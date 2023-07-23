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
            if (options.Size is not null)
            {
                this.Size = new Size(options.Size.Value.Width, options.Size.Value.Height);
            }
            else
            {
                this.Size = new Size(400, 110);
            }

            switch (options.Position)
            {
                case CesNotificationPositionEnum.TopLeft:
                    this.Left = 0;
                    this.Top =
                        options.BlankLocation is null ?
                        0 :
                        options.BlankLocation.Value.Y + this.Height; 
                    break;

                case CesNotificationPositionEnum.TopCenter:
                    this.Left = 
                        (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.Top =
                        options.BlankLocation is null ?
                        0 :
                        options.BlankLocation.Value.Y + this.Height;
                    break;

                case CesNotificationPositionEnum.TopRight:
                    this.Left = 
                        Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    this.Top =
                        options.BlankLocation is null ?
                        0 :
                        options.BlankLocation.Value.Y + this.Height;
                    break;

                case CesNotificationPositionEnum.BottomLeft:
                    this.Left = 0;
                    this.Top =
                        options.BlankLocation is null ?
                        Screen.PrimaryScreen.WorkingArea.Height - this.Height :
                        options.BlankLocation.Value.Y - this.Height;
                    break;

                case CesNotificationPositionEnum.BottomCenter:
                    this.Left = 
                        (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.Top =
                        options.BlankLocation is null ?
                        Screen.PrimaryScreen.WorkingArea.Height - this.Height :
                        options.BlankLocation.Value.Y - this.Height;
                    break;

                case CesNotificationPositionEnum.BottomRight:
                    this.Left = 
                        Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    this.Top = 
                        options.BlankLocation is null ? 
                        Screen.PrimaryScreen.WorkingArea.Height - this.Height :
                        options.BlankLocation.Value.Y - this.Height;
                    break;

                case CesNotificationPositionEnum.ScreenCenter:
                    this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2);
                    break;

                default:
                    break;
            }

            this.TopMost = true;
            this.BackColor = options.BackColor;
            this.btnExit.BackColor = options.BackColor;
            this.btnExit.FlatAppearance.MouseOverBackColor = options.BackColor;
            this.btnExit.FlatAppearance.MouseDownBackColor = options.BackColor;
            this.pnlTitle.Visible = options.ShowTitleBar;
            this.lblTitle.Text = options.Title;
            this.lblMessage.Text = options.Message;
            this.btnExit.Visible = options.ShowExitButton;
            this.pnlStatus.Visible = options.ShowStatusBar;
            this.pbIcon.Visible = options.ShowIcon;

            if (options.ShowIcon && options.Icon != CesNotificationIconEnum.None)
                this.pbIcon.Image = CesNotificationBoxIcon.NotificationNotification;

            if (options.ShowStatusBar && options.ShowIssueDateTime)
            {
                this.lblIssueDataTime.Text =
                options.IssueDateTime.ToLongDateString() + " - " +
                options.IssueDateTime.ToLongTimeString();
            }
        }

        private async void CesNotification_Shown(object sender, EventArgs e)
        {
            await CountDown();
            this.Close();
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

                        if (options.ShowStatusBar && options.ShowRemained)
                        {
                            if (lblCountDown.InvokeRequired)
                            {
                                lblCountDown.Invoke(() =>
                                {
                                    lblCountDown.Text = "Rmained : " + i.ToString();
                                });
                            }
                        }

                        Thread.Sleep(1000);
                    }
                    cancellationTokenSource.Cancel();
                }
            }, token);

            await Task.WhenAll(t);
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

        private void CesNotificationBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Ces.WinForm.UI.CesNotificationBox.CesNotification.SetBlankLocation(options.Order);
        }
    }

}
