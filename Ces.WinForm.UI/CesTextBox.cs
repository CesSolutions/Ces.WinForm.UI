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


            if (CesInputType == CesInputTypeEnum.Integer)
            {
                if (string.IsNullOrEmpty(this.txtTextBox.Text.Trim()))
                {
                    this.txtTextBox.Text = "0";
                    return;
                }

                var result = int.TryParse(this.txtTextBox.Text.Trim(), out int value);

                this.CesHasNotification = !result;
                return;
            }

            if (CesInputType == CesInputTypeEnum.Decimal)
            {
                if (string.IsNullOrEmpty(this.txtTextBox.Text.Trim()))
                {
                    this.txtTextBox.Text = "0";
                    return;
                }

                var result = decimal.TryParse(this.txtTextBox.Text.Trim(), out decimal value);

                this.CesHasNotification = !result;
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
                var regex = new System.Text.RegularExpressions.Regex(pattern,System.Text.RegularExpressions.RegexOptions.IgnoreCase);
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
            ValidateInputData();
            this.Invalidate();
        }

    }

    public enum CesInputTypeEnum
    {
        Any,
        Integer,
        Decimal,
        EmailAddress,
        Password
    }
}
