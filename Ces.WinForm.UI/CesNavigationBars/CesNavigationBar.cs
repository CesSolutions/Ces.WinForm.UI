using Ces.WinForm.UI.CesGridView;
using System.Runtime.ConstrainedExecution;

namespace Ces.WinForm.UI.CesNavigationBars
{
    public partial class CesNavigationBar : System.Windows.Forms.ToolStrip
    {
        private const int _buttonMargine = 2;

        public CesNavigationBar()
        {
            InitializeComponent();
            this.Dock = DockStyle.Bottom;
            this.GripStyle = ToolStripGripStyle.Hidden;
            CreateStandardItems();
        }

        /// <summary>
        /// بعد از تعیین کننرل توسط کاربر، گرید باید در متغیر جاری قرار گیرد
        /// تا در کدهای برنامه دائما نیاز به تبدیل به انواع گرید وجود نداشته باشد
        /// </summary>
        private System.Windows.Forms.DataGridView? _gridView;

        #region Create Button Instances

        private System.Windows.Forms.ToolStripButton btnHelp = new();
        private System.Windows.Forms.ToolStripSeparator helpSectionSeparator = new();
        private System.Windows.Forms.ToolStripButton btnFirst = new();
        private System.Windows.Forms.ToolStripButton btnPrevious = new();
        private System.Windows.Forms.ToolStripTextBox txtNavigationInfo = new();
        private System.Windows.Forms.ToolStripButton btnNext = new();
        private System.Windows.Forms.ToolStripButton btnLast = new();
        private System.Windows.Forms.ToolStripSeparator navigationSectionSeparator = new();
        private System.Windows.Forms.ToolStripButton btnFilter = new();
        private System.Windows.Forms.ToolStripButton btnSort = new();
        private System.Windows.Forms.ToolStripSeparator dataSectionSeparator = new();
        private System.Windows.Forms.ToolStripButton btnNew = new();
        private System.Windows.Forms.ToolStripButton btnEdit = new();
        private System.Windows.Forms.ToolStripButton btnDelete = new();
        private System.Windows.Forms.ToolStripButton btnLoad = new();
        private System.Windows.Forms.ToolStripSeparator operationSectionSeparator = new();
        private System.Windows.Forms.ToolStripButton btnFullScreen = new();
        private System.Windows.Forms.ToolStripButton btnExport = new();

        #endregion Control Button Instances

        #region Section Properties

        private bool cesShowHelpSection = false;
        [System.ComponentModel.Category("CesNavigationBar Section Options")]
        public bool CesShowHelpSection
        {
            get { return cesShowHelpSection; }
            set
            {
                cesShowHelpSection = value;
                btnHelp.Visible = value;
                helpSectionSeparator.Visible = value;
            }
        }

        private bool cesShowNavigationSection = true;
        [System.ComponentModel.Category("CesNavigationBar Section Options")]
        public bool CesShowNavigationSection
        {
            get { return cesShowNavigationSection; }
            set
            {
                cesShowNavigationSection = value;
                btnFirst.Visible = value;
                btnPrevious.Visible = value;
                txtNavigationInfo.Visible = value;
                btnNext.Visible = value;
                btnLast.Visible = value;
                navigationSectionSeparator.Visible = value;
            }
        }

        private bool cesShowDataSection = false;
        [System.ComponentModel.Category("CesNavigationBar Section Options")]
        public bool CesShowDataSection
        {
            get { return cesShowDataSection; }
            set
            {
                cesShowDataSection = value;
                btnFilter.Visible = value ? CesShowFilterButton : false;
                btnSort.Visible = value ? CesShowSortButton : false;
                dataSectionSeparator.Visible = value ? CesShowDataSeparator : false;
            }
        }

