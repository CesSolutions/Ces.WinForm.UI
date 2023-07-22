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
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.lblIssueDataTime = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbIcon.Location = new System.Drawing.Point(374, 25);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(50, 92);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 25);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblMessage.Location = new System.Drawing.Point(0, 25);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(374, 78);
            this.lblMessage.TabIndex = 3;
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCountDown.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCountDown.ForeColor = System.Drawing.Color.Silver;
            this.lblCountDown.Location = new System.Drawing.Point(52, 0);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(54, 12);
            this.lblCountDown.TabIndex = 4;
            this.lblCountDown.Text = "Remained :";
            // 
            // lblIssueDataTime
            // 
            this.lblIssueDataTime.AutoSize = true;
            this.lblIssueDataTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblIssueDataTime.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIssueDataTime.ForeColor = System.Drawing.Color.Silver;
            this.lblIssueDataTime.Location = new System.Drawing.Point(0, 0);
            this.lblIssueDataTime.Name = "lblIssueDataTime";
            this.lblIssueDataTime.Size = new System.Drawing.Size(52, 12);
            this.lblIssueDataTime.TabIndex = 5;
            this.lblIssueDataTime.Text = "Issue Date:";
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(424, 25);
            this.pnlTitle.TabIndex = 6;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lblCountDown);
            this.pnlStatus.Controls.Add(this.lblIssueDataTime);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 103);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(374, 14);
            this.pnlStatus.TabIndex = 7;
            // 
            // CesNotificationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(424, 117);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.pnlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CesNotificationBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CesNotification";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CesNotificationBox_FormClosing);
            this.Load += new System.EventHandler(this.CesNotification_Load);
            this.Shown += new System.EventHandler(this.CesNotification_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbIcon;
        private Label label1;
        private CesButton.CesRoundedButton btnExit;
        private Label lblMessage;
        private Label lblCountDown;
        private Label lblIssueDataTime;
        private Panel pnlTitle;
        private Panel pnlStatus;
    }
}