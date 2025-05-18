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
            cesGridView1.Location = new Point(14, 163);
            cesGridView1.Name = "cesGridView1";
            cesGridView1.RowTemplate.Height = 25;
            cesGridView1.Size = new Size(831, 272);
            cesGridView1.TabIndex = 0;
            // 
            // CesGridView2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cesGridView1);
            Name = "CesGridView2";
            Size = new Size(875, 516);
            ((System.ComponentModel.ISupportInitialize)cesGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public CesGridView cesGridView1;
    }
}
