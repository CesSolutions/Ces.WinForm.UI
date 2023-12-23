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
                if (value == null)
                {
                    this.pbItemImage.Visible = false;
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.pbItemImage.Visible = CesOptions.ShowImage ? (value?.Image != null) : false;
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

                if (!value)
                    ClearSelection();
            }
        }

        private Ces.WinForm.UI.CesListBox.CesListBoxOptions cesOptions = new CesListBoxOptions();
        public Ces.WinForm.UI.CesListBox.CesListBoxOptions CesOptions
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
            if (CesItem == null || (CesItem.Value == null && CesItem == null))
                return;

            if (CesSelected)
                lblItemText.ForeColor = Color.Black;

            if (cesOptions.ShowIndicator)
                this.pnlIndicator.BackColor = Color.Orange;
            else
                this.BackColor = Color.Khaki;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            //if (CesItem == null || (CesItem.Value == null && CesItem == null))
            //    return;

            if (CesSelected)
            {
                this.BackColor = CesOptions.SelectionColor;
                this.lblItemText.ForeColor = CesOptions.SelectionForeColor;
                return;
            }

            if (cesOptions.ShowIndicator)
                this.pnlIndicator.BackColor = Color.White;
            else
                this.BackColor = Color.White;
        }

        private void lblItemText_Click(object sender, EventArgs e)
        {
            if (CesItem == null || (CesItem.Value == null && CesItem == null))
                return;

            CesSelected = !CesSelected;

            if (CesSelected)
            {
                this.BackColor = CesOptions.SelectionColor;
                this.lblItemText.ForeColor = CesOptions.SelectionForeColor;
            }
            else
            {
                this.BackColor = Color.Transparent;
                this.lblItemText.ForeColor = Color.Black;
            }


            if (CesListBoxItemClick != null)
                CesListBoxItemClick(this, cesItem);
        }

        private void ClearSelection()
        {
            this.BackColor = Color.Transparent;
            this.lblItemText.ForeColor = Color.Black;
        }
    }
}
