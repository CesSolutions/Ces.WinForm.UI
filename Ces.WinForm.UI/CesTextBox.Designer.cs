﻿namespace Ces.WinForm.UI
{
    partial class CesTextBox
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
            this.txtTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTextBox
            // 
            this.txtTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTextBox.Location = new System.Drawing.Point(8, 6);
            this.txtTextBox.Name = "txtTextBox";
            this.txtTextBox.Size = new System.Drawing.Size(174, 16);
            this.txtTextBox.TabIndex = 0;
            this.txtTextBox.TabStop = false;
            this.txtTextBox.TextChanged += new System.EventHandler(this.txtTextBox_TextChanged);
            this.txtTextBox.Enter += new System.EventHandler(this.txtTextBox_Enter);
            this.txtTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTextBox_KeyDown);
            this.txtTextBox.Leave += new System.EventHandler(this.txtTextBox_Leave);
            // 
            // CesTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTextBox);
            this.Name = "CesTextBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(188, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesTextBox_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtTextBox;
    }
}
