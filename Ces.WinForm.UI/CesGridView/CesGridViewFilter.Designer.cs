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
            this.lblCurrentFilter = new System.Windows.Forms.Label();
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
            this.btnSortClear = new System.Windows.Forms.Button();
            this.btnSortDesc = new System.Windows.Forms.Button();
            this.btnSortAsc = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.comFilterType = new Ces.WinForm.UI.CesComboBox.CesSimpleComboBox();
            this.pnlTextBox.SuspendLayout();
            this.pnlDatePicker.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlRadioButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOptions
            // 
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // lblCurrentFilter
            // 
            this.lblCurrentFilter.BackColor = System.Drawing.Color.Gray;
            this.lblCurrentFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentFilter.ForeColor = System.Drawing.Color.White;
            this.lblCurrentFilter.Location = new System.Drawing.Point(1, 54);
            this.lblCurrentFilter.Name = "lblCurrentFilter";
            this.lblCurrentFilter.Size = new System.Drawing.Size(469, 23);
            this.lblCurrentFilter.TabIndex = 30;
            this.lblCurrentFilter.Text = "Filter Type :";
            this.lblCurrentFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTextBox
            // 
            this.pnlTextBox.Controls.Add(this.txtCriteriaB);
            this.pnlTextBox.Controls.Add(this.txtCriteriaA);
            this.pnlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTextBox.Location = new System.Drawing.Point(0, 0);
            this.pnlTextBox.Name = "pnlTextBox";
            this.pnlTextBox.Size = new System.Drawing.Size(280, 85);
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
            this.txtCriteriaB.Size = new System.Drawing.Size(267, 35);
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
            this.txtCriteriaA.Size = new System.Drawing.Size(267, 35);
            this.txtCriteriaA.TabIndex = 31;
            // 
            // pnlDatePicker
            // 
            this.pnlDatePicker.Controls.Add(this.dpA);
            this.pnlDatePicker.Controls.Add(this.dpB);
            this.pnlDatePicker.Controls.Add(this.lblCriteriaA);
            this.pnlDatePicker.Controls.Add(this.lblCriteriaB);
            this.pnlDatePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatePicker.Location = new System.Drawing.Point(0, 0);
            this.pnlDatePicker.Name = "pnlDatePicker";
            this.pnlDatePicker.Size = new System.Drawing.Size(280, 85);
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
            this.pnlContainer.Controls.Add(this.pnlTextBox);
            this.pnlContainer.Controls.Add(this.pnlDatePicker);
            this.pnlContainer.Controls.Add(this.pnlRadioButton);
            this.pnlContainer.Location = new System.Drawing.Point(95, 128);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(280, 85);
            this.pnlContainer.TabIndex = 29;
            // 
            // pnlRadioButton
            // 
            this.pnlRadioButton.Controls.Add(this.rbTrue);
            this.pnlRadioButton.Controls.Add(this.rbFalse);
            this.pnlRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRadioButton.Location = new System.Drawing.Point(0, 0);
            this.pnlRadioButton.Name = "pnlRadioButton";
            this.pnlRadioButton.Size = new System.Drawing.Size(280, 85);
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
            // btnSortClear
            // 
            this.btnSortClear.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridSortClear;
            this.btnSortClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSortClear.Location = new System.Drawing.Point(12, 149);
            this.btnSortClear.Name = "btnSortClear";
            this.btnSortClear.Size = new System.Drawing.Size(77, 30);
            this.btnSortClear.TabIndex = 4;
            this.btnSortClear.TabStop = false;
            this.btnSortClear.Text = "Clear";
            this.btnSortClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSortClear.UseVisualStyleBackColor = true;
            this.btnSortClear.Click += new System.EventHandler(this.btnSortClear_Click);
            // 
            // btnSortDesc
            // 
            this.btnSortDesc.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridSortDescending;
            this.btnSortDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSortDesc.Location = new System.Drawing.Point(12, 119);
            this.btnSortDesc.Name = "btnSortDesc";
            this.btnSortDesc.Size = new System.Drawing.Size(77, 30);
            this.btnSortDesc.TabIndex = 3;
            this.btnSortDesc.TabStop = false;
            this.btnSortDesc.Text = "DESC";
            this.btnSortDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSortDesc.UseVisualStyleBackColor = true;
            this.btnSortDesc.Click += new System.EventHandler(this.btnSortDesc_Click);
            // 
            // btnSortAsc
            // 
            this.btnSortAsc.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridSortAscending;
            this.btnSortAsc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSortAsc.Location = new System.Drawing.Point(12, 89);
            this.btnSortAsc.Name = "btnSortAsc";
            this.btnSortAsc.Size = new System.Drawing.Size(77, 30);
            this.btnSortAsc.TabIndex = 2;
            this.btnSortAsc.TabStop = false;
            this.btnSortAsc.Text = "ASC";
            this.btnSortAsc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSortAsc.UseVisualStyleBackColor = true;
            this.btnSortAsc.Click += new System.EventHandler(this.btnSortAsc_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridFilterClearColumn;
            this.btnClearFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearFilter.Location = new System.Drawing.Point(381, 89);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(77, 30);
            this.btnClearFilter.TabIndex = 24;
            this.btnClearFilter.TabStop = false;
            this.btnClearFilter.Text = "Clear";
            this.btnClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridFilterRemove;
            this.btnRemoveFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveFilter.Location = new System.Drawing.Point(381, 119);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(77, 30);
            this.btnRemoveFilter.TabIndex = 22;
            this.btnRemoveFilter.TabStop = false;
            this.btnRemoveFilter.Text = "Remove";
            this.btnRemoveFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // lblColumnName
            // 
            this.lblColumnName.BackColor = System.Drawing.Color.Gray;
            this.lblColumnName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblColumnName.ForeColor = System.Drawing.Color.White;
            this.lblColumnName.Location = new System.Drawing.Point(1, 31);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(469, 23);
            this.lblColumnName.TabIndex = 21;
            this.lblColumnName.Text = "Column :";
            this.lblColumnName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridFilterColumnApply;
            this.btnApplyFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApplyFilter.Location = new System.Drawing.Point(381, 149);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(77, 30);
            this.btnApplyFilter.TabIndex = 20;
            this.btnApplyFilter.TabStop = false;
            this.btnApplyFilter.Text = "Apply";
            this.btnApplyFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // comFilterType
            // 
            this.comFilterType._initialControlHeight = 0;
            this.comFilterType._titleTextSize = new System.Drawing.SizeF(30.9707F, 17.46093F);
            this.comFilterType.CesAdjustPopupToParentWidth = true;
            this.comFilterType.CesAlignToRight = false;
            this.comFilterType.CesAutoHeight = true;
            this.comFilterType.CesBackColor = System.Drawing.Color.White;
            this.comFilterType.CesBorderColor = System.Drawing.Color.Indigo;
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
            this.comFilterType.Location = new System.Drawing.Point(101, 87);
            this.comFilterType.Name = "comFilterType";
            this.comFilterType.Size = new System.Drawing.Size(267, 35);
            this.comFilterType.TabIndex = 31;
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
            this.ClientSize = new System.Drawing.Size(471, 219);
            this.Controls.Add(this.comFilterType);
            this.Controls.Add(this.btnSortClear);
            this.Controls.Add(this.lblCurrentFilter);
            this.Controls.Add(this.btnSortDesc);
            this.Controls.Add(this.btnSortAsc);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnRemoveFilter);
            this.Controls.Add(this.lblColumnName);
            this.Controls.Add(this.btnApplyFilter);
            this.KeyPreview = true;
            this.Name = "CesGridViewFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Grid Filter & Sort";
            this.Deactivate += new System.EventHandler(this.CesGridViewFilter_Deactivate);
            this.Load += new System.EventHandler(this.CesGridViewFilter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CesGridViewFilter_KeyDown);
            this.Controls.SetChildIndex(this.btnApplyFilter, 0);
            this.Controls.SetChildIndex(this.lblColumnName, 0);
            this.Controls.SetChildIndex(this.btnRemoveFilter, 0);
            this.Controls.SetChildIndex(this.btnClearFilter, 0);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.Controls.SetChildIndex(this.btnSortAsc, 0);
            this.Controls.SetChildIndex(this.btnSortDesc, 0);
            this.Controls.SetChildIndex(this.lblCurrentFilter, 0);
            this.Controls.SetChildIndex(this.btnSortClear, 0);
            this.Controls.SetChildIndex(this.comFilterType, 0);
            this.pnlTextBox.ResumeLayout(false);
            this.pnlDatePicker.ResumeLayout(false);
            this.pnlDatePicker.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlRadioButton.ResumeLayout(false);
            this.pnlRadioButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblCurrentFilter;
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
        private Button btnSortClear;
        private Button btnSortDesc;
        private Button btnSortAsc;
        private Button btnClearFilter;
        private Button btnRemoveFilter;
        private Label lblColumnName;
        private Button btnApplyFilter;
        private CesTextBox txtCriteriaB;
        private CesTextBox txtCriteriaA;
        private CesComboBox.CesSimpleComboBox comFilterType;
    }
}