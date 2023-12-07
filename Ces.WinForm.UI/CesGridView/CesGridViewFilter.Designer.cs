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
            this.pnlTextBox = new System.Windows.Forms.Panel();
            this.txtCriteriaB = new Ces.WinForm.UI.CesTextBox();
            this.txtCriteriaA = new Ces.WinForm.UI.CesTextBox();
            this.pnlDatePicker = new System.Windows.Forms.Panel();
            this.dpA = new System.Windows.Forms.DateTimePicker();
            this.dpB = new System.Windows.Forms.DateTimePicker();
            this.lblCriteriaA = new System.Windows.Forms.Label();
            this.lblCriteriaB = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlRadioButton = new System.Windows.Forms.Panel();
            this.rbTrue = new System.Windows.Forms.RadioButton();
            this.rbFalse = new System.Windows.Forms.RadioButton();
            this.comFilterType = new Ces.WinForm.UI.CesComboBox.CesSimpleComboBox();
            this.gbSort = new Ces.WinForm.UI.CesGroupBox();
            this.btnSortClear = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.btnSortDesc = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.btnSortAsc = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.gbFilter = new Ces.WinForm.UI.CesGroupBox();
            this.cesLine1 = new Ces.WinForm.UI.CesLine();
            this.btnClearFilter = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.btnRemoveFilter = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.btnApplyFilter = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.gbInfo = new Ces.WinForm.UI.CesGroupBox();
            this.lblColumnType = new System.Windows.Forms.Label();
            this.lblCurrentFilter = new System.Windows.Forms.Label();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.pnlTextBox.SuspendLayout();
            this.pnlDatePicker.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlRadioButton.SuspendLayout();
            this.gbSort.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOptions
            // 
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // pnlTextBox
            // 
            this.pnlTextBox.BackColor = System.Drawing.Color.White;
            this.pnlTextBox.Controls.Add(this.txtCriteriaB);
            this.pnlTextBox.Controls.Add(this.txtCriteriaA);
            this.pnlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTextBox.Location = new System.Drawing.Point(0, 0);
            this.pnlTextBox.Name = "pnlTextBox";
            this.pnlTextBox.Size = new System.Drawing.Size(309, 85);
            this.pnlTextBox.TabIndex = 19;
            this.pnlTextBox.Visible = false;
            // 
            // txtCriteriaB
            // 
            this.txtCriteriaB._initialControlHeight = 0;
            this.txtCriteriaB._titleTextSize = new System.Drawing.SizeF(44.88671F, 17.46093F);
            this.txtCriteriaB.CesAutoHeight = true;
            this.txtCriteriaB.CesBackColor = System.Drawing.Color.White;
            this.txtCriteriaB.CesBorderColor = System.Drawing.Color.DarkOrchid;
            this.txtCriteriaB.CesBorderRadius = 15;
            this.txtCriteriaB.CesBorderThickness = 1;
            this.txtCriteriaB.CesFocusColor = System.Drawing.Color.Beige;
            this.txtCriteriaB.CesHasFocus = false;
            this.txtCriteriaB.CesHasNotification = false;
            this.txtCriteriaB.CesIcon = null;
            this.txtCriteriaB.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            this.txtCriteriaB.CesNotificationColor = System.Drawing.Color.Red;
            this.txtCriteriaB.CesPadding = new System.Windows.Forms.Padding(3);
            this.txtCriteriaB.CesShowIcon = false;
            this.txtCriteriaB.CesShowTitle = true;
            this.txtCriteriaB.CesText = null;
            this.txtCriteriaB.CesTitleAutoHeight = false;
            this.txtCriteriaB.CesTitleAutoWidth = false;
            this.txtCriteriaB.CesTitleBackground = true;
            this.txtCriteriaB.CesTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCriteriaB.CesTitleHeight = 10;
            this.txtCriteriaB.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left;
            this.txtCriteriaB.CesTitleText = "Value B";
            this.txtCriteriaB.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            this.txtCriteriaB.CesTitleTextColor = System.Drawing.Color.White;
            this.txtCriteriaB.CesTitleWidth = 70;
            this.txtCriteriaB.Location = new System.Drawing.Point(6, 44);
            this.txtCriteriaB.Name = "txtCriteriaB";
            this.txtCriteriaB.Padding = new System.Windows.Forms.Padding(3);
            this.txtCriteriaB.Size = new System.Drawing.Size(296, 35);
            this.txtCriteriaB.TabIndex = 32;
            // 
            // txtCriteriaA
            // 
            this.txtCriteriaA._initialControlHeight = 0;
            this.txtCriteriaA._titleTextSize = new System.Drawing.SizeF(45.77733F, 17.46093F);
            this.txtCriteriaA.CesAutoHeight = true;
            this.txtCriteriaA.CesBackColor = System.Drawing.Color.White;
            this.txtCriteriaA.CesBorderColor = System.Drawing.Color.DarkOrchid;
            this.txtCriteriaA.CesBorderRadius = 15;
            this.txtCriteriaA.CesBorderThickness = 1;
            this.txtCriteriaA.CesFocusColor = System.Drawing.Color.Beige;
            this.txtCriteriaA.CesHasFocus = false;
            this.txtCriteriaA.CesHasNotification = false;
            this.txtCriteriaA.CesIcon = null;
            this.txtCriteriaA.CesInputType = Ces.WinForm.UI.CesInputTypeEnum.Any;
            this.txtCriteriaA.CesNotificationColor = System.Drawing.Color.Red;
            this.txtCriteriaA.CesPadding = new System.Windows.Forms.Padding(3);
            this.txtCriteriaA.CesShowIcon = false;
            this.txtCriteriaA.CesShowTitle = true;
            this.txtCriteriaA.CesText = null;
            this.txtCriteriaA.CesTitleAutoHeight = false;
            this.txtCriteriaA.CesTitleAutoWidth = false;
            this.txtCriteriaA.CesTitleBackground = true;
            this.txtCriteriaA.CesTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCriteriaA.CesTitleHeight = 10;
            this.txtCriteriaA.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left;
            this.txtCriteriaA.CesTitleText = "Value A";
            this.txtCriteriaA.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            this.txtCriteriaA.CesTitleTextColor = System.Drawing.Color.White;
            this.txtCriteriaA.CesTitleWidth = 70;
            this.txtCriteriaA.Location = new System.Drawing.Point(6, 3);
            this.txtCriteriaA.Name = "txtCriteriaA";
            this.txtCriteriaA.Padding = new System.Windows.Forms.Padding(3);
            this.txtCriteriaA.Size = new System.Drawing.Size(296, 35);
            this.txtCriteriaA.TabIndex = 31;
            // 
            // pnlDatePicker
            // 
            this.pnlDatePicker.BackColor = System.Drawing.Color.White;
            this.pnlDatePicker.Controls.Add(this.dpA);
            this.pnlDatePicker.Controls.Add(this.dpB);
            this.pnlDatePicker.Controls.Add(this.lblCriteriaA);
            this.pnlDatePicker.Controls.Add(this.lblCriteriaB);
            this.pnlDatePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatePicker.Location = new System.Drawing.Point(0, 0);
            this.pnlDatePicker.Name = "pnlDatePicker";
            this.pnlDatePicker.Size = new System.Drawing.Size(309, 85);
            this.pnlDatePicker.TabIndex = 20;
            this.pnlDatePicker.Visible = false;
            // 
            // dpA
            // 
            this.dpA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpA.Location = new System.Drawing.Point(73, 3);
            this.dpA.Name = "dpA";
            this.dpA.Size = new System.Drawing.Size(200, 23);
            this.dpA.TabIndex = 14;
            // 
            // dpB
            // 
            this.dpB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpB.Location = new System.Drawing.Point(73, 32);
            this.dpB.Name = "dpB";
            this.dpB.Size = new System.Drawing.Size(200, 23);
            this.dpB.TabIndex = 15;
            // 
            // lblCriteriaA
            // 
            this.lblCriteriaA.AutoSize = true;
            this.lblCriteriaA.Location = new System.Drawing.Point(14, 7);
            this.lblCriteriaA.Name = "lblCriteriaA";
            this.lblCriteriaA.Size = new System.Drawing.Size(54, 15);
            this.lblCriteriaA.TabIndex = 27;
            this.lblCriteriaA.Text = "Criteria 1";
            // 
            // lblCriteriaB
            // 
            this.lblCriteriaB.AutoSize = true;
            this.lblCriteriaB.Location = new System.Drawing.Point(14, 36);
            this.lblCriteriaB.Name = "lblCriteriaB";
            this.lblCriteriaB.Size = new System.Drawing.Size(54, 15);
            this.lblCriteriaB.TabIndex = 28;
            this.lblCriteriaB.Text = "Criteria 2";
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Controls.Add(this.pnlTextBox);
            this.pnlContainer.Controls.Add(this.pnlDatePicker);
            this.pnlContainer.Controls.Add(this.pnlRadioButton);
            this.pnlContainer.Location = new System.Drawing.Point(4, 94);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(309, 85);
            this.pnlContainer.TabIndex = 29;
            // 
            // pnlRadioButton
            // 
            this.pnlRadioButton.BackColor = System.Drawing.Color.White;
            this.pnlRadioButton.Controls.Add(this.rbTrue);
            this.pnlRadioButton.Controls.Add(this.rbFalse);
            this.pnlRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRadioButton.Location = new System.Drawing.Point(0, 0);
            this.pnlRadioButton.Name = "pnlRadioButton";
            this.pnlRadioButton.Size = new System.Drawing.Size(309, 85);
            this.pnlRadioButton.TabIndex = 21;
            this.pnlRadioButton.Visible = false;
            // 
            // rbTrue
            // 
            this.rbTrue.AutoSize = true;
            this.rbTrue.Checked = true;
            this.rbTrue.Location = new System.Drawing.Point(75, 5);
            this.rbTrue.Name = "rbTrue";
            this.rbTrue.Size = new System.Drawing.Size(46, 19);
            this.rbTrue.TabIndex = 16;
            this.rbTrue.TabStop = true;
            this.rbTrue.Text = "true";
            this.rbTrue.UseVisualStyleBackColor = true;
            // 
            // rbFalse
            // 
            this.rbFalse.AutoSize = true;
            this.rbFalse.Location = new System.Drawing.Point(148, 5);
            this.rbFalse.Name = "rbFalse";
            this.rbFalse.Size = new System.Drawing.Size(49, 19);
            this.rbFalse.TabIndex = 17;
            this.rbFalse.Text = "false";
            this.rbFalse.UseVisualStyleBackColor = true;
            // 
            // comFilterType
            // 
            this.comFilterType._initialControlHeight = 0;
            this.comFilterType._titleTextSize = new System.Drawing.SizeF(30.9707F, 17.46093F);
            this.comFilterType.CesAdjustPopupToParentWidth = true;
            this.comFilterType.CesAlignToRight = false;
            this.comFilterType.CesAutoHeight = true;
            this.comFilterType.CesBackColor = System.Drawing.Color.White;
            this.comFilterType.CesBorderColor = System.Drawing.Color.Fuchsia;
            this.comFilterType.CesBorderRadius = 15;
            this.comFilterType.CesBorderThickness = 1;
            this.comFilterType.CesFocusColor = System.Drawing.Color.Beige;
            this.comFilterType.CesHasFocus = false;
            this.comFilterType.CesHasNotification = false;
            this.comFilterType.CesIcon = global::Ces.WinForm.UI.Properties.Resources.CesGridViewFilterType;
            this.comFilterType.CesImageWidth = 35;
            this.comFilterType.CesItemHeight = 35;
            this.comFilterType.CesItemMargin = 1;
            this.comFilterType.CesNotificationColor = System.Drawing.Color.Red;
            this.comFilterType.CesPadding = new System.Windows.Forms.Padding(3);
            this.comFilterType.CesPopupSize = new System.Drawing.Size(350, 400);
            this.comFilterType.CesSelectedItem = null;
            this.comFilterType.CesShowClearButton = false;
            this.comFilterType.CesShowIcon = true;
            this.comFilterType.CesShowImage = false;
            this.comFilterType.CesShowIndicator = false;
            this.comFilterType.CesShowTitle = true;
            this.comFilterType.CesSource = null;
            this.comFilterType.CesTitleAutoHeight = false;
            this.comFilterType.CesTitleAutoWidth = false;
            this.comFilterType.CesTitleBackground = true;
            this.comFilterType.CesTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comFilterType.CesTitleHeight = 10;
            this.comFilterType.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left;
            this.comFilterType.CesTitleText = "Filter";
            this.comFilterType.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            this.comFilterType.CesTitleTextColor = System.Drawing.Color.White;
            this.comFilterType.CesTitleWidth = 70;
            this.comFilterType.Location = new System.Drawing.Point(10, 37);
            this.comFilterType.Name = "comFilterType";
            this.comFilterType.Size = new System.Drawing.Size(296, 35);
            this.comFilterType.TabIndex = 31;
            this.comFilterType.CesSelectedItemChanged += new Ces.WinForm.UI.CesComboBox.CesSimpleComboBox.CesSelectedItemChangedEventHandler(this.comFilterType_CesSelectedItemChanged);
            // 
            // gbSort
            // 
            this.gbSort._initialControlHeight = 0;
            this.gbSort._titleTextSize = new System.Drawing.SizeF(28.21093F, 17.46093F);
            this.gbSort.BackColor = System.Drawing.SystemColors.Control;
            this.gbSort.CesAutoHeight = true;
            this.gbSort.CesBackColor = System.Drawing.Color.White;
            this.gbSort.CesBorderColor = System.Drawing.Color.Gray;
            this.gbSort.CesBorderRadius = 15;
            this.gbSort.CesBorderThickness = 1;
            this.gbSort.CesFocusColor = System.Drawing.Color.Beige;
            this.gbSort.CesHasFocus = false;
            this.gbSort.CesHasNotification = false;
            this.gbSort.CesIcon = null;
            this.gbSort.CesNotificationColor = System.Drawing.Color.Red;
            this.gbSort.CesPadding = new System.Windows.Forms.Padding(3);
            this.gbSort.CesShowIcon = false;
            this.gbSort.CesShowTitle = true;
            this.gbSort.CesTitleAutoHeight = false;
            this.gbSort.CesTitleAutoWidth = false;
            this.gbSort.CesTitleBackground = true;
            this.gbSort.CesTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbSort.CesTitleHeight = 10;
            this.gbSort.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top;
            this.gbSort.CesTitleText = "Sort";
            this.gbSort.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            this.gbSort.CesTitleTextColor = System.Drawing.Color.White;
            this.gbSort.CesTitleWidth = 80;
            this.gbSort.ChildContainer = null;
            this.gbSort.Controls.Add(this.btnSortClear);
            this.gbSort.Controls.Add(this.btnSortDesc);
            this.gbSort.Controls.Add(this.btnSortAsc);
            this.gbSort.Location = new System.Drawing.Point(12, 163);
            this.gbSort.Name = "gbSort";
            this.gbSort.Size = new System.Drawing.Size(316, 84);
            this.gbSort.TabIndex = 33;
            // 
            // btnSortClear
            // 
            this.btnSortClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnSortClear.CesBackColor = System.Drawing.Color.Tomato;
            this.btnSortClear.CesBorderColor = System.Drawing.Color.Firebrick;
            this.btnSortClear.CesBorderRadius = 15;
            this.btnSortClear.CesBorderThickness = 1;
            this.btnSortClear.CesBorderVisible = false;
            this.btnSortClear.CesCircular = false;
            this.btnSortClear.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Red;
            this.btnSortClear.CesFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSortClear.CesForeColor = System.Drawing.Color.Black;
            this.btnSortClear.CesIcon = global::Ces.WinForm.UI.Properties.Resources.CesGridSortClear;
            this.btnSortClear.CesIconAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnSortClear.CesMouseDownColor = System.Drawing.Color.Tomato;
            this.btnSortClear.CesMouseOverColor = System.Drawing.Color.Salmon;
            this.btnSortClear.CesShowIcon = true;
            this.btnSortClear.CesShowText = true;
            this.btnSortClear.CesText = "Clear";
            this.btnSortClear.CesTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSortClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortClear.Location = new System.Drawing.Point(10, 39);
            this.btnSortClear.Margin = new System.Windows.Forms.Padding(10);
            this.btnSortClear.Name = "btnSortClear";
            this.btnSortClear.Size = new System.Drawing.Size(75, 35);
            this.btnSortClear.TabIndex = 7;
            this.btnSortClear.Click += new System.EventHandler(this.btnSortClear_Click);
            // 
            // btnSortDesc
            // 
            this.btnSortDesc.BackColor = System.Drawing.SystemColors.Control;
            this.btnSortDesc.CesBackColor = System.Drawing.Color.Gray;
            this.btnSortDesc.CesBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSortDesc.CesBorderRadius = 15;
            this.btnSortDesc.CesBorderThickness = 1;
            this.btnSortDesc.CesBorderVisible = false;
            this.btnSortDesc.CesCircular = false;
            this.btnSortDesc.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            this.btnSortDesc.CesFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSortDesc.CesForeColor = System.Drawing.Color.Black;
            this.btnSortDesc.CesIcon = global::Ces.WinForm.UI.Properties.Resources.CesGridSortDescending;
            this.btnSortDesc.CesIconAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnSortDesc.CesMouseDownColor = System.Drawing.Color.Gray;
            this.btnSortDesc.CesMouseOverColor = System.Drawing.Color.DarkGray;
            this.btnSortDesc.CesShowIcon = true;
            this.btnSortDesc.CesShowText = true;
            this.btnSortDesc.CesText = "Descending";
            this.btnSortDesc.CesTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSortDesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortDesc.Location = new System.Drawing.Point(199, 39);
            this.btnSortDesc.Margin = new System.Windows.Forms.Padding(10);
            this.btnSortDesc.Name = "btnSortDesc";
            this.btnSortDesc.Size = new System.Drawing.Size(107, 35);
            this.btnSortDesc.TabIndex = 6;
            this.btnSortDesc.Click += new System.EventHandler(this.btnSortDesc_Click);
            // 
            // btnSortAsc
            // 
            this.btnSortAsc.BackColor = System.Drawing.SystemColors.Control;
            this.btnSortAsc.CesBackColor = System.Drawing.Color.Gray;
            this.btnSortAsc.CesBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSortAsc.CesBorderRadius = 15;
            this.btnSortAsc.CesBorderThickness = 1;
            this.btnSortAsc.CesBorderVisible = false;
            this.btnSortAsc.CesCircular = false;
            this.btnSortAsc.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            this.btnSortAsc.CesFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSortAsc.CesForeColor = System.Drawing.Color.Black;
            this.btnSortAsc.CesIcon = global::Ces.WinForm.UI.Properties.Resources.CesGridSortAscending;
            this.btnSortAsc.CesIconAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnSortAsc.CesMouseDownColor = System.Drawing.Color.Gray;
            this.btnSortAsc.CesMouseOverColor = System.Drawing.Color.DarkGray;
            this.btnSortAsc.CesShowIcon = true;
            this.btnSortAsc.CesShowText = true;
            this.btnSortAsc.CesText = "Ascending";
            this.btnSortAsc.CesTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSortAsc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortAsc.Location = new System.Drawing.Point(94, 39);
            this.btnSortAsc.Margin = new System.Windows.Forms.Padding(10);
            this.btnSortAsc.Name = "btnSortAsc";
            this.btnSortAsc.Size = new System.Drawing.Size(97, 35);
            this.btnSortAsc.TabIndex = 5;
            this.btnSortAsc.Click += new System.EventHandler(this.btnSortAsc_Click);
            // 
            // gbFilter
            // 
            this.gbFilter._initialControlHeight = 0;
            this.gbFilter._titleTextSize = new System.Drawing.SizeF(33.85937F, 17.46093F);
            this.gbFilter.BackColor = System.Drawing.SystemColors.Control;
            this.gbFilter.CesAutoHeight = true;
            this.gbFilter.CesBackColor = System.Drawing.Color.White;
            this.gbFilter.CesBorderColor = System.Drawing.Color.Gray;
            this.gbFilter.CesBorderRadius = 15;
            this.gbFilter.CesBorderThickness = 1;
            this.gbFilter.CesFocusColor = System.Drawing.Color.Beige;
            this.gbFilter.CesHasFocus = false;
            this.gbFilter.CesHasNotification = false;
            this.gbFilter.CesIcon = null;
            this.gbFilter.CesNotificationColor = System.Drawing.Color.Red;
            this.gbFilter.CesPadding = new System.Windows.Forms.Padding(3);
            this.gbFilter.CesShowIcon = false;
            this.gbFilter.CesShowTitle = true;
            this.gbFilter.CesTitleAutoHeight = false;
            this.gbFilter.CesTitleAutoWidth = false;
            this.gbFilter.CesTitleBackground = true;
            this.gbFilter.CesTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbFilter.CesTitleHeight = 10;
            this.gbFilter.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top;
            this.gbFilter.CesTitleText = "Filter";
            this.gbFilter.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            this.gbFilter.CesTitleTextColor = System.Drawing.Color.White;
            this.gbFilter.CesTitleWidth = 80;
            this.gbFilter.ChildContainer = null;
            this.gbFilter.Controls.Add(this.cesLine1);
            this.gbFilter.Controls.Add(this.comFilterType);
            this.gbFilter.Controls.Add(this.pnlContainer);
            this.gbFilter.Location = new System.Drawing.Point(12, 253);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(316, 189);
            this.gbFilter.TabIndex = 34;
            // 
            // cesLine1
            // 
            this.cesLine1.BackColor = System.Drawing.Color.White;
            this.cesLine1.CesBackColor = System.Drawing.Color.Empty;
            this.cesLine1.CesLineColor = System.Drawing.Color.Silver;
            this.cesLine1.CesLineType = System.Drawing.Drawing2D.DashStyle.Dash;
            this.cesLine1.CesLineWidth = 1F;
            this.cesLine1.CesRoundedTip = true;
            this.cesLine1.CesVertical = false;
            this.cesLine1.Location = new System.Drawing.Point(10, 78);
            this.cesLine1.Name = "cesLine1";
            this.cesLine1.Size = new System.Drawing.Size(296, 12);
            this.cesLine1.TabIndex = 32;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = System.Drawing.SystemColors.Control;
            this.btnClearFilter.CesBackColor = System.Drawing.Color.Tomato;
            this.btnClearFilter.CesBorderColor = System.Drawing.Color.Firebrick;
            this.btnClearFilter.CesBorderRadius = 15;
            this.btnClearFilter.CesBorderThickness = 1;
            this.btnClearFilter.CesBorderVisible = false;
            this.btnClearFilter.CesCircular = false;
            this.btnClearFilter.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Red;
            this.btnClearFilter.CesFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnClearFilter.CesForeColor = System.Drawing.Color.Black;
            this.btnClearFilter.CesIcon = global::Ces.WinForm.UI.Properties.Resources.CesGridFilterClearColumn;
            this.btnClearFilter.CesIconAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnClearFilter.CesMouseDownColor = System.Drawing.Color.Tomato;
            this.btnClearFilter.CesMouseOverColor = System.Drawing.Color.Salmon;
            this.btnClearFilter.CesShowIcon = true;
            this.btnClearFilter.CesShowText = true;
            this.btnClearFilter.CesText = "Clear";
            this.btnClearFilter.CesTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilter.Location = new System.Drawing.Point(22, 455);
            this.btnClearFilter.Margin = new System.Windows.Forms.Padding(10);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(75, 35);
            this.btnClearFilter.TabIndex = 35;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.BackColor = System.Drawing.SystemColors.Control;
            this.btnRemoveFilter.CesBackColor = System.Drawing.Color.Khaki;
            this.btnRemoveFilter.CesBorderColor = System.Drawing.Color.DarkKhaki;
            this.btnRemoveFilter.CesBorderRadius = 15;
            this.btnRemoveFilter.CesBorderThickness = 1;
            this.btnRemoveFilter.CesBorderVisible = false;
            this.btnRemoveFilter.CesCircular = false;
            this.btnRemoveFilter.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Yellow;
            this.btnRemoveFilter.CesFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnRemoveFilter.CesForeColor = System.Drawing.Color.Black;
            this.btnRemoveFilter.CesIcon = global::Ces.WinForm.UI.Properties.Resources.CesGridFilterRemove;
            this.btnRemoveFilter.CesIconAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoveFilter.CesMouseDownColor = System.Drawing.Color.Khaki;
            this.btnRemoveFilter.CesMouseOverColor = System.Drawing.Color.PaleGoldenrod;
            this.btnRemoveFilter.CesShowIcon = true;
            this.btnRemoveFilter.CesShowText = true;
            this.btnRemoveFilter.CesText = "Remove";
            this.btnRemoveFilter.CesTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveFilter.Location = new System.Drawing.Point(106, 455);
            this.btnRemoveFilter.Margin = new System.Windows.Forms.Padding(10);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(97, 35);
            this.btnRemoveFilter.TabIndex = 36;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.BackColor = System.Drawing.SystemColors.Control;
            this.btnApplyFilter.CesBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnApplyFilter.CesBorderColor = System.Drawing.Color.DarkGreen;
            this.btnApplyFilter.CesBorderRadius = 15;
            this.btnApplyFilter.CesBorderThickness = 1;
            this.btnApplyFilter.CesBorderVisible = false;
            this.btnApplyFilter.CesCircular = false;
            this.btnApplyFilter.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Green;
            this.btnApplyFilter.CesFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnApplyFilter.CesForeColor = System.Drawing.Color.Black;
            this.btnApplyFilter.CesIcon = global::Ces.WinForm.UI.Properties.Resources.CesGridFilterColumnApply;
            this.btnApplyFilter.CesIconAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnApplyFilter.CesMouseDownColor = System.Drawing.Color.MediumSeaGreen;
            this.btnApplyFilter.CesMouseOverColor = System.Drawing.Color.DarkSeaGreen;
            this.btnApplyFilter.CesShowIcon = true;
            this.btnApplyFilter.CesShowText = true;
            this.btnApplyFilter.CesText = "Apply";
            this.btnApplyFilter.CesTextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.btnApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyFilter.Location = new System.Drawing.Point(211, 455);
            this.btnApplyFilter.Margin = new System.Windows.Forms.Padding(10);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(107, 35);
            this.btnApplyFilter.TabIndex = 37;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // gbInfo
            // 
            this.gbInfo._initialControlHeight = 0;
            this.gbInfo._titleTextSize = new System.Drawing.SizeF(76.15232F, 17.46093F);
            this.gbInfo.BackColor = System.Drawing.SystemColors.Control;
            this.gbInfo.CesAutoHeight = true;
            this.gbInfo.CesBackColor = System.Drawing.Color.White;
            this.gbInfo.CesBorderColor = System.Drawing.Color.Gray;
            this.gbInfo.CesBorderRadius = 15;
            this.gbInfo.CesBorderThickness = 1;
            this.gbInfo.CesFocusColor = System.Drawing.Color.Beige;
            this.gbInfo.CesHasFocus = false;
            this.gbInfo.CesHasNotification = false;
            this.gbInfo.CesIcon = null;
            this.gbInfo.CesNotificationColor = System.Drawing.Color.Red;
            this.gbInfo.CesPadding = new System.Windows.Forms.Padding(3);
            this.gbInfo.CesShowIcon = false;
            this.gbInfo.CesShowTitle = true;
            this.gbInfo.CesTitleAutoHeight = false;
            this.gbInfo.CesTitleAutoWidth = false;
            this.gbInfo.CesTitleBackground = true;
            this.gbInfo.CesTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbInfo.CesTitleHeight = 10;
            this.gbInfo.CesTitlePosition = Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top;
            this.gbInfo.CesTitleText = "Column Info";
            this.gbInfo.CesTitleTextAlignment = Ces.WinForm.UI.Infrastructure.CesTitleContentAlignmentEnum.Center;
            this.gbInfo.CesTitleTextColor = System.Drawing.Color.White;
            this.gbInfo.CesTitleWidth = 80;
            this.gbInfo.ChildContainer = null;
            this.gbInfo.Controls.Add(this.lblColumnType);
            this.gbInfo.Controls.Add(this.lblCurrentFilter);
            this.gbInfo.Controls.Add(this.lblColumnName);
            this.gbInfo.Location = new System.Drawing.Point(12, 42);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(316, 115);
            this.gbInfo.TabIndex = 38;
            // 
            // lblColumnType
            // 
            this.lblColumnType.BackColor = System.Drawing.Color.White;
            this.lblColumnType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblColumnType.Location = new System.Drawing.Point(10, 57);
            this.lblColumnType.Name = "lblColumnType";
            this.lblColumnType.Size = new System.Drawing.Size(296, 23);
            this.lblColumnType.TabIndex = 33;
            this.lblColumnType.Text = "Type :";
            this.lblColumnType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentFilter
            // 
            this.lblCurrentFilter.BackColor = System.Drawing.Color.White;
            this.lblCurrentFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCurrentFilter.Location = new System.Drawing.Point(10, 83);
            this.lblCurrentFilter.Name = "lblCurrentFilter";
            this.lblCurrentFilter.Size = new System.Drawing.Size(296, 23);
            this.lblCurrentFilter.TabIndex = 32;
            this.lblCurrentFilter.Text = "Filter :";
            this.lblCurrentFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblColumnName
            // 
            this.lblColumnName.BackColor = System.Drawing.Color.White;
            this.lblColumnName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblColumnName.Location = new System.Drawing.Point(10, 31);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(296, 23);
            this.lblColumnName.TabIndex = 31;
            this.lblColumnName.Text = "Name :";
            this.lblColumnName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CesGridViewFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CesBorderThickness = 1;
            this.CesFormType = Ces.WinForm.UI.CesForm.CesFormTypeEnum.Dialog;
            this.CesMaximizeButtonVisible = false;
            this.CesMinimizeButtonVisible = false;
            this.CesOptionButtonVisible = false;
            this.CesTitle = "Filter && Sort";
            this.ClientSize = new System.Drawing.Size(341, 505);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.btnRemoveFilter);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.gbSort);
            this.KeyPreview = true;
            this.Name = "CesGridViewFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Grid Filter & Sort";
            this.Deactivate += new System.EventHandler(this.CesGridViewFilter_Deactivate);
            this.Load += new System.EventHandler(this.CesGridViewFilter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CesGridViewFilter_KeyDown);
            this.Controls.SetChildIndex(this.gbSort, 0);
            this.Controls.SetChildIndex(this.gbFilter, 0);
            this.Controls.SetChildIndex(this.btnClearFilter, 0);
            this.Controls.SetChildIndex(this.btnRemoveFilter, 0);
            this.Controls.SetChildIndex(this.btnApplyFilter, 0);
            this.Controls.SetChildIndex(this.gbInfo, 0);
            this.pnlTextBox.ResumeLayout(false);
            this.pnlDatePicker.ResumeLayout(false);
            this.pnlDatePicker.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlRadioButton.ResumeLayout(false);
            this.pnlRadioButton.PerformLayout();
            this.gbSort.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel pnlTextBox;
        private Panel pnlDatePicker;
        private DateTimePicker dpA;
        private DateTimePicker dpB;
        private Panel pnlContainer;
        private Panel pnlRadioButton;
        private RadioButton rbTrue;
        private RadioButton rbFalse;
        private Label lblCriteriaB;
        private Label lblCriteriaA;
        private CesTextBox txtCriteriaB;
        private CesTextBox txtCriteriaA;
        private CesComboBox.CesSimpleComboBox comFilterType;
        private CesGroupBox gbSort;
        private CesButton.CesRoundedButton btnSortClear;
        private CesButton.CesRoundedButton btnSortDesc;
        private CesButton.CesRoundedButton btnSortAsc;
        private CesGroupBox gbFilter;
        private CesLine cesLine1;
        private CesButton.CesRoundedButton btnClearFilter;
        private CesButton.CesRoundedButton btnRemoveFilter;
        private CesButton.CesRoundedButton btnApplyFilter;
        private CesGroupBox gbInfo;
        private Label lblCurrentFilter;
        private Label lblColumnName;
        private Label lblColumnType;
    }
}