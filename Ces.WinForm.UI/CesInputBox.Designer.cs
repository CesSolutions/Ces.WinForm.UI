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
            pnlTitle = new Panel();
            btnExit = new Ces.WinForm.UI.CesButton.CesButton();
            txtValue = new CesTextBox();
            btnOk = new Ces.WinForm.UI.CesButton.CesButton();
            btnCancel = new Ces.WinForm.UI.CesButton.CesButton();
            pnlTitle.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitle
            // 
            pnlTitle.BackColor = Color.FromArgb(64, 64, 64);
            pnlTitle.Controls.Add(btnExit);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Location = new Point(1, 1);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(483, 35);
            pnlTitle.TabIndex = 2;
            pnlTitle.MouseDown += pnlTitle_MouseDown;
            pnlTitle.MouseMove += pnlTitle_MouseMove;
            pnlTitle.MouseUp += pnlTitle_MouseUp;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(64, 64, 64);
            btnExit.CesBorderThickness = 1;
            btnExit.CesBorderVisible = false;
            btnExit.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btnExit.CesEnableToolTip = false;
            btnExit.CesToolTipText = null;
            btnExit.Dock = DockStyle.Right;
            btnExit.FlatAppearance.BorderColor = Color.Firebrick;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.Salmon;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Tomato;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.Black;
            btnExit.Image = Properties.Resources.Exit;
            btnExit.Location = new Point(441, 0);
            btnExit.Margin = new Padding(0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(42, 35);
            btnExit.TabIndex = 0;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // txtValue
            // 
            txtValue._initialControlHeight = 0;
            txtValue.CesAutoHeight = true;
            txtValue.CesBackColor = Color.White;
            txtValue.CesBorderColor = Color.DeepSkyBlue;
            txtValue.CesBorderRadius = 0;
            txtValue.CesBorderThickness = 1;
            txtValue.CesCharacterCasing = CharacterCasing.Normal;
            txtValue.CesFocusColor = Color.Beige;
            txtValue.CesHasFocus = false;
            txtValue.CesHasNotification = false;
            txtValue.CesIcon = null;
            txtValue.CesInputType = CesInputTypeEnum.Any;
            txtValue.CesMaxLength = 0;
            txtValue.CesMultiLine = false;
            txtValue.CesNotificationColor = Color.Red;
            txtValue.CesPadding = new Padding(3);
            txtValue.CesPasswordChar = '\0';
            txtValue.CesPlaceHolderText = null;
            txtValue.CesReadOnly = false;
            txtValue.CesRightToLeft = RightToLeft.No;
            txtValue.CesScrollBar = ScrollBars.None;
            txtValue.CesShowClearButton = false;
            txtValue.CesShowCopyButton = false;
            txtValue.CesShowIcon = false;
            txtValue.CesShowPasteButton = false;
            txtValue.CesShowTitle = true;
            txtValue.CesText = null;
            txtValue.CesTextAlignment = HorizontalAlignment.Left;
            txtValue.CesTheme = Infrastructure.ThemeEnum.White;
            txtValue.CesTitleAutoHeight = false;
            txtValue.CesTitleAutoWidth = false;
            txtValue.CesTitleBackground = true;
            txtValue.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtValue.CesTitleHeight = 10;
            txtValue.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            txtValue.CesTitleText = "Enter Value";
            txtValue.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            txtValue.CesTitleTextColor = Color.White;
            txtValue.CesTitleWidth = 80;
            txtValue.CesWordWrap = false;
            txtValue.Location = new Point(13, 53);
            txtValue.Name = "txtValue";
            txtValue.Padding = new Padding(3);
            txtValue.Size = new Size(459, 35);
            txtValue.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.MediumSeaGreen;
            btnOk.CesBorderThickness = 1;
            btnOk.CesBorderVisible = false;
            btnOk.CesColorTemplate = CesButton.ColorTemplateEnum.Green;
            btnOk.CesEnableToolTip = false;
            btnOk.CesToolTipText = null;
            btnOk.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOk.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.Black;
            btnOk.Location = new Point(382, 98);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 35);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 113, 113);
            btnCancel.CesBorderThickness = 1;
            btnCancel.CesBorderVisible = false;
            btnCancel.CesColorTemplate = CesButton.ColorTemplateEnum.LightRed;
            btnCancel.CesEnableToolTip = false;
            btnCancel.CesToolTipText = null;
            btnCancel.FlatAppearance.BorderColor = Color.Tomato;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 113, 113);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 150, 150);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(286, 98);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 35);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // CesInputBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 145);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(pnlTitle);
            Controls.Add(txtValue);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CesInputBox";
            Padding = new Padding(1);
            StartPosition = FormStartPosition.CenterParent;
            Text = "CesInputBox";
            Load += CesInputBox_Load;
            Paint += CesInputBox_Paint;
            pnlTitle.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private Panel pnlTitle;
        private CesButton.CesButton btnExit;
        private CesTextBox txtValue;
        private CesButton.CesButton btnOk;
        private CesButton.CesButton btnCancel;
    }
}