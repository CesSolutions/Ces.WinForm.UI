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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CesSimpleComboBoxPopup));
            this.lb = new Ces.WinForm.UI.CesListBox.CesListBox();
            this.SuspendLayout();
            // 
            // btnOptions
            // 
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // lb
            // 
            this.lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb.CesDisplayMember = "";
            this.lb.CesHighlightColor = System.Drawing.Color.Khaki;
            this.lb.CesImageWidth = 24;
            this.lb.CesIndicatorColor = System.Drawing.Color.DodgerBlue;
            this.lb.CesItemHeight = 30;
            this.lb.CesMultiSelect = false;
            this.lb.CesSelectedItem = null;
            this.lb.CesSelectedItems = ((System.Collections.Generic.IList<object>)(resources.GetObject("lb.CesSelectedItems")));
            this.lb.CesSelectionColor = System.Drawing.Color.Orange;
            this.lb.CesSelectionForeColor = System.Drawing.Color.White;
            this.lb.CesShowImage = false;
            this.lb.CesShowIndicator = false;
            this.lb.CesShowSearchBox = true;
            this.lb.CesShowStatusBar = true;
            this.lb.CesValueMember = "";
            this.lb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb.Location = new System.Drawing.Point(1, 1);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(280, 242);
            this.lb.TabIndex = 6;
            this.lb.Load += new System.EventHandler(this.lb_Load);
            // 
            // CesSimpleComboBoxPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CesBorderThickness = 1;
            this.CesFormType = Ces.WinForm.UI.CesForm.CesFormTypeEnum.None;
            this.ClientSize = new System.Drawing.Size(282, 244);
            this.Controls.Add(this.lb);
            this.KeyPreview = true;
            this.Name = "CesSimpleComboBoxPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CesSimpleComboBoxPopup";
            this.Deactivate += new System.EventHandler(this.CesSimpleComboBoxPopup_Deactivate);
            this.Load += new System.EventHandler(this.CesSimpleComboBoxPopup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CesSimpleComboBoxPopup_KeyDown);
            this.Controls.SetChildIndex(this.lb, 0);
            this.ResumeLayout(false);

        }

        #endregion

        public CesListBox.CesListBox lb;
    }
}