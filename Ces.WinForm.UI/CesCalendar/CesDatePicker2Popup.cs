namespace Ces.WinForm.UI.CesCalendar
{
    public partial class CesDatePicker2Popup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesDatePicker2Popup()
        {
            InitializeComponent();
        }

        public event EventHandler<Ces.WinForm.UI.CesCalendar.Events.CesSelectionEvent> CesSelectionChanged;
        public DateTime? _startDate { get; set; }
        public DateTime? _endDate { get; set; }
        public int _maxSelectionCount { get; set; }

        private void CesDatePicker2Popup_Load(object sender, EventArgs e)
        {
            mc.Left = (this.Width / 2) - (mc.Width / 2);
        }

        private void CesDatePicker2Popup_Shown(object sender, EventArgs e)
        {
            mc.MaxSelectionCount = _maxSelectionCount < 1 ? 1 : _maxSelectionCount;

            if (_startDate.HasValue)
                mc.SelectionStart = _startDate.Value;

            if (_endDate.HasValue)
                mc.SelectionEnd = _endDate.Value;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CesDatePicker2Popup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            this.Dispose();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (CesSelectionChanged is not null)
                CesSelectionChanged.Invoke(this, new UI.CesCalendar.Events.CesSelectionEvent
                {
                    Start = mc.SelectionStart,
                    End = mc.SelectionEnd,
                });
        }
    }
}
