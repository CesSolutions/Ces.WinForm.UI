namespace Ces.WinForm.UI.CesComboBox
{
    partial class CesComboBoxPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CesComboBoxPopup));
            lb = new Ces.WinForm.UI.CesListBox.CesListBox();
            SuspendLayout();
            // 
            // btnOptions
            // 
            btnOptions.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            // 
            // lb
            // 
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.CesDisplayMember = "";
            lb.CesHighlightColor = Color.Khaki;
            lb.CesImageMember = "";
            lb.CesImageWidth = 24;
            lb.CesIndicatorColor = Color.DodgerBlue;
            lb.CesItemHeight = 30;
            lb.CesMultiSelect = false;
            lb.CesSelectedItem = null;
            lb.CesSelectedItems = (List<object>)resources.GetObject("lb.CesSelectedItems");
            lb.CesSelectionColor = Color.Orange;
            lb.CesSelectionForeColor = Color.White;
            lb.CesShowImage = false;
            lb.CesShowIndicator = false;
            lb.CesShowSearchBox = true;
            lb.CesShowStatusBar = true;
            lb.CesTheme = Infrastructure.ThemeEnum.White;
            lb.CesValueMember = "";
            lb.Dock = DockStyle.Fill;
            lb.Location = new Point(1, 1);
            lb.Name = "lb";
            lb.Size = new Size(249, 268);
            lb.TabIndex = 6;
            lb.CesSelectedItemChanged += lb_CesSelectedItemChanged;
            // 
            // CesComboBoxPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CesBorderThickness = 1;
            CesFormType = CesForm.CesFormTypeEnum.None;
            ClientSize = new Size(251, 270);
            Controls.Add(lb);
            KeyPreview = true;
            Name = "CesComboBoxPopup";
            StartPosition = FormStartPosition.Manual;
            Text = "CesSimpleComboBoxPopup";
            Deactivate += CesSimpleComboBoxPopup_Deactivate;
            KeyDown += CesSimpleComboBoxPopup_KeyDown;
            Controls.SetChildIndex(lb, 0);
            ResumeLayout(false);

        }

        #endregion

        public CesListBox.CesListBox lb;
    }
}