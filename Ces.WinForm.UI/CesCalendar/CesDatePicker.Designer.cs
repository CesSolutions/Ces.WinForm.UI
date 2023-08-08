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
            this.btnShowCalendar = new System.Windows.Forms.Button();
            this.lblSelectedDate = new System.Windows.Forms.Label();
            this.pnlChildControl = new System.Windows.Forms.Panel();
            this.pnlChildControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowCalendar
            // 
            this.btnShowCalendar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnShowCalendar.Location = new System.Drawing.Point(192, 1);
            this.btnShowCalendar.Name = "btnShowCalendar";
            this.btnShowCalendar.Size = new System.Drawing.Size(41, 24);
            this.btnShowCalendar.TabIndex = 0;
            this.btnShowCalendar.Text = "button1";
            this.btnShowCalendar.UseVisualStyleBackColor = true;
            this.btnShowCalendar.Click += new System.EventHandler(this.btnShowCalendar_Click);
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSelectedDate.Location = new System.Drawing.Point(7, 2);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(179, 20);
            this.lblSelectedDate.TabIndex = 1;
            this.lblSelectedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlChildControl
            // 
            this.pnlChildControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChildControl.Controls.Add(this.btnShowCalendar);
            this.pnlChildControl.Controls.Add(this.lblSelectedDate);
            this.pnlChildControl.Location = new System.Drawing.Point(2, 5);
            this.pnlChildControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChildControl.Name = "pnlChildControl";
            this.pnlChildControl.Size = new System.Drawing.Size(236, 25);
            this.pnlChildControl.TabIndex = 2;
            // 
            // CesDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlChildControl);
            this.Name = "CesDatePicker";
            this.Size = new System.Drawing.Size(240, 35);
            this.Load += new System.EventHandler(this.CesDatePicker_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesDatePicker_Paint);
            this.pnlChildControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnShowCalendar;
        private Label lblSelectedDate;
        private Panel pnlChildControl;
    }
}
