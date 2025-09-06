using System.ComponentModel;

namespace Ces.WinForm.UI.CesProgressBar
{
    public partial class CesLinearProgressBar : UserControl
    {
        public CesLinearProgressBar()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            cesProgressValue = (CesValue / CesMaxValue) * 100;
        }

        private double cesProgressValue;
        [Browsable(false)]
        [System.ComponentModel.Category("CesProgressBar")]
        public double CesProgressValue
        {
            get { return cesProgressValue; }
            set
            {
                cesProgressValue = value;
            }
        }

        private double cesMaxValue = 100;
        [System.ComponentModel.Category("CesProgressBar")]
        public double CesMaxValue
        {
            get { return cesMaxValue; }
            set
            {
                cesMaxValue = value;
                CesProgressValue = (CesValue / CesMaxValue) * 100;
                this.Invalidate();
            }
        }

        private double cesValue = 60;
        [System.ComponentModel.Category("CesProgressBar")]
        public double CesValue
        {
            get { return cesValue; }
            set
            {
                if (value > CesMaxValue)
                    value = CesMaxValue;

                if (value < 0)
                    value = 0;

                cesValue = value;
                CesProgressValue = (CesValue / CesMaxValue) * 100;
                this.Invalidate();
            }
        }

        private Color cesBackColor = Color.White;
        [System.ComponentModel.Category("CesProgressBar")]
        public Color CesBackColor
        {
            get { return cesBackColor; }
            set
            {
                cesBackColor = value;
                this.Invalidate();
            }
        }

        private Color cesBarColor = Color.Coral;
        [System.ComponentModel.Category("CesProgressBar")]
        public Color CesBarColor
        {
            get { return cesBarColor; }
            set
            {
                cesBarColor = value;
                this.Invalidate();
            }
        }

        private float cesProgressPrecision = 1;
        [System.ComponentModel.Category("CesProgressBar")]
        public float CesProgressPrecision
        {
            get { return cesProgressPrecision; }
            set
            {
                cesProgressPrecision = value;
                this.Invalidate();
            }
        }

        private bool cesShowProgress = true;
        [System.ComponentModel.Category("CesProgressBar")]
        public bool CesShowProgress
        {
            get { return cesShowProgress; }
            set
            {
                cesShowProgress = value;
                this.Invalidate();
            }
        }

        private CesProgressLocationEnum cesProgressLocation = CesProgressLocationEnum.Center;
        [System.ComponentModel.Category("CesProgressBar")]
        public CesProgressLocationEnum CesProgressLocation
        {
            get { return cesProgressLocation; }
            set
            {
                cesProgressLocation = value;
                this.Invalidate();
            }
        }

        private void Redraw(Graphics g)
        {
            using SolidBrush solidBrush = new SolidBrush(CesBarColor);
            using Pen pen = new Pen(CesBarColor, 1);
            {
                g.Clear(CesBackColor);

                //رسم حاشیه
                g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));

                // محاسبه درصد
                var progress = CesValue / cesMaxValue;

                // درصد نبایداز 1 بیشتر باشد چون مستطیل ازکادر خارج خواهد شد
                if (progress > 1)
                    progress = 1;

                // محاسبه پهنای مستطیل برحسب درصد بدست آمده
                // این مستطیل نیز باید به همان نسبت در گرافیک رسم شود
                var rectWidth = this.Width * progress;
                var rect = new RectangleF(2, 2, (float)rectWidth - 4, this.Height - 4);

                g.FillRectangle(solidBrush, rect);

                if (CesShowProgress)
                {
                    string text = $"{CesProgressValue.ToString("N" + CesProgressPrecision.ToString())} %";
                    var textSize = g.MeasureString(text, this.Font);
                    var textRect = new Rectangle();

                    if (CesProgressLocation == CesProgressLocationEnum.left)
                        textRect = new Rectangle(5, (int)(this.Height / 2 - textSize.Height / 2), (int)textSize.Width + 5, (int)textSize.Height);

                    if (CesProgressLocation == CesProgressLocationEnum.Center)
                        textRect = new Rectangle((int)(this.Width / 2 - textSize.Width / 2), (int)(this.Height / 2 - textSize.Height / 2), (int)textSize.Width + 5, (int)textSize.Height);

                    if (CesProgressLocation == CesProgressLocationEnum.Right)
                        textRect = new Rectangle((int)(this.Width - textSize.Width - 5), (int)(this.Height / 2 - textSize.Height / 2), (int)textSize.Width + 5, (int)textSize.Height);

                    g.DrawString(text, this.Font, new SolidBrush(this.ForeColor), textRect);
                }
            }
        }

        private void CesLinearProgressBar_Paint(object sender, PaintEventArgs e)
        {
            Redraw(e.Graphics);
        }
    }

    public enum CesProgressLocationEnum
    {
        left,
        Center,
        Right,
    }
}
