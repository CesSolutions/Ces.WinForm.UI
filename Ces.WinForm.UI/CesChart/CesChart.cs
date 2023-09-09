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
            pbChart.Image = null;
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
            // برای رسم در فضای کمتر و یا بیشتر از ضریب استفاده کند
            float HeightFactor = (img.Height - CesTitleHeight - CesCategoryHeight) / 100;

            // رسم عنوان چارت
            if (CesChartTitleVisible)
            {
                SizeF titleSize = g.MeasureString(CesChartTitle, CesTitleFont);

                var titleLocation = new PointF(
                        titleArea.Width / 2 - titleSize.Width / 2,
                        titleArea.Height / 2 - titleSize.Height / 2);

                g.DrawString(CesChartTitle, CesTitleFont, new SolidBrush(Color.Green), titleLocation);
            }

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

            // تعیین فونت جهت نمایش ارقام درجه بندی و عنوان گروه بندی هر ستون
            //var scaleFont = new Font(new FontFamily("Verdana"), 3 * HeightFactor, FontStyle.Regular);

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

            // اگر اطلاعاتی وجود نداشته باشد برنامه از اجرای ادامه کدها خارج خواهد شد
            if (CesData == null)
                return;

            // تهیه لیست سری ها و گروه ها
            var series = new List<Ces.WinForm.UI.CesChart.CesChartSerie>();
            var categories = new List<Ces.WinForm.UI.CesChart.CesChartCategory>();

            series = CesData
                .DistinctBy(x => x.Serie)
                .Select(s => new Ces.WinForm.UI.CesChart.CesChartSerie
                {
                    Name = s.Serie,
                    SerieColor = s.SerieColor
                })
                .OrderBy(x => x.Name)
                .ToList();

            categories = CesData
                .DistinctBy(x => x.Category)
                .Select(s => new Ces.WinForm.UI.CesChart.CesChartCategory
                {
                    Name = s.Category,
                    Order = 0
                })
                .OrderBy(x => x.Name)
                .ToList();

            // حال باید به ازای هر سری یک لیست از گروه ها ایجاد کنیم
            // که به ازای هر گروه تمام مقادیر بصورت یک عدد تجمیع محاسبه خواهند شد
            // مثلا اگر گروه 2 چندین آیام باشد، یک ایتم از آن ایجاد میکنیم و مقدار
            // آن برابر جمع تمام گروه های مشابه در آن سری خواهد بود
            var finalData = new Dictionary<string, IList<Ces.WinForm.UI.CesChart.CesChartData>>();

            // جهت تعیین فاصله بین ستون های رسم شده در چارت باید تعداد
            // گروه را بر عرض ناحیه چارت تقسیم کنیم. فقط باید ببینیم
            // کدام سری از گروه های بیشتری برخورد است
            var countCat = CesData.DistinctBy(x => x.Category).Count();
            float CategoryDistance = chartArea.Width / countCat;

            int countSerie = 0;

            // ابتدا در لیست سری ها یک حلقه ایجاد میکنیم
            foreach (var serie in series)
            {
                var serieSize = g.MeasureString(serie.Name, CesLegendFont);

                g.FillEllipse(new SolidBrush(serie.SerieColor), legendArea.Left + 5, (float)(legendArea.Top + (countSerie * serieSize.Height * 1.5)), serieSize.Height, serieSize.Height);
                g.DrawString(serie.Name, CesLegendFont, new SolidBrush(Color.Black), legendArea.Left + serieSize.Height + 8, (float)(legendArea.Top + (countSerie * serieSize.Height * 1.5)));

                countSerie += 1;

                // یک لیست از گروه ها ایجاد میکنیم که کلید آن نام سری می باشد
                // و در انتها به دیکشنری اضافه خواهد شد. در واقع برای هر سری ی لیست
                // خواهیم داشت که شامل نام گروه می باشد که مقدار آن
                // جمع مقادیر گروه های مشسابه می باشد
                var cat = new List<Ces.WinForm.UI.CesChart.CesChartData>();

                // حلقه زیر روی داده هایی از نوع هر یک از سری ها اجرا خواهد شد
                // در واقع باید به ازای هر سری، داده ها را ارزیابی کنیم و مقادیر گروه های
                // مشابه را با هم جمع میکنیم تا بتوانیم درصد را نمایش بدهیم
                foreach (var data in CesData.Where(x => x.Serie == serie.Name).ToList())
                {
                    // اگر گروه از قبل در لیست وجود داشت هباشد فقط مقدار جدید بهآن اضافه خواهد شد
                    // در غیر اینصورت باید یک گروه جددی ایجاد کنیم
                    if (cat.Any(c => c.Category == data.Category))
                        cat.FirstOrDefault(c => c.Category == data.Category).Value += data.Value;
                    else
                        cat.Add(data);
                }

                // محاسبه درصد هر گروه برحسب مقدار کل کی سری
                foreach (var item in cat)
                {
                    var total = cat.Sum(s => s.Value);
                    decimal percent = (item.Value / total) * 100m;
                    item.Percent = percent > 100 ? 100 : percent;
                };

                // اگر اطلاعات سری جاری در لیست وجود داشت هباشد که فقط لیست را به آن 
                // اضافه میکنیم در غیر اینصورت یک آیتم جدید با کلیدی از نام سری ایجاد میکنیم
                if (finalData.ContainsKey(serie.Name))
                    finalData[serie.Name] = cat;
                else
                    finalData.Add(serie.Name, cat);
            }

            // حال باید تمام گروه ها را نمایش دهیم. با توجه به اینکه هر سری
            // ممکن است گروه های مشابه با سری های دیگر داشته باشد
            int currentCategory = 0;

            // یکبار عنوان گروه ها را روی چارت رسم میکنیم تا
            // برای تمام سری ها مجددا رسم نشود و در حلقه های بعدی فقط برحسب
            // مقدار هر گروه، ستون آن رسم شود
            foreach (var category in categories)
            {
                // محاسبه انداز عنوان گروه
                var categorySize = g.MeasureString(category.Name, CesCategoryFont);

                // رسم کادر اطراف عنوان
                if (CesCategoryGridLineVisible)
                {
                    g.DrawRectangle(
                        new Pen(Color.Black, 1),
                            categoryArea.Left + (currentCategory * CategoryDistance),
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
                        categoryArea.Left + (currentCategory * CategoryDistance),
                        categoryArea.Top,
                        CategoryDistance,
                        CesCategoryHeight
                        ), sf);

                // برای هر یک از گروه ها یک شماره تخصیص میدهیم و این شماره در زمان رسم ستون در چارت 
                // استفاده خواهد شد. از این عدد برای بدست آورده موقعیت رسم ستون استفاده خواهد شد.
                category.Order = currentCategory;

                currentCategory += 1;
            }

            int serieCount = 0;

            foreach (var serie in finalData)
            {
                serieCount += 1;

                var seriColor = series.FirstOrDefault(s => s.Name == serie.Key).SerieColor;

                foreach (var item in serie.Value.OrderBy(x => x.Category))
                {
                    var columnX = categories.FirstOrDefault(x => x.Name == item.Category).Order;

                    // محل رسم ستون نباید از عرض ناحیه چارت بیشتر باشد
                    var currentX = chartArea.Left + (columnX * CategoryDistance) + (CategoryDistance / 2) - (CesColumnWidth / 2) - ((series.Count / 2) * CesColumnWidth) + (serieCount * CesColumnWidth) + CesColumnWidth / 2;
                    if (currentX > chartArea.Right)
                    {
                        g.DrawString("Error...!", CesErrorFont, new SolidBrush(Color.Red), chartArea.Left, chartArea.Top);
                        continue;
                    }

                    // رسم ستون
                    g.DrawLine(
                        new Pen(seriColor, CesColumnWidth),
                        chartArea.Left + (columnX * CategoryDistance) + (CategoryDistance / 2) - (CesColumnWidth / 2) - ((series.Count / 2) * CesColumnWidth) + (serieCount * CesColumnWidth),
                        chartArea.Bottom,
                        chartArea.Left + (columnX * CategoryDistance) + (CategoryDistance / 2) - (CesColumnWidth / 2) - ((series.Count / 2) * CesColumnWidth) + (serieCount * CesColumnWidth),
                        chartArea.Bottom - ((int)item.Percent * HeightFactor));
                }
            }

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
