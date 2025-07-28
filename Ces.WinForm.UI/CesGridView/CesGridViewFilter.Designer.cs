namespace Ces.WinForm.UI.CesGridView
{
    partial class CesGridViewFilter
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
            pnlTextBox = new Panel();
            txtCriteriaB = new CesTextBox();
            txtCriteriaA = new CesTextBox();
            pnlRadioButton = new Panel();
            rbTrue = new RadioButton();
            rbFalse = new RadioButton();
            pnlDatePicker = new Panel();
            dpB = new Ces.WinForm.UI.CesCalendar.CesDatePicker2();
            dpA = new Ces.WinForm.UI.CesCalendar.CesDatePicker2();
            btnSortAsc = new Ces.WinForm.UI.CesButton.CesButton();
            btnSortDesc = new Ces.WinForm.UI.CesButton.CesButton();
            topLine = new CesLine();
            comFilterType = new Ces.WinForm.UI.CesComboBox.CesComboBox();
            btnApplyFilter = new Ces.WinForm.UI.CesButton.CesButton();
            btnCancel = new Ces.WinForm.UI.CesButton.CesButton();
            btnRemoveFilter = new Ces.WinForm.UI.CesButton.CesButton();
            btnClearFilter = new Ces.WinForm.UI.CesButton.CesButton();
            sc = new SplitContainer();
            lbSelectionBox = new Ces.WinForm.UI.CesListBox.CesListBox();
            pnlTextBox.SuspendLayout();
            pnlRadioButton.SuspendLayout();
            pnlDatePicker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sc).BeginInit();
            sc.Panel1.SuspendLayout();
            sc.Panel2.SuspendLayout();
            sc.SuspendLayout();
            SuspendLayout();
            // 
            // btnOptions
            // 
            btnOptions.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            // 
            // pnlTextBox
            // 
            pnlTextBox.BackColor = Color.White;
            pnlTextBox.Controls.Add(txtCriteriaB);
            pnlTextBox.Controls.Add(txtCriteriaA);
            pnlTextBox.Dock = DockStyle.Fill;
            pnlTextBox.Location = new Point(0, 0);
            pnlTextBox.Name = "pnlTextBox";
            pnlTextBox.Size = new Size(321, 42);
            pnlTextBox.TabIndex = 19;
            pnlTextBox.Visible = false;
            // 
            // txtCriteriaB
            // 
            txtCriteriaB._initialControlHeight = 0;
            txtCriteriaB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCriteriaB.BackColor = Color.White;
            txtCriteriaB.CesAutoHeight = true;
            txtCriteriaB.CesBackColor = Color.White;
            txtCriteriaB.CesBorderColor = Color.FromArgb(224, 224, 224);
            txtCriteriaB.CesBorderRadius = 0;
            txtCriteriaB.CesBorderThickness = 1;
            txtCriteriaB.CesCharacterCasing = CharacterCasing.Normal;
            txtCriteriaB.CesFocusColor = Color.White;
            txtCriteriaB.CesHasFocus = false;
            txtCriteriaB.CesHasNotification = false;
            txtCriteriaB.CesIcon = null;
            txtCriteriaB.CesInputType = CesInputTypeEnum.Any;
            txtCriteriaB.CesMaxLength = 0;
            txtCriteriaB.CesMultiLine = false;
            txtCriteriaB.CesNotificationColor = Color.Red;
            txtCriteriaB.CesPadding = new Padding(5);
            txtCriteriaB.CesPasswordChar = '\0';
            txtCriteriaB.CesPlaceHolderText = null;
            txtCriteriaB.CesReadOnly = false;
            txtCriteriaB.CesRightToLeft = RightToLeft.No;
            txtCriteriaB.CesScrollBar = ScrollBars.None;
            txtCriteriaB.CesShowClearButton = false;
            txtCriteriaB.CesShowCopyButton = false;
            txtCriteriaB.CesShowIcon = false;
            txtCriteriaB.CesShowPasteButton = false;
            txtCriteriaB.CesShowTitle = true;
            txtCriteriaB.CesText = null;
            txtCriteriaB.CesTextAlignment = HorizontalAlignment.Left;
            txtCriteriaB.CesTheme = Infrastructure.ThemeEnum.None;
            txtCriteriaB.CesTitleAutoHeight = false;
            txtCriteriaB.CesTitleAutoWidth = false;
            txtCriteriaB.CesTitleBackground = true;
            txtCriteriaB.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCriteriaB.CesTitleHeight = 25;
            txtCriteriaB.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            txtCriteriaB.CesTitleText = "B";
            txtCriteriaB.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            txtCriteriaB.CesTitleTextColor = Color.Black;
            txtCriteriaB.CesTitleWidth = 40;
            txtCriteriaB.CesWordWrap = false;
            txtCriteriaB.Location = new Point(168, 3);
            txtCriteriaB.Name = "txtCriteriaB";
            txtCriteriaB.Padding = new Padding(3);
            txtCriteriaB.Size = new Size(150, 35);
            txtCriteriaB.TabIndex = 1;
            // 
            // txtCriteriaA
            // 
            txtCriteriaA._initialControlHeight = 0;
            txtCriteriaA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCriteriaA.BackColor = Color.White;
            txtCriteriaA.CesAutoHeight = true;
            txtCriteriaA.CesBackColor = Color.White;
            txtCriteriaA.CesBorderColor = Color.FromArgb(224, 224, 224);
            txtCriteriaA.CesBorderRadius = 0;
            txtCriteriaA.CesBorderThickness = 1;
            txtCriteriaA.CesCharacterCasing = CharacterCasing.Normal;
            txtCriteriaA.CesFocusColor = Color.White;
            txtCriteriaA.CesHasFocus = false;
            txtCriteriaA.CesHasNotification = false;
            txtCriteriaA.CesIcon = null;
            txtCriteriaA.CesInputType = CesInputTypeEnum.Any;
            txtCriteriaA.CesMaxLength = 0;
            txtCriteriaA.CesMultiLine = false;
            txtCriteriaA.CesNotificationColor = Color.Red;
            txtCriteriaA.CesPadding = new Padding(5);
            txtCriteriaA.CesPasswordChar = '\0';
            txtCriteriaA.CesPlaceHolderText = null;
            txtCriteriaA.CesReadOnly = false;
            txtCriteriaA.CesRightToLeft = RightToLeft.No;
            txtCriteriaA.CesScrollBar = ScrollBars.None;
            txtCriteriaA.CesShowClearButton = false;
            txtCriteriaA.CesShowCopyButton = false;
            txtCriteriaA.CesShowIcon = false;
            txtCriteriaA.CesShowPasteButton = false;
            txtCriteriaA.CesShowTitle = true;
            txtCriteriaA.CesText = "";
            txtCriteriaA.CesTextAlignment = HorizontalAlignment.Left;
            txtCriteriaA.CesTheme = Infrastructure.ThemeEnum.None;
            txtCriteriaA.CesTitleAutoHeight = false;
            txtCriteriaA.CesTitleAutoWidth = false;
            txtCriteriaA.CesTitleBackground = true;
            txtCriteriaA.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCriteriaA.CesTitleHeight = 25;
            txtCriteriaA.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            txtCriteriaA.CesTitleText = "A";
            txtCriteriaA.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            txtCriteriaA.CesTitleTextColor = Color.Black;
            txtCriteriaA.CesTitleWidth = 40;
            txtCriteriaA.CesWordWrap = false;
            txtCriteriaA.Location = new Point(3, 3);
            txtCriteriaA.Name = "txtCriteriaA";
            txtCriteriaA.Padding = new Padding(3);
            txtCriteriaA.Size = new Size(150, 35);
            txtCriteriaA.TabIndex = 0;
            // 
            // pnlRadioButton
            // 
            pnlRadioButton.BackColor = Color.White;
            pnlRadioButton.Controls.Add(rbTrue);
            pnlRadioButton.Controls.Add(rbFalse);
            pnlRadioButton.Dock = DockStyle.Fill;
            pnlRadioButton.Location = new Point(0, 0);
            pnlRadioButton.Name = "pnlRadioButton";
            pnlRadioButton.Size = new Size(321, 42);
            pnlRadioButton.TabIndex = 21;
            pnlRadioButton.Visible = false;
            // 
            // rbTrue
            // 
            rbTrue.AutoSize = true;
            rbTrue.Checked = true;
            rbTrue.Location = new Point(3, 3);
            rbTrue.Name = "rbTrue";
            rbTrue.Size = new Size(46, 19);
            rbTrue.TabIndex = 16;
            rbTrue.TabStop = true;
            rbTrue.Text = "true";
            rbTrue.UseVisualStyleBackColor = true;
            // 
            // rbFalse
            // 
            rbFalse.AutoSize = true;
            rbFalse.Location = new Point(99, 3);
            rbFalse.Name = "rbFalse";
            rbFalse.Size = new Size(49, 19);
            rbFalse.TabIndex = 17;
            rbFalse.Text = "false";
            rbFalse.UseVisualStyleBackColor = true;
            // 
            // pnlDatePicker
            // 
            pnlDatePicker.BackColor = Color.White;
            pnlDatePicker.Controls.Add(dpB);
            pnlDatePicker.Controls.Add(dpA);
            pnlDatePicker.Dock = DockStyle.Fill;
            pnlDatePicker.Location = new Point(0, 0);
            pnlDatePicker.Name = "pnlDatePicker";
            pnlDatePicker.Size = new Size(321, 42);
            pnlDatePicker.TabIndex = 20;
            pnlDatePicker.Visible = false;
            // 
            // dpB
            // 
            dpB._initialControlHeight = 0;
            dpB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dpB.BackColor = SystemColors.Control;
            dpB.CesAlignToRight = false;
            dpB.CesAlwaysToday = true;
            dpB.CesAutoHeight = true;
            dpB.CesBackColor = Color.White;
            dpB.CesBorderColor = Color.Gainsboro;
            dpB.CesBorderRadius = 0;
            dpB.CesBorderThickness = 1;
            dpB.CesEndDate = null;
            dpB.CesFocusColor = Color.Beige;
            dpB.CesHasFocus = false;
            dpB.CesHasNotification = false;
            dpB.CesIcon = null;
            dpB.CesNotificationColor = Color.Red;
            dpB.CesPadding = new Padding(5);
            dpB.CesShowIcon = false;
            dpB.CesShowLongFormat = false;
            dpB.CesShowTitle = true;
            dpB.CesStartDate = new DateTime(2025, 7, 28, 18, 26, 23, 89);
            dpB.CesTitleAutoHeight = false;
            dpB.CesTitleAutoWidth = false;
            dpB.CesTitleBackground = true;
            dpB.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dpB.CesTitleHeight = 25;
            dpB.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            dpB.CesTitleText = "B";
            dpB.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            dpB.CesTitleTextColor = Color.Black;
            dpB.CesTitleWidth = 40;
            dpB.Location = new Point(168, 3);
            dpB.Name = "dpB";
            dpB.Size = new Size(150, 35);
            dpB.TabIndex = 30;
            // 
            // dpA
            // 
            dpA._initialControlHeight = 0;
            dpA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dpA.BackColor = SystemColors.Control;
            dpA.CesAlignToRight = false;
            dpA.CesAlwaysToday = true;
            dpA.CesAutoHeight = true;
            dpA.CesBackColor = Color.White;
            dpA.CesBorderColor = Color.Gainsboro;
            dpA.CesBorderRadius = 0;
            dpA.CesBorderThickness = 1;
            dpA.CesEndDate = null;
            dpA.CesFocusColor = Color.Beige;
            dpA.CesHasFocus = false;
            dpA.CesHasNotification = false;
            dpA.CesIcon = null;
            dpA.CesNotificationColor = Color.Red;
            dpA.CesPadding = new Padding(5);
            dpA.CesShowIcon = false;
            dpA.CesShowLongFormat = false;
            dpA.CesShowTitle = true;
            dpA.CesStartDate = new DateTime(2025, 7, 28, 18, 26, 23, 98);
            dpA.CesTitleAutoHeight = false;
            dpA.CesTitleAutoWidth = false;
            dpA.CesTitleBackground = true;
            dpA.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dpA.CesTitleHeight = 25;
            dpA.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            dpA.CesTitleText = "A";
            dpA.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            dpA.CesTitleTextColor = Color.Black;
            dpA.CesTitleWidth = 40;
            dpA.Location = new Point(3, 3);
            dpA.Name = "dpA";
            dpA.Size = new Size(150, 35);
            dpA.TabIndex = 29;
            // 
            // btnSortAsc
            // 
            btnSortAsc.BackColor = Color.White;
            btnSortAsc.CesBorderThickness = 1;
            btnSortAsc.CesBorderVisible = false;
            btnSortAsc.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btnSortAsc.CesEnableToolTip = false;
            btnSortAsc.CesToolTipText = null;
            btnSortAsc.Dock = DockStyle.Top;
            btnSortAsc.FlatAppearance.BorderColor = Color.Gray;
            btnSortAsc.FlatAppearance.BorderSize = 0;
            btnSortAsc.FlatAppearance.MouseDownBackColor = Color.LightGray;
            btnSortAsc.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnSortAsc.FlatStyle = FlatStyle.Flat;
            btnSortAsc.ForeColor = Color.Black;
            btnSortAsc.Image = Properties.Resources.CesGridViewSortAscending;
            btnSortAsc.ImageAlign = ContentAlignment.MiddleLeft;
            btnSortAsc.Location = new Point(1, 1);
            btnSortAsc.Name = "btnSortAsc";
            btnSortAsc.Size = new Size(338, 30);
            btnSortAsc.TabIndex = 0;
            btnSortAsc.Text = "   Sort A to Z";
            btnSortAsc.TextAlign = ContentAlignment.MiddleLeft;
            btnSortAsc.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSortAsc.UseVisualStyleBackColor = false;
            btnSortAsc.Click += btnSortAsc_Click;
            // 
            // btnSortDesc
            // 
            btnSortDesc.BackColor = Color.White;
            btnSortDesc.CesBorderThickness = 1;
            btnSortDesc.CesBorderVisible = false;
            btnSortDesc.CesColorTemplate = CesButton.ColorTemplateEnum.None;
            btnSortDesc.CesEnableToolTip = false;
            btnSortDesc.CesToolTipText = null;
            btnSortDesc.Dock = DockStyle.Top;
            btnSortDesc.FlatAppearance.BorderColor = Color.Silver;
            btnSortDesc.FlatAppearance.BorderSize = 0;
            btnSortDesc.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            btnSortDesc.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            btnSortDesc.FlatStyle = FlatStyle.Flat;
            btnSortDesc.ForeColor = Color.Black;
            btnSortDesc.Image = Properties.Resources.CesGridViewSortDescending;
            btnSortDesc.ImageAlign = ContentAlignment.MiddleLeft;
            btnSortDesc.Location = new Point(1, 31);
            btnSortDesc.Name = "btnSortDesc";
            btnSortDesc.Size = new Size(338, 30);
            btnSortDesc.TabIndex = 1;
            btnSortDesc.Text = "   Sort Z to A";
            btnSortDesc.TextAlign = ContentAlignment.MiddleLeft;
            btnSortDesc.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSortDesc.UseVisualStyleBackColor = false;
            btnSortDesc.Click += btnSortDesc_Click;
            // 
            // topLine
            // 
            topLine.CesAutoStick = false;
            topLine.CesAutoStickOffset = 3;
            topLine.CesBackColor = Color.Empty;
            topLine.CesLineColor = Color.Gainsboro;
            topLine.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            topLine.CesLineWidth = 1F;
            topLine.CesRoundedTip = true;
            topLine.CesVertical = false;
            topLine.Dock = DockStyle.Top;
            topLine.Location = new Point(1, 61);
            topLine.Margin = new Padding(0);
            topLine.Name = "topLine";
            topLine.Size = new Size(338, 8);
            topLine.TabIndex = 2;
            // 
            // comFilterType
            // 
            comFilterType._initialControlHeight = 0;
            comFilterType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comFilterType.BackColor = Color.White;
            comFilterType.CesAdjustPopupToParentWidth = true;
            comFilterType.CesAlignToRight = false;
            comFilterType.CesAutoHeight = true;
            comFilterType.CesBackColor = Color.White;
            comFilterType.CesBorderColor = Color.FromArgb(224, 224, 224);
            comFilterType.CesBorderRadius = 0;
            comFilterType.CesBorderThickness = 1;
            comFilterType.CesDataSource = null;
            comFilterType.CesDisplayMember = null;
            comFilterType.CesDropDownOnFocus = false;
            comFilterType.CesFocusColor = Color.White;
            comFilterType.CesHasFocus = false;
            comFilterType.CesHasNotification = false;
            comFilterType.CesIcon = null;
            comFilterType.CesImageWidth = 24;
            comFilterType.CesItemHeight = 30;
            comFilterType.CesKeepPreviousSelection = false;
            comFilterType.CesLoadingMode = false;
            comFilterType.CesNotificationColor = Color.Red;
            comFilterType.CesPadding = new Padding(5);
            comFilterType.CesPopupSize = new Size(350, 400);
            comFilterType.CesSelectedItem = null;
            comFilterType.CesSelectedValue = null;
            comFilterType.CesSelectFirstItem = false;
            comFilterType.CesSelectFirstItemIfPreviousWasNull = true;
            comFilterType.CesShowAddItemButton = false;
            comFilterType.CesShowClearButton = false;
            comFilterType.CesShowEditItemButton = false;
            comFilterType.CesShowIcon = false;
            comFilterType.CesShowImage = true;
            comFilterType.CesShowIndicator = false;
            comFilterType.CesShowLoadButton = false;
            comFilterType.CesShowSearchBox = true;
            comFilterType.CesShowStatusBar = true;
            comFilterType.CesShowTitle = true;
            comFilterType.CesStopSelectedItemChangedEvent = false;
            comFilterType.CesTheme = Infrastructure.ThemeEnum.None;
            comFilterType.CesTitleAutoHeight = false;
            comFilterType.CesTitleAutoWidth = false;
            comFilterType.CesTitleBackground = true;
            comFilterType.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comFilterType.CesTitleHeight = 25;
            comFilterType.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            comFilterType.CesTitleText = "Filter";
            comFilterType.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            comFilterType.CesTitleTextColor = Color.Black;
            comFilterType.CesTitleWidth = 40;
            comFilterType.CesValueMember = null;
            comFilterType.Location = new Point(12, 74);
            comFilterType.Name = "comFilterType";
            comFilterType.Padding = new Padding(3);
            comFilterType.Size = new Size(315, 35);
            comFilterType.TabIndex = 3;
            comFilterType.CesSelectedItemChanged += comFilterType_CesSelectedItemChanged;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnApplyFilter.BackColor = Color.FromArgb(120, 209, 160);
            btnApplyFilter.CesBorderThickness = 1;
            btnApplyFilter.CesBorderVisible = false;
            btnApplyFilter.CesColorTemplate = CesButton.ColorTemplateEnum.LightGreen;
            btnApplyFilter.CesEnableToolTip = false;
            btnApplyFilter.CesToolTipText = null;
            btnApplyFilter.FlatAppearance.BorderColor = Color.MediumSeaGreen;
            btnApplyFilter.FlatAppearance.BorderSize = 0;
            btnApplyFilter.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 209, 160);
            btnApplyFilter.FlatAppearance.MouseOverBackColor = Color.MediumSeaGreen;
            btnApplyFilter.FlatStyle = FlatStyle.Flat;
            btnApplyFilter.ForeColor = Color.Black;
            btnApplyFilter.Image = Properties.Resources.CesGridFilterColumnApply;
            btnApplyFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnApplyFilter.Location = new Point(253, 397);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(75, 30);
            btnApplyFilter.TabIndex = 4;
            btnApplyFilter.Text = "Apply";
            btnApplyFilter.TextAlign = ContentAlignment.MiddleLeft;
            btnApplyFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnApplyFilter.UseVisualStyleBackColor = false;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.CesBorderThickness = 1;
            btnCancel.CesBorderVisible = false;
            btnCancel.CesColorTemplate = CesButton.ColorTemplateEnum.Light;
            btnCancel.CesEnableToolTip = false;
            btnCancel.CesToolTipText = null;
            btnCancel.FlatAppearance.BorderColor = Color.Silver;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.Black;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(173, 397);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 5;
            btnCancel.TabStop = false;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRemoveFilter
            // 
            btnRemoveFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemoveFilter.BackColor = Color.Khaki;
            btnRemoveFilter.CesBorderThickness = 1;
            btnRemoveFilter.CesBorderVisible = false;
            btnRemoveFilter.CesColorTemplate = CesButton.ColorTemplateEnum.Yellow;
            btnRemoveFilter.CesEnableToolTip = false;
            btnRemoveFilter.CesToolTipText = null;
            btnRemoveFilter.FlatAppearance.BorderColor = Color.DarkKhaki;
            btnRemoveFilter.FlatAppearance.BorderSize = 0;
            btnRemoveFilter.FlatAppearance.MouseDownBackColor = Color.Khaki;
            btnRemoveFilter.FlatAppearance.MouseOverBackColor = Color.PaleGoldenrod;
            btnRemoveFilter.FlatStyle = FlatStyle.Flat;
            btnRemoveFilter.ForeColor = Color.Black;
            btnRemoveFilter.Image = Properties.Resources.CesGridFilterRemove;
            btnRemoveFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnRemoveFilter.Location = new Point(92, 397);
            btnRemoveFilter.Name = "btnRemoveFilter";
            btnRemoveFilter.Size = new Size(75, 30);
            btnRemoveFilter.TabIndex = 6;
            btnRemoveFilter.TabStop = false;
            btnRemoveFilter.Text = "Remove";
            btnRemoveFilter.TextAlign = ContentAlignment.MiddleLeft;
            btnRemoveFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRemoveFilter.UseVisualStyleBackColor = false;
            btnRemoveFilter.Click += btnRemoveFilter_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClearFilter.BackColor = Color.FromArgb(255, 113, 113);
            btnClearFilter.CesBorderThickness = 1;
            btnClearFilter.CesBorderVisible = false;
            btnClearFilter.CesColorTemplate = CesButton.ColorTemplateEnum.LightRed;
            btnClearFilter.CesEnableToolTip = false;
            btnClearFilter.CesToolTipText = null;
            btnClearFilter.FlatAppearance.BorderColor = Color.Tomato;
            btnClearFilter.FlatAppearance.BorderSize = 0;
            btnClearFilter.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 113, 113);
            btnClearFilter.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 150, 150);
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.ForeColor = Color.Black;
            btnClearFilter.Image = Properties.Resources.CesGridFilterClearColumn;
            btnClearFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearFilter.Location = new Point(11, 397);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(75, 30);
            btnClearFilter.TabIndex = 7;
            btnClearFilter.TabStop = false;
            btnClearFilter.Text = "Clear";
            btnClearFilter.TextAlign = ContentAlignment.MiddleLeft;
            btnClearFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // sc
            // 
            sc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sc.FixedPanel = FixedPanel.Panel1;
            sc.IsSplitterFixed = true;
            sc.Location = new Point(9, 112);
            sc.Name = "sc";
            sc.Orientation = Orientation.Horizontal;
            // 
            // sc.Panel1
            // 
            sc.Panel1.Controls.Add(pnlTextBox);
            sc.Panel1.Controls.Add(pnlRadioButton);
            sc.Panel1.Controls.Add(pnlDatePicker);
            // 
            // sc.Panel2
            // 
            sc.Panel2.Controls.Add(lbSelectionBox);
            sc.Size = new Size(321, 279);
            sc.SplitterDistance = 42;
            sc.TabIndex = 50;
            // 
            // lbSelectionBox
            // 
            lbSelectionBox.BackColor = Color.Silver;
            lbSelectionBox.CesDisplayMember = "";
            lbSelectionBox.CesHighlightColor = Color.Khaki;
            lbSelectionBox.CesImageMember = "";
            lbSelectionBox.CesImageWidth = 24;
            lbSelectionBox.CesIndicatorColor = Color.DodgerBlue;
            lbSelectionBox.CesItemHeight = 25;
            lbSelectionBox.CesMultiSelect = true;
            lbSelectionBox.CesSelectedItem = null;
            lbSelectionBox.CesSelectedItems = null;
            lbSelectionBox.CesSelectionColor = Color.Orange;
            lbSelectionBox.CesSelectionForeColor = Color.White;
            lbSelectionBox.CesShowImage = false;
            lbSelectionBox.CesShowIndicator = false;
            lbSelectionBox.CesShowSearchBox = true;
            lbSelectionBox.CesShowStatusBar = true;
            lbSelectionBox.CesTheme = Infrastructure.ThemeEnum.White;
            lbSelectionBox.CesValueMember = "";
            lbSelectionBox.Dock = DockStyle.Fill;
            lbSelectionBox.Location = new Point(0, 0);
            lbSelectionBox.Name = "lbSelectionBox";
            lbSelectionBox.Size = new Size(321, 233);
            lbSelectionBox.TabIndex = 0;
            // 
            // CesGridViewFilter
            // 
            AcceptButton = btnApplyFilter;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            CesBorderColor = Color.Silver;
            CesBorderThickness = 1;
            CesFormType = CesForm.CesFormTypeEnum.None;
            CesMaximizeButtonVisible = false;
            CesMinimizeButtonVisible = false;
            CesShowResizeIcon = true;
            CesTitle = "Filter && Sort";
            ClientSize = new Size(340, 436);
            Controls.Add(sc);
            Controls.Add(btnClearFilter);
            Controls.Add(btnRemoveFilter);
            Controls.Add(btnCancel);
            Controls.Add(btnApplyFilter);
            Controls.Add(comFilterType);
            Controls.Add(topLine);
            Controls.Add(btnSortDesc);
            Controls.Add(btnSortAsc);
            KeyPreview = true;
            MinimumSize = new Size(340, 200);
            Name = "CesGridViewFilter";
            StartPosition = FormStartPosition.Manual;
            Text = "Grid Filter & Sort";
            Load += CesGridViewFilter_Load;
            Controls.SetChildIndex(btnSortAsc, 0);
            Controls.SetChildIndex(btnSortDesc, 0);
            Controls.SetChildIndex(topLine, 0);
            Controls.SetChildIndex(comFilterType, 0);
            Controls.SetChildIndex(btnApplyFilter, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(btnRemoveFilter, 0);
            Controls.SetChildIndex(btnClearFilter, 0);
            Controls.SetChildIndex(sc, 0);
            pnlTextBox.ResumeLayout(false);
            pnlRadioButton.ResumeLayout(false);
            pnlRadioButton.PerformLayout();
            pnlDatePicker.ResumeLayout(false);
            sc.Panel1.ResumeLayout(false);
            sc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sc).EndInit();
            sc.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlTextBox;
        private Panel pnlDatePicker;
        private Panel pnlRadioButton;
        private RadioButton rbTrue;
        private RadioButton rbFalse;
        private CesButton.CesButton btnSortAsc;
        private CesButton.CesButton btnSortDesc;
        private CesLine topLine;
        private CesComboBox.CesComboBox comFilterType;
        private CesTextBox txtCriteriaA;
        private CesTextBox txtCriteriaB;
        private CesCalendar.CesDatePicker2 dpA;
        private CesCalendar.CesDatePicker2 dpB;
        private CesButton.CesButton btnApplyFilter;
        private CesButton.CesButton btnCancel;
        private CesButton.CesButton btnRemoveFilter;
        private CesButton.CesButton btnClearFilter;
        private SplitContainer sc;
        private CesListBox.CesListBox lbSelectionBox;
    }
}