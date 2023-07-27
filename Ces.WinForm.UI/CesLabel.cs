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


        public CesLabelDegreeEnum cesDegree { get; set; }
        [System.ComponentModel.Category("CesLabel")]
        public CesLabelDegreeEnum CesDegree
        {
            get { return cesDegree; }
            set
            {
                cesDegree = value;
                Redraw();
            }
        }


        private void Redraw()
        {
            using System.Drawing.Graphics g = this.CreateGraphics();           
            using System.Drawing.SolidBrush brush = new SolidBrush(this.ForeColor);
            var textSize = g.MeasureString(this.Text, this.Font);
            var rectangle = new RectangleF(0, 0, textSize.Width, textSize.Height);
            float offsetX = 0;
            float offsetY = 0;

            if (!cesVertical)
                cesDegree = CesLabelDegreeEnum.Rotate0;

            if (cesDegree == CesLabelDegreeEnum.Rotate0)
            {
                offsetX = 0;
                offsetY = 0;
            }

            if (cesDegree == CesLabelDegreeEnum.Rotate90)
            {
                offsetX = 0;
                offsetY = -textSize.Height;
            }

            if (cesDegree == CesLabelDegreeEnum.Rotate180)
            {
                offsetX = -textSize.Width;
                offsetY = -textSize.Height;
            }

            if (cesDegree == CesLabelDegreeEnum.Rotate270)
            {
                offsetX = -textSize.Width;
                offsetY = 0;
            }

            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.RotateTransform((float)(cesVertical ? cesDegree : 0));
            g.TranslateTransform(offsetX, offsetY);
            g.DrawString(this.Text, this.Font, brush, rectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Redraw();
        }
    }

    public enum CesLabelDegreeEnum
    {
        Rotate0 = 0,
        Rotate90 = 90,
        Rotate180 = 180,
        Rotate270 = 270,
    }

}