        private bool cesShowOperationSection = true;
        [System.ComponentModel.Category("CesNavigationBar Section Options")]
        public bool CesShowOperationSection
        {
            get { return cesShowOperationSection; }
            set
            {
                cesShowOperationSection = value;
                btnNew.Visible = value ? CesShowNewButton : false;
                btnEdit.Visible = value ? CesShowEditButton : false;
                btnDelete.Visible = value ? CesShowDeleteButton : false;
                btnLoad.Visible = value ? CesShowLoadButton : false;
                operationSectionSeparator.Visible = value ? CesShowOperationSeparator : false;
            }
        }

        private bool cesShowMiscSection = true;
        [System.ComponentModel.Category("CesNavigationBar Section Options")]
        public bool CesShowMiscSection
        {
            get { return cesShowMiscSection; }
            set
            {
                cesShowMiscSection = value;
                btnFullScreen.Visible = value ? CesShowFullScreenButton : false;
                btnExport.Visible = value ? CesShowExportButton : false;
            }
        }

        #endregion Properties For Section Visibility

        #region Separator Properties

        private bool cesShowDataSeparator = true;
        [System.ComponentModel.Category("CesNavigationBar Separator Options")]
        public bool CesShowDataSeparator
        {
            get { return cesShowDataSeparator; }
            set
            {
                cesShowDataSeparator = value;
                dataSectionSeparator.Visible = CesShowDataSection ? value : false;
            }
        }

        private bool cesShowOperationSeparator = true;
        [System.ComponentModel.Category("CesNavigationBar Separator Options")]
        public bool CesShowOperationSeparator
        {
            get { return cesShowOperationSeparator; }
            set
            {
                cesShowOperationSeparator = value;
                operationSectionSeparator.Visible = CesShowOperationSection ? value : false;
            }
        }

        #endregion Separator Properties

        #region Properties

        private Control cesGridView;
        [System.ComponentModel.Category("CesNavigationBar")]
        public Control CesGridView
        {
            get { return cesGridView; }
            set
            {
                cesGridView = value;

                if (cesGridView is not null)
                {
                    if (value.GetType() == typeof(CesGridView.CesGridView))
                        _gridView = value as CesGridView.CesGridView;

                    else if (value.GetType() == typeof(CesGridView.CesGridViewPro))
                        _gridView = (value as CesGridView.CesGridViewPro).dgv;

                    else
                        throw new Exception("Invalid Control");

                    //اگر گرید انتخاب شود باید برای رویداد تغییر ردیف یک متد تعریف کنیم
                    _gridView.RowEnter += new DataGridViewCellEventHandler((sender, e) =>
                    {
                        SelectRow(e.RowIndex);
                    });

                    //هر بار که منبع داده گرید تغییر کرد باید اطلاعات نمایش داده شده بروزرسانی شود
                    _gridView.DataSourceChanged += new EventHandler((sender, e) =>
                    {
                        UpdateNavigationInfo();
                    });
                }
                else
                    _gridView = null;
            }
        }

        private NavigationBarIconMode cesIconMode = NavigationBarIconMode.Colorful;
        [System.ComponentModel.Category("CesNavigationBar")]
        public NavigationBarIconMode CesIconMode
        {
            get { return cesIconMode; }
            set
            {
                cesIconMode = value;
                SetIcon();
            }
        }

        private System.Windows.Forms.ToolStripItemImageScaling cesImageScaling
          = ToolStripItemImageScaling.None;
        [System.ComponentModel.Category("CesNavigationBar")]
        public System.Windows.Forms.ToolStripItemImageScaling CesImageScaling
        {
            get { return cesImageScaling; }
            set
            {
                cesImageScaling = value;

                btnHelp.ImageScaling = value;
                btnFirst.ImageScaling = value;
                btnPrevious.ImageScaling = value;
                btnNext.ImageScaling = value;
                btnLast.ImageScaling = value;
                btnFilter.ImageScaling = value;
                btnSort.ImageScaling = value;
                btnNew.ImageScaling = value;
                btnEdit.ImageScaling = value;
                btnDelete.ImageScaling = value;
                btnLoad.ImageScaling = value;
                btnFullScreen.ImageScaling = value;
                btnExport.ImageScaling = value;

                SetIcon();
            }
        }

