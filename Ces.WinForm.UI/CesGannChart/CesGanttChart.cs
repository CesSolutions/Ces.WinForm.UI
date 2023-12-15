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

        private IList<CesGanttChartTaskProperty> cesDataSource { get; set; } = new List<CesGanttChartTaskProperty>();
        public IList<CesGanttChartTaskProperty> CesDataSource
        {
            get { return cesDataSource; }
            set
            {
                cesDataSource = value;
                LoadDataSource();
            }
        }



        private void LoadDataSource()
        {
            flpTask.SuspendLayout();
            //pnlTaskDetails.SuspendLayout();

            DateTime minDate = CesDataSource.Min(x => x.StartDate);
            DateTime maxDate = CesDataSource.Max(x => x.EndDate);
            int totalDays = (int)(maxDate - minDate).TotalDays;


            flpTask.Controls.Clear();
            //pnlTaskDetails.Controls.Clear();

            int startDay = 0;
            int i = 0;

            foreach (var d in CesDataSource.OrderBy(x => x.Id).ThenBy(x => x.ParntTaskId))
            {
                i++;

                var t = new Ces.WinForm.UI.CesGannChart.CesGannChartTaskItem();
                t.CesGanttChartTaskProperty = d;
                //t.Dock = DockStyle.Top;
                flpTask.Controls.Add(t);

                //startDay = (int)(d.StartDate - minDate).TotalDays;

                //var det = new Ces.WinForm.UI.CesGannChart.CesGannChartDetailItem();

                //det.DetailColor = d.Detail.DetailColor;
                //det.Left = startDay * 50;
                //det.Top = 30 * i;
                //det.Width = d.Duration * 50;
                //det.Height = 30;

                //pnlTaskDetails.Controls.Add(det);
            }

            flpTask.ResumeLayout();
            //pnlTaskDetails.ResumeLayout();
        }

        public bool AddTask(CesGanttChartTaskProperty task)
        {
            if (TaskExist(task.Id))
            {
                MessageBox.Show($"Duplicate Task => {task.Id} = {task.Title}");
                return false;
            }

            CesDataSource.Add(task);

            flpTask.SuspendLayout();

            if (string.IsNullOrEmpty(task.ParntTaskId))
                LoadDataSource();
            else
                AddSubTask(null, task);

            flpTask.ResumeLayout();
            return true;
        }

        private void AddSubTask(CesGannChartTaskItem? mainTaskItem, CesGanttChartTaskProperty task)
        {
            if (mainTaskItem == null)
                foreach (CesGannChartTaskItem current in flpTask.Controls)
                {
                    if (current.pnlChildTask.Controls.Count > 0)
                        AddSubTask(current, task);

                    if (current.CesGanttChartTaskProperty.Id == task.ParntTaskId)
                    {
                        current.AddChildTask(current, task);
                        SetNestedChildTask(task.Id);
                        return;
                    }
                }
            else
                foreach (CesGannChartTaskItem current in mainTaskItem.pnlChildTask.Controls)
                {
                    if (current.pnlChildTask.Controls.Count > 0)
                        AddSubTask(current, task);

                    if (current.CesGanttChartTaskProperty.Id == task.ParntTaskId)
                    {
                        current.AddChildTask(current, task);
                        SetNestedChildTask(task.Id);
                        return;
                    }
                }
        }


        private void SetNestedChildTask(string taskId)
        {
            string[] idSegment = taskId.Split('.');           

            foreach (CesGannChartTaskItem item1 in flpTask.Controls)
            {
                if (item1.CesGanttChartTaskProperty.Id == $"{idSegment[0]}")
                {
                    item1.TotalSubTask = item1.pnlChildTask.Controls.Count;
                    item1.SetItemHeight();

                    foreach (CesGannChartTaskItem item2 in item1.pnlChildTask.Controls)
                    {
                        item2.TotalSubTask = item2.pnlChildTask.Controls.Count;
                        item2.SetItemHeight();
                        item1.TotalSubTask += item2.TotalSubTask;
                        item1.SetItemHeight();

                        foreach (CesGannChartTaskItem item3 in item2.pnlChildTask.Controls)
                        {
                            item3.TotalSubTask = item3.pnlChildTask.Controls.Count;
                            item3.SetItemHeight();
                            item2.TotalSubTask += item3.TotalSubTask;
                            item2.SetItemHeight();
                            item1.TotalSubTask += item3.TotalSubTask;
                            item1.SetItemHeight();

                            foreach (CesGannChartTaskItem item4 in item3.pnlChildTask.Controls)
                            {
                                item4.TotalSubTask = item4.pnlChildTask.Controls.Count;
                                item4.SetItemHeight();
                                item3.TotalSubTask += item4.TotalSubTask;
                                item3.SetItemHeight();
                                item2.TotalSubTask += item4.TotalSubTask;
                                item2.SetItemHeight();
                                item1.TotalSubTask += item4.TotalSubTask;
                                item1.SetItemHeight();

                                foreach (CesGannChartTaskItem item5 in item4.pnlChildTask.Controls)
                                {
                                    item5.TotalSubTask = item5.pnlChildTask.Controls.Count;
                                    item5.SetItemHeight();
                                    item4.TotalSubTask += item5.TotalSubTask;
                                    item4.SetItemHeight();
                                    item3.TotalSubTask += item5.TotalSubTask;
                                    item3.SetItemHeight();
                                    item2.TotalSubTask += item5.TotalSubTask;
                                    item2.SetItemHeight();
                                    item1.TotalSubTask += item5.TotalSubTask;
                                    item1.SetItemHeight();

                                    foreach (CesGannChartTaskItem item6 in item5.pnlChildTask.Controls)
                                    {
                                        item6.TotalSubTask = item6.pnlChildTask.Controls.Count;
                                        item6.SetItemHeight();
                                        item5.TotalSubTask += item6.TotalSubTask;
                                        item5.SetItemHeight();
                                        item4.TotalSubTask += item6.TotalSubTask;
                                        item4.SetItemHeight();
                                        item3.TotalSubTask += item6.TotalSubTask;
                                        item3.SetItemHeight();
                                        item2.TotalSubTask += item6.TotalSubTask;
                                        item2.SetItemHeight();
                                        item1.TotalSubTask += item6.TotalSubTask;
                                        item1.SetItemHeight();
                                    }
                                }
                            }
                        }
                    }
                }
            }

           
        }

        private bool TaskExist(string id)
        {
            return CesDataSource.Any(x => x.Id == id);
        }
    }
}

