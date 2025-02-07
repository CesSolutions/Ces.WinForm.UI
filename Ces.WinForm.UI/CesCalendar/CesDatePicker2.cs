﻿using System.ComponentModel;

namespace Ces.WinForm.UI.CesCalendar
{
    [ToolboxItem(true)]
    public partial class CesDatePicker2 : Infrastructure.CesControlBase
    {
        public CesDatePicker2()
        {
            InitializeComponent();
            ChildContainer = this.pnlChildControl;

            this.CesStartDate = DateTime.Today;
            this.CesEndDate = DateTime.Today;            
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

        private DateTime? cesStartDate;
        [System.ComponentModel.Category("Ces Date Picker")]
        public DateTime? CesStartDate
        {
            get { return cesStartDate; }
            set
            {
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

        private bool cesShowInLongFormat = false;
        public bool CesShowInLongFormat
        {
            get { return cesShowInLongFormat; }
            set
            {
                cesShowInLongFormat = value;
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
            frm.StartDate = CesStartDate.Value;
            frm.EndDate = CesEndDate.Value;
            frm.CesBorderColor = this.CesBorderColor;
            frm.Width = this.Width;

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

            this.CesStartDate = e.Start;
            this.CesEndDate = e.End;
        }

        private void ShowSelectedDate()
        {
            //if (value == null)
            //    this.lblSelectedDate.Text = string.Empty;


            //if (CesShowInLongFormat)
            //    this.lblSelectedDate.Text = value.Value.ToLongDateString();
            //else
            //    this.lblSelectedDate.Text = value.Value.ToShortDateString();

            if (CesStartDate == null)
                this.lblSelectedDate.Text = string.Empty;
            else
            {
                if (CesShowInLongFormat)
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
