namespace Ces.WinForm.UI.CesGannChart
{
    partial class CesGannChartTaskItem
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
            this.pnlChildTask = new System.Windows.Forms.Panel();
            this.pnlTask = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblWeightFactor = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnToggleChildTask = new System.Windows.Forms.Button();
            this.lblSpacer = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.cesLine1 = new Ces.WinForm.UI.CesLine();
            this.pnlTask.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChildTask
            // 
            this.pnlChildTask.BackColor = System.Drawing.Color.Transparent;
            this.pnlChildTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildTask.Location = new System.Drawing.Point(0, 30);
            this.pnlChildTask.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChildTask.Name = "pnlChildTask";
            this.pnlChildTask.Size = new System.Drawing.Size(1008, 0);
            this.pnlChildTask.TabIndex = 7;
            this.pnlChildTask.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlChildTask_ControlAdded);
            // 
            // pnlTask
            // 
            this.pnlTask.BackColor = System.Drawing.Color.Transparent;
            this.pnlTask.Controls.Add(this.lblProgress);
            this.pnlTask.Controls.Add(this.lblWeightFactor);
            this.pnlTask.Controls.Add(this.lblDuration);
            this.pnlTask.Controls.Add(this.lblEndDate);
            this.pnlTask.Controls.Add(this.lblStartDate);
            this.pnlTask.Controls.Add(this.pnlTitle);
            this.pnlTask.Controls.Add(this.lblId);
            this.pnlTask.Controls.Add(this.cesLine1);
            this.pnlTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTask.Location = new System.Drawing.Point(0, 0);
            this.pnlTask.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTask.MaximumSize = new System.Drawing.Size(0, 30);
            this.pnlTask.MinimumSize = new System.Drawing.Size(0, 30);
            this.pnlTask.Name = "pnlTask";
            this.pnlTask.Size = new System.Drawing.Size(1008, 30);
            this.pnlTask.TabIndex = 6;
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProgress.Location = new System.Drawing.Point(705, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(50, 29);
            this.lblProgress.TabIndex = 24;
            this.lblProgress.Text = "Progress";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeightFactor
            // 
            this.lblWeightFactor.BackColor = System.Drawing.Color.Transparent;
            this.lblWeightFactor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWeightFactor.Location = new System.Drawing.Point(655, 0);
            this.lblWeightFactor.Name = "lblWeightFactor";
            this.lblWeightFactor.Size = new System.Drawing.Size(50, 29);
            this.lblWeightFactor.TabIndex = 25;
            this.lblWeightFactor.Text = "W. F.";
            this.lblWeightFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblDuration.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDuration.Location = new System.Drawing.Point(605, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 29);
            this.lblDuration.TabIndex = 23;
            this.lblDuration.Text = "Duration";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndDate
            // 
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEndDate.Location = new System.Drawing.Point(535, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(70, 29);
            this.lblEndDate.TabIndex = 22;
            this.lblEndDate.Text = "End Date";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartDate
            // 
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStartDate.Location = new System.Drawing.Point(465, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(70, 29);
            this.lblStartDate.TabIndex = 21;
            this.lblStartDate.Text = "Start Date";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.btnToggleChildTask);
            this.pnlTitle.Controls.Add(this.lblSpacer);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTitle.Location = new System.Drawing.Point(80, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(385, 29);
            this.pnlTitle.TabIndex = 28;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(32, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(353, 29);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnToggleChildTask
            // 
            this.btnToggleChildTask.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleChildTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleChildTask.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnToggleChildTask.Enabled = false;
            this.btnToggleChildTask.FlatAppearance.BorderSize = 0;
            this.btnToggleChildTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleChildTask.ForeColor = System.Drawing.Color.Black;
            this.btnToggleChildTask.Location = new System.Drawing.Point(10, 0);
            this.btnToggleChildTask.Margin = new System.Windows.Forms.Padding(0);
            this.btnToggleChildTask.Name = "btnToggleChildTask";
            this.btnToggleChildTask.Size = new System.Drawing.Size(22, 29);
            this.btnToggleChildTask.TabIndex = 28;
            this.btnToggleChildTask.Text = "+";
            this.btnToggleChildTask.UseVisualStyleBackColor = false;
            this.btnToggleChildTask.Click += new System.EventHandler(this.btnToggleChildTask_Click);
            // 
            // lblSpacer
            // 
            this.lblSpacer.BackColor = System.Drawing.Color.Transparent;
            this.lblSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSpacer.Location = new System.Drawing.Point(0, 0);
            this.lblSpacer.Name = "lblSpacer";
            this.lblSpacer.Size = new System.Drawing.Size(10, 29);
            this.lblSpacer.TabIndex = 29;
            this.lblSpacer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblId
            // 
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblId.Location = new System.Drawing.Point(0, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(80, 29);
            this.lblId.TabIndex = 19;
            this.lblId.Text = "Id";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cesLine1
            // 
            this.cesLine1.BackColor = System.Drawing.Color.White;
            this.cesLine1.CesAutoStick = false;
            this.cesLine1.CesAutoStickOffset = 3;
            this.cesLine1.CesBackColor = System.Drawing.Color.Empty;
            this.cesLine1.CesLineColor = System.Drawing.Color.Gainsboro;
            this.cesLine1.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.cesLine1.CesLineWidth = 1F;
            this.cesLine1.CesRoundedTip = true;
            this.cesLine1.CesVertical = false;
            this.cesLine1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cesLine1.Location = new System.Drawing.Point(0, 29);
            this.cesLine1.Name = "cesLine1";
            this.cesLine1.Size = new System.Drawing.Size(1008, 1);
            this.cesLine1.TabIndex = 29;
            // 
            // CesGannChartTaskItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChildTask);
            this.Controls.Add(this.pnlTask);
            this.MinimumSize = new System.Drawing.Size(660, 0);
            this.Name = "CesGannChartTaskItem";
            this.Size = new System.Drawing.Size(1008, 30);
            this.pnlTask.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel pnlTask;
        private Label lblProgress;
        private Label lblWeightFactor;
        private Label lblDuration;
        private Label lblEndDate;
        private Label lblStartDate;
        private Label lblId;
        public Panel pnlChildTask;
        private Panel pnlTitle;
        private Label lblTitle;
        private Button btnToggleChildTask;
        private Label lblSpacer;
        private CesLine cesLine1;
    }
}