        #endregion Properties

        #region Button Properties

        private bool cesShowFilterButton = true;
        [System.ComponentModel.Category("CesNavigationBar Button Options")]
        public bool CesShowFilterButton
        {
            get { return cesShowFilterButton; }
            set
            {
                cesShowFilterButton = value;
                btnFilter.Visible = CesShowDataSection ? value : false;
            }
        }

        private bool cesShowSortButton = true;
        [System.ComponentModel.Category("CesNavigationBar Button Options")]
        public bool CesShowSortButton
        {
            get { return cesShowSortButton; }
            set
            {
                cesShowSortButton = value;
                btnSort.Visible = CesShowDataSection ? value : false;
            }
        }

        private bool cesShowNewButton = true;
        [System.ComponentModel.Category("CesNavigationBar Button Options")]
        public bool CesShowNewButton
        {
            get { return cesShowNewButton; }
            set
            {
                cesShowNewButton = value;
                btnNew.Visible = CesShowOperationSection ? value : false;
            }
        }

        private bool cesShowEditButton = true;
        [System.ComponentModel.Category("CesNavigationBar Button Options")]
        public bool CesShowEditButton
        {
            get { return cesShowEditButton; }
            set
            {
                cesShowEditButton = value;
                btnEdit.Visible = CesShowOperationSection ? value : false;
            }
        }

        private bool cesShowDeleteButton = true;
        [System.ComponentModel.Category("CesNavigationBar Button Options")]
        public bool CesShowDeleteButton
        {
            get { return cesShowDeleteButton; }
            set
            {
                cesShowDeleteButton = value;
                btnDelete.Visible = CesShowOperationSection ? value : false;
            }
        }

        private bool cesShowLoadButton = true;
        [System.ComponentModel.Category("CesNavigationBar Button Options")]
        public bool CesShowLoadButton
        {
            get { return cesShowLoadButton; }
            set
            {
                cesShowLoadButton = value;
                btnLoad.Visible = CesShowOperationSection ? value : false;
            }
        }

        private bool cesShowFullScreenButton = true;
        [System.ComponentModel.Category("CesNavigationBar Button Options")]
        public bool CesShowFullScreenButton
        {
            get { return cesShowFullScreenButton; }
            set
            {
                cesShowFullScreenButton = value;
                btnFullScreen.Visible = CesShowMiscSection ? value : false;
            }
        }

        private bool cesShowExportButton = true;
        [System.ComponentModel.Category("CesNavigationBar Button Options")]
        public bool CesShowExportButton
        {
            get { return cesShowExportButton; }
            set
            {
                cesShowExportButton = value;
                btnExport.Visible = CesShowMiscSection ? value : false;
            }
        }

        #endregion Button Properties

        #region EventHandler

        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesHelpButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesFilterButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesSortButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesNewButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesEditButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesDeleteButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesLoadButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesExportButtonClicked;

        #endregion EventHadler

        #region Create & Config Objects

        private void CreateStandardItems()
        {
            CreateHelpSection();
            CreateNavigationSection();
            CreateDataSection();
            CreateOperationSection();
            CreateMiscSection();

            SetIcon();
        }

        private CesNavigationBars.Events.CesNavigationEvent CreateEvent()
        {
            return new CesNavigationBars.Events.CesNavigationEvent
            {
                CountRows = 0,
                RowIndex = 0,
                IsFirst = false,
                IsLast = true
            };
        }

