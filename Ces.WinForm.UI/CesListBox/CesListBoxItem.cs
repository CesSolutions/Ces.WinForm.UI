using System.ComponentModel;

namespace Ces.WinForm.UI.CesListBox
{
    [ToolboxItem(false)]
    public partial class CesListBoxItem : UserControl
    {
        public CesListBoxItem()
        {
            InitializeComponent();

            this.pbItemImage.Width = Ces.WinForm.UI.CesListBox.CesListBoxOptions.ImageWidth;
            this.Height = Ces.WinForm.UI.CesListBox.CesListBoxOptions.ItemHeight;
            this.pbItemImage.Visible = Ces.WinForm.UI.CesListBox.CesListBoxOptions.ShowImage;
        }

        public delegate void CesListBoxItemClickEventHandler(object sender, object? item);
        public event CesListBoxItemClickEventHandler CesListBoxItemClick;

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

        private bool cesShowIndicator;
        public bool CesShowIndicator
        {
            get { return cesShowIndicator; }
            set
            {
                cesShowIndicator = value;
                this.pnlIndicator.Visible = value;
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
            if (CesItem == null || (CesItem.Value == null && CesItem == null))
                return;

            if (CesSelected)
                return;

            if (Ces.WinForm.UI.CesListBox.CesListBoxOptions.ShowIndicator)
                this.pnlIndicator.BackColor = Ces.WinForm.UI.CesListBox.CesListBoxOptions.IndicatorColor;
            else            
                this.BackColor = Ces.WinForm.UI.CesListBox.CesListBoxOptions.HighlightColor;            
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            if (CesSelected)
            {
                this.BackColor = Ces.WinForm.UI.CesListBox.CesListBoxOptions.SelectionColor;
                this.lblItemText.ForeColor = Ces.WinForm.UI.CesListBox.CesListBoxOptions.SelectionForeColor;
                return;
            }

            if (Ces.WinForm.UI.CesListBox.CesListBoxOptions.ShowIndicator)
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
            if (CesItem == null || (CesItem.Value == null && CesItem == null))
                return;

            CesSelected = !CesSelected;
            
            if (CesListBoxItemClick != null)
                CesListBoxItemClick(this, CesItem);
        }

        private void SetItemColor()
        {
            if (CesSelected)
            {
                this.BackColor = Ces.WinForm.UI.CesListBox.CesListBoxOptions.SelectionColor;
                this.lblItemText.ForeColor = Ces.WinForm.UI.CesListBox.CesListBoxOptions.SelectionForeColor;
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
    }
}
