namespace Ces.WinForm.UI
{
    partial class CesCheckBox
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
            this.pb = new System.Windows.Forms.PictureBox();
            this.lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb.Image = global::Ces.WinForm.UI.Properties.Resources.CheckBoxTypeB_24_Uncheck;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(24, 24);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            this.pb.Click += new System.EventHandler(this.pb_Click);
            // 
            // lbl
            // 
            this.lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl.Location = new System.Drawing.Point(24, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(192, 24);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "CesCheckBox";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl.Click += new System.EventHandler(this.lbl_Click);
            // 
            // CesCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.pb);
            this.Name = "CesCheckBox";
            this.Size = new System.Drawing.Size(216, 24);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pb;
        private Label lbl;
    }
}
