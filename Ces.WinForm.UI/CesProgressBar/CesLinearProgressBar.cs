using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesProgressBar
{
    public partial class CesLinearProgressBar : UserControl
    {
        public CesLinearProgressBar()
        {
            InitializeComponent();
        }

        private double cesProgressValue;
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
        public double CesProgressValue
        {
            get { return cesProgressValue; }
            set
            {
                cesProgressValue = value;
            }
        }

        private double cesTotalValue = 100;
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
        public double CesTotalValue
        {
            get { return cesTotalValue; }
            set
            {
                cesTotalValue = value;
                CesProgressValue = (CesCurrentValue / CesTotalValue) * 100;
                this.Invalidate();
            }
        }

        private double cesCurrentValue = 60;
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
        public double CesCurrentValue
        {
            get { return cesCurrentValue; }
            set
            {
                cesCurrentValue = value;
                CesProgressValue = (CesCurrentValue / CesTotalValue) * 100;
                this.Invalidate();
            }
        }

        private Color cesBackColor = Color.White;
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
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
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
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
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
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
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
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
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
        public CesProgressLocationEnum CesProgressLocation
        {
            get { return cesProgressLocation; }
            set
            {
                cesProgressLocation = value;
                this.Invalidate();
            }
        }


        private void Redraw()
        {
            using Graphics g = this.CreateGraphics();
            using SolidBrush sb = new SolidBrush(CesBarColor);
            using Pen p = new Pen(CesBarColor, 1);

            g.Clear(CesBackColor);

            // رسم حاشیه
            g.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));

            // محاسبه درصد
            var progress = CesCurrentValue / cesTotalValue;

            // درصد نبایداز 1 بیشتر باشد چون مستطیل ازکادر خارج خواهد شد
            if (progress > 1)
                progress = 1;

            // محاسبه پهنای مستطیل برحسب درصد بدست آمده
            // این مستطیل نیز باید به همان نسبت در گرافیک رسم شود
            var rectWidth = this.Width * progress;
            var rect = new RectangleF(2, 2, (float)rectWidth - 4, this.Height - 4);

            g.FillRectangle(sb, rect);

            if (CesShowProgress)
            {
                string text = $"% {CesProgressValue.ToString("N" + CesProgressPrecision.ToString())}";
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

        private void CesLinearProgressBar_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }
    }

    public enum CesProgressLocationEnum
    {
        left,
        Center,
        Right,
    }
}
