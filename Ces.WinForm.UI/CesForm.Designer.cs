namespace Ces.WinForm.UI
{
    partial class CesForm
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
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlFormTopContainer = new System.Windows.Forms.Panel();
            this.pnlFormTopBlankContainer = new System.Windows.Forms.Panel();
            this.pnlControlBox = new System.Windows.Forms.Panel();
            this.btnMinimize = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnMaximize = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnExit = new Ces.WinForm.UI.CesButton.CesButton();
            this.pbFormIcon = new System.Windows.Forms.PictureBox();
            this.scFormTop = new System.Windows.Forms.SplitContainer();
            this.pnlFormTopContainer.SuspendLayout();
            this.pnlControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scFormTop)).BeginInit();
            this.scFormTop.Panel1.SuspendLayout();
            this.scFormTop.Panel2.SuspendLayout();
            this.scFormTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFormTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFormTitle.MaximumSize = new System.Drawing.Size(0, 30);
            this.lblFormTitle.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(856, 30);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblFormTitle_MouseDown);
            this.lblFormTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblFormTitle_MouseMove);
            this.lblFormTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblFormTitle_MouseUp);
            // 
            // pnlFormTopContainer
            // 
            this.pnlFormTopContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlFormTopContainer.Controls.Add(this.pnlFormTopBlankContainer);
            this.pnlFormTopContainer.Controls.Add(this.pnlControlBox);
            this.pnlFormTopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormTopContainer.Location = new System.Drawing.Point(0, 30);
            this.pnlFormTopContainer.MaximumSize = new System.Drawing.Size(0, 30);
            this.pnlFormTopContainer.MinimumSize = new System.Drawing.Size(0, 30);
            this.pnlFormTopContainer.Name = "pnlFormTopContainer";
            this.pnlFormTopContainer.Size = new System.Drawing.Size(856, 30);
            this.pnlFormTopContainer.TabIndex = 2;
            // 
            // pnlFormTopBlankContainer
            // 
            this.pnlFormTopBlankContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormTopBlankContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlFormTopBlankContainer.Name = "pnlFormTopBlankContainer";
            this.pnlFormTopBlankContainer.Size = new System.Drawing.Size(721, 30);
            this.pnlFormTopBlankContainer.TabIndex = 3;
            // 
            // pnlControlBox
            // 
            this.pnlControlBox.Controls.Add(this.btnMinimize);
            this.pnlControlBox.Controls.Add(this.btnMaximize);
            this.pnlControlBox.Controls.Add(this.btnExit);
            this.pnlControlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControlBox.Location = new System.Drawing.Point(721, 0);
            this.pnlControlBox.MaximumSize = new System.Drawing.Size(135, 30);
            this.pnlControlBox.MinimumSize = new System.Drawing.Size(135, 30);
            this.pnlControlBox.Name = "pnlControlBox";
            this.pnlControlBox.Size = new System.Drawing.Size(135, 30);
            this.pnlControlBox.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.CesBorderThickness = 1;
            this.btnMinimize.CesBorderVisible = false;
            this.btnMinimize.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::Ces.WinForm.UI.Properties.Resources.Min;
            this.btnMinimize.Location = new System.Drawing.Point(0, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(45, 30);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.CesBorderThickness = 1;
            this.btnMaximize.CesBorderVisible = false;
            this.btnMaximize.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Image = global::Ces.WinForm.UI.Properties.Resources.Max;
            this.btnMaximize.Location = new System.Drawing.Point(45, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(45, 30);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.CesBorderThickness = 1;
            this.btnExit.CesBorderVisible = false;
            this.btnExit.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::Ces.WinForm.UI.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(90, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbFormIcon
            // 
            this.pbFormIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFormIcon.Image = global::Ces.WinForm.UI.Properties.Resources.Max;
            this.pbFormIcon.Location = new System.Drawing.Point(0, 0);
            this.pbFormIcon.Name = "pbFormIcon";
            this.pbFormIcon.Size = new System.Drawing.Size(60, 60);
            this.pbFormIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFormIcon.TabIndex = 3;
            this.pbFormIcon.TabStop = false;
            // 
            // scFormTop
            // 
            this.scFormTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.scFormTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.scFormTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.scFormTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scFormTop.IsSplitterFixed = true;
            this.scFormTop.Location = new System.Drawing.Point(0, 0);
            this.scFormTop.Name = "scFormTop";
            // 
            // scFormTop.Panel1
            // 
            this.scFormTop.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.scFormTop.Panel1.Controls.Add(this.pbFormIcon);
            // 
            // scFormTop.Panel2
            // 
            this.scFormTop.Panel2.Controls.Add(this.pnlFormTopContainer);
            this.scFormTop.Panel2.Controls.Add(this.lblFormTitle);
            this.scFormTop.Size = new System.Drawing.Size(917, 60);
            this.scFormTop.SplitterDistance = 60;
            this.scFormTop.SplitterWidth = 1;
            this.scFormTop.TabIndex = 0;
            // 
            // CesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 586);
            this.Controls.Add(this.scFormTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CesForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CesForm";
            this.Load += new System.EventHandler(this.CesForm_Load);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.CesForm_ControlAdded);
            this.pnlFormTopContainer.ResumeLayout(false);
            this.pnlControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFormIcon)).EndInit();
            this.scFormTop.Panel1.ResumeLayout(false);
            this.scFormTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scFormTop)).EndInit();
            this.scFormTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblFormTitle;
        private Panel pnlFormTopContainer;
        private Panel pnlControlBox;
        private CesButton.CesButton btnMinimize;
        private CesButton.CesButton btnMaximize;
        private CesButton.CesButton btnExit;
        private Panel pnlFormTopBlankContainer;
        private PictureBox pbFormIcon;
        private SplitContainer scFormTop;
    }
}