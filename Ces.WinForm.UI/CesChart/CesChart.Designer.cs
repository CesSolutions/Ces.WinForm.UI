namespace Ces.WinForm.UI.CesChart
{
    partial class CesChart
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
            this.pnlChart = new System.Windows.Forms.Panel();
            this.pbChart = new System.Windows.Forms.PictureBox();
            this.pnlSeries = new System.Windows.Forms.Panel();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChart
            // 
            this.pnlChart.AutoScroll = true;
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChart.Controls.Add(this.pbChart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(0, 0);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(572, 347);
            this.pnlChart.TabIndex = 0;
            // 
            // pbChart
            // 
            this.pbChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pbChart.Location = new System.Drawing.Point(0, 0);
            this.pbChart.Margin = new System.Windows.Forms.Padding(0);
            this.pbChart.Name = "pbChart";
            this.pbChart.Size = new System.Drawing.Size(476, 160);
            this.pbChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbChart.TabIndex = 1;
            this.pbChart.TabStop = false;
            // 
            // pnlSeries
            // 
            this.pnlSeries.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeries.Location = new System.Drawing.Point(572, 0);
            this.pnlSeries.Name = "pnlSeries";
            this.pnlSeries.Size = new System.Drawing.Size(174, 347);
            this.pnlSeries.TabIndex = 1;
            // 
            // CesChart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlSeries);
            this.Name = "CesChart";
            this.Size = new System.Drawing.Size(746, 347);
            this.Load += new System.EventHandler(this.CesChart_Load);
            this.pnlChart.ResumeLayout(false);
            this.pnlChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlChart;
        private PictureBox pbChart;
        private Panel pnlSeries;
    }
}
