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
            var img = new Bitmap(500, 300);
            using System.Drawing.Graphics g = Graphics.FromImage(img);

            float TitleHeight = Options.ChartTitleVisible ? 100 : 0;
            float CategoryHeight = 100;
            float YAxisWidth = Options.YAxisVisible ? 50 : 0;
            float gHeight = img.Height - TitleHeight - CategoryHeight;
            float LegendWidth = Options.LegendVisible ? 200 : 0;

            // بدست آوردن ضریب ارتفاع. اگر کاربر ارتفاع چارت را تغییر بدهد، برنامه باید
            // برای رسم در فضای کمتر و یا بیشتر از ضریب استفاده کند
            float HeightFactor = (img.Height - TitleHeight - CategoryHeight) / 100;

            // رسم خط افقی
            g.DrawLine(
                new Pen(Color.Blue, 1),
                YAxisWidth,
                img.Height - CategoryHeight,
                img.Width - YAxisWidth - LegendWidth,
                img.Height - CategoryHeight);

            // رسم خط عمودی
            g.DrawLine(
                new Pen(Color.Blue, 1),
                YAxisWidth,
                TitleHeight,
                YAxisWidth,
                img.Height - CategoryHeight + 8);

            if (Options.YAxisVisible)
            {
                for (int i = 0; i <= 100; i += Options.YAxisScale)
                {
                    g.DrawLine(
                        new Pen(Color.Blue, 1),
                        YAxisWidth,
                        img.Height - CategoryHeight - (i * HeightFactor),
                        YAxisWidth - 8,
                        img.Height - CategoryHeight - (i * HeightFactor));
                }
            }

            if (Options.Data == null)
                return;

            for (int i = 0; i <= Options.Data?.Count - 1; i++)
            {
                g.DrawLine(new Pen(Color.Red, 1), 20 + (i * 50), panel1.Height - 10, 20 + (i * 50), panel1.Height - 10 - Options.Data[i].Value);
            }

            pictureBox1.Image = img;
        }

        private void CesChart_Load(object sender, EventArgs e)
        {

        }
    }
}
