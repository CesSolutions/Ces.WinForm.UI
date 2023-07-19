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
            var g = this.CreateGraphics();

            g.Clear(System.Drawing.SystemColors.Control);

            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;


            // Fill path with smooth curve
            using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                // Top-Left Arc
                gp.AddArc(new Rectangle(
                    cesBorderThickness / 2,
                    cesBorderThickness / 2,
                    cesBorderRadius,
                    cesBorderRadius),
                    180, 90);

                // Top line
                //gp.AddLine(
                //    cesBorderRadius + (cesBorderThickness / 2),
                //    cesBorderThickness / 2,
                //    this.Width - cesBorderRadius - (cesBorderThickness / 2),
                //    cesBorderThickness / 2);

                // Top-Right Arc
                gp.AddArc(new Rectangle(
                    this.Width - cesBorderRadius - (cesBorderThickness / 2),
                    cesBorderThickness / 2,
                    cesBorderRadius,
                    cesBorderRadius),
                    270, 90);

                // Right Line
                //gp.AddLine(
                //    this.Width - (cesBorderThickness / 2),
                //    cesBorderRadius + (cesBorderThickness / 2),
                //    this.Width - (cesBorderThickness / 2),
                //    this.Height - cesBorderRadius - (cesBorderThickness / 2));

                // Bottom-Right Arc
                gp.AddArc(new Rectangle(
                    this.Width - cesBorderRadius - (cesBorderThickness / 2),
                    this.Height - cesBorderRadius - (cesBorderThickness / 2),
                    cesBorderRadius,
                    cesBorderRadius),
                    0, 90);

                // Bottom Line
                //gp.AddLine(
                //    this.Width - cesBorderRadius - (cesBorderThickness / 2),
                //    this.Height - (cesBorderThickness / 2),
                //    cesBorderRadius + (cesBorderThickness / 2),
                //    this.Height - (cesBorderThickness / 2));

                // Bottom-Left Arc
                gp.AddArc(new Rectangle(
                    (cesBorderThickness / 2),
                    this.Height - cesBorderRadius - (cesBorderThickness / 2),
                    cesBorderRadius,
                    cesBorderRadius),
                    90, 90);

                // Left Line
                //gp.AddLine(
                //    (cesBorderThickness / 2),
                //    this.Height - cesBorderRadius - (cesBorderThickness / 2),
                //    (cesBorderThickness / 2),
                //    cesBorderRadius + (cesBorderThickness / 2));

                gp.CloseFigure();

                using (var sb = new SolidBrush(
                    string.IsNullOrEmpty(mouse) ? cesMouseDownColor :
                    mouse == "enter" ? cesMouseOverColor : cesMouseDownColor))
                {
                    g.FillPath(sb, gp);
                }

                if (cesBorderVisible)
                    using (var p = new Pen(cesBorderColor, cesBorderThickness))
                    {
                        g.DrawPath(p, gp);
                    }


                var maxWidth = this.Width - (cesBorderThickness * 2) - this.Padding.Left - this.Padding.Right;
                var maxHeight = this.Height - (cesBorderThickness * 2) - this.Padding.Top - this.Padding.Bottom;

                var textSize = g.MeasureString(cesText, cesFont);

                var textLocation = new RectangleF(
                    this.Width - (maxWidth / 2) - (textSize.Width > maxWidth ? maxWidth / 2 : (textSize.Width / 2)) - ((cesBorderThickness * 2) - this.Padding.Left - this.Padding.Right) / 2,
                    this.Height - (maxHeight / 2) - (textSize.Height > maxHeight ? maxHeight / 2 : (textSize.Height / 2)) - ((cesBorderThickness * 2) - this.Padding.Left - this.Padding.Right) / 2,
                    textSize.Width > maxWidth ? maxWidth : textSize.Width,
                    textSize.Height > maxHeight ? maxHeight : textSize.Height);


                using (var sb = new SolidBrush(cesForeColor))
                    g.DrawString(cesText, cesFont, sb, textLocation, StringFormat.GenericDefault);

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
