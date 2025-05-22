using Ces.WinForm.UI.CesGridView.Events;
using Ces.WinForm.UI.CesListBox;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridView : DataGridView
    {
        public CesGridView()
        {
            InitializeComponent();
            SetTheme();
        }

        public event EventHandler<FilterAndSortOperationDoneEvent> FilterAndSortOperationDone;

        #region Private Fields

        private object? MainData;
        private IEnumerable<object> FilteredData = new List<object>();
        private IQueryable<object> query;
        /// <summary>
        /// این ویژگی پارامترهای فیلترینگ را به ازای هر ستون نگهداری خواهد کرد
        /// در واقع هر ستون اطلاعات فیلترینگ مجزایی می تواند داشته باشند
        /// </summary>
        private List<CesGridFilterOperation> FilterCollection = new List<CesGridFilterOperation>();
        private Dictionary<string, CesGridSortTypeEnum> SortList = new Dictionary<string, CesGridSortTypeEnum>();
        private Dictionary<string, string> FilterOperation = new Dictionary<string, string>();
        private CesGridFilterAndSort FilterAndSortData = new CesGridFilterAndSort();
        private List<string>? UniqeItems { get; set; } = new List<string>();
        private CesGridViewFilter frm = new();
        private Form _loadingForm;
        private CesButton.CesButton _btnClearFilter;
        private Label _lblClearFilter;

        /// <summary>
        /// While GridView Datasource is set, OnSelectionChanged occures
        /// twice. So, to stop this, we must check operation to run event once
        /// </summary>
        private bool settingDataSource;

        #endregion Private Fields

        #region Properties

        private CesGridFilterActionModeEnum cesEnableFiltering { get; set; }
            = CesGridFilterActionModeEnum.LeftClick;
        [Category("Ces GridView")]
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
        [Category("Ces GridView")]
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
        [Category("Ces GridView")]
        [Browsable(false)]
        public object CesDataSource
        {
            get { return cesDataSource; }
            set
            {
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
                MainData = value;
                this.DataSource = value;
                SetTheme();
            }
        }

        #endregion Properties

        #region Custom Methods

        public void LoadingMode(bool coverParentArea = true)
        {
            if (_loadingForm == null || _loadingForm.IsDisposed)
                _loadingForm = CesLoadScreen.Create(this, coverParentArea);
        }

        public void CloseLoadingMode()
        {
            if (_loadingForm != null)
            {
                _loadingForm.Hide();
                _loadingForm.Dispose();
            }
        }

        private void ReloadData()
        {
            if (MainData == null)
                return;

            // لیست اطلاعات فیلتر شده باید برابر لیست اطلاعات اصلی قرار گیرد
            // در ادامه با توجه به داده های دریافت شده از پنجره قیلترینگ، اقدام
            // به تولید لیست فیلتر شده میکنیم و پس از آن داده های فیلتر شده را
            // در گرید نمایش می دهیم
            FilteredData = (IEnumerable<object>)MainData;

            // چون عملیات فیلتر کردن باید در هر بار از ابتدا انجام شود
            // بنابراین لازم است تا لیست عملیات قبلی کاملا پاک شود. البته
            // آنچه که باید انجام شود در لیست دیگری نگهداری می شود
            FilterOperation.Clear();

            VerifyFilteringData();

            // لیست فیلترینگ که معادل لیست اصلی می باشد را به نوعی قابل 
            // فیلتر کردن تبدیل میکنیم
            query = FilteredData.AsQueryable();

            // در یک حلقه تمامی فیلترها را روی لیست اعمال مکینم
            if (FilterCollection.Count > 0)
                foreach (var filter in FilterCollection)
                {
                    ////فیلترهایی که مقدارشان خالی باشد نباید به عنوان 
                    ////فاکتور فیلترگذاری به کالکشن اضافه شوند چون تاثیر
                    ////ندارند
                    //if ((filter.SelectedItems == null || filter.SelectedItems.Count == 0)
                    //    && (filter.CriteriaA == null || string.IsNullOrEmpty(filter.CriteriaA?.ToString())))
                    //    continue;

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

                    else if (filter.Filter == FilterType.Contain)
                        FilterForContain(filter);

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

            // تبدیل فهرست به لیست نهایی و بارگذاری در گرید
            FilteredData = query.ToList();
            this.DataSource = FilteredData;

            if (FilteredData.Count() == 0)
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
            FilterAndSortData = new CesGridFilterAndSort
            {
                ClearAllFilter = true,
                ClearAllSort = true,
            };

            ReloadData();
            this.Controls.Remove(_btnClearFilter);
            this.Controls.Remove(_lblClearFilter);
        }

        private void SetTheme()
        {
            if (CesTheme == Infrastructure.ThemeEnum.None)
                return;

            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        #region Operation of Filter and Sort

        private void FilterForSelectedItems(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(string))
                query = query.Where(x => filter.SelectedItems.Any(item => item.Value.ToString() == x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()));

            else if (colType == typeof(decimal))
                query = query.Where(x => filter.SelectedItems.Any(item => decimal.Parse(item.Value.ToString()) == decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString())));

            else if (colType == typeof(int))
                query = query.Where(x => filter.SelectedItems.Any(item => int.Parse(item.Value.ToString()) == int.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString())));

            else if (colType == typeof(DateTime))
                query = query.Where(x => filter.SelectedItems.Any(item => (DateTime.Parse(item.Value.ToString()).Date == DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date)));

            else if (colType == typeof(bool))
                query = query.Where(x => filter.SelectedItems.Any(item => bool.Parse(item.Value.ToString()) == bool.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString())));
        }

        private void FilterForEqual(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(string))
                query = query.Where(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString() == filter.CriteriaA.ToString());

            else if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) == decimal.Parse(filter.CriteriaA.ToString()));

            else if (colType == typeof(DateTime))
                query = query.Where(x => DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date == DateTime.Parse(filter.CriteriaA.ToString()));

            else if (colType == typeof(bool))
                query = query.Where(x => bool.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) == bool.Parse(filter.CriteriaA.ToString()));
        }

        private void FilterForContain(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            query = query.Where(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString().ToLower().Contains(filter.CriteriaA.ToString().ToLower()));
        }

        private void FilterForBiggerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) > decimal.Parse(filter.CriteriaA.ToString()));

            else if (colType == typeof(DateTime))
                query = query.Where(x => DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date > DateTime.Parse(filter.CriteriaA.ToString()).Date);
        }

        private void FilterForEqualAndBiggerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) >= decimal.Parse(filter.CriteriaA.ToString()));

            else if (colType == typeof(DateTime))
                query = query.Where(x => DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date >= DateTime.Parse(filter.CriteriaA.ToString()).Date);
        }

        private void FilterForSmallerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) < decimal.Parse(filter.CriteriaA.ToString()));

            else if (colType == typeof(DateTime))
                query = query.Where(x => DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date < DateTime.Parse(filter.CriteriaA.ToString()).Date);
        }

        private void FilterForEqualAndSmallerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) <= decimal.Parse(filter.CriteriaA.ToString()));

            else if (colType == typeof(DateTime))
                query = query.Where(x => DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date <= DateTime.Parse(filter.CriteriaA.ToString()).Date);
        }

        private void FilterForBetween(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x =>
                decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) >= decimal.Parse(filter.CriteriaA.ToString()) &&
                decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) <= decimal.Parse(filter.CriteriaB.ToString())
                );

            else if (colType == typeof(DateTime))
                query = query.Where(x =>
                DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date >= DateTime.Parse(filter.CriteriaA.ToString()).Date &&
                DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date <= DateTime.Parse(filter.CriteriaB.ToString()).Date
                );
        }

        private void FilterForStartWith(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            query = query.Where(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString().StartsWith(filter.CriteriaA.ToString()));
        }

        private void FilterForEndWith(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            query = query.Where(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString().EndsWith(filter.CriteriaA.ToString()));
        }

        private void VerifyFilteringData()
        {
            // اگر کاربر قصد حذف تمام فیلترها را داشته باشد
            // باید لیست تمامی فیلترها پاک شود. این لیست نام ستون ها
            // و نوع فیلترینگ را نگهداری می کند
            if (FilterAndSortData.ClearAllFilter)
                FilterCollection.Clear();

            // اگر کاربر قصد حذف فیلتر یک ستون را داشته باشد
            // باید اطلاعات فیلترینگ همان ستون را از لیست حذف کنیم
            if (FilterAndSortData.ClearColumnFilter)
                FilterCollection.Remove(FilterCollection.FirstOrDefault(x => x.ColumnName == FilterAndSortData.ColumnName));

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
                return;
            
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
            // اگر ستون جاری یکبار مرتبشده باشد در صورت تکرار
            // برنامه مرتب سازی برای آن ستون را حذف می کند
            // عملیات مرتب سازی نیز همانند فیلترینگ تنها
            // یکبار روی لیست اعمال می شود. بنابراین اطلاعات ستون
            // باید در یک لیست جهت بررسی این مورد نگهداری شود
            // اگر نوع مرتب سازی
            // None
            // باشد نباید اطلاعات مرتب سازی ستون جاری از لیست حذف شود
            // فقط زمانی که مرتب سازی تکراری بخواهد ثبت شود برنامه اطلاعات
            // مرتب سازی آن ستون را حذف خواهد کرد.
            if (FilterAndSortData.SortType != CesGridSortTypeEnum.None && SortList.ContainsKey(FilterAndSortData.ColumnName))
                SortList.Remove(FilterAndSortData.ColumnName);
            else
            {
                if (FilterAndSortData.SortType != CesGridSortTypeEnum.None)
                    SortList.TryAdd(FilterAndSortData.ColumnName, FilterAndSortData.SortType);
            }

            // اگر کاربر قصد حذف عملیات مرتب سازی داشته باشد
            // لیست مورد نظر باید پاک شود
            if (FilterAndSortData.ClearAllSort)
                SortList.Clear();

            int sortCount = 0;

            // انجام مرتب سازی لیست با توجه به تنظیمات کاربر
            foreach (var sort in SortList)
            {
                // قبل از مرتب سازی ابتدا بررسی می شود که مرتب سازی صعودی است یا نزولی
                // در مرحله بعدی اگر نیاز به اعمال فیلتر بیشتر از یک مرحله باشد برنامه
                // ابتدا لیست را به نوع
                // IOrderedQueryable
                // تبدیل می کند و سپس از 
                // Then
                // برای اعمال مرتب سازی های بعدی استفاده میکنیم
                if (sort.Value == CesGridSortTypeEnum.ASC)
                    if (sortCount == 0)
                        query = query.OrderBy(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == sort.Key).GetValue(x));
                    else
                        query = ((IOrderedQueryable<object>)query)
                            .ThenBy(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == sort.Key).GetValue(x));

                if (sort.Value == CesGridSortTypeEnum.DESC)
                    if (sortCount == 0)
                        query = query.OrderByDescending(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == sort.Key).GetValue(x));
                    else
                        query = ((IOrderedQueryable<object>)query).ThenByDescending(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == sort.Key).GetValue(x));

                sortCount += 1;
            }
        }

        #endregion Operation of Filter and Sort

        private void OpenPopup(CesColumnHeader? cesColumnHeader, DataGridViewCellMouseEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new();
                frm.CesTheme = this.CesTheme;
            }


            // جهت نمایش کادر فیلترینگ ابتدا باید مختصات سرستون را بدست آوریم
            // و در زمان ارسال مشخصات بدست آمده، ارتفاع سرستون را به موقعیت 
            // عمودی اضافه میکنم تا کادر در زیر ستون ها نمایش داده شود در غیر
            // اینصورت کادر فیلترینگ روی ستون ها باز خواهد شد

            if (e == null)
                return;

            Point columnHeaderLocation = new Point();

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
                    return;

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

            frm.ColumnIndex = e.ColumnIndex;
            frm.ColumnName = this.Columns[e.ColumnIndex].DataPropertyName;
            frm.ColumnDataType = this.Columns[e.ColumnIndex].ValueType;
            frm.CurrentFilter = FilterCollection.FirstOrDefault(x
                => x.ColumnName == this.Columns[e.ColumnIndex].DataPropertyName);
            frm.UniqeItems = this.UniqeItems.OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();

            frm.ShowDialog(this.FindForm());
        }

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

            FilterAndSortOperationDone?.Invoke(null, new FilterAndSortOperationDoneEvent
            {
                ColumnIndex = columnIndex,
                SortType = FilterAndSortData.SortType,
                ClearColumnFilter = FilterAndSortData.ClearColumnFilter,
                ClearAllFilter = FilterAndSortData.ClearAllFilter,
                ClearAllSort = FilterAndSortData.ClearAllSort,
                HasFilterignData =
                    !string.IsNullOrEmpty((string?)FilterAndSortData.CriteriaA)
                    || FilterAndSortData.SelectedItems?.Count > 0
            });
        }

        public void AddFilter(string value, int columnIndex)
        {
            var column = this.Columns[columnIndex];

            if (column == null)
                return;

            var filter = new CesGridFilterAndSort
            {
                ColumnIndex = columnIndex,
                ColumnName = column.Name,
                Filter = FilterType.Contain,
                CriteriaA = value,
                ClearColumnFilter = value == null || string.IsNullOrEmpty(value?.ToString())
            };

            FilterAndSortData = filter;
            ExecuteReloadData(columnIndex);
        }

        #endregion Cutom Methods

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

        protected override void OnDataSourceChanged(EventArgs e)
        {
            settingDataSource = true;

            base.OnDataSourceChanged(e);

            settingDataSource = false;
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            if (settingDataSource)
                return;

            base.OnSelectionChanged(e);
        }

        #endregion Override Region
    }
}
