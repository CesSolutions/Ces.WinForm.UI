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

            cln = new CesCalendar2();
            cln.MonthCalendar.SelectionStart = DateTime.Today;
            this.CesStartDate = DateTime.Today;
            this.CesEndDate = DateTime.Today;
            ShowSelectedDate(cln.MonthCalendar.SelectionStart);
        }

        public event EventHandler<Ces.WinForm.UI.CesCalendar.Events.CesSelectionEvent> CesSelectionChanged;

        // This Class Property
        private Ces.WinForm.UI.CesForm.CesForm frm;
        private Ces.WinForm.UI.CesCalendar.CesCalendar2 cln;
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

        private DateTime? cesStartDate;
        [System.ComponentModel.Category("Ces Date Picker")]
        public DateTime? CesStartDate
        {
            get { return cesStartDate; }
            set
            {
                cesStartDate = value;
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

        private bool cesShowInLongFormat = false;
        public bool CesShowInLongFormat
        {
            get { return cesShowInLongFormat; }
            set
            {
                cesShowInLongFormat = value;
                ShowSelectedDate(cln.MonthCalendar.SelectionStart);
            }
        }

        private void CesDatePicker2_Paint(object sender, PaintEventArgs e)
        {
            this.lblSelectedDate.BackColor = CesBackColor;
            this.GenerateBorder(this);
        }

        private void pbOpenCalendar_Click(object sender, EventArgs e)
        {
            cln = new CesCalendar2();
            cln.CesSelectionChanged += this.OnClose;
            cln.Dock = DockStyle.Fill;
            cln.Location = new Point(0, 0);

            frm = new Ces.WinForm.UI.CesForm.CesForm();
            frm.StartPosition = FormStartPosition.Manual;
            frm.CesFormType = CesForm.CesFormTypeEnum.None;
            frm.CesBorderColor = this.CesBorderColor;
            frm.CesShowResizeIcon = false;
            frm.CesBorderThickness = 1;
            frm.TopMost = true;
            frm.Size = new Size(cln.Width, cln.Height);

            // Check frm size to fit in location. if will be out ot screen,
            // another location shall be select automatically

            var controlLocation = this.PointToScreen(Point.Empty);
            var screenSize = Screen.PrimaryScreen.WorkingArea;
            var datePickerRightLocation = 0;
            var datePickerLeftLocation = 0;
            var datePickerBottomLocation = controlLocation.Y + this.Height + frm.Height;

            // Top Location
            if (datePickerBottomLocation > screenSize.Height)
                frm.Top = controlLocation.Y - frm.Height;
            else
                frm.Top = controlLocation.Y + this.Height;

            // Left Location
            if (CesAlignToRight)
                datePickerLeftLocation = controlLocation.X - (frm.Width - this.Width);
            else
                datePickerRightLocation = controlLocation.X + frm.Width;

            if (CesAlignToRight)
            {
                if (datePickerLeftLocation < 0)
                    frm.Left = 0;
                else
                    frm.Left = controlLocation.X - (frm.Width - this.Width);
            }
            else
            {
                if (datePickerRightLocation > screenSize.Width)
                    frm.Left = screenSize.Width - frm.Width;
                else
                    frm.Left = controlLocation.X;
            }


            // Show
            frm.Controls.Add(cln);
            frm.ShowDialog();
        }

        private void OnClose(object sender, UI.CesCalendar.Events.CesSelectionEvent e)
        {
            frm.Close();

            if (CesSelectionChanged is not null)
                CesSelectionChanged.Invoke(this, new UI.CesCalendar.Events.CesSelectionEvent
                {
                    Start = e.Start,
                    End = e.End
                });

            this.CesStartDate = e.Start;
            this.CesEndDate = e.End;

            ShowSelectedDate(e.Start);
        }

        private void ShowSelectedDate(DateTime? value)
        {
            if (value == null)
                this.lblSelectedDate.Text = string.Empty;


            if (CesShowInLongFormat)
                this.lblSelectedDate.Text = value.Value.ToLongDateString();
            else
                this.lblSelectedDate.Text = value.Value.ToShortDateString();
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
