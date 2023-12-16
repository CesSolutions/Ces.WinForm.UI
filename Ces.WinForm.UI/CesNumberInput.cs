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
    [ToolboxItem(true)]
    public partial class CesNumberInput : Ces.WinForm.UI.Infrastructure.CesControlBase
    {
        public CesNumberInput()
        {
            InitializeComponent();
            ChildContainer = pnlContainer;
        }

        public Decimal CesValue { get; set; }
        public Decimal CesMinValue { get; set; } = 0;
        public Decimal CesMaxValue { get; set; } = 1000;
        public Decimal CesStep { get; set; } = 1;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= (int)Keys.NumPad0 && e.KeyValue <= (int)Keys.NumPad9) ||
                e.KeyValue == (int)Keys.Decimal)
                e.SuppressKeyPress = false;
            else
                e.SuppressKeyPress = true;
        }

        private void pbPlus_Click(object sender, EventArgs e)
        {
            if (CesValue >= CesMaxValue)
                return;

            CesValue += CesStep;
            txtValue.Text = CesValue.ToString();
        }

        private void pbMinus_Click(object sender, EventArgs e)
        {
            if (CesValue <= CesMaxValue)
                return;

            CesValue -= CesStep;
            txtValue.Text = CesValue.ToString();
        }

        private void CesNumberInput_Paint(object sender, PaintEventArgs e)
        {
            this.txtValue.Left = pbMinus.Width + 5;
            this.txtValue.Width = pnlContainer.Width - pbMinus.Width - pbnPlus.Width - 10;
            this.txtValue.Top = (this.pnlContainer.Height/2) - (this.txtValue.Height / 2);

            GenerateBorder(this);
        }
    }
}
