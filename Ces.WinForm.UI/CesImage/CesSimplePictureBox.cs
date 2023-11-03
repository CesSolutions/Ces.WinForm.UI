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


        public int cesBorderThickness { get; set; } = 2;
        public int CesBorderThickness
        {
            get { return cesBorderThickness; }
            set
            {
                cesBorderThickness = value;
                this.Invalidate();
            }
        }

        public Color cesBorderColor { get; set; } = Color.DarkOrange;
        public Color CesBorderColor
        {
            get { return cesBorderColor; }
            set
            {
                cesBorderColor = value;
                this.Invalidate();
            }
        }

        private void CesSimplePictureBox_Load(object sender, EventArgs e)
        {

        }

        private void CesSimplePictureBox_Paint(object sender, PaintEventArgs e)
        {
            using Graphics g = e.Graphics;
            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            RectangleF rect = new RectangleF();

            if (this.Width <= this.Height)
                rect = new RectangleF(
                    (CesBorderThickness / 2) + 1,
                    (this.Height / 2) - (this.Width / 2) + (CesBorderThickness / 2) + 1,
                    this.Width - CesBorderThickness - 2,
                    this.Width - CesBorderThickness - 2);
            else
                rect = new RectangleF(
                    (this.Width / 2) - (this.Height / 2) + (CesBorderThickness / 2) + 1,
                    (CesBorderThickness / 2) + 1,
                    this.Height - CesBorderThickness - 2,
                    this.Height - CesBorderThickness - 2);

            if (CesImage != null)
            {
                using Brush b = new TextureBrush(CesImage);
                g.FillEllipse(b, rect);
            }

            g.DrawEllipse(new Pen(CesBorderColor, CesBorderThickness), rect);
        }
    }
}
