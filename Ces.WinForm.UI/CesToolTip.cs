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




        private int CesDuration { get; set; } = 5;
        private string CesToolTipText { get; set; }
        private bool CesEnableToolTip { get; set; }
        private Point CesControlLocation { get; set; }
        private Size CesControlSize { get; set; }




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
            this.lblText.Text = CesToolTipText;
            this.Location = new Point(CesControlLocation.X , CesControlLocation.Y + CesControlSize.Height + 5);

            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(CesDuration * 1000);
            });

            this.Dispose();
        }

        public static void CesAddToolTipHandler(object sender)
        {
            if (((CesButton.CesButton)sender).CesEnableToolTip == false)
                ((CesButton.CesButton)sender).MouseEnter -= new EventHandler(CesToolTip.CesOnMouseEnter);
            else
                ((CesButton.CesButton)sender).MouseEnter += new EventHandler(CesToolTip.CesOnMouseEnter);
        }

        public static void CesOnMouseEnter(object sender, EventArgs e)
        {
            var tt = new CesToolTip()
            {
                CesToolTipText = ((CesButton.CesButton)sender).CesToolTipText,
                CesEnableToolTip = ((CesButton.CesButton)sender).CesEnableToolTip,
                CesControlLocation = ((CesButton.CesButton)sender).PointToScreen(new Point()),
                CesControlSize = ((CesButton.CesButton)sender).Size,
            };

            if (tt.CesEnableToolTip)
                tt.Show();
        }


    }
}
