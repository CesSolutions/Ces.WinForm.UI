namespace Ces.WinForm.UI
{
    partial class CesTextBox
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
            this.txtTextBox = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTextBox
            // 
            this.txtTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTextBox.Location = new System.Drawing.Point(7, 28);
            this.txtTextBox.Name = "txtTextBox";
            this.txtTextBox.Size = new System.Drawing.Size(174, 16);
            this.txtTextBox.TabIndex = 0;
            this.txtTextBox.Enter += new System.EventHandler(this.txtTextBox_Enter);
            this.txtTextBox.Leave += new System.EventHandler(this.txtTextBox_Leave);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTitle.Location = new System.Drawing.Point(7, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(174, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            this.lblTitle.Visible = false;
            // 
            // CesTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTextBox);
            this.Name = "CesTextBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(188, 52);
            this.Load += new System.EventHandler(this.CesTextBox_Load);
            this.PaddingChanged += new System.EventHandler(this.CesTextBox_PaddingChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesTextBox_Paint);
            this.Resize += new System.EventHandler(this.CesTextBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtTextBox;
        private Label lblTitle;
    }
}
