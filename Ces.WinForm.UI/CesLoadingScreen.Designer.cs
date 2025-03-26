namespace Ces.WinForm.UI
{
    partial class CesLoadingScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLoading = new Label();
            SuspendLayout();
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoading.ForeColor = Color.Gray;
            lblLoading.Location = new Point(268, 140);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(89, 23);
            lblLoading.TabIndex = 1;
            lblLoading.Text = "Loading ...";
            // 
            // CesLoadingScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 302);
            Controls.Add(lblLoading);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CesLoadingScreen";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "frmLoading";
            Load += CesLoadingScreen_Load;
            Shown += frmLoading_Shown;
            Resize += frmLoading_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoading;
    }
}