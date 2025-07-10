namespace Ces.WinForm.UI.CesListBox
{
    partial class CesListBoxItem
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
            pbItemImage = new PictureBox();
            lblItemText = new Label();
            pnlIndicator = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbItemImage).BeginInit();
            SuspendLayout();
            // 
            // pbItemImage
            // 
            pbItemImage.BackColor = Color.Transparent;
            pbItemImage.Cursor = Cursors.Hand;
            pbItemImage.Dock = DockStyle.Left;
            pbItemImage.Location = new Point(3, 0);
            pbItemImage.Margin = new Padding(0);
            pbItemImage.Name = "pbItemImage";
            pbItemImage.Size = new Size(35, 30);
            pbItemImage.SizeMode = PictureBoxSizeMode.CenterImage;
            pbItemImage.TabIndex = 0;
            pbItemImage.TabStop = false;
            pbItemImage.MouseEnter += MouseEnter;
            pbItemImage.MouseLeave += MouseLeave;
            // 
            // lblItemText
            // 
            lblItemText.BackColor = Color.Transparent;
            lblItemText.Dock = DockStyle.Fill;
            lblItemText.Location = new Point(38, 0);
            lblItemText.Name = "lblItemText";
            lblItemText.Size = new Size(275, 30);
            lblItemText.TabIndex = 1;
            lblItemText.TextAlign = ContentAlignment.MiddleLeft;
            lblItemText.Click += lblItemText_Click;
            lblItemText.MouseEnter += MouseEnter;
            lblItemText.MouseLeave += MouseLeave;
            // 
            // pnlIndicator
            // 
            pnlIndicator.Dock = DockStyle.Left;
            pnlIndicator.Location = new Point(0, 0);
            pnlIndicator.Margin = new Padding(0);
            pnlIndicator.Name = "pnlIndicator";
            pnlIndicator.Size = new Size(3, 30);
            pnlIndicator.TabIndex = 2;
            pnlIndicator.Visible = false;
            // 
            // CesListBoxItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblItemText);
            Controls.Add(pbItemImage);
            Controls.Add(pnlIndicator);
            Margin = new Padding(0);
            Name = "CesListBoxItem";
            Size = new Size(313, 30);
            ((System.ComponentModel.ISupportInitialize)pbItemImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox pbItemImage;
        public Label lblItemText;
        private Panel pnlIndicator;
    }
}
