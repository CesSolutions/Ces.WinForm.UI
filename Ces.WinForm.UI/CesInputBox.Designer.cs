namespace Ces.WinForm.UI
{
    partial class CesInputBox
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
            this.cesRoundedButton1 = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.cesRoundedButton2 = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.SuspendLayout();
            // 
            // cesRoundedButton1
            // 
            this.cesRoundedButton1.BackColor = System.Drawing.SystemColors.Control;
            this.cesRoundedButton1.CesBackColor = System.Drawing.Color.Gray;
            this.cesRoundedButton1.CesBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cesRoundedButton1.CesBorderRadius = 15;
            this.cesRoundedButton1.CesBorderThickness = 1;
            this.cesRoundedButton1.CesBorderVisible = false;
            this.cesRoundedButton1.CesCircular = false;
            this.cesRoundedButton1.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            this.cesRoundedButton1.CesFont = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cesRoundedButton1.CesForeColor = System.Drawing.Color.Black;
            this.cesRoundedButton1.CesIcon = null;
            this.cesRoundedButton1.CesIconAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cesRoundedButton1.CesMouseDownColor = System.Drawing.Color.Gray;
            this.cesRoundedButton1.CesMouseOverColor = System.Drawing.Color.DarkGray;
            this.cesRoundedButton1.CesShowIcon = false;
            this.cesRoundedButton1.CesShowText = true;
            this.cesRoundedButton1.CesText = "CesButton";
            this.cesRoundedButton1.CesTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cesRoundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cesRoundedButton1.Location = new System.Drawing.Point(4, 267);
            this.cesRoundedButton1.Margin = new System.Windows.Forms.Padding(10);
            this.cesRoundedButton1.Name = "cesRoundedButton1";
            this.cesRoundedButton1.Size = new System.Drawing.Size(110, 35);
            this.cesRoundedButton1.TabIndex = 0;
            // 
            // cesRoundedButton2
            // 
            this.cesRoundedButton2.BackColor = System.Drawing.SystemColors.Control;
            this.cesRoundedButton2.CesBackColor = System.Drawing.Color.Gray;
            this.cesRoundedButton2.CesBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cesRoundedButton2.CesBorderRadius = 15;
            this.cesRoundedButton2.CesBorderThickness = 1;
            this.cesRoundedButton2.CesBorderVisible = false;
            this.cesRoundedButton2.CesCircular = false;
            this.cesRoundedButton2.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            this.cesRoundedButton2.CesFont = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cesRoundedButton2.CesForeColor = System.Drawing.Color.Black;
            this.cesRoundedButton2.CesIcon = null;
            this.cesRoundedButton2.CesIconAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cesRoundedButton2.CesMouseDownColor = System.Drawing.Color.Gray;
            this.cesRoundedButton2.CesMouseOverColor = System.Drawing.Color.DarkGray;
            this.cesRoundedButton2.CesShowIcon = false;
            this.cesRoundedButton2.CesShowText = true;
            this.cesRoundedButton2.CesText = "CesButton";
            this.cesRoundedButton2.CesTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cesRoundedButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cesRoundedButton2.Location = new System.Drawing.Point(113, 267);
            this.cesRoundedButton2.Margin = new System.Windows.Forms.Padding(10);
            this.cesRoundedButton2.Name = "cesRoundedButton2";
            this.cesRoundedButton2.Size = new System.Drawing.Size(110, 35);
            this.cesRoundedButton2.TabIndex = 1;
            // 
            // CesInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 307);
            this.Controls.Add(this.cesRoundedButton2);
            this.Controls.Add(this.cesRoundedButton1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CesInputBox";
            this.Text = "CesInputBox";
            this.ResumeLayout(false);

        }

        #endregion

        private CesButton.CesRoundedButton cesRoundedButton1;
        private CesButton.CesRoundedButton cesRoundedButton2;
    }
}