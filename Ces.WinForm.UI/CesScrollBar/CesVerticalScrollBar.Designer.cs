namespace Ces.WinForm.UI.CesScrollBar
{
    partial class CesVerticalScrollBar
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
            lineLeft = new CesLine();
            lineRight = new CesLine();
            ((System.ComponentModel.ISupportInitialize)pbSlider).BeginInit();
            pnlSlider.SuspendLayout();
            SuspendLayout();
            // 
            // pbSlider
            // 
            pbSlider.BackColor = Color.FromArgb(64, 64, 64);
            pbSlider.Cursor = Cursors.Hand;
            pbSlider.Location = new Point(0, 0);
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
            btnUp.Dock = DockStyle.Top;
            btnUp.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnUp.FlatAppearance.BorderSize = 0;
            btnUp.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnUp.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnUp.FlatStyle = FlatStyle.Flat;
            btnUp.ForeColor = Color.Black;
            btnUp.Image = Properties.Resources.CesScrollBarUp;
            btnUp.Location = new Point(1, 0);
            btnUp.Margin = new Padding(0);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(16, 20);
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
            btnDown.Dock = DockStyle.Bottom;
            btnDown.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnDown.FlatAppearance.BorderSize = 0;
            btnDown.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnDown.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnDown.FlatStyle = FlatStyle.Flat;
            btnDown.ForeColor = Color.Black;
            btnDown.Image = Properties.Resources.CesScrollBarDown;
            btnDown.Location = new Point(1, 120);
            btnDown.Margin = new Padding(0);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(16, 20);
            btnDown.TabIndex = 6;
            btnDown.UseVisualStyleBackColor = false;
            btnDown.Click += btnDown_Click;
            // 
            // pnlSlider
            // 
            pnlSlider.Controls.Add(pbSlider);
            pnlSlider.Dock = DockStyle.Fill;
            pnlSlider.Location = new Point(1, 20);
            pnlSlider.Margin = new Padding(0);
            pnlSlider.Name = "pnlSlider";
            pnlSlider.Size = new Size(16, 100);
            pnlSlider.TabIndex = 7;
            pnlSlider.MouseWheel += pnlSlider_MouseWheel;
            // 
            // lineLeft
            // 
            lineLeft.CesAutoStick = false;
            lineLeft.CesAutoStickOffset = 3;
            lineLeft.CesBackColor = Color.Empty;
            lineLeft.CesLineColor = Color.Gainsboro;
            lineLeft.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lineLeft.CesLineWidth = 1F;
            lineLeft.CesRoundedTip = true;
            lineLeft.CesVertical = true;
            lineLeft.Dock = DockStyle.Left;
            lineLeft.Location = new Point(0, 0);
            lineLeft.Margin = new Padding(0);
            lineLeft.Name = "lineLeft";
            lineLeft.Size = new Size(1, 140);
            lineLeft.TabIndex = 8;
            // 
            // lineRight
            // 
            lineRight.CesAutoStick = false;
            lineRight.CesAutoStickOffset = 3;
            lineRight.CesBackColor = Color.Empty;
            lineRight.CesLineColor = Color.Gainsboro;
            lineRight.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lineRight.CesLineWidth = 1F;
            lineRight.CesRoundedTip = true;
            lineRight.CesVertical = true;
            lineRight.Dock = DockStyle.Right;
            lineRight.Location = new Point(17, 0);
            lineRight.Margin = new Padding(0);
            lineRight.Name = "lineRight";
            lineRight.Size = new Size(1, 140);
            lineRight.TabIndex = 9;
            // 
            // CesVerticalScrollBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(pnlSlider);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(lineRight);
            Controls.Add(lineLeft);
            Margin = new Padding(0);
            Name = "CesVerticalScrollBar";
            Size = new Size(18, 140);
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
        private CesLine lineLeft;
        private CesLine lineRight;
    }
}
