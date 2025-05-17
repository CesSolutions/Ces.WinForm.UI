namespace Ces.WinForm.UI.CesGridView
{
    partial class CeeHeaderRow
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
            pnlSpacer = new Panel();
            SpacerSplitter = new Splitter();
            pnlColumnHeaderContainer = new Panel();
            SuspendLayout();
            // 
            // pnlSpacer
            // 
            pnlSpacer.BackColor = Color.Cornsilk;
            pnlSpacer.Dock = DockStyle.Left;
            pnlSpacer.Location = new Point(0, 0);
            pnlSpacer.Name = "pnlSpacer";
            pnlSpacer.Size = new Size(0, 69);
            pnlSpacer.TabIndex = 0;
            // 
            // SpacerSplitter
            // 
            SpacerSplitter.Location = new Point(0, 0);
            SpacerSplitter.Name = "SpacerSplitter";
            SpacerSplitter.Size = new Size(1, 69);
            SpacerSplitter.TabIndex = 1;
            SpacerSplitter.TabStop = false;
            // 
            // pnlColumnHeaderContainer
            // 
            pnlColumnHeaderContainer.Dock = DockStyle.Fill;
            pnlColumnHeaderContainer.Location = new Point(1, 0);
            pnlColumnHeaderContainer.Name = "pnlColumnHeaderContainer";
            pnlColumnHeaderContainer.Size = new Size(946, 69);
            pnlColumnHeaderContainer.TabIndex = 2;
            // 
            // CeeHeaderRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlColumnHeaderContainer);
            Controls.Add(SpacerSplitter);
            Controls.Add(pnlSpacer);
            Name = "CeeHeaderRow";
            Size = new Size(947, 69);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSpacer;
        private Splitter SpacerSplitter;
        private Panel pnlColumnHeaderContainer;
    }
}
