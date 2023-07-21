namespace Ces.WinForm.UI.CesNotificationBox
{
    internal partial class CesNotificationBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CesNotificationBox));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(516, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(585, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.CesBackColor = System.Drawing.Color.Tomato;
            this.btnClose.CesBorderColor = System.Drawing.Color.Firebrick;
            this.btnClose.CesBorderRadius = 15;
            this.btnClose.CesBorderThickness = 1;
            this.btnClose.CesBorderVisible = false;
            this.btnClose.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Red;
            this.btnClose.CesFont = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnClose.CesForeColor = System.Drawing.Color.Black;
            this.btnClose.CesIcon = global::Ces.WinForm.UI.Properties.Resources.Exit;
            this.btnClose.CesIconAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.CesMouseDownColor = System.Drawing.Color.Tomato;
            this.btnClose.CesMouseOverColor = System.Drawing.Color.Salmon;
            this.btnClose.CesShowIcon = true;
            this.btnClose.CesShowText = false;
            this.btnClose.CesText = "CesButton";
            this.btnClose.CesTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(596, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(44, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(466, 64);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCountDown.Location = new System.Drawing.Point(4, 150);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(62, 12);
            this.lblCountDown.TabIndex = 4;
            this.lblCountDown.Text = "Remained : 0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CesNotificationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 167);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CesNotificationBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CesNotification";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CesNotificationBox_FormClosing);
            this.Load += new System.EventHandler(this.CesNotification_Load);
            this.Shown += new System.EventHandler(this.CesNotification_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private CesButton.CesRoundedButton btnClose;
        private Label label2;
        private Label lblCountDown;
        private Button button1;
    }
}