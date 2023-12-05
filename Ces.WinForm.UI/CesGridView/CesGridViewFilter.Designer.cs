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
            this.txtCriteriaA = new System.Windows.Forms.TextBox();
            this.txtCriteriaB = new System.Windows.Forms.TextBox();
            this.pnlDatePicker = new System.Windows.Forms.Panel();
            this.dpA = new System.Windows.Forms.DateTimePicker();
            this.dpB = new System.Windows.Forms.DateTimePicker();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlRadioButton = new System.Windows.Forms.Panel();
            this.rbTrue = new System.Windows.Forms.RadioButton();
            this.rbFalse = new System.Windows.Forms.RadioButton();
            this.lblCriteriaB = new System.Windows.Forms.Label();
            this.lblCriteriaA = new System.Windows.Forms.Label();
            this.btnSortClear = new System.Windows.Forms.Button();
            this.btnSortDesc = new System.Windows.Forms.Button();
            this.btnSortAsc = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.comFilterType = new System.Windows.Forms.ComboBox();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
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
            this.lblCurrentFilter.Size = new System.Drawing.Size(512, 23);
            this.lblCurrentFilter.TabIndex = 30;
            this.lblCurrentFilter.Text = "Filter Type :";
            this.lblCurrentFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTextBox
            // 
            this.pnlTextBox.Controls.Add(this.txtCriteriaA);
            this.pnlTextBox.Controls.Add(this.txtCriteriaB);
            this.pnlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTextBox.Location = new System.Drawing.Point(0, 0);
            this.pnlTextBox.Name = "pnlTextBox";
            this.pnlTextBox.Size = new System.Drawing.Size(234, 61);
            this.pnlTextBox.TabIndex = 19;
            this.pnlTextBox.Visible = false;
            // 
            // txtCriteriaA
            // 
            this.txtCriteriaA.Location = new System.Drawing.Point(3, 3);
            this.txtCriteriaA.Name = "txtCriteriaA";
            this.txtCriteriaA.Size = new System.Drawing.Size(221, 23);
            this.txtCriteriaA.TabIndex = 0;
            // 
            // txtCriteriaB
            // 
            this.txtCriteriaB.Location = new System.Drawing.Point(3, 32);
            this.txtCriteriaB.Name = "txtCriteriaB";
            this.txtCriteriaB.Size = new System.Drawing.Size(221, 23);
            this.txtCriteriaB.TabIndex = 12;
            // 
            // pnlDatePicker
            // 
            this.pnlDatePicker.Controls.Add(this.dpA);
            this.pnlDatePicker.Controls.Add(this.dpB);
            this.pnlDatePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatePicker.Location = new System.Drawing.Point(0, 0);
            this.pnlDatePicker.Name = "pnlDatePicker";
            this.pnlDatePicker.Size = new System.Drawing.Size(234, 61);
            this.pnlDatePicker.TabIndex = 20;
            this.pnlDatePicker.Visible = false;
            // 
            // dpA
            // 
            this.dpA.Location = new System.Drawing.Point(3, 3);
            this.dpA.Name = "dpA";
            this.dpA.Size = new System.Drawing.Size(200, 23);
            this.dpA.TabIndex = 14;
            // 
            // dpB
            // 
            this.dpB.Location = new System.Drawing.Point(3, 32);
            this.dpB.Name = "dpB";
            this.dpB.Size = new System.Drawing.Size(200, 23);
            this.dpB.TabIndex = 15;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlTextBox);
            this.pnlContainer.Controls.Add(this.pnlDatePicker);
            this.pnlContainer.Controls.Add(this.pnlRadioButton);
            this.pnlContainer.Location = new System.Drawing.Point(165, 122);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(234, 61);
            this.pnlContainer.TabIndex = 29;
            // 
            // pnlRadioButton
            // 
            this.pnlRadioButton.Controls.Add(this.rbTrue);
            this.pnlRadioButton.Controls.Add(this.rbFalse);
            this.pnlRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRadioButton.Location = new System.Drawing.Point(0, 0);
            this.pnlRadioButton.Name = "pnlRadioButton";
            this.pnlRadioButton.Size = new System.Drawing.Size(234, 61);
            this.pnlRadioButton.TabIndex = 21;
            this.pnlRadioButton.Visible = false;
            // 
            // rbTrue
            // 
            this.rbTrue.AutoSize = true;
            this.rbTrue.Checked = true;
            this.rbTrue.Location = new System.Drawing.Point(10, 3);
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
            this.rbFalse.Location = new System.Drawing.Point(62, 3);
            this.rbFalse.Name = "rbFalse";
            this.rbFalse.Size = new System.Drawing.Size(49, 19);
            this.rbFalse.TabIndex = 17;
            this.rbFalse.Text = "false";
            this.rbFalse.UseVisualStyleBackColor = true;
            // 
            // lblCriteriaB
            // 
            this.lblCriteriaB.AutoSize = true;
            this.lblCriteriaB.Location = new System.Drawing.Point(103, 152);
            this.lblCriteriaB.Name = "lblCriteriaB";
            this.lblCriteriaB.Size = new System.Drawing.Size(54, 15);
            this.lblCriteriaB.TabIndex = 28;
            this.lblCriteriaB.Text = "Criteria 2";
            // 
            // lblCriteriaA
            // 
            this.lblCriteriaA.AutoSize = true;
            this.lblCriteriaA.Location = new System.Drawing.Point(103, 123);
            this.lblCriteriaA.Name = "lblCriteriaA";
            this.lblCriteriaA.Size = new System.Drawing.Size(54, 15);
            this.lblCriteriaA.TabIndex = 27;
            this.lblCriteriaA.Text = "Criteria 1";
            // 
            // btnSortClear
            // 
            this.btnSortClear.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridSortClear;
            this.btnSortClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSortClear.Location = new System.Drawing.Point(10, 150);
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
            this.btnSortDesc.Location = new System.Drawing.Point(10, 120);
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
            this.btnSortAsc.Location = new System.Drawing.Point(10, 90);
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
            this.btnClearFilter.Location = new System.Drawing.Point(426, 90);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(77, 30);
            this.btnClearFilter.TabIndex = 24;
            this.btnClearFilter.TabStop = false;
            this.btnClearFilter.Text = "Clear";
            this.btnClearFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // comFilterType
            // 
            this.comFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comFilterType.FormattingEnabled = true;
            this.comFilterType.Location = new System.Drawing.Point(168, 93);
            this.comFilterType.Name = "comFilterType";
            this.comFilterType.Size = new System.Drawing.Size(221, 23);
            this.comFilterType.TabIndex = 23;
            this.comFilterType.TabStop = false;
            this.comFilterType.SelectedIndexChanged += new System.EventHandler(this.comFilterType_SelectedIndexChanged);
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridFilterRemove;
            this.btnRemoveFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveFilter.Location = new System.Drawing.Point(426, 120);
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
            this.lblColumnName.Size = new System.Drawing.Size(512, 23);
            this.lblColumnName.TabIndex = 21;
            this.lblColumnName.Text = "Column :";
            this.lblColumnName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(124, 94);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(33, 15);
            this.lblFilter.TabIndex = 26;
            this.lblFilter.Text = "Filter";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Image = global::Ces.WinForm.UI.Properties.Resources.CesGridFilterColumnApply;
            this.btnApplyFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApplyFilter.Location = new System.Drawing.Point(426, 150);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(77, 30);
            this.btnApplyFilter.TabIndex = 20;
            this.btnApplyFilter.TabStop = false;
            this.btnApplyFilter.Text = "Apply";
            this.btnApplyFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
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
            this.ClientSize = new System.Drawing.Size(514, 200);
            this.Controls.Add(this.btnSortClear);
            this.Controls.Add(this.lblCurrentFilter);
            this.Controls.Add(this.btnSortDesc);
            this.Controls.Add(this.btnSortAsc);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.lblCriteriaB);
            this.Controls.Add(this.lblCriteriaA);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.comFilterType);
            this.Controls.Add(this.btnRemoveFilter);
            this.Controls.Add(this.lblColumnName);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnApplyFilter);
            this.Name = "CesGridViewFilter";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Grid Filter & Sort";
            this.Deactivate += new System.EventHandler(this.CesGridViewFilter_Deactivate);
            this.Load += new System.EventHandler(this.CesGridViewFilter_Load);
            this.Controls.SetChildIndex(this.btnApplyFilter, 0);
            this.Controls.SetChildIndex(this.lblFilter, 0);
            this.Controls.SetChildIndex(this.lblColumnName, 0);
            this.Controls.SetChildIndex(this.btnRemoveFilter, 0);
            this.Controls.SetChildIndex(this.comFilterType, 0);
            this.Controls.SetChildIndex(this.btnClearFilter, 0);
            this.Controls.SetChildIndex(this.lblCriteriaA, 0);
            this.Controls.SetChildIndex(this.lblCriteriaB, 0);
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.Controls.SetChildIndex(this.btnSortAsc, 0);
            this.Controls.SetChildIndex(this.btnSortDesc, 0);
            this.Controls.SetChildIndex(this.lblCurrentFilter, 0);
            this.Controls.SetChildIndex(this.btnSortClear, 0);
            this.pnlTextBox.ResumeLayout(false);
            this.pnlTextBox.PerformLayout();
            this.pnlDatePicker.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlRadioButton.ResumeLayout(false);
            this.pnlRadioButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblCurrentFilter;
        private Panel pnlTextBox;
        private TextBox txtCriteriaA;
        private TextBox txtCriteriaB;
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
        private ComboBox comFilterType;
        private Button btnRemoveFilter;
        private Label lblColumnName;
        private Label lblFilter;
        private Button btnApplyFilter;
    }
}