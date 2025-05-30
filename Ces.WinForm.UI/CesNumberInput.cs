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

        private Infrastructure.ThemeEnum cesTheme { get; set; }
            = Infrastructure.ThemeEnum.White;
        [Category("CesTextBox")]
        public Infrastructure.ThemeEnum CesTheme
        {
            get { return cesTheme; }
            set
            {
                cesTheme = value;
                SetTheme();
            }
        }

        private void SetTheme()
        {
            if (this.CesTheme == Infrastructure.ThemeEnum.None)
                ThemeNone();
            else if (this.CesTheme == Infrastructure.ThemeEnum.White)
                ThemeWhite();
            else if (this.CesTheme == Infrastructure.ThemeEnum.Dark)
                ThemeDark();
        }

        private void ThemeNone()
        {

        }

        private void ThemeWhite()
        {
            this.BackColor = Color.White;
            this.CesBackColor = Color.White;
            this.CesBorderColor = Color.DeepSkyBlue;
            this.txtValue.BackColor = Color.White;
            this.txtValue.ForeColor = Color.Black;
            this.pnlContainer.BackColor = Color.White;
            this.CesTitleTextColor = Color.White;
            this.CesFocusColor = Color.White;
        }

        private void ThemeDark()
        {
            this.BackColor = Color.FromArgb(64, 64, 64);
            this.CesBackColor = Color.FromArgb(64, 64, 64);
            this.CesBorderColor = Color.FromArgb(90, 90, 90);
            this.txtValue.BackColor = Color.FromArgb(64, 64, 64);
            this.txtValue.ForeColor = Color.Silver;
            this.pnlContainer.BackColor = Color.FromArgb(90, 90, 90);
            this.CesTitleTextColor = Color.Silver;
            this.CesFocusColor = Color.FromArgb(64, 64, 64);
        }

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
