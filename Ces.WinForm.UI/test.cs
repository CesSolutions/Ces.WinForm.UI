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
    public partial class Test : Infrastructure.CesControlBase
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Paint(object sender, PaintEventArgs e)
        {
            base.ArrangeControls(this);
            base.GenerateBorder(this);
        }
    }
}
