using Ces.WinForm.UI.CesGridView.Events;
using System.ComponentModel;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridView2 : UserControl
    {
        public CesGridView2()
        {
            InitializeComponent();
        }

        public event EventHandler<OptionsButtonClickEvent> OptionsButtonClick;
        private int _initialMouseX;
        private int _initialWidth;

        #region Properties

        private CesGridViewRowSizeModeEnum cesRowSizeMode { get; set; }
            = CesGridViewRowSizeModeEnum.Normal;
        [Category("Ces GridView")]
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
                dgv.CesDataSource = value;
                CreateHeaderRow();
            }
        }

        private bool cesEnableFilteringRow { get; set; }
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

            dgv.FilterAndSortOperationDone -= FilterAndSortOperationDoneEventHandler;
            dgv.FilterAndSortOperationDone += FilterAndSortOperationDoneEventHandler;
        }

        private void FilterAndSortOperationDoneEventHandler(object? sender, FilterAndSortOperationDoneEvent e)
        {
            foreach (CesColumnHeader col in flpHeader.Controls)
            {
                if (e.ClearAllSort || (col.Index == e.ColumnIndex && e.SortType == CesGridSortTypeEnum.None))
                {
                    col.CesSortButtonVisible = false;
                    col.CesSortType = CesGridSortTypeEnum.None;
                }

                if (e.ClearAllFilter || (col.Index == e.ColumnIndex && e.ClearColumnFilter))
                    col.CesHasFilter = false;

                if (col.Index != e.ColumnIndex)
                    continue;

                if (e.SortType != CesGridSortTypeEnum.None)
                {
                    col.CesSortType = e.SortType;
                    col.CesSortButtonVisible = true;
                }

                if (e.HasFilterignData)
                    col.CesHasFilter = true;
            }
        }

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

        public void LoadingMode(bool coverParentArea = true)
        {
            dgv.LoadingMode(coverParentArea);
        }

        public void CloseLoadingMode()
        {
            dgv.CloseLoadingMode();
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

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionsButtonClick?.Invoke(sender, new OptionsButtonClickEvent());
        }
    }
}
