namespace Ces.WinForm.UI
{
    partial class CesToolTip
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
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(233, 43);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "label1";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblText.MouseLeave += new System.EventHandler(this.lblText_MouseLeave);
            // 
            // CesToolTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(233, 43);
            this.Controls.Add(this.lblText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CesToolTip";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CesToolTip";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.CesToolTip_Shown);
            this.MouseLeave += new System.EventHandler(this.CesToolTip_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblText;
    }
}