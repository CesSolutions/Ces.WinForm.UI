using System.ComponentModel;
using System.Drawing;

namespace Ces.WinForm.UI
{
    [ToolboxItem(true)]
    public partial class CesTextBox : Infrastructure.CesControlBase
    {
        public CesTextBox()
        {
            InitializeComponent();
            ChildContainer = this.pnlContainer;
        }

        public event EventHandler CesTextChanged;

        private Color currentBorderColor;

        #region Properties

        private int cesMaxLength { get; set; }
        [System.ComponentModel.Category("CesTextBox")]
        public int CesMaxLength
        {
            get
            {
                return cesMaxLength;
            }
            set
            {
                cesMaxLength = value;
                txtTextBox.MaxLength = value;
            }
        }

        private bool cesReadOnly { get; set; }
        [System.ComponentModel.Category("CesTextBox")]
        public bool CesReadOnly
        {
            get
            {
                return cesReadOnly;
            }
            set
            {
                cesReadOnly = value;
                txtTextBox.ReadOnly = value;
                this.GenerateBorder(this);
            }
        }

        private bool cesWordWrap { get; set; }
        [System.ComponentModel.Category("CesTextBox")]
        public bool CesWordWrap
        {
            get
            {
                return cesWordWrap;
            }
            set
            {
                cesWordWrap = value;
                txtTextBox.WordWrap = value;
            }
        }

        private RightToLeft cesRightToLeft { get; set; } = RightToLeft.No;
        [System.ComponentModel.Category("CesTextBox")]
        public RightToLeft CesRightToLeft
        {
            get
            {
                return cesRightToLeft;
            }
            set
            {
                cesRightToLeft = value;
                txtTextBox.RightToLeft = value;
            }
        }

        private bool cesMultiLine { get; set; }
        [System.ComponentModel.Category("CesTextBox")]
        public bool CesMultiLine
        {
            get
            {
                return cesMultiLine;
            }
            set
            {
                cesMultiLine = value;
                txtTextBox.Multiline = value;
                SetTextBoxWidth();
            }
        }

        private ScrollBars cesScrollBar { get; set; } = ScrollBars.None;
        [System.ComponentModel.Category("CesTextBox")]
        public ScrollBars CesScrollBar
        {
            get
            {
                return cesScrollBar;
            }
            set
            {
                cesScrollBar = value;
                txtTextBox.ScrollBars = value;
            }
        }

        private CharacterCasing cesCharacterCasing { get; set; } = CharacterCasing.Normal;
        [System.ComponentModel.Category("CesTextBox")]
        public CharacterCasing CesCharacterCasing
        {
            get
            {
                return cesCharacterCasing;
            }
            set
            {
                cesCharacterCasing = value;
                txtTextBox.CharacterCasing = value;
            }
        }

        private string cesPlaceHolderText { get; set; }
        [System.ComponentModel.Category("CesTextBox")]
        public string CesPlaceHolderText
        {
            get
            {
                return cesPlaceHolderText;
            }
            set
            {
                cesPlaceHolderText = value;
                txtTextBox.PlaceholderText = value;
            }
        }

        private char cesPasswordChar { get; set; }
        [System.ComponentModel.Category("CesTextBox")]
        public char CesPasswordChar
        {
            get
            {
                return cesPasswordChar;
            }
            set
            {
                cesPasswordChar = value;
                txtTextBox.PasswordChar = value;
            }
        }

        private CesInputTypeEnum cesInputType = CesInputTypeEnum.Any;
        [System.ComponentModel.Category("CesTextBox")]
        public CesInputTypeEnum CesInputType
        {
            get { return cesInputType; }
            set
            {
                cesInputType = value;

                if (value == CesInputTypeEnum.Password)
                    this.txtTextBox.PasswordChar = '*';
                else
                    this.txtTextBox.PasswordChar = '\0'; // \0 == null

                ValidateInputData();
            }
        }

        private string cesText;
        [System.ComponentModel.Category("CesTextBox")]
        public string CesText
        {
            get
            {
                return cesText;
            }
            set
            {
                cesText = value;
                txtTextBox.Text = value;
            }
        }

        private bool cesShowCopyButton { get; set; }
        [System.ComponentModel.Category("CesTextBox")]
        public bool CesShowCopyButton
        {
            get { return cesShowCopyButton; }
            set
            {
                cesShowCopyButton = value;
                btnCopy.Visible = value;
                SetTextBoxWidth();
            }
        }

        private bool cesShowPasteButton { get; set; }
        [System.ComponentModel.Category("CesTextBox")]
        public bool CesShowPasteButton
        {
            get { return cesShowPasteButton; }
            set
            {
                cesShowPasteButton = value;
                btnPaste.Visible = value;
                SetTextBoxWidth();
            }
        }

