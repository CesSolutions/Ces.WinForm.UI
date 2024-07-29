using System.ComponentModel;

namespace Ces.WinForm.UI
{
    public partial class CesSlider : UserControl
    {
        public CesSlider()
        {
            InitializeComponent();
            standard = pnl.Width - 20;
            line.MouseWheel += new MouseEventHandler(MouseWheel);
            lbl.Visible = CesShowValue;
            pb.Visible = CesShowImage;
        }



        public delegate void CesSliderValueChangedEventHandler(object sender, decimal value);
        public event CesSliderValueChangedEventHandler CesSliderValueChanged;

        public delegate void CesSliderValueEventHandler(object sender, decimal value);
        public event CesSliderValueEventHandler CesSliderValue;

        private bool _mouseDown { get; set; }
        private Point _currentMousePosition { get; set; }
        private int newPosition { get; set; }
        private int standard { get; set; }


        private Image cesImage { get; set; }
        [Category("Ces Slider")]
        public Image CesImage
        {
            get { return cesImage; }
            set
            {
                cesImage = value;
                pb.Image = value;
            }
        }

        private int cesValuePrecision { get; set; } = 0;
        [Category("Ces Slider")]
        public int CesValuePrecision
        {
            get { return cesValuePrecision; }
            set { cesValuePrecision = value; }
        }


        private bool cesShowImage { get; set; }
        [Category("Ces Slider")]
        public bool CesShowImage
        {
            get { return cesShowImage; }
            set
            {
                cesShowImage = value;
                pb.Visible = value;
            }
        }

        private bool cesShowValue { get; set; }
        [Category("Ces Slider")]
        public bool CesShowValue
        {
            get { return cesShowValue; }
            set
            {
                cesShowValue = value;
                lbl.Visible = value;
            }
        }

        private string cesValueSymbol { get; set; }
        [Category("Ces Slider")]
        public string CesValueSymbol
        {
            get { return cesValueSymbol; }
            set
            {
                cesValueSymbol = value;
                ShowValue(CesValue);
            }
        }

        private decimal cesValue { get; set; }
        [Category("Ces Slider")]
        public decimal CesValue
        {
            get { return cesValue; }
            set
            {
                cesValue = value;

                if (value < CesMinValue)
                {
                    cesValue = CesMinValue;
                    return;
                }

                if (value > CesMaxValue)
                {
                    cesValue = CesMaxValue;
                    return;
                }

                SetNewPosition();
                SetSliderPosition();

                ShowValue(cesValue);

                if (CesSliderValueChanged != null)
                    CesSliderValueChanged(this, cesValue);
            }
        }

        private decimal cesMinValue { get; set; } = 0;
        [Category("Ces Slider")]
        private decimal CesMinValue
        {
            get { return cesMinValue; }
            set
            {
                cesMinValue = value;
                SetCalculateValue();
            }
        }

        private decimal cesMaxValue { get; set; } = 100;
        [Category("Ces Slider")]
        public decimal CesMaxValue
        {
            get { return cesMaxValue; }
            set
            {
                cesMaxValue = value;
                SetCalculateValue();
            }
        }

        [Category("Ces Slider")]
        [Description("When user click on arrows/mouse wheel, CesValue inclreases or decreases according to MovingStep.")]
        public decimal CesMovingStep { get; set; } = 1;

        private Color cesBackColor { get; set; } = Color.FromArgb(64, 64, 64);
        [Category("Ces Slider")]
        public Color CesBackColor
        {
            get { return cesBackColor; }
            set
            {
                cesBackColor = value;
                line.CesLineColor = value;
            }
        }

        private Color cesSliderColor { get; set; } = Color.DarkOrange;
        [Category("Ces Slider")]
        public Color CesSliderColor
        {
            get { return cesSliderColor; }
            set
            {
                cesSliderColor = value;
                btn.CesBackColor = value;
                btn.CesMouseDownColor = value;
                btn.CesMouseOverColor = value;
            }
        }

        private void line_Resize(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _mouseDown = true;
            _currentMousePosition = e.Location;
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !_mouseDown)
                return;

            if (e.Button == MouseButtons.Left)
            {
                SetSliderPosition(e.X);

                decimal currentValue = CalculateValue();

                ShowValue(currentValue);

                if (CesSliderValue != null)
                    CesSliderValue(this, currentValue);

            }
        }

        private void SetSliderPosition(int? newMouseYLocation = null)
        {
            if (newMouseYLocation.HasValue)
                newPosition = btn.Left + (newMouseYLocation.Value - _currentMousePosition.X);

            if (newPosition < 0)
                newPosition = 0;

            if (newPosition > standard)
                newPosition = standard;

            btn.Left = newPosition;
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
            SetCalculateValue();

            if (CesSliderValueChanged != null)
                CesSliderValueChanged(this, CesValue);
        }

        /// <summary>
        /// این متد بعد از اینکه کاربر کلیک ماوس را رها کند فراخوانی خواهد
        /// شد تا نتیجه مقدار جدید درمتغیر ذخیره شود و رویدادها مربوط به اجرا شوند
        /// این متد مقدارش را از متد
        /// CalculateValue
        /// دریافت خواهد کرد
        /// </summary>
        private void SetCalculateValue()
        {
            CesValue = (newPosition * CesMaxValue) / standard;
        }

        /// <summary>
        /// این متد مقدار اسکرول را با توجه به موقعیت لغزنده محاسبه میکند
        /// تا رویداد تغییرات لحظه ای بتواند از آن استفاده کند شاید مورد
        /// نیاز کاربر باشد
        /// </summary>
        /// <returns>مقدار اسکرول</returns>
        private decimal CalculateValue()
        {
            decimal result = (newPosition * CesMaxValue) / standard;
            return result;
        }

        private void SetNewPosition()
        {
            if (CesMaxValue == 0)
                return;

            newPosition = ((int)((standard * CesValue) / CesMaxValue));
        }

        private void ResetValues()
        {
            btn.Top = (pnl.Height / 2) - (btn.Height / 2);
            standard = pnl.Width - 20;
            SetNewPosition();
            SetSliderPosition();
        }

        private void MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
                CesValue -= CesMovingStep;
            else
                CesValue += CesMovingStep;
        }

        private void ShowValue(decimal value)
        {
            lbl.Text = value.ToString("N" + CesValuePrecision.ToString()) + " " + CesValueSymbol;
        }
    }
}
