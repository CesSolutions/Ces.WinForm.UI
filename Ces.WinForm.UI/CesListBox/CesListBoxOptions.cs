using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesListBox
{
    public class CesListBoxOptions
    {
        public string ValueMember { get; set; } = string.Empty;
        public string DisplayMember { get; set; } = string.Empty;
        public bool ShowIndicator { get; set; }
        public bool ShowImage { get; set; }
        public int Margin { get; set; } = 0;
        public int ImageWidth { get; set; } = 24;
        public int ItemHeight { get; set; } = 35;
        public int ItemWidth { get; set; } = 35;
    }

    public class CesListBoxItemProperty
    {
        // تعیین مقدار متن جهت نمایش الزامی می باشد
        public CesListBoxItemProperty(string? text = null, object? value = null, Image? image = null)
        {
            this.Value = value;
            this.Text = text;
            this.Image = image;
        }

        public string? Text { get; set; }
        public object? Value { get; set; }
        public Image? Image { get; set; }
    }
}
