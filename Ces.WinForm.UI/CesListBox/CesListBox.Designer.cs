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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new Ces.WinForm.UI.CesButton.CesButton();
            this.lblStatusBar = new System.Windows.Forms.Label();
            this.pnlSeachBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp
            // 
            this.flp.BackColor = System.Drawing.Color.White;
            this.flp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp.Location = new System.Drawing.Point(0, 30);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(307, 232);
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
            this.vs.Location = new System.Drawing.Point(307, 0);
            this.vs.Margin = new System.Windows.Forms.Padding(0);
            this.vs.Name = "vs";
            this.vs.Size = new System.Drawing.Size(24, 282);
            this.vs.TabIndex = 1;
            this.vs.Visible = false;
            this.vs.CesScrollValueChanged += new Ces.WinForm.UI.CesScrollBar.CesVerticalScrollBar.CesScrollValueChangedEventHandler(this.vs_CesScrollValueChanged);
            // 
            // pnlSeachBox
            // 
            this.pnlSeachBox.Controls.Add(this.textBox1);
            this.pnlSeachBox.Controls.Add(this.btnSearch);
            this.pnlSeachBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeachBox.Location = new System.Drawing.Point(0, 0);
            this.pnlSeachBox.Name = "pnlSeachBox";
            this.pnlSeachBox.Size = new System.Drawing.Size(307, 30);
            this.pnlSeachBox.TabIndex = 2;
            this.pnlSeachBox.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(40, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 16);
            this.textBox1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Gray;
            this.btnSearch.CesBorderThickness = 1;
            this.btnSearch.CesBorderVisible = false;
            this.btnSearch.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            this.btnSearch.CesEnableToolTip = false;
            this.btnSearch.CesToolTipText = null;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 30);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatusBar.Location = new System.Drawing.Point(0, 262);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(307, 20);
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
            this.Size = new System.Drawing.Size(331, 282);
            this.Load += new System.EventHandler(this.CesListBox_Load);
            this.Resize += new System.EventHandler(this.CesListBox_Resize);
            this.pnlSeachBox.ResumeLayout(false);
            this.pnlSeachBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp;
        private CesScrollBar.CesVerticalScrollBar vs;
        private Panel pnlSeachBox;
        private Label lblStatusBar;
        private CesButton.CesButton btnSearch;
        private TextBox textBox1;
    }
}
