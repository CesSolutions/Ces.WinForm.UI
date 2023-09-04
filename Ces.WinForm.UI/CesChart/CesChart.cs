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

            var img = new Bitmap(this.Width - 2, this.Height - 2);
            using System.Drawing.Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            float TitleHeight = Options.ChartTitleVisible ? 50 : 0;
            float CategoryHeight = Options.CategoryVisible ? 50 : 0;
            float scaleWidth = Options.ScaleVisible ? 50 : 0;
            float LegendWidth = Options.LegendVisible ? 150 : 0;
            float scaleIndicatorWidth = 5;
            //float gHeight = img.Height - TitleHeight - CategoryHeight;
            float CategoryDistance = 40;

            // تعیین نواحی چارت
            var titleArea = new RectangleF(0, 0, img.Width, TitleHeight);
            var categoryArea = new RectangleF(scaleWidth, img.Height - CategoryHeight, img.Width - scaleWidth-LegendWidth, CategoryHeight);
            var scaleArea = new RectangleF(0, TitleHeight, scaleWidth, img.Height - TitleHeight - CategoryHeight);
            var legendArea = new RectangleF(img.Width - LegendWidth, TitleHeight, LegendWidth, img.Height - TitleHeight - CategoryHeight);
            var chartArea = new RectangleF(scaleWidth, TitleHeight, img.Width - scaleWidth - LegendWidth, img.Height - TitleHeight - CategoryHeight);

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

            int countData = 0;

            foreach (var item in Options.Data)
            {
                // محل رسم ستون نباید از عرض ناحیه چارت بیشتر باشد
                var currentX =  (countData * CategoryDistance) + CategoryDistance;

                if (currentX >= chartArea.Width)
                    break;

                // رسم ستون
                g.DrawLine(
                    new Pen(Color.Red, 10),
                    chartArea.Left + (countData * CategoryDistance) + (CategoryDistance/2),
                    chartArea.Bottom,
                    chartArea.Left + (countData * CategoryDistance) + (CategoryDistance/2),
                    chartArea.Bottom - (item.Value * HeightFactor));

                // نمایش عنوان هر ستون
                var categorySize = g.MeasureString(item.Category, scaleFont);

                // رسم کادر اطراف عنوان
                if (Options.CategoryGridLineVisible)
                {
                    g.DrawRectangle(
                        new Pen(Color.Black, 1),
                            categoryArea.Left + (countData * CategoryDistance),
                            categoryArea.Top,
                            CategoryDistance,
                            CategoryHeight
                            );
                }

                // رسم متن هر ستون
                g.DrawString(
                    item.Category,
                    scaleFont,
                    new SolidBrush(Color.Black),
                    new RectangleF(
                        categoryArea.Left + (countData * CategoryDistance),
                        categoryArea.Top,
                        CategoryDistance,
                        CategoryHeight
                        ));

                countData += 1;
            }

           
            pbChart.Image = img;
        }

        private void CesChart_Load(object sender, EventArgs e)
        {

        }
    }
}
