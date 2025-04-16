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
            pnlContainer = new Panel();
            lblEnable = new Label();
            lblLoading = new Label();
            pnlButtonContainer = new Panel();
            btnEditItem = new PictureBox();
            btnClear = new PictureBox();
            btnReloadData = new PictureBox();
            btnAddItem = new PictureBox();
            btnOpen = new PictureBox();
            txtSelectedItem = new TextBox();
            pnlContainer.SuspendLayout();
            pnlButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnEditItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnClear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnReloadData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnAddItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnOpen).BeginInit();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(lblEnable);
            pnlContainer.Controls.Add(lblLoading);
            pnlContainer.Controls.Add(pnlButtonContainer);
            pnlContainer.Controls.Add(txtSelectedItem);
            pnlContainer.Location = new Point(3, 3);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(252, 29);
            pnlContainer.TabIndex = 0;
            pnlContainer.Resize += pnlContainer_Resize;
            // 
            // lblEnable
            // 
            lblEnable.AutoSize = true;
            lblEnable.BackColor = SystemColors.ActiveCaption;
            lblEnable.Location = new Point(90, 6);
            lblEnable.Name = "lblEnable";
            lblEnable.Size = new Size(22, 15);
            lblEnable.TabIndex = 3;
            lblEnable.Text = "---";
            lblEnable.Visible = false;
            // 
            // lblLoading
            // 
            lblLoading.BackColor = SystemColors.Info;
            lblLoading.ForeColor = SystemColors.ControlDark;
            lblLoading.Location = new Point(4, 6);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(80, 15);
            lblLoading.TabIndex = 7;
            lblLoading.Text = "Loading...";
            lblLoading.Visible = false;
            // 
            // pnlButtonContainer
            // 
            pnlButtonContainer.Controls.Add(btnEditItem);
            pnlButtonContainer.Controls.Add(btnClear);
            pnlButtonContainer.Controls.Add(btnReloadData);
            pnlButtonContainer.Controls.Add(btnAddItem);
            pnlButtonContainer.Controls.Add(btnOpen);
            pnlButtonContainer.Dock = DockStyle.Right;
            pnlButtonContainer.Location = new Point(152, 0);
            pnlButtonContainer.Name = "pnlButtonContainer";
            pnlButtonContainer.Size = new Size(100, 29);
            pnlButtonContainer.TabIndex = 6;
            // 
            // btnEditItem
            // 
            btnEditItem.Cursor = Cursors.Hand;
            btnEditItem.Dock = DockStyle.Right;
            btnEditItem.Image = Properties.Resources.CesComboBoxEditItem;
            btnEditItem.Location = new Point(0, 0);
            btnEditItem.Name = "btnEditItem";
            btnEditItem.Size = new Size(20, 29);
            btnEditItem.SizeMode = PictureBoxSizeMode.CenterImage;
            btnEditItem.TabIndex = 6;
            btnEditItem.TabStop = false;
            btnEditItem.Click += btnEditItem_Click;
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.Dock = DockStyle.Right;
            btnClear.Image = Properties.Resources.CesComboBoxClear;
            btnClear.Location = new Point(20, 0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(20, 29);
            btnClear.SizeMode = PictureBoxSizeMode.CenterImage;
            btnClear.TabIndex = 1;
            btnClear.TabStop = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnReloadData
            // 
            btnReloadData.Cursor = Cursors.Hand;
            btnReloadData.Dock = DockStyle.Right;
            btnReloadData.Image = Properties.Resources.CesComboBoxReloadData;
            btnReloadData.Location = new Point(40, 0);
            btnReloadData.Name = "btnReloadData";
            btnReloadData.Size = new Size(20, 29);
            btnReloadData.SizeMode = PictureBoxSizeMode.CenterImage;
            btnReloadData.TabIndex = 5;
            btnReloadData.TabStop = false;
            btnReloadData.Click += btnReloadData_Click;
            // 
            // btnAddItem
            // 
            btnAddItem.Cursor = Cursors.Hand;
            btnAddItem.Dock = DockStyle.Right;
            btnAddItem.Image = Properties.Resources.CesComboBoxAddItem;
            btnAddItem.Location = new Point(60, 0);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(20, 29);
            btnAddItem.SizeMode = PictureBoxSizeMode.CenterImage;
            btnAddItem.TabIndex = 4;
            btnAddItem.TabStop = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnOpen
            // 
            btnOpen.Cursor = Cursors.Hand;
            btnOpen.Dock = DockStyle.Right;
            btnOpen.Image = Properties.Resources.CesComboBoxDropDown;
            btnOpen.Location = new Point(80, 0);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(20, 29);
            btnOpen.SizeMode = PictureBoxSizeMode.CenterImage;
            btnOpen.TabIndex = 0;
            btnOpen.TabStop = false;
            btnOpen.Click += btnOpen_Click;
            // 
            // txtSelectedItem
            // 
            txtSelectedItem.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSelectedItem.BackColor = SystemColors.AppWorkspace;
            txtSelectedItem.BorderStyle = BorderStyle.None;
            txtSelectedItem.Location = new Point(7, 6);
            txtSelectedItem.Name = "txtSelectedItem";
            txtSelectedItem.Size = new Size(138, 16);
            txtSelectedItem.TabIndex = 2;
            // 
            // CesComboBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Name = "CesComboBox";
            Padding = new Padding(3);
            Size = new Size(258, 35);
            Paint += CesSimpleComboBox_Paint;
            Enter += CesComboBox_Enter;
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            pnlButtonContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnEditItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnClear).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnReloadData).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnAddItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnOpen).EndInit();
            ResumeLayout(false);
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
        private PictureBox btnEditItem;
        private Label lblLoading;
    }
}
