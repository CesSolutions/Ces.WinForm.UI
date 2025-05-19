using System.ComponentModel;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridView2 : UserControl
    {
        public CesGridView2()
        {
            InitializeComponent();
        }

        private int _initialMouseX;
        private int _initialWidth;

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
                dgv.CesEnableFiltering = value;
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
                dgv.CesSetAppearance = value;
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
                dgv.CesRowSizeMode = value;
            }
        }

        private bool cesDarkMode { get; set; } = true;
        [Category("Ces GridView")]
        public bool CesDarkMode
        {
            get { return cesDarkMode; }
            set
            {
                cesDarkMode = value;
                dgv.CesDarkMode = value;
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

        #endregion Properties

        private void CreateHeaderRow()
        {
            flpHeader.Visible = false;
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

                columnHeader.ClientSizeChanged += (s, e) =>
                {
                    var header = s as CesColumnHeader;

                    foreach (DataGridViewColumn col in dgv.Columns)
                        if (col.Name == header.Name)
                            col.Width = header.Width;
                };

                columnHeader.FilterTextChanged += (s, e) => this.Text = e.Filter;
                flpHeader.Controls.Add(columnHeader);
            }
            flpHeader.Top = 0;
            flpHeader.Height = pnlHeaderRow.Height;
            flpHeader.Visible = true;
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
            dgv.RowHeadersWidth = pnlSpacer.Width ;
            flpHeader.Left = pnlSpacer.Width;
        }

        private void dgv_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            SetSpacerWidth();
        }

        private void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            CreateHeaderRow();
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
    }
}
