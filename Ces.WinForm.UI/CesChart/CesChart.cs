using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesChart
{
    public partial class CesChart : UserControl
    {
        public CesChart()
        {
            InitializeComponent();

            CesTitleHeight = CesChartTitleVisible ? 50 : 0;
            CesCategoryHeight = CesCategoryVisible ? 50 : 0;
            CesScaleWidth = CesScaleVisible ? 50 : 0;
            CesLegendWidth = CesLegendVisible ? 100 : 0;

            CesTitleFont = this.Font;
            CesScaleFont = this.Font;
            CesCategoryFont = this.Font;
            CesLegendFont = this.Font;
            CesErrorFont = this.Font;
        }


        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("Ces Chart")]
        public IList<CesChartData>? CesData { get; set; }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("Ces Chart")]
        public Dictionary<string, Color> CesSerieColor { get; set; }

        [System.ComponentModel.Category("Ces Chart")]
        public string? CesChartTitle { get; set; } = "Chart title";
        [System.ComponentModel.Category("Ces Chart")]
        public bool CesChartTitleVisible { get; set; } = true;
        [System.ComponentModel.Category("Ces Chart")]
        public IList<string>? CesLegend { get; set; } // SerieA, SerieB, ...
        [System.ComponentModel.Category("Ces Chart")]
        public bool CesLegendVisible { get; set; } = true;
        [System.ComponentModel.Category("Ces Chart")]
        public bool CesCategoryVisible { get; set; } = true;
        [System.ComponentModel.Category("Ces Chart")]
        public bool CesCategoryGridLineVisible { get; set; } = false;
        [System.ComponentModel.Category("Ces Chart")]
        public string? CesScaleTitle { get; set; } // Price, Time, ...
        [System.ComponentModel.Category("Ces Chart")]
        public bool CesScaleVisible { get; set; } = true;
        [System.ComponentModel.Category("Ces Chart")]
        public int CesScale { get; set; } = 10; // 0, 10, 20, 30, ...



        [System.ComponentModel.Category("Ces Chart")]
        public float CesTitleHeight { get; set; } = 50;
        [System.ComponentModel.Category("Ces Chart")]
        public float CesCategoryHeight { get; set; } = 50;
        [System.ComponentModel.Category("Ces Chart")]
        public float CesScaleWidth { get; set; } = 40;
        [System.ComponentModel.Category("Ces Chart")]
        public float CesLegendWidth { get; set; } = 100;
        [System.ComponentModel.Category("Ces Chart")]
        public float CesScaleIndicatorWidth { get; set; } = 5;
        [System.ComponentModel.Category("Ces Chart")]
        public float CesColumnWidth { get; set; } = 5;



        [System.ComponentModel.Category("Ces Chart")]
        public Font CesTitleFont { get; set; }
        [System.ComponentModel.Category("Ces Chart")]
        public Font CesScaleFont { get; set; }
        [System.ComponentModel.Category("Ces Chart")]
        public Font CesCategoryFont { get; set; }
        [System.ComponentModel.Category("Ces Chart")]
        public Font CesLegendFont { get; set; }
        [System.ComponentModel.Category("Ces Chart")]
        public Font CesErrorFont { get; set; }


        public void GenerateChart()
        {
            DrawChart();
        }

        private void DrawChart()
        {
            //ابتدا تصویر قبلی رد کنترل را حذف میکنیم تا پس از رسم چارت
            // تصویر جدید را در کنترل بارگذاری کنیم
            pbChart.Image = null;

            // ایجاد یک تصویر جدید به اندازه کنترل چارت که کاربر
            // در فرم آن را تنظیم کرده است. کاربر می تواند اندازه کنترل
            // چارت را به دلخواه تنظیم نماید
            var img = new Bitmap(this.Width - 2, this.Height - 2);

            using System.Drawing.Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // تعیین نواحی چارت
            var titleArea = new RectangleF(0, 0, img.Width, CesTitleHeight);
            var categoryArea = new RectangleF(CesScaleWidth, img.Height - CesCategoryHeight, img.Width - CesScaleWidth - CesLegendWidth, CesCategoryHeight);
            var scaleArea = new RectangleF(0, CesTitleHeight, CesScaleWidth, img.Height - CesTitleHeight - CesCategoryHeight);
            var legendArea = new RectangleF(img.Width - CesLegendWidth, CesTitleHeight, CesLegendWidth, img.Height - CesTitleHeight - CesCategoryHeight);
            var chartArea = new RectangleF(CesScaleWidth, CesTitleHeight, img.Width - CesScaleWidth - CesLegendWidth, img.Height - CesTitleHeight - CesCategoryHeight);

            // تعیین رنگ نواحی
            var titleAreaColor = Color.White;
            var categoryAreaColor = Color.White;
            var scaleAreaColor = Color.White;
            var legendAreaColor = Color.White;
            var chartAreaColor = Color.White;


            // رسم نواحی چارت
            g.FillRectangle(new SolidBrush(titleAreaColor), titleArea);
            g.FillRectangle(new SolidBrush(categoryAreaColor), categoryArea);
            g.FillRectangle(new SolidBrush(scaleAreaColor), scaleArea);
            g.FillRectangle(new SolidBrush(legendAreaColor), legendArea);
            g.FillRectangle(new SolidBrush(chartAreaColor), chartArea);

            // بدست آوردن ضریب ارتفاع. اگر کاربر ارتفاع چارت را تغییر بدهد، برنامه باید
            // برای رسم در فضای کمتر و یا بیشتر، از ضریب استفاده کند. چون در نمایش درصد
            // نمودا اگر ارتفاع 100 باشد مشکلی نیست ولی اگر کاربر اندازه چارت را بشتر و
            // یا کمتر تنظیم کند آنوقا برای رسم نمودار ستونی، باید ضریب ارتفاع را به
            // اندازه واقعی ضرب کنیم
            float HeightFactor = (img.Height - CesTitleHeight - CesCategoryHeight) / 100;

            //---------------------------------------------------------------------------------------------------

            // رسم عنوان چارت
            if (CesChartTitleVisible)
            {
                SizeF titleSize = g.MeasureString(CesChartTitle, CesTitleFont);

                var titleLocation = new PointF(
                        titleArea.Width / 2 - titleSize.Width / 2,
                        titleArea.Height / 2 - titleSize.Height / 2);

                g.DrawString(CesChartTitle, CesTitleFont, new SolidBrush(Color.Green), titleLocation);
            }

            //--------------------------------------------------------------------------------------------------- 

            // رسم خط افقی پایین ناحیه چارت
            g.DrawLine(
                new Pen(Color.Black, 1),
                chartArea.Left,
                chartArea.Bottom,
                chartArea.Right,
                chartArea.Bottom);

            // رسم خط عمودی بخش درجه بندی
            g.DrawLine(
                new Pen(Color.Black, 1),
                scaleArea.Width,
                scaleArea.Top,
                scaleArea.Width,
                scaleArea.Bottom);

            // رسم خط عمودی بخش درجه بندی
            g.DrawLine(
                new Pen(Color.Black, 1),
                legendArea.Left,
                legendArea.Top,
                legendArea.Left,
                legendArea.Bottom);

            //---------------------------------------------------------------------------------------------------

            // رسم درجه بندی خط عموی چارت و خطوط افقی داخل ناحیه چارت
            if (CesScaleVisible)
            {
                // حلقه زیر برحسب مقیاس تعیین شده مقدار شمارنده را افزایش میدهد
                // مثلا اگر مقیاس هدد 10 تعیین شده باشد به این معنی است که حلقه در 
                // هر مرحله باید 10 واحد به شمارنده اضافه کند و مقدر شماره در هر
                // مرحله از اجرای حلقه 10 واحد افزایش خواهد یافت و برنامه نیز عدد
                // شمارنده را به عنوان عدد درجه بندی رسم خواهد کرد
                // 10, 20, 30, ...
                for (int i = 0; i <= 100; i += CesScale)
                {
                    // رسم خطوط کوچک کنار خط عمودی. رسم این خطوط از پایین به بالا انجام
                    // خواهد شد و برحسب ضریب ارتفاع کنترل، موقعیت تعیین خواهد شد
                    g.DrawLine(
                        new Pen(Color.Blue, 1),
                        scaleArea.Width,
                        scaleArea.Bottom - (i * HeightFactor),
                        scaleArea.Width - CesScaleIndicatorWidth,
                        scaleArea.Bottom - (i * HeightFactor));

                    // برای رسم خطوط افقط نباید روی مقدار 0 خط رسم شود چون
                    // دقیقا روی خط پایینی ناحیه چارت قرار خواهد گرفت
                    if (i > 0)
                    {
                        g.DrawLine(
                            new Pen(Color.LightGray, 1),
                            chartArea.Left,
                            chartArea.Bottom - (i * HeightFactor),
                            chartArea.Right,
                            chartArea.Bottom - (i * HeightFactor));
                    }

                    // رسم عدد درجه بندی در کنار خطوط افقی کوچک
                    var scaleSize = g.MeasureString(i.ToString(), CesScaleFont);

                    g.DrawString(
                        i.ToString(),
                        CesScaleFont,
                        new SolidBrush(Color.Green),
                        scaleArea.Width - CesScaleIndicatorWidth - scaleSize.Width,
                        scaleArea.Bottom - (i * HeightFactor) - (scaleSize.Height / 2));
                }
            }

            //---------------------------------------------------------------------------------------------------

            // اگر اطلاعاتی وجود نداشته باشد برنامه از اجرای ادامه کدها خارج خواهد شد
            if (CesData == null)
                return;

            // تهیه لیست سری ها و گروه ها
            var series = new List<string>();
            var categories = new List<Ces.WinForm.UI.CesChart.CesChartCategory>();

            series = CesData
                .DistinctBy(x => x.Serie)
                .Select(s => s.Serie)
                .OrderBy(x => x)
                .ToList();

            categories = CesData
                .DistinctBy(x => x.Category)
                .Select(s => new Ces.WinForm.UI.CesChart.CesChartCategory
                {
                    Name = s.Category,
                    Percent = 0,
                    Order = 0
                })
                .OrderBy(x => x.Name)
                .ToList();

            //---------------------------------------------------------------------------------------------------

            // حال باید به ازای هر سری یک لیست از گروه ها ایجاد کنیم
            // که به ازای هر گروه تمام مقادیر بصورت یک عدد تجمیع محاسبه خواهند شد
            // مثلا اگر گروه 2 چندین آیتم باشد، یک ایتم از آن ایجاد میکنیم و مقدار
            // آن برابر جمع تمام گروه های مشابه در آن سری خواهد بود
            // Key = SeriName, Value = CesChartData
            var finalData = new Dictionary<string, IList<Ces.WinForm.UI.CesChart.CesChartCategory>>();

            // جهت تعیین فاصله بین ستون های رسم شده در چارت باید تعداد
            // گروه را بر عرض ناحیه چارت تقسیم کنیم. فقط باید ببینیم
            // کدام سری از گروه های بیشتری برخورد است و آن را ملاک قرار دهیم
            float CategoryDistance = chartArea.Width / categories.Count();

            int seriesCounter = 0;

            // ابتدا در لیست سری ها یک حلقه ایجاد میکنیم
            foreach (var serie in series)
            {
                // ایجاد فهرست سری ها در سمت راست چارت و مطابق با ناحیه تعریف شده برای
                // بخش های مختلف چارت
                var serieSize = g.MeasureString(serie, CesLegendFont);
                Color seriColor =  CesSerieColor.ContainsKey(serie) ? CesSerieColor[serie] : Color.Blue;

                g.FillEllipse(
                    new SolidBrush(seriColor),
                    legendArea.Left + 5,
                    (float)(legendArea.Top + (seriesCounter * serieSize.Height * 1.5)),
                    serieSize.Height, serieSize.Height);

                g.DrawString(
                    serie,
                    CesLegendFont,
                    new SolidBrush(Color.Black),
                    legendArea.Left + serieSize.Height + 8,
                    (float)(legendArea.Top + (seriesCounter * serieSize.Height * 1.5)));

                //-----------------------------------------------------------------------------

                seriesCounter += 1;

                // یک لیست از گروه ها ایجاد میکنیم که کلید آن نام سری می باشد
                // و در انتها به دیکشنری اضافه خواهد شد. در واقع برای هر سری یک لیست
                // خواهیم داشت که شامل نام گروه می باشد که مقدار آن
                // جمع مقادیر گروه های مشسابه است
                var categoryData = new List<Ces.WinForm.UI.CesChart.CesChartCategory>();

                // حلقه زیر روی داده هایی از نوع هر یک از سری ها اجرا خواهد شد
                // در واقع باید به ازای هر سری، داده ها را ارزیابی کنیم و مقادیر گروه های
                // مشابه را با هم جمع میکنیم تا بتوانیم درصد را نمایش بدهیم
                foreach (var data in CesData.Where(x => x.Serie == serie).ToList())
                {
                    // اگر گروه از قبل در لیست وجود داشته باشد فقط مقدار جدید به آن اضافه خواهد شد
                    // در غیر اینصورت باید یک گروه جدید ایجاد کنیم
                    if (categoryData.Any(c => c.Name == data.Category))
                        categoryData.FirstOrDefault(c => c.Name == data.Category).SumValue += data.Value;
                    else
                        categoryData.Add(new CesChartCategory { Name = data.Category });
                }

                // محاسبه درصد هر گروه برحسب مقدار کل یک سری
                var totalValue = categoryData.Sum(s => s.SumValue);

                foreach (var item in categoryData)
                {
                    decimal percent = (item.SumValue / totalValue) * 100m;
                    item.Percent = percent > 100 ? 100 : percent;
                };

                // اگر اطلاعات سری جاری در لیست وجود داشته باشد که فقط لیست را به آن 
                // اضافه میکنیم در غیر اینصورت یک آیتم جدید با کلیدی از نام سری ایجاد میکنیم
                if (finalData.ContainsKey(serie))
                    finalData[serie] = categoryData;
                else
                    finalData.Add(serie, categoryData);
            }

            // تا به اینجا ما لیستی از سری ها و گروه ها ایجاد کردیم و با توجه به 
            // داده هایی که به کاربر ارسال کرده، مقادیر گروه های مشابه در هر سری
            // را جمع زدیم و درصد هر گروه را در همان سری نیز محاسبه کردیم

            //---------------------------------------------------------------------------------------------------

            // حال باید تمام گروه ها را نمایش دهیم. با توجه به اینکه هر سری
            // ممکن است گروه های مشابه با سری های دیگر داشته باشد بنابراین
            // یکبار تمام گروه های منحصربفرد را رسم میکنیم و برای هر گروه 
            // یک شماره تخصیص میدهیم تا نمودارد مربوطبه هر گروه در موقعیت خودش رسم شود
            int categoryCounter = 0;

            foreach (var category in categories)
            {
                // محاسبه انداز عنوان گروه
                var categorySize = g.MeasureString(category.Name, CesCategoryFont);

                // رسم کادر اطراف عنوان
                if (CesCategoryGridLineVisible)
                {
                    g.DrawRectangle(
                        new Pen(Color.Black, 1),
                            categoryArea.Left + (categoryCounter * CategoryDistance),
                            categoryArea.Top,
                            CategoryDistance,
                            CesCategoryHeight);
                }

                // رسم عنوان هر گروه
                var sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.DrawString(
                    category.Name,
                    CesCategoryFont,
                    new SolidBrush(Color.Black),
                    new RectangleF(
                        categoryArea.Left + (categoryCounter * CategoryDistance),
                        categoryArea.Top,
                        CategoryDistance,
                        CesCategoryHeight),
                    sf);

                // برای هر یک از گروه ها یک شماره تخصیص میدهیم و این شماره در زمان رسم ستون در چارت 
                // استفاده خواهد شد. از این عدد برای بدست آورده موقعیت رسم ستون استفاده خواهد شد.
                category.Order = categoryCounter;
                categoryCounter += 1;
            }

            //---------------------------------------------------------------------------------------------------

            int serieCounter = 0;

            foreach (var serie in finalData)
            {
                serieCounter += 1;

                // رسم نمودار باید مطابق رنگ هر سری باشد که توسط کاربر تعیین شده است
                Color seriColor = CesSerieColor.ContainsKey(serie.Key) ? CesSerieColor[serie.Key] : Color.Blue;

                foreach (var item in serie.Value.OrderBy(x => x.Name))
                {
                    var columnXLocation = categories.FirstOrDefault(x => x.Name == item.Name).Order;

                    // محل رسم ستون نباید از عرض ناحیه چارت بیشتر باشد
                    var currentX = 
                        chartArea.Left + 
                        (columnXLocation * CategoryDistance) + 
                        (CategoryDistance / 2) - 
                        (CesColumnWidth / 2) - 
                        ((series.Count / 2) * CesColumnWidth) + 
                        (serieCounter * CesColumnWidth) + 
                        CesColumnWidth / 2;

                    // اگر موقعیت یک ستون خارج از ناحیه چارت باشد یک عبارت در گوشه سمت چپ بالا
                    // نمایش داده خواهد شد که در این شرایط کاربر باید عرض ستون ها را کوچکتر در نظر بگیرد
                    if (currentX > chartArea.Right)
                    {
                        g.DrawString("Error...! (Lessen Column Width)", CesErrorFont, new SolidBrush(Color.Red), chartArea.Left, chartArea.Top);
                        continue;
                    }

                    // تعیین موقعیت سمت چپ ستون
                    var columnLeft =
                        chartArea.Left + 
                        (columnXLocation * CategoryDistance) + 
                        (CategoryDistance / 2) - 
                        (CesColumnWidth / 2) - 
                        ((series.Count / 2) * CesColumnWidth) + 
                        (serieCounter * CesColumnWidth);

                    // رسم ستون
                    g.DrawLine(
                        new Pen(seriColor, CesColumnWidth),
                        columnLeft,
                        chartArea.Bottom,
                        columnLeft,
                        chartArea.Bottom - ((int)item.Percent * HeightFactor));
                }
            }

            // نمایش تصویر در کنترل
            pbChart.Image = img;
        }

        private void CesChart_Load(object sender, EventArgs e)
        {

        }

        private void CesChart_SizeChanged(object sender, EventArgs e)
        {
            GenerateChart();
        }
    }
}
