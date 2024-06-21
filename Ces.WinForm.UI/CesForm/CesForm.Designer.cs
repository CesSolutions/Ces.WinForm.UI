namespace Ces.WinForm.UI.CesForm
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
            this.scFormTop = new System.Windows.Forms.SplitContainer();
            this.btnOptions = new Ces.WinForm.UI.CesButton.CesButton();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlControlBox = new System.Windows.Forms.Panel();
            this.btnMinimize = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnMaximize = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnExit = new Ces.WinForm.UI.CesButton.CesButton();
            this.clBorderTop = new Ces.WinForm.UI.CesLine();
            this.clBorderBottom = new Ces.WinForm.UI.CesLine();
            this.clBorderLeft = new Ces.WinForm.UI.CesLine();
            this.clBorderRight = new Ces.WinForm.UI.CesLine();
            this.pbResizeForm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.scFormTop)).BeginInit();
            this.scFormTop.Panel1.SuspendLayout();
            this.scFormTop.Panel2.SuspendLayout();
            this.scFormTop.SuspendLayout();
            this.pnlControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResizeForm)).BeginInit();
            this.SuspendLayout();
            // 
            // scFormTop
            // 
            this.scFormTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.scFormTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.scFormTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.scFormTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scFormTop.IsSplitterFixed = true;
            this.scFormTop.Location = new System.Drawing.Point(2, 2);
            this.scFormTop.Margin = new System.Windows.Forms.Padding(0);
            this.scFormTop.Name = "scFormTop";
            // 
            // scFormTop.Panel1
            // 
            this.scFormTop.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.scFormTop.Panel1.Controls.Add(this.btnOptions);
            // 
            // scFormTop.Panel2
            // 
            this.scFormTop.Panel2.Controls.Add(this.lblFormTitle);
            this.scFormTop.Panel2.Controls.Add(this.pnlControlBox);
            this.scFormTop.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.scFormTop.Size = new System.Drawing.Size(710, 60);
            this.scFormTop.SplitterDistance = 60;
            this.scFormTop.SplitterWidth = 1;
            this.scFormTop.TabIndex = 1;
            // 
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOptions.CesBorderThickness = 1;
            this.btnOptions.CesBorderVisible = false;
            this.btnOptions.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Green;
            this.btnOptions.CesEnableToolTip = false;
            this.btnOptions.CesToolTipText = null;
            this.btnOptions.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.ForeColor = System.Drawing.Color.Black;
            this.btnOptions.Image = global::Ces.WinForm.UI.Properties.Resources.Option;
            this.btnOptions.Location = new System.Drawing.Point(0, 0);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(0);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(60, 60);
            this.btnOptions.TabIndex = 6;
            this.btnOptions.TabStop = false;
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFormTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFormTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 30);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblFormTitle.MaximumSize = new System.Drawing.Size(0, 30);
            this.lblFormTitle.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(514, 30);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormTitle.DoubleClick += new System.EventHandler(this.lblFormTitle_DoubleClick);
            this.lblFormTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblFormTitle_MouseDown);
            this.lblFormTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblFormTitle_MouseMove);
            this.lblFormTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblFormTitle_MouseUp);
            // 
            // pnlControlBox
            // 
            this.pnlControlBox.Controls.Add(this.btnMinimize);
            this.pnlControlBox.Controls.Add(this.btnMaximize);
            this.pnlControlBox.Controls.Add(this.btnExit);
            this.pnlControlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControlBox.Location = new System.Drawing.Point(514, 0);
            this.pnlControlBox.Margin = new System.Windows.Forms.Padding(0);
            this.pnlControlBox.MaximumSize = new System.Drawing.Size(135, 30);
            this.pnlControlBox.MinimumSize = new System.Drawing.Size(45, 30);
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
            this.btnMinimize.CesEnableToolTip = false;
            this.btnMinimize.CesToolTipText = null;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            this.btnMaximize.CesEnableToolTip = false;
            this.btnMaximize.CesToolTipText = null;
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            this.btnExit.CesEnableToolTip = false;
            this.btnExit.CesToolTipText = null;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            // clBorderTop
            // 
            this.clBorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clBorderTop.CesAutoStick = false;
            this.clBorderTop.CesAutoStickOffset = 3;
            this.clBorderTop.CesBackColor = System.Drawing.Color.Empty;
            this.clBorderTop.CesLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clBorderTop.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.clBorderTop.CesLineWidth = 2F;
            this.clBorderTop.CesRoundedTip = false;
            this.clBorderTop.CesVertical = false;
            this.clBorderTop.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.clBorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.clBorderTop.Location = new System.Drawing.Point(0, 0);
            this.clBorderTop.Margin = new System.Windows.Forms.Padding(0);
            this.clBorderTop.Name = "clBorderTop";
            this.clBorderTop.Size = new System.Drawing.Size(714, 2);
            this.clBorderTop.TabIndex = 2;
            this.clBorderTop.DoubleClick += new System.EventHandler(this.clBorderTop_DoubleClick);
            // 
            // clBorderBottom
            // 
            this.clBorderBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clBorderBottom.CesAutoStick = false;
            this.clBorderBottom.CesAutoStickOffset = 3;
            this.clBorderBottom.CesBackColor = System.Drawing.Color.Empty;
            this.clBorderBottom.CesLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clBorderBottom.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.clBorderBottom.CesLineWidth = 2F;
            this.clBorderBottom.CesRoundedTip = false;
            this.clBorderBottom.CesVertical = false;
            this.clBorderBottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.clBorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clBorderBottom.Location = new System.Drawing.Point(0, 381);
            this.clBorderBottom.Margin = new System.Windows.Forms.Padding(0);
            this.clBorderBottom.Name = "clBorderBottom";
            this.clBorderBottom.Size = new System.Drawing.Size(714, 2);
            this.clBorderBottom.TabIndex = 3;
            this.clBorderBottom.DoubleClick += new System.EventHandler(this.clBorderBottom_DoubleClick);
            // 
            // clBorderLeft
            // 
            this.clBorderLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clBorderLeft.CesAutoStick = false;
            this.clBorderLeft.CesAutoStickOffset = 3;
            this.clBorderLeft.CesBackColor = System.Drawing.Color.Empty;
            this.clBorderLeft.CesLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clBorderLeft.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.clBorderLeft.CesLineWidth = 2F;
            this.clBorderLeft.CesRoundedTip = false;
            this.clBorderLeft.CesVertical = true;
            this.clBorderLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.clBorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.clBorderLeft.Location = new System.Drawing.Point(0, 2);
            this.clBorderLeft.Margin = new System.Windows.Forms.Padding(0);
            this.clBorderLeft.Name = "clBorderLeft";
            this.clBorderLeft.Size = new System.Drawing.Size(2, 379);
            this.clBorderLeft.TabIndex = 4;
            this.clBorderLeft.DoubleClick += new System.EventHandler(this.clBorderLeft_DoubleClick);
            // 
            // clBorderRight
            // 
            this.clBorderRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clBorderRight.CesAutoStick = false;
            this.clBorderRight.CesAutoStickOffset = 3;
            this.clBorderRight.CesBackColor = System.Drawing.Color.Empty;
            this.clBorderRight.CesLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clBorderRight.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.clBorderRight.CesLineWidth = 2F;
            this.clBorderRight.CesRoundedTip = false;
            this.clBorderRight.CesVertical = true;
            this.clBorderRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.clBorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.clBorderRight.Location = new System.Drawing.Point(712, 2);
            this.clBorderRight.Margin = new System.Windows.Forms.Padding(0);
            this.clBorderRight.Name = "clBorderRight";
            this.clBorderRight.Size = new System.Drawing.Size(2, 379);
            this.clBorderRight.TabIndex = 5;
            this.clBorderRight.DoubleClick += new System.EventHandler(this.clBorderRight_DoubleClick);
            // 
            // pbResizeForm
            // 
            this.pbResizeForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbResizeForm.BackColor = System.Drawing.Color.Transparent;
            this.pbResizeForm.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pbResizeForm.Image = global::Ces.WinForm.UI.Properties.Resources.CesFormResize;
            this.pbResizeForm.Location = new System.Drawing.Point(695, 363);
            this.pbResizeForm.Margin = new System.Windows.Forms.Padding(0);
            this.pbResizeForm.Name = "pbResizeForm";
            this.pbResizeForm.Size = new System.Drawing.Size(16, 16);
            this.pbResizeForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbResizeForm.TabIndex = 6;
            this.pbResizeForm.TabStop = false;
            this.pbResizeForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbResizeForm_MouseDown);
            this.pbResizeForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbResizeForm_MouseMove);
            this.pbResizeForm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbResizeForm_MouseUp);
            // 
            // CesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 383);
            this.Controls.Add(this.scFormTop);
            this.Controls.Add(this.clBorderRight);
            this.Controls.Add(this.clBorderLeft);
            this.Controls.Add(this.clBorderTop);
            this.Controls.Add(this.clBorderBottom);
            this.Controls.Add(this.pbResizeForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CesForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "CesForm";
            this.ResizeEnd += new System.EventHandler(this.CesForm_ResizeEnd);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.CesForm_Layout);
            this.Move += new System.EventHandler(this.CesForm_Move);
            this.Resize += new System.EventHandler(this.CesForm_Resize);
            this.scFormTop.Panel1.ResumeLayout(false);
            this.scFormTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scFormTop)).EndInit();
            this.scFormTop.ResumeLayout(false);
            this.pnlControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbResizeForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer scFormTop;
        private Panel pnlControlBox;
        private CesButton.CesButton btnMinimize;
        private CesButton.CesButton btnMaximize;
        private CesButton.CesButton btnExit;
        private Label lblFormTitle;
        private CesLine clBorderTop;
        private CesLine clBorderBottom;
        private CesLine clBorderLeft;
        private CesLine clBorderRight;
        public CesButton.CesButton btnOptions;
        private PictureBox pbResizeForm;
    }
}