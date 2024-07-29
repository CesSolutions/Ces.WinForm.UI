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

                // در صورتی که ویژگی نمایش تصویر فعال باشد
                // باری آیتم هایی که تصویر ندارند باید کنترل
                // عکس مخفی شود
                if (value == null)
                {
                    this.pbItemImage.Visible = false;
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.pbItemImage.Visible = Ces.WinForm.UI.CesListBox.CesListBoxOptions.ShowImage ? (value?.Image != null) : false;
                    this.Cursor = Cursors.Hand;
                }
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
                this.pnlIndicator.BackColor = Color.White;
            else
                this.BackColor = Color.White;
        }

        private void lblItemText_Click(object sender, EventArgs e)
        {
            if (CesItem == null || (CesItem.Value == null && CesItem == null))
                return;

            CesSelected = !CesSelected;

            if (CesListBoxItemClick != null)
                CesListBoxItemClick(this, cesItem);
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
                this.BackColor = Color.White;
                this.pnlIndicator.BackColor = Color.White;
                this.lblItemText.ForeColor = Color.Black;
            }
        }
    }
}
