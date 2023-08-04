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
    public partial class CesDatePicker : UserControl
    {
        public CesDatePicker()
        {
            InitializeComponent();
        }

        Ces.WinForm.UI.CesFormBase frm;
        Ces.WinForm.UI.CesCalendar.CesCalendar cln;

        private void btnShowCalendar_Click(object sender, EventArgs e)
        {
            cln  = new CesCalendar();
            cln.CalenderClosedEventhandler += this.OnClose;
            cln.Dock = DockStyle.Fill;
            cln.CesShowSidePanel = false;
            cln.CesShowWeekNumber = false;
            cln.Location = new Point(0, 0);
            
            if (!string.IsNullOrEmpty(lblSelectedDate.Text))
                cln.CesValuePersian = lblSelectedDate.Text;


            frm = new CesFormBase();
            frm.Deactivate += new EventHandler(frmDeactivated);
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
    }
}
