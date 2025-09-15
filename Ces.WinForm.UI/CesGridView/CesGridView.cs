using Ces.WinForm.UI.CesGridView.Events;
using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridView : DataGridView
    {
        public CesGridView()
        {
            InitializeComponent();
            SetTheme();
        }

        public event EventHandler<FilterAndSortCompletedEvent> FilterAndSortCompleted;

        #region Private Fields

        private IQueryable<object> _originalDataSource;
        private IQueryable<object> _finalDataSource;
        private IQueryable<object> _tempQuery;
        /// <summary>
        /// این ویژگی پارامترهای فیلترینگ را به ازای هر ستون نگهداری خواهد کرد
        /// در واقع هر ستون اطلاعات فیلترینگ مجزایی می تواند داشته باشند
        /// </summary>
        private List<CesGridFilterOperation> FilterCollection = new List<CesGridFilterOperation>();
        private Dictionary<string, CesGridSortTypeEnum> SortList = new Dictionary<string, CesGridSortTypeEnum>();
        /// <summary>
        /// این پروپرتی در زمان فیلتر کردن بررسی میکند اگر یک ستون از قبل
        /// با یک نوع فیلتر، فیلتر شده باشد از تکرار آن جلوگیری خواهد کرد
        /// مثلا یک ستون نمی تواند دوبار فیلتر نوع Contain شده باشد
        /// </summary>
        private Dictionary<string, string> FilterOperation = new Dictionary<string, string>();
        private Dictionary<int, bool> FilterHasError = new Dictionary<int, bool>();
        private CesGridFilterAndSort FilterAndSortData = new CesGridFilterAndSort();
        private List<string>? UniqeItems { get; set; } = new List<string>();
        private CesGridViewFilter frm = new();
        private ConcurrentBag<Form> _loadScreens = new();
        private CesButton.CesButton _btnClearFilter;
        private Label _lblClearFilter;

        /// <summary>
        /// While GridView Datasource is set, OnSelectionChanged occures
        /// twice. So, to stop this, we must check operation to run event once
        /// </summary>
        private bool _loadingDataSource;
        private int _currentRowIndex = -1;

        #endregion Private Fields

        #region Properties

        private bool cesStopCerrentCellChangedEventInCurrentRow;
        /// <summary>
        /// اگر تغییر سلول در ردیف جاری باشد می‌توان از رویداد مورد نظر جلوگیری
        /// کرد. ولی اگر سلول در ردیف دیگری انتخاب شود رویداد اجرا خواهد شد
        /// </summary>
        public bool CesStopCerrentCellChangedEventInCurrentRow
        {
            get { return cesStopCerrentCellChangedEventInCurrentRow; }
            set { cesStopCerrentCellChangedEventInCurrentRow = value; }
        }

        private CesGridFilterActionModeEnum cesEnableFiltering { get; set; }
            = CesGridFilterActionModeEnum.LeftClick;
        [Category("CesGridView")]
        public CesGridFilterActionModeEnum CesEnableFiltering
        {
            get { return cesEnableFiltering; }
            set
            {
                cesEnableFiltering = value;

                if (value == CesGridFilterActionModeEnum.None)
                {
                    FilterCollection.Clear();
                    SortList.Clear();
                    FilterAndSortData = new CesGridFilterAndSort();
                    ReloadData();
                }

                this.Invalidate();
            }
        }

        private CesGridViewRowSizeModeEnum cesRowSizeMode { get; set; }
            = CesGridViewRowSizeModeEnum.Normal;
        [Category("CesGridView")]
        public CesGridViewRowSizeModeEnum CesRowSizeMode
        {
            get { return cesRowSizeMode; }
            set
            {
                cesRowSizeMode = value;
                SetTheme();
            }
        }

        private Infrastructure.ThemeEnum cesTheme { get; set; }
            = Infrastructure.ThemeEnum.White;
        [Category("CesGridView")]
        public Infrastructure.ThemeEnum CesTheme
        {
            get { return cesTheme; }
            set
            {
                cesTheme = value;
                SetTheme();
            }
        }

        private object cesDataSource { get; set; }
        [Category("CesGridView")]
        [Browsable(false)]
        public object CesDataSource
        {
            get { return cesDataSource; }
            set
            {
                _loadingDataSource = true;
                SetTheme();

                this.Controls.Remove(_btnClearFilter);
                this.Controls.Remove(_lblClearFilter);

                cesDataSource = null;
                this.DataSource = null;
                cesDataSource = value;

                if (this.Columns.Count > 0)
                    this.Columns.Clear();

                if (this.Rows.Count > 0)
                    this.Rows.Clear();

                FilterCollection.Clear();
                SortList.Clear();
                FilterOperation.Clear();
                FilterAndSortData = new CesGridFilterAndSort();
                NormalizeDataSource(value);
                ShowDataSource();
                _loadingDataSource = false;

                OnCurrentCellChanged(EventArgs.Empty);
                OnSelectionChanged(EventArgs.Empty);
            }
        }

        #endregion Properties

        #region Private Methods

        private void NormalizeDataSource(object dataSource)
        {
            _originalDataSource = Enumerable.Empty<object>().AsQueryable();
            _finalDataSource = Enumerable.Empty<object>().AsQueryable();

            if (dataSource != null)
                if (dataSource is DataTable dt)
                    _originalDataSource = dt.DefaultView.Cast<object>().AsQueryable();
                else if (dataSource is IEnumerable enumerable)
                    _originalDataSource = enumerable.Cast<object>().AsQueryable();
                else
                    throw new ArgumentException("Unsupported data source type.");

            _finalDataSource = _originalDataSource;
        }

        private void ShowDataSource()
        {
            if (_finalDataSource == null)
                return;

            // تبدیل فهرست به لیست نهایی و بارگذاری در گرید
            var data = new BindingList<object>(_finalDataSource.ToList());
            this.DataSource = data;
        }

        /// <summary>
        /// Do not call this method directly. 
        /// Use "ExecuteReloadData" method to raise "FilterAndSortCompleted" event.
        /// Otherwise ReloadData works properly but event dose not raise
        /// </summary>
        private void ReloadData()
        {
            if (_originalDataSource == null)
                return;

            // لیست اطلاعات فیلتر شده باید برابر لیست اطلاعات اصلی قرار گیرد
            // در ادامه با توجه به داده های دریافت شده از پنجره قیلترینگ، اقدام
            // به تولید لیست فیلتر شده میکنیم و پس از آن داده های فیلتر شده را
            // در گرید نمایش می دهیم
            //_finalDataSource = (IQueryable<object>)_originalDataSource;

            // لیست فیلترینگ که معادل لیست اصلی می باشد را به نوعی قابل 
            // فیلتر کردن تبدیل میکنیم
            _finalDataSource = _originalDataSource;

            // چون عملیات فیلتر کردن باید در هر بار از ابتدا انجام شود
            // بنابراین لازم است تا لیست عملیات قبلی کاملا پاک شود. البته
            // آنچه که باید انجام شود در لیست دیگری نگهداری می شود
            FilterOperation.Clear();
            VerifyFilteringData();

            // در یک حلقه تمامی فیلترها را روی لیست اعمال مکینم
            if (FilterCollection.Count > 0)
                foreach (var filter in FilterCollection)
                {
                    // انجام فیلترهای مورد نظر کاربر
                    // تمام آیتم های موجود در حلقه تنها یکبار روی لیست می بایست اعمال شود
                    // بنابراین اگر فیلتر جاری در لیست عملیات فیلترینگ وجود نداشته باشد
                    // برنامه فیلتر را اعمال خواهد کرد

                    //اولویت با آیتم‌های انتخاب شده می‌باشد اما اگر آیتمی 
                    //انتخاب نشده باشد برنامه سایر فیلترها را اعمال خواهد کرد
                    if (filter.SelectedItems != null && filter.SelectedItems.Count > 0)
                        FilterForSelectedItems(filter);

                    else if (filter.Filter == FilterType.Equal)
                        FilterForEqual(filter);

                    else if (filter.Filter == FilterType.NotEqual)
                        FilterForNotEqual(filter);

                    else if (filter.Filter == FilterType.Contain)
                        FilterForContain(filter);

                    else if (filter.Filter == FilterType.NotContain)
                        FilterForNotContain(filter);

                    else if (filter.Filter == FilterType.BiggerThan)
                        FilterForBiggerThan(filter);

                    else if (filter.Filter == FilterType.EqualAndBiggerThan)
                        FilterForEqualAndBiggerThan(filter);

                    else if (filter.Filter == FilterType.SmallerThan)
                        FilterForSmallerThan(filter);

                    else if (filter.Filter == FilterType.EqualAndSmallerThan)
                        FilterForEqualAndSmallerThan(filter);

                    else if (filter.Filter == FilterType.Between)
                        FilterForBetween(filter);

                    else if (filter.Filter == FilterType.StartWith)
                        FilterForStartWith(filter);

                    else if (filter.Filter == FilterType.EndWith)
                        FilterForEndWith(filter);

                    // اطلاعات فیلتر در هر بار اجرای حلقه باید در لیست عملیات فیلتر کردن
                    // اضافه شود تا همان فیلتر دوبار اعمال نشود چون باعث می شود لیست فاقد خروجی شود
                    FilterOperation.TryAdd(filter.ColumnName, filter.Filter);
                }

            VerifySortingDataAndExecution();
            ShowDataSource();

            if (_finalDataSource.Count() == 0)
            {
                _lblClearFilter = new();
                _lblClearFilter.Location = new Point { X = 10, Y = 10 };
                _lblClearFilter.AutoSize = true;
                _lblClearFilter.Text = "No data found with current filter.";
                _lblClearFilter.BackColor = Color.White;
                _lblClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
                this.Controls.Add(_lblClearFilter);

                _btnClearFilter = new();
                _btnClearFilter.Click += ClearFilterClicked;
                _btnClearFilter.Location = new Point { X = 10, Y = 40 };
                _btnClearFilter.Text = "Clear Filter";
                this.Controls.Add(_btnClearFilter);
            }
        }

        private void ClearFilterClicked(object sender, EventArgs e)
        {
            ResetData(true);
        }

        private void ResetData(bool keepSortData)
        {
            FilterAndSortData = new CesGridFilterAndSort
            {
                ClearAllFilter = true,
                ClearAllSort = keepSortData,
            };

            ExecuteReloadData(0);
            this.Controls.Remove(_btnClearFilter);
            this.Controls.Remove(_lblClearFilter);
        }

        private void SetTheme()
        {
            if (CesTheme == Infrastructure.ThemeEnum.None)
                return;

            //this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.EnableHeadersVisualStyles = CesTheme == Infrastructure.ThemeEnum.White ? true : false;
            this.BorderStyle = BorderStyle.None;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;

            //Header
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.RowTemplate.Height = (int)CesRowSizeMode;
            this.RowHeadersWidth = 30;
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Row
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = 30;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //Cell
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;

            if (CesTheme == Infrastructure.ThemeEnum.White)
                ThemeWhite();
            else if (CesTheme == Infrastructure.ThemeEnum.Dark)
                ThemeDark();
        }

        private void ThemeWhite()
        {
            this.BackgroundColor = Color.White;
            this.GridColor = Color.FromArgb(224, 224, 224);

            this.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            this.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.RowHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.Black;
            this.DefaultCellStyle.SelectionBackColor = Color.Khaki;
            this.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void ThemeDark()
        {
            this.BackgroundColor = Color.FromArgb(64, 64, 64);
            this.GridColor = Color.FromArgb(90, 90, 90);

            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 75, 75);
            this.AlternatingRowsDefaultCellStyle.ForeColor = Color.Silver;

            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            this.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.RowHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            this.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.DefaultCellStyle.ForeColor = Color.Silver;
            this.DefaultCellStyle.SelectionBackColor = Color.Khaki;
            this.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
        }

        private void OpenPopup(CesColumnHeader? cesColumnHeader, DataGridViewCellMouseEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new();

            // جهت نمایش کادر فیلترینگ ابتدا باید مختصات سرستون را بدست آوریم
            // و در زمان ارسال مشخصات بدست آمده، ارتفاع سرستون را به موقعیت 
            // عمودی اضافه میکنم تا کادر در زیر ستون ها نمایش داده شود در غیر
            // اینصورت کادر فیلترینگ روی ستون ها باز خواهد شد

            if (e == null)
                return;

            Point columnHeaderLocation = new Point();
            var colheight = 0;

            //موقعیت یا بر مبنای هدر اصلی گرید و یا هدرهای سفارشی باید محاسبه شود
            if (cesColumnHeader == null)
                columnHeaderLocation = this.PointToScreen(
                    this.GetCellDisplayRectangle(
                        e.ColumnIndex,
                        e.RowIndex,
                        false)
                .Location);
            else
                columnHeaderLocation = cesColumnHeader.PointToScreen(Point.Empty);

            UniqeItems?.Clear();
            UniqeItems = null;
            UniqeItems = new();

            foreach (DataGridViewRow row in this.Rows)
            {
                var value = row.Cells[e.ColumnIndex].Value;

                if (value == null)
                    continue;

                if (value.GetType() == typeof(DateTime))
                {
                    if (!UniqeItems.Contains(DateTime.Parse(value.ToString()).ToShortDateString()))
                        UniqeItems.Add(DateTime.Parse(value.ToString()).ToShortDateString());
                }
                else
                {
                    if (!UniqeItems.Contains(value.ToString()))
                        UniqeItems.Add(value.ToString());
                }
            }

            if (cesColumnHeader == null)
                frm.MouseLocation = new Point(columnHeaderLocation.X, columnHeaderLocation.Y + this.ColumnHeadersHeight);
            else
                frm.MouseLocation = new Point(columnHeaderLocation.X, columnHeaderLocation.Y + cesColumnHeader.Height - cesColumnHeader.FilterRowHeight);

            if (cesColumnHeader == null)
                colheight = this.ColumnHeadersHeight;
            else
                colheight = cesColumnHeader.Height - cesColumnHeader.FilterRowHeight;

            frm.ColumnHeight = colheight;
            frm.ColumnIndex = e.ColumnIndex;
            frm.ColumnName = this.Columns[e.ColumnIndex].DataPropertyName;
            frm.ColumnDataType = this.Columns[e.ColumnIndex].ValueType;
            frm.CurrentFilter = FilterCollection.FirstOrDefault(x
                => x.ColumnName == this.Columns[e.ColumnIndex].DataPropertyName);
            frm.UniqeItems = this.UniqeItems.OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();
            frm.CesTheme = this.CesTheme;
            frm.ShowDialog(this.FindForm());
        }

        private void HandleMouseClick(bool isOriginalHeader, CesColumnHeader? cesColumnHeader, DataGridViewCellMouseEventArgs e)
        {
            // با توجه به اینکه قابلی ت فیلتر کردن فقط برای نوع هایخاصیازستون 
            // در نظر گرفته شده است بنابراین بررسینوع ستون باید درابتدای کار
            // انجام شود و انجام فیلترینگ تنها برای نوع های مورد نظر انجام شود
            if (this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn)
                || this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn)
                || this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewImageColumn))
                return;

            // در این مرحله باید بررسی شود که کادر فیلترینگ باید 
            // توسط کدام رویداد کلیک اجرا شود
            if ((CesEnableFiltering == CesGridFilterActionModeEnum.None)
                || (CesEnableFiltering == CesGridFilterActionModeEnum.LeftClick && e.Button != MouseButtons.Left)
                || (CesEnableFiltering == CesGridFilterActionModeEnum.RightClick && e.Button != MouseButtons.Right))
                return;

            // نمایش فرم فیلتر
            OpenPopup(cesColumnHeader, e);

            // اعمال فیلتر مورد نظر
            FilterAndSortData = frm.q;
            ExecuteReloadData(e.ColumnIndex);
        }

        private void ExecuteReloadData(int columnIndex)
        {
            ReloadData();

            FilterAndSortCompleted?.Invoke(null, new FilterAndSortCompletedEvent
            {
                ColumnIndex = columnIndex,
                SortType = FilterAndSortData.SortType,
                ClearColumnFilter = FilterAndSortData.ClearColumnFilter,
                ClearAllFilter = FilterAndSortData.ClearAllFilter,
                ClearAllSort = FilterAndSortData.ClearAllSort,
                HasFilteringData =
                    !string.IsNullOrEmpty((string?)FilterAndSortData.CriteriaA)
                    || FilterAndSortData.SelectedItems?.Count > 0,
                HasFilteringError = FilterHasError.ContainsKey(columnIndex)
            });
        }

        #endregion Private Methods

        #region Operation of Filter and Sort

        private object GetColumnValue(object row, string columnName)
        {
            if (row is DataRowView drv)            
                return drv.Row[columnName] == DBNull.Value ? null : drv.Row[columnName];    
            
            else if (row is DataRow dr)            
                return dr[columnName] == DBNull.Value ? null : dr[columnName];      
            
            else
            {
                // fallback for POCO/class objects
                var prop = row.GetType().GetProperty(columnName);
                return prop?.GetValue(row);
            }
        }

        private void FilterForSelectedItems(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource.AsEnumerable().AsQueryable();
            var query = _finalDataSource.AsEnumerable();
            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(string) || colType == typeof(Guid) || colType == typeof(Guid?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           filter.SelectedItems.Any(item => item.Value.ToString() == val.ToString());
                });
            }
            else if (colType == typeof(int) || colType == typeof(int?) ||
                     colType == typeof(decimal) || colType == typeof(decimal?) ||
                     colType == typeof(double) || colType == typeof(double?) ||
                     colType == typeof(long) || colType == typeof(long?) ||
                     colType == typeof(float) || colType == typeof(float?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           filter.SelectedItems.Any(item =>
                               double.Parse(item.Value.ToString()) == double.Parse(val.ToString()));
                });
            }
            else if (colType == typeof(DateTime) || colType == typeof(DateTime?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           filter.SelectedItems.Any(item =>
                               DateTime.Parse(item.Value.ToString()).Date == DateTime.Parse(val.ToString()).Date);
                });
            }
            else if (colType == typeof(bool) || colType == typeof(bool?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           filter.SelectedItems.Any(item =>
                               bool.Parse(item.Value.ToString()) == bool.Parse(val.ToString()));
                });
            }

            _finalDataSource = query.AsQueryable();

            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForEqual(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            //if (colType == typeof(string) || colType == typeof(Guid) || colType == typeof(Guid?))
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString() == filter.CriteriaA.ToString());

            //else if (colType == typeof(int) || colType == typeof(int?)
            //    || colType == typeof(decimal) || colType == typeof(decimal?)
            //    || colType == typeof(double) || colType == typeof(double?)
            //    || colType == typeof(long) || colType == typeof(long?)
            //    || colType == typeof(float) || colType == typeof(float?)
            //    )
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && double.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) == double.Parse(filter.CriteriaA.ToString()));

            //else if (colType == typeof(DateTime) || colType == typeof(DateTime?))
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date == DateTime.Parse(filter.CriteriaA.ToString()));

            //else if (colType == typeof(bool) || colType == typeof(bool))
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && bool.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) == bool.Parse(filter.CriteriaA.ToString()));
            var query = _finalDataSource.AsEnumerable();

            if (colType == typeof(string) || colType == typeof(Guid) || colType == typeof(Guid?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null && val.ToString() == filter.CriteriaA?.ToString();
                });
            }
            else if (colType == typeof(int) || colType == typeof(int?) ||
                     colType == typeof(decimal) || colType == typeof(decimal?) ||
                     colType == typeof(double) || colType == typeof(double?) ||
                     colType == typeof(long) || colType == typeof(long?) ||
                     colType == typeof(float) || colType == typeof(float?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           double.Parse(val.ToString()) == double.Parse(filter.CriteriaA.ToString());
                });
            }
            else if (colType == typeof(DateTime) || colType == typeof(DateTime?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           DateTime.Parse(val.ToString()).Date == DateTime.Parse(filter.CriteriaA.ToString()).Date;
                });
            }
            else if (colType == typeof(bool) || colType == typeof(bool?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           bool.Parse(val.ToString()) == bool.Parse(filter.CriteriaA.ToString());
                });
            }

            // Convert back to IQueryable
            _finalDataSource = query.AsQueryable();
            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForNotEqual(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            //if (colType == typeof(string) || colType == typeof(Guid) || colType == typeof(Guid?))
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString() != filter.CriteriaA.ToString());

            //else if (colType == typeof(int) || colType == typeof(int?)
            //    || colType == typeof(decimal) || colType == typeof(decimal?)
            //    || colType == typeof(double) || colType == typeof(double?)
            //    || colType == typeof(long) || colType == typeof(long?)
            //    || colType == typeof(float) || colType == typeof(float?)
            //    )
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && double.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) != double.Parse(filter.CriteriaA.ToString()));

            //else if (colType == typeof(DateTime) || colType == typeof(DateTime))
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date != DateTime.Parse(filter.CriteriaA.ToString()));

            //else if (colType == typeof(bool) || colType == typeof(bool))
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && bool.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) != bool.Parse(filter.CriteriaA.ToString()));
            var query = _finalDataSource.AsEnumerable();

            if (colType == typeof(string) || colType == typeof(Guid) || colType == typeof(Guid?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null && val.ToString() != filter.CriteriaA?.ToString();
                });
            }
            else if (colType == typeof(int) || colType == typeof(int?) ||
                     colType == typeof(decimal) || colType == typeof(decimal?) ||
                     colType == typeof(double) || colType == typeof(double?) ||
                     colType == typeof(long) || colType == typeof(long?) ||
                     colType == typeof(float) || colType == typeof(float?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           double.Parse(val.ToString()) != double.Parse(filter.CriteriaA.ToString());
                });
            }
            else if (colType == typeof(DateTime) || colType == typeof(DateTime?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           DateTime.Parse(val.ToString()).Date != DateTime.Parse(filter.CriteriaA.ToString()).Date;
                });
            }
            else if (colType == typeof(bool) || colType == typeof(bool?))
            {
                query = query.Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName);
                    return val != null &&
                           bool.Parse(val.ToString()) != bool.Parse(filter.CriteriaA.ToString());
                });
            }

            // Convert back to IQueryable
            _finalDataSource = query.AsQueryable();
            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForContain(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            //_finalDataSource = _finalDataSource.Where(x
            //    => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //    && x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString().ToLower().Contains(filter.CriteriaA.ToString().ToLower()));
            var query = _finalDataSource.AsEnumerable()
                .Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName)?.ToString();
                    return val != null &&
                           val.Contains(filter.CriteriaA?.ToString() ?? "", StringComparison.OrdinalIgnoreCase);
                });

            _finalDataSource = query.AsQueryable();
            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForNotContain(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            //_finalDataSource = _finalDataSource.Where(x
            //    => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //    && !x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString().ToLower().Contains(filter.CriteriaA.ToString().ToLower()));
            var query = _finalDataSource.AsEnumerable()
                .Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName)?.ToString();
                    return val != null &&
                           !val.Contains(filter.CriteriaA?.ToString() ?? "", StringComparison.OrdinalIgnoreCase);
                });

            _finalDataSource = query.AsQueryable();
            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForBiggerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            //if (colType == typeof(int) || colType == typeof(int?)
            //    || colType == typeof(decimal) || colType == typeof(decimal?)
            //    || colType == typeof(double) || colType == typeof(double?)
            //    || colType == typeof(long) || colType == typeof(long?)
            //    || colType == typeof(float) || colType == typeof(float?)
            //    )
            //{
            //    var criteria = double.TryParse(filter.CriteriaA.ToString(), out double result);
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && double.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) > result);
            //}

            //else if (colType == typeof(DateTime))
            //{
            //    var criteria = DateTime.TryParse(filter.CriteriaA.ToString(), out DateTime result);
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date > result.Date);
            //}
            var query = _finalDataSource.AsEnumerable();

            if (colType == typeof(int) || colType == typeof(int?) ||
                colType == typeof(decimal) || colType == typeof(decimal?) ||
                colType == typeof(double) || colType == typeof(double?) ||
                colType == typeof(long) || colType == typeof(long?) ||
                colType == typeof(float) || colType == typeof(float?))
            {
                if (double.TryParse(filter.CriteriaA?.ToString(), out double criteria))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        return val != null && double.Parse(val.ToString()) > criteria;
                    });
                }
            }
            else if (colType == typeof(DateTime) || colType == typeof(DateTime?))
            {
                if (DateTime.TryParse(filter.CriteriaA?.ToString(), out DateTime criteria))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        return val != null &&
                               DateTime.Parse(val.ToString()).Date > criteria.Date;
                    });
                }
            }

            _finalDataSource = query.AsQueryable();
            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForEqualAndBiggerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            //if (colType == typeof(int) || colType == typeof(int?)
            //    || colType == typeof(decimal) || colType == typeof(decimal?)
            //    || colType == typeof(double) || colType == typeof(double?)
            //    || colType == typeof(long) || colType == typeof(long?)
            //    || colType == typeof(float) || colType == typeof(float?)
            //    )
            //{
            //    var criteria = double.TryParse(filter.CriteriaA.ToString(), out double result);
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && double.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) >= result);
            //}

            //else if (colType == typeof(DateTime) || colType == typeof(DateTime))
            //{
            //    var criteria = DateTime.TryParse(filter.CriteriaA.ToString(), out DateTime result);
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date >= result.Date);
            //}
            var query = _finalDataSource.AsEnumerable();

            if (IsNumericType(colType))
            {
                if (double.TryParse(filter.CriteriaA?.ToString(), out double criteria))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        return val != null && double.Parse(val.ToString()) >= criteria;
                    });
                }
            }
            else if (IsDateType(colType))
            {
                if (DateTime.TryParse(filter.CriteriaA?.ToString(), out DateTime criteria))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        return val != null && DateTime.Parse(val.ToString()).Date >= criteria.Date;
                    });
                }
            }

            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForSmallerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            //if (colType == typeof(int) || colType == typeof(int?)
            //    || colType == typeof(decimal) || colType == typeof(decimal?)
            //    || colType == typeof(double) || colType == typeof(double?)
            //    || colType == typeof(long) || colType == typeof(long?)
            //    || colType == typeof(float) || colType == typeof(float?)
            //    )
            //{
            //    var criteria = double.TryParse(filter.CriteriaA.ToString(), out double result);
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && double.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) < result);
            //}

            //else if (colType == typeof(DateTime) || colType == typeof(DateTime?))
            //{
            //    var criteria = DateTime.TryParse(filter.CriteriaA.ToString(), out DateTime result);
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date < result.Date);
            //}
            var query = _finalDataSource.AsEnumerable();

            if (IsNumericType(colType))
            {
                if (double.TryParse(filter.CriteriaA?.ToString(), out double criteria))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        return val != null && double.Parse(val.ToString()) < criteria;
                    });
                }
            }
            else if (IsDateType(colType))
            {
                if (DateTime.TryParse(filter.CriteriaA?.ToString(), out DateTime criteria))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        return val != null && DateTime.Parse(val.ToString()).Date < criteria.Date;
                    });
                }
            }

            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForEqualAndSmallerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            //if (colType == typeof(int) || colType == typeof(int?)
            //    || colType == typeof(decimal) || colType == typeof(decimal?)
            //    || colType == typeof(double) || colType == typeof(double?)
            //    || colType == typeof(long) || colType == typeof(long?)
            //    || colType == typeof(float) || colType == typeof(float?)
            //    )
            //{
            //    var criteria = double.TryParse(filter.CriteriaA.ToString(), out double result);
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && double.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) <= result);
            //}

            //else if (colType == typeof(DateTime) || colType == typeof(DateTime?))
            //{
            //    var criteria = DateTime.TryParse(filter.CriteriaA.ToString(), out DateTime result);
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date <= result.Date);
            //}
            var query = _finalDataSource.AsEnumerable();

            if (IsNumericType(colType))
            {
                if (double.TryParse(filter.CriteriaA?.ToString(), out double criteria))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        return val != null && double.Parse(val.ToString()) <= criteria;
                    });
                }
            }
            else if (IsDateType(colType))
            {
                if (DateTime.TryParse(filter.CriteriaA?.ToString(), out DateTime criteria))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        return val != null && DateTime.Parse(val.ToString()).Date <= criteria.Date;
                    });
                }
            }

            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForBetween(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            //if (colType == typeof(int) || colType == typeof(int?)
            //    || colType == typeof(decimal) || colType == typeof(decimal?)
            //    || colType == typeof(double) || colType == typeof(double?)
            //    || colType == typeof(long) || colType == typeof(long?)
            //    || colType == typeof(float) || colType == typeof(float?)
            //    )
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && double.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) >= double.Parse(filter.CriteriaA.ToString())
            //        && double.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) <= double.Parse(filter.CriteriaB.ToString())
            //    );

            //else if (colType == typeof(DateTime) || colType == typeof(DateTime?))
            //    _finalDataSource = _finalDataSource.Where(x
            //        => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //        && DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date >= DateTime.Parse(filter.CriteriaA.ToString()).Date
            //        && DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date <= DateTime.Parse(filter.CriteriaB.ToString()).Date
            //    );

            var query = _finalDataSource.AsEnumerable();

            if (IsNumericType(colType))
            {
                if (double.TryParse(filter.CriteriaA?.ToString(), out double min) &&
                    double.TryParse(filter.CriteriaB?.ToString(), out double max))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        if (val == null) return false;
                        var d = double.Parse(val.ToString());
                        return d >= min && d <= max;
                    });
                }
            }
            else if (IsDateType(colType))
            {
                if (DateTime.TryParse(filter.CriteriaA?.ToString(), out DateTime min) &&
                    DateTime.TryParse(filter.CriteriaB?.ToString(), out DateTime max))
                {
                    query = query.Where(x =>
                    {
                        var val = GetColumnValue(x, filter.ColumnName);
                        if (val == null) return false;
                        var d = DateTime.Parse(val.ToString()).Date;
                        return d >= min.Date && d <= max.Date;
                    });
                }
            }

            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForStartWith(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            //_finalDataSource = _finalDataSource.Where(x
            //    => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //    && x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString().StartsWith(filter.CriteriaA.ToString()));
            var query = _finalDataSource.AsEnumerable()
                 .Where(x =>
                 {
                     var val = GetColumnValue(x, filter.ColumnName)?.ToString();
                     return val != null && val.StartsWith(filter.CriteriaA?.ToString() ?? "");
                 });

            ApplyQueryWithRollback(query, filter);

            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void FilterForEndWith(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            _tempQuery = _finalDataSource;

            //_finalDataSource = _finalDataSource.Where(x
            //    => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x) != null
            //    && x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString().EndsWith(filter.CriteriaA.ToString()));
            var query = _finalDataSource.AsEnumerable()
                .Where(x =>
                {
                    var val = GetColumnValue(x, filter.ColumnName)?.ToString();
                    return val != null && val.EndsWith(filter.CriteriaA?.ToString() ?? "");
                });

            ApplyQueryWithRollback(query, filter);
            //if (_finalDataSource.Count() == 0)
            //{
            //    if (!FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Add(filter.ColumnIndex, true);

            //    _finalDataSource = _tempQuery;
            //}
            //else
            //{
            //    if (FilterHasError.ContainsKey(filter.ColumnIndex))
            //        FilterHasError.Remove(filter.ColumnIndex);
            //}
        }

        private void ApplyQueryWithRollback(IEnumerable<object> query, CesGridFilterOperation filter)
        {
            _finalDataSource = query.AsQueryable();
            if (!_finalDataSource.Any())
            {
                if (!FilterHasError.ContainsKey(filter.ColumnIndex))
                    FilterHasError.Add(filter.ColumnIndex, true);
                _finalDataSource = _tempQuery; // rollback
            }
            else
            {
                FilterHasError.Remove(filter.ColumnIndex);
            }
        }

        private bool IsNumericType(Type type)
        {
            return type == typeof(int) || type == typeof(int?) ||
                   type == typeof(decimal) || type == typeof(decimal?) ||
                   type == typeof(double) || type == typeof(double?) ||
                   type == typeof(long) || type == typeof(long?) ||
                   type == typeof(float) || type == typeof(float?);
        }

        private bool IsDateType(Type type)
        {
            return type == typeof(DateTime) || type == typeof(DateTime?);
        }

        private void VerifyFilteringData()
        {
            // اگر کاربر قصد حذف تمام فیلترها را داشته باشد
            // باید لیست تمامی فیلترها پاک شود. این لیست نام ستون ها
            // و نوع فیلترینگ را نگهداری می کند
            if (FilterAndSortData.ClearAllFilter)
            {
                FilterCollection.Clear();
                FilterHasError.Clear();
            }

            // اگر کاربر قصد حذف فیلتر یک ستون را داشته باشد
            // باید اطلاعات فیلترینگ همان ستون را از لیست حذف کنیم
            if (FilterAndSortData.ClearColumnFilter)
            {
                FilterCollection.Remove(FilterCollection.FirstOrDefault(x => x.ColumnName == FilterAndSortData.ColumnName));

                if (FilterHasError.ContainsKey(FilterAndSortData.ColumnIndex))
                    FilterHasError.Remove(FilterAndSortData.ColumnIndex);
            }

            if ((FilterAndSortData.SelectedItems == null || FilterAndSortData.SelectedItems?.Count == 0)
                && FilterAndSortData.CriteriaA is null)
                return;

            // اگر نوع فیلتر None باشد نباید ثبت شود
            if ((FilterAndSortData.SelectedItems == null || FilterAndSortData.SelectedItems?.Count == 0)
                && FilterAndSortData.Filter == FilterType.None)
                return;

            // اگر نوع فیلتر نیاز به مقدار داشته باشد
            // بایدآن مقدار بررسی شود و اگر موجود نبود
            // نباید در لیست فیلترها ثبت شود
            if ((FilterAndSortData.SelectedItems == null || FilterAndSortData.SelectedItems?.Count == 0)
                && FilterAndSortData.Filter != FilterType.Between
                && string.IsNullOrEmpty(FilterAndSortData.CriteriaA.ToString()))
            {
                if (FilterHasError.ContainsKey(FilterAndSortData.ColumnIndex))
                    FilterHasError.Remove(FilterAndSortData.ColumnIndex);

                return;
            }

            /// اگر کاربر برای یک ستون فیلترینگ جدید اعمال کند در اینجا باید
            /// بررسی شود که آیا از قبل برای آن ستون در لیست فیلترینگ اطلاعاتی
            /// وجود دارد یا خیر. اگر وجود نداشته باشد که یک فیلترینگ جدید به لیست
            /// اضافه خواهد شد ولی اگر از قبل برای ستون فیلتر تعریف شده باشد برنامه
            /// داده‌های آن فیلتر را برای ستون بروزرسانی خواهد کرد
            /// اعمال فیلتر برای همه نوع‌ها به غیر از
            /// None
            /// انجام خواهد شد
            var currentFilter = FilterCollection.FirstOrDefault(x => x.ColumnName == FilterAndSortData.ColumnName);

            if (currentFilter == null)
            {
                FilterCollection.Add(new CesGridFilterOperation
                {
                    ColumnIndex = FilterAndSortData.ColumnIndex,
                    ColumnName = FilterAndSortData.ColumnName,
                    Filter = FilterAndSortData.Filter,
                    CriteriaA = FilterAndSortData.CriteriaA,
                    CriteriaB = FilterAndSortData.CriteriaB,
                    SelectedItems = FilterAndSortData.SelectedItems
                });
            }
            else
            {
                currentFilter.Filter = FilterAndSortData.Filter;
                currentFilter.CriteriaA = FilterAndSortData.CriteriaA;
                currentFilter.CriteriaB = FilterAndSortData.CriteriaB;
            }
        }

        private void VerifySortingDataAndExecution()
        {
            //اگر ستون جاری از قبل دارای اطلاعات مرتب سازی باشد
            //مقدار جدید جایگزین خواهد شد در غیراینصورت یک
            //مقدار جدید به لیست اضافه می‌گردد
            var columnHasSort = SortList.ContainsKey(FilterAndSortData.ColumnName);

            if (columnHasSort)
                SortList[FilterAndSortData.ColumnName] = FilterAndSortData.SortType;
            else
                SortList.TryAdd(FilterAndSortData.ColumnName, FilterAndSortData.SortType);

            if (FilterAndSortData.ClearColumnFilter)
            {
                if (columnHasSort)
                    SortList.Remove(FilterAndSortData.ColumnName);
            }

            // اگر کاربر قصد حذف عملیات مرتب سازی داشته باشد
            // لیست مورد نظر باید پاک شود
            if (FilterAndSortData.ClearAllSort)
            {
                SortList.Clear();
                return;
            }

            int sortCount = 0;

            // انجام مرتب سازی لیست با توجه به تنظیمات کاربر
            foreach (var sort in SortList)
            {
                //حتما اگر نوع مرتب سازی 
                //None
                //بود باید حلقه بعدی اجرا شود چون اگر اجرا شود
                //یک واحد به شمارنده اضافه میشود که باعت میشود
                //مرتب سازی با  متد
                //ThenBy
                //انجام شود که باعث ایجاد خطا خواهد شد
                if (sort.Value == CesGridSortTypeEnum.None)
                    continue;

                // قبل از مرتب سازی ابتدا بررسی می شود که مرتب سازی صعودی است یا نزولی
                // در مرحله بعدی اگر نیاز به اعمال فیلتر بیشتر از یک مرحله باشد برنامه
                // ابتدا لیست را به نوع
                // IOrderedQueryable
                // تبدیل می کند و سپس از 
                // Then
                // برای اعمال مرتب سازی های بعدی استفاده میکنیم
                //if (sort.Value == CesGridSortTypeEnum.ASC)
                //    if (sortCount == 0)
                //        _finalDataSource = _finalDataSource.OrderBy(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == sort.Key).GetValue(x));
                //    else
                //        _finalDataSource = ((IOrderedQueryable<object>)_finalDataSource)
                //            .ThenBy(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == sort.Key).GetValue(x));

                //else if (sort.Value == CesGridSortTypeEnum.DESC)
                //    if (sortCount == 0)
                //        _finalDataSource = _finalDataSource.OrderByDescending(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == sort.Key).GetValue(x));
                //    else
                //        _finalDataSource = ((IOrderedQueryable<object>)_finalDataSource).ThenByDescending(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == sort.Key).GetValue(x));


                if (sort.Value == CesGridSortTypeEnum.ASC)
                {
                    if (sortCount == 0)
                    {
                        _finalDataSource = _finalDataSource
                            .OrderBy(x => GetValueByName(x, sort.Key));
                    }
                    else
                    {
                        _finalDataSource = ((IOrderedQueryable<object>)_finalDataSource)
                            .ThenBy(x => GetValueByName(x, sort.Key));
                    }
                }
                else if (sort.Value == CesGridSortTypeEnum.DESC)
                {
                    if (sortCount == 0)
                    {
                        _finalDataSource = _finalDataSource
                            .OrderByDescending(x => GetValueByName(x, sort.Key));
                    }
                    else
                    {
                        _finalDataSource = ((IOrderedQueryable<object>)_finalDataSource)
                            .ThenByDescending(x => GetValueByName(x, sort.Key));
                    }
                }

                sortCount += 1;
            }
        }

        private static object? GetValueByName(object obj, string columnName)
        {
            if (obj is DataRowView drv)
            {
                return drv.Row[columnName] == DBNull.Value ? null : drv.Row[columnName];
            }

            var prop = obj.GetType().GetProperty(columnName);
            return prop?.GetValue(obj);
        }

        #endregion Operation of Filter and Sort

        #region Public Methods

        /// <summary>
        /// این متد توسط هدر سفارشی فراخوانی می شود و رویداد کلیک
        /// ماوس روی هدر گرید را اجرا خواهد کرد
        /// </summary>
        /// <param name="isOriginalHeader"></param>
        /// <param name="e"></param>
        public void OpenFilteringDialog(CesColumnHeader cesColumnHeader, DataGridViewCellMouseEventArgs e)
        {
            HandleMouseClick(false, cesColumnHeader, e);
        }

        public void AddFilter(string filterValue, int columnIndex)
        {
            if (this.ColumnCount == 0)
                ResetData(false);

            var column = this.Columns[columnIndex];

            if (column == null)
                return;

            var filterType = FilterType.Contain;
            var criteria = string.Empty;

            if (filterValue != null)
            {
                var valueLength = filterValue.ToString().Length;

                if (filterValue.ToString().StartsWith("="))
                {
                    filterType = FilterType.Equal;

                    if (valueLength > 1)
                        criteria = filterValue.ToString().AsSpan(1).ToString();
                }

                else if (filterValue.ToString().StartsWith("@"))
                {
                    filterType = FilterType.NotContain;

                    if (valueLength > 1)
                        criteria = filterValue.ToString().AsSpan(1).ToString();
                }

                else if (filterValue.ToString().StartsWith("!"))
                {
                    filterType = FilterType.NotEqual;

                    if (valueLength > 1)
                        criteria = filterValue.ToString().AsSpan(1).ToString();
                }

                else if (filterValue.ToString().StartsWith(">"))
                {
                    filterType = FilterType.BiggerThan;

                    if (valueLength > 1)
                        criteria = filterValue.ToString().AsSpan(1).ToString();
                }

                else if (filterValue.ToString().StartsWith(">="))
                {
                    filterType = FilterType.EqualAndBiggerThan;

                    if (valueLength > 2)
                        criteria = filterValue.ToString().AsSpan(2).ToString();
                }

                else if (filterValue.ToString().StartsWith("<"))
                {
                    filterType = FilterType.SmallerThan;

                    if (valueLength > 1)
                        criteria = filterValue.ToString().AsSpan(1).ToString();
                }

                else if (filterValue.ToString().StartsWith("<="))
                {
                    filterType = FilterType.EqualAndSmallerThan;

                    if (valueLength > 2)
                        criteria = filterValue.ToString().AsSpan(2).ToString();
                }

                else if (filterValue.ToString().StartsWith("?"))
                {
                    filterType = FilterType.StartWith;

                    if (valueLength > 1)
                        criteria = filterValue.ToString().AsSpan(1).ToString();
                }

                else if (filterValue.ToString().StartsWith("%"))
                {
                    filterType = FilterType.EndWith;

                    if (valueLength > 1)
                        criteria = filterValue.ToString().AsSpan(1).ToString();
                }

                else
                {
                    filterType = FilterType.Contain;
                    criteria = filterValue.ToString();
                }
            }

            var filter = new CesGridFilterAndSort
            {
                ColumnIndex = columnIndex,
                ColumnName = column.Name,
                Filter = filterType,
                CriteriaA = criteria,
                ClearColumnFilter = filterValue == null || string.IsNullOrEmpty(filterValue?.ToString()),
                SortType = SortList.GetValueOrDefault(column.Name),
            };

            FilterAndSortData = filter;
            ExecuteReloadData(columnIndex);
        }

        /// <summary>
        /// این متد برای خالی کردن منبع دیتا استفاده می‌شود
        /// ولی ستون‌ها رو حفظ خواهد کرد
        /// </summary>
        public void Clear()
        {
            var sourceType = _originalDataSource?.GetType();

            if (sourceType == null)
                return;

            var blankSourceType = Activator.CreateInstance(sourceType);
            CesDataSource = blankSourceType;
        }

        public void LoadingMode(bool coverParentArea = true, bool coverParentForm = false, string title = "Loading...")
        {
            Application.DoEvents();
            var loadScreen = CesLoadScreen.Create(this, coverParentArea, coverParentForm, title);
            _loadScreens.Add(loadScreen);
        }

        public void CloseLoadingMode()
        {
            foreach (Form ls in _loadScreens)
                ls.Dispose();

            _loadScreens.Clear();
        }

        /// <summary>
        /// Remove item from GridView & DataSource
        /// </summary>
        /// <param name="row"></param>
        public void RemoveRow(DataGridViewRow row)
        {
            if (row.DataBoundItem != null)
            {
                var bindingList = new BindingList<object>(_originalDataSource.ToList());
                bindingList?.Remove(row.DataBoundItem);
                this.Rows.Remove(row);

                _originalDataSource = bindingList.ToList().AsQueryable();
            }
        }

        #endregion Public Methods

        #region Override Methods

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnColumnHeaderMouseClick(e);
            HandleMouseClick(true, null, e);
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);

            if (CesEnableFiltering == CesGridFilterActionModeEnum.None)
                return;

            // Ignoring following column type to draw icon
            // because cannot be filter or sort
            if (this.Columns.Count > 0 && e.ColumnIndex != -1 &&
                (this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn)
                || this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn)
                || this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewImageColumn)))
                return;

            if (e.RowIndex == -1 & e.ColumnIndex > -1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Size iconSize = new Size(14, 14);

                // رسم آیکن فیلتر
                // اگر ستون جاری در لیست ستون های دارای فیلتر وجود داشته باشد
                // بنابراین باید آیکن فیلتر فعال نمایش داده شود در غیر اینصورت
                // یا نباید آیکنی نمایش داده شود و یا یک آیکن کم رنگ نمایش داده شود

                // Draw filtering icons

                if (FilterCollection.Any(x => x.ColumnName == this.Columns[e.ColumnIndex].DataPropertyName))
                    e.Graphics.DrawImage(
                        Ces.WinForm.UI.Properties.Resources.CesGridViewFilterSet,
                        new Rectangle(
                            new Point(
                                (this.RightToLeft == RightToLeft.Yes ? e.CellBounds.Left + 2 : e.CellBounds.Right - 18),
                                e.CellBounds.Y + 5),
                            iconSize));
                else
                    e.Graphics.DrawImage(
                        Ces.WinForm.UI.Properties.Resources.CesGridViewFilterNotSet,
                        new Rectangle(
                            new Point(
                                (this.RightToLeft == RightToLeft.Yes ? e.CellBounds.Left + 2 : e.CellBounds.Right - 18),
                                e.CellBounds.Y + 5),
                            iconSize));

                // Draw sorting icons

                var currentColumn = SortList.FirstOrDefault(x => x.Key == this.Columns[e.ColumnIndex].Name);

                if (currentColumn.Key is not null)
                {
                    if (currentColumn.Value == CesGridSortTypeEnum.ASC)
                        e.Graphics.DrawImage(
                            Ces.WinForm.UI.Properties.Resources.CesGridViewSortAscending,
                            new Rectangle(
                                new Point(
                                    (this.RightToLeft == RightToLeft.Yes ? e.CellBounds.Left + 18 : e.CellBounds.Right - 35),
                                    e.CellBounds.Y + 5),
                                iconSize));

                    if (currentColumn.Value == CesGridSortTypeEnum.DESC)
                        e.Graphics.DrawImage(
                            Ces.WinForm.UI.Properties.Resources.CesGridViewSortDescending,
                            new Rectangle(
                                new Point(
                                    (this.RightToLeft == RightToLeft.Yes ? e.CellBounds.Left + 18 : e.CellBounds.Right - 35),
                                    e.CellBounds.Y + 5),
                                iconSize));
                }

                e.Handled = true;
            }
        }

        /// <summary>
        /// باپیاده سازی زیر، بعد از تخصیص داده به گرید
        /// هیچ ردیف و سلولی در حالت انتخاب قرار نخواهد 
        /// داشت و مقدار زیر نول خواهند بود
        /// CurrentCell & CurrentRow
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDataSourceChanged(EventArgs e)
        {
            this.ClearSelection();
            base.OnDataSourceChanged(e);
            this.CurrentCell = null;
        }

        //متد زیر الزاما باید برای جلوگیری از تکرار اجرای رویداد
        //SelectionChanged
        //پیاده سازی شود
        protected override void OnSelectionChanged(EventArgs e)
        {
            if (_loadingDataSource)
                return;

            base.OnSelectionChanged(e);
        }


        /// <summary>
        /// در این هندلر می‌توان در صورتی که ضروری باشد از اجرای رویداد
        /// در ردیف جاری جلوگیری کرد مگر آنکه کاربر در ردیف دیگری کلیک نماید
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCurrentCellChanged(EventArgs e)
        {
            if (CesStopCerrentCellChangedEventInCurrentRow
                && this.CurrentCell != null
                && this.CurrentCell.RowIndex == _currentRowIndex)
                return;

            if (_loadingDataSource)
                return;

            if (this.CurrentCell != null)
                _currentRowIndex = this.CurrentCell.RowIndex;

            base.OnCurrentCellChanged(e);
        }

        #endregion Override Region
    }
}
