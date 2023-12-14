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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnToggleChildTask = new System.Windows.Forms.Button();
            this.lblSpacer = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.pnlTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChildTask
            // 
            this.pnlChildTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildTask.Location = new System.Drawing.Point(0, 30);
            this.pnlChildTask.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChildTask.Name = "pnlChildTask";
            this.pnlChildTask.Size = new System.Drawing.Size(753, 0);
            this.pnlChildTask.TabIndex = 7;
            this.pnlChildTask.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlChildTask_ControlAdded);
            // 
            // pnlTask
            // 
            this.pnlTask.Controls.Add(this.lblProgress);
            this.pnlTask.Controls.Add(this.lblWeightFactor);
            this.pnlTask.Controls.Add(this.lblDuration);
            this.pnlTask.Controls.Add(this.lblEndDate);
            this.pnlTask.Controls.Add(this.lblStartDate);
            this.pnlTask.Controls.Add(this.lblTitle);
            this.pnlTask.Controls.Add(this.btnToggleChildTask);
            this.pnlTask.Controls.Add(this.lblSpacer);
            this.pnlTask.Controls.Add(this.lblId);
            this.pnlTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTask.Location = new System.Drawing.Point(0, 0);
            this.pnlTask.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTask.MaximumSize = new System.Drawing.Size(0, 30);
            this.pnlTask.MinimumSize = new System.Drawing.Size(0, 30);
            this.pnlTask.Name = "pnlTask";
            this.pnlTask.Size = new System.Drawing.Size(753, 30);
            this.pnlTask.TabIndex = 6;
            // 
            // lblProgress
            // 
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProgress.Location = new System.Drawing.Point(643, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(50, 30);
            this.lblProgress.TabIndex = 24;
            this.lblProgress.Text = "Progress";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeightFactor
            // 
            this.lblWeightFactor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWeightFactor.Location = new System.Drawing.Point(593, 0);
            this.lblWeightFactor.Name = "lblWeightFactor";
            this.lblWeightFactor.Size = new System.Drawing.Size(50, 30);
            this.lblWeightFactor.TabIndex = 25;
            this.lblWeightFactor.Text = "W. F.";
            this.lblWeightFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuration
            // 
            this.lblDuration.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDuration.Location = new System.Drawing.Point(543, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 30);
            this.lblDuration.TabIndex = 23;
            this.lblDuration.Text = "Duration";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEndDate.Location = new System.Drawing.Point(473, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(70, 30);
            this.lblEndDate.TabIndex = 22;
            this.lblEndDate.Text = "End Date";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStartDate.Location = new System.Drawing.Point(403, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(70, 30);
            this.lblStartDate.TabIndex = 21;
            this.lblStartDate.Text = "Start Date";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Location = new System.Drawing.Point(112, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(291, 30);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnToggleChildTask
            // 
            this.btnToggleChildTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleChildTask.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnToggleChildTask.Enabled = false;
            this.btnToggleChildTask.FlatAppearance.BorderSize = 0;
            this.btnToggleChildTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleChildTask.ForeColor = System.Drawing.Color.Black;
            this.btnToggleChildTask.Location = new System.Drawing.Point(90, 0);
            this.btnToggleChildTask.Margin = new System.Windows.Forms.Padding(0);
            this.btnToggleChildTask.Name = "btnToggleChildTask";
            this.btnToggleChildTask.Size = new System.Drawing.Size(22, 30);
            this.btnToggleChildTask.TabIndex = 26;
            this.btnToggleChildTask.Text = "+";
            this.btnToggleChildTask.UseVisualStyleBackColor = true;
            this.btnToggleChildTask.Click += new System.EventHandler(this.btnToggleChildTask_Click);
            // 
            // lblSpacer
            // 
            this.lblSpacer.BackColor = System.Drawing.SystemColors.Control;
            this.lblSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSpacer.Location = new System.Drawing.Point(80, 0);
            this.lblSpacer.Name = "lblSpacer";
            this.lblSpacer.Size = new System.Drawing.Size(10, 30);
            this.lblSpacer.TabIndex = 27;
            this.lblSpacer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblId
            // 
            this.lblId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblId.Location = new System.Drawing.Point(0, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(80, 30);
            this.lblId.TabIndex = 19;
            this.lblId.Text = "Id";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CesGannChartTaskItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChildTask);
            this.Controls.Add(this.pnlTask);
            this.MinimumSize = new System.Drawing.Size(660, 0);
            this.Name = "CesGannChartTaskItem";
            this.Size = new System.Drawing.Size(753, 30);
            this.pnlTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel pnlTask;
        private Label lblProgress;
        private Label lblWeightFactor;
        private Label lblDuration;
        private Label lblEndDate;
        private Label lblStartDate;
        private Label lblTitle;
        private Label lblSpacer;
        private Label lblId;
        private Button btnToggleChildTask;
        public Panel pnlChildTask;
    }
}
