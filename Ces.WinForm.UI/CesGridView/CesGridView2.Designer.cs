namespace Ces.WinForm.UI.CesGridView
{
    partial class CesGridView2
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
            dgv = new CesGridView();
            pnlHeaderRow = new Panel();
            pnlSpacer = new Panel();
            SpacerSplitter = new Splitter();
            flpHeader = new FlowLayoutPanel();
            lblTitle = new CesLabel();
            cesLine1 = new CesLine();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            pnlHeaderRow.SuspendLayout();
            pnlSpacer.SuspendLayout();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CesDataSource = null;
            dgv.CesEnableFiltering = CesGridFilterActionModeEnum.LeftClick;
            dgv.CesRowSizeMode = CesGridViewRowSizeModeEnum.Normal;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.ColumnHeadersVisible = false;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 84);
            dgv.Margin = new Padding(0);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowTemplate.Height = 25;
            dgv.Size = new Size(721, 283);
            dgv.TabIndex = 0;
            dgv.DataSourceChanged += dgv_DataSourceChanged;
            dgv.RowHeadersWidthChanged += dgv_RowHeadersWidthChanged;
            dgv.ColumnWidthChanged += dgv_ColumnWidthChanged;
            dgv.Scroll += dgv_Scroll;
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
            pnlHeaderRow.Size = new Size(721, 55);
            pnlHeaderRow.TabIndex = 7;
            // 
            // pnlSpacer
            // 
            pnlSpacer.BackColor = Color.White;
            pnlSpacer.Controls.Add(SpacerSplitter);
            pnlSpacer.Dock = DockStyle.Left;
            pnlSpacer.Location = new Point(0, 0);
            pnlSpacer.Margin = new Padding(0);
            pnlSpacer.Name = "pnlSpacer";
            pnlSpacer.Size = new Size(35, 55);
            pnlSpacer.TabIndex = 5;
            pnlSpacer.SizeChanged += pnlSpacer_SizeChanged;
            // 
            // SpacerSplitter
            // 
            SpacerSplitter.BackColor = Color.DarkGray;
            SpacerSplitter.Dock = DockStyle.Right;
            SpacerSplitter.Location = new Point(34, 0);
            SpacerSplitter.Margin = new Padding(0);
            SpacerSplitter.Name = "SpacerSplitter";
            SpacerSplitter.Size = new Size(1, 55);
            SpacerSplitter.TabIndex = 7;
            SpacerSplitter.TabStop = false;
            SpacerSplitter.Visible = false;
            SpacerSplitter.MouseDown += SpacerSplitter_MouseDown;
            SpacerSplitter.MouseUp += SpacerSplitter_MouseUp;
            // 
            // flpHeader
            // 
            flpHeader.AutoSize = true;
            flpHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpHeader.BackColor = SystemColors.Control;
            flpHeader.Location = new Point(65, 3);
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
            lblTitle.Size = new Size(721, 28);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cesLine1
            // 
            cesLine1.CesAutoStick = false;
            cesLine1.CesAutoStickOffset = 0;
            cesLine1.CesBackColor = Color.Empty;
            cesLine1.CesLineColor = Color.DarkGray;
            cesLine1.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            cesLine1.CesLineWidth = 1F;
            cesLine1.CesRoundedTip = false;
            cesLine1.CesVertical = false;
            cesLine1.Dock = DockStyle.Top;
            cesLine1.Location = new Point(0, 28);
            cesLine1.Margin = new Padding(0);
            cesLine1.Name = "cesLine1";
            cesLine1.Size = new Size(721, 1);
            cesLine1.TabIndex = 9;
            // 
            // CesGridView2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(dgv);
            Controls.Add(pnlHeaderRow);
            Controls.Add(cesLine1);
            Controls.Add(lblTitle);
            Name = "CesGridView2";
            Size = new Size(721, 367);
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
        private Splitter SpacerSplitter;
        private CesLine cesLine1;
    }
}
