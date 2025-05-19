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
            btn = new Ces.WinForm.UI.CesButton.CesButton();
            pnlFilter = new Panel();
            txt = new CesTextBox();
            splitter = new Splitter();
            cesLine1 = new CesLine();
            pnlFilter.SuspendLayout();
            SuspendLayout();
            // 
            // btn
            // 
            btn.BackColor = Color.White;
            btn.CesBorderThickness = 0;
            btn.CesBorderVisible = false;
            btn.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btn.CesEnableToolTip = false;
            btn.CesToolTipText = null;
            btn.Dock = DockStyle.Fill;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            btn.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.Black;
            btn.Location = new Point(0, 0);
            btn.Margin = new Padding(0);
            btn.Name = "btn";
            btn.Size = new Size(190, 29);
            btn.TabIndex = 0;
            btn.UseVisualStyleBackColor = false;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.LightGray;
            pnlFilter.Controls.Add(txt);
            pnlFilter.Dock = DockStyle.Bottom;
            pnlFilter.Location = new Point(0, 30);
            pnlFilter.Margin = new Padding(0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(190, 25);
            pnlFilter.TabIndex = 3;
            // 
            // txt
            // 
            txt._initialControlHeight = 0;
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
            txt.CesTitleWidth = 25;
            txt.CesWordWrap = false;
            txt.Dock = DockStyle.Fill;
            txt.Location = new Point(0, 0);
            txt.Margin = new Padding(0);
            txt.Name = "txt";
            txt.Padding = new Padding(3);
            txt.Size = new Size(190, 25);
            txt.TabIndex = 0;
            txt.CesTextChanged += txt_CesTextChanged;
            // 
            // splitter
            // 
            splitter.BackColor = Color.DarkGray;
            splitter.Dock = DockStyle.Right;
            splitter.Location = new Point(190, 0);
            splitter.Margin = new Padding(0);
            splitter.Name = "splitter";
            splitter.Size = new Size(1, 55);
            splitter.TabIndex = 4;
            splitter.TabStop = false;
            splitter.MouseDown += splitter_MouseDown;
            splitter.MouseUp += splitter_MouseUp;
            // 
            // cesLine1
            // 
            cesLine1.BackColor = Color.White;
            cesLine1.CesAutoStick = false;
            cesLine1.CesAutoStickOffset = 0;
            cesLine1.CesBackColor = Color.Empty;
            cesLine1.CesLineColor = Color.DarkGray;
            cesLine1.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            cesLine1.CesLineWidth = 1F;
            cesLine1.CesRoundedTip = false;
            cesLine1.CesVertical = false;
            cesLine1.Dock = DockStyle.Bottom;
            cesLine1.Location = new Point(0, 29);
            cesLine1.Margin = new Padding(0);
            cesLine1.Name = "cesLine1";
            cesLine1.Size = new Size(190, 1);
            cesLine1.TabIndex = 5;
            // 
            // CesColumnHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn);
            Controls.Add(cesLine1);
            Controls.Add(pnlFilter);
            Controls.Add(splitter);
            Margin = new Padding(0);
            Name = "CesColumnHeader";
            Size = new Size(191, 55);
            pnlFilter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CesButton.CesButton btn;
        private Panel pnlFilter;
        private CesTextBox txt;
        private Splitter splitter;
        private CesLine cesLine1;
    }
}
