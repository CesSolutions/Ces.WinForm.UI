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
            scFormTop = new SplitContainer();
            btnOptions = new Ces.WinForm.UI.CesButton.CesButton();
            lblFormTitle = new Label();
            pnlControlBox = new Panel();
            btnMinimize = new Ces.WinForm.UI.CesButton.CesButton();
            btnMaximize = new Ces.WinForm.UI.CesButton.CesButton();
            btnExit = new Ces.WinForm.UI.CesButton.CesButton();
            clBorderTop = new CesLine();
            clBorderBottom = new CesLine();
            clBorderLeft = new CesLine();
            clBorderRight = new CesLine();
            pbResizeForm = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)scFormTop).BeginInit();
            scFormTop.Panel1.SuspendLayout();
            scFormTop.Panel2.SuspendLayout();
            scFormTop.SuspendLayout();
            pnlControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbResizeForm).BeginInit();
            SuspendLayout();
            // 
            // scFormTop
            // 
            scFormTop.BackColor = Color.FromArgb(64, 64, 64);
            scFormTop.Dock = DockStyle.Top;
            scFormTop.FixedPanel = FixedPanel.Panel1;
            scFormTop.IsSplitterFixed = true;
            scFormTop.Location = new Point(2, 2);
            scFormTop.Margin = new Padding(0);
            scFormTop.Name = "scFormTop";
            // 
            // scFormTop.Panel1
            // 
            scFormTop.Panel1.BackColor = Color.FromArgb(64, 64, 64);
            scFormTop.Panel1.Controls.Add(btnOptions);
            scFormTop.Panel1Collapsed = true;
            // 
            // scFormTop.Panel2
            // 
            scFormTop.Panel2.Controls.Add(lblFormTitle);
            scFormTop.Panel2.Controls.Add(pnlControlBox);
            scFormTop.Size = new Size(710, 30);
            scFormTop.SplitterDistance = 60;
            scFormTop.SplitterWidth = 1;
            scFormTop.TabIndex = 1;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.MediumSeaGreen;
            btnOptions.CesBorderThickness = 1;
            btnOptions.CesBorderVisible = false;
            btnOptions.CesColorTemplate = CesButton.ColorTemplateEnum.Green;
            btnOptions.CesEnableToolTip = false;
            btnOptions.CesToolTipText = null;
            btnOptions.Dock = DockStyle.Fill;
            btnOptions.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.ForeColor = Color.Black;
            btnOptions.Image = Properties.Resources.Option;
            btnOptions.Location = new Point(0, 0);
            btnOptions.Margin = new Padding(0);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(60, 100);
            btnOptions.TabIndex = 6;
            btnOptions.TabStop = false;
            btnOptions.UseVisualStyleBackColor = false;
            btnOptions.Click += btnOptions_Click;
            // 
            // lblFormTitle
            // 
            lblFormTitle.BackColor = Color.FromArgb(64, 64, 64);
            lblFormTitle.Dock = DockStyle.Bottom;
            lblFormTitle.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblFormTitle.ForeColor = Color.Silver;
            lblFormTitle.Location = new Point(0, 0);
            lblFormTitle.Margin = new Padding(0);
            lblFormTitle.MaximumSize = new Size(0, 30);
            lblFormTitle.MinimumSize = new Size(0, 30);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(575, 30);
            lblFormTitle.TabIndex = 1;
            lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblFormTitle.DoubleClick += lblFormTitle_DoubleClick;
            lblFormTitle.MouseDown += lblFormTitle_MouseDown;
            lblFormTitle.MouseMove += lblFormTitle_MouseMove;
            lblFormTitle.MouseUp += lblFormTitle_MouseUp;
            // 
            // pnlControlBox
            // 
            pnlControlBox.Controls.Add(btnMinimize);
            pnlControlBox.Controls.Add(btnMaximize);
            pnlControlBox.Controls.Add(btnExit);
            pnlControlBox.Dock = DockStyle.Right;
            pnlControlBox.Location = new Point(575, 0);
            pnlControlBox.Margin = new Padding(0);
            pnlControlBox.MaximumSize = new Size(135, 30);
            pnlControlBox.MinimumSize = new Size(45, 30);
            pnlControlBox.Name = "pnlControlBox";
            pnlControlBox.Size = new Size(135, 30);
            pnlControlBox.TabIndex = 0;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.CesBorderThickness = 1;
            btnMinimize.CesBorderVisible = false;
            btnMinimize.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btnMinimize.CesEnableToolTip = false;
            btnMinimize.CesToolTipText = null;
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseDownBackColor = Color.DarkOrange;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.Orange;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.ForeColor = Color.Black;
            btnMinimize.Image = Properties.Resources.Min;
            btnMinimize.Location = new Point(0, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(45, 30);
            btnMinimize.TabIndex = 2;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnMaximize
            // 
            btnMaximize.BackColor = Color.Transparent;
            btnMaximize.CesBorderThickness = 1;
            btnMaximize.CesBorderVisible = false;
            btnMaximize.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btnMaximize.CesEnableToolTip = false;
            btnMaximize.CesToolTipText = null;
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatAppearance.MouseDownBackColor = Color.DarkGreen;
            btnMaximize.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.ForeColor = Color.Black;
            btnMaximize.Image = Properties.Resources.Max;
            btnMaximize.Location = new Point(45, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(45, 30);
            btnMaximize.TabIndex = 1;
            btnMaximize.UseVisualStyleBackColor = false;
            btnMaximize.Click += btnMaximize_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.CesBorderThickness = 1;
            btnExit.CesBorderVisible = false;
            btnExit.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btnExit.CesEnableToolTip = false;
            btnExit.CesToolTipText = null;
            btnExit.Dock = DockStyle.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.DarkRed;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.Black;
            btnExit.Image = Properties.Resources.Exit;
            btnExit.Location = new Point(90, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(45, 30);
            btnExit.TabIndex = 0;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // clBorderTop
            // 
            clBorderTop.BackColor = Color.FromArgb(255, 128, 0);
            clBorderTop.CesAutoStick = false;
            clBorderTop.CesAutoStickOffset = 3;
            clBorderTop.CesBackColor = Color.Empty;
            clBorderTop.CesLineColor = Color.FromArgb(255, 128, 0);
            clBorderTop.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            clBorderTop.CesLineWidth = 2F;
            clBorderTop.CesRoundedTip = false;
            clBorderTop.CesVertical = false;
            clBorderTop.Cursor = Cursors.SizeNS;
            clBorderTop.Dock = DockStyle.Top;
            clBorderTop.Location = new Point(0, 0);
            clBorderTop.Margin = new Padding(0);
            clBorderTop.Name = "clBorderTop";
            clBorderTop.Size = new Size(714, 2);
            clBorderTop.TabIndex = 2;
            clBorderTop.DoubleClick += clBorderTop_DoubleClick;
            // 
            // clBorderBottom
            // 
            clBorderBottom.BackColor = Color.FromArgb(255, 128, 0);
            clBorderBottom.CesAutoStick = false;
            clBorderBottom.CesAutoStickOffset = 3;
            clBorderBottom.CesBackColor = Color.Empty;
            clBorderBottom.CesLineColor = Color.FromArgb(255, 128, 0);
            clBorderBottom.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            clBorderBottom.CesLineWidth = 2F;
            clBorderBottom.CesRoundedTip = false;
            clBorderBottom.CesVertical = false;
            clBorderBottom.Cursor = Cursors.SizeNS;
            clBorderBottom.Dock = DockStyle.Bottom;
            clBorderBottom.Location = new Point(0, 381);
            clBorderBottom.Margin = new Padding(0);
            clBorderBottom.Name = "clBorderBottom";
            clBorderBottom.Size = new Size(714, 2);
            clBorderBottom.TabIndex = 3;
            clBorderBottom.DoubleClick += clBorderBottom_DoubleClick;
            clBorderBottom.MouseDown += clBorderBottom_MouseDown;
            clBorderBottom.MouseMove += clBorderBottom_MouseMove;
            clBorderBottom.MouseUp += clBorderBottom_MouseUp;
            // 
            // clBorderLeft
            // 
            clBorderLeft.BackColor = Color.FromArgb(255, 128, 0);
            clBorderLeft.CesAutoStick = false;
            clBorderLeft.CesAutoStickOffset = 3;
            clBorderLeft.CesBackColor = Color.Empty;
            clBorderLeft.CesLineColor = Color.FromArgb(255, 128, 0);
            clBorderLeft.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            clBorderLeft.CesLineWidth = 2F;
            clBorderLeft.CesRoundedTip = false;
            clBorderLeft.CesVertical = true;
            clBorderLeft.Cursor = Cursors.SizeWE;
            clBorderLeft.Dock = DockStyle.Left;
            clBorderLeft.Location = new Point(0, 2);
            clBorderLeft.Margin = new Padding(0);
            clBorderLeft.Name = "clBorderLeft";
            clBorderLeft.Size = new Size(2, 379);
            clBorderLeft.TabIndex = 4;
            clBorderLeft.DoubleClick += clBorderLeft_DoubleClick;
            // 
            // clBorderRight
            // 
            clBorderRight.BackColor = Color.FromArgb(255, 128, 0);
            clBorderRight.CesAutoStick = false;
            clBorderRight.CesAutoStickOffset = 3;
            clBorderRight.CesBackColor = Color.Empty;
            clBorderRight.CesLineColor = Color.FromArgb(255, 128, 0);
            clBorderRight.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            clBorderRight.CesLineWidth = 2F;
            clBorderRight.CesRoundedTip = false;
            clBorderRight.CesVertical = true;
            clBorderRight.Cursor = Cursors.SizeWE;
            clBorderRight.Dock = DockStyle.Right;
            clBorderRight.Location = new Point(712, 2);
            clBorderRight.Margin = new Padding(0);
            clBorderRight.Name = "clBorderRight";
            clBorderRight.Size = new Size(2, 379);
            clBorderRight.TabIndex = 5;
            clBorderRight.DoubleClick += clBorderRight_DoubleClick;
            clBorderRight.MouseDown += clBorderRight_MouseDown;
            clBorderRight.MouseMove += clBorderRight_MouseMove;
            clBorderRight.MouseUp += clBorderRight_MouseUp;
            // 
            // pbResizeForm
            // 
            pbResizeForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pbResizeForm.BackColor = Color.Transparent;
            pbResizeForm.Cursor = Cursors.SizeNWSE;
            pbResizeForm.Image = Properties.Resources.CesFormResize;
            pbResizeForm.Location = new Point(695, 363);
            pbResizeForm.Margin = new Padding(0);
            pbResizeForm.Name = "pbResizeForm";
            pbResizeForm.Size = new Size(16, 16);
            pbResizeForm.SizeMode = PictureBoxSizeMode.CenterImage;
            pbResizeForm.TabIndex = 6;
            pbResizeForm.TabStop = false;
            pbResizeForm.Visible = false;
            pbResizeForm.MouseDown += pbResizeForm_MouseDown;
            pbResizeForm.MouseMove += pbResizeForm_MouseMove;
            pbResizeForm.MouseUp += pbResizeForm_MouseUp;
            // 
            // CesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 383);
            Controls.Add(scFormTop);
            Controls.Add(clBorderRight);
            Controls.Add(clBorderLeft);
            Controls.Add(clBorderTop);
            Controls.Add(clBorderBottom);
            Controls.Add(pbResizeForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CesForm";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "CesForm";
            ResizeEnd += CesForm_ResizeEnd;
            Layout += CesForm_Layout;
            Move += CesForm_Move;
            Resize += CesForm_Resize;
            scFormTop.Panel1.ResumeLayout(false);
            scFormTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scFormTop).EndInit();
            scFormTop.ResumeLayout(false);
            pnlControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbResizeForm).EndInit();
            ResumeLayout(false);
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