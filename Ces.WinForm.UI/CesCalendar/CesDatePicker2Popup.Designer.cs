namespace Ces.WinForm.UI.CesCalendar
{
    partial class CesDatePicker2Popup
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
            mc = new MonthCalendar();
            btnApply = new Ces.WinForm.UI.CesButton.CesButton();
            btnCancel = new Ces.WinForm.UI.CesButton.CesButton();
            SuspendLayout();
            // 
            // btnOptions
            // 
            btnOptions.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            // 
            // mc
            // 
            mc.BackColor = Color.White;
            mc.Location = new Point(9, 9);
            mc.Margin = new Padding(0);
            mc.Name = "mc";
            mc.ShowTodayCircle = false;
            mc.TabIndex = 7;
            mc.TrailingForeColor = Color.Gold;
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApply.BackColor = Color.MediumSeaGreen;
            btnApply.CesBorderThickness = 1;
            btnApply.CesBorderVisible = false;
            btnApply.CesColorTemplate = CesButton.ColorTemplateEnum.Green;
            btnApply.CesEnableToolTip = false;
            btnApply.CesToolTipText = null;
            btnApply.FlatAppearance.BorderColor = Color.DarkGreen;
            btnApply.FlatAppearance.BorderSize = 0;
            btnApply.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnApply.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.ForeColor = Color.Black;
            btnApply.Location = new Point(174, 177);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(60, 27);
            btnApply.TabIndex = 8;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = Color.OrangeRed;
            btnCancel.CesBorderThickness = 1;
            btnCancel.CesBorderVisible = false;
            btnCancel.CesColorTemplate = CesButton.ColorTemplateEnum.Red;
            btnCancel.CesEnableToolTip = false;
            btnCancel.CesToolTipText = null;
            btnCancel.FlatAppearance.BorderColor = Color.Firebrick;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(10, 177);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(60, 27);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // CesDatePicker2Popup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CesBorderColor = Color.DeepSkyBlue;
            CesFormType = CesForm.CesFormTypeEnum.None;
            ClientSize = new Size(245, 212);
            Controls.Add(btnCancel);
            Controls.Add(btnApply);
            Controls.Add(mc);
            KeyPreview = true;
            MinimumSize = new Size(245, 212);
            Name = "CesDatePicker2Popup";
            Text = "CesDatePicker2Popup";
            Load += CesDatePicker2Popup_Load;
            KeyDown += CesDatePicker2Popup_KeyDown;
            Controls.SetChildIndex(mc, 0);
            Controls.SetChildIndex(btnApply, 0);
            Controls.SetChildIndex(btnCancel, 0);
            ResumeLayout(false);
        }

        #endregion

        public MonthCalendar mc;
        private CesButton.CesButton btnApply;
        private CesButton.CesButton btnCancel;
    }
}