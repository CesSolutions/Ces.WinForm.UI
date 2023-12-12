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
    public partial class CesTimePickerPopup : Form
    {
        public CesTimePickerPopup()
        {
            InitializeComponent();
            g = pnlMinute.CreateGraphics();
        }

        private Graphics g;

        private bool HourSelected { get; set; }
        private bool MinuteSelected { get; set; }


        private void SetFocus(Label control)
        {
            Panel parent = (Panel)control.Parent;
            Point controlLocation = control.Location;
            Size controlSize = control.Size;
            Font controlFont = control.Font;
            string controlText = control.Text;
            Rectangle rect = control.ClientRectangle;

            Graphics g = parent.CreateGraphics();

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(parent.BackColor);

            g.FillEllipse(
                new SolidBrush(Color.Black),
                new Rectangle(
                    parent.Width / 2 - 3,
                    parent.Height / 2 - 3,
                    6,
                    6));

            g.DrawLine(
                new Pen(Color.Black, 1),
                controlLocation.X + controlSize.Width / 2,
                controlLocation.Y + controlSize.Height / 2,
                parent.Width / 2,
                parent.Height / 2);

            g.Dispose();

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

            SetFocus((Label)sender);
        }

        private void _Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Name.StartsWith("lblMinute"))
                MinuteSelected = true;
            else
                HourSelected = true;
        }

        private void _MouseLeave(object sender, EventArgs e)
        {
            if (HourSelected && ((Label)sender).Parent.Name == "pnlHour")
                return;

            if (!HourSelected && ((Label)sender).Parent.Name == "pnlHour")
                g.Clear(Color.White);

            if (MinuteSelected && ((Label)sender).Parent.Name == "pnlMinute")
                return;

            if (!MinuteSelected && ((Label)sender).Parent.Name == "pnlMinute")
                g.Clear(Color.White);


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

            ((Label)sender).BackColor = Color.White;
            ((Label)sender).ForeColor = Color.Black;

            ((Label)sender).Invalidate();
        }
    }
}
