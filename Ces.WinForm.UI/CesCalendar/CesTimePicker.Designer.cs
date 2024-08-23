namespace Ces.WinForm.UI.CesCalendar
{
    partial class CesTimePicker
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
            pnlChildControl = new Panel();
            pbOpenTimePopup = new PictureBox();
            lblSelectedTime = new Label();
            pnlChildControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbOpenTimePopup).BeginInit();
            SuspendLayout();
            // 
            // pnlChildControl
            // 
            pnlChildControl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pnlChildControl.Controls.Add(pbOpenTimePopup);
            pnlChildControl.Controls.Add(lblSelectedTime);
            pnlChildControl.Location = new Point(5, 5);
            pnlChildControl.Margin = new Padding(0);
            pnlChildControl.Name = "pnlChildControl";
            pnlChildControl.Size = new Size(103, 25);
            pnlChildControl.TabIndex = 3;
            // 
            // pbOpenTimePopup
            // 
            pbOpenTimePopup.Anchor = AnchorStyles.Right;
            pbOpenTimePopup.Cursor = Cursors.Hand;
            pbOpenTimePopup.Image = Properties.Resources.CesTimePicker;
            pbOpenTimePopup.Location = new Point(82, 4);
            pbOpenTimePopup.Name = "pbOpenTimePopup";
            pbOpenTimePopup.Size = new Size(18, 16);
            pbOpenTimePopup.SizeMode = PictureBoxSizeMode.CenterImage;
            pbOpenTimePopup.TabIndex = 2;
            pbOpenTimePopup.TabStop = false;
            pbOpenTimePopup.Click += pbOpenTimePopup_Click;
            // 
            // lblSelectedTime
            // 
            lblSelectedTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSelectedTime.BackColor = Color.FromArgb(224, 224, 224);
            lblSelectedTime.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSelectedTime.Location = new Point(3, 4);
            lblSelectedTime.Name = "lblSelectedTime";
            lblSelectedTime.Size = new Size(73, 16);
            lblSelectedTime.TabIndex = 1;
            lblSelectedTime.TextAlign = ContentAlignment.MiddleLeft;
            lblSelectedTime.MouseClick += lblSelectedTime_MouseClick;
            // 
            // CesTimePicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlChildControl);
            Name = "CesTimePicker";
            Size = new Size(112, 35);
            Load += CesTimePicker_Load;
            Paint += CesTimePicker_Paint;
            pnlChildControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbOpenTimePopup).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlChildControl;
        private PictureBox pbOpenTimePopup;
        private Label lblSelectedTime;
    }
}
