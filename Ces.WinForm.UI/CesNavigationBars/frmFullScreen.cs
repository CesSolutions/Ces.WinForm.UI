using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesNavigationBars
{
    public partial class frmFullScreen : CesForm.CesForm
    {
        public Control? Parent;
        public Control? GridView;

        public frmFullScreen()
        {
            InitializeComponent();
        }

        private void frmFullScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parent?.Controls.Add(GridView);
            Dispose();
        }

        private void frmFullScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
