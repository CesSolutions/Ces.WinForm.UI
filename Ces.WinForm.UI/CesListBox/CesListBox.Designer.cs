namespace Ces.WinForm.UI.CesListBox
{
    partial class CesListBox
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
            flp = new FlowLayoutPanel();
            vs = new Ces.WinForm.UI.CesScrollBar.CesVerticalScrollBar();
            pnlSeachBox = new Panel();
            pbSearch = new PictureBox();
            txtSearchBox = new TextBox();
            topLine = new CesLine();
            lblStatusBar = new Label();
            pnlContainer = new Panel();
            pnlSeachBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // flp
            // 
            flp.BackColor = Color.White;
            flp.Dock = DockStyle.Fill;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.Location = new Point(0, 0);
            flp.Name = "flp";
            flp.Size = new Size(255, 185);
            flp.TabIndex = 0;
            flp.WrapContents = false;
            flp.SizeChanged += flp_SizeChanged;
            flp.MouseClick += flp_MouseClick;
            // 
            // vs
            // 
            vs.BackColor = SystemColors.ButtonHighlight;
            vs.CesBorderColor = Color.Silver;
            vs.CesMaxValue = 100;
            vs.CesMovingStep = 1;
            vs.CesScrollButton = Color.Gainsboro;
            vs.CesScrollButtonMouseClick = Color.Gainsboro;
            vs.CesScrollButtonMouseOver = Color.DarkGray;
            vs.CesShowBorder = true;
            vs.CesSliderColor = Color.Gray;
            vs.CesUseScrollValue = false;
            vs.CesValue = 0;
            vs.Dock = DockStyle.Right;
            vs.Location = new Point(255, 0);
            vs.Margin = new Padding(0);
            vs.Name = "vs";
            vs.Size = new Size(18, 185);
            vs.TabIndex = 1;
            vs.Visible = false;
            vs.CesScrollValueChanged += vs_CesScrollValueChanged;
            // 
            // pnlSeachBox
            // 
            pnlSeachBox.BackColor = Color.White;
            pnlSeachBox.Controls.Add(pbSearch);
            pnlSeachBox.Controls.Add(txtSearchBox);
            pnlSeachBox.Controls.Add(topLine);
            pnlSeachBox.Dock = DockStyle.Top;
            pnlSeachBox.Location = new Point(0, 0);
            pnlSeachBox.Name = "pnlSeachBox";
            pnlSeachBox.Size = new Size(273, 30);
            pnlSeachBox.TabIndex = 2;
            pnlSeachBox.Visible = false;
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
            pbSearch.Click += pbSearch_Click;
            // 
            // txtSearchBox
            // 
            txtSearchBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearchBox.BackColor = Color.White;
            txtSearchBox.BorderStyle = BorderStyle.None;
            txtSearchBox.Location = new Point(31, 7);
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.Size = new Size(239, 16);
            txtSearchBox.TabIndex = 1;
            txtSearchBox.TextChanged += txtSearchBox_TextChanged;
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
            topLine.Size = new Size(273, 1);
            topLine.TabIndex = 3;
            // 
            // lblStatusBar
            // 
            lblStatusBar.BackColor = Color.WhiteSmoke;
            lblStatusBar.Dock = DockStyle.Bottom;
            lblStatusBar.ForeColor = Color.DimGray;
            lblStatusBar.Location = new Point(0, 215);
            lblStatusBar.Name = "lblStatusBar";
            lblStatusBar.Size = new Size(273, 18);
            lblStatusBar.TabIndex = 3;
            lblStatusBar.Text = "Selected Item(s) : 0";
            lblStatusBar.TextAlign = ContentAlignment.MiddleLeft;
            lblStatusBar.Visible = false;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(flp);
            pnlContainer.Controls.Add(vs);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 30);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(273, 185);
            pnlContainer.TabIndex = 4;
            // 
            // CesListBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Controls.Add(pnlSeachBox);
            Controls.Add(lblStatusBar);
            Name = "CesListBox";
            Size = new Size(273, 233);
            Load += CesListBox_Load;
            SizeChanged += CesListBox_SizeChanged;
            pnlSeachBox.ResumeLayout(false);
            pnlSeachBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            pnlContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flp;
        private CesScrollBar.CesVerticalScrollBar vs;
        private Panel pnlSeachBox;
        private Label lblStatusBar;
        private TextBox txtSearchBox;
        private PictureBox pbSearch;
        private CesLine topLine;
        private Panel pnlContainer;
    }
}