        private bool cesShowClearButton { get; set; }
        [System.ComponentModel.Category("CesTextBox")]
        public bool CesShowClearButton
        {
            get { return cesShowClearButton; }
            set
            {
                cesShowClearButton = value;
                btnClear.Visible = value;
                SetTextBoxWidth();
            }
        }

        public HorizontalAlignment cesTextAlignment = HorizontalAlignment.Left;
        [System.ComponentModel.Category("CesTextBox")]
        public HorizontalAlignment CesTextAlignment
        {
            get { return cesTextAlignment; }
            set
            {
                cesTextAlignment = value;
                txtTextBox.TextAlign = value;
            }
        }

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

        #endregion Properties

        #region Custom Methods

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
            this.txtTextBox.BackColor = Color.White;
            this.txtTextBox.ForeColor = Color.Black;
            this.pnlContainer.BackColor = Color.White;
            this.CesTitleTextColor = Color.White;
            this.CesFocusColor = Color.White;
        }

        private void ThemeDark()
        {
            this.BackColor = Color.FromArgb(64, 64, 64);
            this.CesBackColor = Color.FromArgb(64, 64, 64);
            this.CesBorderColor = Color.FromArgb(90, 90, 90);
            this.txtTextBox.BackColor = Color.FromArgb(64, 64, 64);
            this.txtTextBox.ForeColor = Color.Silver;
            this.pnlContainer.BackColor = Color.FromArgb(90, 90, 90);
            this.CesTitleTextColor = Color.Silver;
            this.CesFocusColor = Color.FromArgb(64, 64, 64);
        }

        private void ValidateInputData()
        {
            // ابتدا خطا را از کنترل لغو میکنیم و در زمان اعتبارسنجی اگر 
            // اشکالی وجود داشته باشد اقدام به نمایش اعلان خطا میکنیم
            this.CesHasNotification = false;

            // اگر نوع ورودی از نوع
            // Any, Password
            // باشد بنابراین فضای خالی نیز می تواند
            // به عنوا مقدار ورودی پذیرفته شود در نتیجه نیاز به اعتبار سنجی ندارد

            if (CesInputType == CesInputTypeEnum.Any)
                CesInputTypeEnumAnyValidation();

            else if (CesInputType == CesInputTypeEnum.Password)
                CesInputTypeEnumPasswordValidation();

            else if (CesInputType == CesInputTypeEnum.Number)
                CesInputTypeEnumNumberValidation();

            else if (CesInputType == CesInputTypeEnum.EmailAddress)
                CesInputTypeEnumEmailAddressValidation();
        }

        private void CesInputTypeEnumAnyValidation()
        {

        }

        private void CesInputTypeEnumPasswordValidation()
        {

        }

        private void CesInputTypeEnumNumberValidation()
        {
            string inputValue = this.txtTextBox.Text.Trim();

            if (inputValue.Length == 0)
                return;

            while (inputValue.Contains(".."))
                inputValue = inputValue.Replace("..", ".");

            if (inputValue.EndsWith("."))
                return;

            //var number = inputValue.Replace(",", "");
            inputValue = inputValue.Replace(",", "");
            var isValid = decimal.TryParse(inputValue, out decimal value);

            this.CesHasNotification = !isValid;

            if (!isValid)
                return;

            string[] parts = value.ToString().Split('.');

            var integralPart = decimal.Parse(parts[0]);
            var decimalPart = decimal.Parse(parts.Length == 2 ? parts[1] : "0");

            var finalResult = integralPart.ToString("N0") + (decimalPart > 0 ? "." + decimalPart.ToString() : "");

            // حرکت نشانگر به انتهای متن، تا عدد جدید در انتهای اعداد درج شود
            this.txtTextBox.Text = finalResult;

            if (decimalPart == 0)
                this.txtTextBox.Select(integralPart.ToString("N0").Length, 0);
            else
                this.txtTextBox.Select(this.txtTextBox.Text.Length, 0);
        }

        private void CesInputTypeEnumEmailAddressValidation()
        {
            if (string.IsNullOrEmpty(this.txtTextBox.Text.Trim()))
                return;

            var pattern = "^[A-Z0-9.]+@[A-Z0-9.-]+\\.[A-Z]{2,6}$";
            var regex = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            var result = regex.IsMatch(this.txtTextBox.Text.Trim());
            this.CesHasNotification = !result;
        }

        public void Clear()
        {
            CesText = string.Empty;
            Text = string.Empty;
        }