        private void CreateHelpSection()
        {
            btnHelp.Name = nameof(btnHelp);
            btnHelp.Text = "Help";
            btnHelp.ToolTipText = btnHelp.Text;
            btnHelp.Margin = new Padding(all: _buttonMargine);
            btnHelp.ImageScaling = CesImageScaling;
            btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnHelp.Visible = CesShowHelpSection;
            btnHelp.Click += new EventHandler((sender, e) =>
            {
                CesHelpButtonClicked?.Invoke(sender, CreateEvent());
            });

            helpSectionSeparator.Name = nameof(helpSectionSeparator);
            helpSectionSeparator.Visible = CesShowHelpSection;

            this.Items.Add(btnHelp);
            this.Items.Add(helpSectionSeparator);
        }

        private void CreateNavigationSection()
        {
            btnFirst.Name = nameof(btnFirst);
            btnFirst.Text = "First";
            btnFirst.ToolTipText = btnFirst.Text;
            btnFirst.Margin = new Padding(all: _buttonMargine);
            btnFirst.ImageScaling = CesImageScaling;
            btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnFirst.Click += new EventHandler((sender, e) =>
            {
                if (_gridView is null)
                    return;

                if (_gridView.Rows is null || _gridView.Rows?.Count == 0)
                    return;

                SelectRow(0, true);
            });

            btnPrevious.Name = nameof(btnPrevious);
            btnPrevious.Text = "Previous";
            btnPrevious.ToolTipText = btnPrevious.Text;
            btnPrevious.Margin = new Padding(all: _buttonMargine);
            btnPrevious.ImageScaling = CesImageScaling;
            btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnPrevious.Click += new EventHandler((sender, e) =>
            {
                if (_gridView is null)
                    return;

                if (_gridView.Rows is null || _gridView.Rows?.Count == 0)
                    return;

                var totalRows = _gridView.Rows.Count;

                if (_gridView.SelectedRows.Count == 0)
                {
                    SelectRow(totalRows - 1, true);
                    return;
                }

                var currentIndex = _gridView.SelectedRows[0].Index;
                var newIndex = currentIndex - 1;

                if (currentIndex == 0)
                    return;

                SelectRow(newIndex, true);
            });

            txtNavigationInfo.Name = nameof(txtNavigationInfo);
            txtNavigationInfo.Size = new System.Drawing.Size(100, 35);
            txtNavigationInfo.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtNavigationInfo.Text = "0 of 0";
            txtNavigationInfo.ToolTipText = txtNavigationInfo.Text;
            txtNavigationInfo.Margin = new Padding(all: _buttonMargine);
            txtNavigationInfo.KeyUp += new KeyEventHandler((sender, e) =>
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                var value = txtNavigationInfo.Text;

                if (string.IsNullOrWhiteSpace(value))
                    return;

                // بررسی میکنیم که آیا مقدار موجود در تست باکس بصورت زیر است یا خیر
                // 5 of 20
                // اگر کاربر عدد را مستقیم وارد کرد باید بررسی کنیم که آیا مقدار وارد
                // شده از نوع عدد است یا خیر
                if (!value.Contains("of"))
                {
                    if (!int.TryParse(value, out _))
                    {
                        MessageBox.Show("Invalid input data");
                        txtNavigationInfo.Focus();
                        return;
                    }

                    // اگر عدد بود باید متد صدا زده شود
                    GoTo(int.Parse(value));
                    return;
                }

                // اما اگر مقدار وارد شده با فرمت زیر باشد باید بصورت زیر اقدام شود
                // 2 of 5
                var valueSections = value.Split("of");

                if (valueSections.Length != 2)
                {
                    MessageBox.Show("Invalid input data");
                    txtNavigationInfo.Focus();
                    return;
                }

                if (!int.TryParse(valueSections.First(), out _))
                {
                    MessageBox.Show("Invalid input data");
                    txtNavigationInfo.Focus();
                    return;
                }

                // اگر بخش اول عدد بود باید متد صدا زده شود
                GoTo(int.Parse(valueSections.First()));
            });

