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
            btnToggleChildTask.Text = string.Empty;
            btnToggleChildTask.Enabled = false;
        }

        private int totalSubTask = 0;
        public int TotalSubTask
        {
            get { return totalSubTask; }
            set
            {
                totalSubTask = value;
                //SetToggleButton();
            }
        }

        private CesGanttChartTaskProperty cesGanttChartTaskProperty { get; set; }
        public CesGanttChartTaskProperty CesGanttChartTaskProperty
        {
            get { return cesGanttChartTaskProperty; }
            set
            {
                cesGanttChartTaskProperty = value;

                this.lblId.Text = value.Id;
                this.lblTitle.Text = value.Title;
                this.lblStartDate.Text = value.StartDate.ToShortDateString();
                this.lblEndDate.Text = value.EndDate.ToShortDateString();
                this.lblDuration.Text = value.Duration.ToString();
                this.lblWeightFactor.Text = value.WeightFactor.ToString();
                this.lblDuration.Text = value.Duration.ToString();
                this.lblProgress.Text = value.Progerss.ToString();

                var itemLevel = string.IsNullOrEmpty(value.ParntTaskId) ? 0 : value.ParntTaskId.ToString().Split('.').Length;
                lblSpacer.Width = 30 * itemLevel;
                //lblTitle.Width -= 30 * itemLevel;
            }
        }


        private IList<CesGanttChartTaskProperty> CesChildTaskList { get; set; }
            = new List<CesGanttChartTaskProperty>();


        public void AddChildTask(CesGannChartTaskItem mainTaskItem, CesGanttChartTaskProperty task)
        {
            var subTask = new CesGannChartTaskItem();
            subTask.Dock = DockStyle.Top;
            subTask.CesGanttChartTaskProperty = task;

            foreach (CesGannChartTaskItem current in mainTaskItem.pnlChildTask.Controls)
            {
                if (current.CesGanttChartTaskProperty.Id == task.Id)
                {
                    return;
                }
            }

            mainTaskItem.pnlChildTask.Controls.Add(subTask);
        }

        private void btnToggleChildTask_Click(object sender, EventArgs e)
        {
            if (TotalSubTask == 0)
                return;

            if (this.Height == 30)
                this.Height = 30 + (TotalSubTask * 30);
            else
                this.Height = 30;
        }

        public void SetItemHeight()
        {
            this.Height = 30 + (TotalSubTask * 30);

            if (TotalSubTask == 0)
            {
                btnToggleChildTask.Text = string.Empty;
                btnToggleChildTask.Enabled = false;
            }
            else
            {
                btnToggleChildTask.Text = "+";
                btnToggleChildTask.Enabled = true;
            }
        }

        private void pnlChildTask_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.BringToFront();
        }
    }
}
