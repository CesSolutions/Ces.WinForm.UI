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
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.vs = new Ces.WinForm.UI.CesScrollBar.CesVerticalScrollBar();
            this.SuspendLayout();
            // 
            // btnOptions
            // 
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // flp
            // 
            this.flp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp.Location = new System.Drawing.Point(1, 1);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(258, 192);
            this.flp.TabIndex = 6;
            this.flp.WrapContents = false;
            // 
            // vs
            // 
            this.vs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.vs.CesMaxValue = 100;
            this.vs.CesMovingStep = 1;
            this.vs.CesValue = 0;
            this.vs.Dock = System.Windows.Forms.DockStyle.Right;
            this.vs.Location = new System.Drawing.Point(259, 1);
            this.vs.Margin = new System.Windows.Forms.Padding(0);
            this.vs.Name = "vs";
            this.vs.Size = new System.Drawing.Size(22, 192);
            this.vs.TabIndex = 7;
            this.vs.CesScrollValueChanged += new Ces.WinForm.UI.CesScrollBar.CesVerticalScrollBar.CesScrollValueChangedEventHandler(this.vs_CesScrollValueChanged);
            // 
            // CesSimpleComboBoxPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CesBorderThickness = 1;
            this.CesFormType = Ces.WinForm.UI.CesForm.CesFormTypeEnum.None;
            this.ClientSize = new System.Drawing.Size(282, 194);
            this.Controls.Add(this.flp);
            this.Controls.Add(this.vs);
            this.KeyPreview = true;
            this.Name = "CesSimpleComboBoxPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CesSimpleComboBoxPopup";
            this.Deactivate += new System.EventHandler(this.CesSimpleComboBoxPopup_Deactivate);
            this.Load += new System.EventHandler(this.CesSimpleComboBoxPopup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CesSimpleComboBoxPopup_KeyDown);
            this.Controls.SetChildIndex(this.vs, 0);
            this.Controls.SetChildIndex(this.flp, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp;
        private CesScrollBar.CesVerticalScrollBar vs;
    }
}