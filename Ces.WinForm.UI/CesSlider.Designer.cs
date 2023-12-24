namespace Ces.WinForm.UI
{
    partial class CesSlider
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
            this.btn = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.line = new Ces.WinForm.UI.CesLine();
            this.pb = new System.Windows.Forms.PictureBox();
            this.lbl = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.SystemColors.Control;
            this.btn.CesBackColor = System.Drawing.Color.Black;
            this.btn.CesBorderColor = System.Drawing.Color.Black;
            this.btn.CesBorderRadius = 15;
            this.btn.CesBorderThickness = 1;
            this.btn.CesBorderVisible = false;
            this.btn.CesCircular = false;
            this.btn.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Black;
            this.btn.CesFont = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn.CesForeColor = System.Drawing.Color.White;
            this.btn.CesIcon = null;
            this.btn.CesIconAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn.CesMouseDownColor = System.Drawing.Color.Black;
            this.btn.CesMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn.CesShowIcon = false;
            this.btn.CesShowText = true;
            this.btn.CesText = "";
            this.btn.CesTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn.Location = new System.Drawing.Point(41, 28);
            this.btn.Margin = new System.Windows.Forms.Padding(10);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(33, 48);
            this.btn.TabIndex = 0;
            // 
            // line
            // 
            this.line.CesAutoStick = true;
            this.line.CesAutoStickOffset = 3;
            this.line.CesBackColor = System.Drawing.Color.Empty;
            this.line.CesLineColor = System.Drawing.Color.Black;
            this.line.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.line.CesLineWidth = 5F;
            this.line.CesRoundedTip = true;
            this.line.CesVertical = false;
            this.line.Location = new System.Drawing.Point(3, 28);
            this.line.Margin = new System.Windows.Forms.Padding(0);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(432, 31);
            this.line.TabIndex = 1;
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(45, 179);
            this.pb.TabIndex = 2;
            this.pb.TabStop = false;
            // 
            // lbl
            // 
            this.lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl.Location = new System.Drawing.Point(483, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(49, 179);
            this.lbl.TabIndex = 3;
            this.lbl.Text = "0";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.btn);
            this.pnl.Controls.Add(this.line);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(45, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(438, 179);
            this.pnl.TabIndex = 4;
            // 
            // CesSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.pb);
            this.Name = "CesSlider";
            this.Size = new System.Drawing.Size(532, 179);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CesButton.CesRoundedButton btn;
        private CesLine line;
        private PictureBox pb;
        private Label lbl;
        private Panel pnl;
    }
}
