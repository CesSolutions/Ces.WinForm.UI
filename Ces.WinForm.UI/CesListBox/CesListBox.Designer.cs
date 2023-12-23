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
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.vs = new Ces.WinForm.UI.CesScrollBar.CesVerticalScrollBar();
            this.pnlSeachBox = new System.Windows.Forms.Panel();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.cesLine1 = new Ces.WinForm.UI.CesLine();
            this.lblStatusBar = new System.Windows.Forms.Label();
            this.pnlSeachBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // flp
            // 
            this.flp.BackColor = System.Drawing.Color.White;
            this.flp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp.Location = new System.Drawing.Point(0, 30);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(249, 232);
            this.flp.TabIndex = 0;
            this.flp.WrapContents = false;
            // 
            // vs
            // 
            this.vs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.vs.CesBorderColor = System.Drawing.Color.Silver;
            this.vs.CesMaxValue = 100;
            this.vs.CesMovingStep = 1;
            this.vs.CesScrollButton = System.Drawing.Color.Gray;
            this.vs.CesScrollButtonMouseClick = System.Drawing.Color.Gray;
            this.vs.CesScrollButtonMouseOver = System.Drawing.Color.DarkGray;
            this.vs.CesShowBorder = true;
            this.vs.CesSliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.vs.CesUseScrollValue = false;
            this.vs.CesValue = 0;
            this.vs.Dock = System.Windows.Forms.DockStyle.Right;
            this.vs.Location = new System.Drawing.Point(249, 0);
            this.vs.Margin = new System.Windows.Forms.Padding(0);
            this.vs.Name = "vs";
            this.vs.Size = new System.Drawing.Size(24, 282);
            this.vs.TabIndex = 1;
            this.vs.Visible = false;
            this.vs.CesScrollValueChanged += new Ces.WinForm.UI.CesScrollBar.CesVerticalScrollBar.CesScrollValueChangedEventHandler(this.vs_CesScrollValueChanged);
            // 
            // pnlSeachBox
            // 
            this.pnlSeachBox.BackColor = System.Drawing.Color.White;
            this.pnlSeachBox.Controls.Add(this.pbSearch);
            this.pnlSeachBox.Controls.Add(this.txtSearchBox);
            this.pnlSeachBox.Controls.Add(this.cesLine1);
            this.pnlSeachBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeachBox.Location = new System.Drawing.Point(0, 0);
            this.pnlSeachBox.Name = "pnlSeachBox";
            this.pnlSeachBox.Size = new System.Drawing.Size(249, 30);
            this.pnlSeachBox.TabIndex = 2;
            this.pnlSeachBox.Visible = false;
            // 
            // pbSearch
            // 
            this.pbSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbSearch.Image = global::Ces.WinForm.UI.Properties.Resources.CesListBoxSearch;
            this.pbSearch.Location = new System.Drawing.Point(0, 0);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(25, 29);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSearch.TabIndex = 2;
            this.pbSearch.TabStop = false;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBox.BackColor = System.Drawing.Color.White;
            this.txtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchBox.Location = new System.Drawing.Point(31, 7);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(215, 16);
            this.txtSearchBox.TabIndex = 1;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // cesLine1
            // 
            this.cesLine1.CesAutoStick = false;
            this.cesLine1.CesAutoStickOffset = 3;
            this.cesLine1.CesBackColor = System.Drawing.Color.Empty;
            this.cesLine1.CesLineColor = System.Drawing.Color.LightGray;
            this.cesLine1.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.cesLine1.CesLineWidth = 1F;
            this.cesLine1.CesRoundedTip = true;
            this.cesLine1.CesVertical = false;
            this.cesLine1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cesLine1.Location = new System.Drawing.Point(0, 29);
            this.cesLine1.Name = "cesLine1";
            this.cesLine1.Size = new System.Drawing.Size(249, 1);
            this.cesLine1.TabIndex = 3;
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatusBar.Location = new System.Drawing.Point(0, 262);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(249, 20);
            this.lblStatusBar.TabIndex = 3;
            this.lblStatusBar.Text = "Selected Item(s) : 0";
            this.lblStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusBar.Visible = false;
            // 
            // CesListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flp);
            this.Controls.Add(this.lblStatusBar);
            this.Controls.Add(this.pnlSeachBox);
            this.Controls.Add(this.vs);
            this.Name = "CesListBox";
            this.Size = new System.Drawing.Size(273, 282);
            this.Load += new System.EventHandler(this.CesListBox_Load);
            this.Resize += new System.EventHandler(this.CesListBox_Resize);
            this.pnlSeachBox.ResumeLayout(false);
            this.pnlSeachBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp;
        private CesScrollBar.CesVerticalScrollBar vs;
        private Panel pnlSeachBox;
        private Label lblStatusBar;
        private TextBox txtSearchBox;
        private PictureBox pbSearch;
        private CesLine cesLine1;
    }
}
