using System.ComponentModel;

namespace Ces.WinForm.UI.CesCalendar
{
    /// <summary>
    /// پانل
    /// pnlCalendarHolder
    /// به این دلیل اضافه شده که تقویم در مختصات -2 از چپ و بالا در آن
    /// قرار گیرد تا حاشیه تقویم دیده نشود. چون تقویم ویژگی حذف حاشیه
    /// را ندارد. این کار به ظاهر تقویم کمک میکند
    /// </summary>
    [ToolboxItem(true)]
    public partial class CesCalendar2 : Infrastructure.CesControlBase
    {
        public event EventHandler<Ces.WinForm.UI.CesCalendar.Events.CesSelectionEvent> CesSelectionChanged;
        public event EventHandler<Ces.WinForm.UI.CesCalendar.Events.CesSelectionEvent> CesDateSelected;
        public event EventHandler<Ces.WinForm.UI.CesCalendar.Events.CesSelectionEvent> CesStartDateChanged;
        public event EventHandler<Ces.WinForm.UI.CesCalendar.Events.CesSelectionEvent> CesEndDateChanged;

        private Color currentBorderColor;

        public CesCalendar2()
        {
            InitializeComponent();
            ChildContainer = this.pnlContainer;
            cesMonthCalendar = this.MonthCalendar;
        }

        private MonthCalendar cesMonthCalendar;
        [System.ComponentModel.Category("Ces Calendar")]
        public MonthCalendar CesMonthCalendar
        {
            get { return cesMonthCalendar; }
            set { cesMonthCalendar = value; }
        }

        private DateTime? cesStartDate = DateTime.Now;
        [System.ComponentModel.Category("Ces Calendar")]
        public DateTime? CesStartDate
        {
            get { return cesStartDate; }
            set
            {
                cesStartDate = value;

                CesStartDateChanged?.Invoke(this, new UI.CesCalendar.Events.CesSelectionEvent
                {
                    Start = value,
                    End = CesEndDate,
                });
            }
        }

        private DateTime? cesEndDate = DateTime.Now;
        [System.ComponentModel.Category("Ces Calendar")]
        public DateTime? CesEndDate
        {
            get { return cesEndDate; }
            set
            {
                cesEndDate = value;

                CesEndDateChanged?.Invoke(this, new UI.CesCalendar.Events.CesSelectionEvent
                {
                    Start = CesStartDate,
                    End = value
                });
            }
        }

        #region Override Methods

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
            {
                CesBorderColor = currentBorderColor;
            }
            else
            {
                currentBorderColor = CesBorderColor;
                CesBorderColor = Color.Silver;
            }
        }

        #endregion Override Methods

        private void CesCalendar2_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }

        private void pnlContainer_Resize(object sender, EventArgs e)
        {
            pnlCalendarHolder.Left = pnlContainer.Width / 2 - pnlCalendarHolder.Width / 2;
            pnlCalendarHolder.Top = pnlContainer.Height / 2 - pnlCalendarHolder.Height / 2;
        }

        private void MonthCalendar_Resize(object sender, EventArgs e)
        {
            pnlCalendarHolder.Width = MonthCalendar.Width - 4;
            pnlCalendarHolder.Height = MonthCalendar.Height - 4;
            MonthCalendar.Left = -2;
            MonthCalendar.Top = -2;
        }

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.CesStartDate = e.Start;
            this.CesEndDate = e.End;

            CesSelectionChanged?.Invoke(this, new UI.CesCalendar.Events.CesSelectionEvent
            {
                Start = e.Start,
                End = e.End
            });
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.CesStartDate = e.Start;
            this.CesEndDate = e.End;

            CesSelectionChanged?.Invoke(this, new UI.CesCalendar.Events.CesSelectionEvent
            {
                Start = e.Start,
                End = e.End
            });
        }
    }
}
