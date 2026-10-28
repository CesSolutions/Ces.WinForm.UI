namespace Ces.WinForm.UI.CesComboBox
{
    partial class CesComboBoxMultiColumnPopup
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            dgv = new Ces.WinForm.UI.CesGridView.CesGridView();
            pnlSeachBox = new Panel();
            txtSearchBox = new TextBox();
            pbSearch = new PictureBox();
            topLine = new CesLine();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            pnlSeachBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            SuspendLayout();
            // 
            // btnOptions
            // 
            btnOptions.FlatAppearance.BorderColor = Color.DarkGreen;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.MediumSeaGreen;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dgv.CesDataSource = null;
            dgv.CesEnableFiltering = CesGridView.CesGridFilterActionModeEnum.LeftClick;
            dgv.CesRowSizeMode = CesGridView.CesGridViewRowSizeModeEnum.Normal;
            dgv.CesStopCerrentCellChangedEventInCurrentRow = false;
            dgv.CesTheme = Infrastructure.ThemeEnum.White;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.Khaki;
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle7;
            dgv.Dock = DockStyle.Fill;
            dgv.GridColor = Color.FromArgb(224, 224, 224);
            dgv.Location = new Point(2, 32);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgv.RowHeadersWidth = 30;
            dgv.RowTemplate.Height = 30;
            dgv.Size = new Size(315, 280);
            dgv.TabIndex = 1;
            dgv.CellClick += dgv_CellClick;
            // 
            // pnlSeachBox
            // 
            pnlSeachBox.BackColor = Color.White;
            pnlSeachBox.Controls.Add(txtSearchBox);
            pnlSeachBox.Controls.Add(pbSearch);
            pnlSeachBox.Controls.Add(topLine);
            pnlSeachBox.Dock = DockStyle.Top;
            pnlSeachBox.Location = new Point(2, 2);
            pnlSeachBox.Name = "pnlSeachBox";
            pnlSeachBox.Size = new Size(315, 30);
            pnlSeachBox.TabIndex = 0;
            pnlSeachBox.Visible = false;
            // 
            // txtSearchBox
            // 
            txtSearchBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchBox.BackColor = Color.White;
            txtSearchBox.BorderStyle = BorderStyle.None;
            txtSearchBox.Location = new Point(31, 7);
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.Size = new Size(274, 16);
            txtSearchBox.TabIndex = 0;
            txtSearchBox.TextChanged += txtSearchBox_TextChanged;
            // 
            // pbSearch
            // 
            pbSearch.Cursor = Cursors.Hand;
            pbSearch.Dock = DockStyle.Left;
            pbSearch.Image = Properties.Resources.CesListBoxSearch;
            pbSearch.Location = new Point(0, 0);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(25, 29);
            pbSearch.SizeMode = PictureBoxSizeMode.CenterImage;
            pbSearch.TabIndex = 2;
            pbSearch.TabStop = false;
            // 
            // topLine
            // 
            topLine.CesAutoStick = false;
            topLine.CesAutoStickOffset = 3;
            topLine.CesBackColor = Color.Empty;
            topLine.CesLineColor = Color.LightGray;
            topLine.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            topLine.CesLineWidth = 1F;
            topLine.CesRoundedTip = true;
            topLine.CesVertical = false;
            topLine.Dock = DockStyle.Bottom;
            topLine.Location = new Point(0, 29);
            topLine.Margin = new Padding(0);
            topLine.Name = "topLine";
            topLine.Size = new Size(315, 1);
            topLine.TabIndex = 3;
            // 
            // CesComboBoxMultiColumnPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CesFormType = CesForm.CesFormTypeEnum.None;
            ClientSize = new Size(319, 314);
            Controls.Add(dgv);
            Controls.Add(pnlSeachBox);
            KeyPreview = true;
            Name = "CesComboBoxMultiColumnPopup";
            StartPosition = FormStartPosition.Manual;
            Text = "CesComboBoxMultiColumnPopup";
            Deactivate += CesComboBoxMultiColumnPopup_Deactivate;
            KeyDown += CesComboBoxMultiColumnPopup_KeyDown;
            Controls.SetChildIndex(pnlSeachBox, 0);
            Controls.SetChildIndex(dgv, 0);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            pnlSeachBox.ResumeLayout(false);
            pnlSeachBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ResumeLayout(false);
        }

        #endregion

        protected internal CesGridView.CesGridView dgv;
        private PictureBox pbSearch;
        private TextBox txtSearchBox;
        private CesLine topLine;
        internal Panel pnlSeachBox;
    }
}