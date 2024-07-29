using System.ComponentModel;

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

        private Color currentBorderColor;

        private decimal cesValue { get; set; } = 0;
        [Category("Ces NumberInput")]
        public decimal CesValue
        {
            get { return cesValue; }
            set
            {
                cesValue = value;

                if (value < CesMinValue)
                    cesValue = CesMaxValue;

                if (value > CesMaxValue)
                    cesValue = CesMinValue;

                txtValue.Text = CesValue.ToString();
            }
        }
        [Category("Ces NumberInput")]
        public decimal CesMinValue { get; set; } = 0;
        [Category("Ces NumberInput")]
        public decimal CesMaxValue { get; set; } = 100;
        [Category("Ces NumberInput")]
        public decimal CesStep { get; set; } = 1;

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().EndsWith("."))
                return;

            CesValue = decimal.Parse(((TextBox)sender).Text);
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= (int)Keys.NumPad0 && e.KeyValue <= (int)Keys.NumPad9) ||
                e.KeyValue == (int)Keys.Decimal ||
                e.KeyValue == (int)Keys.Back)
                e.SuppressKeyPress = false;
            else
                e.SuppressKeyPress = true;
        }

        private void pbPlus_Click(object sender, EventArgs e)
        {
            CesValue += CesStep;
        }

        private void pbMinus_Click(object sender, EventArgs e)
        {
            CesValue -= CesStep;
        }

        private void CesNumberInput_Paint(object sender, PaintEventArgs e)
        {
            this.txtValue.Left = pbMinus.Width + 5;
            this.txtValue.Width = pnlContainer.Width - pbMinus.Width - pbnPlus.Width - 10;
            this.txtValue.Top = (this.pnlContainer.Height / 2) - (this.txtValue.Height / 2);

            GenerateBorder(this);
        }

        private void txtValue_MouseEnter(object sender, EventArgs e)
        {            
            CesHasFocus = true;
            this.txtValue.BackColor = CesFocusColor;
            this.Invalidate();
        }

        private void txtValue_MouseLeave(object sender, EventArgs e)
        {
            CesHasFocus = false;
            this.txtValue.BackColor = CesBackColor;
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.txtValue.Focus();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
                CesBorderColor = currentBorderColor;
            else
            {
                currentBorderColor = CesBorderColor;
                CesBorderColor = Color.Silver;
            }
        }
    }
}
