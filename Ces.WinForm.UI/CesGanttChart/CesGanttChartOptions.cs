namespace Ces.WinForm.UI.CesGannChart
{
    public class CesGanttChartTaskProperty
    {
        public bool HasChild { get; set; }
        public int Level { get; private set; } = 0;
        public string ParntTaskId { get; set; } = string.Empty;
        private string id { get; set; } = string.Empty;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                Level = value.Split('.').Length;
            }
        }
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        private DateTime endDate { get; set; }
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                duration = (int)(value - this.StartDate).TotalDays;
            }
        }
        private int duration { get; set; }
        public int Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                endDate = this.StartDate.AddDays(value);
            }
        }
        public float WeightFactor { get; set; } = 0;
        public float Progerss { get; set; } = 0;
        public bool Expand { get; set; } = true;
        public CesGanttChartTaskDetailProperty? Detail { get; set; }
    }

    public class CesGanttChartTaskDetailProperty
    {
        public Color DetailColor { get; set; }
    }
}
