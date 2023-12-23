using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesListBox
{
    internal static class CesListBoxOptions
    {
        public static string ValueMember { get; set; } = string.Empty;
        public static string DisplayMember { get; set; } = string.Empty;
        public static bool ShowIndicator { get; set; }
        public static bool ShowImage { get; set; }
        public static int ImageWidth { get; set; }
        public static int ItemHeight { get; set; } 
        public static Color SelectionColor { get; set; } 
        public static Color SelectionForeColor { get; set; } 
        public static Color IndicatorColor { get; set; }
        public static Color HighlightColor { get; set; }
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
