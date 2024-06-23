namespace Ces.WinForm.UI.CesComboBox
{
    partial class CesComboBox
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlButtonContainer = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.PictureBox();
            this.btnReloadData = new System.Windows.Forms.PictureBox();
            this.btnAddItem = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.PictureBox();
            this.txtSelectedItem = new System.Windows.Forms.TextBox();
            this.lblEnable = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.pnlButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReloadData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlButtonContainer);
            this.pnlContainer.Controls.Add(this.txtSelectedItem);
            this.pnlContainer.Controls.Add(this.lblEnable);
            this.pnlContainer.Location = new System.Drawing.Point(3, 3);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(213, 29);
            this.pnlContainer.TabIndex = 0;
            // 
            // pnlButtonContainer
            // 
            this.pnlButtonContainer.Controls.Add(this.btnClear);
            this.pnlButtonContainer.Controls.Add(this.btnReloadData);
            this.pnlButtonContainer.Controls.Add(this.btnAddItem);
            this.pnlButtonContainer.Controls.Add(this.btnOpen);
            this.pnlButtonContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtonContainer.Location = new System.Drawing.Point(133, 0);
            this.pnlButtonContainer.Name = "pnlButtonContainer";
            this.pnlButtonContainer.Size = new System.Drawing.Size(80, 29);
            this.pnlButtonContainer.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClear.Image = global::Ces.WinForm.UI.Properties.Resources.ComboboxClear;
            this.btnClear.Location = new System.Drawing.Point(0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(20, 29);
            this.btnClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClear.TabIndex = 1;
            this.btnClear.TabStop = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReloadData
            // 
            this.btnReloadData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReloadData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReloadData.Image = global::Ces.WinForm.UI.Properties.Resources.CesComboBoxReloadData;
            this.btnReloadData.Location = new System.Drawing.Point(20, 0);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(20, 29);
            this.btnReloadData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnReloadData.TabIndex = 5;
            this.btnReloadData.TabStop = false;
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddItem.Image = global::Ces.WinForm.UI.Properties.Resources.CesComboBoxAddItem;
            this.btnAddItem.Location = new System.Drawing.Point(40, 0);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(20, 29);
            this.btnAddItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.TabStop = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpen.Image = global::Ces.WinForm.UI.Properties.Resources.DatePickerDownArrow;
            this.btnOpen.Location = new System.Drawing.Point(60, 0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(20, 29);
            this.btnOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnOpen.TabIndex = 0;
            this.btnOpen.TabStop = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtSelectedItem
            // 
            this.txtSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedItem.BackColor = System.Drawing.SystemColors.Control;
            this.txtSelectedItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSelectedItem.Location = new System.Drawing.Point(7, 6);
            this.txtSelectedItem.Name = "txtSelectedItem";
            this.txtSelectedItem.Size = new System.Drawing.Size(120, 16);
            this.txtSelectedItem.TabIndex = 2;
            // 
            // lblEnable
            // 
            this.lblEnable.AutoSize = true;
            this.lblEnable.Location = new System.Drawing.Point(62, 6);
            this.lblEnable.Name = "lblEnable";
            this.lblEnable.Size = new System.Drawing.Size(22, 15);
            this.lblEnable.TabIndex = 3;
            this.lblEnable.Text = "---";
            this.lblEnable.Visible = false;
            // 
            // CesComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Name = "CesComboBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(221, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CesSimpleComboBox_Paint);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlButtonContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReloadData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlContainer;
        private PictureBox btnClear;
        private PictureBox btnOpen;
        private TextBox txtSelectedItem;
        private Label lblEnable;
        private PictureBox btnAddItem;
        private PictureBox btnReloadData;
        private Panel pnlButtonContainer;
    }
}
