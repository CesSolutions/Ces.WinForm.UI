using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI
{
    public partial class CesToolTip : Form
    {
        public CesToolTip()
        {
            InitializeComponent();
        }

        private int cesDuration { get; set; } = 5;
        private string cesToolTipText { get; set; }


        private void CesToolTip_MouseLeave(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblText_MouseLeave(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void CesToolTip_Shown(object sender, EventArgs e)
        {
            this.lblText.Text = cesToolTipText;
            this.Location = new Point(Cursor.Position.X + 5, Cursor.Position.Y + 10);

            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(cesDuration * 1000);
            });

            this.Dispose();
        }

        public static void CesOnMouseEnter(object sender, EventArgs e)
        {
            var tt = new CesToolTip();
            tt.cesToolTipText = ((CesButton.CesButton)sender).CesToolTipText;
            tt.Show();
        }

     
    }
}
