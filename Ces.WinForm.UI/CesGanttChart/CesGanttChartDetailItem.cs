using System.ComponentModel;

namespace Ces.WinForm.UI.CesGannChart
{
    [ToolboxItem(false)]
    public partial class CesGanttChartDetailItem : UserControl
    {
        public CesGanttChartDetailItem()
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
