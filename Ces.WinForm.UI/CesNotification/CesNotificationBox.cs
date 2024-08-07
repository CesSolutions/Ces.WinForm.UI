﻿namespace Ces.WinForm.UI.CesNotification
{
    internal partial class CesNotificationBox : Form
    {
        public CesNotificationBox()
        {
            InitializeComponent();
        }

        private Task t;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken token;
        internal CesNotificationOptions options =new();
        private int offsetNotification = 5;

        private void CesNotification_Load(object sender, EventArgs e)
        {
            switch (options.Position)
            {
                case CesNotificationPositionEnum.TopLeft:
                    this.Left = offsetNotification;
                    this.Top =
                        options.BlankLocation is null ?
                        offsetNotification :
                        options.BlankLocation.Value.Y + this.Height + offsetNotification;
                    break;

                case CesNotificationPositionEnum.TopCenter:
                    this.Left =
                        (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.Top =
                        options.BlankLocation is null ?
                        offsetNotification :
                        options.BlankLocation.Value.Y + this.Height + offsetNotification;
                    break;

                case CesNotificationPositionEnum.TopRight:
                    this.Left =
                        Screen.PrimaryScreen.WorkingArea.Width - this.Width - offsetNotification;
                    this.Top =
                        options.BlankLocation is null ?
                        offsetNotification :
                        options.BlankLocation.Value.Y + this.Height + offsetNotification;
                    break;

                case CesNotificationPositionEnum.BottomLeft:
                    this.Left = offsetNotification;
                    this.Top =
                        options.BlankLocation is null ?
                        Screen.PrimaryScreen.WorkingArea.Height - this.Height - offsetNotification :
                        options.BlankLocation.Value.Y - this.Height - offsetNotification;
                    break;

                case CesNotificationPositionEnum.BottomCenter:
                    this.Left =
                        (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.Top =
                        options.BlankLocation is null ?
                        Screen.PrimaryScreen.WorkingArea.Height - this.Height - offsetNotification :
                        options.BlankLocation.Value.Y - this.Height - offsetNotification;
                    break;

                case CesNotificationPositionEnum.BottomRight:
                    this.Left =
                        Screen.PrimaryScreen.WorkingArea.Width - this.Width - offsetNotification;
                    this.Top =
                        options.BlankLocation is null ?
                        Screen.PrimaryScreen.WorkingArea.Height - this.Height - offsetNotification :
                        options.BlankLocation.Value.Y - this.Height - offsetNotification;
                    break;

                case CesNotificationPositionEnum.ScreenCenter:
                    this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
                    this.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2);
                    break;

                default:
                    break;
            }

            this.Opacity = options.Opacity;
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

            if (options.Icon == CesNotificationIconEnum.None)
                this.pbIcon.Visible = false;

            if (options.Icon != CesNotificationIconEnum.None)
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
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (options.CesNotificationOnExit is not null)
                options.CesNotificationOnExit();

            this.Close();
        }

        private void CesNotificationBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        private void CesNotificationBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Ces.WinForm.UI.CesNotification.CesNotification.SetBlankLocation(options.Order);
        }
    }

}
