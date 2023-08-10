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
    public partial class CesCircularProgressBar : UserControl
    {
        public CesCircularProgressBar()
        {
            InitializeComponent();
            cesProgressValue = (CesCurrentValue / CesTotalValue) * 100;
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

        private int cesBarThickness = 8;
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
        public int CesBarThickness
        {
            get { return cesBarThickness; }
            set
            {
                cesBarThickness = value;
                this.Invalidate();
            }
        }

        private Color cesBarUnfilledColor = Color.LightGray;
        [System.ComponentModel.Category("Ces Linear Progress Bar")]
        public Color CesBarUnfilledColor
        {
            get { return cesBarUnfilledColor; }
            set
            {
                cesBarUnfilledColor = value;
                this.Invalidate();
            }
        }


        private void Redraw()
        {
            using Graphics g = this.CreateGraphics();
            using SolidBrush sbBackground = new SolidBrush(CesBackColor);
            using Pen pOutline = new Pen(CesBarUnfilledColor, CesBarThickness);
            using Pen pProgress = new Pen(CesBarColor, CesBarThickness);

            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // محاسبه درصد
            var progress = CesCurrentValue / cesTotalValue;

            // درصد نبایداز 1 بیشتر باشد چون مستطیل ازکادر خارج خواهد شد
            if (progress > 1)
                progress = 1;

            var rect = new Rectangle(
                CesBarThickness / 2,
                CesBarThickness / 2,
                this.Width - CesBarThickness - 1,
                this.Height - CesBarThickness - 1);

            g.FillEllipse(sbBackground, rect);
            g.DrawEllipse(pOutline, rect);
            g.DrawArc(pProgress, rect, 270, (float)(360 * progress));
            
            if (CesShowProgress)
            {
                string text = $"{CesProgressValue.ToString("N" + CesProgressPrecision.ToString())} %";
                var textSize = g.MeasureString(text, this.Font);
                var textRect = new Rectangle(
                    (int)(this.Width / 2 - textSize.Width / 2),
                    (int)(this.Height / 2 - textSize.Height / 2),
                    (int)textSize.Width + 5,
                    (int)textSize.Height);

                g.DrawString(text, this.Font, new SolidBrush(this.ForeColor), textRect);
            }
        }

        private void CesCircularProgressBar_Resize(object sender, EventArgs e)
        {
            this.Width = this.Height;
        }

        private void CesCircularProgressBar_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }
    }
}
