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
            pnlFilter = new Panel();
            lineTop = new CesLine();
            txtFilter = new CesTextBox();
            lineBottom = new CesLine();
            splitter = new Splitter();
            btnHeader = new Ces.WinForm.UI.CesButton.CesButton();
            btnSort = new Ces.WinForm.UI.CesButton.CesButton();
            btnFilter = new Ces.WinForm.UI.CesButton.CesButton();
            pnlFilter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.WhiteSmoke;
            pnlFilter.Controls.Add(lineTop);
            pnlFilter.Controls.Add(txtFilter);
            pnlFilter.Controls.Add(lineBottom);
            pnlFilter.Dock = DockStyle.Bottom;
            pnlFilter.Location = new Point(0, 30);
            pnlFilter.Margin = new Padding(0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(168, 30);
            pnlFilter.TabIndex = 3;
            // 
            // lineTop
            // 
            lineTop.BackColor = Color.White;
            lineTop.CesAutoStick = false;
            lineTop.CesAutoStickOffset = 0;
            lineTop.CesBackColor = Color.Empty;
            lineTop.CesLineColor = Color.LightGray;
            lineTop.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lineTop.CesLineWidth = 1F;
            lineTop.CesRoundedTip = false;
            lineTop.CesVertical = false;
            lineTop.Dock = DockStyle.Top;
            lineTop.Location = new Point(0, 0);
            lineTop.Margin = new Padding(0);
            lineTop.Name = "lineTop";
            lineTop.Size = new Size(168, 1);
            lineTop.TabIndex = 2;
            // 
            // txtFilter
            // 
            txtFilter._initialControlHeight = 0;
            txtFilter.CesAutoHeight = true;
            txtFilter.CesBackColor = Color.White;
            txtFilter.CesBorderColor = Color.White;
            txtFilter.CesBorderRadius = 0;
            txtFilter.CesBorderThickness = 0;
            txtFilter.CesCharacterCasing = CharacterCasing.Normal;
            txtFilter.CesFocusColor = Color.White;
            txtFilter.CesHasFocus = false;
            txtFilter.CesHasNotification = false;
            txtFilter.CesIcon = null;
            txtFilter.CesInputType = CesInputTypeEnum.Any;
            txtFilter.CesMaxLength = 0;
            txtFilter.CesMultiLine = false;
            txtFilter.CesNotificationColor = Color.Red;
            txtFilter.CesPadding = new Padding(5);
            txtFilter.CesPasswordChar = '\0';
            txtFilter.CesPlaceHolderText = null;
            txtFilter.CesReadOnly = false;
            txtFilter.CesRightToLeft = RightToLeft.No;
            txtFilter.CesScrollBar = ScrollBars.None;
            txtFilter.CesShowClearButton = false;
            txtFilter.CesShowCopyButton = false;
            txtFilter.CesShowIcon = false;
            txtFilter.CesShowPasteButton = false;
            txtFilter.CesShowTitle = false;
            txtFilter.CesText = null;
            txtFilter.CesTextAlignment = HorizontalAlignment.Left;
            txtFilter.CesTheme = Infrastructure.ThemeEnum.White;
            txtFilter.CesTitleAutoHeight = false;
            txtFilter.CesTitleAutoWidth = false;
            txtFilter.CesTitleBackground = true;
            txtFilter.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtFilter.CesTitleHeight = 25;
            txtFilter.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            txtFilter.CesTitleText = "Enter Value";
            txtFilter.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            txtFilter.CesTitleTextColor = Color.White;
            txtFilter.CesTitleWidth = 80;
            txtFilter.CesWordWrap = false;
            txtFilter.Dock = DockStyle.Fill;
            txtFilter.Location = new Point(0, 0);
            txtFilter.Margin = new Padding(0);
            txtFilter.Name = "txtFilter";
            txtFilter.Padding = new Padding(1);
            txtFilter.Size = new Size(168, 29);
            txtFilter.TabIndex = 0;
            txtFilter.CesTextChanged += txtFilter_CesTextChanged;
            // 
            // lineBottom
            // 
            lineBottom.BackColor = Color.White;
            lineBottom.CesAutoStick = false;
            lineBottom.CesAutoStickOffset = 0;
            lineBottom.CesBackColor = Color.Empty;
            lineBottom.CesLineColor = Color.LightGray;
            lineBottom.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lineBottom.CesLineWidth = 1F;
            lineBottom.CesRoundedTip = false;
            lineBottom.CesVertical = false;
            lineBottom.Dock = DockStyle.Bottom;
            lineBottom.Location = new Point(0, 29);
            lineBottom.Margin = new Padding(0);
            lineBottom.Name = "lineBottom";
            lineBottom.Size = new Size(168, 1);
            lineBottom.TabIndex = 1;
            // 
            // splitter
            // 
            splitter.BackColor = Color.DarkGray;
            splitter.Dock = DockStyle.Right;
            splitter.Location = new Point(168, 0);
            splitter.Margin = new Padding(0);
            splitter.Name = "splitter";
            splitter.Size = new Size(1, 60);
            splitter.TabIndex = 4;
            splitter.TabStop = false;
            splitter.MouseDown += splitter_MouseDown;
            splitter.MouseUp += splitter_MouseUp;
            // 
            // btnHeader
            // 
            btnHeader.BackColor = Color.White;
            btnHeader.CesBorderThickness = 1;
            btnHeader.CesBorderVisible = false;
            btnHeader.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btnHeader.CesEnableToolTip = false;
            btnHeader.CesToolTipText = null;
            btnHeader.Dock = DockStyle.Fill;
            btnHeader.FlatAppearance.BorderColor = Color.Silver;
            btnHeader.FlatAppearance.BorderSize = 0;
            btnHeader.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            btnHeader.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnHeader.FlatStyle = FlatStyle.Flat;
            btnHeader.ForeColor = Color.Black;
            btnHeader.Location = new Point(0, 0);
            btnHeader.Name = "btnHeader";
            btnHeader.Size = new Size(128, 30);
            btnHeader.TabIndex = 5;
            btnHeader.UseVisualStyleBackColor = false;
            btnHeader.MouseEnter += btnHeader_MouseEnter;
            btnHeader.MouseLeave += btnHeader_MouseLeave;
            // 
            // btnSort
            // 
            btnSort.BackColor = Color.White;
            btnSort.CesBorderThickness = 1;
            btnSort.CesBorderVisible = false;
            btnSort.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btnSort.CesEnableToolTip = false;
            btnSort.CesToolTipText = null;
            btnSort.Dock = DockStyle.Right;
            btnSort.FlatAppearance.BorderColor = Color.Silver;
            btnSort.FlatAppearance.BorderSize = 0;
            btnSort.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            btnSort.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnSort.FlatStyle = FlatStyle.Flat;
            btnSort.ForeColor = Color.Black;
            btnSort.Image = Properties.Resources.CesGridViewSortAscending;
            btnSort.Location = new Point(128, 0);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(20, 30);
            btnSort.TabIndex = 6;
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Visible = false;
            btnSort.Click += btnSort_Click;
            btnSort.MouseEnter += btnSort_MouseEnter;
            btnSort.MouseLeave += btnSort_MouseLeave;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.White;
            btnFilter.CesBorderThickness = 1;
            btnFilter.CesBorderVisible = false;
            btnFilter.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btnFilter.CesEnableToolTip = false;
            btnFilter.CesToolTipText = null;
            btnFilter.Dock = DockStyle.Right;
            btnFilter.FlatAppearance.BorderColor = Color.Silver;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            btnFilter.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.ForeColor = Color.Black;
            btnFilter.Image = Properties.Resources.CesGridViewFilterNotSet;
            btnFilter.Location = new Point(148, 0);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(20, 30);
            btnFilter.TabIndex = 7;
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            btnFilter.MouseEnter += btnFilter_MouseEnter;
            btnFilter.MouseLeave += btnFilter_MouseLeave;
            // 
            // CesColumnHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnHeader);
            Controls.Add(btnSort);
            Controls.Add(btnFilter);
            Controls.Add(pnlFilter);
            Controls.Add(splitter);
            DoubleBuffered = true;
            Margin = new Padding(0);
            Name = "CesColumnHeader";
            Size = new Size(169, 60);
            pnlFilter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilter;
        private Splitter splitter;
        private CesLine cesLine1;
        private CesButton.CesButton btnHeader;
        private CesButton.CesButton btnSort;
        private CesButton.CesButton btnFilter;
        private CesTextBox txtFilter;
        private CesLine lineBottom;
        private CesLine lineTop;
    }
}
