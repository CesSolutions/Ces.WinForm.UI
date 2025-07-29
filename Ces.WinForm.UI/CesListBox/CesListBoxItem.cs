using System.ComponentModel;

namespace Ces.WinForm.UI.CesListBox
{
    [ToolboxItem(false)]
    public partial class CesListBoxItem : UserControl
    {
        public CesListBoxItem()
        {
            InitializeComponent();
        }

        public event EventHandler<Events.CesItemClickEvent> CesItemClick;

        #region Properties

        private CesListBoxItemProperty? cesItem;
        public CesListBoxItemProperty? CesItem
        {
            get { return this.cesItem; }
            set
            {
                cesItem = value;

                this.lblItemText.Text = value == null ? string.Empty : value.Text;
                this.pbItemImage.Image = value == null ? null : value.Image;

                if (value == null)
                    CesSelected = false;
            }
        }

        private bool cesSelected { get; set; }
        public bool CesSelected
        {
            get { return cesSelected; }
            set
            {
                cesSelected = value;
                SetItemColor();
            }
        }

        private bool cesShowIndicator { get; set; }
        public bool CesShowIndicator
        {
            get { return cesShowIndicator; }
            set
            {
                cesShowIndicator = value;
                this.pnlIndicator.Visible = value;
            }
        }

        private bool cesShowImage { get; set; }
        public bool CesShowImage
        {
            get { return cesShowImage; }
            set
            {
                cesShowImage = value;
                this.pbItemImage.Visible = value;
            }
        }

        private int cesImageWidth { get; set; }
        public int CesImageWidth
        {
            get { return cesImageWidth; }
            set
            {
                cesImageWidth = value;
                this.pbItemImage.Width = value;
            }
        }

        private int cesItemHeight { get; set; }
        public int CesItemHeight
        {
            get { return cesItemHeight; }
            set
            {
                cesItemHeight = value;
                this.Height = value;
            }
        }

        private Color cesSelectionColor { get; set; } = Color.Gold;
        public Color CesSelectionColor
        {
            get { return cesSelectionColor; }
            set { cesSelectionColor = value; }
        }

        private Color cesSelectionForeColor { get; set; } = Color.White;
        public Color CesSelectionForeColor
        {
            get { return cesSelectionForeColor; }
            set { cesSelectionForeColor = value; }
        }

        private Color cesIndicatorColor { get; set; } = Color.DodgerBlue;
        public Color CesIndicatorColor
        {
            get { return cesIndicatorColor; }
            set { cesIndicatorColor = value; }
        }

        private Color cesHighlightColor { get; set; } = Color.Khaki;
        public Color CesHighlightColor
        {
            get { return cesHighlightColor; }
            set { cesHighlightColor = value; }
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

        #endregion Properties

        #region Methods

        private void SetTheme()
        {
            if (this.CesTheme == Infrastructure.ThemeEnum.None)
                ThemeNone();
            else if (this.CesTheme == Infrastructure.ThemeEnum.White)
                ThemeWhite();
            else if (this.CesTheme == Infrastructure.ThemeEnum.Dark)
                ThemeDark();
        }

        private void ThemeNone()
        {

        }

        private void ThemeWhite()
        {
            this.BackColor = Color.White;
            lblItemText.ForeColor = Color.Black;
            pnlIndicator.BackColor = Color.White;
        }

        private void ThemeDark()
        {
            this.BackColor = Color.FromArgb(64, 64, 64);
            lblItemText.ForeColor = Color.Silver;
            pnlIndicator.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            if (CesItem == null)
                return;

            if (CesShowIndicator)
                this.pnlIndicator.BackColor = CesIndicatorColor;
            else
                this.BackColor = CesHighlightColor;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            if (CesItem == null)
                return;

            if (CesSelected)
            {
                this.BackColor = CesSelectionColor;
                this.lblItemText.ForeColor = CesSelectionForeColor;
                return;
            }

            if (CesShowIndicator)
                this.pnlIndicator.BackColor = CesTheme == Infrastructure.ThemeEnum.Dark ?
                    Color.FromArgb(64, 64, 64) :
                    Color.White;
            else
                this.BackColor = CesTheme == Infrastructure.ThemeEnum.Dark ?
                    Color.FromArgb(64, 64, 64) :
                    Color.White;
        }

        private void lblItemText_Click(object sender, EventArgs e)
        {
            ItemClicked();
        }

        public void ItemClicked()
        {
            CesSelected = !CesSelected;
            CesItemClick?.Invoke(this, new UI.CesListBox.Events.CesItemClickEvent { Item = CesItem });
        }

        private void SetItemColor()
        {
            if (CesSelected)
            {
                this.BackColor = CesSelectionColor;
                this.lblItemText.ForeColor = CesSelectionForeColor;
            }
            else
            {
                this.BackColor = CesTheme == Infrastructure.ThemeEnum.Dark ?
                    Color.FromArgb(64, 64, 64) :
                    Color.White;
                this.pnlIndicator.BackColor = CesTheme == Infrastructure.ThemeEnum.Dark ?
                    Color.FromArgb(64, 64, 64) :
                    Color.White;
                this.lblItemText.ForeColor = CesTheme == Infrastructure.ThemeEnum.Dark ?
                    Color.Silver :
                    Color.Black;
            }
        }

        #endregion Methods
    }
}
