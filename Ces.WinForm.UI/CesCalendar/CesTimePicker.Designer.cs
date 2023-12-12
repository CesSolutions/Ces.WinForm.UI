namespace Ces.WinForm.UI.CesCalendar
{
    partial class CesTimePicker
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
            this.pnlChildControl = new System.Windows.Forms.Panel();
            this.pbOpenTimePopup = new System.Windows.Forms.PictureBox();
            this.lblSelectedTime = new System.Windows.Forms.Label();
            this.pnlChildControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenTimePopup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChildControl
            // 
            this.pnlChildControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChildControl.Controls.Add(this.pbOpenTimePopup);
            this.pnlChildControl.Controls.Add(this.lblSelectedTime);
            this.pnlChildControl.Location = new System.Drawing.Point(5, 5);
            this.pnlChildControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChildControl.Name = "pnlChildControl";
            this.pnlChildControl.Size = new System.Drawing.Size(132, 25);
            this.pnlChildControl.TabIndex = 3;
            // 
            // pbOpenTimePopup
            // 
            this.pbOpenTimePopup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbOpenTimePopup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOpenTimePopup.Image = global::Ces.WinForm.UI.Properties.Resources.CesTimePicker;
            this.pbOpenTimePopup.Location = new System.Drawing.Point(111, 4);
            this.pbOpenTimePopup.Name = "pbOpenTimePopup";
            this.pbOpenTimePopup.Size = new System.Drawing.Size(18, 16);
            this.pbOpenTimePopup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbOpenTimePopup.TabIndex = 2;
            this.pbOpenTimePopup.TabStop = false;
            this.pbOpenTimePopup.Click += new System.EventHandler(this.pbOpenTimePopup_Click);
            // 
            // lblSelectedTime
            // 
            this.lblSelectedTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSelectedTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelectedTime.Location = new System.Drawing.Point(3, 4);
            this.lblSelectedTime.Name = "lblSelectedTime";
            this.lblSelectedTime.Size = new System.Drawing.Size(102, 16);
            this.lblSelectedTime.TabIndex = 1;
            this.lblSelectedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CesTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChildControl);
            this.Name = "CesTimePicker";
            this.Size = new System.Drawing.Size(141, 35);
            this.Load += new System.EventHandler(this.CesTimePicker_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesTimePicker_Paint);
            this.pnlChildControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenTimePopup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlChildControl;
        private PictureBox pbOpenTimePopup;
        private Label lblSelectedTime;
    }
}
