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
    public partial class CesLabel : UserControl
    {
        public CesLabel()
        {
            InitializeComponent();
        }


        private CesLabelRotationDegreeEnum cesDegree { get; set; }
            = CesLabelRotationDegreeEnum.Rotate0;
        [System.ComponentModel.Category("CesLabel")]
        [System.ComponentModel.Description("CesLabel can show string value in vertical direction.")]
        public CesLabelRotationDegreeEnum CesDegree
        {
            get { return cesDegree; }
            set
            {
                cesDegree = value;
                Redraw();
            }
        }


        private System.Drawing.ContentAlignment cesTextAlignment { get; set; }
            = ContentAlignment.TopLeft;
        [System.ComponentModel.Category("CesLabel")]
        public System.Drawing.ContentAlignment CesTextAlignment
        {
            get { return cesTextAlignment; }
            set
            {
                cesTextAlignment = value;
                Redraw();
            }
        }


        public bool cesAutoSize { get; set; }
        [System.ComponentModel.Category("CesLabel")]
        public bool CesAutoSize
        {
            get { return cesAutoSize; }
            set
            {
                cesAutoSize = value;

                if (value)
                    this.AutoSize = false;

                Redraw();
            }
        }


        private void Redraw()
        {
            System.Drawing.Graphics g = this.CreateGraphics();
            using System.Drawing.SolidBrush brush = new SolidBrush(this.ForeColor);
            var textSize = g.MeasureString(this.Text, this.Font);
            var rectangle = new RectangleF(0, 0, textSize.Width, textSize.Height);
            float offsetX = 0;
            float offsetY = 0;


            if (cesDegree == CesLabelRotationDegreeEnum.Rotate0)
            {
                switch (cesTextAlignment)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = 0;
                        offsetY = 0;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = 0;
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = 0;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = 0;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = 0;
                        offsetY = this.Height - textSize.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = this.Height - textSize.Height;
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = this.Height - textSize.Height;
                        break;
                }
            }

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate90)
            {
                //switch (this.TextAlign)
                //{
                //    case ContentAlignment.TopLeft:
                //        offsetX = 0;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.TopCenter:
                //        offsetX = 0;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.TopRight:
                //        offsetX = 0;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.MiddleLeft:
                //        offsetX = 0;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.MiddleCenter:
                //        offsetX = 0;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.MiddleRight:
                //        offsetX = 0;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.BottomLeft:
                //        offsetX = 0;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.BottomCenter:
                //        offsetX = 0;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.BottomRight:
                //        offsetX = 0;
                //        offsetY = -textSize.Height;
                //        break;
                //}
                switch (cesTextAlignment)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = 0;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = 0;
                        offsetY = -((this.Width / 2 - textSize.Width / 2) + textSize.Height);
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = this.Height / 2 - textSize.Height / 2;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = (this.Height / 2 - textSize.Height / 2) - textSize.Height;
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = (this.Height / 2 - textSize.Height / 2) - textSize.Height;
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = 0;
                        offsetY = (this.Height - textSize.Height) - textSize.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = (this.Height - textSize.Height) - textSize.Height;
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = (this.Height - textSize.Height) - textSize.Height;
                        break;
                }
            }

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate180)
            {
                //switch (this.TextAlign)
                //{
                //    case ContentAlignment.TopLeft:
                //        offsetX = -textSize.Width;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.TopCenter:
                //        offsetX = -textSize.Width;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.TopRight:
                //        offsetX = -textSize.Width;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.MiddleLeft:
                //        offsetX = -textSize.Width;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.MiddleCenter:
                //        offsetX = -textSize.Width;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.MiddleRight:
                //        offsetX = -textSize.Width;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.BottomLeft:
                //        offsetX = -textSize.Width;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.BottomCenter:
                //        offsetX = -textSize.Width;
                //        offsetY = -textSize.Height;
                //        break;
                //    case ContentAlignment.BottomRight:
                //        offsetX = -textSize.Width;
                //        offsetY = -textSize.Height;
                //        break;
                //}

                switch (cesTextAlignment)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = -textSize.Width;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = -(this.Width / 2 - textSize.Width / 2) - textSize.Width;
                        offsetY = 0;
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = this.Width - textSize.Width - textSize.Width;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = -textSize.Height;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = 0;
                        offsetY = this.Height - textSize.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = this.Height - textSize.Height;
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = this.Height - textSize.Height;
                        break;
                }
            }

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate270)
            {
                //switch (this.TextAlign)
                //{
                //    case ContentAlignment.TopLeft:
                //        offsetX = -textSize.Width;
                //        offsetY = 0;
                //        break;
                //    case ContentAlignment.TopCenter:
                //        offsetX = -textSize.Width;
                //        offsetY = 0;
                //        break;
                //    case ContentAlignment.TopRight:
                //        offsetX = -textSize.Width;
                //        offsetY = 0;
                //        break;
                //    case ContentAlignment.MiddleLeft:
                //        offsetX = -textSize.Width;
                //        offsetY = 0;
                //        break;
                //    case ContentAlignment.MiddleCenter:
                //        offsetX = -textSize.Width;
                //        offsetY = 0;
                //        break;
                //    case ContentAlignment.MiddleRight:
                //        offsetX = -textSize.Width;
                //        offsetY = 0;
                //        break;
                //    case ContentAlignment.BottomLeft:
                //        offsetX = -textSize.Width;
                //        offsetY = 0;
                //        break;
                //    case ContentAlignment.BottomCenter:
                //        offsetX = -textSize.Width;
                //        offsetY = 0;
                //        break;
                //    case ContentAlignment.BottomRight:
                //        offsetX = -textSize.Width;
                //        offsetY = 0;
                //        break;
                //}
                switch (cesTextAlignment)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = 0;
                        offsetY = 0;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = 0;
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = 0;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = 0;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = this.Height / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = 0;
                        offsetY = this.Height - textSize.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = this.Width / 2 - textSize.Width / 2;
                        offsetY = this.Height - textSize.Height;
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = this.Width - textSize.Width;
                        offsetY = this.Height - textSize.Height;
                        break;
                }
            }

            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.RotateTransform((float)cesDegree);
            g.TranslateTransform(offsetX, offsetY);
            g.DrawString(this.Text, this.Font, brush, rectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Redraw();
        }
    }

    public enum CesLabelRotationDegreeEnum
    {
        Rotate0 = 0,
        Rotate90 = 90,
        Rotate180 = 180,
        Rotate270 = 270,
    }
}
