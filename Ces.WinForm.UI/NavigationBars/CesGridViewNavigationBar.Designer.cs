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
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.tssHelpSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.txtCurrentRow = new System.Windows.Forms.ToolStripTextBox();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.tssNavigationSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.btnClearSelection = new System.Windows.Forms.ToolStripButton();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.btnSort = new System.Windows.Forms.ToolStripButton();
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
            this.btnHelp,
            this.tssHelpSeparator,
            this.btnFirst,
            this.btnPrevious,
            this.txtCurrentRow,
            this.btnNext,
            this.btnLast,
            this.tssNavigationSeparator,
            this.btnSelectAll,
            this.btnClearSelection,
            this.btnFilter,
            this.btnSort,
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
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarHelp;
            this.btnHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(28, 31);
            this.btnHelp.Text = "Help";
            this.btnHelp.Visible = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tssHelpSeparator
            // 
            this.tssHelpSeparator.Name = "tssHelpSeparator";
            this.tssHelpSeparator.Size = new System.Drawing.Size(6, 35);
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarFirst;
            this.btnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(23, 31);
            this.btnFirst.Text = "First";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarPrevious;
            this.btnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(23, 31);
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // txtCurrentRow
            // 
            this.txtCurrentRow.Name = "txtCurrentRow";
            this.txtCurrentRow.Size = new System.Drawing.Size(100, 35);
            this.txtCurrentRow.Text = "0 of 0";
            this.txtCurrentRow.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentRow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCurrentRow_KeyUp);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarNext;
            this.btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 31);
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarLast;
            this.btnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Margin = new System.Windows.Forms.Padding(2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(23, 31);
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
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(28, 31);
            this.btnSelectAll.Text = "SelectAll";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearSelection.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarClearSelection;
            this.btnClearSelection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearSelection.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(28, 31);
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFilter.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarFilter;
            this.btnFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(28, 31);
            this.btnFilter.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnSort
            // 
            this.btnSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSort.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarSort;
            this.btnSort.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(28, 31);
            this.btnSort.Text = "Sort";
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
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
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(28, 31);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarDelete;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 31);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoad.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarLoad;
            this.btnLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(28, 31);
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
            this.btnFullScreen.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarFullScreen;
            this.btnFullScreen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullScreen.Margin = new System.Windows.Forms.Padding(2);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(28, 31);
            this.btnFullScreen.Text = "Full Screen";
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = global::Ces.WinForm.UI.Properties.Resources.NavigationBarExport;
            this.btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(28, 31);
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
        private ToolStripButton btnHelp;
        private ToolStripSeparator tssHelpSeparator;
        private ToolStripButton btnFilter;
        private ToolStripButton btnSort;
    }
}
