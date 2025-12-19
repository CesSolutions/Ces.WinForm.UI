using Ces.WinForm.UI.CesGridView.Events;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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

        /// <summary>
        /// مقدار این کنترل در حال حاضر در تعیین موقعیت کادر فیلترینگ کاربرد دارد
        /// </summary>
        public int FilterRowHeight
        {
            get
            {
                return pnlFilter.Height;
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
                btnHeader.TextAlign = value;
            }
        }

        private bool cesSortButtonVisible { get; set; }
        public bool CesSortButtonVisible
        {
            get
            {
                return cesSortButtonVisible;
            }
            set
            {
                cesSortButtonVisible = value;
                btnSort.Visible = value;
            }
        }

        private bool cesFilterButtonVisible { get; set; }
        public bool CesFilterButtonVisible
        {
            get
            {
                return cesFilterButtonVisible;
            }
            set
            {
                cesFilterButtonVisible = value;
                btnFilter.Visible = value;
            }
        }

        private bool cesFilterHasError { get; set; }
        public bool CesFilterHasError
        {
            get { return cesFilterHasError; }
            set
            {
                cesFilterHasError = value;

                if (value)
                    btnFilter.Image = Properties.Resources.CesGridViewFilterHasError;
                else
                {
                    if (CesHasFilter)
                        btnFilter.Image = Properties.Resources.CesGridViewFilterSet;
                    else
                        btnFilter.Image = Properties.Resources.CesGridViewFilterNotSet;
                }
            }
        }

        private bool cesHasFilter { get; set; }
        public bool CesHasFilter
        {
            get
            {
                return cesHasFilter;
            }
            set
            {
                cesHasFilter = value;

                if (value)
                    btnFilter.Image = Properties.Resources.CesGridViewFilterSet;
                else
                    btnFilter.Image = Properties.Resources.CesGridViewFilterNotSet;
            }
        }

        private CesGridSortTypeEnum cesSortType { get; set; }
        public CesGridSortTypeEnum CesSortType
        {
            get
            {
                return cesSortType;
            }
            set
            {
                cesSortType = value;
                CesSortButtonVisible = !(value == CesGridSortTypeEnum.None);

                if (value == CesGridSortTypeEnum.None)
                    btnSort.Image = null;
                else if (value == CesGridSortTypeEnum.ASC)
                    btnSort.Image = Properties.Resources.CesGridViewSortAscending;
                else if (value == CesGridSortTypeEnum.DESC)
                    btnSort.Image = Properties.Resources.CesGridViewSortDescending;
            }
        }


        private bool cesEnableFilter { get; set; } = true;
        public bool CesEnableFilter
        {
            get
            {
                return cesEnableFilter;
            }
            set
            {
                cesEnableFilter = value;
                pnlFilter.Visible = value;
           }
        }

        private int cesIndex { get; set; }
        public int CesIndex
        {
            get { return cesIndex; }
            set
            {
                cesIndex = value;
            }
        }

        private int cesHeaderMinWidth { get; set; }
        public int CesHeaderMinWidth
        {
            get { return cesHeaderMinWidth; }
            set
            {
                cesHeaderMinWidth = value;
                this.Width = value;
            }
        }

        private string cesTitle { get; set; }
        public string CesTitle
        {
            get { return cesTitle; }
            set
            {
                cesTitle = value;
                btnHeader.Text = value;

                //بعد از تعیین عنوان، حداقل عرض هدر را نیز تنظیم می‌کنیم
                using var g = this.CreateGraphics();
                var textSize = g.MeasureString(CesTitle, CesTitleFont);
                //عدد 40 پهنای دکمه های فیلترینگ و مرتب‌سازی است
                CesHeaderMinWidth = (int)textSize.Width + 40;
            }
        }

        private string cesFilterValue { get; set; }
        public string CesFilterValue
        {
            get { return cesFilterValue; }
            set
            {
                cesFilterValue = value;
                txtFilter.CesText = value;
            }
        }

        private Font cesTitleFont { get; set; }
        [DefaultValue(typeof(Font), "Segoe UI, 9")]
        public Font CesTitleFont
        {
            get { return cesTitleFont; }
            set
            {
                cesTitleFont = value ?? new Font("Segoe UI", 9); 
                btnHeader.Font = CesTitleFont;
            }
        }

        private Color cesTitleColor { get; set; }
        public Color CesTitleColor
        {
            get { return cesTitleColor; }
            set
            {
                cesTitleColor = value;
                btnHeader.ForeColor = value;
            }
        }

        private ContentAlignment cesTitleAlignment { get; set; } = ContentAlignment.MiddleCenter;
        public ContentAlignment CesTitleAlignment
        {
            get { return cesTitleAlignment; }
            set
            {
                cesTitleAlignment = value;
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

        private void txtFilter_CesTextChanged(object sender, EventArgs e)
        {
            CesFilterValue = txtFilter.CesText;

            if (FilterTextChanged != null)
                FilterTextChanged.Invoke(this, new FilterTextChangedEvent { Filter = CesFilterValue });
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
