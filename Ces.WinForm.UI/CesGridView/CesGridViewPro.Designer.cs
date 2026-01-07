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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            dgv = new CesGridView();
            pnlHeaderRow = new Panel();
            pnlSpacer = new Panel();
            btnOptions = new Ces.WinForm.UI.CesButton.CesButton();
            flpHeader = new FlowLayoutPanel();
            lblTitle = new CesLabel();
            lineRowHeaderTop = new CesLine();
            lineRowHeaderBottom = new CesLine();
            lineRowFooterTop = new CesLine();
            RowHeaderSeparator = new CesLine();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            pnlHeaderRow.SuspendLayout();
            pnlSpacer.SuspendLayout();
            SuspendLayout();
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
            dgv.CesEnableFiltering = CesGridFilterActionModeEnum.LeftClick;
            dgv.CesRowSizeMode = CesGridViewRowSizeModeEnum.Normal;
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
            dgv.ColumnHeadersVisible = false;
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
            dgv.Location = new Point(0, 87);
            dgv.Margin = new Padding(0);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
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
            dgv.Resize += dgv_Resize;
            dgv.Validating += dgv_Validating;
            dgv.Validated += dgv_Validated;
            // 
            // pnlHeaderRow
            // 
            pnlHeaderRow.BackColor = Color.White;
            pnlHeaderRow.Controls.Add(pnlSpacer);
            pnlHeaderRow.Controls.Add(flpHeader);
            pnlHeaderRow.Dock = DockStyle.Top;
            pnlHeaderRow.Location = new Point(0, 29);
            pnlHeaderRow.Margin = new Padding(0);
            pnlHeaderRow.Name = "pnlHeaderRow";
            pnlHeaderRow.Size = new Size(409, 55);
            pnlHeaderRow.TabIndex = 7;
            // 
            // pnlSpacer
            // 
            pnlSpacer.BackColor = Color.White;
            pnlSpacer.Controls.Add(btnOptions);
            pnlSpacer.Controls.Add(RowHeaderSeparator);
            pnlSpacer.Dock = DockStyle.Left;
            pnlSpacer.Location = new Point(0, 0);
            pnlSpacer.Margin = new Padding(0);
            pnlSpacer.Name = "pnlSpacer";
            pnlSpacer.Size = new Size(29, 55);
            pnlSpacer.TabIndex = 5;
            pnlSpacer.SizeChanged += pnlSpacer_SizeChanged;
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
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            pnlHeaderRow.ResumeLayout(false);
            pnlHeaderRow.PerformLayout();
            pnlSpacer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public CesGridView dgv;
        private Panel pnlHeaderRow;
        private Panel pnlSpacer;
        private FlowLayoutPanel flpHeader;
        private CesLabel lblTitle;
        private CesLine lineRowHeaderTop;
        private CesLine lineRowHeaderBottom;
        private CesButton.CesButton btnOptions;
        private CesLine lineRowFooterTop;
        private CesLine RowHeaderSeparator;
    }
}
