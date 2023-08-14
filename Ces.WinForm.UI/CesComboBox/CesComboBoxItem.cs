using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesComboBox
{
    public partial class CesComboBoxItem : UserControl
    {
        public CesComboBoxItem(CesSimpleComboBoxItem cesSimpleComboBoxItem)
        {
            InitializeComponent();
            CesItem = cesSimpleComboBoxItem;
        }


        private CesSimpleComboBoxItem cesItem;
        public CesSimpleComboBoxItem CesItem
        {
            get { return this.cesItem; }
            set
            {
                cesItem = value;

                this.lblItemText.Text = value.Text;
                this.pbItemImage.Visible = (value.Image != null);
                this.pbItemImage.Image = value.Image;
            }
        }

        private bool cesShowIndicator = true;
        public bool CesShowIndicator
        {
            get { return cesShowIndicator; }
            set { cesShowIndicator = value; }
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            if (CesShowIndicator)
            {
                this.pnlIndicator.BackColor = Color.Orange;
            }
            else
            {
                this.BackColor = Color.Khaki;
            }
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            if (CesShowIndicator)
            {
                this.pnlIndicator.BackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
            }
        }
    }

    public class CesSimpleComboBoxItem
    {
        // تعیین مقدار متن جهت نمایش الزامی می باشد
        public CesSimpleComboBoxItem(string text, object? value = null, Image? image = null)
        {
            this.Text = text;
            this.Value = value;
            this.Image = image;
        }

        public string Text { get; set; }
        public object? Value { get; set; }
        public Image? Image { get; set; }
    }
}
