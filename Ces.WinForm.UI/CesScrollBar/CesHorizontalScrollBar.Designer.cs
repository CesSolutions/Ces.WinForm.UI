namespace Ces.WinForm.UI.CesScrollBar
{
    partial class CesHorizontalScrollBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbSlider = new PictureBox();
            btnUp = new CesButton.CesButton();
            btnDown = new CesButton.CesButton();
            pnlSlider = new Panel();
            lineTop = new CesLine();
            lineBottom = new CesLine();
            ((System.ComponentModel.ISupportInitialize)pbSlider).BeginInit();
            pnlSlider.SuspendLayout();
            SuspendLayout();
            // 
            // pbSlider
            // 
            pbSlider.BackColor = Color.FromArgb(64, 64, 64);
            pbSlider.Cursor = Cursors.Hand;
            pbSlider.Location = new Point(1, 1);
            pbSlider.Margin = new Padding(0);
            pbSlider.Name = "pbSlider";
            pbSlider.Size = new Size(22, 20);
            pbSlider.SizeMode = PictureBoxSizeMode.CenterImage;
            pbSlider.TabIndex = 4;
            pbSlider.TabStop = false;
            pbSlider.MouseDown += pbSlider_MouseDown;
            pbSlider.MouseMove += pbSlider_MouseMove;
            pbSlider.MouseUp += pbSlider_MouseUp;
            // 
            // btnUp
            // 
            btnUp.BackColor = Color.Gray;
            btnUp.CesBorderThickness = 1;
            btnUp.CesBorderVisible = false;
            btnUp.CesColorTemplate = CesButton.ColorTemplateEnum.Gray;
            btnUp.CesEnableToolTip = false;
            btnUp.CesToolTipText = null;
            btnUp.Dock = DockStyle.Left;
            btnUp.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnUp.FlatAppearance.BorderSize = 0;
            btnUp.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnUp.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnUp.FlatStyle = FlatStyle.Flat;
            btnUp.ForeColor = Color.Black;
            btnUp.Image = Properties.Resources.CesScrollBarLeft;
            btnUp.Location = new Point(0, 1);
            btnUp.Margin = new Padding(0);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(22, 16);
            btnUp.TabIndex = 5;
            btnUp.UseVisualStyleBackColor = false;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.BackColor = Color.Gray;
            btnDown.CesBorderThickness = 1;
            btnDown.CesBorderVisible = false;
            btnDown.CesColorTemplate = CesButton.ColorTemplateEnum.Gray;
            btnDown.CesEnableToolTip = false;
            btnDown.CesToolTipText = null;
            btnDown.Dock = DockStyle.Right;
            btnDown.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnDown.FlatAppearance.BorderSize = 0;
            btnDown.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnDown.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnDown.FlatStyle = FlatStyle.Flat;
            btnDown.ForeColor = Color.Black;
            btnDown.Image = Properties.Resources.CesScrollBarRight;
            btnDown.Location = new Point(118, 1);
            btnDown.Margin = new Padding(0);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(22, 16);
            btnDown.TabIndex = 6;
            btnDown.UseVisualStyleBackColor = false;
            btnDown.Click += btnDown_Click;
            // 
            // pnlSlider
            // 
            pnlSlider.Controls.Add(pbSlider);
            pnlSlider.Dock = DockStyle.Fill;
            pnlSlider.Location = new Point(22, 1);
            pnlSlider.Margin = new Padding(0);
            pnlSlider.Name = "pnlSlider";
            pnlSlider.Size = new Size(96, 16);
            pnlSlider.TabIndex = 7;
            pnlSlider.MouseWheel += pnlSlider_MouseWheel;
            // 
            // lineTop
            // 
            lineTop.CesAutoStick = false;
            lineTop.CesAutoStickOffset = 3;
            lineTop.CesBackColor = Color.Empty;
            lineTop.CesLineColor = Color.Gainsboro;
            lineTop.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lineTop.CesLineWidth = 1F;
            lineTop.CesRoundedTip = true;
            lineTop.CesVertical = false;
            lineTop.Dock = DockStyle.Top;
            lineTop.Location = new Point(0, 0);
            lineTop.Margin = new Padding(0);
            lineTop.Name = "lineTop";
            lineTop.Size = new Size(140, 1);
            lineTop.TabIndex = 8;
            // 
            // lineBottom
            // 
            lineBottom.CesAutoStick = false;
            lineBottom.CesAutoStickOffset = 3;
            lineBottom.CesBackColor = Color.Empty;
            lineBottom.CesLineColor = Color.Gainsboro;
            lineBottom.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lineBottom.CesLineWidth = 1F;
            lineBottom.CesRoundedTip = true;
            lineBottom.CesVertical = false;
            lineBottom.Dock = DockStyle.Bottom;
            lineBottom.Location = new Point(0, 17);
            lineBottom.Margin = new Padding(0);
            lineBottom.Name = "lineBottom";
            lineBottom.Size = new Size(140, 1);
            lineBottom.TabIndex = 9;
            // 
            // CesHorizontalScrollBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(pnlSlider);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(lineBottom);
            Controls.Add(lineTop);
            Margin = new Padding(0);
            Name = "CesHorizontalScrollBar";
            Size = new Size(140, 18);
            SizeChanged += CesVerticalScrollBar_SizeChanged;
            Paint += CesVerticalScrollBar_Paint;
            ((System.ComponentModel.ISupportInitialize)pbSlider).EndInit();
            pnlSlider.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pbSlider;
        private CesButton.CesButton btnUp;
        private CesButton.CesButton btnDown;
        private Panel pnlSlider;
        private CesLine lineTop;
        private CesLine lineBottom;
    }
}
