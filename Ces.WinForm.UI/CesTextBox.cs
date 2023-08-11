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
    public partial class CesTextBox : Infrastructure.CesControlBase
    {
        public CesTextBox()
        {
            InitializeComponent();
            ChildContainer = this.txtTextBox;
        }


        private void CesTextBox_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }


        private void txtTextBox_Enter(object sender, EventArgs e)
        {
            CesHasFocus = true;
            this.Invalidate();
        }

        private void txtTextBox_Leave(object sender, EventArgs e)
        {
            CesHasFocus = false;
            this.Invalidate();
        }

    }
}