            btnNext.Name = nameof(btnNext);
            btnNext.Text = "Next";
            btnNext.ToolTipText = btnNext.Text;
            btnNext.Margin = new Padding(all: _buttonMargine);
            btnNext.ImageScaling = CesImageScaling;
            btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnNext.Click += new EventHandler((sender, e) =>
            {
                if (_gridView is null)
                    return;

                if (_gridView.Rows is null || _gridView.Rows?.Count == 0)
                    return;

                if (_gridView.SelectedRows.Count == 0)
                {
                    SelectRow(0, true);
                    return;
                }

                var totalRows = _gridView.Rows.Count;
                var currentIndex = _gridView.SelectedRows[0].Index;
                var newIndex = currentIndex + 1;

                if (currentIndex == totalRows - 1)
                    return;

                SelectRow(newIndex, true);
            });

            btnLast.Name = nameof(btnLast);
            btnLast.Text = "Last";
            btnLast.ToolTipText = btnLast.Text;
            btnLast.Margin = new Padding(all: _buttonMargine);
            btnLast.ImageScaling = CesImageScaling;
            btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnLast.Click += new EventHandler((sender, e) =>
            {
                if (_gridView is null)
                    return;

                if (_gridView.Rows is null || _gridView.Rows?.Count == 0)
                    return;

                var newIndex = _gridView.Rows.Count - 1;

                SelectRow(newIndex, true);
            });

            navigationSectionSeparator.Name = nameof(navigationSectionSeparator);

            this.Items.Add(btnFirst);
            this.Items.Add(btnPrevious);
            this.Items.Add(txtNavigationInfo);
            this.Items.Add(btnNext);
            this.Items.Add(btnLast);
            this.Items.Add(navigationSectionSeparator);
        }

        private void CreateDataSection()
        {
            btnFilter.Name = nameof(btnFilter);
            btnFilter.Text = "Filter";
            btnFilter.ToolTipText = btnFilter.Text;
            btnFilter.Margin = new Padding(all: _buttonMargine);
            btnFilter.ImageScaling = CesImageScaling;
            btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnFilter.Visible = CesShowDataSection ? CesShowFilterButton : false;
            btnFilter.Click += new EventHandler((sender, e) =>
            {
                CesFilterButtonClicked?.Invoke(sender, CreateEvent());
            });

            btnSort.Name = nameof(btnSort);
            btnSort.Text = "Sort";
            btnSort.ToolTipText = btnSort.Text;
            btnSort.Margin = new Padding(all: _buttonMargine);
            btnSort.ImageScaling = CesImageScaling;
            btnSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnSort.Visible = CesShowDataSection ? CesShowSortButton : false;
            btnSort.Click += new EventHandler((sender, e) =>
            {
                CesSortButtonClicked?.Invoke(sender, CreateEvent());
            });

            dataSectionSeparator.Name = nameof(dataSectionSeparator);
            dataSectionSeparator.Visible = CesShowDataSection ? CesShowDataSeparator : false;

            this.Items.Add(btnFilter);
            this.Items.Add(btnSort);
            this.Items.Add(dataSectionSeparator);
        }

