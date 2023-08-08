using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI
{
    public partial class CesInputBox : Form
    {
        public CesInputBox()
        {
            InitializeComponent();
        }

        public string CesValue { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.CesValue = this.txtValue.CesTextBoxControl.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CesInputBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Orange, 2), new Rectangle(1, 1, this.Width - 2, this.Height - 2));
        }

        private void CesInputBox_Load(object sender, EventArgs e)
        {
            this.txtValue.CesTextBoxControl.Text = this.CesValue;
        }
    }
}
