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
    public partial class CesTextBox : UserControl
    {
        public CesTextBox()
        {
            InitializeComponent();
            SetTexBoxLocation();
            Redraw();
        }


        private Color cesBackColor { get; set; } = Color.White;
        public Color CesBackColor
        {
            get { return cesBackColor; }
            set
            {
                cesBackColor = value;
                Redraw();
            }
        }


        private Color cesBorderColor { get; set; } = Color.DeepSkyBlue;
        public Color CesBorderColor
        {
            get { return cesBorderColor; }
            set
            {
                cesBorderColor = value;
                Redraw();
            }
        }


        private int cesBorderThickness { get; set; } = 1;
        public int CesBorderThickness
        {
            get { return cesBorderThickness; }
            set
            {
                cesBorderThickness = value;
                SetTexBoxLocation();
                Redraw();
            }
        }


        private int cesBorderRadius { get; set; } = 20;
        public int CesBorderRadius
        {
            get { return cesBorderRadius; }
            set
            {
                cesBorderRadius = value;
                Redraw();
            }
        }


        private Color cesFocusColor { get; set; } = Color.Beige;
        public Color CesFocusColor
        {
            get { return cesFocusColor; }
            set
            {
                cesFocusColor = value;
                Redraw();
            }
        }


        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.EditorBrowsable]
        public TextBox CesTextBoxControl { get { return txtTextBox; } }


        private void CesTextBox_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        private void Redraw()
        {
            using (var g = this.CreateGraphics())
            {
                g.Clear(this.BackColor);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    using (var p = new Pen(cesBorderColor, cesBorderThickness))
                    {
                        // Top-Left Arc
                        gp.AddArc(new Rectangle(
                            (cesBorderThickness / 2) + 1,
                            (cesBorderThickness / 2) + 1,
                            cesBorderRadius,
                            cesBorderRadius),
                            180, 90);

                        // Top line
                        //gp.AddLine(
                        //    cesBorderRadius + (cesBorderThickness / 2),
                        //    (cesBorderThickness / 2) + 1,
                        //    this.Width - cesBorderRadius - (cesBorderThickness / 2),
                        //    (cesBorderThickness / 2) + 1);

                        // Top-Right Arc
                        gp.AddArc(new Rectangle(
                            this.Width - cesBorderRadius - (cesBorderThickness / 2) - 1,
                            (cesBorderThickness / 2) + 1,
                            cesBorderRadius,
                            cesBorderRadius),
                            270, 90);

                        // Right Line
                        //gp.AddLine(
                        //    this.Width - (cesBorderThickness / 2) - 1,
                        //    cesBorderRadius + (cesBorderThickness / 2),
                        //    this.Width - (cesBorderThickness / 2) - 1,
                        //    this.Height - cesBorderRadius - (cesBorderThickness / 2));

                        // Bottom-Right Arc
                        gp.AddArc(new Rectangle(
                            this.Width - CesBorderRadius - (cesBorderThickness / 2) - 1,
                            this.Height - CesBorderRadius - (cesBorderThickness / 2) - 1,
                            cesBorderRadius,
                            cesBorderRadius),
                            0, 90);

                        // Bottom Line
                        //gp.AddLine(
                        //    this.Width - CesBorderRadius - (cesBorderThickness / 2),
                        //    this.Height - (cesBorderThickness / 2) - 1,
                        //    CesBorderRadius + (cesBorderThickness / 2),
                        //    this.Height - (cesBorderThickness / 2) - 1);

                        // Bottom-Left Arc
                        gp.AddArc(new Rectangle(
                            (cesBorderThickness / 2) + 1,
                            this.Height - cesBorderRadius - (cesBorderThickness / 2) - 1,
                            cesBorderRadius,
                            cesBorderRadius),
                            90, 90);

                        // Left Line
                        //gp.AddLine(
                        //    (cesBorderThickness / 2) + 1,
                        //    this.Height - cesBorderRadius - (cesBorderThickness / 2) - 1,
                        //    (cesBorderThickness / 2) + 1,
                        //    cesBorderRadius + (cesBorderRadius / 2) + 1);

                        using (var sb = new SolidBrush(this.txtTextBox.Focused ? cesFocusColor : cesBackColor))
                        {
                            this.txtTextBox.BackColor = this.txtTextBox.Focused ? cesFocusColor : cesBackColor;
                            gp.CloseFigure();
                            g.FillPath(sb, gp);
                        }

                        g.DrawPath(p, gp);
                    }
                }
            }

        }

        private void CesTextBox_Resize(object sender, EventArgs e)
        {
            SetTexBoxLocation();
        }

        private void SetTexBoxLocation()
        {
            this.txtTextBox.Size = new Size(
                this.Width - (cesBorderThickness * 2) - this.Padding.Left - this.Padding.Right,
                this.Height - (cesBorderThickness * 2) - this.Padding.Top - this.Padding.Bottom);

            this.txtTextBox.Location = new Point(
                (this.Width / 2) - (this.txtTextBox.Width / 2),
                (this.Height / 2) - (this.txtTextBox.Height / 2));
        }

        private void CesTextBox_PaddingChanged(object sender, EventArgs e)
        {
            SetTexBoxLocation();
        }

        private void txtTextBox_Enter(object sender, EventArgs e)
        {
            Redraw();
        }

        private void txtTextBox_Leave(object sender, EventArgs e)
        {
            Redraw();
        }
    }
}
