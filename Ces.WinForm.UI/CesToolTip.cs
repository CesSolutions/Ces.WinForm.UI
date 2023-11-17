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
        public int CesControlHashCode { get; set; }

        public static string? CesToolTipText { get; set; }
        public static bool CesEnableToolTip { get; set; }
        public static Point CesControlLocation { get; set; }
        public static Size CesControlSize { get; set; }
        public static IList<int>? CesActiveToolTipList { get; set; }
            = new System.Collections.Generic.List<int>();


        private void CesToolTip_MouseLeave(object sender, EventArgs e)
        {
            CesActiveToolTipList.Remove(CesControlHashCode);
            this.Dispose();
        }

        private void lblText_MouseLeave(object sender, EventArgs e)
        {
            CesActiveToolTipList.Remove(CesControlHashCode);
            this.Dispose();
        }

        private async void CesToolTip_Shown(object sender, EventArgs e)
        {
            this.lblText.Text = CesToolTipText + DateTime.Now.ToLongTimeString();
            this.Location = new Point(CesControlLocation.X, CesControlLocation.Y + CesControlSize.Height + 5);

            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(CesDuration * 1000);
            });

            CesActiveToolTipList.Remove(CesControlHashCode);
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
            CesToolTipText = ((CesButton.CesButton)sender).CesToolTipText;
            CesEnableToolTip = ((CesButton.CesButton)sender).CesEnableToolTip;
            CesControlLocation = ((CesButton.CesButton)sender).PointToScreen(new Point());
            CesControlSize = ((CesButton.CesButton)sender).Size;

            var tt = new CesToolTip();
            tt.CesControlHashCode = ((CesButton.CesButton)sender).GetHashCode();

            if (CesEnableToolTip && !CesActiveToolTipList.Any(x => x == tt.CesControlHashCode))
            {
                CesActiveToolTipList.Add(tt.CesControlHashCode);
                tt.Show();
            }
        }


    }
}
