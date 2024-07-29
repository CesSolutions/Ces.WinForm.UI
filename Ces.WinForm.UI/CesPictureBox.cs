namespace Ces.WinForm.UI
{
    public partial class CesPictureBox : UserControl
    {
        public CesPictureBox()
        {
            InitializeComponent();
        }


        private Image cesImage { get; set; }
        [System.ComponentModel.Category("Ces PictureBox")]
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
        [System.ComponentModel.Category("Ces PictureBox")]
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
        [System.ComponentModel.Category("Ces PictureBox")]
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
        [System.ComponentModel.Category("Ces PictureBox")]
        public bool CesShowBorder
        {
            get { return cesShowBorder; }
            set
            {
                cesShowBorder = value;
                this.Invalidate();
            }
        }

        private System.Drawing.Drawing2D.DashStyle cesBorderType { get; set; }
            = System.Drawing.Drawing2D.DashStyle.Solid;
        [System.ComponentModel.Category("Ces PictureBox")]
        public System.Drawing.Drawing2D.DashStyle CesBorderType
        {
            get { return cesBorderType; }
            set
            {
                cesBorderType = value;
                this.Invalidate();
            }
        }

        private void CesPictureBox_Paint(object sender, PaintEventArgs e)
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
            {
                using Pen borderPen = new Pen(CesBorderColor, CesBorderThickness);
                borderPen.DashStyle = CesBorderType;
                g.DrawEllipse(borderPen, rect);
            }
        }

        private void CesPictureBox_Resize(object sender, EventArgs e)
        {
            this.Width = this.Height;
        }
    }
}
