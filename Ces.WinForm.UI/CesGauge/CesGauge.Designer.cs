namespace Ces.WinForm.UI.CesGauge
{
    partial class CesGauge
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
            this.pbGauge = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGauge)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGauge
            // 
            this.pbGauge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbGauge.Location = new System.Drawing.Point(0, 0);
            this.pbGauge.Name = "pbGauge";
            this.pbGauge.Size = new System.Drawing.Size(369, 208);
            this.pbGauge.TabIndex = 0;
            this.pbGauge.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTitle.Location = new System.Drawing.Point(0, 208);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(369, 36);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Gauge";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CesGauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbGauge);
            this.Controls.Add(this.lblTitle);
            this.Name = "CesGauge";
            this.Size = new System.Drawing.Size(369, 244);
            ((System.ComponentModel.ISupportInitialize)(this.pbGauge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbGauge;
        private Label lblTitle;
    }
}
