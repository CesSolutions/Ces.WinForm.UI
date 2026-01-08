using Ces.WinForm.UI.CesGridView.Events;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing.Design;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridViewPro : UserControl
    {
        public CesGridViewPro()
        {
            _initializing = true;
            InitializeComponent();
            InitializeHeaders(20);
            CesTitleVisible = false;
            _initializing = false;
        }

        public event EventHandler<OptionsButtonClickEvent> OptionsButtonClick;
        private ConcurrentBag<Form> _loadScreens = new();
        private bool _loading;
        private bool _clearFilteringValue;
        /// <summary>
        /// پهنای ستون در هر حال نباید از  مقدار زیر کمتر باشد چون
        /// یا عنوان ستون قابل مشاهده نخواهد بود و یا دکمه‌های
        /// فیلتر و مرتب‌سازی پنهان خواهند شد
        /// </summary>
        private int _criticalMinimumColumnWidth = 75;
        /// <summary>
        /// چنانچه کاربر پهنای ستون‌ها را تغییر داده باشد، اندازه جدید در این
        /// لیست نگهداری خواهد شد  و بعد از بارگذاری دوباره اطلاعات، پهنای ستون
        /// مجدد تنظیم خواهد شد. جهت انجام این کار باید گزینه زیر فعال باشد
        /// CesKeepColumnWidth
        /// </summary>        
        private Dictionary<string, int> _columnWidth = new Dictionary<string, int>();
        /// <summary>
        /// دو متغیر زیر در دو متد جداگانه مقدار دهی و کنترل می‌شوند. علت آن است که اگر کاربر
        /// با جابجایی هدر قصد تغییر پهنا را داشت رویداد تغییر پهنای گرید باید مقدار
        /// زیر را بررسی کند تا اگر این تغییر ناشی از تغییر هدر بود دیگر کدهای رویداد
        /// اجرا نشوند و برعکس اگر کاربر پهنای ستون را از گرید تغییر داد رویداد مربوط به
        /// هدر اجرا نشود چون یک چرخه بی پایان بوود خواهد آمد
        /// </summary>
        private bool _initializing;

        #region Events

        public event EventHandler<DataGridViewCellEventArgs> GridViewCellClick;
        public event EventHandler<DataGridViewCellEventArgs> GridViewCellContentClick;
        public event EventHandler<DataGridViewCellEventArgs> GridViewCellContentDoubleClick;
        public event EventHandler<DataGridViewCellEventArgs> GridViewCellDoubleClick;
        public event EventHandler<DataGridViewCellEventArgs> GridViewCellEnter;
        public event EventHandler<DataGridViewCellEventArgs> GridViewCellLeave;
        public event EventHandler<DataGridViewCellMouseEventArgs> GridViewCellMouseClick;
        public event EventHandler<DataGridViewCellMouseEventArgs> GridViewCellMouseDoubleClick;
        public event EventHandler<DataGridViewCellMouseEventArgs> GridViewCellMouseDown;
        public event EventHandler<DataGridViewCellEventArgs> GridViewCellMouseEnter;
        public event EventHandler<DataGridViewCellEventArgs> GridViewCellMouseLeave;
        public event EventHandler<DataGridViewCellMouseEventArgs> GridViewCellMouseUp;
        public event EventHandler<DataGridViewCellPaintingEventArgs> GridViewCellPainting;
        public event EventHandler<DataGridViewCellEventArgs> GridViewCellValidated;
        public event EventHandler<DataGridViewCellValidatingEventArgs> GridViewCellValidating;
        public event EventHandler<DataGridViewCellEventArgs> GridViewCellValueChanged;
        public event EventHandler<DataGridViewColumnEventArgs> GridViewColumnAdded;
        public event EventHandler<DataGridViewColumnEventArgs> GridViewColumnRemoved;
        public event EventHandler<KeyEventArgs> GridViewKeyDown;
        public event EventHandler<KeyPressEventArgs> GridViewKeyPress;
        public event EventHandler<KeyEventArgs> GridViewKeyUp;
        public event EventHandler<PaintEventArgs> GridViewPaint;
        public event EventHandler<EventArgs> GridViewSelectionChanged;
        public event EventHandler<DataGridViewRowEventArgs> GridViewUserAddedRow;
        public event EventHandler<DataGridViewRowEventArgs> GridViewUserDeletedRow;
        public event EventHandler<DataGridViewRowCancelEventArgs> GridViewUserDeletingRow;
        public event EventHandler<EventArgs> GridViewValidated;
        public event EventHandler<CancelEventArgs> GridViewValidating;
        public event EventHandler<DataGridViewCellEventArgs> GridViewRowEnter;
        public event EventHandler<EventArgs> GridViewCurrentCellChanged;
        public event EventHandler<FilterAndSortCompletedEvent> GridViewFilterAndSortCompleted;

        #endregion Events

        #region Properties

        /// <summary>
        /// این پروپرتی ستون‌های سفارشی ایجاد شده را بر می‌گرداند
        /// CesColumnHeader
        /// </summary>
        [Browsable(false)]
        public List<CesColumnHeader> CesHeaders
        {
            get
            {
                List<CesColumnHeader> result = new();

                //لیست هدرهایی که شماره ایندکس آنها بزرگتر از -1 باشد برگردانده خواهد شد
                //با توجه به اینکه گرید دارای هدرهای پیش‌فرض است و اگر داده‌هایی که ستون‌های
                //کمتری داشته باشند، هدرهای اضافه مخفی و ایندکس آنها برابر -1 خواهد شد تا بتوان
                //در مدیریت هدرها اقدام مناسب را انجام داد
                foreach (CesColumnHeader header in flpHeader.Controls.OfType<CesColumnHeader>())
                    if (header.CesIndex > -1)
                        result.Add(header);

                return result;
            }
        }

        //private RightToLeft RightToLeft { get; set; } = RightToLeft.No;
        //[Category("CesGridViewPro")]
        //public RightToLeft RightToLeft
        //{
        //    get
        //    {
        //        return RightToLeft;
        //    }
        //    set
        //    {
        //        RightToLeft = value;
        //        SetRightToLeft();
        //    }
        //}

        private bool cesStopCerrentCellChangedEventInCurrentRow;
        /// <summary>
        /// اگر تغییر سلول در ردیف جاری باشد می‌توان از رویداد مورد نظر جلوگیری
        /// کرد. ولی اگر سلول در ردیف دیگری انتخاب شود رویداد اجرا خواهد شد
        /// </summary>
        [Category("CesGridViewPro")]
        public bool CesStopCerrentCellChangedEventInCurrentRow
        {
            get { return cesStopCerrentCellChangedEventInCurrentRow; }
            set
            {
                cesStopCerrentCellChangedEventInCurrentRow = value;
                dgv.CesStopCerrentCellChangedEventInCurrentRow = value;
            }
        }

        private CesGridViewRowSizeModeEnum cesRowSizeMode { get; set; }
            = CesGridViewRowSizeModeEnum.Normal;
        [Category("CesGridViewPro")]
        public CesGridViewRowSizeModeEnum CesRowSizeMode
        {
            get { return cesRowSizeMode; }
            set
            {
                cesRowSizeMode = value;
                dgv.CesRowSizeMode = value;
            }
        }

        private Infrastructure.ThemeEnum cesTheme { get; set; }
            = Infrastructure.ThemeEnum.White;
        [Category("CesGridViewPro")]
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
        [Category("CesGridViewPro")]
        [Browsable(false)]
        public object CesDataSource
        {
            get { return cesDataSource; }
            set
            {
                cesDataSource = value;
                LoadDataSource(value);
            }
        }

        private bool cesEnableFilteringRow { get; set; } = true;
        [Category("CesGridViewPro")]
        public bool CesEnableFilteringRow
        {
            get { return cesEnableFilteringRow; }
            set
            {
                cesEnableFilteringRow = value;

                foreach (CesColumnHeader col in flpHeader.Controls)
                    col.CesEnableFilter = value;
            }
        }

        private int cesHeaderHeight { get; set; } = 60;
        [Category("CesGridViewPro")]
        public int CesHeaderHeight
        {
            get { return cesHeaderHeight; }
            set
            {
                cesHeaderHeight = value;
                pnlHeaderRow.Height = value;

                foreach (CesColumnHeader col in flpHeader.Controls)
                    col.Height = value;
            }
        }

        private ContentAlignment cesHeaderTextAlignment { get; set; }
            = ContentAlignment.MiddleCenter;
        [Category("CesGridViewPro")]
        public ContentAlignment CesHeaderTextAlignment
        {
            get { return cesHeaderTextAlignment; }
            set
            {
                cesHeaderTextAlignment = value;

                foreach (CesColumnHeader col in flpHeader.Controls)
                    col.CesHeaderTextAlignment = value;
            }
        }

        private ContentAlignment cesTitleTextAlignment { get; set; }
            = ContentAlignment.MiddleCenter;
        [Category("CesGridViewPro")]
        public ContentAlignment CesTitleTextAlignment
        {
            get { return cesTitleTextAlignment; }
            set
            {
                cesTitleTextAlignment = value;
                lblTitle.TextAlign = value;
            }
        }

        private bool cesLimitToColumnMinSize { get; set; } = true;
        [Category("CesGridViewPro")]
        public bool CesLimitToColumnMinSize
        {
            get
            {
                return cesLimitToColumnMinSize;
            }
            set
            {
                cesLimitToColumnMinSize = value;
            }
        }

        private bool cesRestoreColumnWidth { get; set; } = true;
        [Category("CesGridViewPro")]
        [Description("Keep column width to restore after loading data")]
        public bool CesRestoreColumnWidth
        {
            get
            {
                return cesRestoreColumnWidth;
            }
            set
            {
                cesRestoreColumnWidth = value;
            }
        }

        private bool cesTitleVisible { get; set; } = false;
        [Category("CesGridViewPro")]
        public bool CesTitleVisible
        {
            get { return cesTitleVisible; }
            set
            {
                cesTitleVisible = value;
                lblTitle.Visible = value;
            }
        }

        private string cesTitle { get; set; } = "Title";
        [Category("CesGridViewPro")]
        public string CesTitle
        {
            get { return cesTitle; }
            set
            {
                cesTitle = value;
                lblTitle.Text = value;
            }
        }

        private Color cesTitleColor { get; set; } = Color.DimGray;
        [Category("CesGridViewPro")]
        public Color CesTitleColor
        {
            get { return cesTitleColor; }
            set
            {
                cesTitleColor = value;
                lblTitle.ForeColor = value;
            }
        }

        private bool cesEnableOptions { get; set; }
        [Category("CesGridViewPro")]
        public bool CesEnableOptions
        {
            get { return cesEnableOptions; }
            set
            {
                cesEnableOptions = value;
                btnOptions.Visible = value;
            }
        }

        private Font cesHeaderFont { get; set; } = new Font("Segoe UI", 9);
        [Category("CesGridViewPro")]
        public Font CesHeaderFont
        {
            get { return cesHeaderFont; }
            set
            {
                cesHeaderFont = value ?? new Font("Segoe UI", 9);

                foreach (CesColumnHeader col in flpHeader.Controls)
                    col.CesTitleFont = CesHeaderFont;
            }
        }

        private Color cesHeaderTextColor { get; set; }
        [Category("CesGridViewPro")]
        public Color CesHeaderTextColor
        {
            get { return cesHeaderTextColor; }
            set
            {
                cesHeaderTextColor = value;

                foreach (CesColumnHeader col in flpHeader.Controls)
                    col.CesTitleColor = value;
            }
        }

        #endregion Properties      

        #region Original Properties

        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set
            {
                base.RightToLeft = value;
                SetRightToLeft();
            }
        }

        [Browsable(false)]
        [DefaultValue(0)]
        [Description("DataGridView")]
        public int RowCount { get { return dgv.RowCount; } }

        [Browsable(false)]
        [Description("DataGridView")]
        public DataGridViewRowCollection Rows { get { return dgv.Rows; } }

        [Browsable(false)]
        [Description("DataGridView")]
        public DataGridViewSelectedRowCollection SelectedRows { get { return dgv.SelectedRows; } }

        [Browsable(false)]
        [Description("DataGridView")]
        public DataGridViewSelectedColumnCollection SelectedColumns { get { return dgv.SelectedColumns; } }

        [Browsable(false)]
        [Description("DataGridView")]
        public DataGridViewSelectedCellCollection SelectedCells { get { return dgv.SelectedCells; } }

        [Browsable(false)]
        [Description("DataGridView")]
        public DataGridViewRow CurrentRow { get { return dgv.CurrentRow; } }

        [Browsable(false)]
        [Description("DataGridView")]
        public Point CurrentCellAddress { get { return dgv.CurrentCellAddress; } }

        [Browsable(false)]
        [Description("DataGridView")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCell CurrentCell { get { return dgv.CurrentCell; } set { dgv.CurrentCell = value; } }

        [Browsable(false)]
        [Description("DataGridView")]
        public int ColumnCount { get { return dgv.ColumnCount; } }

        //---------------------------------------Browsable Properties

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool RowHeadersVisible { get { return dgv.RowHeadersVisible; } set { dgv.RowHeadersVisible = value; } }

        [AmbientValue(null)]
        [Description("DataGridView")]
        public DataGridViewCellStyle RowHeadersDefaultCellStyle { get { return dgv.RowHeadersDefaultCellStyle; } set { dgv.RowHeadersDefaultCellStyle = value; } }

        [DefaultValue(DataGridViewHeaderBorderStyle.Raised)]
        public DataGridViewHeaderBorderStyle RowHeadersBorderStyle { get { return dgv.RowHeadersBorderStyle; } set { dgv.RowHeadersBorderStyle = value; } }

        [DefaultValue(false)]
        [Description("DataGridView")]
        public bool ReadOnly { get { return dgv.ReadOnly; } set { dgv.ReadOnly = value; } }

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool MultiSelect { get { return dgv.MultiSelect; } set { dgv.MultiSelect = value; } }

        [Description("DataGridView")]
        public int RowHeadersWidth { get { return dgv.RowHeadersWidth; } set { dgv.RowHeadersWidth = value; } }

        [Description("DataGridView")]
        public Color GridColor { get { return dgv.GridColor; } set { dgv.GridColor = value; } }

        [Description("DataGridView")]
        public DataGridViewCellStyle RowsDefaultCellStyle { get { return dgv.RowsDefaultCellStyle; } set { dgv.RowsDefaultCellStyle = value; } }

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool ShowRowErrors { get { return dgv.ShowRowErrors; } set { dgv.ShowRowErrors = value; } }

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool ShowCellToolTips { get { return dgv.ShowCellToolTips; } set { dgv.ShowCellToolTips = value; } }

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool ShowCellErrors { get { return dgv.ShowCellErrors; } set { dgv.ShowCellErrors = value; } }

        [DefaultValue(DataGridViewSelectionMode.RowHeaderSelect)]
        public DataGridViewSelectionMode SelectionMode { get { return dgv.SelectionMode; } set { dgv.SelectionMode = value; } }

        [DefaultValue(ScrollBars.Both)]
        [Localizable(true)]
        [Description("DataGridView")]
        public ScrollBars ScrollBars { get { return dgv.ScrollBars; } set { dgv.ScrollBars = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("DataGridView")]
        public DataGridViewRow RowTemplate { get { return dgv.RowTemplate; } set { dgv.RowTemplate = value; } }

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool ShowEditingIcon { get { return dgv.ShowEditingIcon; } set { dgv.ShowEditingIcon = value; } }

        [DefaultValue(DataGridViewAutoSizeRowsMode.None)]
        [Description("DataGridView")]
        public DataGridViewAutoSizeRowsMode AutoSizeRowsMode { get { return dgv.AutoSizeRowsMode; } set { dgv.AutoSizeRowsMode = value; } }

        [DefaultValue(DataGridViewAutoSizeColumnsMode.None)]
        [Description("DataGridView")]
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get { return dgv.AutoSizeColumnsMode; } set { dgv.AutoSizeColumnsMode = value; } }

        [Description("DataGridView")]
        public DataGridViewCellStyle AlternatingRowsDefaultCellStyle { get { return dgv.AlternatingRowsDefaultCellStyle; } set { dgv.AlternatingRowsDefaultCellStyle = value; } }

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool AllowUserToResizeRows { get { return dgv.AllowUserToResizeRows; } set { dgv.AllowUserToResizeRows = value; } }

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool AllowUserToResizeColumns { get { return dgv.AllowUserToResizeColumns; } set { dgv.AllowUserToResizeColumns = value; } }

        [DefaultValue(false)]
        [Description("DataGridView")]
        public bool AllowUserToOrderColumns { get { return dgv.AllowUserToOrderColumns; } set { dgv.AllowUserToOrderColumns = value; } }

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool AllowUserToDeleteRows { get { return dgv.AllowUserToDeleteRows; } set { dgv.AllowUserToDeleteRows = value; } }

        [DefaultValue(true)]
        [Description("DataGridView")]
        public bool AllowUserToAddRows { get { return dgv.AllowUserToAddRows; } set { dgv.AllowUserToAddRows = value; } }

        [AmbientValue(null)]
        [Description("DataGridView")]
        public DataGridViewCellStyle DefaultCellStyle { get { return dgv.DefaultCellStyle; } set { dgv.DefaultCellStyle = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(false)]
        [Description("DataGridView")]
        public DataGridViewColumnCollection Columns { get { return dgv.Columns; } }

        [DefaultValue(DataGridViewCellBorderStyle.Single)]
        [Description("DataGridView")]
        public DataGridViewCellBorderStyle CellBorderStyle { get { return dgv.CellBorderStyle; } set { dgv.CellBorderStyle = value; } }

        #endregion Original Properties

        #region Private Methods        

        private void LoadDataSource(object dataSource)
        {
            _loading = true;
            dgv.CesDataSource = dataSource;
            CreateHeaderRow();
            ClearFilter(true);
            _loading = false;
            ResetHeaderRow();
        }

        private void SetRightToLeft()
        {
            if (_loading || _initializing)
                return;

            this.SuspendLayout();
            pnlHeaderRow.SuspendLayout();
            flpHeader.SuspendLayout();

            //همیشه باید این تنظیم ثابت باشد
            flpHeader.RightToLeft = RightToLeft.No;

            if (RightToLeft == RightToLeft.Yes || RightToLeft == RightToLeft.No)
            {
                foreach (CesColumnHeader col in flpHeader.Controls.OfType<CesColumnHeader>())
                    col.RightToLeft = RightToLeft;

                dgv.RightToLeft = RightToLeft;
            }

            if (RightToLeft == RightToLeft.Yes)
            {
                flpHeader.FlowDirection = FlowDirection.RightToLeft;
                pnlOption.Dock = DockStyle.Right;
                RowHeaderSeparator.Dock = DockStyle.Left;
            }
            else if (RightToLeft == RightToLeft.No)
            {
                flpHeader.FlowDirection = FlowDirection.LeftToRight;
                pnlOption.Dock = DockStyle.Left;
                RowHeaderSeparator.Dock = DockStyle.Right;
            }

            LoadDataSource(CesDataSource);
            flpHeader.ResumeLayout(true);
            pnlHeaderRow.ResumeLayout(true);
            this.ResumeLayout(true);
        }

        private void SetTheme()
        {
            foreach (CesColumnHeader col in flpHeader.Controls)
                col.CesTheme = CesTheme;

            dgv.CesTheme = CesTheme;

            this.SuspendLayout();

            if (CesTheme == Infrastructure.ThemeEnum.None)
                ThemeNone();
            else if (CesTheme == Infrastructure.ThemeEnum.White)
                ThemeWhite();
            else if (CesTheme == Infrastructure.ThemeEnum.Dark)
                ThemeDark();

            this.ResumeLayout(true);
        }

        private void ThemeNone()
        {

        }

        private void ThemeWhite()
        {
            lblTitle.BackColor = Color.White;
            lblTitle.ForeColor = Color.DimGray;
            lineRowHeaderTop.BackColor = Color.White;
            lineRowHeaderTop.CesLineColor = Color.FromArgb(224, 224, 224);
            lineRowHeaderBottom.BackColor = Color.White;
            lineRowHeaderBottom.CesLineColor = Color.FromArgb(224, 224, 224);
            lineRowFooterTop.BackColor = Color.White;
            lineRowFooterTop.CesLineColor = Color.FromArgb(224, 224, 224);
            pnlHeaderRow.BackColor = Color.White;
            pnlOption.BackColor = Color.White;
            RowHeaderSeparator.CesBackColor = Color.FromArgb(224, 224, 224);
            RowHeaderSeparator.CesLineColor = Color.FromArgb(224, 224, 224);
            pnlHeaderRow.BackColor = Color.White;
            flpHeader.BackColor = Color.White;
            dgv.GridColor = Color.FromArgb(224, 224, 224);
            btnOptions.Image = Properties.Resources.CesGridViewOptionsWhite;
            btnOptions.CesColorTemplate = CesButton.ColorTemplateEnum.White;
        }

        private void ThemeDark()
        {
            lblTitle.BackColor = Color.FromArgb(64, 64, 64);
            lblTitle.ForeColor = Color.Silver;
            lineRowHeaderTop.BackColor = Color.FromArgb(64, 64, 64);
            lineRowHeaderTop.CesLineColor = Color.FromArgb(90, 90, 90);
            lineRowHeaderBottom.BackColor = Color.FromArgb(64, 64, 64);
            lineRowHeaderBottom.CesLineColor = Color.FromArgb(90, 90, 90);
            lineRowFooterTop.BackColor = Color.FromArgb(64, 64, 64);
            lineRowFooterTop.CesLineColor = Color.FromArgb(90, 90, 90);
            pnlHeaderRow.BackColor = Color.FromArgb(64, 64, 64);
            pnlOption.BackColor = Color.FromArgb(64, 64, 64);
            RowHeaderSeparator.CesBackColor = Color.FromArgb(90, 90, 90);
            RowHeaderSeparator.CesLineColor = Color.FromArgb(90, 90, 90);
            pnlHeaderRow.BackColor = Color.FromArgb(64, 64, 64);
            flpHeader.BackColor = Color.FromArgb(64, 64, 64);
            dgv.GridColor = Color.FromArgb(90, 90, 90);
            btnOptions.Image = Properties.Resources.CesGridViewOptionsDark;
            btnOptions.CesColorTemplate = CesButton.ColorTemplateEnum.Dark;
        }

        private void ClearFilter(bool keepSortOrder)
        {
            _clearFilteringValue = true;

            foreach (CesColumnHeader col in flpHeader.Controls)
                if (!string.IsNullOrEmpty(col.CesFilterValue?.Trim()))
                    col.CesFilterValue = "";

            dgv.ClearFilter(keepSortOrder);
            _clearFilteringValue = false;
        }

        private void CreateHeaderRow()
        {
            var totalColumns = dgv.ColumnCount;
            var totalHeaders = flpHeader.Controls.Count;
            var totalValidColumn = 0;

            //قبل از هر اقدامی برای تولید هدر باید بررسی کنیم
            //اگر هدرهای موجود با ستون های جاری یکسان بود دیگر
            //نیازی به تولید مجدد و اقدام تکراری نیست که با این
            //کار عملیات بارگذاری داده‌ها سریعتر انجام خواهد شد
            foreach (DataGridViewColumn col in dgv.Columns)
                foreach (CesColumnHeader header in flpHeader.Controls.OfType<CesColumnHeader>())
                    if (header.Name == col.Name)
                        totalValidColumn += 1;

            //افزودن هدر جدید در صورتی که تعداد ستون‌ها بیشتر ازتعداد هدر اولیه باشد
            if (totalValidColumn != dgv.ColumnCount && totalColumns > totalHeaders)
                InitializeHeaders(totalColumns - totalHeaders);

            this.SuspendLayout();
            flpHeader.SuspendLayout();
            ObjectsVisibility(false);
            SetOptionWidth();

            //تعداد هدرهای قابل مشاهده باید باتعداد هدرهای گرید برابر باشند
            //در واقع آخرین ایندکس قابل مشاهده برابر تعداد ستون‌های گرید است
            //و مابقی مخفی می‌شوند
            foreach (CesColumnHeader col in flpHeader.Controls)
                if (col.CesIndex > -1 && col.CesIndex < dgv.ColumnCount)
                {
                    col.Visible = true;
                }
                else
                {
                    col.CesIndex = -1;
                    col.Visible = false;
                }

            var columns = new List<DataGridViewColumn>();

            foreach (DataGridViewColumn col in dgv.Columns)
                columns.Add(col);

            //در اینجا قصد داریم تا پهنای حداکثری ستون‌ها را برحسب پهنای سلولی
            //که بیشترین فضا را گرفته است محاسبه کنیم. اگر از متدهای موجود استفاده
            //کنیم بعد از تغییر حالت پهنای خودکار ستو‌ها مجددا به حالت اول بازخواهند
            //گشت و هماهنگ‌‌سازی پهنای ستون با در بدرستی انجام نمی‌شود. بنابراین
            //باید بصورتدستی آن را مدیریت کنیم
            var maxColumnsWidth = new Dictionary<string, int>();

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            foreach (DataGridViewColumn col in dgv.Columns)
                maxColumnsWidth.Add(col.Name, col.Width);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataGridViewColumn col in dgv.Columns)
                col.Width = maxColumnsWidth[col.Name] < _criticalMinimumColumnWidth ? _criticalMinimumColumnWidth : maxColumnsWidth[col.Name];

            foreach (DataGridViewColumn col in columns.OrderBy(x => x.Index))
            {
                var columnHeader = flpHeader.Controls[col.Index] as CesColumnHeader;
                columnHeader.Name = col.Name;
                columnHeader.CesTitle = col.HeaderText;

                //بدلیل آنکه هدر در مرحله دوم اضافه می‌شود باید پهنای ستون در گرید
                //را مطابق پهنای هدر تنظیم کنیم در غیر اینصورت پهنای اولیه ستون‌های
                //در گرید اعمال خواهد شد. در انجام این کار باید تنظیم زیر لحاظ شود
                //تا در صورت نیاز همان پهنای قبلی بازگردانده شود
                if (CesRestoreColumnWidth && _columnWidth.ContainsKey(col.Name))
                {
                    if (CesLimitToColumnMinSize && _columnWidth[col.Name] < columnHeader.CesHeaderMinWidth)
                    {
                        col.Width = columnHeader.CesHeaderMinWidth;
                    }
                    else
                    {
                        columnHeader.Width = _columnWidth[col.Name] < _criticalMinimumColumnWidth ? _criticalMinimumColumnWidth : _columnWidth[col.Name];
                        col.Width = _columnWidth[col.Name] < _criticalMinimumColumnWidth ? _criticalMinimumColumnWidth : _columnWidth[col.Name];
                    }
                }
                else
                {
                    if (CesLimitToColumnMinSize && col.Width < columnHeader.CesHeaderMinWidth)
                    {
                        col.Width = columnHeader.CesHeaderMinWidth;
                    }
                    else
                    {
                        columnHeader.Width = col.Width < _criticalMinimumColumnWidth ? _criticalMinimumColumnWidth : col.Width;
                    }
                }

                columnHeader.Visible = col.Visible;
                columnHeader.CesIndex = col.Index;

                columnHeader.FilterTextChanged += (s, e) =>
                {
                    if (_loading || _clearFilteringValue || columnHeader.CesIndex < 0)
                        return;

                    dgv.AddFilter(e.Filter, columnHeader.CesIndex);
                };

                columnHeader.ColumnHeaderClick += (s, e) =>
                {
                    if (_loading || columnHeader.CesIndex < 0)
                        return;

                    DataGridViewCellMouseEventArgs args = new DataGridViewCellMouseEventArgs(
                        columnHeader.CesIndex,
                        -1,
                        0,
                        0,
                        new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)
                    );

                    dgv.OpenFilteringDialog(columnHeader, args);
                };
            }

            flpHeader.Top = 0;
            ObjectsVisibility(true);
            flpHeader.ResumeLayout(true);
            this.ResumeLayout(true);
        }

        /// <summary>
        /// برای جلوگیری از اتلاف وقت در زمان اجرای برنامه که ممکن است
        /// کاربر چندین بار اقدام به بارگذاری اطلاعات کند بهتر است هدرهای
        /// اولیه ایجاد شوند و متناسب با تعداد ستون‌های گرید تعداد هدرها
        /// تنظیم شوند
        /// </summary>
        /// <param name="totalHeaders"></param>
        private void InitializeHeaders(int totalHeaders)
        {
            this.SuspendLayout();
            flpHeader.SuspendLayout();
            ObjectsVisibility(false);
            SetOptionWidth();

            //حتما باید تعداد هدر موجود در یک متغیر نگهداری شود چون در زمان
            //حلقه اگر هدر اضافه شود متغیر شمارنده تعداد جدید را برمی‌گرداند
            //و در تولید تعداد هدر موردنیاز به مشکل برخواهیم خورد
            var totalExistingHeaders = flpHeader.Controls.Count;

            for (int i = totalExistingHeaders; i < totalExistingHeaders + totalHeaders; i++)
            {
                var columnHeader = new CesColumnHeader();
                columnHeader.SuspendLayout();
                columnHeader.CesIndex = i;
                columnHeader.Visible = false;
                columnHeader.Height = CesHeaderHeight;
                columnHeader.CesTheme = CesTheme;
                columnHeader.CesEnableFilter = this.CesEnableFilteringRow;

                flpHeader.Controls.Add(columnHeader);
                columnHeader.ResumeLayout();
            }

            flpHeader.Top = 0;
            ObjectsVisibility(true);
            dgv.FilterAndSortCompleted -= FilterAndSortCompleted;
            dgv.FilterAndSortCompleted += FilterAndSortCompleted;
            flpHeader.ResumeLayout(true);
            this.ResumeLayout(true);
        }

        private void ObjectsVisibility(bool visible)
        {
            flpHeader.Visible = visible;
            pnlOption.Visible = visible;
            RowHeaderSeparator.Visible = visible;
        }

        private void SetOptionWidth()
        {
            pnlOption.Visible = dgv.RowHeadersVisible;
            pnlOption.Width = dgv.RowHeadersWidth;
            RowHeaderSeparator.Visible = dgv.RowHeadersVisible;
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Remove item from GridView & DataSource
        /// </summary>
        /// <param name="row"></param>
        public void RemoveRow(DataGridViewRow row)
        {
            this.dgv.RemoveRow(row);
        }

        /// <summary>
        /// بعداز افزودن و یا حذف یک ستون می‌بایست این متد توسط
        /// توسعه دهنده صدا زده شود تا هدرها مجدد ایجاد شوند. امکان
        /// صدا زدن این متد در رویداد افزودن و حذف ستون وجود ندارد
        /// چون در زمان فیلتر کردن گرید به تعداد داده‌های فیلترینگ
        /// هدرها مجددا ایجاد می‌شوند که ضروری نیست و باعث کند شدن
        /// عملیات‌ها در گرید می‌شود
        /// </summary>
        public void RefreshGrid()
        {
            if (_loading)
                return;

            CreateHeaderRow();
        }

        /// <summary>
        /// حذف منبع داده از گرید
        /// </summary>
        public void Clear()
        {
            dgv.Clear();
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

        public CesColumnHeader? ColumnHeader(string columnName)
        {
            CesColumnHeader? result = null;

            foreach (CesColumnHeader col in flpHeader.Controls)
                if (col.Name == columnName)
                {
                    result = col;
                    break;
                }

            return result;
        }

        public CesColumnHeader? ColumnHeader(int columnIndex)
        {
            CesColumnHeader? result = null;

            foreach (CesColumnHeader col in flpHeader.Controls)
                if (col.CesIndex == columnIndex)
                {
                    result = col;
                    break;
                }

            return result;
        }

        public void EnableHeaderFilter(string columnName, bool enable)
        {
            foreach (CesColumnHeader col in flpHeader.Controls)
                if (col.Name == columnName)
                {
                    col.CesEnableFilter = enable;
                    return;
                }
        }

        public void EnableHeaderFilter(int columnIndex, bool enable)
        {
            foreach (CesColumnHeader col in flpHeader.Controls)
                if (col.CesIndex == columnIndex)
                {
                    col.CesEnableFilter = enable;
                    return;
                }
        }

        public void SetColumnColor(int columnIndex, Color color)
        {
            foreach (CesColumnHeader col in pnlHeaderRow.Controls)
                if (col.CesIndex == columnIndex)
                    col.CesTitleColor = color;
        }

        public void SetColumnColor(string columnName, Color color)
        {
            foreach (CesColumnHeader col in pnlHeaderRow.Controls)
                if (col.Name == columnName)
                    col.CesTitleColor = color;
        }

        #endregion Public Methods

        #region Custom Events

        private void FilterAndSortCompleted(object? sender, FilterAndSortCompletedEvent e)
        {
            foreach (CesColumnHeader col in flpHeader.Controls)
            {
                if (e.ClearAllSort)
                    col.CesSortType = CesGridSortTypeEnum.None;

                if (e.ClearAllFilter || (col.CesIndex == e.ColumnIndex && e.ClearColumnFilter))
                {
                    col.CesHasFilter = false;
                    col.CesFilterHasError = false;
                }

                if (col.CesIndex != e.ColumnIndex)
                    continue;

                col.CesSortType = e.SortType;

                if (e.HasFilteringData)
                    col.CesHasFilter = e.HasFilteringData;
            }

            GridViewFilterAndSortCompleted?.Invoke(sender, e);
        }

        private void dgv_FilterAndSortCompleted(object sender, FilterAndSortCompletedEvent e)
        {
            if (_clearFilteringValue)
                return;

            if (e.ClearAllFilter)
                ClearFilter(true);

            if (e.ClearColumnFilter)
            {
                _clearFilteringValue = true;
                ((CesColumnHeader)flpHeader.Controls[e.ColumnIndex]).CesFilterValue = "";
                _clearFilteringValue = false;
            }
        }

        #endregion Custom Events

        #region Original Events

        private void dgv_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Visible)
                ColumnVisibility(e);
        }

        private void ColumnVisibility(DataGridViewColumnStateChangedEventArgs e)
        {
            foreach (var btn in flpHeader.Controls.OfType<CesColumnHeader>())
                if (btn.CesIndex == e.Column.Index)
                {
                    btn.Visible = e.Column.Visible;

                    if (!_loading && !_initializing)
                        ResetHeaderRow();

                    return;
                }
        }

        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (_loading)
                return;

            var headers = new List<CesColumnHeader>();

            foreach (CesColumnHeader header in flpHeader.Controls.OfType<CesColumnHeader>())
                headers.Add(header);

            if (headers == null || headers.Count == 0)
                return;

            var colHeader = headers.FirstOrDefault(x => x.Name.EndsWith(e.Column.Name));

            if (colHeader == null)
                return;

            if (CesLimitToColumnMinSize && e.Column.Width < colHeader.CesHeaderMinWidth)
            {
                colHeader.Width = colHeader.CesHeaderMinWidth;
                e.Column.Width = colHeader.CesHeaderMinWidth;
            }
            else
            {
                colHeader.Width = e.Column.Width < _criticalMinimumColumnWidth ? _criticalMinimumColumnWidth : e.Column.Width;
            }

            if (_columnWidth.ContainsKey(e.Column.Name))
                _columnWidth[e.Column.Name] = e.Column.Width;
            else
                _columnWidth.TryAdd(e.Column.Name, e.Column.Width);

            ResetHeaderRow();
        }

        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                ResetHeaderRow();
        }

        private void ResetHeaderRow()
        {
            if (_loading || _initializing)
                return;

            dgv.RowHeadersWidth = pnlOption.Width;

            if (RightToLeft == RightToLeft.Yes)
                flpHeader.Left = pnlHeaderRow.Width - (flpHeader.Width + pnlOption.Width) + dgv.HorizontalScrollingOffset;
            else if (RightToLeft == RightToLeft.No)
                flpHeader.Left = pnlOption.Width - dgv.HorizontalScrollingOffset;
        }

        private void dgv_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            SetOptionWidth();
            ResetHeaderRow();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionsButtonClick?.Invoke(sender, new OptionsButtonClickEvent());
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellClick?.Invoke(sender, e);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellContentClick?.Invoke(sender, e);
        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellContentDoubleClick?.Invoke(sender, e);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellDoubleClick?.Invoke(sender, e);
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellEnter?.Invoke(sender, e);
        }

        private void dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellLeave?.Invoke(sender, e);
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellMouseClick?.Invoke(sender, e);
        }

        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellMouseDoubleClick?.Invoke(sender, e);
        }

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellMouseDown?.Invoke(sender, e);
        }

        private void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellMouseEnter?.Invoke(sender, e);
        }

        private void dgv_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellMouseLeave?.Invoke(sender, e);
        }

        private void dgv_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellMouseUp?.Invoke(sender, e);
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellPainting?.Invoke(sender, e);
        }

        private void dgv_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellValidated?.Invoke(sender, e);
        }

        private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellValidating?.Invoke(sender, e);
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCellValueChanged?.Invoke(sender, e);
        }

        private void dgv_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewColumnRemoved?.Invoke(sender, e);
            ResetHeaderRow();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewKeyDown?.Invoke(sender, e);
        }

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewKeyPress?.Invoke(sender, e);
        }

        private void dgv_KeyUp(object sender, KeyEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewKeyUp?.Invoke(sender, e);
        }

        private void dgv_Paint(object sender, PaintEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewPaint?.Invoke(sender, e);
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewSelectionChanged?.Invoke(sender, e);
        }

        private void dgv_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewUserAddedRow?.Invoke(sender, e);
        }

        private void dgv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewUserDeletedRow?.Invoke(sender, e);
        }

        private void dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewUserDeletingRow?.Invoke(sender, e);
        }

        private void dgv_Validated(object sender, EventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewValidated?.Invoke(sender, e);
        }

        private void dgv_Validating(object sender, CancelEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewValidating?.Invoke(sender, e);
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewRowEnter?.Invoke(sender, e);
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (_loading || _initializing)
                return;

            GridViewCurrentCellChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// زمانی که کنترل تغییر سایز می‌دهد باید چیدمان ستون‌ها مرتب شوند
        /// کافیست میزان جابجایی اسکرول را به اندازه‌ی یک واحد تغییر دهیم
        /// تا رویداد اسکرول اجرا شود تا مرتب سازی صورت گیرد
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CesGridViewPro_Resize(object sender, EventArgs e)
        {
            if (_loading || _initializing)
                return;

            ResetHeaderRow();
        }

        #endregion Original Events
    }
}
