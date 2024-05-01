namespace Ces.WinForm.UI
{
    partial class CesInputBox
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
            this.btnOk = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.btnCancel = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnExit = new Ces.WinForm.UI.CesButton.CesButton();
            this.txtValue = new Ces.WinForm.UI.CesTextBox();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.BackColor = System.Drawing.SystemColors.Control;
            this.btnOk.CesBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOk.CesBorderColor = System.Drawing.Color.DarkGreen;
            this.btnOk.CesBorderRadius = 15;
            this.btnOk.CesBorderThickness = 1;
            this.btnOk.CesBorderVisible = false;
            this.btnOk.CesCircular = false;
            this.btnOk.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Green;
            this.btnOk.CesFont = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnOk.CesForeColor = System.Drawing.Color.Black;
            this.btnOk.CesIcon = null;
            this.btnOk.CesIconAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.CesMouseDownColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOk.CesMouseOverColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOk.CesShowIcon = false;
            this.btnOk.CesShowText = true;
            this.btnOk.CesText = "Ok";
            this.btnOk.CesTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Location = new System.Drawing.Point(412, 120);
            this.btnOk.Margin = new System.Windows.Forms.Padding(10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(60, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.CesBackColor = System.Drawing.Color.Orange;
            this.btnCancel.CesBorderColor = System.Drawing.Color.Chocolate;
            this.btnCancel.CesBorderRadius = 15;
            this.btnCancel.CesBorderThickness = 1;
            this.btnCancel.CesBorderVisible = false;
            this.btnCancel.CesCircular = false;
            this.btnCancel.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Orange;
            this.btnCancel.CesFont = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCancel.CesForeColor = System.Drawing.Color.Black;
            this.btnCancel.CesIcon = null;
            this.btnCancel.CesIconAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.CesMouseDownColor = System.Drawing.Color.Orange;
            this.btnCancel.CesMouseOverColor = System.Drawing.Color.SandyBrown;
            this.btnCancel.CesShowIcon = false;
            this.btnCancel.CesShowText = true;
            this.btnCancel.CesText = "Cancel";
            this.btnCancel.CesTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(326, 120);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(2, 2);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(481, 35);
            this.pnlTitle.TabIndex = 2;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            this.pnlTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseMove);
            this.pnlTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseUp);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.CesBorderThickness = 1;
            this.btnExit.CesBorderVisible = false;
            this.btnExit.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = global::Ces.WinForm.UI.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(439, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 35);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtValue
            // 
            this.txtValue._initialControlHeight = 0;
            this.txtValue.CesAutoHeight = true;
            this.txtValue.CesBackColor = System.Drawing.Color.White;
            this.txtValue.CesBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtValue.CesBorderRadius = 15;
            this.txtValue.CesBorderThickness = 1;
            this.txtValue.CesFocusColor = System.Drawing.Color.Beige;
            this.txtValue.CesHasFocus = false;
            this.txtValue.CesHasNotification = false;
            this.txtValue.CesIcon = null;
            this.txtValue.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            this.txtValue.CesNotificationColor = System.Drawing.Color.Red;
            this.txtValue.CesPadding = new System.Windows.Forms.Padding(3);
            this.txtValue.CesShowIcon = false;
            this.txtValue.CesShowTitle = true;
            this.txtValue.CesTitleAutoHeight = false;
            this.txtValue.CesTitleAutoWidth = false;
            this.txtValue.CesTitleBackground = true;
            this.txtValue.CesTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtValue.CesTitleHeight = 10;
            this.txtValue.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left;
            this.txtValue.CesTitleText = "Enter Value";
            this.txtValue.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            this.txtValue.CesTitleTextColor = System.Drawing.Color.Black;
            this.txtValue.CesTitleWidth = 80;
            this.txtValue.Location = new System.Drawing.Point(13, 65);
            this.txtValue.Name = "txtValue";
            this.txtValue.Padding = new System.Windows.Forms.Padding(3);
            this.txtValue.Size = new System.Drawing.Size(459, 35);
            this.txtValue.TabIndex = 3;
            // 
            // CesInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 170);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CesInputBox";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CesInputBox";
            this.Load += new System.EventHandler(this.CesInputBox_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesInputBox_Paint);
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CesButton.CesRoundedButton btnOk;
        private CesButton.CesRoundedButton btnCancel;
        private Panel pnlTitle;
        private CesButton.CesButton btnExit;
        private CesTextBox txtValue;
    }
}