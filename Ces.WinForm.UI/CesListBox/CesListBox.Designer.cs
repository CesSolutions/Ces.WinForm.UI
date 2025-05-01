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
            vs = new CesScrollBar.CesVerticalScrollBar();
            pnlSeachBox = new Panel();
            pbSearch = new PictureBox();
            txtSearchBox = new TextBox();
            cesLine1 = new CesLine();
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
            flp.Size = new Size(253, 232);
            flp.TabIndex = 0;
            flp.WrapContents = false;
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
            vs.Location = new Point(253, 0);
            vs.Margin = new Padding(0);
            vs.Name = "vs";
            vs.Size = new Size(20, 232);
            vs.TabIndex = 1;
            vs.Visible = false;
            vs.CesScrollValueChanged += vs_CesScrollValueChanged;
            // 
            // pnlSeachBox
            // 
            pnlSeachBox.BackColor = Color.White;
            pnlSeachBox.Controls.Add(pbSearch);
            pnlSeachBox.Controls.Add(txtSearchBox);
            pnlSeachBox.Controls.Add(cesLine1);
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
            // cesLine1
            // 
            cesLine1.CesAutoStick = false;
            cesLine1.CesAutoStickOffset = 3;
            cesLine1.CesBackColor = Color.Empty;
            cesLine1.CesLineColor = Color.LightGray;
            cesLine1.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            cesLine1.CesLineWidth = 1F;
            cesLine1.CesRoundedTip = true;
            cesLine1.CesVertical = false;
            cesLine1.Dock = DockStyle.Bottom;
            cesLine1.Location = new Point(0, 29);
            cesLine1.Margin = new Padding(0);
            cesLine1.Name = "cesLine1";
            cesLine1.Size = new Size(273, 1);
            cesLine1.TabIndex = 3;
            // 
            // lblStatusBar
            // 
            lblStatusBar.Dock = DockStyle.Bottom;
            lblStatusBar.Location = new Point(0, 262);
            lblStatusBar.Name = "lblStatusBar";
            lblStatusBar.Size = new Size(273, 20);
            lblStatusBar.TabIndex = 3;
            lblStatusBar.Text = "Selected Item(s) : 0";
            lblStatusBar.TextAlign = ContentAlignment.MiddleLeft;
            lblStatusBar.Visible = false;
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(flp);
            pnlContainer.Controls.Add(vs);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 30);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(273, 232);
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
            Size = new Size(273, 282);
            Load += CesListBox_Load;
            Resize += CesListBox_Resize;
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
        private CesLine cesLine1;
        private Panel pnlContainer;
    }
}
