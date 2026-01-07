namespace Ces.WinForm.UI.CesGridView
{
    partial class CesGridViewPro
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgv = new CesGridView();
            pnlHeaderRow = new Panel();
            pnlOption = new Panel();
            btnOptions = new Ces.WinForm.UI.CesButton.CesButton();
            RowHeaderSeparator = new CesLine();
            flpHeader = new FlowLayoutPanel();
            lblTitle = new CesLabel();
            lineRowHeaderTop = new CesLine();
            lineRowHeaderBottom = new CesLine();
            lineRowFooterTop = new CesLine();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            pnlHeaderRow.SuspendLayout();
            pnlOption.SuspendLayout();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dgv.CesDataSource = null;
            dgv.CesEnableFiltering = CesGridFilterActionModeEnum.LeftClick;
            dgv.CesRowSizeMode = CesGridViewRowSizeModeEnum.Normal;
            dgv.CesStopCerrentCellChangedEventInCurrentRow = false;
            dgv.CesTheme = Infrastructure.ThemeEnum.White;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.Khaki;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle3;
            dgv.Dock = DockStyle.Fill;
            dgv.GridColor = Color.FromArgb(224, 224, 224);
            dgv.Location = new Point(0, 87);
            dgv.Margin = new Padding(0);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv.RowHeadersWidth = 30;
            dgv.RowTemplate.Height = 25;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(409, 161);
            dgv.TabIndex = 0;
            dgv.FilterAndSortCompleted += dgv_FilterAndSortCompleted;
            dgv.RowHeadersWidthChanged += dgv_RowHeadersWidthChanged;
            dgv.CellClick += dgv_CellClick;
            dgv.CellContentClick += dgv_CellContentClick;
            dgv.CellContentDoubleClick += dgv_CellContentDoubleClick;
            dgv.CellDoubleClick += dgv_CellDoubleClick;
            dgv.CellEnter += dgv_CellEnter;
            dgv.CellLeave += dgv_CellLeave;
            dgv.CellMouseClick += dgv_CellMouseClick;
            dgv.CellMouseDoubleClick += dgv_CellMouseDoubleClick;
            dgv.CellMouseDown += dgv_CellMouseDown;
            dgv.CellMouseEnter += dgv_CellMouseEnter;
            dgv.CellMouseLeave += dgv_CellMouseLeave;
            dgv.CellMouseUp += dgv_CellMouseUp;
            dgv.CellPainting += dgv_CellPainting;
            dgv.CellValidated += dgv_CellValidated;
            dgv.CellValidating += dgv_CellValidating;
            dgv.CellValueChanged += dgv_CellValueChanged;
            dgv.ColumnRemoved += dgv_ColumnRemoved;
            dgv.ColumnStateChanged += dgv_ColumnStateChanged;
            dgv.ColumnWidthChanged += dgv_ColumnWidthChanged;
            dgv.CurrentCellChanged += dgv_CurrentCellChanged;
            dgv.RowEnter += dgv_RowEnter;
            dgv.Scroll += dgv_Scroll;
            dgv.SelectionChanged += dgv_SelectionChanged;
            dgv.UserAddedRow += dgv_UserAddedRow;
            dgv.UserDeletedRow += dgv_UserDeletedRow;
            dgv.UserDeletingRow += dgv_UserDeletingRow;
            dgv.Paint += dgv_Paint;
            dgv.KeyDown += dgv_KeyDown;
            dgv.KeyPress += dgv_KeyPress;
            dgv.KeyUp += dgv_KeyUp;
            dgv.Validating += dgv_Validating;
            dgv.Validated += dgv_Validated;
            // 
            // pnlHeaderRow
            // 
            pnlHeaderRow.BackColor = Color.White;
            pnlHeaderRow.Controls.Add(pnlOption);
            pnlHeaderRow.Controls.Add(flpHeader);
            pnlHeaderRow.Dock = DockStyle.Top;
            pnlHeaderRow.Location = new Point(0, 29);
            pnlHeaderRow.Margin = new Padding(0);
            pnlHeaderRow.Name = "pnlHeaderRow";
            pnlHeaderRow.Size = new Size(409, 55);
            pnlHeaderRow.TabIndex = 7;
            // 
            // pnlOption
            // 
            pnlOption.BackColor = Color.White;
            pnlOption.Controls.Add(btnOptions);
            pnlOption.Controls.Add(RowHeaderSeparator);
            pnlOption.Dock = DockStyle.Left;
            pnlOption.Location = new Point(0, 0);
            pnlOption.Margin = new Padding(0);
            pnlOption.Name = "pnlOption";
            pnlOption.Size = new Size(29, 55);
            pnlOption.TabIndex = 5;
            // 
            // btnOptions
            // 
            btnOptions.BackColor = Color.White;
            btnOptions.CesBorderThickness = 1;
            btnOptions.CesBorderVisible = false;
            btnOptions.CesColorTemplate = CesButton.ColorTemplateEnum.White;
            btnOptions.CesEnableToolTip = false;
            btnOptions.CesToolTipText = null;
            btnOptions.Dock = DockStyle.Fill;
            btnOptions.FlatAppearance.BorderColor = Color.White;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnOptions.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.ForeColor = Color.Black;
            btnOptions.Image = Properties.Resources.CesGridViewOptionsWhite;
            btnOptions.Location = new Point(0, 0);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(28, 55);
            btnOptions.TabIndex = 8;
            btnOptions.UseVisualStyleBackColor = false;
            btnOptions.Visible = false;
            btnOptions.Click += btnOptions_Click;
            // 
            // RowHeaderSeparator
            // 
            RowHeaderSeparator.BackColor = Color.White;
            RowHeaderSeparator.CesAutoStick = false;
            RowHeaderSeparator.CesAutoStickOffset = 0;
            RowHeaderSeparator.CesBackColor = Color.Empty;
            RowHeaderSeparator.CesLineColor = Color.LightGray;
            RowHeaderSeparator.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            RowHeaderSeparator.CesLineWidth = 1F;
            RowHeaderSeparator.CesRoundedTip = false;
            RowHeaderSeparator.CesVertical = true;
            RowHeaderSeparator.Dock = DockStyle.Right;
            RowHeaderSeparator.Location = new Point(28, 0);
            RowHeaderSeparator.Margin = new Padding(3, 0, 0, 0);
            RowHeaderSeparator.Name = "RowHeaderSeparator";
            RowHeaderSeparator.Size = new Size(1, 55);
            RowHeaderSeparator.TabIndex = 9;
            RowHeaderSeparator.TabStop = false;
            // 
            // flpHeader
            // 
            flpHeader.AutoSize = true;
            flpHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpHeader.BackColor = Color.White;
            flpHeader.Location = new Point(65, 0);
            flpHeader.Margin = new Padding(0);
            flpHeader.Name = "flpHeader";
            flpHeader.Size = new Size(0, 0);
            flpHeader.TabIndex = 7;
            flpHeader.WrapContents = false;
            // 
            // lblTitle
            // 
            lblTitle.CesDegree = CesLabelRotationDegreeEnum.Rotate0;
            lblTitle.CesShowUnderLine = false;
            lblTitle.CesUnderlineColor = Color.Black;
            lblTitle.CesUnderlineThickness = 1;
            lblTitle.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(409, 28);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lineRowHeaderTop
            // 
            lineRowHeaderTop.CesAutoStick = false;
            lineRowHeaderTop.CesAutoStickOffset = 0;
            lineRowHeaderTop.CesBackColor = Color.Empty;
            lineRowHeaderTop.CesLineColor = Color.DarkGray;
            lineRowHeaderTop.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lineRowHeaderTop.CesLineWidth = 1F;
            lineRowHeaderTop.CesRoundedTip = false;
            lineRowHeaderTop.CesVertical = false;
            lineRowHeaderTop.Dock = DockStyle.Top;
            lineRowHeaderTop.Location = new Point(0, 28);
            lineRowHeaderTop.Margin = new Padding(0);
            lineRowHeaderTop.Name = "lineRowHeaderTop";
            lineRowHeaderTop.Size = new Size(409, 1);
            lineRowHeaderTop.TabIndex = 9;
            // 
            // lineRowHeaderBottom
            // 
            lineRowHeaderBottom.CesAutoStick = false;
            lineRowHeaderBottom.CesAutoStickOffset = 0;
            lineRowHeaderBottom.CesBackColor = Color.Empty;
            lineRowHeaderBottom.CesLineColor = Color.DarkGray;
            lineRowHeaderBottom.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lineRowHeaderBottom.CesLineWidth = 1F;
            lineRowHeaderBottom.CesRoundedTip = false;
            lineRowHeaderBottom.CesVertical = false;
            lineRowHeaderBottom.Dock = DockStyle.Top;
            lineRowHeaderBottom.Location = new Point(0, 84);
            lineRowHeaderBottom.Margin = new Padding(0);
            lineRowHeaderBottom.Name = "lineRowHeaderBottom";
            lineRowHeaderBottom.Size = new Size(409, 3);
            lineRowHeaderBottom.TabIndex = 10;
            // 
            // lineRowFooterTop
            // 
            lineRowFooterTop.CesAutoStick = false;
            lineRowFooterTop.CesAutoStickOffset = 0;
            lineRowFooterTop.CesBackColor = Color.Empty;
            lineRowFooterTop.CesLineColor = Color.DarkGray;
            lineRowFooterTop.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            lineRowFooterTop.CesLineWidth = 1F;
            lineRowFooterTop.CesRoundedTip = false;
            lineRowFooterTop.CesVertical = false;
            lineRowFooterTop.Dock = DockStyle.Bottom;
            lineRowFooterTop.Location = new Point(0, 248);
            lineRowFooterTop.Margin = new Padding(0);
            lineRowFooterTop.Name = "lineRowFooterTop";
            lineRowFooterTop.Size = new Size(409, 3);
            lineRowFooterTop.TabIndex = 12;
            // 
            // CesGridViewPro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgv);
            Controls.Add(lineRowFooterTop);
            Controls.Add(lineRowHeaderBottom);
            Controls.Add(pnlHeaderRow);
            Controls.Add(lineRowHeaderTop);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            ForeColor = Color.DimGray;
            Name = "CesGridViewPro";
            Size = new Size(409, 251);
            Resize += CesGridViewPro_Resize;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            pnlHeaderRow.ResumeLayout(false);
            pnlHeaderRow.PerformLayout();
            pnlOption.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public CesGridView dgv;
        private Panel pnlHeaderRow;
        private Panel pnlOption;
        private FlowLayoutPanel flpHeader;
        private CesLabel lblTitle;
        private CesLine lineRowHeaderTop;
        private CesLine lineRowHeaderBottom;
        private CesButton.CesButton btnOptions;
        private CesLine lineRowFooterTop;
        private CesLine RowHeaderSeparator;
    }
}
