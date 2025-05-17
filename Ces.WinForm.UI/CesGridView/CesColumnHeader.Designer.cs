namespace Ces.WinForm.UI.CesGridView
{
    partial class CesColumnHeader
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
            btn = new CesButton.CesButton();
            pnlFilter = new Panel();
            txt = new CesTextBox();
            pnlFilter.SuspendLayout();
            SuspendLayout();
            // 
            // btn
            // 
            btn.BackColor = Color.LightGray;
            btn.CesBorderThickness = 0;
            btn.CesBorderVisible = false;
            btn.CesColorTemplate = CesButton.ColorTemplateEnum.Silver;
            btn.CesEnableToolTip = false;
            btn.CesToolTipText = null;
            btn.Dock = DockStyle.Fill;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.LightGray;
            btn.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.Black;
            btn.Location = new Point(0, 0);
            btn.Name = "btn";
            btn.Size = new Size(262, 30);
            btn.TabIndex = 0;
            btn.Text = "cesButton1";
            btn.UseVisualStyleBackColor = false;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.LightGray;
            pnlFilter.Controls.Add(txt);
            pnlFilter.Dock = DockStyle.Bottom;
            pnlFilter.Location = new Point(0, 30);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(3);
            pnlFilter.Size = new Size(262, 31);
            pnlFilter.TabIndex = 3;
            // 
            // txt
            // 
            txt._initialControlHeight = 0;
            txt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt.CesAutoHeight = true;
            txt.CesBackColor = Color.White;
            txt.CesBorderColor = Color.White;
            txt.CesBorderRadius = 0;
            txt.CesBorderThickness = 1;
            txt.CesCharacterCasing = CharacterCasing.Normal;
            txt.CesFocusColor = Color.Beige;
            txt.CesHasFocus = false;
            txt.CesHasNotification = false;
            txt.CesIcon = null;
            txt.CesInputType = CesInputTypeEnum.Any;
            txt.CesMaxLength = 0;
            txt.CesMultiLine = false;
            txt.CesNotificationColor = Color.Red;
            txt.CesPadding = new Padding(5);
            txt.CesPasswordChar = '\0';
            txt.CesPlaceHolderText = null;
            txt.CesReadOnly = false;
            txt.CesRightToLeft = RightToLeft.No;
            txt.CesScrollBar = ScrollBars.None;
            txt.CesShowClearButton = false;
            txt.CesShowCopyButton = false;
            txt.CesShowIcon = false;
            txt.CesShowPasteButton = false;
            txt.CesShowTitle = false;
            txt.CesText = null;
            txt.CesTextAlignment = HorizontalAlignment.Left;
            txt.CesTitleAutoHeight = false;
            txt.CesTitleAutoWidth = false;
            txt.CesTitleBackground = true;
            txt.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt.CesTitleHeight = 25;
            txt.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            txt.CesTitleText = "Enter Value";
            txt.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            txt.CesTitleTextColor = Color.White;
            txt.CesTitleWidth = 80;
            txt.CesWordWrap = false;
            txt.Location = new Point(2, 4);
            txt.Name = "txt";
            txt.Padding = new Padding(3);
            txt.Size = new Size(258, 25);
            txt.TabIndex = 0;
            txt.CesTextChanged += txt_CesTextChanged;
            // 
            // CesColumnHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn);
            Controls.Add(pnlFilter);
            Name = "CesColumnHeader";
            Size = new Size(262, 61);
            pnlFilter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CesButton.CesButton btn;
        private Panel pnlFilter;
        private CesTextBox txt;
    }
}
