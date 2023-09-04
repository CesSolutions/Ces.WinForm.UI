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
            pictureBox1.Image = null;

            var img = new Bitmap(600, 350);
            using System.Drawing.Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            float TitleHeight = Options.ChartTitleVisible ? 50 : 0;
            float CategoryHeight = Options.CategoryVisible ? 50 : 0;
            float scaleWidth = Options.ScaleVisible ? 50 : 0;
            float LegendWidth = Options.LegendVisible ? 150 : 0;
            //float gHeight = img.Height - TitleHeight - CategoryHeight;
            float CategoryDistance = 30;

            // تعیین نواحی چارت
            var titleArea = new RectangleF(0, 0, img.Width, TitleHeight);
            var categoryArea = new RectangleF(0, img.Height - CategoryHeight, img.Width, CategoryHeight);
            var scaleArea = new RectangleF(0, TitleHeight, scaleWidth, img.Height - TitleHeight - CategoryHeight);
            var legendArea = new RectangleF(img.Width - LegendWidth, TitleHeight, LegendWidth, img.Height - TitleHeight - CategoryHeight);
            var chartArea = new RectangleF(scaleWidth, TitleHeight, img.Width - scaleWidth - LegendWidth, img.Height - TitleHeight - CategoryHeight);

            // تعیین رنگ نواحی
            var titleAreaColor = Color.Orange;
            var categoryAreaColor = Color.Blue;
            var scaleAreaColor = Color.Yellow;
            var legendAreaColor = Color.Gray;
            var chartAreaColor = Color.Khaki;

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

            //// رسم خط افقی
            //g.DrawLine(
            //    new Pen(Color.Blue, 1),
            //    YAxisWidth,
            //    img.Height - CategoryHeight,
            //    img.Width - YAxisWidth - LegendWidth,
            //    img.Height - CategoryHeight);

            //// رسم خط عمودی
            //g.DrawLine(
            //    new Pen(Color.Blue, 1),
            //    YAxisWidth,
            //    TitleHeight,
            //    YAxisWidth,
            //    img.Height - CategoryHeight + 8);

            //var scaleFont = new Font(new FontFamily("Verdana"), 4 * HeightFactor, FontStyle.Regular);
            //if (Options.YAxisVisible)
            //{

            //    for (int i = 0; i <= 100; i += Options.YAxisScale)
            //    {
            //        g.DrawLine(
            //            new Pen(Color.Blue, 1),
            //            YAxisWidth,
            //            img.Height - CategoryHeight - (i * HeightFactor),
            //            YAxisWidth - 8,
            //            img.Height - CategoryHeight - (i * HeightFactor));

            //        if (i > 0)
            //        {
            //            g.DrawLine(
            //                new Pen(Color.LightGray, 1),
            //                YAxisWidth,
            //                img.Height - CategoryHeight - (i * HeightFactor),
            //                img.Width - LegendWidth,
            //                img.Height - CategoryHeight - (i * HeightFactor));
            //        }

            //        var scaleSize = g.MeasureString(i.ToString(), scaleFont);

            //        g.DrawString(
            //            i.ToString(),
            //            scaleFont,
            //            new SolidBrush(Color.Green),
            //            YAxisWidth - 10 - scaleSize.Width,
            //            img.Height - CategoryHeight - (i * HeightFactor) - (scaleSize.Height / 2));
            //    }
            //}

            //if (Options.Data == null)
            //    return;

            //int countData = 0;

            //foreach (var item in Options.Data)
            //{
            //    var a = YAxisWidth + (countData * CategoryDistance) + CategoryDistance;
            //    var b = img.Width - LegendWidth;
            //    if (a > b)
            //        break;

            //    g.DrawLine(
            //        new Pen(Color.Red, 10),
            //        YAxisWidth + (countData * CategoryDistance) + CategoryDistance,
            //        img.Height - CategoryHeight,
            //        YAxisWidth + (countData * CategoryDistance) + CategoryDistance,
            //        img.Height - CategoryHeight - (item.Value * HeightFactor));

            //    var categorySize = g.MeasureString(item.Category, scaleFont);

            //    g.DrawString(
            //        item.Category,
            //        scaleFont,
            //        new SolidBrush(Color.Black),
            //        new RectangleF(
            //            YAxisWidth + (countData * CategoryDistance) + CategoryDistance - (CategoryDistance / 2),
            //            img.Height - CategoryHeight,
            //            CategoryDistance,
            //            CategoryHeight
            //            ));

            //    countData += 1;
            //}


            pictureBox1.Image = img;
        }

        private void CesChart_Load(object sender, EventArgs e)
        {

        }
    }
}
