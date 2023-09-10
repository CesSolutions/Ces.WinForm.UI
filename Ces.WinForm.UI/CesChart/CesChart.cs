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
        public IList<Ces.WinForm.UI.CesChart.CesChartData>? CesData { get; set; }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("Ces Chart")]
        public IList<Ces.WinForm.UI.CesChart.CesChartSerie> CesSeries { get; set; }

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



        private System.Drawing.Bitmap? img;
        private System.Drawing.Graphics g;

        private IList<Ces.WinForm.UI.CesChart.CesChartData>? columnTypeChartData;
        private IList<Ces.WinForm.UI.CesChart.CesChartData>? areaTypeChartData;

        private IList<Ces.WinForm.UI.CesChart.CesChartSerie>? series;
        private IList<Ces.WinForm.UI.CesChart.CesChartCategory> categories;

        // تعیین نواحی چارت
        private RectangleF titleArea;
        private RectangleF categoryArea;
        private RectangleF scaleArea;
        private RectangleF legendArea;
        private RectangleF chartArea;

        // تعیین رنگ نواحی
        private Color titleAreaColor = Color.White;
        private Color categoryAreaColor = Color.White;
        private Color scaleAreaColor = Color.White;
        private Color legendAreaColor = Color.White;
        private Color chartAreaColor = Color.White;

        float HeightFactor = 0;
        float CategoryDistance = 0;


        public void GenerateChart()
        {
            columnTypeChartData = CesData?.Where(x => x.Serie?.Type == CesChartTypeEnum.Column).ToList();
            areaTypeChartData = CesData?.Where(x => x.Serie?.Type == CesChartTypeEnum.Area).ToList();

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
            img = new Bitmap(this.Width - 2, this.Height - 2);

            g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            // تعیین نواحی چارت
            titleArea = new RectangleF(0, 0, img.Width, CesTitleHeight);
            categoryArea = new RectangleF(CesScaleWidth, img.Height - CesCategoryHeight, img.Width - CesScaleWidth - CesLegendWidth, CesCategoryHeight);
            scaleArea = new RectangleF(0, CesTitleHeight, CesScaleWidth, img.Height - CesTitleHeight - CesCategoryHeight);
            legendArea = new RectangleF(img.Width - CesLegendWidth, CesTitleHeight, CesLegendWidth, img.Height - CesTitleHeight - CesCategoryHeight);
            chartArea = new RectangleF(CesScaleWidth, CesTitleHeight, img.Width - CesScaleWidth - CesLegendWidth, img.Height - CesTitleHeight - CesCategoryHeight);

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
            HeightFactor = (img.Height - CesTitleHeight - CesCategoryHeight) / 100;

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
            series = new List<Ces.WinForm.UI.CesChart.CesChartSerie>();
            categories = new List<Ces.WinForm.UI.CesChart.CesChartCategory>();

            series = CesData
                .DistinctBy(x => x.Serie.Name)
                .Select(s => s.Serie)
                .OrderBy(x => x.Name)
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

            // تخصیص شماره ترتیب به عناوین گروه ها تا در ادامه برنامه
            // جهت رسم عناوین و رسم مقادیر از این شماره ترتیب استفاده نماید
            for (int i = 0; i < categories.Count; i++)
            {
                categories[i].Order = i;
            }


            //---------------------------------------------------------------------------------------------------


            int seriesCounter = 0;

            // ابتدا در لیست سری ها یک حلقه ایجاد میکنیم
            foreach (var serie in series)
            {
                // ایجاد فهرست سری ها در سمت راست چارت و مطابق با ناحیه تعریف شده برای
                // بخش های مختلف چارت
                var serieSize = g.MeasureString(serie.Name, CesLegendFont);

                g.FillEllipse(
                    new SolidBrush(serie.SeriColor),
                    legendArea.Left + 5,
                    (float)(legendArea.Top + (seriesCounter * serieSize.Height * 1.5)),
                    serieSize.Height,
                    serieSize.Height);

                g.DrawString(
                    serie.Name,
                    CesLegendFont,
                    new SolidBrush(Color.Black),
                    legendArea.Left + serieSize.Height + 8,
                    (float)(legendArea.Top + (seriesCounter * serieSize.Height * 1.5)));

                seriesCounter += 1;


                //---------------------------------------------------------------------------------------------------


                // جهت تعیین فاصله بین ستون های رسم شده در چارت باید تعداد
                // گروه را بر عرض ناحیه چارت تقسیم کنیم. فقط باید ببینیم
                // کدام سری از گروه های بیشتری برخورد است و آن را ملاک قرار دهیم
                CategoryDistance = chartArea.Width / categories.Count();

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


                    categoryCounter += 1;
                }
            }


            //---------------------------------------------------------------------------------------------------


            // فراخوانی متدهای مورد نیاز جهت رس چارت های مختلف
            DrawColumnTypeChart();
            DrawAreaTypeChart();

            // نمایش تصویر در کنترل
            pbChart.Image = img;

            g.Dispose();
        }

        private void DrawColumnTypeChart()
        {
            if (columnTypeChartData is null || columnTypeChartData.Count == 0)
                return;

            // ایجاد یک لیست نهایی و انجام محاسبات
            var finalData = new Dictionary<
                Ces.WinForm.UI.CesChart.CesChartSerie,
                IList<Ces.WinForm.UI.CesChart.CesChartCategory>>();

            Ces.WinForm.UI.CesChart.CesChartSerie? currentSerie;
            Ces.WinForm.UI.CesChart.CesChartCategory? currentCategory;

            foreach (var serie in series.Where(x => x.Type == CesChartTypeEnum.Column).OrderBy(x => x.Name))
            {
                var chartCategory = new List<Ces.WinForm.UI.CesChart.CesChartCategory>();

                foreach (var item in columnTypeChartData.Where(x => x.Serie.Name == serie.Name).ToList())
                {
                    // اگر گروه وجود نداشته باشد آن را ایجاد میکنیم و اگر وجود
                    //داشته باشد که مقدار جدید را به گروه مشابه قبلی اضافه می کنیم
                    currentCategory = chartCategory.FirstOrDefault(x => x.Name == item.Category);

                    if (currentCategory is null)
                        chartCategory.Add(new CesChartCategory
                        {
                            Name = item.Category,
                            SumValue = item.Value,
                        });
                    else
                        currentCategory.SumValue += item.Value;
                }


                // اگر کلید مورد نظر وجود نداشته باشد آن را ایجاد می کنیم و 
                // اگر وجود داشته باشد مقدار جدید را به آن کلید تخصیص می دهیم
                currentSerie = finalData.FirstOrDefault(x => x.Key.Name == serie.Name).Key;

                if (currentSerie is null)
                    finalData.Add(serie, chartCategory);
                else
                    finalData[serie] = chartCategory;
            }


            int serieCounter = 0;

            // به ازای تمام سری باید یک حلقه اجرا شود تا به ازای هر سری گروه های
            // مربوط به آن نیز بررسی و نمودار آن در چارت رسم شود
            foreach (var serie in finalData)
            {
                serieCounter += 1;

                foreach (var item in serie.Value)
                {
                    var columnXLocation = categories.FirstOrDefault(x => x.Name == item.Name).Order;

                    // محاسبه درصد هر گروه برحسب مقدار کل یک سری
                    var totalValueOfSerie = columnTypeChartData.Where(x => x.Serie.Name == serie.Key.Name).Sum(x => x.Value);
                    //var totalValueOfCategory = columnTypeChartData.Where(x => x.Serie.Name == serie.Name && x.Category == item.Category).Sum(x => x.Value);
                    var categoryPercent = (item.SumValue / totalValueOfSerie) * 100m;

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
                        g.DrawString(
                            "Error...! (Lessen Column Width)",
                            CesErrorFont,
                            new SolidBrush(Color.Red),
                            chartArea.Left,
                            chartArea.Top);

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
                        new Pen(serie.Key.SeriColor, CesColumnWidth),
                        columnLeft,
                        chartArea.Bottom,
                        columnLeft,
                        chartArea.Bottom - ((int)categoryPercent * HeightFactor));
                }
            }
        }

        private void DrawAreaTypeChart()
        {
            if (areaTypeChartData is null || areaTypeChartData.Count == 0)
                return;

            // ایجاد یک لیست نهایی و انجام محاسبات
            var finalData = new Dictionary<
                Ces.WinForm.UI.CesChart.CesChartSerie,
                IList<Ces.WinForm.UI.CesChart.CesChartCategory>>();

            Ces.WinForm.UI.CesChart.CesChartCategory? currentCategory;
            Ces.WinForm.UI.CesChart.CesChartSerie? currentSerie;

            foreach (var serie in series.Where(x => x.Type == CesChartTypeEnum.Area).OrderBy(x => x.Name))
            {
                var chartCategory = new List<Ces.WinForm.UI.CesChart.CesChartCategory>();

                foreach (var item in areaTypeChartData.Where(x => x.Serie.Name == serie.Name).ToList())
                {
                    // اگر گروه وجود نداشته باشد آن را ایجاد میکنیم و اگر وجود
                    //داشته باشد که مقدار جدید را به گروه مشابه قبلی اضافه می کنیم
                    currentCategory = chartCategory.FirstOrDefault(x => x.Name == item.Category);

                    if (currentCategory is null)
                        chartCategory.Add(new CesChartCategory
                        {
                            Name = item.Category,
                            SumValue = item.Value,
                        });
                    else
                        currentCategory.SumValue += item.Value;
                }

                // اگر کلید مورد نظر وجود نداشته باشد آن را ایجاد می کنیم و 
                // اگر وجود داشته باشد مقدار جدید را به آن کلید تخصیص می دهیم
                currentSerie = finalData.FirstOrDefault(x => x.Key.Name == serie.Name).Key;

                if (currentSerie is null)
                    finalData.Add(serie, chartCategory);
                else
                    finalData[serie] = chartCategory;
            }

            int serieCounter = 0;

            foreach (var serie in finalData)
            {
                var gp = new System.Drawing.Drawing2D.GraphicsPath();
                PointF inititalPoint = new PointF();
                PointF currentPoint = new PointF();
                PointF lastPoint = new PointF();
                var p = new List<PointF>();
                float leftPosition = 0;
                int itemCounter = 0;

                serieCounter += 1;

                foreach (var item in serie.Value)
                {
                    // محاسبه درصد هر گروه برحسب مقدار کل یک سری
                    var totalValueOfSerie = serie.Value.Sum(x => x.SumValue);
                    var categoryPercent = (item.SumValue / totalValueOfSerie) * 100m;

                    //var columnXLocation = categories.FirstOrDefault(x => x.Name == item.Name).Order;

                    //// محل رسم ستون نباید از عرض ناحیه چارت بیشتر باشد
                    //var currentX =
                    //    chartArea.Left +
                    //    (columnXLocation * CategoryDistance) +
                    //    (CategoryDistance / 2) -
                    //    (CesColumnWidth / 2) -
                    //    ((series.Count / 2) * CesColumnWidth) +
                    //    (serieCounter * CesColumnWidth) +
                    //    CesColumnWidth / 2;

                    //// اگر موقعیت یک ستون خارج از ناحیه چارت باشد یک عبارت در گوشه سمت چپ بالا
                    //// نمایش داده خواهد شد که در این شرایط کاربر باید عرض ستون ها را کوچکتر در نظر بگیرد
                    //if (currentX > chartArea.Right)
                    //{
                    //    g.DrawString("Error...! (Lessen Column Width)", CesErrorFont, new SolidBrush(Color.Red), chartArea.Left, chartArea.Top);
                    //    continue;
                    //}


                    float height = chartArea.Bottom - ((int)categoryPercent * HeightFactor);

                    // اولین نقطه باید از کف چارت به سمت بالا باشد و مقدار ارتفاع
                    // همان درصد مورد نظر گروه اول می باشد
                    if (itemCounter == 0)
                    {
                        // تعیین موقعیت سمت چپ ستون
                        leftPosition =
                            chartArea.Left + // CategoryDistance +
                            (CategoryDistance / 2) -
                            (CesColumnWidth / 2);

                        inititalPoint = new PointF(leftPosition, chartArea.Bottom);
                        //p.Add(inititalPoint);
                    }

                    int categoryOrder = categories.FirstOrDefault(x => x.Name == item.Name).Order;

                    // تعیین موقعیت سمت چپ ستون
                    leftPosition =
                        chartArea.Left +
                        categoryOrder * CategoryDistance +
                        (CategoryDistance / 2) -
                        (CesColumnWidth / 2);


                    // تعیین نقطه مربوط به درصد گروه جاری
                    currentPoint = new PointF(leftPosition, height);
                    p.Add(currentPoint);
                    itemCounter += 1;
                }

                // تعیین موقعیت سمت چپ ستون
                leftPosition =
                    chartArea.Left +
                    categories.Max(x => x.Order) * CategoryDistance +
                    (CategoryDistance / 2) -
                    (CesColumnWidth / 2);

                // آخرین نقطه نیز بصورت عموی به سمت کف چارت رسم می شود
                lastPoint = new PointF(leftPosition, chartArea.Bottom);
                //p.Add(lastPoint);

                var p2 = p.OrderBy(x => x.X).ToList();

                p2.Insert(0, inititalPoint);
                p2.Insert(p2.Count, lastPoint);

                // رسم خطوط جهت ایجاد ناحیه
                gp.AddLines(p2.ToArray());


                gp.Clone();
                g.DrawPath(new Pen(serie.Key.SeriColor, 2), gp);
                g.FillPath(new SolidBrush(serie.Key.AreaColor), gp);
            }          

            // نمایش تصویر در کنترل
            pbChart.Image = img;
        }


        private void CesChart_SizeChanged(object sender, EventArgs e)
        {
            GenerateChart();
        }
    }
}
