namespace Ces.WinForm.UI.CesCalendar
{
    partial class CesCalendar2
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
            pnlContainer = new Panel();
            MonthCalendar = new MonthCalendar();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlContainer.Controls.Add(MonthCalendar);
            pnlContainer.Location = new Point(3, 3);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(3);
            pnlContainer.Size = new Size(234, 168);
            pnlContainer.TabIndex = 0;
            // 
            // MonthCalendar
            // 
            MonthCalendar.Dock = DockStyle.Fill;
            MonthCalendar.Location = new Point(3, 3);
            MonthCalendar.Margin = new Padding(0);
            MonthCalendar.Name = "MonthCalendar";
            MonthCalendar.ShowTodayCircle = false;
            MonthCalendar.TabIndex = 0;
            MonthCalendar.TrailingForeColor = Color.Gold;
            // 
            // CesCalendar2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Name = "CesCalendar2";
            Size = new Size(240, 175);
            Paint += CesCalendar2_Paint;
            pnlContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        public MonthCalendar MonthCalendar;
    }
}
