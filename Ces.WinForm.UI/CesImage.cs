using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI
{
    public partial class CesImage : PictureBox
    {
        public CesImage()
        {
            InitializeComponent();
        }


        private bool cesCircularMode { get; set; } = false;
        public bool CesCircularMode
        {
            get { return cesCircularMode; }
            set
            {
                cesCircularMode = value;
                this.Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            using Graphics g = Graphics.FromImage(this.Image);
            using GraphicsPath gp = new GraphicsPath();

            g.Clear(Color.Transparent);

            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (CesCircularMode)
            {
                if (this.Width <= this.Height)
                    gp.AddEllipse(0, 0, this.Width, this.Width);
                else
                    gp.AddEllipse(0, 0, this.Height, this.Height);
            }
            else
            {
                gp.AddRectangle(new Rectangle(0, 0, this.Width, this.Height));
            }

            this.Region = new Region(gp);
            Brush b = new TextureBrush(this.Image);
            g.FillPath(b, gp);
            g.DrawImage(this.Image, 0, 0, this.Width, this.Height);
        }

        protected override void OnResize(EventArgs e)
        {
            if (CesCircularMode)
                this.Width = this.Height;
        }
    }
}
