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
    public partial class CesGanttChart : UserControl
    {
        public CesGanttChart()
        {
            InitializeComponent();
        }

        public IList<CesGanttChartTaskProperty> CesDataSource = new List<CesGanttChartTaskProperty>();


        public bool AddTask(CesGanttChartTaskProperty task)
        {
            if (TaskExist(task.Id))
            {
                MessageBox.Show("Duplicate Task");
                return false;
            }

            CesDataSource.Add(task);
            return true;
        }

        private void AddSubTask(CesGanttChartTaskProperty task)
        {
            if (!AddTask(task))
                return;

            foreach (CesGannChartTaskItem current in flpTask.Controls)
            {
                if (current.CesGanttChartTaskProperty.Id == task.ParntTaskId)
                {
                    current.AddChildTask(task);
                    return;
                }
            }
        }

        private bool TaskExist(string id)
        {
            return CesDataSource.Any(x => x.Id == id);
        }
    }
}
