namespace Ces.WinForm.UI.CesComboBox
{
    partial class CesComboBox
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.txtSelectedItem = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.PictureBox();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtSelectedItem);
            this.pnlContainer.Controls.Add(this.btnClear);
            this.pnlContainer.Controls.Add(this.btnOpen);
            this.pnlContainer.Location = new System.Drawing.Point(3, 3);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(258, 29);
            this.pnlContainer.TabIndex = 0;
            // 
            // txtSelectedItem
            // 
            this.txtSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSelectedItem.Location = new System.Drawing.Point(7, 6);
            this.txtSelectedItem.Name = "txtSelectedItem";
            this.txtSelectedItem.Size = new System.Drawing.Size(202, 16);
            this.txtSelectedItem.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Image = global::Ces.WinForm.UI.Properties.Resources.ComboboxClear;
            this.btnClear.Location = new System.Drawing.Point(215, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(16, 16);
            this.btnClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClear.TabIndex = 1;
            this.btnClear.TabStop = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.Image = global::Ces.WinForm.UI.Properties.Resources.DatePickerDownArrow;
            this.btnOpen.Location = new System.Drawing.Point(237, 6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(16, 16);
            this.btnOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnOpen.TabIndex = 0;
            this.btnOpen.TabStop = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // CesComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CesComboBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(267, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesSimpleComboBox_Paint);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlContainer;
        private PictureBox btnClear;
        private PictureBox btnOpen;
        private TextBox txtSelectedItem;
    }
}
