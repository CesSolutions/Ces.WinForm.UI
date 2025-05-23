using Ces.WinForm.UI.CesGridView.Events;
using System.ComponentModel;
using System.Drawing.Design;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridViewPro : UserControl
    {
        public CesGridViewPro()
        {
            InitializeComponent();
        }

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

        public event EventHandler<OptionsButtonClickEvent> OptionsButtonClick;
        private int _initialMouseX;
        private int _initialWidth;

        #region Properties

        /// <summary>
        /// این پروپرتی ستون‌های سفارشی ایجاد شده را بر می‌گرداند
        /// CesColumnHeader
        /// </summary>
        [Browsable(false)]
        public List<CesColumnHeader> CesColumns { 
            get
            {
                List<CesColumnHeader> result = new();

                foreach (Control ctr in flpHeader.Controls)
                    if (ctr.GetType() == typeof(CesColumnHeader))
                        result.Add((CesColumnHeader)ctr);

                return result; 
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
                dgv.CesRowSizeMode = value;
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
                dgv.CesDataSource = value;
                CreateHeaderRow();
            }
        }

        private bool cesEnableFilteringRow { get; set; } = true;
        [Category("CesGridView")]
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
        [Category("CesGridView")]
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
        [Category("CesGridView")]
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
        [Category("CesGridView")]
        public ContentAlignment CesTitleTextAlignment
        {
            get { return cesTitleTextAlignment; }
            set
            {
                cesTitleTextAlignment = value;
                lblTitle.TextAlign = value;
            }
        }

        private bool cesTitleVisible { get; set; } = true;
        [Category("CesGridView")]
        public bool CesTitleVisible
        {
            get { return cesTitleVisible; }
            set
            {
                cesTitleVisible = value;
                lblTitle.Visible = value;
            }
        }

        private string cesTitle { get; set; }
        [Category("CesGridView")]
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
        [Category("CesGridView")]
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
        [Category("CesGridView")]
        public bool CesEnableOptions
        {
            get { return cesEnableOptions; }
            set
            {
                cesEnableOptions = value;
                btnOptions.Visible = value;
            }
        }

        #endregion Properties      

        #region Original Properties

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

        private void SetTheme()
        {
            foreach (CesColumnHeader col in flpHeader.Controls)
                col.CesTheme = CesTheme;

            dgv.CesTheme = CesTheme;

            if (CesTheme == Infrastructure.ThemeEnum.None)
                ThemeNone();
            else if (CesTheme == Infrastructure.ThemeEnum.White)
                ThemeWhite();
            else if (CesTheme == Infrastructure.ThemeEnum.Dark)
                ThemeDark();
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
            pnlSpacer.BackColor = Color.White;
            SpacerSplitter.BackColor = Color.FromArgb(224, 224, 224);
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
            pnlSpacer.BackColor = Color.FromArgb(64, 64, 64);
            SpacerSplitter.BackColor = Color.FromArgb(90, 90, 90);
            pnlHeaderRow.BackColor = Color.FromArgb(64, 64, 64);
            flpHeader.BackColor = Color.FromArgb(64, 64, 64);
            dgv.GridColor = Color.FromArgb(90, 90, 90);
            btnOptions.Image = Properties.Resources.CesGridViewOptionsDark;
            btnOptions.CesColorTemplate = CesButton.ColorTemplateEnum.Dark;
        }

        private void CreateHeaderRow()
        {
            ObjectsVisibility(false);
            SetSpacerWidth();
            flpHeader.Controls.Clear();
            var columns = new List<DataGridViewColumn>();

            foreach (DataGridViewColumn col in dgv.Columns)
                columns.Add(col);

            foreach (DataGridViewColumn col in columns.OrderBy(x => x.Index))
            {
                var columnHeader = new CesColumnHeader();
                columnHeader.Name = col.Name;
                columnHeader.Index = col.Index;
                columnHeader.Title = col.HeaderText;
                columnHeader.Width = col.Width;
                columnHeader.Visible = col.Visible;
                columnHeader.Height = CesHeaderHeight;
                columnHeader.CesTheme = CesTheme;
                columnHeader.CesEnableFilter = this.CesEnableFilteringRow;

                columnHeader.ClientSizeChanged += (s, e) =>
                {
                    var header = s as CesColumnHeader;

                    foreach (DataGridViewColumn col in dgv.Columns)
                        if (col.Name == header.Name)
                            col.Width = header.Width;
                };

                columnHeader.FilterTextChanged += (s, e) =>
                {
                    dgv.AddFilter(e.Filter, columnHeader.Index);
                };

                columnHeader.ColumnHeaderClick += (s, e) =>
                {
                    DataGridViewCellMouseEventArgs args = new DataGridViewCellMouseEventArgs(
                        columnHeader.Index,
                        -1,
                        0,
                        0,
                        new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)
                    );

                    dgv.OpenFilteringDialog(columnHeader, args);
                };

                flpHeader.Controls.Add(columnHeader);
            }

            flpHeader.Top = 0;
            ObjectsVisibility(true);

            dgv.FilterAndSortCompleted -= FilterAndSortOperationDoneEventHandler;
            dgv.FilterAndSortCompleted += FilterAndSortOperationDoneEventHandler;
        }

        private void ObjectsVisibility(bool visible)
        {
            flpHeader.Visible = visible;
            pnlSpacer.Visible = visible;
            SpacerSplitter.Visible = visible;
        }

        private void SetSpacerWidth()
        {
            pnlSpacer.Visible = dgv.RowHeadersVisible;
            pnlSpacer.Width = dgv.RowHeadersWidth;
            SpacerSplitter.Visible = dgv.RowHeadersVisible;
        }

        #endregion Private Methods

        #region Public Methods

        public void LoadingMode(bool coverParentArea = true)
        {
            dgv.LoadingMode(coverParentArea);
        }

        public void CloseLoadingMode()
        {
            dgv.CloseLoadingMode();
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
                if (col.Index == columnIndex)
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
                if (col.Index == columnIndex)
                {
                    col.CesEnableFilter = enable;
                    return;
                }
        }

        #endregion Public Methods

        #region Custom Events

        private void FilterAndSortOperationDoneEventHandler(object? sender, FilterAndSortCompletedEvent e)
        {
            foreach (CesColumnHeader col in flpHeader.Controls)
            {
                if (e.ClearAllSort || (col.Index == e.ColumnIndex && e.SortType == CesGridSortTypeEnum.None))
                {
                    col.CesSortButtonVisible = false;
                    col.CesSortType = CesGridSortTypeEnum.None;
                }

                if (e.ClearAllFilter || (col.Index == e.ColumnIndex && e.ClearColumnFilter))
                {
                    col.CesHasFilter = false;
                    col.CesFilterHasError = false;
                }

                if (col.Index != e.ColumnIndex)
                    continue;

                if (e.SortType != CesGridSortTypeEnum.None)
                {
                    col.CesSortType = e.SortType;
                    col.CesSortButtonVisible = true;
                }

                if (e.HasFilteringData)
                    col.CesHasFilter = e.HasFilteringData;

                if (e.HasFilteringError)
                    col.CesFilterHasError = e.HasFilteringError;
            }
        }

        #endregion Custom Events

        #region Original Events

        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            var headers = new List<CesColumnHeader>();

            foreach (var btn in flpHeader.Controls)
            {
                if (btn.GetType() == typeof(CesColumnHeader))
                    headers.Add(btn as CesColumnHeader);
            }

            if (headers == null || headers.Count == 0)
                return;

            var colHeader = headers.FirstOrDefault(x => x.Name.EndsWith(e.Column.Name));

            if (colHeader == null)
                return;

            colHeader.Width = e.Column.Width;
        }

        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                flpHeader.Left = pnlSpacer.Width - e.NewValue;
        }

        private void pnlSpacer_SizeChanged(object sender, EventArgs e)
        {
            dgv.RowHeadersWidth = pnlSpacer.Width;
            flpHeader.Left = pnlSpacer.Width;
        }

        private void dgv_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            SetSpacerWidth();
        }

        private void SpacerSplitter_MouseDown(object sender, MouseEventArgs e)
        {
            _initialMouseX = Cursor.Position.X;
            _initialWidth = pnlSpacer.Width;
        }

        private void SpacerSplitter_MouseUp(object sender, MouseEventArgs e)
        {
            var headerX = this.PointToScreen(Point.Empty).X;
            var currentMouseX = Cursor.Position.X;
            pnlSpacer.Width = _initialWidth + (currentMouseX - _initialMouseX);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionsButtonClick?.Invoke(sender, new OptionsButtonClickEvent());
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e) => GridViewCellClick?.Invoke(sender, e);
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e) => GridViewCellContentClick?.Invoke(sender, e);
        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) => GridViewCellContentDoubleClick?.Invoke(sender, e);
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => GridViewCellDoubleClick?.Invoke(sender, e);
        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e) => GridViewCellEnter?.Invoke(sender, e);
        private void dgv_CellLeave(object sender, DataGridViewCellEventArgs e) => GridViewCellLeave?.Invoke(sender, e);
        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) => GridViewCellMouseClick?.Invoke(sender, e);
        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => GridViewCellMouseDoubleClick?.Invoke(sender, e);
        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) => GridViewCellMouseDown?.Invoke(sender, e);
        private void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e) => GridViewCellMouseEnter?.Invoke(sender, e);
        private void dgv_CellMouseLeave(object sender, DataGridViewCellEventArgs e) => GridViewCellMouseLeave?.Invoke(sender, e);
        private void dgv_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) => GridViewCellMouseUp?.Invoke(sender, e);
        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) => GridViewCellPainting?.Invoke(sender, e);
        private void dgv_CellValidated(object sender, DataGridViewCellEventArgs e) => GridViewCellValidated?.Invoke(sender, e);
        private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) => GridViewCellValidating?.Invoke(sender, e);
        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e) => GridViewCellValueChanged?.Invoke(sender, e);
        private void dgv_ColumnAdded(object sender, DataGridViewColumnEventArgs e) => GridViewColumnAdded?.Invoke(sender, e);
        private void dgv_ColumnRemoved(object sender, DataGridViewColumnEventArgs e) => GridViewColumnRemoved?.Invoke(sender, e);
        private void dgv_KeyDown(object sender, KeyEventArgs e) => GridViewKeyDown?.Invoke(sender, e);
        private void dgv_KeyPress(object sender, KeyPressEventArgs e) => GridViewKeyPress?.Invoke(sender, e);
        private void dgv_KeyUp(object sender, KeyEventArgs e) => GridViewKeyUp?.Invoke(sender, e);
        private void dgv_Paint(object sender, PaintEventArgs e) => GridViewPaint?.Invoke(sender, e);
        private void dgv_SelectionChanged(object sender, EventArgs e) => GridViewSelectionChanged?.Invoke(sender, e);
        private void dgv_UserAddedRow(object sender, DataGridViewRowEventArgs e) => GridViewUserAddedRow?.Invoke(sender, e);
        private void dgv_UserDeletedRow(object sender, DataGridViewRowEventArgs e) => GridViewUserDeletedRow?.Invoke(sender, e);
        private void dgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) => GridViewUserDeletingRow?.Invoke(sender, e);
        private void dgv_Validated(object sender, EventArgs e) => GridViewValidated?.Invoke(sender, e);
        private void dgv_Validating(object sender, CancelEventArgs e) => GridViewValidating?.Invoke(sender, e);
        
        #endregion Original Events
    }
}
