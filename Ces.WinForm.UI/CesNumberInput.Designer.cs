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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.pbnPlus = new System.Windows.Forms.PictureBox();
            this.pbMinus = new System.Windows.Forms.PictureBox();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbnPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinus)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Controls.Add(this.txtValue);
            this.pnlContainer.Controls.Add(this.pbnPlus);
            this.pnlContainer.Controls.Add(this.pbMinus);
            this.pnlContainer.Location = new System.Drawing.Point(6, 5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(102, 26);
            this.pnlContainer.TabIndex = 0;
            // 
            // txtValue
            // 
            this.txtValue.BackColor = System.Drawing.Color.White;
            this.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValue.Location = new System.Drawing.Point(36, 5);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(30, 16);
            this.txtValue.TabIndex = 2;
            this.txtValue.Text = "0";
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyDown);
            this.txtValue.MouseEnter += new System.EventHandler(this.txtValue_MouseEnter);
            this.txtValue.MouseLeave += new System.EventHandler(this.txtValue_MouseLeave);
            // 
            // pbnPlus
            // 
            this.pbnPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbnPlus.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbnPlus.Image = global::Ces.WinForm.UI.Properties.Resources.CesNumberInputPlus;
            this.pbnPlus.Location = new System.Drawing.Point(72, 0);
            this.pbnPlus.Name = "pbnPlus";
            this.pbnPlus.Size = new System.Drawing.Size(30, 26);
            this.pbnPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbnPlus.TabIndex = 1;
            this.pbnPlus.TabStop = false;
            this.pbnPlus.Click += new System.EventHandler(this.pbPlus_Click);
            // 
            // pbMinus
            // 
            this.pbMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMinus.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbMinus.Image = global::Ces.WinForm.UI.Properties.Resources.CesNumberInputMinus;
            this.pbMinus.Location = new System.Drawing.Point(0, 0);
            this.pbMinus.Name = "pbMinus";
            this.pbMinus.Size = new System.Drawing.Size(30, 26);
            this.pbMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMinus.TabIndex = 0;
            this.pbMinus.TabStop = false;
            this.pbMinus.Click += new System.EventHandler(this.pbMinus_Click);
            // 
            // CesNumberInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Name = "CesNumberInput";
            this.Size = new System.Drawing.Size(111, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesNumberInput_Paint);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbnPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlContainer;
        private PictureBox pbnPlus;
        private PictureBox pbMinus;
        private TextBox txtValue;
    }
}
