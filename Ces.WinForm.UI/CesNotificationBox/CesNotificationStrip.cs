using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesNotificationBox
{
    internal partial class CesNotificationStrip : Form
    {
        public CesNotificationStrip(CesNotificationOptions? cesNotificationOptions)
        {
            if (cesNotificationOptions is null)
            {
                options = new CesNotificationOptions();
            }
            else
            {
                options = cesNotificationOptions;
            }

            InitializeComponent();
        }

        private Task t;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken token;
        private CesNotificationOptions options;
        private int offsetNotification = 5;

        private void CesNotification_Load(object sender, EventArgs e)
        {
            if (options.Size is not null)
            {
                this.Size =
                    new Size(
                        Screen.PrimaryScreen.WorkingArea.Width,
                        options.Size.Value.Height);
            }
            else
            {
                this.Size =
                    new Size(
                        Screen.PrimaryScreen.WorkingArea.Width,
                        60);
            }

            if (options.ShowStripBottom)
            {
                this.Location =
                    new Point(
                        0,
                        (options.BlankLocation is null ?
                        Screen.PrimaryScreen.WorkingArea.Height - offsetNotification :
                        options.BlankLocation.Value.Y) - this.Height - offsetNotification);
            }
            else
            {
                this.Location = new Point(
                    0,
                    (options.BlankLocation is not null ?
                    options.BlankLocation.Value.Y + this.Height + offsetNotification :
                    offsetNotification));
            }

            this.Opacity = options.Opacity;
            this.TopMost = true;
            this.BackColor = options.BackColor;
            this.btnExit.BackColor = options.BackColor;
            this.btnExit.FlatAppearance.MouseOverBackColor = options.BackColor;
            this.btnExit.FlatAppearance.MouseDownBackColor = options.BackColor;

            this.lblMessage.Text = options.Message;
            this.btnExit.Visible = options.ShowExitButton;

            if (options.Icon == CesNotificationIconEnum.None)
                this.pbIcon.Visible = false;

            if (options.Icon != CesNotificationIconEnum.None)
                this.pbIcon.Image = CesNotificationBoxIcon.NotificationNotification;
        }

        private async void CesNotification_Shown(object sender, EventArgs e)
        {
            await CountDown();
            this.Dispose();
        }

        private async Task CountDown()
        {
            cancellationTokenSource = new CancellationTokenSource();
            token = cancellationTokenSource.Token;

            t = Task.Run(async () =>
            {
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    for (int i = options.Duration; i >= 0; i--)
                    {
                        if (cancellationTokenSource.IsCancellationRequested)
                            break;

                        //if (i >= options.Duration)
                        //    cancellationTokenSource.Cancel();
                        //if (options.ShowStatusBar && options.ShowRemained)
                        //{
                        //    if (lblCountDown.InvokeRequired)
                        //    {
                        //        lblCountDown.Invoke(() =>
                        //        {
                        //            lblCountDown.Text = "Rmained : " + i.ToString();
                        //        });
                        //    }
                        //}

                        Thread.Sleep(1000);                
                    }
                    cancellationTokenSource.Cancel();
                }
            }, token);

            await Task.WhenAll(t);
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (options.CesNotificationOnExitHandler is not null)
                options.CesNotificationOnExitHandler();

            this.Close();
        }

        private void CesNotificationBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        private void CesNotificationStrip_FormClosed(object sender, FormClosedEventArgs e)
        {
            Ces.WinForm.UI.CesNotificationBox.CesNotification.SetBlankLocation(options.Order);
        }
    }

}
