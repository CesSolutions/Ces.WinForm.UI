namespace Ces.WinForm.UI.CesComboBox
{
    partial class CesComboBoxItem
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
            this.pbItemImage = new System.Windows.Forms.PictureBox();
            this.lblItemText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbItemImage
            // 
            this.pbItemImage.BackColor = System.Drawing.Color.Transparent;
            this.pbItemImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItemImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbItemImage.Location = new System.Drawing.Point(0, 0);
            this.pbItemImage.Name = "pbItemImage";
            this.pbItemImage.Size = new System.Drawing.Size(35, 35);
            this.pbItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbItemImage.TabIndex = 0;
            this.pbItemImage.TabStop = false;
            this.pbItemImage.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.pbItemImage.MouseLeave += new System.EventHandler(this.MouseLeave);
            // 
            // lblItemText
            // 
            this.lblItemText.BackColor = System.Drawing.Color.Transparent;
            this.lblItemText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblItemText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemText.Location = new System.Drawing.Point(35, 0);
            this.lblItemText.Name = "lblItemText";
            this.lblItemText.Size = new System.Drawing.Size(278, 35);
            this.lblItemText.TabIndex = 1;
            this.lblItemText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemText.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.lblItemText.MouseLeave += new System.EventHandler(this.MouseLeave);
            // 
            // CesComboBoxItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblItemText);
            this.Controls.Add(this.pbItemImage);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CesComboBoxItem";
            this.Size = new System.Drawing.Size(313, 35);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public PictureBox pbItemImage;
        public Label lblItemText;
    }
}
