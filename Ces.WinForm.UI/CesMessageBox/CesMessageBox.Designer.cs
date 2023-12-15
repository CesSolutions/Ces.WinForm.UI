namespace Ces.WinForm.UI.CesMessageBox
{
   internal partial class CesMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnYes = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnNo = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnCancel = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnCopy = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnRetry = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnAbort = new Ces.WinForm.UI.CesButton.CesButton();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnIgnore = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnOk = new Ces.WinForm.UI.CesButton.CesButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOptions
            // 
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnYes.CesBorderThickness = 1;
            this.btnYes.CesBorderVisible = false;
            this.btnYes.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnYes.CesEnableToolTip = false;
            this.btnYes.CesToolTipText = null;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Image = global::Ces.WinForm.UI.Properties.Resources.CesMessageBoxYes;
            this.btnYes.Location = new System.Drawing.Point(595, 0);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(60, 50);
            this.btnYes.TabIndex = 0;
            this.btnYes.TabStop = false;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNo.CesBorderThickness = 1;
            this.btnNo.CesBorderVisible = false;
            this.btnNo.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnNo.CesEnableToolTip = false;
            this.btnNo.CesToolTipText = null;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Image = global::Ces.WinForm.UI.Properties.Resources.CesMessageBoxNo;
            this.btnNo.Location = new System.Drawing.Point(535, 0);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(60, 50);
            this.btnNo.TabIndex = 1;
            this.btnNo.TabStop = false;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCancel.CesBorderThickness = 1;
            this.btnCancel.CesBorderVisible = false;
            this.btnCancel.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnCancel.CesEnableToolTip = false;
            this.btnCancel.CesToolTipText = null;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::Ces.WinForm.UI.Properties.Resources.CesMessageBoxCancel;
            this.btnCancel.Location = new System.Drawing.Point(453, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 50);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCopy.CesBorderThickness = 1;
            this.btnCopy.CesBorderVisible = false;
            this.btnCopy.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnCopy.CesEnableToolTip = false;
            this.btnCopy.CesToolTipText = null;
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Image = global::Ces.WinForm.UI.Properties.Resources.CesMessageBoxCopy;
            this.btnCopy.Location = new System.Drawing.Point(0, 0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(78, 50);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.TabStop = false;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRetry.CesBorderThickness = 1;
            this.btnRetry.CesBorderVisible = false;
            this.btnRetry.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnRetry.CesEnableToolTip = false;
            this.btnRetry.CesToolTipText = null;
            this.btnRetry.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRetry.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnRetry.FlatAppearance.BorderSize = 0;
            this.btnRetry.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRetry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.ForeColor = System.Drawing.Color.White;
            this.btnRetry.Image = global::Ces.WinForm.UI.Properties.Resources.CesMessageBoxRetry;
            this.btnRetry.Location = new System.Drawing.Point(377, 0);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(76, 50);
            this.btnRetry.TabIndex = 4;
            this.btnRetry.TabStop = false;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Visible = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAbort.CesBorderThickness = 1;
            this.btnAbort.CesBorderVisible = false;
            this.btnAbort.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnAbort.CesEnableToolTip = false;
            this.btnAbort.CesToolTipText = null;
            this.btnAbort.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAbort.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnAbort.FlatAppearance.BorderSize = 0;
            this.btnAbort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAbort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbort.ForeColor = System.Drawing.Color.White;
            this.btnAbort.Image = global::Ces.WinForm.UI.Properties.Resources.CesMessageBoxAbort;
            this.btnAbort.Location = new System.Drawing.Point(301, 0);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(76, 50);
            this.btnAbort.TabIndex = 3;
            this.btnAbort.TabStop = false;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Visible = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // pbIcon
            // 
            this.pbIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbIcon.Location = new System.Drawing.Point(1, 31);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(100, 132);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIcon.TabIndex = 6;
            this.pbIcon.TabStop = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlBottom.Controls.Add(this.btnCopy);
            this.pnlBottom.Controls.Add(this.btnIgnore);
            this.pnlBottom.Controls.Add(this.btnAbort);
            this.pnlBottom.Controls.Add(this.btnRetry);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnNo);
            this.pnlBottom.Controls.Add(this.btnYes);
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(1, 163);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(715, 50);
            this.pnlBottom.TabIndex = 7;
            // 
            // btnIgnore
            // 
            this.btnIgnore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIgnore.CesBorderThickness = 1;
            this.btnIgnore.CesBorderVisible = false;
            this.btnIgnore.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnIgnore.CesEnableToolTip = false;
            this.btnIgnore.CesToolTipText = null;
            this.btnIgnore.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIgnore.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnIgnore.FlatAppearance.BorderSize = 0;
            this.btnIgnore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIgnore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgnore.ForeColor = System.Drawing.Color.White;
            this.btnIgnore.Image = global::Ces.WinForm.UI.Properties.Resources.CesMessageBoxIgnore;
            this.btnIgnore.Location = new System.Drawing.Point(218, 0);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(83, 50);
            this.btnIgnore.TabIndex = 7;
            this.btnIgnore.TabStop = false;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = false;
            this.btnIgnore.Visible = false;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOk.CesBorderThickness = 1;
            this.btnOk.CesBorderVisible = false;
            this.btnOk.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnOk.CesEnableToolTip = false;
            this.btnOk.CesToolTipText = null;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Image = global::Ces.WinForm.UI.Properties.Resources.CesMessageBoxOK;
            this.btnOk.Location = new System.Drawing.Point(655, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(60, 50);
            this.btnOk.TabIndex = 6;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblTitle.Location = new System.Drawing.Point(1, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(715, 30);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Message Box";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseUp);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(101, 31);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(10);
            this.lblMessage.Size = new System.Drawing.Size(615, 132);
            this.lblMessage.TabIndex = 9;
            this.lblMessage.Text = "...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CesMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CesBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CesBorderThickness = 1;
            this.CesFormType = Ces.WinForm.UI.CesForm.CesFormTypeEnum.None;
            this.CesMaximizeButtonVisible = false;
            this.CesMinimizeButtonVisible = false;
            this.CesOptionButtonVisible = false;
            this.ClientSize = new System.Drawing.Size(717, 214);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlBottom);
            this.Name = "CesMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CesMessageBox";
            this.Load += new System.EventHandler(this.CesMessageBox_Load);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.pbIcon, 0);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CesButton.CesButton btnYes;
        private CesButton.CesButton btnNo;
        private CesButton.CesButton btnCancel;
        private CesButton.CesButton btnCopy;
        private CesButton.CesButton btnRetry;
        private CesButton.CesButton btnAbort;
        private PictureBox pbIcon;
        private Panel pnlBottom;
        private Label lblTitle;
        private Label lblMessage;
        private CesButton.CesButton btnOk;
        private CesButton.CesButton btnIgnore;
    }
}