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
            this.SuspendLayout();
            // 
            // flp
            // 
            this.flp.BackColor = System.Drawing.Color.White;
            this.flp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp.Location = new System.Drawing.Point(0, 0);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(338, 282);
            this.flp.TabIndex = 0;
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
            this.vs.Location = new System.Drawing.Point(338, 0);
            this.vs.Margin = new System.Windows.Forms.Padding(0);
            this.vs.Name = "vs";
            this.vs.Size = new System.Drawing.Size(24, 282);
            this.vs.TabIndex = 1;
            this.vs.CesScrollValueChanged += new Ces.WinForm.UI.CesScrollBar.CesVerticalScrollBar.CesScrollValueChangedEventHandler(this.vs_CesScrollValueChanged);
            // 
            // CesListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flp);
            this.Controls.Add(this.vs);
            this.Name = "CesListBox";
            this.Size = new System.Drawing.Size(362, 282);
            this.Load += new System.EventHandler(this.CesListBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp;
        private CesScrollBar.CesVerticalScrollBar vs;
    }
}
