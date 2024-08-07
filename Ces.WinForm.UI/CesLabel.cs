﻿namespace Ces.WinForm.UI
{
    public partial class CesLabel : Label
    {
        public CesLabel()
        {
            InitializeComponent();
            this.Margin = new Padding(all: 3);
        }


        private CesLabelRotationDegreeEnum cesDegree { get; set; }
            = CesLabelRotationDegreeEnum.Rotate0;
        [System.ComponentModel.Category("Ces Label")]
        [System.ComponentModel.Description("CesLabel can show string value in vertical direction.")]
        public CesLabelRotationDegreeEnum CesDegree
        {
            get { return cesDegree; }
            set
            {
                cesDegree = value;
                this.Invalidate();
            }
        }


        private bool cesShowUnderLine { get; set; }
        [System.ComponentModel.Category("Ces Label")]
        public bool CesShowUnderLine
        {
            get { return cesShowUnderLine; }
            set
            {
                cesShowUnderLine = value;
                this.Invalidate();
            }
        }


        private System.Drawing.Drawing2D.DashStyle cesUnderlineType { get; set; }
            = System.Drawing.Drawing2D.DashStyle.Solid;
        [System.ComponentModel.Category("Ces Label")]
        public System.Drawing.Drawing2D.DashStyle CesUnderlineType
        {
            get { return cesUnderlineType; }
            set
            {
                cesUnderlineType = value;
                this.Invalidate();
            }
        }


        private int cesUnderlineThickness { get; set; } = 1;
        [System.ComponentModel.Category("Ces Label")]
        public int CesUnderlineThickness
        {
            get { return cesUnderlineThickness; }
            set
            {
                cesUnderlineThickness = value;
                this.Invalidate();
            }
        }


        private Color cesUnderlineColor { get; set; } = Color.Black;
        [System.ComponentModel.Category("Ces Label")]
        public Color CesUnderlineColor
        {
            get { return cesUnderlineColor; }
            set
            {
                cesUnderlineColor = value;
                this.Invalidate();
            }
        }


        // Methods


        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            using System.Drawing.SolidBrush brush = new SolidBrush(this.ForeColor);
            var textSize = g.MeasureString(this.Text, this.Font);
            var rectangle = new RectangleF(0, 0, textSize.Width, textSize.Height);
            float offsetX = 0;
            float offsetY = 0;

            // Set X,Y Offset for TranslateTransform

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate0)
            {
                switch (this.TextAlign)
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
                switch (this.TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = 0;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = 0;
                        offsetY = -(this.Width / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = 0;
                        offsetY = -this.Width;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = this.Height / 2 - textSize.Width / 2;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = this.Height / 2 - textSize.Width / 2;
                        offsetY = -(this.Width / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = this.Height / 2 - textSize.Width / 2;
                        offsetY = -this.Width;
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = this.Height - textSize.Width;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = this.Height - textSize.Width;
                        offsetY = -(this.Width / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = this.Height - textSize.Width;
                        offsetY = -this.Width;
                        break;
                }
            }

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate180)
            {
                switch (this.TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = -textSize.Width;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = -(this.Width / 2 + textSize.Width / 2);
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = -this.Width;
                        offsetY = -textSize.Height;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = -textSize.Width;
                        offsetY = -(this.Height / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = -(this.Width / 2 + textSize.Width / 2);
                        offsetY = -(this.Height / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = -this.Width;
                        offsetY = -(this.Height / 2 + textSize.Height / 2);
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = -textSize.Width;
                        offsetY = -this.Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = -(this.Width / 2 + textSize.Width / 2);
                        offsetY = -this.Height;
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = -this.Width;
                        offsetY = -this.Height;
                        break;
                }
            }

            if (cesDegree == CesLabelRotationDegreeEnum.Rotate270)
            {
                switch (this.TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        offsetX = -textSize.Height;
                        offsetY = 0;
                        break;
                    case ContentAlignment.TopCenter:
                        offsetX = -textSize.Height;
                        offsetY = this.Width / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.TopRight:
                        offsetX = -textSize.Width;
                        offsetY = this.Width - textSize.Width;
                        break;
                    case ContentAlignment.MiddleLeft:
                        offsetX = -(this.Height / 2 + textSize.Width / 2);
                        offsetY = 0;
                        break;
                    case ContentAlignment.MiddleCenter:
                        offsetX = -(this.Height / 2 + textSize.Width / 2);
                        offsetY = this.Width / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.MiddleRight:
                        offsetX = -(this.Height / 2 + textSize.Width / 2);
                        offsetY = this.Width - textSize.Width;
                        break;
                    case ContentAlignment.BottomLeft:
                        offsetX = -this.Height;
                        offsetY = 0;
                        break;
                    case ContentAlignment.BottomCenter:
                        offsetX = -this.Height;
                        offsetY = this.Width / 2 - textSize.Height / 2;
                        break;
                    case ContentAlignment.BottomRight:
                        offsetX = -this.Height;
                        offsetY = this.Width - textSize.Height;
                        break;
                }
            }

            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.RotateTransform((float)cesDegree);
            g.TranslateTransform(offsetX, offsetY);
            g.DrawString(this.Text, this.Font, brush, rectangle);


            // Show Underlie

            if (cesShowUnderLine)
            {
                using Pen pUndeline = new Pen(cesUnderlineColor, cesUnderlineThickness);
                pUndeline.DashStyle = cesUnderlineType;
                g.DrawLine(
                    pUndeline,
                    0,
                    textSize.Height,
                    textSize.Width,
                    textSize.Height);
            }
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