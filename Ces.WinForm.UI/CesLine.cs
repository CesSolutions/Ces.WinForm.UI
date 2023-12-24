namespace Ces.WinForm.UI
{
    public partial class CesLine : UserControl
    {
        public CesLine()
        {
            InitializeComponent();
        }


        private Color cesBackColor;
        [System.ComponentModel.Category("Ces Line")]
        public Color CesBackColor
        {
            get
            {
                return cesBackColor;
            }
            set
            {
                cesBackColor = value;
                this.Invalidate();
            }
        }


        private Color cesLineColor = Color.Black;
        [System.ComponentModel.Category("Ces Line")]
        public Color CesLineColor
        {
            get
            {
                return cesLineColor;
            }
            set
            {
                cesLineColor = value;
                this.Invalidate();
            }
        }


        private float cesLineWidth = 1;
        [System.ComponentModel.Category("Ces Line")]
        public float CesLineWidth
        {
            get
            {
                return cesLineWidth;
            }
            set
            {
                cesLineWidth = value;
                this.Invalidate();
            }
        }


        private bool cesVertical = false;
        [System.ComponentModel.Category("Ces Line")]
        public bool CesVertical
        {
            get
            {
                return cesVertical;
            }
            set
            {
                cesVertical = value;

                if (value)
                {
                    this.Width = this.Height;
                    this.Height = this.Width * 10;
                }
                else
                {
                    this.Height = this.Width;
                    this.Width = this.Height * 10;
                }

                this.Invalidate();
            }
        }


        private bool cesAutoStick { get; set; } = false;
        [System.ComponentModel.Category("Ces Line")]
        public bool CesAutoStick
        {
            get { return cesAutoStick; }
            set
            {
                cesAutoStick = value;
                this.Invalidate();
            }
        }


        private System.Drawing.Drawing2D.DashStyle cesLineType =
            System.Drawing.Drawing2D.DashStyle.Solid;
        [System.ComponentModel.Category("Ces Line")]
        public System.Drawing.Drawing2D.DashStyle CesLineType
        {
            get
            {
                return cesLineType;
            }
            set
            {
                cesLineType = value;
                this.Invalidate();
            }
        }


        private bool cesRoundedTip { get; set; } = true;
        [System.ComponentModel.Category("Ces Line")]
        public bool CesRoundedTip
        {
            get { return cesRoundedTip; }
            set
            {
                cesRoundedTip = value;
                this.Invalidate();
            }
        }

        private int cesAutoStickOffset { get; set; } = 3;
        [System.ComponentModel.Category("Ces Line")]
        public int CesAutoStickOffset
        {
            get { return cesAutoStickOffset; }
            set
            {
                cesAutoStickOffset = value;
                this.Invalidate();
            }
        }


        // Methods


        private void CesLine_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        private void ControlAutoStick()
        {
            if (CesAutoStick && this.Parent is not null)
            {
                if (CesVertical)
                {
                    this.Height = this.Parent.ClientRectangle.Height - (CesAutoStickOffset * 2);
                    this.Top = CesAutoStickOffset;
                }
                else
                {
                    this.Width = this.Parent.ClientRectangle.Width - (CesAutoStickOffset * 2);
                    this.Left = CesAutoStickOffset;
                }
            }
        }

        private void Redraw()
        {
            ControlAutoStick();

            using Graphics g = this.CreateGraphics();
            using Brush brush = new SolidBrush(CesLineColor);
            using Pen pen = new Pen(brush, cesLineWidth);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(this.BackColor);

            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            pen.DashStyle = CesLineType;

            float startX = 0;
            float startY = 0;
            float endX = 0;
            float endY = 0;

            if (CesVertical)
            {
                startX = (int)(this.Width / 2);
                startY = 0;
                endX = startX;
                endY = this.Height;
            }
            else
            {
                startX = 0;
                startY = (int)(this.Height / 2);
                endX = (int)(this.Width);
                endY = startY;
            }


            if (CesRoundedTip)
            {
                g.FillEllipse(
                    new SolidBrush(CesLineColor),
                    new RectangleF(
                        startX + (CesVertical ? -(CesLineWidth / 2) : 1),
                        startY - (CesVertical ? 0 : (CesLineWidth / 2)),
                        CesLineWidth,
                        CesLineWidth));

                g.FillEllipse(
                    new SolidBrush(CesLineColor),
                    new RectangleF(
                        endX - (CesVertical ? (CesLineWidth / 2) : CesLineWidth + 1),
                        endY - (CesVertical ? (CesLineWidth + 1) : (CesLineWidth / 2)),
                        CesLineWidth,
                        CesLineWidth));
            }

            // رسم خط
            if (CesRoundedTip)
                if (CesVertical)
                    g.DrawLine(
                        pen,
                        startX,
                        startY + (CesLineWidth / 2) + 1,
                        endX,
                        endY - (CesLineWidth / 2) - 1);
                else
                    g.DrawLine(
                        pen,
                        startX + (CesLineWidth / 2) + 1,
                        startY,
                        endX - (CesLineWidth / 2) - 1,
                        endY);
            else
                g.DrawLine(pen, startX, startY, endX, endY);
        }

        public override DockStyle Dock 
        {
            get {return  base.Dock; }
            set 
            { 
                base.Dock = value;

                if (value != DockStyle.None)
                    CesAutoStick = false;
            }
        }
    }
}
