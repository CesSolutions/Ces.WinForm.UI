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
        }


        private Ces.WinForm.UI.CesChart.CesChartOptions options = new CesChartOptions();
        public Ces.WinForm.UI.CesChart.CesChartOptions Options
        {
            get { return options; }
            set
            {
                if (value == null)
                    return;

                options = value;
                DrawChart();
            }
        }

        private void DrawChart()
        {
            pbChart.Image = null;
            pnlSeries.Visible = false;
            var img = new Bitmap(this.Width - 2, this.Height - 2);
            using System.Drawing.Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // تعیین مقدار برای متغیرهای ضروری
            float TitleHeight = Options.ChartTitleVisible ? 50 : 0;
            float CategoryHeight = Options.CategoryVisible ? 50 : 0;
            float scaleWidth = Options.ScaleVisible ? 50 : 0;
            float LegendWidth = Options.LegendVisible ? 150 : 0;
            float scaleIndicatorWidth = 5;
            float columnWidth = 8;

            // تعیین نواحی چارت
            var titleArea = new RectangleF(0, 0, img.Width, TitleHeight);
            var categoryArea = new RectangleF(scaleWidth, img.Height - CategoryHeight, img.Width - scaleWidth - LegendWidth, CategoryHeight);
            var scaleArea = new RectangleF(0, TitleHeight, scaleWidth, img.Height - TitleHeight - CategoryHeight);
            var legendArea = new RectangleF(img.Width - LegendWidth, TitleHeight, LegendWidth, img.Height - TitleHeight - CategoryHeight);
            //var chartArea = new RectangleF(scaleWidth, TitleHeight, img.Width - scaleWidth - LegendWidth - (pnlSeries.Visible ? pnlSeries.Width : 0), img.Height - TitleHeight - CategoryHeight);
            var chartArea = new RectangleF(scaleWidth, TitleHeight, img.Width - scaleWidth - (pnlSeries.Visible ? pnlSeries.Width : 0), img.Height - TitleHeight - CategoryHeight);

            // تعیین رنگ نواحی
            var titleAreaColor = Color.White;
            var categoryAreaColor = Color.White;
            var scaleAreaColor = Color.White;
            var legendAreaColor = Color.Gray;
            var chartAreaColor = Color.White;

            // رسم نواحی چارت
            g.FillRectangle(new SolidBrush(titleAreaColor), titleArea);
            g.FillRectangle(new SolidBrush(categoryAreaColor), categoryArea);
            g.FillRectangle(new SolidBrush(scaleAreaColor), scaleArea);
            g.FillRectangle(new SolidBrush(legendAreaColor), legendArea);
            g.FillRectangle(new SolidBrush(chartAreaColor), chartArea);

            // بدست آوردن ضریب ارتفاع. اگر کاربر ارتفاع چارت را تغییر بدهد، برنامه باید
            // برای رسم در فضای کمتر و یا بیشتر از ضریب استفاده کند
            float HeightFactor = (img.Height - TitleHeight - CategoryHeight) / 100;

            // رسم عنوان چارت
            if (Options.ChartTitleVisible)
            {
                SizeF titleSize = g.MeasureString(Options.ChartTitle, this.Font);
                var titleLocation = new PointF(
                        titleArea.Width / 2 - titleSize.Width / 2,
                        titleArea.Height / 2 - titleSize.Height / 2);

                g.DrawString(Options.ChartTitle, this.Font, new SolidBrush(Color.Green), titleLocation);
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

            // تعیین فونت جهت نمایش ارقام درجه بندی و عنوان گروه بندی هر ستون
            var scaleFont = new Font(new FontFamily("Verdana"), 3 * HeightFactor, FontStyle.Regular);

            // رسم درجه بندی خط عموی چارت و خطوط افقی داخل ناحیه چارت
            if (Options.ScaleVisible)
            {
                // حلقه زیر برحسب مقیاس تعیین شده مقدار شمارنده را افزایش میدهد
                // مثلا اگر مقیاس هدد 10 تعیین شده باشد به این معنی است که حلقه در 
                // هر مرحله باید 10 واحد به شمارنده اضافه کند و مقدر شماره در هر
                // مرحله از اجرای حلقه 10 واحد افزایش خواهد یافت و برنامه نیز عدد
                // شمارنده را به عنوان عدد درجه بندی رسم خواهد کرد
                // 10, 20, 30, ...
                for (int i = 0; i <= 100; i += Options.Scale)
                {
                    // رسم خطوط کوچک کنار خط عمودی. رسم این خطوط از پایین به بالا انجام
                    // خواهد شد و برحسب ضریب ارتفاع کنترل، موقعیت تعیین خواهد شد
                    g.DrawLine(
                        new Pen(Color.Blue, 1),
                        scaleArea.Width,
                        scaleArea.Bottom - (i * HeightFactor),
                        scaleArea.Width - scaleIndicatorWidth,
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
                    var scaleSize = g.MeasureString(i.ToString(), scaleFont);

                    g.DrawString(
                        i.ToString(),
                        scaleFont,
                        new SolidBrush(Color.Green),
                        scaleArea.Width - scaleIndicatorWidth - scaleSize.Width,
                        scaleArea.Bottom - (i * HeightFactor) - (scaleSize.Height / 2));
                }
            }

            // اگر اطلاعاتی وجود نداشته باشد برنامه از اجرای ادامه کدها خارج خواهد شد
            if (Options.Data == null)
                return;

            // تهیه لیست سری ها و گروه ها
            var series = new List<Ces.WinForm.UI.CesChart.CesChartSerie>();
            var categories = new List<Ces.WinForm.UI.CesChart.CesChartCategory>();

            series = Options.Data
                .DistinctBy(x => x.Serie)
                .Select(s => new Ces.WinForm.UI.CesChart.CesChartSerie
                {
                    Name = s.Serie,
                    SerieColor = s.SerieColor
                })
                .OrderBy(x => x.Name)
                .ToList();

            categories = Options.Data
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
            var countCat = Options.Data.DistinctBy(x => x.Category).Count();
            float CategoryDistance = chartArea.Width / countCat;

            // ابتدا در لیست سری ها یک حلقه ایجاد میکنیم
            foreach (var serie in series)
            {
                // به ازای هر سری باید یبک برچسب در پانل سری ها ایجاد کنیم
                pnlSeries.Controls.Add(new Label
                {
                    Text = serie.Name,
                    BackColor = serie.SerieColor,
                    Dock = DockStyle.Top
                }); ;

                // یک لیست از گروه ها ایجاد میکنیم که کلید آن نام سری می باشد
                // و در انتها به دیکشنری اضافه خواهد شد. در واقع برای هر سری ی لیست
                // خواهیم داشت که شامل نام گروه می باشد که مقدار آن
                // جمع مقادیر گروه های مشسابه می باشد
                var cat = new List<Ces.WinForm.UI.CesChart.CesChartData>();

                // حلقه زیر روی داده هایی از نوع هر یک از سری ها اجرا خواهد شد
                // در واقع باید به ازای هر سری، داده ها را ارزیابی کنیم و مقادیر گروه های
                // مشابه را با هم جمع میکنیم تا بتوانیم درصد را نمایش بدهیم
                foreach (var data in Options.Data.Where(x => x.Serie == serie.Name).ToList())
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
                // برای هر یک از گروه ها یک شماره تخصیص میدهیم و این شماره در زمان رسم ستون در چارت 
                // استفاده خواهد شد. از این عدد برای بدست آورده موقعیت رسم ستون استفاده خواهد شد.
                category.Order = currentCategory;

                // محاسبه انداز عنوان گروه
                var categorySize = g.MeasureString(category.Name, scaleFont);

                // رسم کادر اطراف عنوان
                if (Options.CategoryGridLineVisible)
                {
                    g.DrawRectangle(
                        new Pen(Color.Black, 1),
                            categoryArea.Left + (currentCategory * CategoryDistance),
                            categoryArea.Top,
                            CategoryDistance,
                            CategoryHeight
                            );
                }

                // رسم عنوان هر گروه
                var sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                g.DrawString(
                    category.Name,
                    scaleFont,
                    new SolidBrush(Color.Black),
                    new RectangleF(
                        categoryArea.Left + (currentCategory * CategoryDistance),
                        categoryArea.Top,
                        CategoryDistance,
                        CategoryHeight
                        ), sf);

                currentCategory += 1;
            }

            int serieCount = 0;
            int countData = 0;

            foreach (var serie in finalData)
            {
                serieCount += 1;
                countData = 0;
                var seriColor = series.FirstOrDefault(s => s.Name == serie.Key).SerieColor;

                foreach (var item in serie.Value.OrderBy(x => x.Category))
                {
                    // محل رسم ستون نباید از عرض ناحیه چارت بیشتر باشد
                    var currentX = (countData * CategoryDistance) + CategoryDistance;                    
                    if (currentX > chartArea.Width)
                        break;

                    var columnX = categories.FirstOrDefault(x => x.Name == item.Category).Order;

                    // رسم ستون
                    g.DrawLine(
                        new Pen(seriColor, columnWidth),
                        chartArea.Left + (countData * CategoryDistance) + (CategoryDistance / 2) - (columnWidth / 2) - ((series.Count / 2) * columnWidth) + (serieCount * columnWidth),
                        chartArea.Bottom,
                        chartArea.Left + (countData * CategoryDistance) + (CategoryDistance / 2) - (columnWidth / 2) - ((series.Count / 2) * columnWidth) + (serieCount * columnWidth),
                        chartArea.Bottom - ((int)item.Percent * HeightFactor));

                    countData += 1;
                }
            }

            pbChart.Image = img;
        }

        private void CesChart_Load(object sender, EventArgs e)
        {

        }
    }
}
