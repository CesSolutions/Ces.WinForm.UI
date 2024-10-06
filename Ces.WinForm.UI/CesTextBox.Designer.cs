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
            txtTextBox = new TextBox();
            btnPaste = new PictureBox();
            btnCopy = new PictureBox();
            pnlContainer = new Panel();
            lblEnable = new Label();
            pnlButtonContainer = new Panel();
            btnClear = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnPaste).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCopy).BeginInit();
            pnlContainer.SuspendLayout();
            pnlButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnClear).BeginInit();
            SuspendLayout();
            // 
            // txtTextBox
            // 
            txtTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTextBox.BorderStyle = BorderStyle.None;
            txtTextBox.Location = new Point(5, 5);
            txtTextBox.Name = "txtTextBox";
            txtTextBox.Size = new Size(162, 16);
            txtTextBox.TabIndex = 0;
            txtTextBox.TabStop = false;
            txtTextBox.TextChanged += txtTextBox_TextChanged;
            txtTextBox.Enter += txtTextBox_Enter;
            txtTextBox.KeyDown += txtTextBox_KeyDown;
            txtTextBox.Leave += txtTextBox_Leave;
            // 
            // btnPaste
            // 
            btnPaste.Cursor = Cursors.Hand;
            btnPaste.Dock = DockStyle.Right;
            btnPaste.Image = Properties.Resources.CesTextBoxPasteNormal;
            btnPaste.Location = new Point(50, 0);
            btnPaste.Name = "btnPaste";
            btnPaste.Size = new Size(25, 25);
            btnPaste.SizeMode = PictureBoxSizeMode.CenterImage;
            btnPaste.TabIndex = 1;
            btnPaste.TabStop = false;
            btnPaste.Click += btnPaste_Click;
            btnPaste.MouseEnter += btnPaste_MouseEnter;
            btnPaste.MouseLeave += btnPaste_MouseLeave;
            // 
            // btnCopy
            // 
            btnCopy.Cursor = Cursors.Hand;
            btnCopy.Dock = DockStyle.Right;
            btnCopy.Image = Properties.Resources.CesTextBoxCopyNormal;
            btnCopy.Location = new Point(25, 0);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(25, 25);
            btnCopy.SizeMode = PictureBoxSizeMode.CenterImage;
            btnCopy.TabIndex = 2;
            btnCopy.TabStop = false;
            btnCopy.Click += btnCopy_Click;
            btnCopy.MouseEnter += btnCopy_MouseEnter;
            btnCopy.MouseLeave += btnCopy_MouseLeave;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = SystemColors.Control;
            pnlContainer.Controls.Add(txtTextBox);
            pnlContainer.Controls.Add(lblEnable);
            pnlContainer.Controls.Add(pnlButtonContainer);
            pnlContainer.Location = new Point(5, 5);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(248, 25);
            pnlContainer.TabIndex = 3;
            pnlContainer.Resize += pnlContainer_Resize;
            // 
            // lblEnable
            // 
            lblEnable.AutoSize = true;
            lblEnable.Location = new Point(47, 5);
            lblEnable.Name = "lblEnable";
            lblEnable.Size = new Size(0, 15);
            lblEnable.TabIndex = 5;
            lblEnable.Visible = false;
            // 
            // pnlButtonContainer
            // 
            pnlButtonContainer.Controls.Add(btnClear);
            pnlButtonContainer.Controls.Add(btnCopy);
            pnlButtonContainer.Controls.Add(btnPaste);
            pnlButtonContainer.Dock = DockStyle.Right;
            pnlButtonContainer.Location = new Point(173, 0);
            pnlButtonContainer.Name = "pnlButtonContainer";
            pnlButtonContainer.Size = new Size(75, 25);
            pnlButtonContainer.TabIndex = 4;
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.Dock = DockStyle.Right;
            btnClear.Image = Properties.Resources.CesTextBoxClearNormal;
            btnClear.Location = new Point(0, 0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(25, 25);
            btnClear.SizeMode = PictureBoxSizeMode.CenterImage;
            btnClear.TabIndex = 3;
            btnClear.TabStop = false;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // CesTextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Name = "CesTextBox";
            Padding = new Padding(3);
            Size = new Size(258, 35);
            Paint += CesTextBox_Paint;
            ((System.ComponentModel.ISupportInitialize)btnPaste).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCopy).EndInit();
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            pnlButtonContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnClear).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtTextBox;
        private PictureBox btnPaste;
        private PictureBox btnCopy;
        private Panel pnlContainer;
        private PictureBox btnClear;
        private Panel pnlButtonContainer;
        private Label lblEnable;
    }
}
