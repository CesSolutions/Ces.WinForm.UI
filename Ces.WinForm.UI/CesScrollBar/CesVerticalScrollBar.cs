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

            pbSlider.Top = pbUp.Bottom + 1;
        }

        public delegate void CesScrollValueChangedEventHandler(object sender, int e);
        public event CesScrollValueChangedEventHandler CesScrollValueChanged;

        public int CesScrollingValue { get; set; }
        public int CesValue { get; set; }
        public int CesMinValue { get; set; }
        private int cesMaxValue { get; set; } = 100;
        public int CesMaxValue
        {
            get { return cesMaxValue; }
            set
            {
                cesMaxValue = value;
            }
        }
        public int CesMovingStep { get; set; } = 5;


        private bool _mouseDown { get; set; }
        private Point _currentMousePosition { get; set; }
        private int newPosition { get; set; }


        private void pbSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _mouseDown = true;
            _currentMousePosition = e.Location;
        }

        private void pbSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseDown)
                return;

            newPosition = pbSlider.Top + (e.Y - _currentMousePosition.Y);

            if (newPosition < 1)
                newPosition = 1;

            if (newPosition > this.Height - 31)
                newPosition = this.Height - 31;

            if (e.Button == MouseButtons.Left)
                pbSlider.Top = newPosition;
        }

        private void pbSlider_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;

            CesValue = (newPosition * CesMaxValue) / (this.Height - 32);

            if (CesScrollValueChanged != null)
                CesScrollValueChanged(this, CesValue);
        }

        private void CesVerticalScrollBar_Resize(object sender, EventArgs e)
        {
            pbSlider.Left = 1;
            pbSlider.Width = this.Width - 2;
        }
    }
}
