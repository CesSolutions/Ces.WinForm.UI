﻿namespace Ces.WinForm.UI
{
    partial class CesPictureBox
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
            this.SuspendLayout();
            // 
            // CesSimplePictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CesSimplePictureBox";
            this.Size = new System.Drawing.Size(158, 147);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesPictureBox_Paint);
            this.Resize += new System.EventHandler(this.CesPictureBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
