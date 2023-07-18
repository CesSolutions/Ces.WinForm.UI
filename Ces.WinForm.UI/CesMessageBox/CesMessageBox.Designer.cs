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
            this.btnYes = new Ces.WinForm.UI.CesButton();
            this.btnNo = new Ces.WinForm.UI.CesButton();
            this.btnCancel = new Ces.WinForm.UI.CesButton();
            this.btnCopy = new Ces.WinForm.UI.CesButton();
            this.btnRetry = new Ces.WinForm.UI.CesButton();
            this.btnAbort = new Ces.WinForm.UI.CesButton();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnIgnore = new Ces.WinForm.UI.CesButton();
            this.btnOk = new Ces.WinForm.UI.CesButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.CesBorderThickness = 1;
            this.btnYes.CesBorderVisible = false;
            this.btnYes.CesColorTemplate = Ces.WinForm.UI.Infrastructure.ColorTemplateEnum.None;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.ForeColor = System.Drawing.Color.Black;
            this.btnYes.Location = new System.Drawing.Point(403, 0);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(60, 35);
            this.btnYes.TabIndex = 0;
            this.btnYes.TabStop = false;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.CesBorderThickness = 1;
            this.btnNo.CesBorderVisible = false;
            this.btnNo.CesColorTemplate = Ces.WinForm.UI.Infrastructure.ColorTemplateEnum.None;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.ForeColor = System.Drawing.Color.Black;
            this.btnNo.Location = new System.Drawing.Point(343, 0);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(60, 35);
            this.btnNo.TabIndex = 1;
            this.btnNo.TabStop = false;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.CesBorderThickness = 1;
            this.btnCancel.CesBorderVisible = false;
            this.btnCancel.CesColorTemplate = Ces.WinForm.UI.Infrastructure.ColorTemplateEnum.None;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Chocolate;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(283, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.Transparent;
            this.btnCopy.CesBorderThickness = 1;
            this.btnCopy.CesBorderVisible = false;
            this.btnCopy.CesColorTemplate = Ces.WinForm.UI.Infrastructure.ColorTemplateEnum.None;
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.ForeColor = System.Drawing.Color.Black;
            this.btnCopy.Location = new System.Drawing.Point(0, 0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(60, 35);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.TabStop = false;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.Color.Transparent;
            this.btnRetry.CesBorderThickness = 1;
            this.btnRetry.CesBorderVisible = false;
            this.btnRetry.CesColorTemplate = Ces.WinForm.UI.Infrastructure.ColorTemplateEnum.None;
            this.btnRetry.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRetry.FlatAppearance.BorderColor = System.Drawing.Color.MediumBlue;
            this.btnRetry.FlatAppearance.BorderSize = 0;
            this.btnRetry.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRetry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.ForeColor = System.Drawing.Color.Black;
            this.btnRetry.Location = new System.Drawing.Point(223, 0);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(60, 35);
            this.btnRetry.TabIndex = 4;
            this.btnRetry.TabStop = false;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Visible = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.Transparent;
            this.btnAbort.CesBorderThickness = 1;
            this.btnAbort.CesBorderVisible = false;
            this.btnAbort.CesColorTemplate = Ces.WinForm.UI.Infrastructure.ColorTemplateEnum.None;
            this.btnAbort.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAbort.FlatAppearance.BorderColor = System.Drawing.Color.DarkKhaki;
            this.btnAbort.FlatAppearance.BorderSize = 0;
            this.btnAbort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Khaki;
            this.btnAbort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbort.ForeColor = System.Drawing.Color.Black;
            this.btnAbort.Location = new System.Drawing.Point(163, 0);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(60, 35);
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
            this.pbIcon.Location = new System.Drawing.Point(0, 30);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(100, 149);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIcon.TabIndex = 6;
            this.pbIcon.TabStop = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlBottom.Controls.Add(this.btnCopy);
            this.pnlBottom.Controls.Add(this.btnIgnore);
            this.pnlBottom.Controls.Add(this.btnAbort);
            this.pnlBottom.Controls.Add(this.btnRetry);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnNo);
            this.pnlBottom.Controls.Add(this.btnYes);
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 179);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(523, 35);
            this.pnlBottom.TabIndex = 7;
            // 
            // btnIgnore
            // 
            this.btnIgnore.BackColor = System.Drawing.Color.Transparent;
            this.btnIgnore.CesBorderThickness = 1;
            this.btnIgnore.CesBorderVisible = false;
            this.btnIgnore.CesColorTemplate = Ces.WinForm.UI.Infrastructure.ColorTemplateEnum.None;
            this.btnIgnore.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIgnore.FlatAppearance.BorderColor = System.Drawing.Color.MediumBlue;
            this.btnIgnore.FlatAppearance.BorderSize = 0;
            this.btnIgnore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnIgnore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgnore.ForeColor = System.Drawing.Color.Black;
            this.btnIgnore.Location = new System.Drawing.Point(103, 0);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(60, 35);
            this.btnIgnore.TabIndex = 7;
            this.btnIgnore.TabStop = false;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = false;
            this.btnIgnore.Visible = false;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.CesBorderThickness = 1;
            this.btnOk.CesBorderVisible = false;
            this.btnOk.CesColorTemplate = Ces.WinForm.UI.Infrastructure.ColorTemplateEnum.None;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(463, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(60, 35);
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
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(523, 30);
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
            this.lblMessage.Location = new System.Drawing.Point(100, 30);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(10);
            this.lblMessage.Size = new System.Drawing.Size(423, 149);
            this.lblMessage.TabIndex = 9;
            this.lblMessage.Text = "label1";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CesMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CesBorderThickness = 1F;
            this.ClientSize = new System.Drawing.Size(523, 214);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlBottom);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CesMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CesMessageBox";
            this.Load += new System.EventHandler(this.CesMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CesButton btnYes;
        private CesButton btnNo;
        private CesButton btnCancel;
        private CesButton btnCopy;
        private CesButton btnRetry;
        private CesButton btnAbort;
        private PictureBox pbIcon;
        private Panel pnlBottom;
        private Label lblTitle;
        private Label lblMessage;
        private CesButton btnOk;
        private CesButton btnIgnore;
    }
}