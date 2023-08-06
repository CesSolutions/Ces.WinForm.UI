namespace Ces.WinForm.UI
{
    public partial class CesControlBase
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
            this.SuspendLayout();
            // 
            // CesRoundedBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CesRoundedBase";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(188, 35);
            this.SizeChanged += new System.EventHandler(this.CesTextBox_SizeChanged);
            this.PaddingChanged += new System.EventHandler(this.CesTextBox_PaddingChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesTextBox_Paint);
            this.Resize += new System.EventHandler(this.CesTextBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
