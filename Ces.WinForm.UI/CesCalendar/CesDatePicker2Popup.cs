namespace Ces.WinForm.UI.CesCalendar
{
    public partial class CesDatePicker2Popup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesDatePicker2Popup()
        {
            InitializeComponent();
        }

        public event EventHandler<Ces.WinForm.UI.CesCalendar.Events.CesSelectionEvent> CesSelectionChanged;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

        private void CesDatePicker2Popup_Load(object sender, EventArgs e)
        {
            mc.Left = (this.Width / 2) - (mc.Width / 2);
            mc.SelectionStart = StartDate;
            mc.SelectionEnd = EndDate;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CesDatePicker2Popup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            this.Hide();
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

        private void CesDatePicker2Popup_Resize(object sender, EventArgs e)
        {
            //245,212

            
        }
    }
}
