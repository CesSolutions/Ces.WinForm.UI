using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesCalendar
{
    [ToolboxItem(true)]
    public partial class CesTimePicker : Ces.WinForm.UI.Infrastructure.CesControlBase
    {
        public CesTimePicker()
        {
            InitializeComponent();
            this.ChildContainer = this.pnlChildControl;
        }

        // This Class Property
        private Ces.WinForm.UI.CesCalendar.CesTimePickerPopup frm;
        private string SelectedHour { get; set; }
        private string SelectedMinute { get; set; }
        private string AMPM { get; set; }


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

        public TimeOnly cesValue { get; set; }
        [System.ComponentModel.Category("Ces Time Picker")]
        public TimeOnly CesValue
        {
            get { return cesValue; }
            set
            {
                cesValue = value;
            }
        }

        public bool cesUse24Format { get; set; } = true;
        [System.ComponentModel.Category("Ces Time Picker")]
        public bool CesUse24Format
        {
            get { return cesUse24Format; }
            set
            {
                cesUse24Format = value;
            }
        }

        private void pbOpenTimePopup_Click(object sender, EventArgs e)
        {
            frm = new CesTimePickerPopup();
            frm.Deactivate += new EventHandler(frmDeactivated);
            frm.TimePickerPopupClosedEventHandler += this.OnClose;
            frm.TopMost = true;
            frm.Use24Format = CesUse24Format;

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

                DataSetDateTime();
            }
        }

        private void DataSetDateTime()
        {
            string result = $"{frm.SelectedHour.PadLeft(2, '0')}:{frm.SelectedMinute.PadLeft(2, '0')} {(CesUse24Format ? string.Empty : " " + AMPM)}";

            lblSelectedTime.Text = result;
            cesValue = TimeOnly.Parse(result);
        }

        private void OnClose()
        {
            frm.Close();
        }

        private void frmDeactivated(object? sender, EventArgs e)
        {
            frm.Close();
        }

        private void CesTimePicker_Paint(object sender, PaintEventArgs e)
        {
            this.lblSelectedTime.BackColor = CesBackColor;
            this.GenerateBorder(this);
        }

        private void CesTimePicker_Load(object sender, EventArgs e)
        {
            this.lblSelectedTime.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
