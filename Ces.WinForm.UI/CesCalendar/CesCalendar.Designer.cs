namespace Ces.WinForm.UI.CesCalendar
{
    partial class CesCalendar
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cesLabel1 = new Ces.WinForm.UI.CesLabel();
            this.cesLabel2 = new Ces.WinForm.UI.CesLabel();
            this.btnGoToToday = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(26, 80);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(387, 293);
            this.flowLayoutPanel1.TabIndex = 36;
            // 
            // cesLabel1
            // 
            this.cesLabel1.AutoSize = true;
            this.cesLabel1.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.cesLabel1.CesShowUnderLine = false;
            this.cesLabel1.CesUnderlineColor = System.Drawing.Color.Black;
            this.cesLabel1.CesUnderlineThickness = 1;
            this.cesLabel1.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.cesLabel1.Location = new System.Drawing.Point(236, 52);
            this.cesLabel1.Name = "cesLabel1";
            this.cesLabel1.Size = new System.Drawing.Size(58, 15);
            this.cesLabel1.TabIndex = 37;
            this.cesLabel1.Text = "cesLabel1";
            // 
            // cesLabel2
            // 
            this.cesLabel2.AutoSize = true;
            this.cesLabel2.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.cesLabel2.CesShowUnderLine = false;
            this.cesLabel2.CesUnderlineColor = System.Drawing.Color.Black;
            this.cesLabel2.CesUnderlineThickness = 1;
            this.cesLabel2.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.cesLabel2.Location = new System.Drawing.Point(128, 52);
            this.cesLabel2.Name = "cesLabel2";
            this.cesLabel2.Size = new System.Drawing.Size(58, 15);
            this.cesLabel2.TabIndex = 38;
            this.cesLabel2.Text = "cesLabel2";
            // 
            // btnGoToToday
            // 
            this.btnGoToToday.BackColor = System.Drawing.SystemColors.Control;
            this.btnGoToToday.CesBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoToToday.CesBorderColor = System.Drawing.Color.Black;
            this.btnGoToToday.CesBorderRadius = 15;
            this.btnGoToToday.CesBorderThickness = 1;
            this.btnGoToToday.CesBorderVisible = false;
            this.btnGoToToday.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Dark;
            this.btnGoToToday.CesFont = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnGoToToday.CesForeColor = System.Drawing.Color.White;
            this.btnGoToToday.CesIcon = null;
            this.btnGoToToday.CesIconAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoToToday.CesMouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoToToday.CesMouseOverColor = System.Drawing.Color.Gray;
            this.btnGoToToday.CesShowIcon = false;
            this.btnGoToToday.CesShowText = true;
            this.btnGoToToday.CesText = "Today";
            this.btnGoToToday.CesTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoToToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToToday.Location = new System.Drawing.Point(323, 382);
            this.btnGoToToday.Margin = new System.Windows.Forms.Padding(10);
            this.btnGoToToday.Name = "btnGoToToday";
            this.btnGoToToday.Size = new System.Drawing.Size(90, 40);
            this.btnGoToToday.TabIndex = 39;
            this.btnGoToToday.Click += new System.EventHandler(this.btnGoToToday_Click);
            // 
            // CesCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.btnGoToToday);
            this.Controls.Add(this.cesLabel2);
            this.Controls.Add(this.cesLabel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CesCalendar";
            this.Size = new System.Drawing.Size(447, 432);
            this.Load += new System.EventHandler(this.CesCalendar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private CesLabel cesLabel1;
        private CesLabel cesLabel2;
        private CesButton.CesRoundedButton btnGoToToday;
    }
}
