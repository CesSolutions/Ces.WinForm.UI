namespace Ces.WinForm.UI.CesScrollBar
{
    partial class CesVerticalScrollBar
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
            this.pbDown = new System.Windows.Forms.PictureBox();
            this.pbUp = new System.Windows.Forms.PictureBox();
            this.pbSlider = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDown
            // 
            this.pbDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbDown.Image = global::Ces.WinForm.UI.Properties.Resources.CesScrollBarDown;
            this.pbDown.Location = new System.Drawing.Point(2, 388);
            this.pbDown.Name = "pbDown";
            this.pbDown.Size = new System.Drawing.Size(61, 20);
            this.pbDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDown.TabIndex = 6;
            this.pbDown.TabStop = false;
            // 
            // pbUp
            // 
            this.pbUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbUp.Image = global::Ces.WinForm.UI.Properties.Resources.CesScrollBarUp;
            this.pbUp.Location = new System.Drawing.Point(2, 2);
            this.pbUp.Name = "pbUp";
            this.pbUp.Size = new System.Drawing.Size(61, 20);
            this.pbUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbUp.TabIndex = 5;
            this.pbUp.TabStop = false;
            // 
            // pbSlider
            // 
            this.pbSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSlider.Location = new System.Drawing.Point(2, 28);
            this.pbSlider.Name = "pbSlider";
            this.pbSlider.Size = new System.Drawing.Size(30, 30);
            this.pbSlider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSlider.TabIndex = 4;
            this.pbSlider.TabStop = false;
            this.pbSlider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSlider_MouseDown);
            this.pbSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSlider_MouseMove);
            this.pbSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSlider_MouseUp);
            // 
            // CesVerticalScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbDown);
            this.Controls.Add(this.pbUp);
            this.Controls.Add(this.pbSlider);
            this.Name = "CesVerticalScrollBar";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(65, 410);
            this.Resize += new System.EventHandler(this.CesVerticalScrollBar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbDown;
        private PictureBox pbUp;
        private PictureBox pbSlider;
    }
}
