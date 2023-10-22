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

        [System.ComponentModel.Browsable(false)]
        private IList<CesGaugeRecord>? CesGaugeRcordList { get; set; } = new List<CesGaugeRecord>();

        // متد خصوصی برای ثبت تغییرات مقدار گیج
        private void CesRecord()
        {
            if (!CesGaugeRecord)
                return;

            if (CesGaugeRcordList == null)
                CesGaugeRcordList = new List<CesGaugeRecord>();

            CesGaugeRcordList.Add(
                new CesGaugeRecord
                {
                    RecordDateTime = DateTime.Now,
                    RecordValue = CesValue
                });
        }

        // متدی که کاربر می تواند لیست مقادیر ثبت شده را از کنترل دریافت کند
        public IList<CesGaugeRecord>? CesGetRecordList()
        {
            return CesGaugeRcordList;
        }

        // متد عمومی جهت دسترسی کاربر برای حذف داده های ثبت شده
        public void CesClearRecordList()
        {
            CesGaugeRcordList?.Clear();
        }

        // فعال کردن امکان ثبت تغییرات مقدار گیج
        private bool cesGaugeRecord { get; set; }
        [System.ComponentModel.Category("Ces Gauge")]
        public bool CesGaugeRecord
        {
            get { return cesGaugeRecord; }
            set
            {
                cesGaugeRecord = value;
            }
        }

        private IList<CesGaugeOptions>? cesGaugeSegments { get; set; } =
             new List<CesGaugeOptions>()
             {
                new Ces.WinForm.UI.CesGauge.CesGaugeOptions{Percent = 15,SegmentColor = Color.PaleGreen},
                new Ces.WinForm.UI.CesGauge.CesGaugeOptions{Percent = 35,SegmentColor = Color.Khaki},
                new Ces.WinForm.UI.CesGauge.CesGaugeOptions{Percent = 50,SegmentColor = Color.LightBlue},
             };
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("Ces Gauge")]
        public IList<CesGaugeOptions>? CesGaugeSegments
        {
            get { return cesGaugeSegments; }
            set
            {
                cesGaugeSegments = value;
                Draw();
            }
        }

        // رنگ پس زمینه
        private Color cesBackgroundColor { get; set; } = Color.White;
        [System.ComponentModel.Category("Ces Gauge")]
        public Color CesBackgroundColor
        {
            get { return cesBackgroundColor; }
            set
            {
                cesBackgroundColor = value;
                Draw();
            }
        }

        private CesGaugeIndicatorTypeEnum cesIndicatorType { get; set; } = CesGaugeIndicatorTypeEnum.Type1;
        [System.ComponentModel.Category("Ces Gauge")]
        public CesGaugeIndicatorTypeEnum CesIndicatorType
        {
            get { return cesIndicatorType; }
            set
            {
                cesIndicatorType = value;
                Draw();
            }
        }

        // رنگ عقربه
        private Color cesIndicatorColor { get; set; } = Color.Green;
        [System.ComponentModel.Category("Ces Gauge")]
        public Color CesIndicatorColor
        {
            get { return cesIndicatorColor; }
            set
            {
                cesIndicatorColor = value;
                Draw();
            }
        }

        // مقداری فاصله ای که می توان برای سر عقربه با کمان تنظیم کرد
        private float cesIndicatorOffset { get; set; } = 3;
        [System.ComponentModel.Category("Ces Gauge")]
        public float CesIndicatorOffset
        {
            get { return cesIndicatorOffset; }
            set
            {
                cesIndicatorOffset = value;
                Draw();
            }
        }

        // ضخامت کمان گیج
        private int cesArcThickness { get; set; } = 10;
        [System.ComponentModel.Category("Ces Gauge")]
        public int CesArcThickness
        {
            get { return cesArcThickness; }
            set
            {
                cesArcThickness = value;
                Draw();
            }
        }

        // رنگ اولیه کمان گیج اگر کاربر رنگی مشخص نکرده باشد
        private Color cesGaugeArcColor { get; set; } = Color.Gray;
        [System.ComponentModel.Category("Ces Gauge")]
        public Color CesGaugeArcColor
        {
            get { return cesGaugeArcColor; }
            set
            {
                cesGaugeArcColor = value;
                Draw();
            }
        }

        // نمایش خط جدا کننده بین عناصر گیج در زمان نمایش کمان گیج
        private bool cesShowSegmentSeparator { get; set; } = true;
        [System.ComponentModel.Category("Ces Gauge")]
        public bool CesShowSegmentSeparator
        {
            get { return cesShowSegmentSeparator; }
            set
            {
                cesShowSegmentSeparator = value;
                Draw();
            }
        }

        // تعیین رنگ برای جدا کننده عناصر گیج
        private Color cesSegmentSeparatorColor { get; set; } = Color.White;
        [System.ComponentModel.Category("Ces Gauge")]
        public Color CesSegmentSeparatorColor
        {
            get { return cesSegmentSeparatorColor; }
            set
            {
                cesSegmentSeparatorColor = value;
                Draw();
            }
        }

        // تعیین قطر دایره انتهای عقربه
        private float cesBigDiameter { get; set; } = 10;
        [System.ComponentModel.Category("Ces Gauge")]
        public float CesBigDiameter
        {
            get { return cesBigDiameter; }
            set
            {
                cesBigDiameter = value;
                Draw();
            }
        }

        // تعیین قطر دایره سر عقربه
        private float cesSmallDiameter { get; set; } = 2;
        [System.ComponentModel.Category("Ces Gauge")]
        public float CesSmallDiameter
        {
            get { return cesSmallDiameter; }
            set
            {
                cesSmallDiameter = value;
                Draw();
            }
        }

        // مقدار کنترل که می تاند برحسب درصد و یا مقداری از یک محدوده باشد
        private float cesValue { get; set; } = 10;
        [System.ComponentModel.Category("Ces Gauge")]
        public float CesValue
        {
            get
            {
                return cesValue;
            }
            set
            {
                // بررسی مقدار برای حالت درصدی
                if (!cesRangeMode && value < 0)
                    cesValue = 0;

                if (!cesRangeMode && value > 100)
                    cesValue = 100;

                if (!cesRangeMode && value >= 0 && value <= 100)
                    cesValue = value;

                // بررسی مقدار برای حالت رینج
                if (cesRangeMode && value < cesMinValue)
                    cesValue = cesMinValue;

                if (cesRangeMode && value > cesMaxValue)
                    cesValue = cesMaxValue;

                if (cesRangeMode && value >= cesMinValue && value <= cesMaxValue)
                    cesValue = value;

                // ثبت مقدار جدید
                CesRecord();

                // نمایش گیج
                Draw();
            }
        }

        // اگر مقدار این متغیر برابر 1 باشد کاربر باید جهت نمایش عقربه یک مقدار 
        // حداقل و یک مقدار حداکثر تعیین کند تا برنامه در رسم عقربه، دامنه اعداد
        // را در نظر بگیرد در غیر اینصورت بصورت پیش فرض عقربه بصورت درصد نمایش
        // داده خواهد شد
        private bool cesRangeMode { get; set; }
        [System.ComponentModel.Category("Ces Gauge")]
        public bool CesRangeMode
        {
            get { return cesRangeMode; }
            set
            {
                cesRangeMode = value;
                Draw();
            }
        }

        // حداقل مقدار در حالت دامنه
        private float cesMinValue { get; set; } = 0;
        [System.ComponentModel.Category("Ces Gauge")]
        public float CesMinValue
        {
            get { return cesMinValue; }
            set
            {
                cesMinValue = value;
                Draw();
            }
        }

        // حداکثر مقدار در حالت دامنه
        private float cesMaxValue { get; set; } = 10;
        [System.ComponentModel.Category("Ces Gauge")]
        public float CesMaxValue
        {
            get { return cesMaxValue; }
            set
            {
                cesMaxValue = value;
                Draw();
            }
        }

        private bool cesShowIndicatorLine { get; set; } = true;
        [System.ComponentModel.Category("Ces Gauge")]
        public bool CesShowIndicatorLine
        {
            get { return cesShowIndicatorLine; }
            set
            {
                cesShowIndicatorLine = value;
                Draw();
            }
        }

        // تعداد خطوط بزرگ مدرج
        private int cesIndicatorMajorNumber { get; set; } = 5;
        [System.ComponentModel.Category("Ces Gauge")]
        public int CesIndicatorMajorNumber
        {
            get { return cesIndicatorMajorNumber; }
            set
            {
                cesIndicatorMajorNumber = value;
                Draw();
            }
        }

        // تعداد خطوط کوچک مدرج
        private int cesIndicatorMinorNumber { get; set; } = 4;
        [System.ComponentModel.Category("Ces Gauge")]
        public int CesIndicatorMinorNumber
        {
            get { return cesIndicatorMinorNumber; }
            set
            {
                cesIndicatorMinorNumber = value;
                Draw();
            }
        }

        //ایجاد فاصله خطوط مدرج از کمان اصلی
        private float cesIndicatorLineOffset { get; set; } = 5;
        [System.ComponentModel.Category("Ces Gauge")]
        public float CesIndicatorLineOffset
        {
            get { return cesIndicatorLineOffset; }
            set
            {
                cesIndicatorLineOffset = value;
                Draw();
            }
        }

        // رنگ خطوط مدرج
        private Color cesIndicatorLineColor { get; set; } = Color.Silver;
        [System.ComponentModel.Category("Ces Gauge")]
        public Color CesIndicatorLineColor
        {
            get { return cesIndicatorLineColor; }
            set
            {
                cesIndicatorLineColor = value;
                Draw();
            }
        }

        // نمایش مقدار هر خط بزرگ مدرج در صفحه گیج
        private bool cesShowIndicatorLineValue { get; set; } = true;
        [System.ComponentModel.Category("Ces Gauge")]
        public bool CesShowIndicatorLineValue
        {
            get { return cesShowIndicatorLineValue; }
            set
            {
                cesShowIndicatorLineValue = value;
                Draw();
            }
        }

        // رنگ متن برای نمای شمقدار خطوط مدرج
        private Color cesIndicatorLineValueColor { get; set; } = Color.DarkGray;
        [System.ComponentModel.Category("Ces Gauge")]
        public Color CesIndicatorLineValueColor
        {
            get { return cesIndicatorLineValueColor; }
            set
            {
                cesIndicatorLineValueColor = value;
                Draw();
            }
        }

        // تعیین فونت برای نمایش مقدار هر خط مدرج
        private Font cesIndicatorLineValueFont { get; set; } = new Font("Verdana", 8, FontStyle.Bold);
        [System.ComponentModel.Category("Ces Gauge")]
        public Font CesIndicatorLineValueFont
        {
            get { return cesIndicatorLineValueFont; }
            set
            {
                cesIndicatorLineValueFont = value;
                Draw();
            }
        }

        private Font cesValueFont { get; set; } = new Font("Verdana", 10, FontStyle.Bold);
        [System.ComponentModel.Category("Ces Gauge")]
        public Font CesValueFont
        {
            get { return cesValueFont; }
            set
            {
                cesValueFont = value;
                Draw();
            }
        }

        private Color cesValueColor { get; set; } = Color.Black;
        [System.ComponentModel.Category("Ces Gauge")]
        public Color CesValueColor
        {
            get { return cesValueColor; }
            set
            {
                cesValueColor = value;
                Draw();
            }
        }

        private bool cesShowValue { get; set; } = true;
        [System.ComponentModel.Category("Ces Gauge")]
        public bool CesShowValue
        {
            get { return cesShowValue; }
            set
            {
                cesShowValue = value;
                Draw();
            }
        }

        // عبارتی که باید قبل از مقدار کنترل در گیج نمایش داده شود
        private string cesValuePrefix { get; set; } = "% ";
        [System.ComponentModel.Category("Ces Gauge")]
        public string CesValuePrefix
        {
            get { return cesValuePrefix; }
            set
            {
                cesValuePrefix = value;
                Draw();
            }
        }

        // عبارتی که باید بعد از مقدار کنترل در گیج نمایش داده شود
        private string cesValueSuffix { get; set; }
        [System.ComponentModel.Category("Ces Gauge")]
        public string CesValueSuffix
        {
            get { return cesValueSuffix; }
            set
            {
                cesValueSuffix = value;
                Draw();
            }
        }

        // تعیین عنوان برای گیج
        private string cesTitle { get; set; } = "Gauge Title";
        [System.ComponentModel.Category("Ces Gauge")]
        public string CesTitle
        {
            get { return cesTitle; }
            set
            {
                cesTitle = value;
                Draw();
            }
        }

        // نمایش عنوان برای گیج
        private bool cesShowTitle { get; set; } = true;
        [System.ComponentModel.Category("Ces Gauge")]
        public bool CesShowTitle
        {
            get { return cesShowTitle; }
            set
            {
                cesShowTitle = value;
                Draw();
            }
        }

        private Font cesTitleFont { get; set; } = new Font("Verdana", 11, FontStyle.Bold);
        [System.ComponentModel.Category("Ces Gauge")]
        public Font CesTitleFont
        {
            get { return cesTitleFont; }
            set
            {
                cesTitleFont = value;
                Draw();
            }
        }

        private Color cesTitleColor { get; set; } = Color.DimGray;
        [System.ComponentModel.Category("Ces Gauge")]
        public Color CesTitleColor
        {
            get { return cesTitleColor; }
            set
            {
                cesTitleColor = value;
                Draw();
            }
        }

        private Image cesImage { get; set; }
        [System.ComponentModel.Category("Ces Gauge")]
        public Image CesImage
        {
            get { return cesImage; }
            set
            {
                cesImage = value;
                Draw();
            }
        }

        private bool cesShowImage { get; set; }
        [System.ComponentModel.Category("Ces Gauge")]
        public bool CesShowImage
        {
            get { return cesShowImage; }
            set
            {
                cesShowImage = value;
                Draw();
            }
        }

        private CesGaugeImageLocationEnum cesImageLocation { get; set; } = CesGaugeImageLocationEnum.Top;
        [System.ComponentModel.Category("Ces Gauge")]
        public CesGaugeImageLocationEnum CesImageLocation
        {
            get { return cesImageLocation; }
            set
            {
                cesImageLocation = value;
                Draw();
            }
        }




        private float CesBigRadius { get; set; }
        private float CesSmallRadius { get; set; }
        private float IndicatorAngle { get; set; }
        private float IndicatorLength { get; set; }
        private PointF FixPoint { get; set; }
        private PointF RotatingPoint { get; set; }




        private void Draw()
        {
            var canvas = this;

            using Graphics g = canvas.CreateGraphics();
            using GraphicsPath path = new GraphicsPath();
            using Brush brushForIndicator = new SolidBrush(CesIndicatorColor);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(CesBackgroundColor);

            // تعیین ناحیه رسم گیج با توجه به ابعاد کنترل
            Rectangle outerRec = new Rectangle();
            Rectangle innerRec = new Rectangle();

            // تعیین ناحیه رسم کمان اصلی برحسب ابعاد کنترل. ناحیه باید
            // با یکی از ضلع هایی که ابعاد کوچکتری دارد برابر باشد.
            // یا طول یا عرض
            if (canvas.Width <= canvas.Height)
                outerRec = new Rectangle(
                    CesArcThickness,
                    (canvas.Height / 2) - (canvas.Width / 2) + CesArcThickness,
                    canvas.Width - (2 * CesArcThickness),
                    canvas.Width - (2 * CesArcThickness));
            else
                outerRec = new Rectangle(
                    (canvas.Width / 2) - (canvas.Height / 2) + CesArcThickness,
                    CesArcThickness,
                    canvas.Height - (2 * CesArcThickness),
                    canvas.Height - (2 * CesArcThickness));

            // ناحیه داخلی فضایی است که عقربه باید در آن رسم شود و
            // اندازه آن از ناحیه بیرونی که کمان اصلی گیج رسم شده
            // کوچکتر است
            innerRec = new Rectangle(
                outerRec.X + CesArcThickness,
                outerRec.Y + CesArcThickness,
                outerRec.Width - (2 * CesArcThickness),
                outerRec.Height - (2 * CesArcThickness));

            // برای رسم خطوط مدرج نیز یک ناحیه ایجاد میکنیم که
            // این ناحیه از ناحیه رسم عقربه نیز کوچکتر است تا خطوط
            // مدرج به کمان اصلی گیج برخورد نکند
            Rectangle IndicatorRec = new Rectangle()
            {
                X = (int)(innerRec.X + CesIndicatorLineOffset),
                Y = (int)(innerRec.Y + CesIndicatorLineOffset),
                Width = (int)(innerRec.Width - (2 * CesIndicatorLineOffset)),
                Height = (int)(innerRec.Height - (2 * CesIndicatorLineOffset)),
            };

            //------------------------------------------------------------------------------------------نمایش کمان

            // رسم کمان گیج اگر عناصر گیج تعیین نشده باشد
            if (CesGaugeSegments == null || CesGaugeSegments.Count == 0)
                g.DrawArc(
                new Pen(CesGaugeArcColor, CesArcThickness),
                outerRec,
                135,
                270);

            // اگر کاربر عناصر گیج را جهت رسم مشخص کرده باشد
            // برنامه اقدام به رسم آنها خواهد کرد
            float previousDegree = 135;
            float currentDegree = 0;

            // رسم تمام عناصر گیج با توجه به مشخصاتی که کاربر تعیین کرده است
            foreach (CesGaugeOptions item in CesGaugeSegments)
            {
                currentDegree = (item.Percent * 270) / 100;

                g.DrawArc(
                    new Pen(item.SegmentColor, CesArcThickness),
                    outerRec,
                    previousDegree,
                    currentDegree);

                // نمایش خط جدا کننده بین بخش های یک گیج
                // البته اگر آیتم جاری در حلقه، آخرین آیتم باشد دیگر
                // نیازی به رسم خط جدل کننده نیست
                // در رسم کام با زاویه 1 درجه منفی، به این دلیل است
                // که عنصر بعدی از گیج روی کمان رسم خواهد شد و دیده نمی شود
                // بنابراین از آخرین زاویه بدست آمده یک کمان با زاویه 1 درجه معکوس
                // رسم میکنیم تا دیده شود
                if (CesShowSegmentSeparator && CesGaugeSegments.LastOrDefault() != item)
                    g.DrawArc(
                        new Pen(CesSegmentSeparatorColor, CesArcThickness),
                        outerRec,
                        previousDegree + currentDegree,
                        -1);

                previousDegree += currentDegree;
            }

            //------------------------------------------------------------------------------------------نمایش خطوط بزرگ و کوچک

            // رسم خطوط درجه بندی
            // زاوایه هر یک از درجه بندی های بزرگ و کوچک
            float segmentMajorDegree = (float)(270.0) / (CesIndicatorMajorNumber - 1);
            float segmentMinorDegree = segmentMajorDegree / (CesIndicatorMinorNumber + 1);

            if (CesShowIndicatorLine)
                for (float i = 0; i <= CesIndicatorMajorNumber - 1; i++)
                {
                    float startMajorDegree = segmentMajorDegree * i;

                    // ابتدا خطوط مدرج کوچک را رسم میکنیم
                    for (float x = 0; x <= CesIndicatorMinorNumber + 1; x++)
                    {
                        // اگر حلقه رسم خطوط بزرگ به اخر رسید دیگر نبید
                        // خطوط کوچک مدرج بعد از آن رسم شود چون از محدوده
                        // خارج می شود
                        if (i == CesIndicatorMajorNumber - 1)
                            break;

                        float startMinorDegree = segmentMinorDegree * x;

                        g.DrawArc(
                            new Pen(CesIndicatorLineColor, 5),
                            IndicatorRec,
                            (float)(135 + startMajorDegree + startMinorDegree - 0.25),
                            (float)0.5);
                    }

                    // رسم خطوط بزرگ
                    g.DrawArc(
                        new Pen(CesIndicatorLineColor, 15),
                        IndicatorRec,
                        (float)(135 + startMajorDegree - 0.25),
                        (float)0.5);

                    // زاویه 0.25 کسر شده تا حرکت 0.5 درجه دقیقا
                    // هم محور با وسط عقربه قرار گیرد و نمایش تمیزتری
                    // ایجاد خواهد شد
                }

            //------------------------------------------------------------------------------------------نمایش مقدار خطوط بزرگ

            // نمایش مقادیر در کنار خطوط مدرج بزرگ
            if (CesShowIndicatorLine && CesShowIndicatorLineValue)
            {
                // ابتدا نقطع مرکز ناحیه رسم درجه بندی را بدست می آوریم
                PointF centerPoint = new PointF(
                    IndicatorRec.Left + (IndicatorRec.Width / 2),
                    IndicatorRec.Top + (IndicatorRec.Height / 2));

                float length = (IndicatorRec.Width / 2) - 20;

                for (float i = 0; i <= CesIndicatorMajorNumber - 1; i++)
                {
                    float startMajorDegree = segmentMajorDegree * i;

                    // در محاسبه مقدار هر درجه بندی باید بررسی شود که این اعداد
                    // برحسب درصد هستند و یا محدوده اعداد. برای نوع درصدی باید از
                    // صد محاسبه شودند و برای دامنه اعداد باید حداکثر عدد ملاک باشد
                    float currentValue = (CesRangeMode ? CesMaxValue : 100) / (CesIndicatorMajorNumber - 1) * i;
                    var indicatorValueSize = g.MeasureString(currentValue.ToString(), CesIndicatorLineValueFont);

                    PointF valueLocation = valueLocation = new PointF(
                        (float)(centerPoint.X + Math.Cos((135 + startMajorDegree) * Math.PI / 180) * length) - indicatorValueSize.Width / 2,
                        (float)(centerPoint.Y + Math.Sin((135 + startMajorDegree) * Math.PI / 180) * length) - indicatorValueSize.Height / 2);

                    g.DrawString(
                            currentValue.ToString(),
                            CesIndicatorLineValueFont,
                            new SolidBrush(CesIndicatorLineValueColor),
                            valueLocation);
                }
            }

            //------------------------------------------------------------------------------------------نمایش تصویر

            if (CesShowImage && CesImage != null)
            {
                PointF imageLocation = new PointF();

                switch (CesImageLocation)
                {
                    case CesGaugeImageLocationEnum.Top:
                        imageLocation = new Point(
                            innerRec.Left + (innerRec.Width / 2) - (CesImage.Width / 2),
                            innerRec.Top + (innerRec.Height / 4) - (CesImage.Height / 2));
                        break;
                    case CesGaugeImageLocationEnum.Bottom:
                        imageLocation = new Point(
                            innerRec.Left + (innerRec.Width / 2) - (CesImage.Width / 2),
                            innerRec.Bottom - (innerRec.Height / 4) - (CesImage.Height / 2));
                        break;
                    case CesGaugeImageLocationEnum.Left:
                        imageLocation = new Point(
                            innerRec.Left + (innerRec.Width / 4) - (CesImage.Width / 2),
                            innerRec.Top + (innerRec.Height / 2) - (CesImage.Height / 2));
                        break;
                    case CesGaugeImageLocationEnum.Right:
                        imageLocation = new Point(
                            innerRec.Right - (innerRec.Width / 4) - (CesImage.Width),
                            innerRec.Top + (innerRec.Height / 2) - (CesImage.Height / 2));
                        break;
                    default:
                        break;
                }

                g.DrawImage(CesImage, imageLocation);
            }

            //------------------------------------------------------------------------------------------نمایش عقربه

            // بدست آوردن زاویه چرحش عقربه با توجه به مقدار کنترل
            if (CesRangeMode)
                IndicatorAngle = CesValue * 270 / CesMaxValue;
            else
                IndicatorAngle = CesValue * 270 / 100;

            // تعیین موقعیت جهت رسم دایره ثابت و متحرک عقربه
            FixPoint = new PointF(innerRec.Left + (innerRec.Width / 2), (int)(innerRec.Top + (innerRec.Height / 2)));
            RotatingPoint = new PointF(innerRec.Left + (innerRec.Width / 2), CesSmallRadius);

            // این مقادیر جهت رسم دایره ابتدا و انتهای عقربه می باشد
            CesBigRadius = CesBigDiameter / 2;
            CesSmallRadius = CesSmallDiameter / 2;

            // محاسبه طول عقربه جهت محاسبه مختصات سر عقربه
            IndicatorLength = (innerRec.Width / 2) + (CesArcThickness / 2) - CesSmallRadius - CesIndicatorOffset;

            // رسم عقربه نوع 1
            if (CesIndicatorType == CesGaugeIndicatorTypeEnum.Type1)
            {
                // رسم دایره ثابت - انتهای عقربه
                path.AddArc(
                    new RectangleF(
                        new PointF(FixPoint.X - CesBigRadius, FixPoint.Y - CesBigRadius),
                        new SizeF(CesBigDiameter, CesBigDiameter)),
                    225 + IndicatorAngle,
                    180);

                // محاسبه موقعیت سر عقربه با توجه به مقدار کنترل
                RotatingPoint = new PointF(
                    (float)(FixPoint.X + Math.Cos((135 + IndicatorAngle) * Math.PI / 180) * IndicatorLength),
                    (float)(FixPoint.Y + Math.Sin((135 + IndicatorAngle) * Math.PI / 180) * IndicatorLength));

                // رسم دایره چرخان - سر عقربه
                path.AddArc(
                    new RectangleF(
                        new PointF(RotatingPoint.X - CesSmallRadius, RotatingPoint.Y - CesSmallRadius),
                        new SizeF(CesSmallDiameter, CesSmallDiameter)),
                    45 + IndicatorAngle,
                    180);
            }

            // ترسیم عقربه نوع دوم
            if (CesIndicatorType == CesGaugeIndicatorTypeEnum.Type2)
            {
                PointF indicatorPoint1 = new PointF(
                    (float)(FixPoint.X + Math.Cos((45 + IndicatorAngle) * Math.PI / 180) * CesBigRadius),
                    (float)(FixPoint.Y + Math.Sin((45 + IndicatorAngle) * Math.PI / 180) * CesBigRadius));

                PointF indicatorPoint2 = new PointF(
                    (float)(FixPoint.X + Math.Cos((225 + IndicatorAngle) * Math.PI / 180) * CesBigRadius),
                    (float)(FixPoint.Y + Math.Sin((225 + IndicatorAngle) * Math.PI / 180) * CesBigRadius));

                // ترسیم بخش بزرگتر عقربه
                RotatingPoint = new PointF(
                    (float)(FixPoint.X + Math.Cos((135 + IndicatorAngle) * Math.PI / 180) * IndicatorLength),
                    (float)(FixPoint.Y + Math.Sin((135 + IndicatorAngle) * Math.PI / 180) * IndicatorLength));

                path.AddLine(indicatorPoint1, RotatingPoint);
                path.AddLine(RotatingPoint, indicatorPoint2);

                // ترسیم بخش کوچکتر عقربه
                RotatingPoint = new PointF(
                    (float)(FixPoint.X + Math.Cos((315 + IndicatorAngle) * Math.PI / 180) * (IndicatorLength / 10)),
                    (float)(FixPoint.Y + Math.Sin((315 + IndicatorAngle) * Math.PI / 180) * (IndicatorLength / 10)));

                path.AddLine(indicatorPoint2, RotatingPoint);
                path.AddLine(RotatingPoint, indicatorPoint1);
            }

            path.CloseFigure();
            g.FillPath(brushForIndicator, path);
            //g.DrawPath(new Pen(Color.Red, 1), path);

            //------------------------------------------------------------------------------------------نمایش مقدار و عنوان

            // نمایش مقدار جاری در گیج
            if (CesShowValue)
            {
                var finalValue = CesValuePrefix + CesValue.ToString() + CesValueSuffix;
                var valueSize = g.MeasureString(finalValue, CesValueFont);

                g.DrawString(
                    finalValue,
                    CesValueFont,
                    new SolidBrush(CesValueColor),
                    new PointF(
                        FixPoint.X - (valueSize.Width / 2),
                        FixPoint.Y + (IndicatorLength / 2)));
            }

            // نمایش عنوان
            if (CesShowTitle)
            {
                var titleSize = g.MeasureString(CesTitle, CesTitleFont);

                g.DrawString(
                    CesTitle,
                    CesTitleFont,
                    new SolidBrush(CesTitleColor),
                    new PointF(
                        FixPoint.X - (titleSize.Width / 2),
                        outerRec.Bottom - titleSize.Height));
            }
        }

        private void CesGauge_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

    }
}
