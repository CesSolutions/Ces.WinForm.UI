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

        public delegate void CesScrollValueChangedEventHandler(object sender, int e);
        public event CesScrollValueChangedEventHandler CesScrollValueChanged;

        [Category("Ces VerticalScrollBar")]
        public int CesScrollingValue { get; set; }

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
                ExecuteEventWhenValueChanged();
            }
        }

        private int cesMinValue { get; set; }
        [Category("Ces VerticalScrollBar")]
        public int CesMinValue
        {
            get { return cesMinValue; }
            set
            {
                cesMinValue = value;
                CalculateValue();
                ExecuteEventWhenValueChanged();
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
                CalculateValue();
                ExecuteEventWhenValueChanged();
            }
        }

        [Category("Ces VerticalScrollBar")]
        public int CesMovingStep { get; set; } = 5;


        private bool _mouseDown { get; set; }
        private Point _currentMousePosition { get; set; }
        private int newPosition { get; set; }
        private int standard { get; set; }

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
        }

        private void pbSlider_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;

            CalculateValue();
            ExecuteEventWhenValueChanged();
        }

        private void CalculateValue()
        {
            CesValue = (newPosition * CesMaxValue) / standard;
        }

        private void SetNewPosition()
        {
            newPosition = ((standard * CesValue) / CesMaxValue);
        }

        private void ExecuteEventWhenValueChanged()
        {
            if (CesScrollValueChanged != null)
                CesScrollValueChanged(this, CesValue);
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
            pbSlider.Left = 0;
            pbSlider.Width = pnlSlider.Width;
            standard = pnlSlider.Height - 20;
            SetNewPosition();
            SetSliderPosition();
        }

        private void pnlSlider_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
                btnDown.PerformClick();
            else
                btnUp.PerformClick();
        }
    }
}
