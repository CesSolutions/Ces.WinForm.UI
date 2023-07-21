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

            _template = new Dictionary<ColorTemplateEnum, TemplateProperty>();

            _template.Add(ColorTemplateEnum.Black, new TemplateProperty { TextColor = Color.White, NormalColor = Color.Black, MouseOverColor = Color.FromArgb(64, 64, 64), MouseDownColor = Color.Black, BorderColor = Color.Black });
            _template.Add(ColorTemplateEnum.Dark, new TemplateProperty { TextColor = Color.White, NormalColor = Color.FromArgb(64, 64, 64), MouseOverColor = Color.Gray, MouseDownColor = Color.FromArgb(64, 64, 64), BorderColor = Color.Black });
            _template.Add(ColorTemplateEnum.Gray, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Gray, MouseOverColor = Color.DarkGray, MouseDownColor = Color.Gray, BorderColor = Color.FromArgb(64, 64, 64) });
            _template.Add(ColorTemplateEnum.Green, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.MediumSeaGreen, MouseOverColor = Color.DarkSeaGreen, MouseDownColor = Color.MediumSeaGreen, BorderColor = Color.DarkGreen });
            _template.Add(ColorTemplateEnum.Blue, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.CornflowerBlue, MouseOverColor = Color.LightSteelBlue, MouseDownColor = Color.CornflowerBlue, BorderColor = Color.MediumBlue });
            _template.Add(ColorTemplateEnum.Red, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Tomato, MouseOverColor = Color.Salmon, MouseDownColor = Color.Tomato, BorderColor = Color.Firebrick });
            _template.Add(ColorTemplateEnum.Orange, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Orange, MouseOverColor = Color.SandyBrown, MouseDownColor = Color.Orange, BorderColor = Color.Chocolate });
            _template.Add(ColorTemplateEnum.Yellow, new TemplateProperty { TextColor = Color.Black, NormalColor = Color.Khaki, MouseOverColor = Color.PaleGoldenrod, MouseDownColor = Color.Khaki, BorderColor = Color.DarkKhaki });

            SetProperty();
            Redraw();
        }

        private IDictionary<ColorTemplateEnum, TemplateProperty> _template;


        private System.Drawing.ContentAlignment cesIconAlignment { get; set; }
            = ContentAlignment.MiddleCenter;
        public System.Drawing.ContentAlignment CesIconAlignment
        {
            get { return cesIconAlignment; }
            set
            {
                cesIconAlignment = value;
                Redraw();
            }
        }

        private System.Drawing.ContentAlignment cesTextAlignment { get; set; }
            = ContentAlignment.MiddleCenter;
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
        public Image? CesIcon
        {
            get { return cesIcon; }
            set
            {
                cesIcon = value;
                Redraw();
            }
        }

        private ColorTemplateEnum cesColorTemplate { get; set; } = ColorTemplateEnum.Gray;
        public ColorTemplateEnum CesColorTemplate
        {
            get { return cesColorTemplate; }
            set
            {
                cesColorTemplate = value;
                SetProperty();
            }
        }


        private void SetProperty()
        {
            var temp = _template.FirstOrDefault(x => x.Key == cesColorTemplate);

            if (temp.Value == null)
                return;

            cesBackColor = temp.Value.NormalColor;
            cesBorderColor = temp.Value.BorderColor;
            cesMouseOverColor = temp.Value.MouseOverColor;
            cesMouseDownColor = temp.Value.MouseDownColor;
            cesForeColor = temp.Value.TextColor;

            Redraw();
        }


        private Font cesFont { get; set; } =
            new Font(new FontFamily("tahoma"), 15, FontStyle.Regular, GraphicsUnit.Pixel);
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
        public int CesBorderRadius
        {
            get { return cesBorderRadius; }
            set
            {
                cesBorderRadius = value;
                Redraw();
            }
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
                g.Clear(System.Drawing.SystemColors.Control);

                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;


                // Fill path
                using (var gpBorder = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    // Top-Left Arc
                    gpBorder.AddArc(new Rectangle(
                        cesBorderThickness / 2,
                        cesBorderThickness / 2,
                        cesBorderRadius,
                        cesBorderRadius),
                        180, 90);

                    // Top-Right Arc
                    gpBorder.AddArc(new Rectangle(
                        this.Width - cesBorderRadius - (cesBorderThickness / 2),
                        cesBorderThickness / 2,
                        cesBorderRadius,
                        cesBorderRadius),
                        270, 90);

                    // Bottom-Right Arc
                    gpBorder.AddArc(new Rectangle(
                        this.Width - cesBorderRadius - (cesBorderThickness / 2),
                        this.Height - cesBorderRadius - (cesBorderThickness / 2),
                        cesBorderRadius,
                        cesBorderRadius),
                        0, 90);

                    // Bottom-Left Arc
                    gpBorder.AddArc(new Rectangle(
                        (cesBorderThickness / 2),
                        this.Height - cesBorderRadius - (cesBorderThickness / 2),
                        cesBorderRadius,
                        cesBorderRadius),
                        90, 90);

                    gpBorder.CloseFigure();

                    using (var sb = new SolidBrush(
                        string.IsNullOrEmpty(mouse) ? cesMouseDownColor :
                        mouse == "enter" ? cesMouseOverColor : cesMouseDownColor))
                    {
                        g.FillPath(sb, gpBorder);
                    }

                    if (cesBorderVisible)
                        using (var p = new Pen(cesBorderColor, cesBorderThickness))
                        {
                            g.DrawPath(p, gpBorder);
                        }
                }


                // Draw Icon
                if (cesShowIcon)
                {
                    RectangleF iconDestinationRect = new RectangleF();

                    if (cesIconAlignment == ContentAlignment.TopLeft)
                    {
                        iconDestinationRect = new RectangleF(
                            0,
                            0,
                            cesIcon.Width,
                            cesIcon.Height);
                    }

                    if (cesIconAlignment == ContentAlignment.TopCenter)
                    {
                        iconDestinationRect = new RectangleF(
                            (this.Width / 2) - (cesIcon.Width / 2),
                            0,
                            cesIcon.Width,
                            cesIcon.Height);
                    }

                    if (cesIconAlignment == ContentAlignment.TopRight)
                    {
                        iconDestinationRect = new RectangleF(
                            this.Width - cesIcon.Width,
                            0,
                            cesIcon.Width,
                            cesIcon.Height);
                    }

                    if (cesIconAlignment == ContentAlignment.MiddleLeft)
                    {
                        iconDestinationRect = new RectangleF(
                            0,
                            (this.Height / 2) - (cesIcon.Height / 2),
                            cesIcon.Width,
                            cesIcon.Height);
                    }

                    if (cesIconAlignment == ContentAlignment.MiddleRight)
                    {
                        iconDestinationRect = new RectangleF(
                            this.Width - cesIcon.Width,
                            (this.Height / 2) - (cesIcon.Height / 2),
                            cesIcon.Width,
                            cesIcon.Height);
                    }

                    if (cesIconAlignment == ContentAlignment.MiddleCenter)
                    {
                        iconDestinationRect = new RectangleF(
                            (this.Width / 2) - (cesIcon.Width / 2),
                            (this.Height / 2) - (cesIcon.Height / 2),
                            cesIcon.Width,
                            cesIcon.Height);
                    }

                    if (cesIconAlignment == ContentAlignment.BottomLeft)
                    {
                        iconDestinationRect = new RectangleF(
                            0,
                            this.Height - cesIcon.Height,
                            cesIcon.Width,
                            cesIcon.Height);
                    }

                    if (cesIconAlignment == ContentAlignment.BottomCenter)
                    {
                        iconDestinationRect = new RectangleF(
                            (this.Width / 2) - (cesIcon.Width / 2),
                            this.Height - cesIcon.Height,
                            cesIcon.Width,
                            cesIcon.Height);
                    }

                    if (cesIconAlignment == ContentAlignment.BottomRight)
                    {
                        iconDestinationRect = new RectangleF(
                            this.Width - cesIcon.Width,
                            this.Height - cesIcon.Height,
                            cesIcon.Width,
                            cesIcon.Height);
                    }

                    g.DrawImage(
                        cesIcon,
                        iconDestinationRect,
                        new RectangleF(0, 0, cesIcon.Width, cesIcon.Height),
                        GraphicsUnit.Pixel);
                }

                if (cesShowText)
                {
                    var maxWidth = this.Width - (cesBorderThickness * 2) - this.Padding.Left - this.Padding.Right;
                    var maxHeight = this.Height - (cesBorderThickness * 2) - this.Padding.Top - this.Padding.Bottom;

                    var textSize = g.MeasureString(cesText, cesFont);

                    var textLocation = new RectangleF(
                        this.Width - (maxWidth / 2) - (textSize.Width > maxWidth ? maxWidth / 2 : (textSize.Width / 2)) - ((cesBorderThickness * 2) - this.Padding.Left - this.Padding.Right) / 2,
                        this.Height - (maxHeight / 2) - (textSize.Height > maxHeight ? maxHeight / 2 : (textSize.Height / 2)) - ((cesBorderThickness * 2) - this.Padding.Left - this.Padding.Right) / 2,
                        textSize.Width > maxWidth ? maxWidth : textSize.Width,
                        textSize.Height > maxHeight ? maxHeight : textSize.Height);

                    RectangleF textRect = new RectangleF();

                    if (cesTextAlignment == ContentAlignment.TopLeft)
                    {
                        textRect = new RectangleF(
                            0 + (cesShowIcon && cesIconAlignment == ContentAlignment.TopLeft ? cesIcon.Width : 0),
                            0,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (cesTextAlignment == ContentAlignment.TopCenter)
                    {
                        textRect = new RectangleF(
                            (this.Width / 2) - (textSize.Width / 2),
                            0,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (cesTextAlignment == ContentAlignment.TopRight)
                    {
                        textRect = new RectangleF(
                            this.Width - textSize.Width - (cesShowIcon && cesIconAlignment == ContentAlignment.TopRight ? cesIcon.Width : 0),
                            0,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (cesTextAlignment == ContentAlignment.MiddleLeft)
                    {
                        textRect = new RectangleF(
                            0 + (cesShowIcon && cesIconAlignment == ContentAlignment.MiddleLeft ? cesIcon.Width : 0),
                            (this.Height / 2) - (textSize.Height / 2),
                            textSize.Width,
                            textSize.Height);
                    }

                    if (cesTextAlignment == ContentAlignment.MiddleRight)
                    {
                        textRect = new RectangleF(
                            this.Width - textSize.Width - (cesShowIcon && cesIconAlignment == ContentAlignment.MiddleRight ? cesIcon.Width : 0),
                            (this.Height / 2) - (textSize.Height / 2),
                            textSize.Width,
                            textSize.Height);
                    }

                    if (cesTextAlignment == ContentAlignment.MiddleCenter)
                    {
                        textRect = new RectangleF(
                            (this.Width / 2) - (textSize.Width / 2),
                            (this.Height / 2) - (textSize.Height / 2),
                            textSize.Width,
                            textSize.Height);
                    }

                    if (cesTextAlignment == ContentAlignment.BottomLeft)
                    {
                        textRect = new RectangleF(
                            0 + (cesShowIcon && cesIconAlignment == ContentAlignment.BottomLeft ? cesIcon.Width : 0),
                            this.Height - textSize.Height,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (cesTextAlignment == ContentAlignment.BottomCenter)
                    {
                        textRect = new RectangleF(
                            (this.Width / 2) - (textSize.Width / 2),
                            this.Height - textSize.Height,
                            textSize.Width,
                            textSize.Height);
                    }

                    if (cesTextAlignment == ContentAlignment.BottomRight)
                    {
                        textRect = new RectangleF(
                            this.Width - textSize.Width - (cesShowIcon && cesIconAlignment == ContentAlignment.BottomRight ? cesIcon.Width : 0),
                            this.Height - textSize.Height,
                            textSize.Width,
                            textSize.Height);
                    }

                    using (var sbText = new SolidBrush(cesForeColor))
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
    }
}
