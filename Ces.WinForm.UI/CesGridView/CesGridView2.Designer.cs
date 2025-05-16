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
            cesGridView1 = new CesGridView();
            pnlHeader = new Panel();
            pnlFilter = new Panel();
            ((System.ComponentModel.ISupportInitialize)cesGridView1).BeginInit();
            SuspendLayout();
            // 
            // cesGridView1
            // 
            cesGridView1.CesDarkMode = true;
            cesGridView1.CesDataSource = null;
            cesGridView1.CesEnableFiltering = CesGridFilterActionModeEnum.LeftClick;
            cesGridView1.CesRowSizeMode = CesGridViewRowSizeModeEnum.Normal;
            cesGridView1.CesSetAppearance = false;
            cesGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cesGridView1.Dock = DockStyle.Fill;
            cesGridView1.Location = new Point(0, 117);
            cesGridView1.Name = "cesGridView1";
            cesGridView1.RowTemplate.Height = 25;
            cesGridView1.Size = new Size(831, 272);
            cesGridView1.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Coral;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(831, 54);
            pnlHeader.TabIndex = 1;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.Cornsilk;
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 54);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(831, 63);
            pnlFilter.TabIndex = 2;
            // 
            // CesGridView2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cesGridView1);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Name = "CesGridView2";
            Size = new Size(831, 389);
            ((System.ComponentModel.ISupportInitialize)cesGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlHeader;
        private Panel pnlFilter;
        public CesGridView cesGridView1;
    }
}