        public double GetValue()
        {
            if(string.IsNullOrEmpty(CesText?.Trim()))
                return 0;

            var normalizedText = CesText.Trim().Replace(",", string.Empty);

            var check = double.TryParse(normalizedText, out double result);

            if (!check)
                return result;
            else
                return double.Parse(normalizedText);
        }

        private void SetTextBoxWidth()
        {
            int visibleButton = 0;

            if (CesShowCopyButton)
                visibleButton += 1;

            if (CesShowPasteButton)
                visibleButton += 1;

            if (CesShowClearButton)
                visibleButton += 1;

            pnlButtonContainer.Width = visibleButton * 25;

            if (txtTextBox.Multiline)
            {
                txtTextBox.Left = 3;
                txtTextBox.Width = pnlContainer.Width - 3 - pnlButtonContainer.Width - 3;
                txtTextBox.Top = 3;
                txtTextBox.Height = pnlContainer.Height - 6;
            }
            else
            {
                txtTextBox.Left = 5;
                txtTextBox.Width = pnlContainer.Width - 5 - pnlButtonContainer.Width - 5;
                txtTextBox.Top = (pnlContainer.Height / 2) - (txtTextBox.Height / 2);
            }
        }

        #endregion Custom Methods

        #region Object Methods

        private void CesTextBox_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }

        private void txtTextBox_Enter(object sender, EventArgs e)
        {
            CesHasFocus = true;
            txtTextBox.BackColor = CesFocusColor;
            this.Invalidate();
        }

        private void txtTextBox_Leave(object sender, EventArgs e)
        {
            CesHasFocus = false;
            txtTextBox.BackColor = CesBackColor;
            this.Invalidate();
        }

        private void txtTextBox_TextChanged(object sender, EventArgs e)
        {
            CesText = txtTextBox.Text;
            ValidateInputData();
            CesTextChanged?.Invoke(sender, e);
        }

        private void txtTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (CesInputType == CesInputTypeEnum.Number)
            {
                if (
                    (e.KeyValue >= (int)Keys.NumPad0 && e.KeyValue <= (int)Keys.NumPad9)
                    || e.KeyValue == (int)Keys.Decimal
                    || e.KeyValue == (int)Keys.Back)
                    e.SuppressKeyPress = false;
                else
                    e.SuppressKeyPress = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            CesText = System.Windows.Forms.Clipboard.GetText(TextDataFormat.Text);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CesText))
                return;

            System.Windows.Forms.Clipboard.SetText(CesText, TextDataFormat.Text);
        }

        private void pnlContainer_Resize(object sender, EventArgs e)
        {
            SetTextBoxWidth();
        }

        private void btnPaste_MouseEnter(object sender, EventArgs e)
        {
            btnPaste.Image = Ces.WinForm.UI.Properties.Resources.CesTextBoxPaste;
        }

        private void btnPaste_MouseLeave(object sender, EventArgs e)
        {
            btnPaste.Image = Ces.WinForm.UI.Properties.Resources.CesTextBoxPasteNormal;
        }

        private void btnCopy_MouseEnter(object sender, EventArgs e)
        {
            btnCopy.Image = Ces.WinForm.UI.Properties.Resources.CesTextBoxCopy;
        }

        private void btnCopy_MouseLeave(object sender, EventArgs e)
        {
            btnCopy.Image = Ces.WinForm.UI.Properties.Resources.CesTextBoxCopyNormal;
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            btnClear.Image = Ces.WinForm.UI.Properties.Resources.CesTextBoxClear;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.Image = Ces.WinForm.UI.Properties.Resources.CesTextBoxClearNormal;
        }

        #endregion Object Methods

        #region Override Methods

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                txtTextBox.ForeColor = value;
            }
        }

        public override Color CesBackColor
        {
            get { return base.CesBackColor; }
            set
            {
                base.CesBackColor = value;
                txtTextBox.BackColor = value;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.txtTextBox.Focus();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
            {
                lblEnable.Text = string.Empty;
                lblEnable.Visible = !this.Enabled;

                txtTextBox.Visible = this.Enabled;

                CesBorderColor = currentBorderColor;
            }
            else
            {
                txtTextBox.Visible = this.Enabled;

                lblEnable.Left = txtTextBox.Left;
                lblEnable.Top = txtTextBox.Top;
                lblEnable.Width = txtTextBox.Width;
                lblEnable.Text = txtTextBox.Text;
                lblEnable.ForeColor = Color.DarkGray;
                lblEnable.Visible = !this.Enabled;

                currentBorderColor = CesBorderColor;
                CesBorderColor = Color.Silver;
            }
        }

        #endregion Override Methods
    }

    public enum CesInputTypeEnum
    {
        Any,
        Number,
        Password,
        EmailAddress,
    }
}
