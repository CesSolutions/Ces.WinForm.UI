using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesImage
{
    public partial class CesSimplePictureBox : UserControl
    {
        public CesSimplePictureBox()
        {
            InitializeComponent();
        }


        private Image cesImage { get; set; }
        public Image CesImage
        {
            get { return cesImage; }
            set
            {
                cesImage = value;
                this.Invalidate();
            }
        }


        private int cesBorderThickness { get; set; } = 2;
        public int CesBorderThickness
        {
            get { return cesBorderThickness; }
            set
            {
                cesBorderThickness = value;
                this.Invalidate();
            }
        }

        private Color cesBorderColor { get; set; } = Color.DarkOrange;
        public Color CesBorderColor
        {
            get { return cesBorderColor; }
            set
            {
                cesBorderColor = value;
                this.Invalidate();
            }
        }

        private bool cesShowBorder { get; set; } = true;
        public bool CesShowBorder
        {
            get { return cesShowBorder; }
            set
            {
                cesShowBorder = value;
                this.Invalidate();
            }
        }

        private void CesSimplePictureBox_Paint(object sender, PaintEventArgs e)
        {
            using Graphics g = e.Graphics;
            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            RectangleF rect = new RectangleF(
                (CesBorderThickness / 2) + 1,
                (CesBorderThickness / 2) + 1,
                this.Width - CesBorderThickness - 2,
                this.Width - CesBorderThickness - 2);

            if (CesImage != null)
            {
                using Bitmap bmp = new Bitmap(CesImage, new Size((int)rect.Width, (int)rect.Height));
                using Graphics g2 = Graphics.FromImage(bmp);  
                using Brush b = new TextureBrush(bmp);
                g.FillEllipse(b, rect);
            }

            if (CesShowBorder)
                g.DrawEllipse(new Pen(CesBorderColor, CesBorderThickness), rect);
        }

        private void CesSimplePictureBox_Resize(object sender, EventArgs e)
        {
            this.Width = this.Height;
        }
    }
}
