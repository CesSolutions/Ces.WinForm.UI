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

        private void pbOpenTimePopup_Click(object sender, EventArgs e)
        {
            frm = new CesTimePickerPopup();
            frm.Deactivate += new EventHandler(frmDeactivated);
            frm.TimePickerPopupClosedEventHandler += this.OnClose;
            frm.TopMost = true;

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
                this.lblSelectedTime.Text = $"{frm.SelectedHour.PadLeft(2,'0')}:{frm.SelectedMinute.PadLeft(2, '0')}";            
        }

        private void OnClose()
        {
            //var selectedDate = tp.CesSelectedDates.FirstOrDefault();
            //this.CesSelectedDate = selectedDate;
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
    }
}
