namespace Ces.WinForm.UI.CesButton
{
    partial class CesRoundedButton
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
            // CesRoundedButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "CesRoundedButton";
            this.Size = new System.Drawing.Size(110, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesRoundedButton_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CesRounded_MouseDown);
            this.MouseEnter += new System.EventHandler(this.CesRoundedButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CesRounded_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CesRoundedButton_MouseUp);
            this.Resize += new System.EventHandler(this.CesRoundedButton_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
