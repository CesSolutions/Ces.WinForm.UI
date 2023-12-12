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
    public partial class CesTimePickerPopup : Ces.WinForm.UI.CesForm.CesForm
    {
        public delegate void TimePickerPopupClosed();
        public event TimePickerPopupClosed TimePickerPopupClosedEventHandler;


        public CesTimePickerPopup()
        {
            InitializeComponent();
            gHour = pnlHour.CreateGraphics();
            gMinute = pnlMinute.CreateGraphics();
        }

        private Graphics gHour;
        private Graphics gMinute;
        private bool HourSelected { get; set; }
        private bool MinuteSelected { get; set; }

        public string SelectedHour { get; set; }
        public string SelectedMinute { get; set; }
        public bool Use24Format { get; set; }
        public string AMPM { get; set; } = "AM";

        private void SetFocusOnHour(Label control)
        {
            Panel parent = (Panel)control.Parent;
            Point controlLocation = control.Location;
            Size controlSize = control.Size;
            Font controlFont = control.Font;
            string controlText = control.Text;
            Rectangle rect = control.ClientRectangle;

            gHour = pnlHour.CreateGraphics();            
            gHour.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gHour.Clear(parent.BackColor);

            gHour.FillEllipse(
                new SolidBrush(Color.Black),
                new Rectangle(
                    parent.Width / 2 - 3,
                    parent.Height / 2 - 3,
                    6,
                    6));

            gHour.DrawLine(
                new Pen(Color.Black, 1),
                controlLocation.X + controlSize.Width / 2,
                controlLocation.Y + controlSize.Height / 2,
                parent.Width / 2,
                parent.Height / 2);

            using Graphics lbl = control.CreateGraphics();

            lbl.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            lbl.Clear(Color.White);

            lbl.FillEllipse(
                new SolidBrush(Color.Red),
                new Rectangle(
                    0,
                    0,
                    controlSize.Width - 1,
                    controlSize.Height - 1));

            var size = lbl.MeasureString(controlText, controlFont);

            lbl.DrawString(
                controlText,
                controlFont,
                new SolidBrush(Color.Black),
                new PointF(
                    (controlSize.Width / 2) - (size.Width / 2),
                    (controlSize.Height / 2) - (size.Height / 2)));
        }

        private void SetFocusOnMinute(Label control)
        {
            Panel parent = (Panel)control.Parent;
            Point controlLocation = control.Location;
            Size controlSize = control.Size;
            Font controlFont = control.Font;
            string controlText = control.Text;
            Rectangle rect = control.ClientRectangle;

            gMinute = pnlMinute.CreateGraphics();
            gMinute.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gMinute.Clear(parent.BackColor);

            gMinute.FillEllipse(
                new SolidBrush(Color.Black),
                new Rectangle(
                    parent.Width / 2 - 3,
                    parent.Height / 2 - 3,
                    6,
                    6));

            gMinute.DrawLine(
                new Pen(Color.Black, 1),
                controlLocation.X + controlSize.Width / 2,
                controlLocation.Y + controlSize.Height / 2,
                parent.Width / 2,
                parent.Height / 2); 

            using Graphics lbl = control.CreateGraphics();

            lbl.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            lbl.Clear(Color.White);

            lbl.FillEllipse(
                new SolidBrush(Color.Red),
                new Rectangle(
                    0,
                    0,
                    controlSize.Width - 1,
                    controlSize.Height - 1));

            var size = lbl.MeasureString(controlText, controlFont);

            lbl.DrawString(
                controlText,
                controlFont,
                new SolidBrush(Color.Black),
                new PointF(
                    (controlSize.Width / 2) - (size.Width / 2),
                    (controlSize.Height / 2) - (size.Height / 2)));
        }

        private void _MouseEnter(object sender, EventArgs e)
        {
            // اگر ساعت انتخاب شده باشد دیگر نیازی به اجرای کدها نیست مگر آنکه کاربر انتخاب را حذف کند
            if (HourSelected && ((Label)sender).Parent.Name == "pnlHour")
                return;

            if (MinuteSelected && ((Label)sender).Parent.Name == "pnlMinute")
                return;

            if (Use24Format)
            {
                if (((Label)sender).Name == "lblHour1")
                    lblHour13.Visible = false;
                else if (((Label)sender).Name == "lblHour2")
                    lblHour14.Visible = false;
                else if (((Label)sender).Name == "lblHour3")
                    lblHour15.Visible = false;
                else if (((Label)sender).Name == "lblHour4")
                    lblHour16.Visible = false;
                else if (((Label)sender).Name == "lblHour5")
                    lblHour17.Visible = false;
                else if (((Label)sender).Name == "lblHour6")
                    lblHour18.Visible = false;
                else if (((Label)sender).Name == "lblHour7")
                    lblHour19.Visible = false;
                else if (((Label)sender).Name == "lblHour8")
                    lblHour20.Visible = false;
                else if (((Label)sender).Name == "lblHour9")
                    lblHour21.Visible = false;
                else if (((Label)sender).Name == "lblHour10")
                    lblHour22.Visible = false;
                else if (((Label)sender).Name == "lblHour11")
                    lblHour23.Visible = false;
                else if (((Label)sender).Name == "lblHour12")
                    lblHour00.Visible = false;
            }

            if (((Label)sender).Parent.Name == "pnlHour")
                SetFocusOnHour((Label)sender);

            if ( ((Label)sender).Parent.Name == "pnlMinute")
                SetFocusOnMinute((Label)sender);
        }

        private void _Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (!HourSelected && lbl.Name.StartsWith("lblHour"))
            {
                HourSelected = true;
                SelectedHour = lbl.Text;
                btnSelectedHour.CesText = lbl.Text;
                pnlHour.SendToBack();
            }
            else if (!MinuteSelected && lbl.Name.StartsWith("lblMinute"))
            {
                MinuteSelected = true;
                SelectedMinute = lbl.Text;
                btnSelectedMinute.CesText = lbl.Text;
                pnlMinute.SendToBack();
            }
        }

        private void _MouseLeave(object sender, EventArgs e)
        {
            if (HourSelected && ((Label)sender).Parent.Name == "pnlHour")
                return;

            if (!HourSelected && ((Label)sender).Parent.Name == "pnlHour")
            {
                gHour.Clear(Color.White);
                gHour.Dispose();
            }

            if (MinuteSelected && ((Label)sender).Parent.Name == "pnlMinute")
                return;

            if (!MinuteSelected && ((Label)sender).Parent.Name == "pnlMinute")
            {
                gMinute.Clear(Color.White);
                gMinute.Dispose();
            }

            if (Use24Format)
            {
                if (((Label)sender).Name == "lblHour1")
                    lblHour13.Visible = true;
                else if (((Label)sender).Name == "lblHour2")
                    lblHour14.Visible = true;
                else if (((Label)sender).Name == "lblHour3")
                    lblHour15.Visible = true;
                else if (((Label)sender).Name == "lblHour4")
                    lblHour16.Visible = true;
                else if (((Label)sender).Name == "lblHour5")
                    lblHour17.Visible = true;
                else if (((Label)sender).Name == "lblHour6")
                    lblHour18.Visible = true;
                else if (((Label)sender).Name == "lblHour7")
                    lblHour19.Visible = true;
                else if (((Label)sender).Name == "lblHour8")
                    lblHour20.Visible = true;
                else if (((Label)sender).Name == "lblHour9")
                    lblHour21.Visible = true;
                else if (((Label)sender).Name == "lblHour10")
                    lblHour22.Visible = true;
                else if (((Label)sender).Name == "lblHour11")
                    lblHour23.Visible = true;
                else if (((Label)sender).Name == "lblHour12")
                    lblHour00.Visible = true;
            }

            ((Label)sender).BackColor = Color.White;
            ((Label)sender).ForeColor = Color.Black;

            ((Label)sender).Invalidate();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectedHour_Click(object sender, EventArgs e)
        {
            HourSelected = false;
            SelectedHour = string.Empty; ;
            btnSelectedHour.CesText = "-";
            pnlHour.BringToFront();
        }

        private void btnSelectedMinute_Click(object sender, EventArgs e)
        {
            MinuteSelected = false;
            SelectedMinute = string.Empty;
            btnSelectedMinute.CesText = "-";
            pnlMinute.BringToFront();
        }

        private void tbAMPM_Click(object sender, EventArgs e)
        {
            AMPM = tbAMPM.CesToggle ? "PM" : "AM";
        }

        private void CesTimePickerPopup_Load(object sender, EventArgs e)
        {
            tbAMPM.Visible = !Use24Format;

            lblHour13.Visible = Use24Format;
            lblHour14.Visible = Use24Format;
            lblHour15.Visible = Use24Format;
            lblHour16.Visible = Use24Format;
            lblHour17.Visible = Use24Format;
            lblHour18.Visible = Use24Format;
            lblHour19.Visible = Use24Format;
            lblHour20.Visible = Use24Format;
            lblHour21.Visible = Use24Format;
            lblHour22.Visible = Use24Format;
            lblHour23.Visible = Use24Format;
            lblHour00.Visible = Use24Format;
        }
    }
}
