using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesGannChart
{
    public partial class CesGannChartDetailItem : UserControl
    {
        public CesGannChartDetailItem()
        {
            InitializeComponent();
        }

        public Color DetailColor { get; set; }

        private void CesGannChartDetailItem_Paint(object sender, PaintEventArgs e)
        {
            using Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(DetailColor), 0, 0, this.Width, this.Height);
        }
    }
}
