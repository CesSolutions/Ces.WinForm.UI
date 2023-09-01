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

        private CesInputTypeEnum cesInputType = CesInputTypeEnum.Any;
        [System.ComponentModel.Category("Ces TextBox")]
        public CesInputTypeEnum CesInputType
        {
            get { return cesInputType; }
            set
            {
                cesInputType = value;
                ValidateInputData();
            }
        }

        private void ValidateInputData()
        {
            // /0 == null
            this.txtTextBox.PasswordChar = '\0';
            this.CesHasNotification = false;

            if (CesInputType == CesInputTypeEnum.Password)
            {
                this.txtTextBox.PasswordChar = '*';
                return;
            }

            // اگر نوع ورودی از نوعی باشد بنابراین فضای خالی نیز می تواند
            // به عنوا مقدارورودی پذیرفته شود
            if (CesInputType == CesInputTypeEnum.Any)
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
                {
                    this.txtTextBox.Text = string.Empty;
                    return;
                }

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
            this.Invalidate();
        }

        private void txtTextBox_Leave(object sender, EventArgs e)
        {
            CesHasFocus = false;
            this.Invalidate();
        }

        private void txtTextBox_TextChanged(object sender, EventArgs e)
        {
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
    }

    public enum CesInputTypeEnum
    {
        Any,
        Number,
        Password,
        EmailAddress,
    }
}
