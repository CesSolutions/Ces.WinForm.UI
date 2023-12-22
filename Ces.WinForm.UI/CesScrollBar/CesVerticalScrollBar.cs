using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesScrollBar
{
    [DefaultEvent(nameof(CesScrollValueChanged))]
    public partial class CesVerticalScrollBar : UserControl
    {
        public CesVerticalScrollBar()
        {
            InitializeComponent();
            standard = pnlSlider.Height - 20;
        }

        public delegate void CesScrollValueChangedEventHandler(object sender, int value);
        public event CesScrollValueChangedEventHandler CesScrollValueChanged;

        public delegate void CesScrollValueEventHandler(object sender, int value);
        public event CesScrollValueEventHandler CesScrollValue;

        public delegate void CesScrollMinValueEventHandler(object sender, int value);
        public event CesScrollMinValueEventHandler CesScrollMinValue;

        public delegate void CesScrollMaxValueEventHandler(object sender, int value);
        public event CesScrollMaxValueEventHandler CesScrollMaxValue;


        private bool _mouseDown { get; set; }
        private Point _currentMousePosition { get; set; }
        private int newPosition { get; set; }
        private int standard { get; set; }


        private int cesValue { get; set; }
        [Category("Ces VerticalScrollBar")]
        public int CesValue
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
                ExecuteEventHandler();
            }
        }

        private int cesMinValue { get; set; } = 0;
        [Category("Ces VerticalScrollBar")]
        private int CesMinValue
        {
            get { return cesMinValue; }
            set
            {
                //cesMinValue = value;
                SetCalculateValue();
                ExecuteEventHandler();
            }
        }

        private int cesMaxValue { get; set; } = 100;
        [Category("Ces VerticalScrollBar")]
        public int CesMaxValue
        {
            get { return cesMaxValue; }
            set
            {
                cesMaxValue = value;
                SetCalculateValue();
                ExecuteEventHandler();
            }
        }

        [Category("Ces VerticalScrollBar")]
        [Description("When user click on arrows, CesValue inclreases or decreases according to MovingStep.")]
        public int CesMovingStep { get; set; } = 1;

        private bool cesUseScrollValue { get; set; } = false;
        [Category("Ces VerticalScrollBar")]
        public bool CesUseScrollValue
        {
            get { return cesUseScrollValue; }
            set { cesUseScrollValue = value; }
        }

        private Color cesSliderColor { get; set; } = Color.FromArgb(64, 64, 64);
        [Category("Ces VerticalScrollBar")]
        public Color CesSliderColor
        {
            get { return cesSliderColor; }
            set
            {
                cesSliderColor = value;
                pbSlider.BackColor = value;
            }
        }

        private Color cesScrollButton { get; set; } = Color.Gray;
        [Category("Ces VerticalScrollBar")]
        public Color CesScrollButton
        {
            get { return cesScrollButton; }
            set
            {
                cesScrollButton = value;
                btnUp.BackColor = value;
                btnDown.BackColor = value;
            }
        }

        private Color cesScrollButtonMouseOver { get; set; } = Color.DarkGray;
        [Category("Ces VerticalScrollBar")]
        public Color CesScrollButtonMouseOver
        {
            get { return cesScrollButtonMouseOver; }
            set
            {
                cesScrollButtonMouseOver = value;
                btnUp.FlatAppearance.MouseOverBackColor = value;
                btnDown.FlatAppearance.MouseOverBackColor = value;
            }
        }

        private Color cesScrollButtonMouseClick { get; set; } = Color.Gray;
        [Category("Ces VerticalScrollBar")]
        public Color CesScrollButtonMouseClick
        {
            get { return cesScrollButtonMouseClick; }
            set
            {
                cesScrollButtonMouseClick = value;
                btnUp.FlatAppearance.MouseDownBackColor = value;
                btnDown.FlatAppearance.MouseDownBackColor = value;
            }
        }

        private bool cesShowBorder { get; set; } = true;
        [Category("Ces VerticalScrollBar")]
        public bool CesShowBorder
        {
            get { return cesShowBorder; }
            set
            {
                cesShowBorder = value;
                lineLeft.Visible = value;
                lineRight.Visible = value;
            }
        }

        private Color cesBorderColor { get; set; } = Color.Silver;
        [Category("Ces VerticalScrollBar")]
        public Color CesBorderColor
        {
            get { return cesBorderColor; }
            set
            {
                cesBorderColor = value;
                lineLeft.CesLineColor = value;
                lineRight.CesLineColor = value;
            }
        }

        private void pbSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _mouseDown = true;
            _currentMousePosition = e.Location;
        }

        private void pbSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !_mouseDown)
                return;

            if (e.Button == MouseButtons.Left)
                SetSliderPosition(e.Y);
        }

        private void SetSliderPosition(int? newMouseYLocation = null)
        {
            if (newMouseYLocation.HasValue)
                newPosition = pbSlider.Top + (newMouseYLocation.Value - _currentMousePosition.Y);

            if (newPosition < 0)
                newPosition = 0;

            if (newPosition > standard)
                newPosition = standard;

            pbSlider.Top = newPosition;

            //اجرای رویداد لحظه ای تغییرات اسکرول نیز باید توسط کاربر فعال شود
            // تا برنامه منابع را بی مورد مصرف نکند. اگراین ویژگی فعال باشد
            // رویداد تغییرات لحظه ای اجرا خواهد شد
            if (CesUseScrollValue)
                if (CesScrollValue != null)
                    CesScrollValue(this, CalculateValue());
        }

        private void pbSlider_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;

            SetCalculateValue();
            ExecuteEventHandler();
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
        private int CalculateValue()
        {
            int result = (newPosition * CesMaxValue) / standard;
            return result;
        }

        private void SetNewPosition()
        {
            if (CesMaxValue == 0)
                return;

            newPosition = ((standard * CesValue) / CesMaxValue);
        }

        private void ExecuteEventHandler()
        {
            if (CesScrollValueChanged != null)
                CesScrollValueChanged(this, CesValue);

            if (CesValue == CesMinValue && CesScrollMinValue != null)
            {
                CesScrollMinValue(this, CesMinValue);
                return;
            }

            if (CesValue == CesMaxValue && CesScrollMaxValue != null)
            {
                CesScrollMaxValue(this, CesMaxValue);
                return;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            CesValue -= CesMovingStep;
            SetNewPosition();
            SetSliderPosition();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            CesValue += CesMovingStep;
            SetNewPosition();
            SetSliderPosition();
        }

        private void CesVerticalScrollBar_Paint(object sender, PaintEventArgs e)
        {
            ResetValues();
        }

        private void pnlSlider_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
                btnDown.PerformClick();
            else
                btnUp.PerformClick();
        }

        private void CesVerticalScrollBar_SizeChanged(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void ResetValues()
        {
            pbSlider.Left = 0;
            pbSlider.Width = pnlSlider.Width;
            standard = pnlSlider.Height - 20;
            SetNewPosition();
            SetSliderPosition();
        }
    }
}
