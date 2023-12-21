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
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblWeightFactor = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnToggleChildTask = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblId = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProgress.Location = new System.Drawing.Point(705, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(50, 30);
            this.lblProgress.TabIndex = 33;
            this.lblProgress.Text = "Progress";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeightFactor
            // 
            this.lblWeightFactor.BackColor = System.Drawing.Color.Transparent;
            this.lblWeightFactor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWeightFactor.Location = new System.Drawing.Point(655, 0);
            this.lblWeightFactor.Name = "lblWeightFactor";
            this.lblWeightFactor.Size = new System.Drawing.Size(50, 30);
            this.lblWeightFactor.TabIndex = 34;
            this.lblWeightFactor.Text = "W. F.";
            this.lblWeightFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblDuration.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDuration.Location = new System.Drawing.Point(605, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 30);
            this.lblDuration.TabIndex = 32;
            this.lblDuration.Text = "Duration";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndDate
            // 
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEndDate.Location = new System.Drawing.Point(535, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(70, 30);
            this.lblEndDate.TabIndex = 31;
            this.lblEndDate.Text = "End Date";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartDate
            // 
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStartDate.Location = new System.Drawing.Point(465, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(70, 30);
            this.lblStartDate.TabIndex = 30;
            this.lblStartDate.Text = "Start Date";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.btnToggleChildTask);
            this.pnlTitle.Controls.Add(this.pictureBox1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTitle.Location = new System.Drawing.Point(80, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(385, 30);
            this.pnlTitle.TabIndex = 35;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(51, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(334, 30);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnToggleChildTask
            // 
            this.btnToggleChildTask.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleChildTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleChildTask.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnToggleChildTask.FlatAppearance.BorderSize = 0;
            this.btnToggleChildTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleChildTask.ForeColor = System.Drawing.Color.Black;
            this.btnToggleChildTask.Location = new System.Drawing.Point(29, 0);
            this.btnToggleChildTask.Margin = new System.Windows.Forms.Padding(0);
            this.btnToggleChildTask.Name = "btnToggleChildTask";
            this.btnToggleChildTask.Size = new System.Drawing.Size(22, 30);
            this.btnToggleChildTask.TabIndex = 28;
            this.btnToggleChildTask.Text = "+";
            this.btnToggleChildTask.UseVisualStyleBackColor = false;
            this.btnToggleChildTask.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridSortClear;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lblId
            // 
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblId.Location = new System.Drawing.Point(0, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(80, 30);
            this.lblId.TabIndex = 29;
            this.lblId.Text = "Id";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CesGannChartTaskItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblWeightFactor);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.lblId);
            this.MinimumSize = new System.Drawing.Size(660, 0);
            this.Name = "CesGannChartTaskItem";
            this.Size = new System.Drawing.Size(1008, 30);
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblProgress;
        private Label lblWeightFactor;
        private Label lblDuration;
        private Label lblEndDate;
        private Label lblStartDate;
        private Panel pnlTitle;
        private Label lblTitle;
        private Button btnToggleChildTask;
        private Label lblId;
        private PictureBox pictureBox1;
    }
}
