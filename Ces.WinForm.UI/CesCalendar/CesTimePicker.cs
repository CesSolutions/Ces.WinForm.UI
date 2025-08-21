using Ces.WinForm.UI.Infrastructure;
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
            CesValue = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public delegate void TimePickerValueChangedEventHandler();
        public event TimePickerValueChangedEventHandler CesTimePickerValueChanged;

        private Ces.WinForm.UI.CesCalendar.CesTimePickerPopup frm;
        private string SelectedHour { get; set; }
        private string SelectedMinute { get; set; }
        private string AMPM { get; set; }
        private Color currentBorderColor;

        private bool cesTodayOnStartup { get; set; } = true;
        [System.ComponentModel.Category("Ces Time Picker")]
        public bool CesTodayOnStartup
        {
            get { return cesTodayOnStartup; }
            set
            {
                cesTodayOnStartup = value;
                CesValue = TimeOnly.FromDateTime(DateTime.Now);
            }
        }

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
                ShowValue();
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

            frm.PopupLocation(this, false, frm.Size, CesAlignToRight);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                SelectedHour = string.IsNullOrEmpty(frm.SelectedHour) ? "0" : frm.SelectedHour;
                SelectedMinute = string.IsNullOrEmpty(frm.SelectedMinute) ? "0" : frm.SelectedMinute;
                AMPM = frm.AMPM;

                string result = $"{SelectedHour.PadLeft(2, '0')}:{SelectedMinute.PadLeft(2, '0')} {(CesUse24Format ? string.Empty : " " + AMPM)}";

                CesValue = TimeOnly.Parse(result);

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
            lblSelectedTime.Text =
                CesUse24Format ?
                CesValue.ToString("HH:mm") :
                CesValue.ToString("hh:mm");
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

        private void lblSelectedTime_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CesValue = CesValue.AddMinutes(1);
            else if (e.Button == MouseButtons.Right)
                CesValue = CesValue.AddMinutes(-1);
        }
    }
}
