using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesComboBox
{
    public class CesComboBoxOptions
    {
        public CesComboBoxOptions()
        {
            this.ShowIndicator = false;
            this.ShowImage = false;
            this.Margin = 1;
            this.ImageWidth =24;
            this.ItemHeight = 35;
            this.ItemWidth = 35;
        }

        public string ValueMember { get; set; }
        public string DisplayMember { get; set; }
        public bool ShowIndicator { get; set; }
        public bool ShowImage { get; set; }
        public int Margin { get; set; }
        public int ImageWidth { get; set; }
        public int ItemHeight { get; set; }
        public int ItemWidth { get; set; }
    }

    public class CesSimpleComboBoxItem
    {
        // تعیین مقدار متن جهت نمایش الزامی می باشد
        public CesSimpleComboBoxItem(string? text = null, object? value = null, Image? image = null)
        {
            this.Text = text;
            this.Value = value;
            this.Image = image;
        }

        public string? Text { get; set; }
        public object? Value { get; set; }
        public Image? Image { get; set; }
    }
}
