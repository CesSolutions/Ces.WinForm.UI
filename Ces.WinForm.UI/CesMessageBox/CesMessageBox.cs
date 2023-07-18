namespace Ces.WinForm.UI.CesMessageBox
{
    internal partial class CesMessageBox : CesFormBase
    {


        private CesMessageBoxOptions options;
        private bool IsMouseDown { get; set; }
        private Point CurrentMousePosition { get; set; }



        public CesMessageBox(CesMessageBoxOptions? cesMessageBoxOptions = null)
        {
            InitializeComponent();

            options = cesMessageBoxOptions ?? new CesMessageBoxOptions();
        }

        private void CesMessageBox_Load(object sender, EventArgs e)
        {
            this.TopMost = options.TopMost;
            this.lblTitle.Text = options.Title;
            this.lblMessage.Text = options.Message;

            switch (options.Size)
            {
                case CesMessageBoxSizeEnum.Small:
                    this.Size = options._small;
                    break;
                case CesMessageBoxSizeEnum.Medium:
                    this.Size = options._medium;
                    break;
                case CesMessageBoxSizeEnum.Large:
                    this.Size = options._large;
                    break;
                default:
                    break;
            }

            switch (options.Icon)
            {
                case CesMessageBoxIconEnum.None:
                    this.pbIcon.Visible = false;
                    break;
                case CesMessageBoxIconEnum.Asterik:
                    this.pbIcon.Image = MessageBoxIcons64.Asterik;
                    break;
                case CesMessageBoxIconEnum.Exclamation:
                    this.pbIcon.Image = MessageBoxIcons64.Exclamation;
                    break;
                case CesMessageBoxIconEnum.HandStop:
                    this.pbIcon.Image = MessageBoxIcons64.HandStop;
                    break;
                case CesMessageBoxIconEnum.Information:
                    this.pbIcon.Image = MessageBoxIcons64.Information;
                    break;
                case CesMessageBoxIconEnum.Question:
                    this.pbIcon.Image = MessageBoxIcons64.Question;
                    break;
                case CesMessageBoxIconEnum.Stop:
                    this.pbIcon.Image = MessageBoxIcons64.Stop;
                    break;
                case CesMessageBoxIconEnum.Success:
                    this.pbIcon.Image = MessageBoxIcons64.Success;
                    break;
                case CesMessageBoxIconEnum.Warning:
                    this.pbIcon.Image = MessageBoxIcons64.Warning;
                    break;
                case CesMessageBoxIconEnum.Error:
                    this.pbIcon.Image = MessageBoxIcons64.Error;
                    break;
                default:
                    break;
            }

            switch (options.Buttons)
            {
                case CesMessageBoxButtonsEnum.Ok:
                    this.btnOk.Visible = true;
                    break;
                case CesMessageBoxButtonsEnum.OkCancel:
                    btnOk.Visible = true;
                    btnCancel.Visible = true;
                    break;
                case CesMessageBoxButtonsEnum.RetryCancel:
                    btnRetry.Visible = true;
                    btnCancel.Visible = true;
                    break;
                case CesMessageBoxButtonsEnum.YesNo:
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    break;
                case CesMessageBoxButtonsEnum.YesNoCancel:
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    btnCancel.Visible = true;
                    break;
                case CesMessageBoxButtonsEnum.AbortRetryIgnore:
                    btnAbort.Visible = true;
                    btnRetry.Visible = true;
                    btnIgnore.Visible = true;
                    break;
                default:
                    break;
            }

            this.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2);
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            IsMouseDown = true;
            CurrentMousePosition = new Point(e.Location.X, e.Location.Y);
        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown)
                return;

            this.Left = this.Left + (e.X - CurrentMousePosition.X);
            this.Top = this.Top + (e.Y - CurrentMousePosition.Y);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(options.Message);
        }
    }
}
