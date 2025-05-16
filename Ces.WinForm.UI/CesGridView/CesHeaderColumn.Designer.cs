namespace Ces.WinForm.UI.CesGridView
{
    partial class CesHeaderColumn
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
            txt = new CesTextBox();
            splitter = new Splitter();
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
            btn.Size = new Size(302, 45);
            btn.TabIndex = 0;
            btn.Text = "cesButton1";
            btn.UseVisualStyleBackColor = false;
            // 
            // txt
            // 
            txt._initialControlHeight = 0;
            txt.CesAutoHeight = true;
            txt.CesBackColor = Color.White;
            txt.CesBorderColor = Color.LightGray;
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
            txt.CesShowIcon = true;
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
            txt.CesTitleText = "=";
            txt.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            txt.CesTitleTextColor = Color.White;
            txt.CesTitleWidth = 40;
            txt.CesWordWrap = false;
            txt.Dock = DockStyle.Bottom;
            txt.Location = new Point(0, 45);
            txt.Name = "txt";
            txt.Padding = new Padding(3);
            txt.Size = new Size(302, 35);
            txt.TabIndex = 1;
            // 
            // splitter
            // 
            splitter.Dock = DockStyle.Right;
            splitter.Location = new Point(302, 0);
            splitter.Name = "splitter";
            splitter.Size = new Size(3, 80);
            splitter.TabIndex = 2;
            splitter.TabStop = false;
            // 
            // CesHeaderColumn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn);
            Controls.Add(txt);
            Controls.Add(splitter);
            Name = "CesHeaderColumn";
            Size = new Size(305, 80);
            ResumeLayout(false);
        }

        #endregion

        private CesButton.CesButton btn;
        private CesTextBox txt;
        private Splitter splitter;
    }
}
