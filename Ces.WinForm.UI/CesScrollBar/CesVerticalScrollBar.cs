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
            standard = this.Height - (20 + 23 + 23);
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

                if(value < CesMinValue)
                {
                    cesValue = CesMinValue;
                    return;
                }

                if(value > CesMaxValue)
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

            //newPosition = pbSlider.Top + (e.Y - _currentMousePosition.Y);

            //if (newPosition < btnUp.Bottom + 1)
            //    newPosition = btnUp.Bottom + 1;

            //if (newPosition > btnDown.Top - 21)
            //    newPosition = btnDown.Top - 21;

            //if (e.Button == MouseButtons.Left)
            //pbSlider.Top = newPosition;

            if (e.Button == MouseButtons.Left)
                SetSliderPosition(e.Y);
        }

        private void SetSliderPosition(int? currentMouseYLocation = null)
        {
            if (currentMouseYLocation.HasValue)
                newPosition = pbSlider.Top + (currentMouseYLocation.Value - _currentMousePosition.Y);

            if (newPosition < btnUp.Bottom + 1)
                newPosition = btnUp.Bottom + 1;

            if (newPosition > btnDown.Top - 21)
                newPosition = btnDown.Top - 21;

            //if (e.Button == MouseButtons.Left)
            pbSlider.Top = newPosition;
        }

        private void pbSlider_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;

            //CesValue = ((newPosition - 23) * CesMaxValue) / standard;

            //if (CesScrollValueChanged != null)
            //    CesScrollValueChanged(this, CesValue);
            CalculateValue();
            ExecuteEventWhenValueChanged();
        }

        private void CalculateValue()
        {
            CesValue = ((newPosition - 23) * CesMaxValue) / standard;
        }

        private void SetNewPosition()
        {
            newPosition = (standard * CesValue) / CesMaxValue;
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
            pbSlider.Left = 1;
            pbSlider.Width = this.Width - 2;
            standard = this.Height - (20 + 23 + 23);
            //CalculateValue();
            SetSliderPosition();
        }
    }
}
