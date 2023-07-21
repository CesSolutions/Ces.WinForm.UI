namespace Ces.WinForm.UI.CesNotification
{
    internal partial class CesNotification
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CesNotification));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cesRoundedButton1 = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCountDown = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(516, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // cesRoundedButton1
            // 
            this.cesRoundedButton1.BackColor = System.Drawing.SystemColors.Control;
            this.cesRoundedButton1.CesBackColor = System.Drawing.Color.Gray;
            this.cesRoundedButton1.CesBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cesRoundedButton1.CesBorderRadius = 15;
            this.cesRoundedButton1.CesBorderThickness = 1;
            this.cesRoundedButton1.CesBorderVisible = false;
            this.cesRoundedButton1.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Gray;
            this.cesRoundedButton1.CesFont = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cesRoundedButton1.CesForeColor = System.Drawing.Color.Black;
            this.cesRoundedButton1.CesMouseDownColor = System.Drawing.Color.Gray;
            this.cesRoundedButton1.CesMouseOverColor = System.Drawing.Color.DarkGray;
            this.cesRoundedButton1.CesText = "CesButton";
            this.cesRoundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cesRoundedButton1.Location = new System.Drawing.Point(7, 122);
            this.cesRoundedButton1.Margin = new System.Windows.Forms.Padding(10);
            this.cesRoundedButton1.Name = "cesRoundedButton1";
            this.cesRoundedButton1.Size = new System.Drawing.Size(120, 40);
            this.cesRoundedButton1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(44, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(441, 64);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Location = new System.Drawing.Point(308, 128);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(38, 15);
            this.lblCountDown.TabIndex = 4;
            this.lblCountDown.Text = "label3";
            // 
            // CesNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 167);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cesRoundedButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CesNotification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CesNotification";
            this.Load += new System.EventHandler(this.CesNotification_Load);
            this.Shown += new System.EventHandler(this.CesNotification_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private CesButton.CesRoundedButton cesRoundedButton1;
        private Label label2;
        private Label lblCountDown;
    }
}