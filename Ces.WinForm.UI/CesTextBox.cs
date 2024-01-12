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
    public partial class CesTextBox : Infrastructure.CesControlBase
    {
        public CesTextBox()
        {
            InitializeComponent();
            ChildContainer = this.pnlContainer;
        }

        [System.ComponentModel.Category("Ces TextBox")]
        public override Color CesBackColor
        {
            get { return base.CesBackColor; }
            set
            {
                base.CesBackColor = value;
                this.txtTextBox.BackColor = CesBackColor;
            }
        }

        private CesInputTypeEnum cesInputType = CesInputTypeEnum.Any;
        [System.ComponentModel.Category("Ces TextBox")]
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

        public bool cesShowCopyButton { get; set; }
        [System.ComponentModel.Category("Ces TextBox")]
        public bool CesShowCopyButton
        {
            get { return cesShowCopyButton; }
            set
            {
                cesShowCopyButton = value;
                btnCopy.Visible = value;
            }
        }

        public bool cesShowPasteButton { get; set; }
        [System.ComponentModel.Category("Ces TextBox")]
        public bool CesShowPasteButton
        {
            get { return cesShowPasteButton; }
            set
            {
                cesShowPasteButton = value;
                btnPaste.Visible = value;
            }
        }

        public bool cesShowClearButton { get; set; }
        [System.ComponentModel.Category("Ces TextBox")]
        public bool CesShowClearButton
        {
            get { return cesShowClearButton; }
            set
            {
                cesShowClearButton = value;
                btnClear.Visible = value;
            }
        }

        private string cesText;
        //[System.ComponentModel.Category("Ces TextBox")]
        //public string? Text
        //{
        //    get { return cesText; }
        //    set
        //    {
        //        cesText = value;
        //        ((TextBox)ChildContainer).Text = value;
        //    }
        //}

        private void ValidateInputData()
        {
            // ابتدا خطا را از کنترل لغو میکنیم و در زمان اعتبارسنجی اگر 
            // اشکالی وجود داشته باشد اقدام به نمایش اعلان خطا میکنیم
            this.CesHasNotification = false;

            // اگر نوع ورودی از نوع
            // Any, Password
            // باشد بنابراین فضای خالی نیز می تواند
            // به عنوا مقدار ورودی پذیرفته شود در نتیجه نیاز به اعتبار سنجی ندارد
            if (CesInputType == CesInputTypeEnum.Any || CesInputType == CesInputTypeEnum.Password)
                return;

            if (CesInputType == CesInputTypeEnum.Number)
            {
                if (this.txtTextBox.Text.Trim().Length == 0)
                    return;

                if (this.txtTextBox.Text.Trim().EndsWith("."))
                    return;

                var number = this.txtTextBox.Text.Replace(",", "");
                var result = decimal.TryParse(number, out decimal value);

                this.CesHasNotification = !result;

                if (!result)
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

                return;
            }

            if (CesInputType == CesInputTypeEnum.EmailAddress)
            {
                if (string.IsNullOrEmpty(this.txtTextBox.Text.Trim()))
                    return;

                var pattern = "^[A-Z0-9.]+@[A-Z0-9.-]+\\.[A-Z]{2,6}$";
                var regex = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                var result = regex.IsMatch(this.txtTextBox.Text.Trim());
                this.CesHasNotification = !result;
                return;
            }
        }

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
            Text = ((TextBox)sender).Text;
            ValidateInputData();
        }

        private void txtTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (CesInputType == CesInputTypeEnum.Number)
            {
                if ((e.KeyValue >= (int)Keys.NumPad0 && e.KeyValue <= (int)Keys.NumPad9) ||
                    e.KeyValue == (int)Keys.Decimal)
                    e.SuppressKeyPress = false;
                else
                    e.SuppressKeyPress = true;
            }
        }

        public void Clear()
        {
            Text = string.Empty;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.txtTextBox.Focus();
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                txtTextBox.Text = value;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            Text = System.Windows.Forms.Clipboard.GetText(TextDataFormat.Text);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(Text, TextDataFormat.Text);
        }

        private void pnlContainer_Resize(object sender, EventArgs e)
        {
            txtTextBox.Top = (pnlContainer.Height / 2) - (txtTextBox.Height / 2);
        }
    }

    public enum CesInputTypeEnum
    {
        Any,
        Number,
        Password,
        EmailAddress,
    }
}
