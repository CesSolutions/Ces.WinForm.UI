﻿namespace Ces.WinForm.UI.CesMessageBox
{
    internal partial class CesMessageBox : CesForm.CesForm
    {
        private CesMessageBoxOptions options;
        private string _message;
        private bool IsMouseDown { get; set; }
        private Point CurrentMousePosition { get; set; }



        public CesMessageBox(string message, CesMessageBoxOptions? cesMessageBoxOptions = null)
        {
            InitializeComponent();
            _message = message;
            options = cesMessageBoxOptions ?? new CesMessageBoxOptions();
        }

        private void CesMessageBox_Load(object sender, EventArgs e)
        {
            this.TopMost = options.TopMost;
            this.lblTitle.Text = options.Title;
            this.lblMessage.Text = _message;

            btnOk.TextImageRelation = options.TextImageRelation;
            btnYes.TextImageRelation = options.TextImageRelation;
            btnNo.TextImageRelation = options.TextImageRelation;
            btnCancel.TextImageRelation = options.TextImageRelation;
            btnRetry.TextImageRelation = options.TextImageRelation;
            btnAbort.TextImageRelation = options.TextImageRelation;
            btnIgnore.TextImageRelation = options.TextImageRelation;
            btnCopy.TextImageRelation = options.TextImageRelation;

            if (options.ButtonCaption != null)
            {
                btnOk.Text = options.ButtonCaption.CesMessageBoxOk;
                btnYes.Text = options.ButtonCaption.CesMessageBoxYes;
                btnNo.Text = options.ButtonCaption.CesMessageBoxNo;
                btnCancel.Text = options.ButtonCaption.CesMessageBoxCancel;
                btnRetry.Text = options.ButtonCaption.CesMessageBoxRetry;
                btnAbort.Text = options.ButtonCaption.CesMessageBoxAbort;
                btnIgnore.Text = options.ButtonCaption.CesMessageBoxIgnore;
                btnCopy.Text = options.ButtonCaption.CesMessageBoxCopy;
            }

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
                case CesMessageBoxIconEnum.MessageAsterisk:
                    this.pbIcon.Image = CesMessageBoxIcon.MessageAsterisk;
                    break;
                case CesMessageBoxIconEnum.MessageExclamation:
                    this.pbIcon.Image = CesMessageBoxIcon.MessageExclamation;
                    break;
                case CesMessageBoxIconEnum.MessageHandStop:
                    this.pbIcon.Image = CesMessageBoxIcon.MessageHandStop;
                    break;
                case CesMessageBoxIconEnum.MessageInformation:
                    this.pbIcon.Image = CesMessageBoxIcon.MessageInformation;
                    break;
                case CesMessageBoxIconEnum.MessageQuestion:
                    this.pbIcon.Image = CesMessageBoxIcon.MessageQuestion;
                    break;
                case CesMessageBoxIconEnum.MessageStop:
                    this.pbIcon.Image = CesMessageBoxIcon.MessageStop;
                    break;
                case CesMessageBoxIconEnum.MessageSuccess:
                    this.pbIcon.Image = CesMessageBoxIcon.MessageSuccess;
                    break;
                case CesMessageBoxIconEnum.MessageWarning:
                    this.pbIcon.Image = CesMessageBoxIcon.MessageWarning;
                    break;
                case CesMessageBoxIconEnum.MessageError:
                    this.pbIcon.Image = CesMessageBoxIcon.MessageError;
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

            switch (options.ButtonImage)
            {
                case CesMessageBoxButtonImageEnum.TextOnly:
                    btnOk.Image = null;
                    btnYes.Image = null;
                    btnNo.Image = null;
                    btnCancel.Image = null;
                    btnRetry.Image = null;
                    btnAbort.Image = null;
                    btnIgnore.Image = null;
                    btnCopy.Image = null;
                    break;

                case CesMessageBoxButtonImageEnum.ImageOnly:
                    btnOk.Text = string.Empty;
                    btnYes.Text = string.Empty;
                    btnNo.Text = string.Empty;
                    btnCancel.Text = string.Empty;
                    btnRetry.Text = string.Empty;
                    btnAbort.Text = string.Empty;
                    btnIgnore.Text = string.Empty;
                    btnCopy.Text = string.Empty;

                    btnOk.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxOK;
                    btnYes.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxYes;
                    btnNo.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxNo;
                    btnCancel.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxCancel;
                    btnRetry.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxRetry;
                    btnAbort.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxAbort;
                    btnIgnore.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxIgnore;
                    btnCopy.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxCopy;
                    break;

                case CesMessageBoxButtonImageEnum.TextAndImage:
                    btnOk.Text = options.ButtonCaption?.CesMessageBoxOk;
                    btnYes.Text = options.ButtonCaption?.CesMessageBoxYes; 
                    btnNo.Text = options.ButtonCaption?.CesMessageBoxNo; 
                    btnCancel.Text = options.ButtonCaption?.CesMessageBoxCancel; 
                    btnRetry.Text = options.ButtonCaption?.CesMessageBoxRetry; 
                    btnAbort.Text = options.ButtonCaption?.CesMessageBoxAbort; 
                    btnIgnore.Text = options.ButtonCaption?.CesMessageBoxIgnore;
                    btnCopy.Text = options.ButtonCaption?.CesMessageBoxCopy;

                    btnOk.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxOK;
                    btnYes.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxYes;
                    btnNo.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxNo;
                    btnCancel.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxCancel;
                    btnRetry.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxRetry;
                    btnAbort.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxAbort;
                    btnIgnore.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxIgnore;
                    btnCopy.Image = Ces.WinForm.UI.Properties.Resources.CesMessageBoxCopy;
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
            Clipboard.SetText(_message);
        }
    }
}
