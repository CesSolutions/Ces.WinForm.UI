namespace Ces.WinForm.UI.CesNavigationBars
{
    public partial class CesNavigationBar : System.Windows.Forms.ToolStrip
    {
        private const int _buttonMargine = 2;
        private Control? _parentContainerOfGrid;

        public CesNavigationBar()
        {
            InitializeComponent();
            CreateStandardItems();
        }

        #region Control Instances

        System.Windows.Forms.ToolStripButton btnHelp = new();
        System.Windows.Forms.ToolStripSeparator helpSectionSeparator = new();
        System.Windows.Forms.ToolStripButton btnFirst = new();
        System.Windows.Forms.ToolStripButton btnPrevious = new();
        System.Windows.Forms.ToolStripTextBox txtNavigationInfo = new();
        System.Windows.Forms.ToolStripButton btnNext = new();
        System.Windows.Forms.ToolStripButton btnLast = new();
        System.Windows.Forms.ToolStripSeparator navigationSectionSeparator = new();
        System.Windows.Forms.ToolStripButton btnFilter = new();
        System.Windows.Forms.ToolStripButton btnSort = new();
        System.Windows.Forms.ToolStripSeparator selectionSectionSeparator = new();
        System.Windows.Forms.ToolStripButton btnNew = new();
        System.Windows.Forms.ToolStripButton btnDelete = new();
        System.Windows.Forms.ToolStripButton btnLoad = new();
        System.Windows.Forms.ToolStripSeparator operationSectionSeparator = new();
        System.Windows.Forms.ToolStripButton btnFullScreen = new();
        System.Windows.Forms.ToolStripButton btnExport = new();

        #endregion Control Instances

        #region Properties For Section Visibility

        private bool cesShowHelpSection = true;
        [System.ComponentModel.Category("CesNavigationBar")]
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
        [System.ComponentModel.Category("CesNavigationBar")]
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

        private bool cesShowSelectionSection = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowSelectionSection
        {
            get { return cesShowSelectionSection; }
            set
            {
                cesShowSelectionSection = value;
                btnFilter.Visible = value;
                btnSort.Visible = value;
                selectionSectionSeparator.Visible = value;
            }
        }

        private bool cesShowOperationSection = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowOperationSection
        {
            get { return cesShowOperationSection; }
            set
            {
                cesShowOperationSection = value;
                btnNew.Visible = value;
                btnDelete.Visible = value;
                btnLoad.Visible = value;
                operationSectionSeparator.Visible = value;
            }
        }

        private bool cesShowMiscSection = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowMiscSection
        {
            get { return cesShowMiscSection; }
            set
            {
                cesShowMiscSection = value;
                btnFullScreen.Visible = value;
                btnExport.Visible = value;
            }
        }

        #endregion Properties For Section Visibility

        #region Properties

        private Ces.WinForm.UI.CesGridView.CesGridView cesGridView;
        [System.ComponentModel.Category("CesNavigationBar")]
        public Ces.WinForm.UI.CesGridView.CesGridView CesGridView
        {
            get { return cesGridView; }
            set
            {
                cesGridView = value;

                if (cesGridView is not null)
                    cesGridView.RowEnter += new DataGridViewCellEventHandler((sender, e) =>
                    {
                        SelectRow(e.RowIndex);
                    });
            }
        }

        private NavigationBarIconMode cesIconMode = NavigationBarIconMode.Flat;
        [System.ComponentModel.Category("CesNavigationBar")]
        public NavigationBarIconMode CesIconMode
        {
            get { return cesIconMode; }
            set
            {
                cesIconMode = value;
                SetIconMode();
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
                btnDelete.ImageScaling = value;
                btnLoad.ImageScaling = value;
                btnFullScreen.ImageScaling = value;
                btnExport.ImageScaling = value;
            }
        }

        private bool cesShowFilterButton = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowFilterButton
        {
            get { return cesShowFilterButton; }
            set
            {
                cesShowFilterButton = value;
                btnFilter.Visible = value;
                SetSeparatorVisibility();
            }
        }

        private bool cesShowSortButton = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowSortButton
        {
            get { return cesShowSortButton; }
            set
            {
                cesShowSortButton = value;
                btnSort.Visible = value;
                SetSeparatorVisibility();
            }
        }

        private bool cesShowNewButton = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowNewButton
        {
            get { return cesShowNewButton; }
            set
            {
                cesShowNewButton = value;
                btnNew.Visible = value;
                SetSeparatorVisibility();
            }
        }

        private bool cesShowDeleteButton = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowDeleteButton
        {
            get { return cesShowDeleteButton; }
            set
            {
                cesShowDeleteButton = value;
                btnDelete.Visible = value;
                SetSeparatorVisibility();
            }
        }

        private bool cesShowLoadButton = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowLoadButton
        {
            get { return cesShowLoadButton; }
            set
            {
                cesShowLoadButton = value;
                btnLoad.Visible = value;
                SetSeparatorVisibility();
            }
        }

        private bool cesShowFullScreenButton = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowFullScreenButton
        {
            get { return cesShowFullScreenButton; }
            set
            {
                cesShowFullScreenButton = value;
                btnFullScreen.Visible = value;
                SetSeparatorVisibility();
            }
        }

        private bool cesShowExportButton = true;
        [System.ComponentModel.Category("CesNavigationBar")]
        public bool CesShowExportButton
        {
            get { return cesShowExportButton; }
            set
            {
                cesShowExportButton = value;
                btnExport.Visible = value;
                SetSeparatorVisibility();
            }
        }

        #endregion Properties

        #region EventHandler

        // Help EventHandler

        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesHelpButtonClicked;

        // Navigation EventHandler

        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesTextChanged;

        // Selection EventHandler

        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesFilterButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesSortButtonClicked;

        // Operation EventHandler

        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesNewButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesDeleteButtonClicked;
        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesLoadButtonClicked;

        // Misc. EventHandler

        public event EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesExportButtonClicked;

        #endregion EventHadler

        #region Create and Config Objects

        private void CreateStandardItems()
        {
            CreateHelpSection();
            CreateNavigationSection();
            CreateSelectionSection();
            CreateOperationSection();
            CreateMiscSection();

            SetSeparatorVisibility();
            SetIconMode();
        }

        private CesNavigationBars.Events.CesNavigationEvent CreateEvent()
        {
            return new CesNavigationBars.Events.CesNavigationEvent
            {
                TotalRows = 0,
                CurrentRowNumber = 0,
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
            btnHelp.ImageScaling = ToolStripItemImageScaling.None;
            btnHelp.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarHelp;
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
            btnFirst.ImageScaling = ToolStripItemImageScaling.None;
            btnFirst.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarFirst;
            btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnFirst.Visible = CesShowNavigationSection;
            btnFirst.Click += new EventHandler((sender, e) =>
            {
                var control = CesGridView;

                if (control is null)
                    return;

                if (control.Rows is null || control.Rows?.Count == 0)
                    return;

                SelectRow(0);
            });

            btnPrevious.Name = nameof(btnPrevious);
            btnPrevious.Text = "Previous";
            btnPrevious.ToolTipText = btnPrevious.Text;
            btnPrevious.Margin = new Padding(all: _buttonMargine);
            btnPrevious.ImageScaling = ToolStripItemImageScaling.None;
            btnPrevious.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarPrevious;
            btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnPrevious.Visible = CesShowNavigationSection;
            btnPrevious.Click += new EventHandler((sender, e) =>
            {
                var control = CesGridView;

                if (control is null)
                    return;

                if (control.Rows is null || control.Rows?.Count == 0)
                    return;

                var totalRows = control.Rows.Count;

                if (control.SelectedRows.Count == 0)
                {
                    SelectRow(totalRows - 1);
                    return;
                }

                var currentIndex = control.SelectedRows[0].Index;
                var newIndex = currentIndex - 1;

                if (currentIndex == 0)
                    return;

                SelectRow(newIndex);
            });

            txtNavigationInfo.Name = nameof(txtNavigationInfo);
            txtNavigationInfo.Size = new System.Drawing.Size(100, 35);
            txtNavigationInfo.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtNavigationInfo.Text = "0 of 0";
            txtNavigationInfo.ToolTipText = txtNavigationInfo.Text;
            txtNavigationInfo.Margin = new Padding(all: _buttonMargine);
            txtNavigationInfo.Visible = CesShowNavigationSection;
            txtNavigationInfo.KeyUp += new KeyEventHandler((sender, e) =>
            {
                CesTextChanged?.Invoke(sender, CreateEvent());
            });

            btnNext.Name = nameof(btnNext);
            btnNext.Text = "Next";
            btnNext.ToolTipText = btnNext.Text;
            btnNext.Margin = new Padding(all: _buttonMargine);
            btnNext.ImageScaling = ToolStripItemImageScaling.None;
            btnNext.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarNext;
            btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnNext.Visible = CesShowNavigationSection;
            btnNext.Click += new EventHandler((sender, e) =>
            {
                var control = CesGridView;

                if (control is null)
                    return;

                if (control.Rows is null || control.Rows?.Count == 0)
                    return;

                if (control.SelectedRows.Count == 0)
                {
                    SelectRow(0);
                    return;
                }

                var totalRows = control.Rows.Count;
                var currentIndex = control.SelectedRows[0].Index;
                var newIndex = currentIndex + 1;

                if (currentIndex == totalRows - 1)
                    return;

                SelectRow(newIndex);
            });

            btnLast.Name = nameof(btnLast);
            btnLast.Text = "Last";
            btnLast.ToolTipText = btnLast.Text;
            btnLast.Margin = new Padding(all: _buttonMargine);
            btnLast.ImageScaling = ToolStripItemImageScaling.None;
            btnLast.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarLast;
            btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnLast.Visible = CesShowNavigationSection;
            btnLast.Click += new EventHandler((sender, e) =>
            {
                var control = CesGridView;

                if (control is null)
                    return;

                if (control.Rows is null || control.Rows?.Count == 0)
                    return;

                var newIndex = control.Rows.Count - 1;

                SelectRow(newIndex);
            });

            navigationSectionSeparator.Name = nameof(navigationSectionSeparator);
            navigationSectionSeparator.Visible = CesShowNavigationSection;

            this.Items.Add(btnFirst);
            this.Items.Add(btnPrevious);
            this.Items.Add(txtNavigationInfo);
            this.Items.Add(btnNext);
            this.Items.Add(btnLast);
            this.Items.Add(navigationSectionSeparator);
        }

        private void CreateSelectionSection()
        {
            btnFilter.Name = nameof(btnFilter);
            btnFilter.Text = "Filter";
            btnFilter.ToolTipText = btnFilter.Text;
            btnFilter.Margin = new Padding(all: _buttonMargine);
            btnFilter.ImageScaling = ToolStripItemImageScaling.None;
            btnFilter.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarFilter;
            btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnFilter.Visible = CesShowSelectionSection ? CesShowFilterButton : CesShowSelectionSection; ;
            btnFilter.Click += new EventHandler((sender, e) =>
            {
                CesFilterButtonClicked?.Invoke(sender, CreateEvent());
            });

            btnSort.Name = nameof(btnSort);
            btnSort.Text = "Sort";
            btnSort.ToolTipText = btnSort.Text;
            btnSort.Margin = new Padding(all: _buttonMargine);
            btnSort.ImageScaling = ToolStripItemImageScaling.None;
            btnSort.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarSort;
            btnSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnSort.Visible = CesShowSelectionSection ? CesShowSortButton : CesShowSelectionSection; ;
            btnSort.Click += new EventHandler((sender, e) =>
            {
                CesSortButtonClicked?.Invoke(sender, CreateEvent());
            });

            selectionSectionSeparator.Name = nameof(selectionSectionSeparator);
            selectionSectionSeparator.Visible = CesShowSelectionSection;

            this.Items.Add(btnFilter);
            this.Items.Add(btnSort);
            this.Items.Add(selectionSectionSeparator);
        }

        private void CreateOperationSection()
        {
            btnNew.Name = nameof(btnNew);
            btnNew.Text = "New";
            btnNew.ToolTipText = btnNew.Text;
            btnNew.Margin = new Padding(all: _buttonMargine);
            btnNew.ImageScaling = ToolStripItemImageScaling.None;
            btnNew.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarNew;
            btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnNew.Visible = CesShowOperationSection ? CesShowNewButton : CesShowOperationSection;
            btnNew.Click += new EventHandler((sender, e) =>
            {
                CesNewButtonClicked?.Invoke(sender, CreateEvent());
            });

            btnDelete.Name = nameof(btnDelete);
            btnDelete.Text = "Delete";
            btnDelete.ToolTipText = btnDelete.Text;
            btnDelete.Margin = new Padding(all: _buttonMargine);
            btnDelete.ImageScaling = ToolStripItemImageScaling.None;
            btnDelete.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarDelete;
            btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnDelete.Visible = CesShowOperationSection ? CesShowDeleteButton : CesShowOperationSection;
            btnDelete.Click += new EventHandler((sender, e) =>
            {
                CesDeleteButtonClicked?.Invoke(sender, CreateEvent());
            });

            btnLoad.Name = nameof(btnLoad);
            btnLoad.Text = "Load";
            btnLoad.ToolTipText = btnLoad.Text;
            btnLoad.Margin = new Padding(all: _buttonMargine);
            btnLoad.ImageScaling = ToolStripItemImageScaling.None;
            btnLoad.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarLoad;
            btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnLoad.Visible = CesShowOperationSection ? CesShowLoadButton : CesShowOperationSection;
            btnLoad.Click += new EventHandler((sender, e) =>
            {
                CesLoadButtonClicked?.Invoke(sender, CreateEvent());
            });

            operationSectionSeparator.Name = nameof(operationSectionSeparator);
            operationSectionSeparator.Visible = CesShowOperationSection;

            this.Items.Add(btnNew);
            this.Items.Add(btnDelete);
            this.Items.Add(btnLoad);
            this.Items.Add(operationSectionSeparator);
        }

        private void CreateMiscSection()
        {
            btnFullScreen.Name = nameof(btnFullScreen);
            btnFullScreen.Text = "FullScreen";
            btnFullScreen.ToolTipText = btnFullScreen.Text;
            btnFullScreen.Margin = new Padding(all: _buttonMargine);
            btnFullScreen.ImageScaling = ToolStripItemImageScaling.None;
            btnFullScreen.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarFullScreen;
            btnFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnFullScreen.Visible = CesShowMiscSection ? CesShowFullScreenButton : CesShowMiscSection;
            btnFullScreen.Click += new EventHandler((sender, e) =>
            {
                if(CesGridView is null || CesGridView.Parent is null)
                {
                    MessageBox.Show("Control is not defined!");
                    return;
                }

                var frm = new CesNavigationBars.frmFullScreen();
                frm.Parent = CesGridView.Parent;
                frm.GridView = CesGridView;
                frm.Controls.Add(CesGridView);
                CesGridView.Dock = DockStyle.Fill;
                frm.ShowDialog(this);
            });

            btnExport.Name = nameof(btnExport);
            btnExport.Text = "Export";
            btnExport.ToolTipText = btnExport.Text;
            btnExport.Margin = new Padding(all: _buttonMargine);
            btnExport.ImageScaling = ToolStripItemImageScaling.None;
            btnExport.Image = Ces.WinForm.UI.Properties.Resources.NavigationBarExport;
            btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnExport.Visible = CesShowMiscSection ? CesShowFullScreenButton : CesShowMiscSection;
            btnExport.Click += new EventHandler((sender, e) =>
            {
                CesExportButtonClicked?.Invoke(sender, CreateEvent());
            });

            this.Items.Add(btnFullScreen);
            this.Items.Add(btnExport);
        }

        private void SelectRow(int rowIndex)
        {
            CesGridView.ClearSelection();
            CesGridView.Rows[rowIndex].Selected = true;
            UpdateNavigationInfo(rowIndex);
        }

        private void UpdateNavigationInfo(int rowIndex)
        {
            var control = CesGridView;

            if (control is null)
                return;

            if (control.Rows is null || control.Rows?.Count == 0)
                return;

            var totalRows = control.Rows.Count.ToString();
            txtNavigationInfo.Text = $"{rowIndex + 1} of {totalRows}";
        }

        /// <summary>
        /// با توجه به وضعیت قابل رویت بودن سایر آیتم ها در 
        /// یک بخش می بایست خط جدا کننده را نمایان و یا حذف کرد
        /// </summary>
        private void SetSeparatorVisibility()
        {
            //selectionSectionSeparator.Visible =
            //     (!btnFilter.Visible
            //     & !btnSort.Visible) ? false : true;

            //operationSectionSeparator.Visible =
            //     (!btnNew.Visible
            //     & !btnDelete.Visible
            //     & !btnLoad.Visible) ? false : true;
        }

        private void SetIconMode()
        {
            if (cesIconMode == NavigationBarIconMode.Flat)
            {
                btnHelp.Image = Properties.Resources.NavigationBarHelp_Flat;
                btnFirst.Image = Properties.Resources.NavigationBarFirst_FlatFilled;
                btnPrevious.Image = Properties.Resources.NavigationBarPrevious_FlatFilled;
                btnNext.Image = Properties.Resources.NavigationBarNext_FlatFilled;
                btnLast.Image = Properties.Resources.NavigationBarLast_FlatFilled;
                btnFilter.Image = Properties.Resources.NavigationBarFilter_Flat;
                btnSort.Image = Properties.Resources.NavigationBarSort_Flat;
                btnNew.Image = Properties.Resources.NavigationBarNew_Flat;
                btnDelete.Image = Properties.Resources.NavigationBarDelete_Flat;
                btnLoad.Image = Properties.Resources.NavigationBarLoad_Flat;
                btnFullScreen.Image = Properties.Resources.NavigationBarFullScreen_Flat;
                btnExport.Image = Properties.Resources.NavigationBarExport_Flat;
            }

            if (cesIconMode == NavigationBarIconMode.FlatFilled)
            {
                btnHelp.Image = Properties.Resources.NavigationBarHelp_FlatFilled;
                btnFirst.Image = Properties.Resources.NavigationBarFirst_FlatFilled;
                btnPrevious.Image = Properties.Resources.NavigationBarPrevious_FlatFilled;
                btnNext.Image = Properties.Resources.NavigationBarNext_FlatFilled;
                btnLast.Image = Properties.Resources.NavigationBarLast_FlatFilled;
                btnFilter.Image = Properties.Resources.NavigationBarFilter_FlatFilled;
                btnSort.Image = Properties.Resources.NavigationBarSort_FlatFilled;
                btnNew.Image = Properties.Resources.NavigationBarNew_FlatFilled;
                btnDelete.Image = Properties.Resources.NavigationBarDelete_FlatFilled;
                btnLoad.Image = Properties.Resources.NavigationBarLoad_FlatFilled;
                btnFullScreen.Image = Properties.Resources.NavigationBarFullScreen_FlatFilled;
                btnExport.Image = Properties.Resources.NavigationBarExport_FlatFilled;
            }

            if (cesIconMode == NavigationBarIconMode.Color)
            {
                btnHelp.Image = Properties.Resources.NavigationBarHelp;
                btnFirst.Image = Properties.Resources.NavigationBarFirst;
                btnPrevious.Image = Properties.Resources.NavigationBarPrevious;
                btnNext.Image = Properties.Resources.NavigationBarNext;
                btnLast.Image = Properties.Resources.NavigationBarLast;
                btnFilter.Image = Properties.Resources.NavigationBarFilter;
                btnSort.Image = Properties.Resources.NavigationBarSort;
                btnNew.Image = Properties.Resources.NavigationBarNew;
                btnDelete.Image = Properties.Resources.NavigationBarDelete;
                btnLoad.Image = Properties.Resources.NavigationBarLoad;
                btnFullScreen.Image = Properties.Resources.NavigationBarFullScreen;
                btnExport.Image = Properties.Resources.NavigationBarExport;
            }
        }

        #endregion Create and Config Objects
    }

    public enum NavigationBarIconMode
    {
        Flat,
        FlatFilled,
        Color
    }
}
