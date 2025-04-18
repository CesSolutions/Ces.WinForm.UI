﻿using Microsoft.DotNet.DesignTools.Protocol.Values;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridView : DataGridView
    {
        public CesGridView()
        {
            InitializeComponent();
            SetAppearance();
        }

        #region Private Fields

        private object? MainData;
        private IEnumerable<object> FilteredData = new List<object>();
        private IQueryable<object> query;
        private object TypeInstance;
        private List<CesGridFilterOperation> FilterCollection = new List<CesGridFilterOperation>();
        private Dictionary<string, CesGridSortTypeEnum> SortList = new Dictionary<string, CesGridSortTypeEnum>();
        private Dictionary<string, CesGridFilterTypeEnum> FilterOperation = new Dictionary<string, CesGridFilterTypeEnum>();
        private CesGridFilterAndSort FilterAndSortData = new CesGridFilterAndSort();
        private CesGridViewFilter frm = new();
        private bool _controlKey;
        private Form _loadingForm;

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

        private bool cesSetAppearance { get; set; } = false;
        [Category("Ces GridView")]
        public bool CesSetAppearance
        {
            get { return cesSetAppearance; }
            set
            {
                cesSetAppearance = value;

                if (value)
                    SetAppearance();
            }
        }

        private bool cesUseDarkHeader { get; set; } = true;
        [Category("Ces GridView")]
        public bool CesUseDarkHeader
        {
            get { return cesUseDarkHeader; }
            set
            {
                cesUseDarkHeader = value;
                SetAppearance();
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
                SetAppearance();
            }
        }

        private bool cesClearWithKeys { get; set; } = true;
        [Category("Ces GridView")]
        [Description("If user press Control+D, filter and sort will be cleared.")]
        public bool CesClearWithKeys
        {
            get { return cesClearWithKeys; }
            set { cesClearWithKeys = value; }
        }

        #endregion Properties

        #region Custom Methods

        public void LoadingMode(bool coverParentArea = true)
        {
            if (_loadingForm == null)
                _loadingForm = CesLoadingScreen.Create(this, coverParentArea);
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
                    // انجام فیلترهای مورد نظر کاربر
                    // تمام آیتم های موجود در حلقه تنها یکبار روی لیست می بایست اعمال شود
                    // بنابراین اگر فیلتر جاری در لیست عملیات فیلترینگ وجود نداشته باشد
                    // برنامه فیلتر را اعمال خواهد کرد
                    if (filter.FilterType == CesGridFilterTypeEnum.Equal)
                        FilterForEqual(filter);

                    if (filter.FilterType == CesGridFilterTypeEnum.Contain)
                        FilterForContain(filter);

                    if (filter.FilterType == CesGridFilterTypeEnum.BiggerThan)
                        FilterForBiggerThan(filter);

                    if (filter.FilterType == CesGridFilterTypeEnum.EqualAndBiggerThan)
                        FilterForEqualAndBiggerThan(filter);

                    if (filter.FilterType == CesGridFilterTypeEnum.SmallerThan)
                        FilterForSmallerThan(filter);

                    if (filter.FilterType == CesGridFilterTypeEnum.EqualAndSmallerThan)
                        FilterForEqualAndSmallerThan(filter);

                    if (filter.FilterType == CesGridFilterTypeEnum.Between)
                        FilterForBetween(filter);

                    // اطلاعات فیلتر در هر بار اجرای حلقه باید در لیست عملیات فیلتر کردن
                    // اضافه شود تا همان فیلتر دوبار اعمال نشود چون باعث می شود لیست فاقد خروجی شود
                    FilterOperation.TryAdd(filter.ColumnName, filter.FilterType);
                }

            VerifySortingDataAndExecution();

            // تبدیل فهرست به لیست نهایی و بارگذاری در گرید
            FilteredData = query.ToList();
            this.DataSource = FilteredData;

            if (FilteredData.Count() == 0)
                this.DataSource = TypeInstance;
        }

        private void SetAppearance()
        {
            this.BorderStyle = BorderStyle.None;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.BackgroundColor = Color.White;
            this.GridColor = Color.FromArgb(224, 224, 224);
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            this.EnableHeadersVisualStyles = !CesUseDarkHeader;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = 30;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            this.RowTemplate.Resizable = DataGridViewTriState.True;
            this.RowTemplate.Height = 30;
            this.RowHeadersWidth = 30;
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.RowHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            this.RowHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            this.DefaultCellStyle.SelectionBackColor = Color.Khaki;
            this.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void FilterForEqual(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(string))
                query = query.Where(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString() == filter.CriteriaA.ToString());

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) == decimal.Parse(filter.CriteriaA.ToString()));

            if (colType == typeof(DateTime))
                query = query.Where(x => DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date == DateTime.Parse(filter.CriteriaA.ToString()));

            if (colType == typeof(bool))
                query = query.Where(x => bool.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) == bool.Parse(filter.CriteriaA.ToString()));
        }

        private void FilterForContain(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            query = query.Where(x => x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString().Contains(filter.CriteriaA.ToString()));
        }

        private void FilterForBiggerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) > decimal.Parse(filter.CriteriaA.ToString()));

            if (colType == typeof(DateTime))
                query = query.Where(x => DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date > DateTime.Parse(filter.CriteriaA.ToString()).Date);
        }

        private void FilterForEqualAndBiggerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) >= decimal.Parse(filter.CriteriaA.ToString()));

            if (colType == typeof(DateTime))
                query = query.Where(x => DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date >= DateTime.Parse(filter.CriteriaA.ToString()).Date);
        }

        private void FilterForSmallerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) < decimal.Parse(filter.CriteriaA.ToString()));

            if (colType == typeof(DateTime))
                query = query.Where(x => DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date < DateTime.Parse(filter.CriteriaA.ToString()).Date);
        }

        private void FilterForEqualAndSmallerThan(CesGridFilterOperation filter)
        {
            if (FilterOperation.ContainsKey(filter.ColumnName))
                return;

            Type colType = this.Columns[filter.ColumnName].ValueType;

            if (colType == typeof(decimal) || colType == typeof(int))
                query = query.Where(x => decimal.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()) <= decimal.Parse(filter.CriteriaA.ToString()));

            if (colType == typeof(DateTime))
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

            if (colType == typeof(DateTime))
                query = query.Where(x =>
                DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date >= DateTime.Parse(filter.CriteriaA.ToString()).Date &&
                DateTime.Parse(x.GetType().GetProperties().FirstOrDefault(x => x.Name == filter.ColumnName).GetValue(x).ToString()).Date <= DateTime.Parse(filter.CriteriaB.ToString()).Date
                );
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

            if (FilterAndSortData.CriteriaA is null)
                return;

            // بررسی نوع فیلتر. اگر نوع فیلتر
            // None
            // باشد نباید ثبت شود
            if (FilterAndSortData.FilterType == CesGridFilterTypeEnum.None)
                return;

            // اگر نوع فیلتر نیاز به مقدار داشته باشد
            // بایدآن مقدار بررسی شود و اگر موجود نبود
            // نباید در لیست فیلترها ثبت شود
            if (FilterAndSortData.FilterType != CesGridFilterTypeEnum.Between &&
                string.IsNullOrEmpty(FilterAndSortData.CriteriaA.ToString()))
            {
                MessageBox.Show("Criteria not defined");
                return;
            }

            /// اگر کاربر برای یک ستون فیلترینگ جدید اعمال کند در اینجا باید
            /// بررسی شود که آیا از قبل برای آن ستون در لیست فیلترینگ ها اطلاعاتی
            /// وجود دارد یا خیر. اگر وجود نداشته باشد که یک فیلترینگ جدید به لیست
            /// اضافه خواهد شد ولیاگر از قبل برای ستون فیلتر تعریف شده باشد برنامه
            /// داده های آن فیلتر را برای ستون بروزرسانی خواهد کرد
            /// اعمال فیلتر برای همه نوع ها به غیر از
            /// None
            /// انجام خواهد شد
            var currentFilter = FilterCollection.FirstOrDefault(x => x.ColumnName == FilterAndSortData.ColumnName);

            if (currentFilter == null)
            {
                FilterCollection.Add(new CesGridFilterOperation
                {
                    ColumnName = FilterAndSortData.ColumnName,
                    FilterType = FilterAndSortData.FilterType,
                    CriteriaA = FilterAndSortData.CriteriaA,
                    CriteriaB = FilterAndSortData.CriteriaB

                });
            }
            else
            {
                currentFilter.FilterType = FilterAndSortData.FilterType;
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

        private void OpenPopup(DataGridViewCellMouseEventArgs? e)
        {
            if (frm == null)
                frm = new();

            frm.TopMost = true;

            // جهت نمایش کادر فیلترینگ ابتدا باید مختصات سرستون را بدست آوریم
            // و در زمان ارسال مشخصات بدست آمده، ارتفاع سرستون را به موقعیت 
            // عمودی اضافه میکنم تا کادر در زیر ستون ها نمایش داده شود در غیر
            // اینصورت کادر فیلترینگ روی ستون ها باز خواهد شد

            if (e == null)
                return;

            var columnHeaderLocation = this.PointToScreen(
                this.GetCellDisplayRectangle(
                    e.ColumnIndex,
                    e.RowIndex,
                    false)
                .Location);

            frm.MouseLocation = new Point(columnHeaderLocation.X, columnHeaderLocation.Y + this.ColumnHeadersHeight);

            frm.ColumnIndex = e.ColumnIndex;
            frm.ColumnName = this.Columns[e.ColumnIndex].DataPropertyName;
            frm.ColumnText = this.Columns[e.ColumnIndex].HeaderText;
            frm.ColumnDataType = this.Columns[e.ColumnIndex].ValueType;
            frm.CurrentFilter = FilterCollection.FirstOrDefault(x => x.ColumnName == this.Columns[e.ColumnIndex].DataPropertyName);

            frm.ShowDialog(this.FindForm());
        }

        #endregion Cutom Methods

        #region Override Methods

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnColumnHeaderMouseClick(e);

            // با توجه به اینکه قابلی ت فیلتر کردن فقط برای نوع هایخاصیازستون 
            // در نظر گرفته شده است بنابراین بررسینوع ستون باید درابتدای کار
            // انجام شود و انجام فیلترینگ تنها برای نوع های مورد نظر انجام شود

            if (this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn))
                return;

            if (this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn))
                return;

            // در این مرحله باید بررسی شود که کادر فیلتریک باید 
            // توسط کدام رویداد کلیک اجرا شود

            if (CesEnableFiltering == CesGridFilterActionModeEnum.None)
                return;

            if (CesEnableFiltering == CesGridFilterActionModeEnum.LeftClick && e.Button != MouseButtons.Left)
                return;

            if (CesEnableFiltering == CesGridFilterActionModeEnum.RightClick && e.Button != MouseButtons.Right)
                return;

            // نمایش فرم فیلتر

            OpenPopup(e);

            // اعمال فیلتر مورد نظر

            FilterAndSortData = frm.q;
            ReloadData();
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);

            if (CesEnableFiltering == CesGridFilterActionModeEnum.None)
                return;

            // Ignoring following column type to draw icon
            // because cannot be filter or sort
            if (this.Columns.Count > 0 && e.ColumnIndex > -1 &&
                this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn))
                return;

            if (this.Columns.Count > 0 && e.ColumnIndex > -1 &&
                this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn))
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

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                _controlKey = true;

            if (cesClearWithKeys && _controlKey && e.KeyCode == Keys.D)
            {
                FilterAndSortData = new CesGridFilterAndSort
                {
                    ClearAllFilter = true,
                    ClearAllSort = true,
                };

                ReloadData();
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                _controlKey = false;

            base.OnKeyUp(e);
        }

        #endregion Override Region
    }
}