        private void CreateOperationSection()
        {
            btnLoad.Name = nameof(btnLoad);
            btnLoad.Text = "Load";
            btnLoad.ToolTipText = btnLoad.Text;
            btnLoad.Margin = new Padding(all: _buttonMargine);
            btnLoad.ImageScaling = CesImageScaling;
            btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnLoad.Visible = CesShowOperationSection ? CesShowLoadButton : false;
            btnLoad.Click += new EventHandler((sender, e) =>
            {
                CesLoadButtonClicked?.Invoke(sender, CreateEvent());
            });

            btnNew.Name = nameof(btnNew);
            btnNew.Text = "New";
            btnNew.ToolTipText = btnNew.Text;
            btnNew.Margin = new Padding(all: _buttonMargine);
            btnNew.ImageScaling = CesImageScaling;
            btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnNew.Visible = CesShowOperationSection ? CesShowNewButton : false;
            btnNew.Click += new EventHandler((sender, e) =>
            {
                CesNewButtonClicked?.Invoke(sender, CreateEvent());
            });

            btnEdit.Name = nameof(btnEdit);
            btnEdit.Text = "Edit";
            btnEdit.ToolTipText = btnEdit.Text;
            btnEdit.Margin = new Padding(all: _buttonMargine);
            btnEdit.ImageScaling = CesImageScaling;
            btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnEdit.Visible = CesShowOperationSection ? CesShowEditButton : false;
            btnEdit.Click += new EventHandler((sender, e) =>
            {
                CesEditButtonClicked?.Invoke(sender, CreateEvent());
            });

            btnDelete.Name = nameof(btnDelete);
            btnDelete.Text = "Delete";
            btnDelete.ToolTipText = btnDelete.Text;
            btnDelete.Margin = new Padding(all: _buttonMargine);
            btnDelete.ImageScaling = CesImageScaling;
            btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnDelete.Visible = CesShowOperationSection ? CesShowDeleteButton : false;
            btnDelete.Click += new EventHandler((sender, e) =>
            {
                CesDeleteButtonClicked?.Invoke(sender, CreateEvent());
            });

            operationSectionSeparator.Name = nameof(operationSectionSeparator);
            operationSectionSeparator.Visible = CesShowOperationSection ? CesShowOperationSection : false;

            this.Items.Add(btnLoad);
            this.Items.Add(btnNew);
            this.Items.Add(btnEdit);
            this.Items.Add(btnDelete);
            this.Items.Add(operationSectionSeparator);
        }

        private void CreateMiscSection()
        {
            btnFullScreen.Name = nameof(btnFullScreen);
            btnFullScreen.Text = "FullScreen";
            btnFullScreen.ToolTipText = btnFullScreen.Text;
            btnFullScreen.Margin = new Padding(all: _buttonMargine);
            btnFullScreen.ImageScaling = CesImageScaling;
            btnFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnFullScreen.Visible = CesShowMiscSection ? CesShowFullScreenButton : false;
            btnFullScreen.Click += new EventHandler((sender, e) =>
            {
                if (_gridView is null || _gridView.Parent is null)
                {
                    MessageBox.Show("Control is not defined!");
                    return;
                }

                var frm = new CesNavigationBars.frmFullScreen();
                frm.Parent = _gridView.Parent;
                frm.GridView = _gridView;
                frm.Controls.Add(_gridView);
                _gridView.Dock = DockStyle.Fill;
                frm.ShowDialog(this);
            });

            btnExport.Name = nameof(btnExport);
            btnExport.Text = "Export";
            btnExport.ToolTipText = btnExport.Text;
            btnExport.Margin = new Padding(all: _buttonMargine);
            btnExport.ImageScaling = CesImageScaling;
            btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnExport.Visible = CesShowMiscSection ? CesShowExportButton : false;
            btnExport.Click += new EventHandler((sender, e) =>
            {
                CesExportButtonClicked?.Invoke(sender, CreateEvent());
            });

            this.Items.Add(btnFullScreen);
            this.Items.Add(btnExport);
        }

        private void SelectRow(int rowIndex, bool selectByNavigationBar = false)
        {
            //هر زمان جابجایی بین ردیف ها از طریق
            //Navigationbar
            //انجام شود باید انتخاب قبلی حذف و ردیف جدید انتخاب شود
            //ولی زمانی که کاربر با ماوس ردیف ها را انتخاب کند نیازی
            //به این کار نیست چون ممکن است کاربر چندین ردیف را بخواهد
            //انتخاب کند
            if (selectByNavigationBar)
                _gridView.ClearSelection();

            _gridView.Rows[rowIndex].Selected = true;
            UpdateNavigationInfo(rowIndex);
        }

        private void UpdateNavigationInfo(int rowIndex = 0)
        {
            if (_gridView is null)
                return;

            if (_gridView.Rows is null || _gridView.Rows?.Count == 0)
                return;

            var totalRows = _gridView.Rows.Count.ToString();
            txtNavigationInfo.Text = $"{(_gridView.CurrentRow != null ? rowIndex + 1 : 0)} of {totalRows}";
        }

