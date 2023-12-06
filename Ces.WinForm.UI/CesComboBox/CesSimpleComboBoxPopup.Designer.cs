namespace Ces.WinForm.UI.CesComboBox
{
    partial class CesSimpleComboBoxPopup
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnOptions
            // 
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(280, 192);
            this.pnlContainer.TabIndex = 0;
            // 
            // CesSimpleComboBoxPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CesBorderThickness = 1;
            this.CesFormType = Ces.WinForm.UI.CesForm.CesFormTypeEnum.None;
            this.ClientSize = new System.Drawing.Size(282, 194);
            this.Controls.Add(this.pnlContainer);
            this.KeyPreview = true;
            this.Name = "CesSimpleComboBoxPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CesSimpleComboBoxPopup";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CesSimpleComboBoxPopup_KeyDown);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.ResumeLayout(false);

        }

        #endregion

        public Panel pnlContainer;
    }
}