namespace Ces.WinForm.UI.CesNavigationBars
{
    public partial class CesGridViewNavigationBar : UserControl
    {
        #region EventHandler

        // Help EventHandler

        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesHelpButtonClicked { get; set; }

        // Navigation EventHandler

        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesFirstButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesLastButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesPreviousButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesNextButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesTextChanged { get; set; }

        // Selection EventHandler

        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesSelectAllButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesClearSelectionButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesFilterButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesSortButtonClicked { get; set; }

        // Operation EventHandler

        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesNewButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesDeleteButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesLoadButtonClicked { get; set; }

        // Misc. EventHandler

        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesExportButtonClicked { get; set; }
        public EventHandler<CesNavigationBars.Events.CesNavigationEvent> CesFullscreenButtonClicked { get; set; }

        #endregion EventHadler

        public CesGridViewNavigationBar()
        {
            InitializeComponent();
        }

        #region Properties



        #endregion Properties

        private CesNavigationBars.Events.CesNavigationEvent CreateEvent()
        {
            return new CesNavigationBars.Events.CesNavigationEvent
            {
                TotalRows = 0,
                CurrentRowNumber = 0,
                IsFirst = false,
                IsLast = true
            };
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            CesHelpButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            CesFirstButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            CesPreviousButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CesNextButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            CesLastButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            CesSelectAllButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            CesClearSelectionButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CesNewButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CesDeleteButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            CesLoadButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CesExportButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            CesFullscreenButtonClicked?.Invoke(this, CreateEvent());
        }


        private void txtCurrentRow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CesTextChanged?.Invoke(this, CreateEvent());
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            CesFilterButtonClicked?.Invoke(this, CreateEvent());
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            CesSortButtonClicked?.Invoke(this, CreateEvent());
        }
    }
}
