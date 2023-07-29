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
            this.flpCalendar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblYear = new Ces.WinForm.UI.CesLabel();
            this.lblMonthName = new Ces.WinForm.UI.CesLabel();
            this.btnGoToToday = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.btnNextYear = new System.Windows.Forms.Button();
            this.btnPreviousYear = new System.Windows.Forms.Button();
            this.btnPreviousMonth = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.flpWeekNumber = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlWeekNumber = new System.Windows.Forms.Panel();
            this.clWeekNumber = new Ces.WinForm.UI.CesLine();
            this.pnlWeekNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpCalendar
            // 
            this.flpCalendar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.flpCalendar.Location = new System.Drawing.Point(49, 77);
            this.flpCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.flpCalendar.Name = "flpCalendar";
            this.flpCalendar.Size = new System.Drawing.Size(378, 308);
            this.flpCalendar.TabIndex = 36;
            // 
            // lblYear
            // 
            this.lblYear.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblYear.CesShowUnderLine = false;
            this.lblYear.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblYear.CesUnderlineThickness = 1;
            this.lblYear.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblYear.Location = new System.Drawing.Point(195, 6);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(94, 30);
            this.lblYear.TabIndex = 37;
            this.lblYear.Text = "1402";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonthName
            // 
            this.lblMonthName.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblMonthName.CesShowUnderLine = false;
            this.lblMonthName.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblMonthName.CesUnderlineThickness = 1;
            this.lblMonthName.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblMonthName.Location = new System.Drawing.Point(195, 42);
            this.lblMonthName.Name = "lblMonthName";
            this.lblMonthName.Size = new System.Drawing.Size(94, 30);
            this.lblMonthName.TabIndex = 38;
            this.lblMonthName.Text = "اردیبهشت";
            this.lblMonthName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGoToToday
            // 
            this.btnGoToToday.BackColor = System.Drawing.SystemColors.Control;
            this.btnGoToToday.CesBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoToToday.CesBorderColor = System.Drawing.Color.Black;
            this.btnGoToToday.CesBorderRadius = 10;
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
            this.btnGoToToday.CesText = "امروز";
            this.btnGoToToday.CesTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoToToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToToday.Location = new System.Drawing.Point(3, 388);
            this.btnGoToToday.Margin = new System.Windows.Forms.Padding(10);
            this.btnGoToToday.Name = "btnGoToToday";
            this.btnGoToToday.Size = new System.Drawing.Size(424, 35);
            this.btnGoToToday.TabIndex = 39;
            this.btnGoToToday.Click += new System.EventHandler(this.btnGoToToday_Click);
            // 
            // btnNextYear
            // 
            this.btnNextYear.Location = new System.Drawing.Point(295, 6);
            this.btnNextYear.Name = "btnNextYear";
            this.btnNextYear.Size = new System.Drawing.Size(75, 30);
            this.btnNextYear.TabIndex = 40;
            this.btnNextYear.Text = "سال بعد";
            this.btnNextYear.UseVisualStyleBackColor = true;
            this.btnNextYear.Click += new System.EventHandler(this.btnNextYear_Click);
            // 
            // btnPreviousYear
            // 
            this.btnPreviousYear.Location = new System.Drawing.Point(114, 6);
            this.btnPreviousYear.Name = "btnPreviousYear";
            this.btnPreviousYear.Size = new System.Drawing.Size(75, 30);
            this.btnPreviousYear.TabIndex = 41;
            this.btnPreviousYear.Text = "سال قبل";
            this.btnPreviousYear.UseVisualStyleBackColor = true;
            this.btnPreviousYear.Click += new System.EventHandler(this.btnPreviousYear_Click);
            // 
            // btnPreviousMonth
            // 
            this.btnPreviousMonth.Location = new System.Drawing.Point(114, 42);
            this.btnPreviousMonth.Name = "btnPreviousMonth";
            this.btnPreviousMonth.Size = new System.Drawing.Size(75, 30);
            this.btnPreviousMonth.TabIndex = 43;
            this.btnPreviousMonth.Text = "ماه قبل";
            this.btnPreviousMonth.UseVisualStyleBackColor = true;
            this.btnPreviousMonth.Click += new System.EventHandler(this.btnPreviousMonth_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Location = new System.Drawing.Point(295, 42);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(75, 30);
            this.btnNextMonth.TabIndex = 42;
            this.btnNextMonth.Text = "ماه بعد";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // flpWeekNumber
            // 
            this.flpWeekNumber.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.flpWeekNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpWeekNumber.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpWeekNumber.Location = new System.Drawing.Point(0, 0);
            this.flpWeekNumber.Margin = new System.Windows.Forms.Padding(2);
            this.flpWeekNumber.Name = "flpWeekNumber";
            this.flpWeekNumber.Size = new System.Drawing.Size(43, 308);
            this.flpWeekNumber.TabIndex = 37;
            // 
            // pnlWeekNumber
            // 
            this.pnlWeekNumber.Controls.Add(this.clWeekNumber);
            this.pnlWeekNumber.Controls.Add(this.flpWeekNumber);
            this.pnlWeekNumber.Location = new System.Drawing.Point(3, 77);
            this.pnlWeekNumber.Name = "pnlWeekNumber";
            this.pnlWeekNumber.Size = new System.Drawing.Size(43, 308);
            this.pnlWeekNumber.TabIndex = 44;
            // 
            // clWeekNumber
            // 
            this.clWeekNumber.CesBackColor = System.Drawing.Color.Empty;
            this.clWeekNumber.CesLineColor = System.Drawing.Color.Black;
            this.clWeekNumber.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.clWeekNumber.CesLineWidth = 1F;
            this.clWeekNumber.CesQuality = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.clWeekNumber.CesVertical = true;
            this.clWeekNumber.Dock = System.Windows.Forms.DockStyle.Right;
            this.clWeekNumber.Location = new System.Drawing.Point(38, 0);
            this.clWeekNumber.Name = "clWeekNumber";
            this.clWeekNumber.Size = new System.Drawing.Size(5, 308);
            this.clWeekNumber.TabIndex = 38;
            // 
            // CesCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlWeekNumber);
            this.Controls.Add(this.btnPreviousMonth);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnPreviousYear);
            this.Controls.Add(this.btnNextYear);
            this.Controls.Add(this.btnGoToToday);
            this.Controls.Add(this.lblMonthName);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.flpCalendar);
            this.Name = "CesCalendar";
            this.Size = new System.Drawing.Size(430, 426);
            this.Load += new System.EventHandler(this.CesCalendar_Load);
            this.BackColorChanged += new System.EventHandler(this.CesCalendar_BackColorChanged);
            this.ForeColorChanged += new System.EventHandler(this.CesCalendar_ForeColorChanged);
            this.pnlWeekNumber.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flpCalendar;
        private CesLabel lblYear;
        private CesLabel lblMonthName;
        private CesButton.CesRoundedButton btnGoToToday;
        private Button btnNextYear;
        private Button btnPreviousYear;
        private Button btnPreviousMonth;
        private Button btnNextMonth;
        private FlowLayoutPanel flpWeekNumber;
        private Panel pnlWeekNumber;
        private CesLine clWeekNumber;
    }
}
