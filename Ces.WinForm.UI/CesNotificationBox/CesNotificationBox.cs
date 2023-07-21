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
    internal partial class CesNotificationBox : Form
    {
        public CesNotificationBox(CesNotificationOptions? cesNotificationOptions)
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

        private void CesNotification_Load(object sender, EventArgs e)
        {
            switch (options.Position)
            {
                case CesNotificationPositionEnum.TopLeft:
                    this.Left = 0;
                    this.Top = 0;
                    break;
                case CesNotificationPositionEnum.TopCenter:
                    this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.Top = 0;
                    break;
                case CesNotificationPositionEnum.TopRight:
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    this.Top = 0;
                    break;
                case CesNotificationPositionEnum.BottomLeft:
                    this.Left = 0;
                    this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                    break;
                case CesNotificationPositionEnum.BottomCenter:
                    this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                    break;
                case CesNotificationPositionEnum.BottomRight:
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                    break;
                case CesNotificationPositionEnum.ScreenCenter:
                    this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2);
                    break;
                default:
                    break;

            }
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

                        if (lblCountDown.InvokeRequired)
                        {
                            lblCountDown.Invoke(() =>
                            {
                                lblCountDown.Text = "Rmained : " + i.ToString();
                            });
                        }

                        Thread.Sleep(1000);
                    }
                    cancellationTokenSource.Cancel();
                }
            }, token);

            await Task.WhenAll(t);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (options.CesNotificationOnExitHandler is not null)
                options.CesNotificationOnExitHandler();

            this.Close();
        }

        private void CesNotificationBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }

}
