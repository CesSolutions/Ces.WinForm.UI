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
            this.pnlSort = new System.Windows.Forms.Panel();
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
            this.pnlSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentFilter
            // 
            this.lblCurrentFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCurrentFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentFilter.ForeColor = System.Drawing.Color.White;
            this.lblCurrentFilter.Location = new System.Drawing.Point(0, 23);
            this.lblCurrentFilter.Name = "lblCurrentFilter";
            this.lblCurrentFilter.Size = new System.Drawing.Size(800, 23);
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
            this.pnlTextBox.Size = new System.Drawing.Size(234, 67);
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
            this.pnlDatePicker.Size = new System.Drawing.Size(234, 67);
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
            this.pnlContainer.Location = new System.Drawing.Point(198, 228);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(234, 67);
            this.pnlContainer.TabIndex = 29;
            // 
            // pnlRadioButton
            // 
            this.pnlRadioButton.Controls.Add(this.rbTrue);
            this.pnlRadioButton.Controls.Add(this.rbFalse);
            this.pnlRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRadioButton.Location = new System.Drawing.Point(0, 0);
            this.pnlRadioButton.Name = "pnlRadioButton";
            this.pnlRadioButton.Size = new System.Drawing.Size(234, 67);
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
            this.lblCriteriaB.Location = new System.Drawing.Point(138, 260);
            this.lblCriteriaB.Name = "lblCriteriaB";
            this.lblCriteriaB.Size = new System.Drawing.Size(54, 15);
            this.lblCriteriaB.TabIndex = 28;
            this.lblCriteriaB.Text = "Criteria 2";
            // 
            // lblCriteriaA
            // 
            this.lblCriteriaA.AutoSize = true;
            this.lblCriteriaA.Location = new System.Drawing.Point(138, 231);
            this.lblCriteriaA.Name = "lblCriteriaA";
            this.lblCriteriaA.Size = new System.Drawing.Size(54, 15);
            this.lblCriteriaA.TabIndex = 27;
            this.lblCriteriaA.Text = "Criteria 1";
            // 
            // btnSortClear
            // 
            this.btnSortClear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSortClear.Location = new System.Drawing.Point(0, 60);
            this.btnSortClear.Name = "btnSortClear";
            this.btnSortClear.Size = new System.Drawing.Size(45, 30);
            this.btnSortClear.TabIndex = 4;
            this.btnSortClear.TabStop = false;
            this.btnSortClear.Text = "Clear";
            this.btnSortClear.UseVisualStyleBackColor = true;
            this.btnSortClear.Click += new System.EventHandler(this.btnSortClear_Click);
            // 
            // pnlSort
            // 
            this.pnlSort.Controls.Add(this.btnSortClear);
            this.pnlSort.Controls.Add(this.btnSortDesc);
            this.pnlSort.Controls.Add(this.btnSortAsc);
            this.pnlSort.Location = new System.Drawing.Point(12, 224);
            this.pnlSort.Name = "pnlSort";
            this.pnlSort.Size = new System.Drawing.Size(45, 168);
            this.pnlSort.TabIndex = 25;
            // 
            // btnSortDesc
            // 
            this.btnSortDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSortDesc.Location = new System.Drawing.Point(0, 30);
            this.btnSortDesc.Name = "btnSortDesc";
            this.btnSortDesc.Size = new System.Drawing.Size(45, 30);
            this.btnSortDesc.TabIndex = 3;
            this.btnSortDesc.TabStop = false;
            this.btnSortDesc.Text = "Desc";
            this.btnSortDesc.UseVisualStyleBackColor = true;
            this.btnSortDesc.Click += new System.EventHandler(this.btnSortDesc_Click);
            // 
            // btnSortAsc
            // 
            this.btnSortAsc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSortAsc.Location = new System.Drawing.Point(0, 0);
            this.btnSortAsc.Name = "btnSortAsc";
            this.btnSortAsc.Size = new System.Drawing.Size(45, 30);
            this.btnSortAsc.TabIndex = 2;
            this.btnSortAsc.TabStop = false;
            this.btnSortAsc.Text = "ASC";
            this.btnSortAsc.UseVisualStyleBackColor = true;
            this.btnSortAsc.Click += new System.EventHandler(this.btnSortAsc_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(642, 199);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(75, 23);
            this.btnClearFilter.TabIndex = 24;
            this.btnClearFilter.TabStop = false;
            this.btnClearFilter.Text = "Clear";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // comFilterType
            // 
            this.comFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comFilterType.FormattingEnabled = true;
            this.comFilterType.Location = new System.Drawing.Point(201, 199);
            this.comFilterType.Name = "comFilterType";
            this.comFilterType.Size = new System.Drawing.Size(221, 23);
            this.comFilterType.TabIndex = 23;
            this.comFilterType.TabStop = false;
            this.comFilterType.SelectedIndexChanged += new System.EventHandler(this.comFilterType_SelectedIndexChanged);
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.Location = new System.Drawing.Point(642, 228);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFilter.TabIndex = 22;
            this.btnRemoveFilter.TabStop = false;
            this.btnRemoveFilter.Text = "Remove";
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // lblColumnName
            // 
            this.lblColumnName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblColumnName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblColumnName.ForeColor = System.Drawing.Color.White;
            this.lblColumnName.Location = new System.Drawing.Point(0, 0);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(800, 23);
            this.lblColumnName.TabIndex = 21;
            this.lblColumnName.Text = "Column :";
            this.lblColumnName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(159, 202);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(33, 15);
            this.lblFilter.TabIndex = 26;
            this.lblFilter.Text = "Filter";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(642, 257);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(75, 23);
            this.btnApplyFilter.TabIndex = 20;
            this.btnApplyFilter.TabStop = false;
            this.btnApplyFilter.Text = "Apply";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // CesGridViewFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCurrentFilter);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.lblCriteriaB);
            this.Controls.Add(this.lblCriteriaA);
            this.Controls.Add(this.pnlSort);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.comFilterType);
            this.Controls.Add(this.btnRemoveFilter);
            this.Controls.Add(this.lblColumnName);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnApplyFilter);
            this.Name = "CesGridViewFilter";
            this.Text = "CesGridViewFilter";
            this.Deactivate += new System.EventHandler(this.CesGridViewFilter_Deactivate);
            this.Load += new System.EventHandler(this.CesGridViewFilter_Load);
            this.pnlTextBox.ResumeLayout(false);
            this.pnlTextBox.PerformLayout();
            this.pnlDatePicker.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlRadioButton.ResumeLayout(false);
            this.pnlRadioButton.PerformLayout();
            this.pnlSort.ResumeLayout(false);
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
        private Panel pnlSort;
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