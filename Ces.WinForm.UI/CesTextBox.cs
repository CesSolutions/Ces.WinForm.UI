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
            ArrangeControls();
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
                ArrangeControls();
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


        private bool cesShowTitle { get; set; }
        public bool CesShowTitle
        {
            get { return cesShowTitle; }
            set
            {
                cesShowTitle = value;
                lblTitle.Visible = value;
                ArrangeControls();
            }
        }


        private string cesTitleText { get; set; }
        public string CesTitleText
        {
            get { return cesTitleText; }
            set
            {
                cesTitleText = value;
                lblTitle.Text = value;
            }
        }

        private System.Drawing.ContentAlignment cesTitleAlignment { get; set; }
        public System.Drawing.ContentAlignment CesTitleAlignment
        {
            get { return cesTitleAlignment; }
            set
            {
                cesTitleAlignment = value;
                lblTitle.TextAlign = value;
            }
        }

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.EditorBrowsable]
        public Label CesLabelControl { get { return lblTitle; } }


        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.EditorBrowsable]
        public TextBox CesTextBoxControl { get { return txtTextBox; } }


        private CesTextBoxAlignmentEnum cesTextBoxAlignment { get; set; } =
            CesTextBoxAlignmentEnum.EdgeToCenter;
        public CesTextBoxAlignmentEnum CesTextBoxAlignment
        {
            get { return cesTextBoxAlignment; }
            set
            {
                cesTextBoxAlignment = value;
                ArrangeControls();
            }
        }

        private bool cesAutoHeight { get; set; }
        public bool CesAutoHeight
        {
            get { return cesAutoHeight; }
            set
            {
                cesAutoHeight = value;
                ArrangeControls();
            }
        }

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
                            this.lblTitle.BackColor = this.txtTextBox.Focused ? cesFocusColor : cesBackColor;

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
            ArrangeControls();
        }


        private void ArrangeControls()
        {
            if (cesAutoHeight)
                this.Height = cesShowTitle ?
                    lblTitle.Height + txtTextBox.Height + this.Margin.Top + this.Margin.Bottom + (cesBorderThickness * 4) :
                    txtTextBox.Height + this.Margin.Top + this.Margin.Bottom + (cesBorderThickness * 4);

            if (cesShowTitle)
            {               
                //this.lblTitle.Size = new Size(
                //    this.Width - (cesBorderThickness * 2) - this.Padding.Left - this.Padding.Right,
                //    this.Height - (cesBorderThickness * 2) - this.Padding.Top - this.Padding.Bottom);

                this.lblTitle.Width = this.Width - (cesBorderThickness * 4) - this.Padding.Left - this.Padding.Right;

                if (cesTextBoxAlignment == CesTextBoxAlignmentEnum.CenterToEdge)
                {
                    this.lblTitle.Location = new Point(
                        (this.Width / 2) - (this.lblTitle.Width / 2),
                        (this.Height / 2) - lblTitle.Height - cesBorderThickness);
                }

                if (cesTextBoxAlignment == CesTextBoxAlignmentEnum.EdgeToCenter)
                {
                    this.lblTitle.Location = new Point(
                        (this.Width / 2) - (this.lblTitle.Width / 2),
                        cesBorderThickness * 2);
                }
            }

            //this.txtTextBox.Size = new Size(
            //    this.Width - (cesBorderThickness * 2) - this.Padding.Left - this.Padding.Right,
            //    this.Height - (cesBorderThickness * 2) - this.Padding.Top - this.Padding.Bottom);

            this.txtTextBox.Width = this.Width - (cesBorderThickness * 4) - this.Padding.Left - this.Padding.Right;

            if (cesTextBoxAlignment == CesTextBoxAlignmentEnum.CenterToEdge)
            {
                this.txtTextBox.Location = new Point(
                    (this.Width / 2) - (this.txtTextBox.Width / 2),
                    cesShowTitle ? (this.Height / 2) + cesBorderThickness : (this.Height / 2) - (this.txtTextBox.Height / 2));
            }

            if (cesTextBoxAlignment == CesTextBoxAlignmentEnum.EdgeToCenter)
            {
                this.txtTextBox.Location = new Point(
                    (this.Width / 2) - (this.txtTextBox.Width / 2),
                    cesShowTitle ? this.Height - txtTextBox.Height - (cesBorderThickness * 2) : (this.Height / 2) - (this.txtTextBox.Height / 2));
            }
        }

        private void CesTextBox_PaddingChanged(object sender, EventArgs e)
        {
            ArrangeControls();
        }

        private void txtTextBox_Enter(object sender, EventArgs e)
        {
            Redraw();
        }

        private void txtTextBox_Leave(object sender, EventArgs e)
        {
            Redraw();
        }

        private void CesTextBox_Load(object sender, EventArgs e)
        {

        }
    }

    public enum CesTextBoxAlignmentEnum
    {
        CenterToEdge,
        EdgeToCenter,
    }
}
