using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesGauge
{
    public partial class CesGauge : UserControl
    {
        public CesGauge()
        {
            InitializeComponent();
        }

        private Color cesBackgroundColor { get; set; } = Color.White;
        public Color CesBackgroundColor
        {
            get { return cesBackgroundColor; }
            set
            {
                cesBackgroundColor = value;
                this.Invalidate();
            }
        }

        private Color cesGaugeColor { get; set; } = Color.Black;
        public Color CesGaugeColor
        {
            get { return cesGaugeColor; }
            set
            {
                cesGaugeColor = value;
                this.Invalidate();
            }
        }

        private Color cesGaugeArcColor { get; set; } = Color.Gray;
        public Color CesGaugeArcColor
        {
            get { return cesGaugeArcColor; }
            set
            {
                cesGaugeArcColor = value;
                this.Invalidate();
            }
        }

        private Color cesSegmentLineColor { get; set; } = Color.Gray;
        public Color CesSegmentLineColor
        {
            get { return cesSegmentLineColor; }
            set
            {
                cesSegmentLineColor = value;
                this.Invalidate();
            }
        }

        private int cesSegmentLineLength { get; set; } = 5;
        public int CesSegmentLineLength
        {
            get { return cesSegmentLineLength; }
            set
            {
                cesSegmentLineLength = value;
                this.Invalidate();
            }
        }

        public bool cesShowSegmentLine { get; set; } = true;
        public bool CesShowSegmentLine
        {
            get { return cesShowSegmentLine; }
            set
            {
                cesShowSegmentLine = value;
                this.Invalidate();
            }
        }

        private float cesOuterOffest { get; set; } = 20;
        public float CesOuterOffest
        {
            get { return cesOuterOffest; }
            set
            {
                cesOuterOffest = value;
                this.Invalidate();
            }
        }

        private float cesInnerOffest { get; set; } = 10;
        public float CesInnerOffest
        {
            get { return cesInnerOffest; }
            set
            {
                cesInnerOffest = value;
                this.Invalidate();
            }
        }

        private float cesBigDiameter { get; set; } = 15;
        public float CesBigDiameter
        {
            get { return cesBigDiameter; }
            set
            {
                cesBigDiameter = value;
                this.Invalidate();
            }
        }

        private float cesSmallDiameter { get; set; } = 2;
        public float CesSmallDiameter
        {
            get { return cesSmallDiameter; }
            set
            {
                cesSmallDiameter = value;
                this.Invalidate();
            }
        }

        private float cesValue { get; set; } = 60;
        public float CesValue
        {
            get
            {
                if (!cesRangeMode)
                    return 100 - cesValue;
                else
                    return cesMaxValue - cesValue;
            }
            set
            {
                // بررسی مقدار برای حالت درصدی
                if (!cesRangeMode && value < 0)
                    cesValue = 100;

                if (!cesRangeMode && value > 100)
                    cesValue = 0;

                // برای آنکه عقربه راست گرد باشد باید اعداد وارون شوند
                if (!cesRangeMode && value >= 0 && value <= 100)
                    cesValue = 100 - value;

                // بررسی مقدار برای حالت رینج
                if (cesRangeMode && value < cesMinValue)
                    cesValue = cesMaxValue;

                if (cesRangeMode && value > cesMaxValue)
                    cesValue = 0;

                // برای آنکه عقربه راست گرد باشد باید اعداد وارون شوند
                if (cesRangeMode && value >= cesMinValue && value <= cesMaxValue)
                    cesValue = cesMaxValue - value;

                this.Invalidate();
            }
        }

        private IList<CesGaugeOptions>? cesGaugeSegments { get; set; } =
            new List<CesGaugeOptions>()
            {
                new CesGaugeOptions { Percent = 100, SegmentColor = Color.Gray}
            };
        [System.ComponentModel.Browsable(false)]
        public IList<CesGaugeOptions>? CesGaugeSegments
        {
            get { return cesGaugeSegments; }
            set
            {
                cesGaugeSegments = value;
                this.Invalidate();
            }
        }

        private bool cesRangeMode { get; set; }
        public bool CesRangeMode
        {
            get { return cesRangeMode; }
            set
            {
                cesRangeMode = value;
                this.Invalidate();
            }
        }

        private float cesMinValue { get; set; } = 0;
        public float CesMinValue
        {
            get { return cesMinValue; }
            set
            {
                cesMinValue = value;
                this.Invalidate();
            }
        }

        private float cesMaxValue { get; set; } = 10;
        public float CesMaxValue
        {
            get { return cesMaxValue; }
            set
            {
                cesMaxValue = value;
                this.Invalidate();
            }
        }

        private int cesSegmentNumber { get; set; } = 3;
        public int CesSegmentNumber
        {
            get { return cesSegmentNumber; }
            set
            {
                cesSegmentNumber = value;
                this.Invalidate();
            }
        }

        private bool cesShowSegmentNumber { get; set; } = true;
        public bool CesShowSegmentNumber
        {
            get { return cesShowSegmentNumber; }
            set
            {
                cesShowSegmentNumber = value;
                this.Invalidate();
            }
        }




        private float cesGaugeOffset { get; set; }
        private float cesBigRadius { get; set; }
        private float cesSmallRadius { get; set; }
        private float angle { get; set; }
        private float distance { get; set; }
        private PointF fixPoint { get; set; }
        private PointF rotatingPoint { get; set; }




        private void Draw()
        {
            using Graphics g = this.CreateGraphics();
            using GraphicsPath path = new GraphicsPath();
            using Pen penForSegmentLine = new Pen(Color.White, 2);
            using Brush brushForGauge = new SolidBrush(cesGaugeColor);
            using Brush brushForBackGround = new SolidBrush(cesBackgroundColor);
            using Brush brushForGaugeArc = new SolidBrush(cesGaugeArcColor);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            cesGaugeOffset = this.Height / 4; // این مقدار تقریبی است
            cesBigRadius = cesBigDiameter / 2;
            cesSmallRadius = cesSmallDiameter / 2;

            if (cesRangeMode)
                angle = cesValue * 180 / cesMaxValue;
            else
                angle = cesValue * 180 / 100;


            fixPoint = new PointF(this.Width / 2, (int)(this.Height) - cesBigRadius - 1);
            rotatingPoint = new PointF(this.Width / 2, cesSmallRadius + 1);
            distance = this.Height - cesBigRadius - cesSmallRadius - cesGaugeOffset;


            // رسم جزئیات گیج
            if (cesGaugeSegments == null || cesGaugeSegments.Count == 0)
                g.FillPie(
                    brushForGaugeArc,
                    new Rectangle(
                        (int)(fixPoint.X - distance - cesOuterOffest),
                        (int)(fixPoint.Y - distance - cesOuterOffest),
                        (int)((distance + cesOuterOffest) * 2),
                        (int)((distance + cesOuterOffest) * 2)),
                    180,
                    180);

            float previousDegree = 180;
            float currentDegree = 0;

            foreach (CesGaugeOptions item in cesGaugeSegments)
            {
                currentDegree = (item.Percent * 180) / 100;

                g.FillPie(
                    new SolidBrush(item.SegmentColor),
                    new Rectangle(
                        (int)(fixPoint.X - distance - cesOuterOffest),
                        (int)(fixPoint.Y - distance - cesOuterOffest),
                        (int)((distance + cesOuterOffest) * 2),
                        (int)((distance + cesOuterOffest) * 2)),
                    previousDegree,
                    currentDegree);

                previousDegree += currentDegree;

                // رسم خطوط مدرج
                var p1 = new PointF(
                    (float)((this.Width / 2) + Math.Cos(previousDegree * Math.PI / 180) * (distance - cesInnerOffest)),
                    (float)(this.Height - cesBigRadius - 1 - Math.Abs(Math.Sin(previousDegree * Math.PI / 180) * (distance - cesInnerOffest))));

                var p2 = new PointF(
                    (float)((this.Width / 2) + Math.Cos(previousDegree * Math.PI / 180) * (distance + cesOuterOffest)),
                    (float)(this.Height - cesBigRadius - 1 - Math.Abs(Math.Sin(previousDegree * Math.PI / 180) * (distance + cesOuterOffest))));

                g.DrawLine(penForSegmentLine, p1, p2);

            }

            g.FillPie(
                brushForBackGround,
                new Rectangle(
                    (int)(fixPoint.X - distance + cesInnerOffest),
                    (int)(fixPoint.Y - distance + cesInnerOffest),
                    (int)((distance - cesInnerOffest) * 2),
                    (int)((distance - cesInnerOffest) * 2)),
                180,
                180);

            g.DrawLine(
                new Pen(Color.White, 1),
                (int)(fixPoint.X - distance - cesOuterOffest),
                (int)(fixPoint.Y),
                (int)(fixPoint.X + distance + cesOuterOffest),
                (int)(fixPoint.Y));

            // رسم خطوط درجه بندی
            // در دامنه اعداد تعیین شده توسط کاربر باید دو واحد
            // کسر شود. چون خط اول در ابتدا و خط آخر در انتها رسم می شود
            // بنابراین در رسم خطوط وقتی تعداد باقیمانده بر 180 درجه تقسیم
            // بشود به غیر از ابتدا و انتها، ناحیه میانی تقسیم بندی شده و
            // خطوط رسم خواهند شد
            if (cesShowSegmentLine)
                for (int i = 0; i <= cesSegmentNumber + 1; i++)
                {
                    int seg = 180 / cesSegmentNumber * i;
                    var deg = seg * Math.PI / 180;

                    // رسم خطوط مدرج
                    var p1 = new PointF(
                        (float)((this.Width / 2) + Math.Cos(deg) * (distance - cesInnerOffest - 5)),
                        (float)(this.Height - cesBigRadius - 1 - Math.Abs(Math.Sin(deg) * (distance - cesInnerOffest - 5))));

                    var p2 = new PointF(
                        (float)((this.Width / 2) + Math.Cos(deg) * (distance - cesInnerOffest - 5 - cesSegmentLineLength)),
                        (float)(this.Height - cesBigRadius - 1 - Math.Abs(Math.Sin(deg) * (distance - cesInnerOffest - 5 - cesSegmentLineLength))));

                    g.DrawLine(new Pen(cesSegmentLineColor, 1), p1, p2);
                }


            // رسم مقدار حداقل و حداکثر
            if (cesRangeMode)
            {
                var minSize = g.MeasureString(cesMinValue.ToString(), this.Font);
                g.DrawString(
                    "Min. " + cesMinValue.ToString(),
                    this.Font,
                    new SolidBrush(Color.Blue),
                    new PointF(
                        fixPoint.X - distance + cesInnerOffest,
                        fixPoint.Y - (minSize.Height / 1)));

                var maxSize = g.MeasureString("Max. " + cesMaxValue.ToString(), this.Font);
                g.DrawString(
                    "Max. " + cesMaxValue.ToString(),
                    this.Font,
                    new SolidBrush(Color.Blue),
                    new PointF(
                        fixPoint.X + distance - cesInnerOffest - maxSize.Width,
                        fixPoint.Y - (maxSize.Height / 1)));
            }

            path.AddArc(
                new RectangleF(
                    new PointF(fixPoint.X - cesBigRadius, fixPoint.Y - cesBigRadius),
                    new SizeF(cesBigDiameter, cesBigDiameter)),
                90 - angle,
                180);

            // رسم دایره چرخان - سر عقربه
            rotatingPoint = new PointF(
                (float)((this.Width / 2) + Math.Cos(angle * Math.PI / 180) * distance),
                (float)(this.Height - cesBigRadius - 1 - Math.Abs(Math.Sin(angle * Math.PI / 180) * distance)));

            path.AddArc(
                new RectangleF(
                    new PointF(rotatingPoint.X - cesSmallRadius, rotatingPoint.Y - cesSmallRadius),
                    new SizeF(cesSmallDiameter, cesSmallDiameter)),
                270 - angle,
                180);

            path.CloseFigure();
            g.FillPath(brushForGauge, path);



        }

        private void CesGauge_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

    }
}
