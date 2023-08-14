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

        public bool ShowIndicator { get; set; }
        public bool ShowImage { get; set; }
        public int Margin { get; set; }
        public int ImageWidth { get; set; }
        public int ItemHeight { get; set; }
        public int ItemWidth { get; set; }
    }
}
