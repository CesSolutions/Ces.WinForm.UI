using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ces.WinForm.UI.Infrastructure;

namespace Ces.WinForm.UI
{
    public partial class test : UserControl, Ces.WinForm.UI.Infrastructure.IBorderOptions
    {
        public test()
        {
            if (borderOptions is null)
                borderOptions = new BorderOptions();

            this.CesControl = this;
            this.CesNotificationColor = Color.Red;
            this.CesAutoHeight = true;
            this.CesBackColor = Color.White;
            this.CesBorderColor = Color.DeepSkyBlue;
            this.CesBorderThickness = 1;
            this.CesBorderRadius = 15;
            
            InitializeComponent();
        }

        private Ces.WinForm.UI.Infrastructure.BorderOptions borderOptions = new BorderOptions();

        public int initialControlHeight { get { return borderOptions.initialControlHeight; this.Invalidate(); } set { borderOptions.initialControlHeight = value; } }
        public SizeF _titleTextSize { get { return borderOptions._titleTextSize; this.Invalidate(); } set { borderOptions._titleTextSize = value; } }
        public Control CesControl { get { return borderOptions.CesControl; this.Invalidate(); } set { borderOptions.CesControl = value; } }
        public bool CesHasNotification { get { return borderOptions.CesHasNotification; this.Invalidate(); } set { borderOptions.CesHasNotification = value; } }
        public Color CesNotificationColor { get { return borderOptions.CesNotificationColor; this.Invalidate(); } set { borderOptions.CesNotificationColor = value; } }
        public bool CesAutoHeight { get { return borderOptions.CesAutoHeight; this.Invalidate(); } set { borderOptions.CesAutoHeight = value; } }
        public Color CesBackColor { get { return borderOptions.CesBackColor; this.Invalidate(); } set { borderOptions.CesBackColor = value; } }
        public Color CesBorderColor { get { return borderOptions.CesBorderColor; this.Invalidate(); } set { borderOptions.CesBorderColor = value; } }
        public int CesBorderThickness { get { return borderOptions.CesBorderThickness; this.Invalidate(); } set { borderOptions.CesBorderThickness = value; } }
        public int CesBorderRadius { get { return borderOptions.CesBorderRadius; this.Invalidate(); } set { borderOptions.CesBorderRadius = value; } }


        private void test_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.GenerateBorder(borderOptions, new TitleOptions());
        }
    }
}
