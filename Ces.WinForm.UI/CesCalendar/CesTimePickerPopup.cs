﻿namespace Ces.WinForm.UI.CesCalendar
{
    public partial class CesTimePickerPopup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesTimePickerPopup()
        {
            InitializeComponent();

            gHour = pnlHour.CreateGraphics();
            gMinute = pnlMinute.CreateGraphics();
        }

        private Image img = Ces.WinForm.UI.Properties.Resources.CesTimePickerBackground;
        private Font font = new Font(new FontFamily("Segoe UI Semibold"), 10, FontStyle.Bold);
        private Graphics gHour;
        private Graphics gMinute;

        private bool HourSelected { get; set; }
        private bool MinuteSelected { get; set; }

        public Color SelectionColor { get; set; }
        public Color SelectionTextColor { get; set; }
        public string SelectedHour { get; set; }
        public string SelectedMinute { get; set; }
        public bool Use24Format { get; set; }
        public string AMPM { get; set; } = "AM";
        public string HourText { get; set; }
        public string MinuteText { get; set; }
        public bool CompactMode { get; set; }

        private void DrawHourBackground()
        {
            gHour.DrawImage(img, pnlHour.ClientRectangle, pnlHour.ClientRectangle, GraphicsUnit.Pixel);

            if (string.IsNullOrEmpty(HourText))
                return;

            var hourSize = gHour.MeasureString(HourText, font);

            gHour.DrawString(
                HourText,
                font,
                new SolidBrush(Color.Silver),
                new PointF(
                    (pnlHour.Width / 2) - (hourSize.Width / 2),
                    (pnlHour.Height / 2) - (hourSize.Height * 2)));
        }

        private void DrawMinuteBackground()
        {
            gMinute.DrawImage(img, pnlMinute.ClientRectangle, pnlMinute.ClientRectangle, GraphicsUnit.Pixel);

            if (string.IsNullOrEmpty(MinuteText))
                return;

            var minuteSize = gMinute.MeasureString(MinuteText, font);

            gMinute.DrawString(
                MinuteText,
                font,
                new SolidBrush(Color.Silver),
                new PointF(
                    (pnlMinute.Width / 2) - (minuteSize.Width / 2),
                    (pnlMinute.Height / 2) - (minuteSize.Height * 2)));
        }

        private void SetFocusOnHour(Label control, bool initial)
        {
            Panel parent = (Panel)control.Parent;
            Point controlLocation = control.Location;
            Size controlSize = control.Size;
            Font controlFont = control.Font;
            string controlText = control.Text;
            Rectangle rect = control.ClientRectangle;

            gHour = pnlHour.CreateGraphics();
            gHour.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gHour.Clear(Color.White);

            DrawHourBackground();

            if (initial)
                return;

            gHour.FillEllipse(
                new SolidBrush(SelectionColor),
                new Rectangle(
                    parent.Width / 2 - 3,
                    parent.Height / 2 - 3,
                    6,
                    6));

            gHour.DrawLine(
                new Pen(SelectionColor, 1),
                controlLocation.X + controlSize.Width / 2,
                controlLocation.Y + controlSize.Height / 2,
                parent.Width / 2,
                parent.Height / 2);


            using Graphics lbl = control.CreateGraphics();

            lbl.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            lbl.Clear(Color.White);

            lbl.FillEllipse(
                new SolidBrush(SelectionColor),
                new Rectangle(
                    0,
                    0,
                    controlSize.Width - 1,
                    controlSize.Height - 1));

            var size = lbl.MeasureString(controlText, controlFont);

            lbl.DrawString(
                controlText,
                controlFont,
                new SolidBrush(SelectionTextColor),
                new PointF(
                    (controlSize.Width / 2) - (size.Width / 2),
                    (controlSize.Height / 2) - (size.Height / 2)));
        }

        private void SetFocusOnMinute(Label control, bool initial)
        {
            Panel parent = (Panel)control.Parent;
            Point controlLocation = control.Location;
            Size controlSize = control.Size;
            Font controlFont = control.Font;
            string controlText = control.Text;
            Rectangle rect = control.ClientRectangle;

            gMinute = pnlMinute.CreateGraphics();
            gMinute.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gMinute.Clear(Color.White);

            DrawMinuteBackground();

            if (initial)
                return;

            gMinute.FillEllipse(
                new SolidBrush(SelectionColor),
                new Rectangle(
                    parent.Width / 2 - 3,
                    parent.Height / 2 - 3,
                    6,
                    6));

            gMinute.DrawLine(
                new Pen(SelectionColor, 1),
                controlLocation.X + controlSize.Width / 2,
                controlLocation.Y + controlSize.Height / 2,
                parent.Width / 2,
                parent.Height / 2);


            using Graphics lbl = control.CreateGraphics();

            lbl.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            lbl.Clear(Color.White);

            lbl.FillEllipse(
                new SolidBrush(SelectionColor),
                new Rectangle(
                    0,
                    0,
                    controlSize.Width - 1,
                    controlSize.Height - 1));

            var size = lbl.MeasureString(controlText, controlFont);

            lbl.DrawString(
                controlText,
                controlFont,
                new SolidBrush(SelectionTextColor),
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
                SetFocusOnHour((Label)sender, false);

            if (((Label)sender).Parent.Name == "pnlMinute")
                SetFocusOnMinute((Label)sender, false);
        }

        private void _Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (!HourSelected && lbl.Name.StartsWith("lblHour"))
            {
                HourSelected = true;
                SelectedHour = lbl.Text;
                btnSelectedHour.CesText = lbl.Text.PadLeft(2, '0');
                pnlHour.SendToBack();
            }
            else if (!MinuteSelected && lbl.Name.StartsWith("lblMinute"))
            {
                MinuteSelected = true;
                SelectedMinute = lbl.Text;
                btnSelectedMinute.CesText = lbl.Text.PadLeft(2, '0');
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
                DrawHourBackground();
                gHour.Dispose();
            }

            if (MinuteSelected && ((Label)sender).Parent.Name == "pnlMinute")
                return;

            if (!MinuteSelected && ((Label)sender).Parent.Name == "pnlMinute")
            {
                gMinute.Clear(Color.White);
                DrawMinuteBackground();
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
            if (CompactMode)
                this.Size = new Size(283, 380);
            else
                this.Size = new Size(557, 380);

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

        private void pnlHour_Paint(object sender, PaintEventArgs e)
        {
            SetFocusOnHour(lblHour00, true);
        }

        private void pnlMinute_Paint(object sender, PaintEventArgs e)
        {
            SetFocusOnMinute(lblMinute00, true);
        }
    }
}
