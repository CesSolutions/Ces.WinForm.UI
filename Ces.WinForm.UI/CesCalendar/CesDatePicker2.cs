using Ces.WinForm.UI.Infrastructure;
using System.ComponentModel;

namespace Ces.WinForm.UI.CesCalendar
{
    [ToolboxItem(true)]
    public partial class CesDatePicker2 : Infrastructure.CesControlBase
    {
        public CesDatePicker2()
        {
            InitializeComponent();
            ChildContainer = this.pnlChildControl;
            CesStartDate = DateTime.Now;
        }

        public event EventHandler<Ces.WinForm.UI.CesCalendar.Events.CesSelectionEvent> CesSelectionChanged;

        private CesDatePicker2Popup frm;
        private Color currentBorderColor;

        // Properties
        private bool cesAlignToRight = false;
        [System.ComponentModel.Category("Ces Date Picker")]
        public bool CesAlignToRight
        {
            get { return cesAlignToRight; }
            set
            {
                cesAlignToRight = value;
            }
        }

        private bool cesAlwaysToday = true;
        [System.ComponentModel.Category("Ces Date Picker")]
        [System.ComponentModel.Description("To set new StartDate, set value to false")]
        public bool CesAlwaysToday
        {
            get { return cesAlwaysToday; }
            set
            {
                if (value)
                    CesStartDate = DateTime.Now;

                cesAlwaysToday = value;
            }
        }

        private DateTime? cesStartDate;
        [System.ComponentModel.Category("Ces Date Picker")]
        public DateTime? CesStartDate
        {
            get { return cesStartDate; }
            set
            {
                if (CesAlwaysToday)
                    cesStartDate = DateTime.Now;
                else
                    cesStartDate = value;

                ShowSelectedDate();
            }
        }

        private DateTime? cesEndDate;
        [System.ComponentModel.Category("Ces Date Picker")]
        public DateTime? CesEndDate
        {
            get { return cesEndDate; }
            set
            {
                cesEndDate = value;
            }
        }

        private bool cesShowLongFormat = false;
        [System.ComponentModel.Category("Ces Date Picker")]
        public bool CesShowLongFormat
        {
            get { return cesShowLongFormat; }
            set
            {
                cesShowLongFormat = value;
                ShowSelectedDate();
            }
        }

        private void CesDatePicker2_Paint(object sender, PaintEventArgs e)
        {
            this.lblSelectedDate.BackColor = CesBackColor;
            this.GenerateBorder(this);
        }

        private void pbOpenCalendar_Click(object sender, EventArgs e)
        {
            frm = new CesDatePicker2Popup();
            frm.CesSelectionChanged += OnApplyClick;
            frm.StartPosition = FormStartPosition.Manual;
            frm.CesFormType = CesForm.CesFormTypeEnum.None;
            frm.CesBorderColor = this.CesBorderColor;
            frm.CesShowResizeIcon = false;
            frm.CesBorderThickness = 1;
            frm.TopMost = true;
            frm.StartDate = CesStartDate;
            frm.EndDate = CesEndDate;
            frm.CesBorderColor = this.CesBorderColor;
            frm.Width = this.Width;

            frm.PopupLocation(this, true, frm.Size, CesAlignToRight);
            frm.ShowDialog();
        }

        private void OnApplyClick(object sender, WinForm.UI.CesCalendar.Events.CesSelectionEvent e)
        {
            frm.Close();

            if (CesSelectionChanged is not null)
                CesSelectionChanged.Invoke(this, new UI.CesCalendar.Events.CesSelectionEvent
                {
                    Start = e.Start,
                    End = e.End
                });

            //در اینجا حتما باید متغیر خصوصی مقدار دهی شود
            //چون متغیر عمومی یک شرط را بررسی خواهد کرد
            //که باعث می شود فقط تاریخ از پیش تعیین شده نمایش
            //داده شود. بنابراین اگر کاربر تاریخ جدید انتخاب
            //کرد باید مستقیم در متغیر خصوصی نوشته شود
            this.cesStartDate = e.Start;
            this.cesEndDate = e.End;

            ShowSelectedDate();
        }

        private void ShowSelectedDate()
        {
            if (CesStartDate == null)
                this.lblSelectedDate.Text = string.Empty;
            else
            {
                if (CesShowLongFormat)
                    this.lblSelectedDate.Text = CesStartDate.Value.ToLongDateString();
                else
                    this.lblSelectedDate.Text = CesStartDate.Value.ToShortDateString();
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
                CesBorderColor = currentBorderColor;
            else
            {
                currentBorderColor = CesBorderColor;
                CesBorderColor = Color.Silver;
            }
        }
    }
}
