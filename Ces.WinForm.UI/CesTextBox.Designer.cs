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
            this.btnPaste = new System.Windows.Forms.PictureBox();
            this.btnCopy = new System.Windows.Forms.PictureBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlButtonContainer = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopy)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.pnlButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTextBox
            // 
            this.txtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTextBox.Location = new System.Drawing.Point(5, 5);
            this.txtTextBox.Name = "txtTextBox";
            this.txtTextBox.Size = new System.Drawing.Size(162, 16);
            this.txtTextBox.TabIndex = 0;
            this.txtTextBox.TabStop = false;
            this.txtTextBox.TextChanged += new System.EventHandler(this.txtTextBox_TextChanged);
            this.txtTextBox.Enter += new System.EventHandler(this.txtTextBox_Enter);
            this.txtTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTextBox_KeyDown);
            this.txtTextBox.Leave += new System.EventHandler(this.txtTextBox_Leave);
            // 
            // btnPaste
            // 
            this.btnPaste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaste.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPaste.Image = global::Ces.WinForm.UI.Properties.Resources.CesTextBoxPaste;
            this.btnPaste.Location = new System.Drawing.Point(50, 0);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(25, 25);
            this.btnPaste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPaste.TabIndex = 1;
            this.btnPaste.TabStop = false;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCopy.Image = global::Ces.WinForm.UI.Properties.Resources.CesTextBoxCopy;
            this.btnCopy.Location = new System.Drawing.Point(25, 0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(25, 25);
            this.btnCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCopy.TabIndex = 2;
            this.btnCopy.TabStop = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlButtonContainer);
            this.pnlContainer.Controls.Add(this.txtTextBox);
            this.pnlContainer.Location = new System.Drawing.Point(5, 5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(248, 25);
            this.pnlContainer.TabIndex = 3;
            this.pnlContainer.Resize += new System.EventHandler(this.pnlContainer_Resize);
            // 
            // pnlButtonContainer
            // 
            this.pnlButtonContainer.Controls.Add(this.btnClear);
            this.pnlButtonContainer.Controls.Add(this.btnCopy);
            this.pnlButtonContainer.Controls.Add(this.btnPaste);
            this.pnlButtonContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtonContainer.Location = new System.Drawing.Point(173, 0);
            this.pnlButtonContainer.Name = "pnlButtonContainer";
            this.pnlButtonContainer.Size = new System.Drawing.Size(75, 25);
            this.pnlButtonContainer.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClear.Image = global::Ces.WinForm.UI.Properties.Resources.CesTextBoxClear;
            this.btnClear.Location = new System.Drawing.Point(0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(25, 25);
            this.btnClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClear.TabIndex = 3;
            this.btnClear.TabStop = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // CesTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Name = "CesTextBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(260, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesTextBox_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.btnPaste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopy)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlButtonContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtTextBox;
        private PictureBox btnPaste;
        private PictureBox btnCopy;
        private Panel pnlContainer;
        private PictureBox btnClear;
        private Panel pnlButtonContainer;
    }
}
