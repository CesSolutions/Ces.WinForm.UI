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
            dpB = new CesCalendar.CesDatePicker2();
            dpA = new CesCalendar.CesDatePicker2();
            btnSortAsc = new CesButton.CesButton();
            btnSortDesc = new CesButton.CesButton();
            cesLine2 = new CesLine();
            comFilterType = new CesComboBox.CesComboBox();
            btnApplyFilter = new CesButton.CesButton();
            btnCancel = new CesButton.CesButton();
            btnRemoveFilter = new CesButton.CesButton();
            btnClearFilter = new CesButton.CesButton();
            sc = new SplitContainer();
            lbUniqueItems = new CesListBox.CesListBox();
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
            pnlTextBox.Size = new Size(325, 84);
            pnlTextBox.TabIndex = 19;
            pnlTextBox.Visible = false;
            // 
            // txtCriteriaB
            // 
            txtCriteriaB._initialControlHeight = 0;
            txtCriteriaB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCriteriaB.CesAutoHeight = true;
            txtCriteriaB.CesBackColor = Color.White;
            txtCriteriaB.CesBorderColor = Color.Gainsboro;
            txtCriteriaB.CesBorderRadius = 0;
            txtCriteriaB.CesBorderThickness = 1;
            txtCriteriaB.CesCharacterCasing = CharacterCasing.Normal;
            txtCriteriaB.CesFocusColor = Color.Beige;
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
            txtCriteriaB.CesTitleAutoHeight = false;
            txtCriteriaB.CesTitleAutoWidth = false;
            txtCriteriaB.CesTitleBackground = true;
            txtCriteriaB.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCriteriaB.CesTitleHeight = 25;
            txtCriteriaB.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            txtCriteriaB.CesTitleText = "Value 2";
            txtCriteriaB.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            txtCriteriaB.CesTitleTextColor = Color.Black;
            txtCriteriaB.CesTitleWidth = 80;
            txtCriteriaB.CesWordWrap = false;
            txtCriteriaB.Location = new Point(3, 44);
            txtCriteriaB.Name = "txtCriteriaB";
            txtCriteriaB.Padding = new Padding(3);
            txtCriteriaB.Size = new Size(319, 35);
            txtCriteriaB.TabIndex = 47;
            // 
            // txtCriteriaA
            // 
            txtCriteriaA._initialControlHeight = 0;
            txtCriteriaA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCriteriaA.CesAutoHeight = true;
            txtCriteriaA.CesBackColor = Color.White;
            txtCriteriaA.CesBorderColor = Color.Gainsboro;
            txtCriteriaA.CesBorderRadius = 0;
            txtCriteriaA.CesBorderThickness = 1;
            txtCriteriaA.CesCharacterCasing = CharacterCasing.Normal;
            txtCriteriaA.CesFocusColor = Color.Beige;
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
            txtCriteriaA.CesTitleAutoHeight = false;
            txtCriteriaA.CesTitleAutoWidth = false;
            txtCriteriaA.CesTitleBackground = true;
            txtCriteriaA.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCriteriaA.CesTitleHeight = 25;
            txtCriteriaA.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            txtCriteriaA.CesTitleText = "Value 1";
            txtCriteriaA.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            txtCriteriaA.CesTitleTextColor = Color.Black;
            txtCriteriaA.CesTitleWidth = 80;
            txtCriteriaA.CesWordWrap = false;
            txtCriteriaA.Location = new Point(3, 3);
            txtCriteriaA.Name = "txtCriteriaA";
            txtCriteriaA.Padding = new Padding(3);
            txtCriteriaA.Size = new Size(319, 35);
            txtCriteriaA.TabIndex = 46;
            // 
            // pnlRadioButton
            // 
            pnlRadioButton.BackColor = Color.White;
            pnlRadioButton.Controls.Add(rbTrue);
            pnlRadioButton.Controls.Add(rbFalse);
            pnlRadioButton.Dock = DockStyle.Fill;
            pnlRadioButton.Location = new Point(0, 0);
            pnlRadioButton.Name = "pnlRadioButton";
            pnlRadioButton.Size = new Size(325, 84);
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
            pnlDatePicker.Size = new Size(325, 84);
            pnlDatePicker.TabIndex = 20;
            pnlDatePicker.Visible = false;
            // 
            // dpB
            // 
            dpB._initialControlHeight = 0;
            dpB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            dpB.CesStartDate = new DateTime(2025, 5, 1, 23, 27, 3, 302);
            dpB.CesTitleAutoHeight = false;
            dpB.CesTitleAutoWidth = false;
            dpB.CesTitleBackground = true;
            dpB.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dpB.CesTitleHeight = 25;
            dpB.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            dpB.CesTitleText = "Value 2";
            dpB.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            dpB.CesTitleTextColor = Color.Black;
            dpB.CesTitleWidth = 80;
            dpB.Location = new Point(2, 44);
            dpB.Name = "dpB";
            dpB.Size = new Size(319, 35);
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
            dpA.CesStartDate = new DateTime(2025, 5, 1, 23, 27, 3, 310);
            dpA.CesTitleAutoHeight = false;
            dpA.CesTitleAutoWidth = false;
            dpA.CesTitleBackground = true;
            dpA.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dpA.CesTitleHeight = 25;
            dpA.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            dpA.CesTitleText = "Value 1";
            dpA.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            dpA.CesTitleTextColor = Color.Black;
            dpA.CesTitleWidth = 80;
            dpA.Location = new Point(3, 3);
            dpA.Name = "dpA";
            dpA.Size = new Size(319, 35);
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
            btnSortAsc.Size = new Size(342, 30);
            btnSortAsc.TabIndex = 40;
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
            btnSortDesc.Size = new Size(342, 30);
            btnSortDesc.TabIndex = 41;
            btnSortDesc.Text = "   Sort Z to A";
            btnSortDesc.TextAlign = ContentAlignment.MiddleLeft;
            btnSortDesc.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSortDesc.UseVisualStyleBackColor = false;
            btnSortDesc.Click += btnSortDesc_Click;
            // 
            // cesLine2
            // 
            cesLine2.CesAutoStick = false;
            cesLine2.CesAutoStickOffset = 3;
            cesLine2.CesBackColor = Color.Empty;
            cesLine2.CesLineColor = Color.Gainsboro;
            cesLine2.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            cesLine2.CesLineWidth = 1F;
            cesLine2.CesRoundedTip = true;
            cesLine2.CesVertical = false;
            cesLine2.Dock = DockStyle.Top;
            cesLine2.Location = new Point(1, 61);
            cesLine2.Margin = new Padding(0);
            cesLine2.Name = "cesLine2";
            cesLine2.Size = new Size(342, 8);
            cesLine2.TabIndex = 43;
            // 
            // comFilterType
            // 
            comFilterType._initialControlHeight = 0;
            comFilterType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comFilterType.CesAdjustPopupToParentWidth = true;
            comFilterType.CesAlignToRight = false;
            comFilterType.CesAutoHeight = true;
            comFilterType.CesBackColor = Color.White;
            comFilterType.CesBorderColor = Color.Gainsboro;
            comFilterType.CesBorderRadius = 0;
            comFilterType.CesBorderThickness = 1;
            comFilterType.CesDataSource = null;
            comFilterType.CesDisplayMember = null;
            comFilterType.CesDropDownOnFocus = false;
            comFilterType.CesFocusColor = Color.Beige;
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
            comFilterType.CesTitleAutoHeight = false;
            comFilterType.CesTitleAutoWidth = false;
            comFilterType.CesTitleBackground = true;
            comFilterType.CesTitleFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comFilterType.CesTitleHeight = 25;
            comFilterType.CesTitlePosition = Infrastructure.CesTitlePositionEnum.Left;
            comFilterType.CesTitleText = "Filter";
            comFilterType.CesTitleTextAlignment = Infrastructure.CesTitleContentAlignmentEnum.Center;
            comFilterType.CesTitleTextColor = Color.Black;
            comFilterType.CesTitleWidth = 80;
            comFilterType.CesValueMember = null;
            comFilterType.Location = new Point(12, 74);
            comFilterType.Name = "comFilterType";
            comFilterType.Padding = new Padding(3);
            comFilterType.Size = new Size(319, 35);
            comFilterType.TabIndex = 45;
            comFilterType.CesSelectedItemChanged += comFilterType_CesSelectedItemChanged;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApplyFilter.BackColor = Color.MediumSeaGreen;
            btnApplyFilter.CesBorderThickness = 1;
            btnApplyFilter.CesBorderVisible = false;
            btnApplyFilter.CesColorTemplate = CesButton.ColorTemplateEnum.Green;
            btnApplyFilter.CesEnableToolTip = false;
            btnApplyFilter.CesToolTipText = null;
            btnApplyFilter.FlatAppearance.BorderColor = Color.DarkGreen;
            btnApplyFilter.FlatAppearance.BorderSize = 0;
            btnApplyFilter.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnApplyFilter.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            btnApplyFilter.FlatStyle = FlatStyle.Flat;
            btnApplyFilter.ForeColor = Color.Black;
            btnApplyFilter.Image = Properties.Resources.CesGridFilterColumnApply;
            btnApplyFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnApplyFilter.Location = new Point(258, 409);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(75, 35);
            btnApplyFilter.TabIndex = 46;
            btnApplyFilter.Text = "Apply";
            btnApplyFilter.TextAlign = ContentAlignment.MiddleLeft;
            btnApplyFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnApplyFilter.UseVisualStyleBackColor = false;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.LightGray;
            btnCancel.CesBorderThickness = 1;
            btnCancel.CesBorderVisible = false;
            btnCancel.CesColorTemplate = CesButton.ColorTemplateEnum.Silver;
            btnCancel.CesEnableToolTip = false;
            btnCancel.CesToolTipText = null;
            btnCancel.FlatAppearance.BorderColor = Color.Gray;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.LightGray;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.Black;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(177, 409);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 35);
            btnCancel.TabIndex = 47;
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
            btnRemoveFilter.Location = new Point(94, 409);
            btnRemoveFilter.Name = "btnRemoveFilter";
            btnRemoveFilter.Size = new Size(75, 35);
            btnRemoveFilter.TabIndex = 48;
            btnRemoveFilter.Text = "Remove";
            btnRemoveFilter.TextAlign = ContentAlignment.MiddleLeft;
            btnRemoveFilter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRemoveFilter.UseVisualStyleBackColor = false;
            btnRemoveFilter.Click += btnRemoveFilter_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClearFilter.BackColor = Color.Tomato;
            btnClearFilter.CesBorderThickness = 1;
            btnClearFilter.CesBorderVisible = false;
            btnClearFilter.CesColorTemplate = CesButton.ColorTemplateEnum.Tomato;
            btnClearFilter.CesEnableToolTip = false;
            btnClearFilter.CesToolTipText = null;
            btnClearFilter.FlatAppearance.BorderColor = Color.Firebrick;
            btnClearFilter.FlatAppearance.BorderSize = 0;
            btnClearFilter.FlatAppearance.MouseDownBackColor = Color.Tomato;
            btnClearFilter.FlatAppearance.MouseOverBackColor = Color.Salmon;
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.ForeColor = Color.Black;
            btnClearFilter.Image = Properties.Resources.CesGridFilterClearColumn;
            btnClearFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearFilter.Location = new Point(13, 409);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(75, 35);
            btnClearFilter.TabIndex = 49;
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
            sc.Panel2.Controls.Add(lbUniqueItems);
            sc.Size = new Size(325, 291);
            sc.SplitterDistance = 84;
            sc.TabIndex = 50;
            // 
            // lbUniqueItems
            // 
            lbUniqueItems.CesDisplayMember = "";
            lbUniqueItems.CesHighlightColor = Color.Khaki;
            lbUniqueItems.CesImageMember = "";
            lbUniqueItems.CesImageWidth = 24;
            lbUniqueItems.CesIndicatorColor = Color.DodgerBlue;
            lbUniqueItems.CesItemHeight = 25;
            lbUniqueItems.CesMultiSelect = true;
            lbUniqueItems.CesSelectedItem = null;
            lbUniqueItems.CesSelectedItems = null;
            lbUniqueItems.CesSelectionColor = Color.Orange;
            lbUniqueItems.CesSelectionForeColor = Color.White;
            lbUniqueItems.CesShowImage = false;
            lbUniqueItems.CesShowIndicator = false;
            lbUniqueItems.CesShowSearchBox = true;
            lbUniqueItems.CesShowStatusBar = true;
            lbUniqueItems.CesValueMember = "";
            lbUniqueItems.Dock = DockStyle.Fill;
            lbUniqueItems.Location = new Point(0, 0);
            lbUniqueItems.Name = "lbUniqueItems";
            lbUniqueItems.Size = new Size(325, 203);
            lbUniqueItems.TabIndex = 0;
            // 
            // CesGridViewFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CesBorderColor = Color.Silver;
            CesBorderThickness = 1;
            CesFormType = CesForm.CesFormTypeEnum.None;
            CesMaximizeButtonVisible = false;
            CesMinimizeButtonVisible = false;
            CesShowResizeIcon = true;
            CesTitle = "Filter && Sort";
            ClientSize = new Size(344, 453);
            Controls.Add(sc);
            Controls.Add(btnClearFilter);
            Controls.Add(btnRemoveFilter);
            Controls.Add(btnCancel);
            Controls.Add(btnApplyFilter);
            Controls.Add(comFilterType);
            Controls.Add(cesLine2);
            Controls.Add(btnSortDesc);
            Controls.Add(btnSortAsc);
            KeyPreview = true;
            Name = "CesGridViewFilter";
            StartPosition = FormStartPosition.Manual;
            Text = "Grid Filter & Sort";
            Deactivate += CesGridViewFilter_Deactivate;
            Load += CesGridViewFilter_Load;
            KeyDown += CesGridViewFilter_KeyDown;
            Controls.SetChildIndex(btnSortAsc, 0);
            Controls.SetChildIndex(btnSortDesc, 0);
            Controls.SetChildIndex(cesLine2, 0);
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
        private CesLine cesLine2;
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
        private CesListBox.CesListBox lbUniqueItems;
    }
}