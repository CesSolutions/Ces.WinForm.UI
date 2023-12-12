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
    [DefaultEvent("Click")]
    public partial class CesToggleButton : UserControl
    {
        public CesToggleButton()
        {
            InitializeComponent();
        }

        private Color cesActiveColor { get; set; } = Color.DodgerBlue;
        [Category("Ces ToggleButton")]
        public Color CesActiveColor
        {
            get { return cesActiveColor; }
            set
            {
                cesActiveColor = value;
                this.Invalidate();
            }
        }

        private Color cesInactiveColor { get; set; } = Color.LightGray;
        [Category("Ces ToggleButton")]
        public Color CesInactiveColor
        {
            get { return cesInactiveColor; }
            set
            {
                cesInactiveColor = value;
                this.Invalidate();
            }
        }

        private Color cesToggleActiveColor { get; set; } = Color.White;
        [Category("Ces ToggleButton")]
        public Color CesToggleActiveColor
        {
            get { return cesToggleActiveColor; }
            set
            {
                cesToggleActiveColor = value;
                this.Invalidate();
            }
        }

        private Color cesToggleInactiveColor { get; set; } = Color.DarkGray;
        [Category("Ces ToggleButton")]
        public Color CesToggleInactiveColor
        {
            get { return cesToggleInactiveColor; }
            set
            {
                cesToggleInactiveColor = value;
                this.Invalidate();
            }
        }

        private bool cesToggle { get; set; }
        [Category("Ces ToggleButton")]
        public bool CesToggle
        {
            get { return cesToggle; }
            set
            {
                cesToggle = value;
                this.Invalidate();
            }
        }

        private string cesToggleActiveText { get; set; } = "ON";
        [Category("Ces ToggleButton")]
        public string CesToggleActiveText
        {
            get { return cesToggleActiveText; }
            set
            {
                cesToggleActiveText = value;
                this.Invalidate();
            }
        }

        private string cesToggleInactiveText { get; set; } = "OFF";
        [Category("Ces ToggleButton")]
        public string CesToggleInactiveText
        {
            get { return cesToggleInactiveText; }
            set
            {
                cesToggleInactiveText = value;
                this.Invalidate();
            }
        }

        private bool cesShowToggleText { get; set; } = true;
        [Category("Ces ToggleButton")]
        public bool CessShowToggleText
        {
            get { return cesShowToggleText; }
            set
            {
                cesShowToggleText = value;
                this.Invalidate();
            }
        }

        private void CesToggleButton_Paint(object sender, PaintEventArgs e)
        {
            using Graphics g = this.CreateGraphics();
            using SolidBrush backgroundBrush = new SolidBrush(CesToggle ? CesActiveColor : CesInactiveColor);
            using SolidBrush toggleBrush = new SolidBrush(CesToggle ? CesToggleActiveColor : CesToggleInactiveColor);
            float offset = 1f;

            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw background
            g.FillEllipse(
                backgroundBrush,
                new RectangleF(
                    offset,
                    offset,
                    this.Height - (2 * offset),
                    this.Height - (2 * offset)));

            g.FillEllipse(
                backgroundBrush,
                new RectangleF(
                    this.Width - offset,
                    offset,
                    -(this.Height - (2 * offset)),
                    this.Height - (2 * offset)));

            g.FillRectangle(
                backgroundBrush,
                new RectangleF(
                    (this.Height / 2) + offset,
                    offset,
                    this.Width - this.Height - (2 * offset),
                    this.Height - (2 * offset)));

            //Draw toggle circle
            if (CesToggle)
                g.FillEllipse(
                    toggleBrush,
                    new RectangleF(
                        this.Width - this.Height + 4,
                        4,
                        this.Height - 8,
                        this.Height - 8));
            else
                g.FillEllipse(
                    toggleBrush,
                    new RectangleF(
                        4,
                        4,
                        this.Height - 8,
                        this.Height - 8));

            if (!CessShowToggleText)
                return;

            using SolidBrush textBrush = new SolidBrush(CesToggle ? this.ForeColor:Color.Gray);
            var textSize = g.MeasureString(CesToggle ? CesToggleActiveText : CesToggleInactiveText, this.Font);


            g.DrawString(
                CesToggle ? CesToggleActiveText : CesToggleInactiveText,
                this.Font,
                textBrush,
                new PointF(
                    CesToggle ? (this.Height / 2) : (this.Width - textSize.Width - (this.Height / 2)),
                    (this.Height / 2) - (textSize.Height / 2) + 1));
        }

        private void CesToggleButton_Click(object sender, EventArgs e)
        {
            CesToggle = !CesToggle;
        }

        public override Font Font 
        {
            get {return base.Font; }
            set
            { 
                base.Font = value;
            }
        }
    }
}
