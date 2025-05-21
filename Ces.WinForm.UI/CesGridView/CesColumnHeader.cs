using Ces.WinForm.UI.CesGridView.Events;
using System.ComponentModel;

namespace Ces.WinForm.UI.CesGridView
{
    [ToolboxItem(false)]
    public partial class CesColumnHeader : UserControl
    {
        public CesColumnHeader()
        {
            InitializeComponent();
        }

        public event EventHandler<FilterTextChangedEvent> FilterTextChanged;
        public event EventHandler<ColumnHeaderClickEvent> ColumnHeaderClick;

        private int _initialMouseX;
        private int _initialWidth;
        private Color _btnHeaderBackColor;
        private Color _btnFilterBackColor;
        private Color _btnSortBackColor;

        public CesGridView dgv { get; set; }

        private ContentAlignment cesHeaderTextAlignment { get; set; }
            = ContentAlignment.MiddleCenter;
        public ContentAlignment CesHeaderTextAlignment
        {
            get { return cesHeaderTextAlignment; }
            set
            {
                cesHeaderTextAlignment = value;
                btnHeader.TextAlign = value;
            }
        }

        private bool cesCnableFilter { get; set; } = true;
        public bool CesEnableFilter
        {
            get
            {
                return cesCnableFilter;
            }
            set
            {
                cesCnableFilter = value;
                pnlFilter.Visible = value;
            }
        }

        private int _Index { get; set; }
        public int Index
        {
            get { return _Index; }
            set
            {
                _Index = value;
            }
        }

        private string _Title { get; set; }
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                btnHeader.Text = value;
            }
        }

        private ContentAlignment _TitleAlignment { get; set; } = ContentAlignment.MiddleCenter;
        public ContentAlignment TitleAlignment
        {
            get { return _TitleAlignment; }
            set
            {
                _TitleAlignment = value;
                btnHeader.TextAlign = value;
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

        private void SetTheme()
        {
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
            this.BackColor = Color.White;
            btnHeader.CesColorTemplate = CesButton.ColorTemplateEnum.White;
            btnFilter.CesColorTemplate = CesButton.ColorTemplateEnum.White;
            btnSort.CesColorTemplate = CesButton.ColorTemplateEnum.White;
            pnlFilter.BackColor = Color.White;
            lineTop.BackColor = Color.White;
            lineTop.CesLineColor = Color.FromArgb(224, 224, 224);
            lineBottom.BackColor = Color.White;
            lineBottom.CesLineColor = Color.FromArgb(224, 224, 224);
            txtFilter.CesBackColor = Color.White;
            txtFilter.CesFocusColor = Color.White;
            txtFilter.ForeColor = Color.Black;
            txtFilter.CesBorderColor = Color.White;
            splitter.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void ThemeDark()
        {
            this.BackColor = Color.FromArgb(64, 64, 64);
            btnHeader.CesColorTemplate = CesButton.ColorTemplateEnum.Dark;
            btnFilter.CesColorTemplate = CesButton.ColorTemplateEnum.Dark;
            btnSort.CesColorTemplate = CesButton.ColorTemplateEnum.Dark;
            pnlFilter.BackColor = Color.FromArgb(90, 90, 90);
            lineTop.BackColor = Color.FromArgb(64, 64, 64);
            lineTop.CesLineColor = Color.FromArgb(90, 90, 90);
            lineBottom.BackColor = Color.FromArgb(64, 64, 64);
            lineBottom.CesLineColor = Color.FromArgb(90, 90, 90);
            txtFilter.CesBackColor = Color.FromArgb(60, 60, 60);
            txtFilter.CesFocusColor = Color.FromArgb(60, 60, 60);
            txtFilter.ForeColor = Color.Silver;
            txtFilter.CesBorderColor = Color.FromArgb(60, 60, 60);
            splitter.BackColor = Color.FromArgb(90, 90, 90);
        }

        private void txt_CesTextChanged(object sender, EventArgs e)
        {
            if (FilterTextChanged != null)
                FilterTextChanged.Invoke(this, new FilterTextChangedEvent { Filter = txt.CesText });
        }

        private void splitter_MouseDown(object sender, MouseEventArgs e)
        {
            _initialMouseX = Cursor.Position.X;
            _initialWidth = this.Width;
        }

        private void splitter_MouseUp(object sender, MouseEventArgs e)
        {
            var headerX = this.PointToScreen(Point.Empty).X;
            var currentMouseX = Cursor.Position.X;
            this.Width = _initialWidth + (currentMouseX - _initialMouseX);
        }

        private void btnHeader_MouseEnter(object sender, EventArgs e)
        {
            _btnFilterBackColor = btnFilter.BackColor;
            _btnSortBackColor = btnSort.BackColor;
            btnFilter.BackColor = btnHeader.FlatAppearance.MouseOverBackColor;
            btnSort.BackColor = btnHeader.FlatAppearance.MouseOverBackColor;
        }

        private void btnHeader_MouseLeave(object sender, EventArgs e)
        {
            btnFilter.BackColor = _btnFilterBackColor;
            btnSort.BackColor = _btnSortBackColor;
        }


        private void btnFilter_MouseEnter(object sender, EventArgs e)
        {
            _btnHeaderBackColor = btnHeader.BackColor;
            _btnSortBackColor = btnSort.BackColor;
            btnHeader.BackColor = btnFilter.FlatAppearance.MouseOverBackColor;
            btnSort.BackColor = btnFilter.FlatAppearance.MouseOverBackColor;
        }

        private void btnFilter_MouseLeave(object sender, EventArgs e)
        {
            btnHeader.BackColor = _btnHeaderBackColor;
            btnSort.BackColor = _btnSortBackColor;
        }

        private void btnSort_MouseEnter(object sender, EventArgs e)
        {
            _btnHeaderBackColor = btnHeader.BackColor;
            _btnFilterBackColor = btnFilter.BackColor;
            btnHeader.BackColor = btnSort.FlatAppearance.MouseOverBackColor;
            btnFilter.BackColor = btnSort.FlatAppearance.MouseOverBackColor;
        }

        private void btnSort_MouseLeave(object sender, EventArgs e)
        {
            btnHeader.BackColor = _btnHeaderBackColor;
            btnFilter.BackColor = _btnFilterBackColor;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (ColumnHeaderClick != null)
                ColumnHeaderClick.Invoke(this, new ColumnHeaderClickEvent());
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (ColumnHeaderClick != null)
                ColumnHeaderClick.Invoke(this, new ColumnHeaderClickEvent());
        }
    }
}
