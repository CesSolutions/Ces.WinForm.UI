using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesListBox
{
    [ToolboxItem(false)]
    public partial class CesListBoxItem : UserControl
    {
        public CesListBoxItem()
        {
            InitializeComponent();
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
                if (value != null)
                    this.pbItemImage.Visible = CesOptions.ShowImage ? (value?.Image != null) : false;
                else
                    this.pbItemImage.Visible = false;
            }
        }


        private Ces.WinForm.UI.CesComboBox.CesListBoxOptions cesOptions;
        public Ces.WinForm.UI.CesComboBox.CesListBoxOptions CesOptions
        {
            get { return cesOptions; }
            set
            {
                cesOptions = value;

                this.Margin = new Padding(0, 0, 0, cesOptions.Margin);
                this.pbItemImage.Width = cesOptions.ImageWidth;
                this.Height = cesOptions.ItemHeight;
                this.Width = cesOptions.ItemWidth;

                this.pbItemImage.Visible = cesOptions.ShowImage;
            }
        }


        private void MouseEnter(object sender, EventArgs e)
        {
            if (cesOptions.ShowIndicator)            
                this.pnlIndicator.BackColor = Color.Orange;            
            else            
                this.BackColor = Color.Khaki;            
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            if (cesOptions.ShowIndicator)            
                this.pnlIndicator.BackColor = Color.White;            
            else            
                this.BackColor = Color.White;            
        }

        private void lblItemText_Click(object sender, EventArgs e)
        {
            if (CesListBoxItemClick != null)
                CesListBoxItemClick(this, cesItem);
        }
    }
}
