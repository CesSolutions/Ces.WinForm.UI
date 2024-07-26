using System.ComponentModel;

namespace Ces.WinForm.UI.CesCalendar
{
    [ToolboxItem(true)]
    public partial class CesTimePicker : Ces.WinForm.UI.Infrastructure.CesControlBase
    {
        public CesTimePicker()
        {
            InitializeComponent();
            this.ChildContainer = this.pnlChildControl;

            var time = DateTime.Now;
            CesValue = new TimeOnly(time.Hour, time.Minute, time.Second);
        }

        public delegate void TimePickerValueChangedEventHandler();
        public event TimePickerValueChangedEventHandler CesTimePickerValueChanged;

        // This Class Property
        private Ces.WinForm.UI.CesCalendar.CesTimePickerPopup frm;
        private string SelectedHour { get; set; }
        private string SelectedMinute { get; set; }
        private string AMPM { get; set; }
        private Color currentBorderColor;

        // Properties
        private bool cesAlignToRight = false;
        [System.ComponentModel.Category("Ces Time Picker")]
        public bool CesAlignToRight
        {
            get { return cesAlignToRight; }
            set
            {
                cesAlignToRight = value;
            }
        }
        
        private TimeOnly cesValue { get; set; }
        [System.ComponentModel.Category("Ces Time Picker")]
        [Browsable(false)]
        public TimeOnly CesValue
        {
            get { return cesValue; }
            set
            {
                cesValue = value;
                ShowValue();
            }
        }

        private bool cesUse24Format { get; set; } = true;
        [System.ComponentModel.Category("Ces Time Picker")]
        public bool CesUse24Format
        {
            get { return cesUse24Format; }
            set
            {
                cesUse24Format = value;
            }
        }

        private Color cesSelectionColor { get; set; } = Color.FromArgb(64, 64, 64);
        [System.ComponentModel.Category("Ces Time Picker")]
        public Color CesSelectionColor
        {
            get { return cesSelectionColor; }
            set
            {
                cesSelectionColor = value;
            }
        }

        private Color cesSelectionTextColor { get; set; } = Color.Gold;
        [System.ComponentModel.Category("Ces Time Picker")]
        public Color CesSelectionTextColor
        {
            get { return cesSelectionTextColor; }
            set
            {
                cesSelectionTextColor = value;
            }
        }

        private string cesHourText { get; set; } = "Hour";
        [System.ComponentModel.Category("Ces Time Picker")]
        public string CesHourText
        {
            get { return cesHourText; }
            set
            {
                cesHourText = value;
            }
        }

        private string cesMinuteText { get; set; } = "Minute";
        [System.ComponentModel.Category("Ces Time Picker")]
        public string CesMinuteText
        {
            get { return cesMinuteText; }
            set
            {
                cesMinuteText = value;
            }
        }

        private bool cesCompactMode { get; set; } = true;
        [System.ComponentModel.Category("Ces Time Picker")]
        public bool CesCompactMode
        {
            get { return cesCompactMode; }
            set
            {
                cesCompactMode = value;
            }
        }

        private void pbOpenTimePopup_Click(object sender, EventArgs e)
        {
            frm = new CesTimePickerPopup();
            frm.CesBorderColor = this.CesBorderColor;
            frm.TopMost = true;
            frm.Use24Format = CesUse24Format;
            frm.SelectionColor = CesSelectionColor;
            frm.SelectionTextColor = CesSelectionTextColor;
            frm.HourText = CesHourText;
            frm.MinuteText = CesMinuteText;
            frm.CompactMode = CesCompactMode;

            // Check frm size to fit in location. if will be out ot screen,
            // another location shall be select automatically

            var controlLocation = this.PointToScreen(Point.Empty);
            var screenSize = Screen.PrimaryScreen.WorkingArea;
            var datePickerRightLocation = 0;
            var datePickerLeftLocation = 0;
            var datePickerBottomLocation = controlLocation.Y + this.Top + frm.Height;

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

            if (frm.ShowDialog() == DialogResult.OK)
            {
                SelectedHour = frm.SelectedHour;
                SelectedMinute = frm.SelectedMinute;
                AMPM = frm.AMPM;

                string result = $"{frm.SelectedHour.PadLeft(2, '0')}:{frm.SelectedMinute.PadLeft(2, '0')} {(CesUse24Format ? string.Empty : " " + AMPM)}";

                lblSelectedTime.Text = result;
                cesValue = TimeOnly.Parse(result);

                if (CesTimePickerValueChanged != null)
                    CesTimePickerValueChanged();
            }
        }

        private void CesTimePicker_Paint(object sender, PaintEventArgs e)
        {
            this.lblSelectedTime.BackColor = CesBackColor;
            this.GenerateBorder(this);
        }

        private void CesTimePicker_Load(object sender, EventArgs e)
        {
        }

        private void ShowValue()
        {
            this.lblSelectedTime.Text = CesValue.ToShortTimeString();
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
