namespace Ces.WinForm.UI.NavigationBars
{
    partial class CesGridViewNavigationBar
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
            this.CesToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.txtCurrentRow = new System.Windows.Forms.ToolStripTextBox();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.tssNavigationSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.btnClearSelection = new System.Windows.Forms.ToolStripButton();
            this.tssSelectSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.tssOperationSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnFullScreen = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.CesToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CesToolStrip
            // 
            this.CesToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFirst,
            this.btnPrevious,
            this.txtCurrentRow,
            this.btnNext,
            this.btnLast,
            this.tssNavigationSeparator,
            this.btnSelectAll,
            this.btnClearSelection,
            this.tssSelectSeparator,
            this.btnNew,
            this.btnDelete,
            this.btnLoad,
            this.tssOperationSeparator,
            this.btnFullScreen,
            this.btnExport});
            this.CesToolStrip.Location = new System.Drawing.Point(0, 0);
            this.CesToolStrip.Name = "CesToolStrip";
            this.CesToolStrip.Size = new System.Drawing.Size(575, 35);
            this.CesToolStrip.TabIndex = 0;
            this.CesToolStrip.TabStop = true;
            this.CesToolStrip.Text = "CesToolStrip";
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarFirst;
            this.btnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(23, 32);
            this.btnFirst.Text = "First";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarPrevious;
            this.btnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(23, 32);
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // txtCurrentRow
            // 
            this.txtCurrentRow.Name = "txtCurrentRow";
            this.txtCurrentRow.Size = new System.Drawing.Size(100, 35);
            this.txtCurrentRow.Text = "0 of 0";
            this.txtCurrentRow.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentRow.Leave += new System.EventHandler(this.txtCurrentRow_Leave);
            this.txtCurrentRow.Validated += new System.EventHandler(this.txtCurrentRow_Validated);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarNext;
            this.btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 32);
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarLast;
            this.btnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(23, 32);
            this.btnLast.Text = "Last";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // tssNavigationSeparator
            // 
            this.tssNavigationSeparator.Name = "tssNavigationSeparator";
            this.tssNavigationSeparator.Size = new System.Drawing.Size(6, 35);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectAll.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarSelectAll;
            this.btnSelectAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(23, 32);
            this.btnSelectAll.Text = "SelectAll";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearSelection.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarClearSelection;
            this.btnClearSelection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(23, 32);
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // tssSelectSeparator
            // 
            this.tssSelectSeparator.Name = "tssSelectSeparator";
            this.tssSelectSeparator.Size = new System.Drawing.Size(6, 35);
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarNew;
            this.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 32);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarDelete;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 32);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoad.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarLoad;
            this.btnLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(23, 32);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tssOperationSeparator
            // 
            this.tssOperationSeparator.Name = "tssOperationSeparator";
            this.tssOperationSeparator.Size = new System.Drawing.Size(6, 35);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullScreen.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarFullscreen;
            this.btnFullScreen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(23, 32);
            this.btnFullScreen.Text = "Full Screen";
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarExport;
            this.btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 32);
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // CesGridViewNavigationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CesToolStrip);
            this.Name = "CesGridViewNavigationBar";
            this.Size = new System.Drawing.Size(575, 35);
            this.CesToolStrip.ResumeLayout(false);
            this.CesToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip CesToolStrip;
        private ToolStripButton btnFirst;
        private ToolStripButton btnPrevious;
        private ToolStripTextBox txtCurrentRow;
        private ToolStripButton btnNext;
        private ToolStripButton btnLast;
        private ToolStripSeparator tssNavigationSeparator;
        private ToolStripButton btnClearSelection;
        private ToolStripButton btnSelectAll;
        private ToolStripSeparator tssSelectSeparator;
        private ToolStripButton btnNew;
        private ToolStripButton btnDelete;
        private ToolStripButton btnLoad;
        private ToolStripButton btnExport;
        private ToolStripSeparator tssOperationSeparator;
        private ToolStripButton btnFullScreen;
    }
}
