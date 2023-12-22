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
            this.pbSlider = new System.Windows.Forms.PictureBox();
            this.btnUp = new Ces.WinForm.UI.CesButton.CesButton();
            this.btnDown = new Ces.WinForm.UI.CesButton.CesButton();
            this.pnlSlider = new System.Windows.Forms.Panel();
            this.lineLeft = new Ces.WinForm.UI.CesLine();
            this.lineRight = new Ces.WinForm.UI.CesLine();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlider)).BeginInit();
            this.pnlSlider.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbSlider
            // 
            this.pbSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSlider.Location = new System.Drawing.Point(0, 0);
            this.pbSlider.Margin = new System.Windows.Forms.Padding(0);
            this.pbSlider.Name = "pbSlider";
            this.pbSlider.Size = new System.Drawing.Size(22, 20);
            this.pbSlider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSlider.TabIndex = 4;
            this.pbSlider.TabStop = false;
            this.pbSlider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSlider_MouseDown);
            this.pbSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSlider_MouseMove);
            this.pbSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSlider_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Gray;
            this.btnUp.CesBorderThickness = 1;
            this.btnUp.CesBorderVisible = false;
            this.btnUp.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            this.btnUp.CesEnableToolTip = false;
            this.btnUp.CesToolTipText = null;
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.ForeColor = System.Drawing.Color.Black;
            this.btnUp.Image = global::Ces.WinForm.UI.Properties.Resources.CesScrollBarUp;
            this.btnUp.Location = new System.Drawing.Point(1, 0);
            this.btnUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(22, 20);
            this.btnUp.TabIndex = 5;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Gray;
            this.btnDown.CesBorderThickness = 1;
            this.btnDown.CesBorderVisible = false;
            this.btnDown.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            this.btnDown.CesEnableToolTip = false;
            this.btnDown.CesToolTipText = null;
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.ForeColor = System.Drawing.Color.Black;
            this.btnDown.Image = global::Ces.WinForm.UI.Properties.Resources.CesScrollBarDown;
            this.btnDown.Location = new System.Drawing.Point(1, 120);
            this.btnDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(22, 20);
            this.btnDown.TabIndex = 6;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // pnlSlider
            // 
            this.pnlSlider.Controls.Add(this.pbSlider);
            this.pnlSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSlider.Location = new System.Drawing.Point(1, 20);
            this.pnlSlider.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSlider.Name = "pnlSlider";
            this.pnlSlider.Size = new System.Drawing.Size(22, 100);
            this.pnlSlider.TabIndex = 7;
            this.pnlSlider.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pnlSlider_MouseWheel);
            // 
            // lineLeft
            // 
            this.lineLeft.CesAutoStick = false;
            this.lineLeft.CesAutoStickOffset = 3;
            this.lineLeft.CesBackColor = System.Drawing.Color.Empty;
            this.lineLeft.CesLineColor = System.Drawing.Color.Gainsboro;
            this.lineLeft.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineLeft.CesLineWidth = 1F;
            this.lineLeft.CesRoundedTip = true;
            this.lineLeft.CesVertical = true;
            this.lineLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lineLeft.Location = new System.Drawing.Point(0, 0);
            this.lineLeft.Name = "lineLeft";
            this.lineLeft.Size = new System.Drawing.Size(1, 140);
            this.lineLeft.TabIndex = 8;
            // 
            // lineRight
            // 
            this.lineRight.CesAutoStick = false;
            this.lineRight.CesAutoStickOffset = 3;
            this.lineRight.CesBackColor = System.Drawing.Color.Empty;
            this.lineRight.CesLineColor = System.Drawing.Color.Gainsboro;
            this.lineRight.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineRight.CesLineWidth = 1F;
            this.lineRight.CesRoundedTip = true;
            this.lineRight.CesVertical = true;
            this.lineRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lineRight.Location = new System.Drawing.Point(23, 0);
            this.lineRight.Name = "lineRight";
            this.lineRight.Size = new System.Drawing.Size(1, 140);
            this.lineRight.TabIndex = 9;
            // 
            // CesVerticalScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.pnlSlider);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lineRight);
            this.Controls.Add(this.lineLeft);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CesVerticalScrollBar";
            this.Size = new System.Drawing.Size(24, 140);
            this.SizeChanged += new System.EventHandler(this.CesVerticalScrollBar_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesVerticalScrollBar_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlider)).EndInit();
            this.pnlSlider.ResumeLayout(false);
            this.ResumeLayout(false);

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
