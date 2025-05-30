namespace Ces.WinForm.UI
{
    partial class CesNumberInput
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
            pnlContainer = new Panel();
            txtValue = new TextBox();
            pbnPlus = new PictureBox();
            pbMinus = new PictureBox();
            pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbnPlus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinus).BeginInit();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(txtValue);
            pnlContainer.Controls.Add(pbnPlus);
            pnlContainer.Controls.Add(pbMinus);
            pnlContainer.Location = new Point(6, 5);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(102, 26);
            pnlContainer.TabIndex = 0;
            // 
            // txtValue
            // 
            txtValue.BackColor = Color.White;
            txtValue.BorderStyle = BorderStyle.None;
            txtValue.Location = new Point(36, 5);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(30, 16);
            txtValue.TabIndex = 2;
            txtValue.Text = "0";
            txtValue.TextAlign = HorizontalAlignment.Center;
            txtValue.TextChanged += txtValue_TextChanged;
            txtValue.KeyDown += txtValue_KeyDown;
            txtValue.MouseEnter += txtValue_MouseEnter;
            txtValue.MouseLeave += txtValue_MouseLeave;
            // 
            // pbnPlus
            // 
            pbnPlus.Cursor = Cursors.Hand;
            pbnPlus.Dock = DockStyle.Right;
            pbnPlus.Image = Properties.Resources.CesNumberInputPlus;
            pbnPlus.Location = new Point(72, 0);
            pbnPlus.Name = "pbnPlus";
            pbnPlus.Size = new Size(30, 26);
            pbnPlus.SizeMode = PictureBoxSizeMode.CenterImage;
            pbnPlus.TabIndex = 1;
            pbnPlus.TabStop = false;
            pbnPlus.Click += pbPlus_Click;
            // 
            // pbMinus
            // 
            pbMinus.Cursor = Cursors.Hand;
            pbMinus.Dock = DockStyle.Left;
            pbMinus.Image = Properties.Resources.CesNumberInputMinus;
            pbMinus.Location = new Point(0, 0);
            pbMinus.Name = "pbMinus";
            pbMinus.Size = new Size(30, 26);
            pbMinus.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMinus.TabIndex = 0;
            pbMinus.TabStop = false;
            pbMinus.Click += pbMinus_Click;
            // 
            // CesNumberInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Name = "CesNumberInput";
            Size = new Size(111, 35);
            Paint += CesNumberInput_Paint;
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbnPlus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinus).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Panel pnlContainer;
        private PictureBox pbnPlus;
        private PictureBox pbMinus;
        private TextBox txtValue;
    }
}
