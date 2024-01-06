using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesButton
{
    [System.ComponentModel.DefaultEvent("Click")]
    public partial class CesRoundedButton : UserControl
    {
        public CesRoundedButton()
        {
            InitializeComponent();

            SetProperty();
            Redraw();
        }

        private System.Drawing.ContentAlignment cesIconAlignment { get; set; }
            = ContentAlignment.MiddleCenter;
        [System.ComponentModel.Category("Ces Rounded Button")]
        public System.Drawing.ContentAlignment CesIconAlignment
        {
            get { return cesIconAlignment; }
            set
            {
                cesIconAlignment = value;
                Redraw();
            }
        }


        private bool cesCircular;
        [System.ComponentModel.Category("Ces Rounded Button")]
        public bool CesCircular
        {
            get { return cesCircular; }
            set
            {
                cesCircular = value;

                if (value)
                {
                    cesBorderRadius = this.Width;
                    this.Size = new Size(this.Width, this.Width);
                }
                else
                {
                    cesBorderRadius = 15;
                }

                Redraw();
            }
        }


        private System.Drawing.ContentAlignment cesTextAlignment { get; set; }
            = ContentAlignment.MiddleCenter;
        [System.ComponentModel.Category("Ces Rounded Button")]
        public System.Drawing.ContentAlignment CesTextAlignment
        {
            get { return cesTextAlignment; }
            set
            {
                cesTextAlignment = value;
                Redraw();
            }
        }


        private bool cesShowIcon { get; set; }
        [System.ComponentModel.Category("Ces Rounded Button")]
        public bool CesShowIcon
        {
            get { return cesShowIcon; }
            set
            {
                cesShowIcon = value;
                Redraw();
            }
        }


        private bool cesShowText { get; set; } = true;
        [System.ComponentModel.Category("Ces Rounded Button")]
        public bool CesShowText
        {
            get { return cesShowText; }
            set
            {
                cesShowText = value;
                Redraw();
            }
        }


        private Image? cesIcon { get; set; }
        [System.ComponentModel.Category("Ces Rounded Button")]
        public Image? CesIcon
        {
            get { return cesIcon; }
            set
            {
                cesIcon = value;
                Redraw();
            }
        }


        private ColorTemplateEnum cesColorTemplate { get; set; }
            = ColorTemplateEnum.Gray;
        [System.ComponentModel.Category("Ces Rounded Button")]
        public ColorTemplateEnum CesColorTemplate
        {
            get { return cesColorTemplate; }
            set
            {
                cesColorTemplate = value;
                SetProperty();
            }
        }


        private Font cesFont { get; set; } =
            new Font(new FontFamily("Segoe UI"), 9, FontStyle.Regular, GraphicsUnit.Pixel);
        [System.ComponentModel.Category("Ces Rounded Button")]
        public Font CesFont
        {
            get { return cesFont; }
            set
            {
                cesFont = value;
                Redraw();
            }
        }


        private string cesText { get; set; } = "CesButton";
        [System.ComponentModel.Category("Ces Rounded Button")]
        public string CesText
        {
            get { return cesText; }
            set
            {
                cesText = value;
                Redraw();
            }
        }


        private Color cesForeColor { get; set; }
        [System.ComponentModel.Category("Ces Rounded Button")]
        public Color CesForeColor
        {
            get { return cesForeColor; }
            set
            {
                cesForeColor = value;
                Redraw();
            }
        }


        private Color cesBackColor { get; set; }
        [System.ComponentModel.Category("Ces Rounded Button")]
        public Color CesBackColor
        {
            get { return cesBackColor; }
            set
            {
                cesBackColor = value;
                Redraw();
            }
        }


        private Color cesMouseOverColor { get; set; }
        [System.ComponentModel.Category("Ces Rounded Button")]
        public Color CesMouseOverColor
        {
            get { return cesMouseOverColor; }
            set
            {
                cesMouseOverColor = value;
                Redraw();
            }
        }


        private Color cesMouseDownColor { get; set; }
        [System.ComponentModel.Category("Ces Rounded Button")]
        public Color CesMouseDownColor
        {
            get { return cesMouseDownColor; }
            set
            {
                cesMouseDownColor = value;
                Redraw();
            }
        }


        private Color cesBorderColor { get; set; }
        [System.ComponentModel.Category("Ces Rounded Button")]
        public Color CesBorderColor
        {
            get { return cesBorderColor; }
            set
            {
                cesBorderColor = value;
                Redraw();
            }
        }


        private bool cesBorderVisible { get; set; }
        [System.ComponentModel.Category("Ces Rounded Button")]
        public bool CesBorderVisible
        {
            get { return cesBorderVisible; }
            set
            {
                cesBorderVisible = value;

                if (value)
                {
                    this.Padding = new Padding(all: cesBorderThickness);
                }
                else
                {
                    this.Padding = new Padding(all: 0);
                }

                Redraw();
            }
        }


        private int cesBorderThickness { get; set; } = 1;
        [System.ComponentModel.Category("Ces Rounded Button")]
        public int CesBorderThickness
        {
            get { return cesBorderThickness; }
            set
            {
                cesBorderThickness = value;
                this.Padding = new Padding(all: value);
                Redraw();
            }
        }


        private int cesBorderRadius { get; set; } = 15;
        [System.ComponentModel.Category("Ces Rounded Button")]
        public int CesBorderRadius
        {
            get { return cesBorderRadius; }
            set
            {
                cesBorderRadius = value;
                Redraw();
            }
        }


        // Methods


        private void SetProperty()
        {
            var temp = Ces.WinForm.UI.CesButton.CesButtonOptions.CesButtonColorTemplate.FirstOrDefault(x => x.Key == cesColorTemplate);

            if (temp.Value == null || temp.Key == ColorTemplateEnum.None)
                return;

            cesBackColor = temp.Value.NormalColor;
            cesBorderColor = temp.Value.BorderColor;
            cesMouseOverColor = temp.Value.MouseOverColor;
            cesMouseDownColor = temp.Value.MouseDownColor;
            cesForeColor = temp.Value.TextColor;

            Redraw();
        }

        private void CesRoundedButton_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        private void Redraw(string? mouse = null)
        {
            if (this.IsDisposed)
                return;

            using (var g = this.CreateGraphics())
            {
                g.Clear(this.BackColor);

                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;


                if (CesCircular)
                {
                    using (var sbCircle = new SolidBrush(
                        string.IsNullOrEmpty(mouse) ? CesBackColor :
                        mouse == "enter" ? CesMouseOverColor : CesMouseDownColor))
                    {
                        g.FillEllipse(sbCircle, new Rectangle(1, 1, this.Width - 2, this.Height - 2));
                    }

                    if (CesBorderVisible)
                        using (var pCircle = new Pen(CesBorderColor, CesBorderThickness))
                        {
                            g.DrawEllipse(pCircle, new Rectangle(1, 1, this.Width - 2, this.Height - 2));
                        }
                }
                else
                {
                    // Draw Border
                    using (var gpBorder = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        // Top-Left Arc
                        gpBorder.AddArc(new Rectangle(
                            CesBorderThickness / 2,
                            CesBorderThickness / 2,
                            CesBorderRadius,
                            CesBorderRadius),
                            180, 90);

                        // Top-Right Arc
                        gpBorder.AddArc(new Rectangle(
                            this.Width - CesBorderRadius - (CesBorderThickness / 2),
                            CesBorderThickness / 2,
                            CesBorderRadius,
                            CesBorderRadius),
                            270, 90);

                        // Bottom-Right Arc
                        gpBorder.AddArc(new Rectangle(
                            this.Width - CesBorderRadius - (CesBorderThickness / 2),
                            this.Height - CesBorderRadius - (CesBorderThickness / 2),
                            CesBorderRadius,
                            CesBorderRadius),
                            0, 90);

                        // Bottom-Left Arc
                        gpBorder.AddArc(new Rectangle(
                            (cesBorderThickness / 2),
                            this.Height - CesBorderRadius - (CesBorderThickness / 2),
                            CesBorderRadius,
                            CesBorderRadius),
                            90, 90);

                        gpBorder.CloseFigure();

                        using (var sb = new SolidBrush(
                            string.IsNullOrEmpty(mouse) ? CesBackColor :
                            mouse == "enter" ? CesMouseOverColor : CesMouseDownColor))
                        {
                            g.FillPath(sb, gpBorder);
                        }

                        if (cesBorderVisible)
                            using (var p = new Pen(CesBorderColor, CesBorderThickness))
                                g.DrawPath(p, gpBorder);

                    }
                }

                int iconAndTextOffsetFromEdge = 5;

                // Draw Icon
                if (CesShowIcon && CesIcon != null)
                {
                    RectangleF iconDestinationRect = new RectangleF();

                    if (CesIconAlignment == ContentAlignment.TopLeft)
                    {
                        iconDestinationRect = new RectangleF(
                            iconAndTextOffsetFromEdge,
                            iconAndTextOffsetFromEdge,
                            CesIcon.Width,
                            CesIcon.Height);
                    }

                    if (CesIconAlignment == ContentAlignment.TopCenter)
                    {
                        iconDestinationRect = new RectangleF(
                            (this.Width / 2) - (CesIcon.Width / 2),
                            iconAndTextOffsetFromEdge,
                            CesIcon.Width,
                            CesIcon.Height);
                    }

                    if (CesIconAlignment == ContentAlignment.TopRight)
                    {
                        iconDestinationRect = new RectangleF(
                            this.Width - CesIcon.Width - iconAndTextOffsetFromEdge,
                            iconAndTextOffsetFromEdge,
                            CesIcon.Width,
                            CesIcon.Height);
                    }

                    if (CesIconAlignment == ContentAlignment.MiddleLeft)
                    {
                        iconDestinationRect = new RectangleF(
                            iconAndTextOffsetFromEdge,
                            (this.Height / 2) - (CesIcon.Height / 2),
                            CesIcon.Width,
                            CesIcon.Height);
                    }

                    if (CesIconAlignment == ContentAlignment.MiddleRight)
                    {
                        iconDestinationRect = new RectangleF(
                            this.Width - CesIcon.Width - iconAndTextOffsetFromEdge,
                            (this.Height / 2) - (CesIcon.Height / 2),
                            CesIcon.Width,
                            CesIcon.Height);
                    }

                    if (CesIconAlignment == ContentAlignment.MiddleCenter)
                    {
                        iconDestinationRect = new RectangleF(
                            (this.Width / 2) - (CesIcon.Width / 2),
                            (this.Height / 2) - (CesIcon.Height / 2),
                            CesIcon.Width,
                            CesIcon.Height);
                    }

                    if (CesIconAlignment == ContentAlignment.BottomLeft)
                    {
                        iconDestinationRect = new RectangleF(
                            iconAndTextOffsetFromEdge,
                            this.Height - CesIcon.Height - iconAndTextOffsetFromEdge,
                            CesIcon.Width,
                            CesIcon.Height);
                    }

                    if (CesIconAlignment == ContentAlignment.BottomCenter)
                    {
                        iconDestinationRect = new RectangleF(
                            (this.Width / 2) - (CesIcon.Width / 2),
                            this.Height - CesIcon.Height - iconAndTextOffsetFromEdge,
                            CesIcon.Width,
                            CesIcon.Height);
                    }

                    if (CesIconAlignment == ContentAlignment.BottomRight)
                    {
                        iconDestinationRect = new RectangleF(
                            this.Width - CesIcon.Width - iconAndTextOffsetFromEdge,
                            this.Height - CesIcon.Height - iconAndTextOffsetFromEdge,
                            CesIcon.Width,
                            CesIcon.Height);
                    }

                    g.DrawImage(
                        CesIcon,
                        iconDestinationRect,
                        new RectangleF(0, 0, CesIcon.Width, CesIcon.Height),
                        GraphicsUnit.Pixel);
                }

                if (CesShowText)
                {
                    var maxWidth = this.Width - (CesBorderThickness * 2) - this.Padding.Left - this.Padding.Right;
                    var maxHeight = this.Height - (CesBorderThickness * 2) - this.Padding.Top - this.Padding.Bottom;

                    var textSize = g.MeasureString(cesText, cesFont);

                    var textLocation = new RectangleF(
                        this.Width - (maxWidth / 2) - (textSize.Width > maxWidth ? maxWidth / 2 : (textSize.Width / 2)) - ((CesBorderThickness * 2) - this.Padding.Left - this.Padding.Right) / 2,
                        this.Height - (maxHeight / 2) - (textSize.Height > maxHeight ? maxHeight / 2 : (textSize.Height / 2)) - ((CesBorderThickness * 2) - this.Padding.Left - this.Padding.Right) / 2,
                        textSize.Width > maxWidth ? maxWidth : textSize.Width,
                        textSize.Height > maxHeight ? maxHeight : textSize.Height);

                    RectangleF textRect = new RectangleF();

                    if (CesTextAlignment == ContentAlignment.TopLeft)
                    {
                        textRect = new RectangleF(
                            0 + (CesShowIcon && CesIconAlignment == ContentAlignment.TopLeft ? CesIcon.Width : 0) + iconAndTextOffsetFromEdge,
                            0 + iconAndTextOffsetFromEdge,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (CesTextAlignment == ContentAlignment.TopCenter)
                    {
                        textRect = new RectangleF(
                            (this.Width / 2) - (textSize.Width / 2),
                            0 + iconAndTextOffsetFromEdge,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (CesTextAlignment == ContentAlignment.TopRight)
                    {
                        textRect = new RectangleF(
                            this.Width - textSize.Width - (CesShowIcon && CesIconAlignment == ContentAlignment.TopRight ? CesIcon.Width : 0) - iconAndTextOffsetFromEdge,
                            0 + iconAndTextOffsetFromEdge,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (CesTextAlignment == ContentAlignment.MiddleLeft)
                    {
                        textRect = new RectangleF(
                            0 + (CesShowIcon && CesIconAlignment == ContentAlignment.MiddleLeft ? CesIcon.Width : 0) + iconAndTextOffsetFromEdge,
                            (this.Height / 2) - (textSize.Height / 2),
                            textSize.Width,
                            textSize.Height);
                    }

                    if (CesTextAlignment == ContentAlignment.MiddleRight)
                    {
                        textRect = new RectangleF(
                            this.Width - textSize.Width - (CesShowIcon && CesIconAlignment == ContentAlignment.MiddleRight ? CesIcon.Width : 0) - iconAndTextOffsetFromEdge,
                            (this.Height / 2) - (textSize.Height / 2),
                            textSize.Width,
                            textSize.Height);
                    }

                    if (CesTextAlignment == ContentAlignment.MiddleCenter)
                    {
                        textRect = new RectangleF(
                            (this.Width / 2) - (textSize.Width / 2),
                            (this.Height / 2) - (textSize.Height / 2),
                            textSize.Width,
                            textSize.Height);
                    }

                    if (CesTextAlignment == ContentAlignment.BottomLeft)
                    {
                        textRect = new RectangleF(
                            0 + (CesShowIcon && CesIconAlignment == ContentAlignment.BottomLeft ? CesIcon.Width : 0) + iconAndTextOffsetFromEdge,
                            this.Height - textSize.Height - iconAndTextOffsetFromEdge,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (CesTextAlignment == ContentAlignment.BottomCenter)
                    {
                        textRect = new RectangleF(
                            (this.Width / 2) - (textSize.Width / 2),
                            this.Height - textSize.Height - iconAndTextOffsetFromEdge,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (CesTextAlignment == ContentAlignment.BottomRight)
                    {
                        textRect = new RectangleF(
                            this.Width - textSize.Width - (CesShowIcon && CesIconAlignment == ContentAlignment.BottomRight ? CesIcon.Width : 0) - iconAndTextOffsetFromEdge,
                            this.Height - textSize.Height - iconAndTextOffsetFromEdge,
                            textSize.Width,
                            textSize.Height);
                    }

                    using (var sbText = new SolidBrush(CesForeColor))
                        g.DrawString(cesText, cesFont, sbText, textRect, StringFormat.GenericDefault);
                }
            }
        }

        private void CesRounded_MouseDown(object sender, MouseEventArgs e)
        {
            Redraw("down");
        }

        private void CesRoundedButton_MouseEnter(object sender, EventArgs e)
        {
            Redraw("enter");
        }

        private void CesRounded_MouseLeave(object sender, EventArgs e)
        {
            Redraw(null);
        }

        private void lblLabel_MouseEnter(object sender, EventArgs e)
        {
            Redraw("enter");
        }

        private void lblLabel_MouseDown(object sender, MouseEventArgs e)
        {
            Redraw("down");
        }

        private void lblLabel_MouseLeave(object sender, EventArgs e)
        {
            Redraw(null);
        }

        private void CesRoundedButton_MouseUp(object sender, MouseEventArgs e)
        {
            Redraw("enter");
        }

        private void CesRoundedButton_Resize(object sender, EventArgs e)
        {
            if (CesCircular)
            {
                this.Height = this.Width;
                CesBorderRadius = this.Width;
            }
        }
    }
}
