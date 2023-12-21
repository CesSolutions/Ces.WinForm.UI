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
    [ToolboxItem(false)]
    public partial class CesGannChartTaskItem : UserControl
    {
        public CesGannChartTaskItem()
        {
            InitializeComponent();
            SetValues();
        }

        private CesGanttChartTaskProperty? cesGanttChartTaskProperty { get; set; } = null;
        public CesGanttChartTaskProperty? CesGanttChartTaskProperty
        {
            get { return cesGanttChartTaskProperty; }
            set
            {
                cesGanttChartTaskProperty = value;
                SetValues();
            }
        }


        private IList<CesGanttChartTaskProperty> CesChildTaskList { get; set; }
            = new List<CesGanttChartTaskProperty>();

        private void btnToggleChildTask_Click(object sender, EventArgs e)
        {
            //if (TotalSubTask == 0)
            //    return;

            //if (this.Height == 30)
            //    this.Height = 30 + (TotalSubTask * 30);
            //else
            //    this.Height = 30;
        }

        private void SetValues()
        {
            this.lblId.Text = CesGanttChartTaskProperty == null ? string.Empty : CesGanttChartTaskProperty.Id;
            this.lblTitle.Text = CesGanttChartTaskProperty == null ? string.Empty : CesGanttChartTaskProperty.Title;
            this.lblStartDate.Text = CesGanttChartTaskProperty == null ? string.Empty : CesGanttChartTaskProperty.StartDate.ToShortDateString();
            this.lblEndDate.Text = CesGanttChartTaskProperty == null ? string.Empty : CesGanttChartTaskProperty.EndDate.ToShortDateString();
            this.lblDuration.Text = CesGanttChartTaskProperty == null ? string.Empty : CesGanttChartTaskProperty.Duration.ToString();
            this.lblWeightFactor.Text = CesGanttChartTaskProperty == null ? string.Empty : CesGanttChartTaskProperty.WeightFactor.ToString();
            this.lblDuration.Text = CesGanttChartTaskProperty == null ? string.Empty : CesGanttChartTaskProperty.Duration.ToString();
            this.lblProgress.Text = CesGanttChartTaskProperty == null ? string.Empty : CesGanttChartTaskProperty.Progerss.ToString();

            //lblSpacer.Width = CesGanttChartTaskProperty == null ? 0 : (30 * CesGanttChartTaskProperty.Level);
            pnlTitle.Padding =new Padding(  CesGanttChartTaskProperty == null ? 0 : (30 * CesGanttChartTaskProperty.Level),0,0,0);
            SetToggleButton();
        }

        public void SetToggleButton()
        {
            if (CesGanttChartTaskProperty == null)
                pictureBox1.Visible = false;
                //btnToggleChildTask.Visible = false;
            else
                pictureBox1.Visible = CesGanttChartTaskProperty.HasChild;          
                //btnToggleChildTask.Visible = CesGanttChartTaskProperty.HasChild;          
        }
    }
}