        private void SetIcon()
        {
            if (CesImageScaling == ToolStripItemImageScaling.None)
            {
                if (cesIconMode == NavigationBarIconMode.Simple)
                {
                    btnHelp.Image = Properties.Resources.NavigationBarHelp_Simple24;
                    btnFirst.Image = Properties.Resources.NavigationBarFirst24;
                    btnPrevious.Image = Properties.Resources.NavigationBarPrevious24;
                    btnNext.Image = Properties.Resources.NavigationBarNext24;
                    btnLast.Image = Properties.Resources.NavigationBarLast24;
                    btnFilter.Image = Properties.Resources.NavigationBarFilter_Simple24;
                    btnSort.Image = Properties.Resources.NavigationBarSort_Simple24;
                    btnLoad.Image = Properties.Resources.NavigationBarLoad_Simple24;
                    btnNew.Image = Properties.Resources.NavigationBarNew_Simple24;
                    btnEdit.Image = Properties.Resources.NavigationBarEdit_Simple24;
                    btnDelete.Image = Properties.Resources.NavigationBarDelete_Simple24;
                    btnFullScreen.Image = Properties.Resources.NavigationBarFullScreen_Simple24;
                    btnExport.Image = Properties.Resources.NavigationBarExport_Simple24;
                }

                if (cesIconMode == NavigationBarIconMode.Filled)
                {
                    btnHelp.Image = Properties.Resources.NavigationBarHelp_Filled24;
                    btnFirst.Image = Properties.Resources.NavigationBarFirst24;
                    btnPrevious.Image = Properties.Resources.NavigationBarPrevious24;
                    btnNext.Image = Properties.Resources.NavigationBarNext24;
                    btnLast.Image = Properties.Resources.NavigationBarLast24;
                    btnFilter.Image = Properties.Resources.NavigationBarFilter_Filled24;
                    btnSort.Image = Properties.Resources.NavigationBarSort_Filled24;
                    btnLoad.Image = Properties.Resources.NavigationBarLoad_Filled24;
                    btnNew.Image = Properties.Resources.NavigationBarNew_Filled24;
                    btnEdit.Image = Properties.Resources.NavigationBarEdit_Filled24;
                    btnDelete.Image = Properties.Resources.NavigationBarDelete_Filled24;
                    btnFullScreen.Image = Properties.Resources.NavigationBarFullScreen_Filled24;
                    btnExport.Image = Properties.Resources.NavigationBarExport_Filled24;
                }

                if (cesIconMode == NavigationBarIconMode.Colorful)
                {
                    btnHelp.Image = Properties.Resources.NavigationBarHelp_Color24;
                    btnFirst.Image = Properties.Resources.NavigationBarFirst24;
                    btnPrevious.Image = Properties.Resources.NavigationBarPrevious24;
                    btnNext.Image = Properties.Resources.NavigationBarNext24;
                    btnLast.Image = Properties.Resources.NavigationBarLast24;
                    btnFilter.Image = Properties.Resources.NavigationBarFilter_Color24;
                    btnSort.Image = Properties.Resources.NavigationBarSort_Color24;
                    btnLoad.Image = Properties.Resources.NavigationBarLoad_Color24;
                    btnNew.Image = Properties.Resources.NavigationBarNew_Color24;
                    btnEdit.Image = Properties.Resources.NavigationBarEdit_Color24;
                    btnDelete.Image = Properties.Resources.NavigationBarDelete_Color24;
                    btnFullScreen.Image = Properties.Resources.NavigationBarFullScreen_Color24;
                    btnExport.Image = Properties.Resources.NavigationBarExport_Color24;
                }
            }

            if (CesImageScaling == ToolStripItemImageScaling.SizeToFit)
            {
                if (cesIconMode == NavigationBarIconMode.Simple)
                {
                    btnHelp.Image = Properties.Resources.NavigationBarHelp_Simple16;
                    btnFirst.Image = Properties.Resources.NavigationBarFirst16;
                    btnPrevious.Image = Properties.Resources.NavigationBarPrevious16;
                    btnNext.Image = Properties.Resources.NavigationBarNext16;
                    btnLast.Image = Properties.Resources.NavigationBarLast16;
                    btnFilter.Image = Properties.Resources.NavigationBarFilter_Simple16;
                    btnSort.Image = Properties.Resources.NavigationBarSort_Simple16;
                    btnLoad.Image = Properties.Resources.NavigationBarLoad_Simple16;
                    btnNew.Image = Properties.Resources.NavigationBarNew_Simple16;
                    btnEdit.Image = Properties.Resources.NavigationBarEdit_Simple16;
                    btnDelete.Image = Properties.Resources.NavigationBarDelete_Simple16;
                    btnFullScreen.Image = Properties.Resources.NavigationBarFullScreen_Simple16;
                    btnExport.Image = Properties.Resources.NavigationBarExport_Simple16;
                }

                if (cesIconMode == NavigationBarIconMode.Filled)
                {
                    btnHelp.Image = Properties.Resources.NavigationBarHelp_Filled16;
                    btnFirst.Image = Properties.Resources.NavigationBarFirst16;
                    btnPrevious.Image = Properties.Resources.NavigationBarPrevious16;
                    btnNext.Image = Properties.Resources.NavigationBarNext16;
                    btnLast.Image = Properties.Resources.NavigationBarLast16;
                    btnFilter.Image = Properties.Resources.NavigationBarFilter_Filled16;
                    btnSort.Image = Properties.Resources.NavigationBarSort_Filled16;
                    btnLoad.Image = Properties.Resources.NavigationBarLoad_Filled16;
                    btnNew.Image = Properties.Resources.NavigationBarNew_Filled16;
                    btnEdit.Image = Properties.Resources.NavigationBarEdit_Filled16;
                    btnDelete.Image = Properties.Resources.NavigationBarDelete_Filled16;
                    btnFullScreen.Image = Properties.Resources.NavigationBarFullScreen_Filled16;
                    btnExport.Image = Properties.Resources.NavigationBarExport_Filled16;
                }

                if (cesIconMode == NavigationBarIconMode.Colorful)
                {
                    btnHelp.Image = Properties.Resources.NavigationBarHelp_Color16;
                    btnFirst.Image = Properties.Resources.NavigationBarFirst16;
                    btnPrevious.Image = Properties.Resources.NavigationBarPrevious16;
                    btnNext.Image = Properties.Resources.NavigationBarNext16;
                    btnLast.Image = Properties.Resources.NavigationBarLast16;
                    btnFilter.Image = Properties.Resources.NavigationBarFilter_Color16;
                    btnSort.Image = Properties.Resources.NavigationBarSort_Color16;
                    btnLoad.Image = Properties.Resources.NavigationBarLoad_Color16;
                    btnNew.Image = Properties.Resources.NavigationBarNew_Color16;
                    btnEdit.Image = Properties.Resources.NavigationBarEdit_Color16;
                    btnDelete.Image = Properties.Resources.NavigationBarDelete_Color16;
                    btnFullScreen.Image = Properties.Resources.NavigationBarFullScreen_Color16;
                    btnExport.Image = Properties.Resources.NavigationBarExport_Color16;
                }
            }
        }

        public void GoTo(int rowNumber)
        {
            if (_gridView is null)
                return;

            var maxRowNumber = _gridView.Rows.Count;

            if (maxRowNumber == 0)
                return;

            if (rowNumber > maxRowNumber)
                SelectRow(maxRowNumber - 1, true);
            else
                SelectRow(rowNumber - 1, true);
        }

        #endregion Create & Config Objects
    }

    public enum NavigationBarIconMode
    {
        Simple,
        Filled,
        Colorful
    }
}
