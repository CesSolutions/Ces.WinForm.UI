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
    public partial class CesDatePicker : UserControl
    {
        public CesDatePicker()
        {
            BorderOptions = new BorderOptions(this);
            TitleOptions = new TitleOptions(this);

            InitializeComponent();
            Redraw();
        }


        // Border and Title Class Property
        public Ces.WinForm.UI.Infrastructure.BorderOptions BorderOptions { get; set; }
        public Ces.WinForm.UI.Infrastructure.TitleOptions TitleOptions { get; set; }

        // This Class Property
        Ces.WinForm.UI.CesFormBase frm;
        Ces.WinForm.UI.CesCalendar.CesCalendar cln;

        private void btnShowCalendar_Click(object sender, EventArgs e)
        {
            cln = new CesCalendar();
            cln.CalenderClosedEventhandler += this.OnClose;
            cln.Dock = DockStyle.Fill;
            cln.CesShowSidePanel = false;
            cln.CesShowWeekNumber = false;
            cln.Location = new Point(0, 0);

            if (!string.IsNullOrEmpty(lblSelectedDate.Text))
                cln.CesValuePersian = lblSelectedDate.Text;


            frm = new CesFormBase();
            frm.Deactivate += new EventHandler(frmDeactivated);
            frm.CesBorderColor = BorderOptions.CesBorderColor;
            frm.CesBorderThickness = 1;
            frm.TopMost = true;
            frm.Size = new Size(cln.Width, cln.Height);
            frm.Left = this.Parent.PointToScreen(Point.Empty).X + this.Left;
            frm.Top = this.Parent.PointToScreen(Point.Empty).Y + this.Top + this.Height;

            frm.Controls.Add(cln);
            frm.Show();
        }

        private void OnClose()
        {
            this.lblSelectedDate.Text = cln.CesSelectedDates.FirstOrDefault()?.Persian;
            frm.Close();
        }

        private void frmDeactivated(object? sender, EventArgs e)
        {
            frm.Close();
        }

        private void CesDatePicker_Load(object sender, EventArgs e)
        {

        }

        public void Redraw()
        {
            this.ArrangeControls(BorderOptions, TitleOptions);

            this.btnShowCalendar.Top = (this.pnlChildControl.Height / 2) - (this.btnShowCalendar.Height / 2);
            this.lblSelectedDate.Top = (this.pnlChildControl.Height / 2) - (this.lblSelectedDate.Height / 2);
        }

        private void CesDatePicker_Paint(object sender, PaintEventArgs e)
        {
            Control? childControl = this.Controls[0];
            if (childControl is not null)
                childControl.BackColor = BorderOptions.CesBackColor;

            this.lblSelectedDate.BackColor = BorderOptions.CesBackColor;

            e.Graphics.GenerateBorder(BorderOptions, TitleOptions);
        }
    }
}
