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
    public partial class CesGannChartTaskItem : UserControl
    {
        public CesGannChartTaskItem()
        {
            InitializeComponent();
            btnToggleChildTask.Text = string.Empty;
            btnToggleChildTask.Enabled = false;
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
                this.lblDuration.Text = value.Progerss.ToString();

                lblSpacer.Width = 30 * (value.Id.ToString().Split('.').Length - 1);
                lblTitle.Width -= 30 * (value.Id.ToString().Split('.').Length - 1);
            }
        }


        private IList<CesGanttChartTaskProperty> CesChildTaskList { get; set; }
            = new List<CesGanttChartTaskProperty>();


        public void AddChildTask(CesGanttChartTaskProperty task)
        {
            var subTask = new CesGannChartTaskItem();
            subTask.Dock = DockStyle.Top;
            subTask.cesGanttChartTaskProperty = task;

            foreach (CesGannChartTaskItem current in pnlChildTask.Controls)
            {
                if (current.cesGanttChartTaskProperty.Id == task.Id)
                {
                    return;
                }
            }

            pnlChildTask.Controls.Add(subTask);
            pnlChildTask.Visible = true;
            this.Height = (pnlChildTask.Controls.Count + 1) * 30;
            SetToggleButton();
        }

        private void btnToggleChildTask_Click(object sender, EventArgs e)
        {
            if (pnlChildTask.Controls.Count == 0)
                return;

            if (!pnlChildTask.Visible)
            {
                pnlChildTask.Visible = true;
                this.Height = (pnlChildTask.Controls.Count + 1) * 30;
            }
            else
            {
                pnlChildTask.Visible = false;
                this.Height = 30;
            }
        }

        private void SetToggleButton()
        {
            if (pnlChildTask.Controls.Count == 0)
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
    }
}
