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
            this.SuspendLayout();
            // 
            // btnShowCalendar
            // 
            this.btnShowCalendar.Location = new System.Drawing.Point(239, 43);
            this.btnShowCalendar.Name = "btnShowCalendar";
            this.btnShowCalendar.Size = new System.Drawing.Size(75, 23);
            this.btnShowCalendar.TabIndex = 0;
            this.btnShowCalendar.Text = "button1";
            this.btnShowCalendar.UseVisualStyleBackColor = true;
            this.btnShowCalendar.Click += new System.EventHandler(this.btnShowCalendar_Click);
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.Location = new System.Drawing.Point(68, 33);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(135, 23);
            this.lblSelectedDate.TabIndex = 1;
            // 
            // CesDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.Controls.Add(this.lblSelectedDate);
            this.Controls.Add(this.btnShowCalendar);
            this.Name = "CesDatePicker";
            this.Size = new System.Drawing.Size(432, 107);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnShowCalendar;
        private Label lblSelectedDate;
    }
}
