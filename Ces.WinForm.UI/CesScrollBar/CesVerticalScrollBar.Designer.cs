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
            ((System.ComponentModel.ISupportInitialize)(this.pbSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSlider
            // 
            this.pbSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSlider.Image = global::Ces.WinForm.UI.Properties.Resources.CesScrollBarSlider;
            this.pbSlider.Location = new System.Drawing.Point(2, 23);
            this.pbSlider.Name = "pbSlider";
            this.pbSlider.Size = new System.Drawing.Size(18, 20);
            this.pbSlider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSlider.TabIndex = 4;
            this.pbSlider.TabStop = false;
            this.pbSlider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSlider_MouseDown);
            this.pbSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSlider_MouseMove);
            this.pbSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSlider_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUp.CesBorderThickness = 1;
            this.btnUp.CesBorderVisible = false;
            this.btnUp.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnUp.CesEnableToolTip = false;
            this.btnUp.CesToolTipText = null;
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Image = global::Ces.WinForm.UI.Properties.Resources.CesScrollBarUp;
            this.btnUp.Location = new System.Drawing.Point(0, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(22, 20);
            this.btnUp.TabIndex = 5;
            this.btnUp.UseVisualStyleBackColor = false;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDown.CesBorderThickness = 1;
            this.btnDown.CesBorderVisible = false;
            this.btnDown.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.btnDown.CesEnableToolTip = false;
            this.btnDown.CesToolTipText = null;
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Image = global::Ces.WinForm.UI.Properties.Resources.CesScrollBarDown;
            this.btnDown.Location = new System.Drawing.Point(0, 390);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(22, 20);
            this.btnDown.TabIndex = 6;
            this.btnDown.UseVisualStyleBackColor = false;
            // 
            // CesVerticalScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.pbSlider);
            this.Name = "CesVerticalScrollBar";
            this.Size = new System.Drawing.Size(22, 410);
            this.Resize += new System.EventHandler(this.CesVerticalScrollBar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox pbSlider;
        private CesButton.CesButton btnUp;
        private CesButton.CesButton btnDown;
    }
}
