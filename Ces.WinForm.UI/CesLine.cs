namespace Ces.WinForm.UI
{
    public partial class CesLine : UserControl
    {
        public CesLine()
        {
            InitializeComponent();
        }


        private Color cesBackColor;
        [System.ComponentModel.Category("CesLine")]
        public Color CesBackColor
        {
            get
            {
                return cesBackColor;
            }
            set
            {
                cesBackColor = value;
                Redraw();
            }
        }


        private Color cesLineColor = Color.Black;
        [System.ComponentModel.Category("CesLine")]
        public Color CesLineColor
        {
            get
            {
                return cesLineColor;
            }
            set
            {
                cesLineColor = value;
                Redraw();
            }
        }


        private float cesLineWidth = 1;
        [System.ComponentModel.Category("CesLine")]
        public float CesLineWidth
        {
            get
            {
                return cesLineWidth;
            }
            set
            {
                cesLineWidth = value;
                Redraw();
            }
        }


        private bool cesVertical = false;
        [System.ComponentModel.Category("CesLine")]
        public bool CesVertical
        {
            get
            {
                return cesVertical;
            }
            set
            {
                cesVertical = value;
                Redraw();
            }
        }


        private System.Drawing.Drawing2D.DashStyle cesLineType = 
            System.Drawing.Drawing2D.DashStyle.Solid;
        [System.ComponentModel.Category("CesLine")]
        public System.Drawing.Drawing2D.DashStyle CesLineType
        {
            get
            {
                return cesLineType;
            }
            set
            {
                cesLineType = value;
                Redraw();
            }
        }



        // Methods


        private void CesHorizontalLine_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        private void Redraw()
        {
            using Graphics g = this.CreateGraphics();
            using Brush brush = new SolidBrush(cesLineColor);
            using Pen pen = new Pen(brush, cesLineWidth);

            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            pen.DashStyle = cesLineType;

            int startX = 0;
            int startY = 0;
            int endX = 0;
            int endY = 0;

            if (cesVertical)
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
           
            g.DrawLine(pen, startX, startY, endX, endY);
        }
    }
}
