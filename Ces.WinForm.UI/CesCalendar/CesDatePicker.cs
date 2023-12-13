using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ces.WinForm.UI.Infrastructure;

namespace Ces.WinForm.UI.CesCalendar
{
    [ToolboxItem(true)]
    public partial class CesDatePicker : Infrastructure.CesControlBase
    {
        public CesDatePicker()
        {
            InitializeComponent();
            ChildContainer = this.pnlChildControl;

            cln = new CesCalendar();
            this.CesSelectedDate = cln.GetToday();
        }

        public delegate void CalenderValueChangedEventHandler();
        public event CalenderValueChangedEventHandler CesCalenderValueChanged;

        // This Class Property
        private Ces.WinForm.UI.CesForm.CesForm frm;
        private Ces.WinForm.UI.CesCalendar.CesCalendar cln;

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

        private Ces.WinForm.UI.CesCalendar.SelectedDate cesSelectedDate;
        [System.ComponentModel.Category("Ces Date Picker")]
        public Ces.WinForm.UI.CesCalendar.SelectedDate CesSelectedDate
        {
            get { return cesSelectedDate; }
            set
            {
                cesSelectedDate = value;

                if (cesShowGeregorian)
                    this.lblSelectedDate.Text = value?.Geregorian;
                else
                    this.lblSelectedDate.Text = value?.Persian;
            }
        }

        private bool cesShowGeregorian = false;
        [System.ComponentModel.Category("Ces Date Picker")]
        public bool CesShowGeregorian
        {
            get { return cesShowGeregorian; }
            set
            {
                cesShowGeregorian = value;

                if (value)
                    this.lblSelectedDate.Text = CesSelectedDate?.Geregorian;
                else
                    this.lblSelectedDate.Text = CesSelectedDate?.Persian;
            }
        }

        private void OnClose()
        {
            var selectedDate = cln.CesSelectedDates.FirstOrDefault();
            this.CesSelectedDate = selectedDate;
            frm.Close();

            if (CesCalenderValueChanged is not null)
                CesCalenderValueChanged();
        }

        private void CesDatePicker_Paint(object sender, PaintEventArgs e)
        {
            this.lblSelectedDate.BackColor = CesBackColor;
            this.GenerateBorder(this);
        }

        private void pbOpenCalendar_Click(object sender, EventArgs e)
        {
            cln = new CesCalendar();
            //cln.CalenderClosedEventHandler += this.OnClose;
            cln.Dock = DockStyle.Fill;
            cln.CesShowSidePanel = false;
            cln.CesShowWeekNumber = false;
            cln.Location = new Point(0, 0);

            if (!string.IsNullOrEmpty(CesSelectedDate?.Persian))
                cln.CesValuePersian = CesSelectedDate.Persian;

            frm = new Ces.WinForm.UI.CesForm.CesForm();
            frm.StartPosition = FormStartPosition.Manual;
            frm.CesFormType = CesForm.CesFormTypeEnum.None;
            frm.CesBorderColor = this.CesBorderColor;
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
                datePickerLeftLocation = controlLocation.X  - (frm.Width - this.Width);
            else
                datePickerRightLocation = controlLocation.X  + frm.Width;

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
    }
}
