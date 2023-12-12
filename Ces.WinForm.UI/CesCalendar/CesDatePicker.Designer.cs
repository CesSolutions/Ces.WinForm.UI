namespace Ces.WinForm.UI.CesCalendar
{
    partial class CesDatePicker
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
            this.lblSelectedDate = new System.Windows.Forms.Label();
            this.pnlChildControl = new System.Windows.Forms.Panel();
            this.pbOpenCalendar = new System.Windows.Forms.PictureBox();
            this.pnlChildControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSelectedDate.Location = new System.Drawing.Point(5, 4);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(203, 16);
            this.lblSelectedDate.TabIndex = 1;
            this.lblSelectedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlChildControl
            // 
            this.pnlChildControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChildControl.Controls.Add(this.pbOpenCalendar);
            this.pnlChildControl.Controls.Add(this.lblSelectedDate);
            this.pnlChildControl.Location = new System.Drawing.Point(2, 5);
            this.pnlChildControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChildControl.Name = "pnlChildControl";
            this.pnlChildControl.Size = new System.Drawing.Size(236, 25);
            this.pnlChildControl.TabIndex = 2;
            // 
            // pbOpenCalendar
            // 
            this.pbOpenCalendar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbOpenCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOpenCalendar.Image = global::Ces.WinForm.UI.Properties.Resources.CesDatePicker;
            this.pbOpenCalendar.Location = new System.Drawing.Point(214, 4);
            this.pbOpenCalendar.Name = "pbOpenCalendar";
            this.pbOpenCalendar.Size = new System.Drawing.Size(18, 16);
            this.pbOpenCalendar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbOpenCalendar.TabIndex = 2;
            this.pbOpenCalendar.TabStop = false;
            this.pbOpenCalendar.Click += new System.EventHandler(this.pbOpenCalendar_Click);
            // 
            // CesDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlChildControl);
            this.Name = "CesDatePicker";
            this.Size = new System.Drawing.Size(240, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesDatePicker_Paint);
            this.pnlChildControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenCalendar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label lblSelectedDate;
        private Panel pnlChildControl;
        private PictureBox pbOpenCalendar;
    }
}
