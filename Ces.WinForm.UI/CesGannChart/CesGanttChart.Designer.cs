namespace Ces.WinForm.UI.CesGannChart
{
    partial class CesGanttChart
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
            this.flpTask = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpTask
            // 
            this.flpTask.Location = new System.Drawing.Point(3, 3);
            this.flpTask.Name = "flpTask";
            this.flpTask.Size = new System.Drawing.Size(365, 389);
            this.flpTask.TabIndex = 0;
            // 
            // CesGanttChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flpTask);
            this.Name = "CesGanttChart";
            this.Size = new System.Drawing.Size(737, 393);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flpTask;
    }
}
