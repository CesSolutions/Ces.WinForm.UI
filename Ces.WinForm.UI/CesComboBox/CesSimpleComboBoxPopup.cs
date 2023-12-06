using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesComboBox
{
    public partial class CesSimpleComboBoxPopup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesSimpleComboBoxPopup()
        {

            InitializeComponent();
        }

        private void CesSimpleComboBoxPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Dispose();
        }

        private void CesSimpleComboBoxPopup_Deactivate(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
