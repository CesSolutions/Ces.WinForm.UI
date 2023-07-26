using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI
{
    public partial class CesLabel : System.Windows.Forms.Label
    {
        public CesLabel()
        {
            InitializeComponent();
        }


        private bool cesVertical { get; set; }
        [System.ComponentModel.Category("CesLabel")]
        [System.ComponentModel.Description("CesLabel can show string value in vertical direction.")]
        public bool CesVertical
        {
            get { return cesVertical; }
            set
            {
                cesVertical = value;
                Redraw();
            }
        }


        private float cesDegree { get; set; } = 90;
        [System.ComponentModel.Category("CesLabel")]
        public float CesDegree
        {
            get { return cesDegree; }
            set
            {
                cesDegree = value;
                Redraw();
            }
        }

        private int cesOffsetX { get; set; }
        [System.ComponentModel.Category("CesLabel")]
        public int CesOffsetX
        {
            get { return cesOffsetX; }
            set
            {
                cesOffsetX = value;
                Redraw();
            }
        }


        private int cesOffsetY { get; set; }
        [System.ComponentModel.Category("CesLabel")]
        public int CesOffsetY
        {
            get { return cesOffsetY; }
            set
            {
                cesOffsetY = value;
                Redraw();
            }
        }


        private void CesLabel_TextChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void Redraw()
        {
            using System.Drawing.Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);

            using System.Drawing.SolidBrush brush = new SolidBrush(this.ForeColor);

            var textSize = g.MeasureString(this.Text, this.Font);
            var rectangle = new RectangleF(0, 0, textSize.Width, textSize.Height);
            float offsetX = 0;
            float offsetY = 0;

            if (!cesVertical)
            {
                offsetX = 0;
                offsetY = 0;
            }

            if (CesDegree == 90)
            {
                offsetX = 0;
                offsetY = -textSize.Height;
            }

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.RotateTransform(cesVertical ? cesDegree : 0);
            g.TranslateTransform(cesOffsetX, cesOffsetY);
            g.DrawString(this.Text, this.Font, brush, rectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Redraw();
        }
    }
}
