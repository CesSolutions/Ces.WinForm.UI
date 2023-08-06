using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.Infrastructure
{
    public enum CesTitlePositionEnum
    {
        Top,
        Right,
        Bottom,
        Left,
    }

    /// <summary>
    /// Title content can be text or image
    /// </summary>
    public enum CesTitleContentAlignmentEnum
    {
        Left,
        Center,
        Right,
    }

    public class BorderOptions : IBorderOptions
    {
        public int initialControlHeight { get; set; }
        public SizeF _titleTextSize { get; set; }
        public Control CesControl { get; set; }
        public bool CesHasNotification { get; set; }
        public Color CesNotificationColor { get; set; }
        public bool CesAutoHeight { get; set; }
        public Color CesBackColor { get; set; }
        public Color CesBorderColor { get; set; }
        public int CesBorderThickness { get; set; }
        public int CesBorderRadius { get; set; }
    }


    public interface IBorderOptions
    {
        public int initialControlHeight { get; set; }
        public SizeF _titleTextSize { get; set; }
        public Control CesControl { get; set; }


        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesHasNotification { get; set; }


        [System.ComponentModel.Category("CesTextBox Title")]
        public Color CesNotificationColor { get; set; }


        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesAutoHeight { get; set; }


        [System.ComponentModel.Category("CesTextBox")]
        public Color CesBackColor { get; set; }


        [System.ComponentModel.Category("CesTextBox")]
        public Color CesBorderColor { get; set; }


        [System.ComponentModel.Category("CesTextBox")]
        public int CesBorderThickness { get; set; }


        [System.ComponentModel.Category("CesTextBox")]
        public int CesBorderRadius { get; set; }
    }


    public class TitleOptions
    {
        private bool cesShowIcon { get; set; }
        [System.ComponentModel.Category("CesTextBox Icon")]
        public bool CesShowIcon
        {
            get { return cesShowIcon; }
            set
            {
                cesShowIcon = value;
                //Redraw();
            }
        }


        private Image? cesIcon { get; set; }
        [System.ComponentModel.Category("CesTextBox Icon")]
        public Image? CesIcon
        {
            get { return cesIcon; }
            set
            {
                cesIcon = value;
                //Redraw();
            }
        }

        private bool cesShowTitle { get; set; }
        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesShowTitle
        {
            get { return cesShowTitle; }
            set
            {
                cesShowTitle = value;
                //ArrangeControls();
            }
        }

        private bool cesTitleBackground { get; set; } = true;
        [System.ComponentModel.Category("CesTextBox Icon")]
        public bool CesTitleBackground
        {
            get
            {
                return cesTitleBackground;
            }
            set
            {
                cesTitleBackground = value;
                //Redraw();
            }
        }


        private Font cesTitleFont { get; set; }
        public Font CesTitleFont
        {
            get { return cesTitleFont; }
            set
            {
                cesTitleFont = value;
                //Redraw();
            }
        }


        private Color cesTitleTextColor { get; set; } = Color.White;
        [System.ComponentModel.Category("CesTextBox Title")]
        public Color CesTitleTextColor
        {
            get { return cesTitleTextColor; }
            set
            {
                cesTitleTextColor = value;
                //Redraw();
            }
        }


        private string cesTitleText { get; set; } = "Enter Value";
        [System.ComponentModel.Category("CesTextBox Title")]
        public string CesTitleText
        {
            get { return cesTitleText; }
            set
            {
                cesTitleText = value;
                //ArrangeControls();
            }
        }


        private CesTitlePositionEnum cesTitlePosition { get; set; }
            = CesTitlePositionEnum.Left;
        [System.ComponentModel.Category("CesTextBox Title")]
        public CesTitlePositionEnum CesTitlePosition
        {
            get { return cesTitlePosition; }
            set
            {
                cesTitlePosition = value;
                //ArrangeControls();
            }
        }


        private CesTitleContentAlignmentEnum cesTitleTextAlignment { get; set; }
            = CesTitleContentAlignmentEnum.Center;
        [System.ComponentModel.Category("CesTextBox Title")]
        public CesTitleContentAlignmentEnum CesTitleTextAlignment
        {
            get
            {
                return cesTitleTextAlignment;
            }
            set
            {
                cesTitleTextAlignment = value;
                //Redraw();
            }
        }


        private bool cesTitleAutoWidth { get; set; }
        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesTitleAutoWidth
        {
            get { return cesTitleAutoWidth; }
            set
            {
                cesTitleAutoWidth = value;
                //ArrangeControls();
            }
        }


        private int cesTitleWidth { get; set; } = 80;
        [System.ComponentModel.Category("CesTextBox Title")]
        public int CesTitleWidth
        {
            get { return cesTitleWidth; }
            set
            {
                cesTitleWidth = value;
                //ArrangeControls();
            }
        }


        private bool cesTitleAutoHeight { get; set; }
        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesTitleAutoHeight
        {
            get { return cesTitleAutoHeight; }
            set
            {
                cesTitleAutoHeight = value;
                //ArrangeControls();
            }
        }


        private int cesTitleHeight { get; set; } = 10;
        [System.ComponentModel.Category("CesTextBox Title")]
        public int CesTitleHeight
        {
            get { return cesTitleHeight; }
            set
            {
                cesTitleHeight = value;
                //ArrangeControls();
            }
        }
    }

    public static class BorderGeneratorExtension
    {
        public static System.Drawing.Graphics GenerateBorder(
            this System.Drawing.Graphics graphics,
            BorderOptions borderOptions,
            TitleOptions titleOptions)
        {
            using (var g = graphics)
            {
                g.Clear(borderOptions.CesControl.BackColor);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw Border
                using (var gpBorder = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    using (var pBorder =
                        new Pen(borderOptions.CesHasNotification ?
                        borderOptions.CesNotificationColor :
                        borderOptions.CesBorderColor,
                        borderOptions.CesBorderThickness))
                    {
                        // Top-Left Arc
                        gpBorder.AddArc(new Rectangle(
                            (borderOptions.CesBorderThickness / 2) + 1,
                            (borderOptions.CesBorderThickness / 2) + 1,
                            borderOptions.CesBorderRadius,
                            borderOptions.CesBorderRadius),
                            180, 90);

                        // Top-Right Arc
                        gpBorder.AddArc(new Rectangle(
                            borderOptions.CesControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                            (borderOptions.CesBorderThickness / 2) + 1,
                            borderOptions.CesBorderRadius,
                            borderOptions.CesBorderRadius),
                            270, 90);

                        // Bottom-Right Arc
                        gpBorder.AddArc(new Rectangle(
                            borderOptions.CesControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                            borderOptions.CesControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                            borderOptions.CesBorderRadius,
                            borderOptions.CesBorderRadius),
                            0, 90);

                        // Bottom-Left Arc
                        gpBorder.AddArc(new Rectangle(
                            (borderOptions.CesBorderThickness / 2) + 1,
                            borderOptions.CesControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                            borderOptions.CesBorderRadius,
                            borderOptions.CesBorderRadius),
                            90, 90);

                        //using (var sb = new SolidBrush(borderOptions.CesControl.txtTextBox.Focused ? borderOptions.CesFocusColor : borderOptions.CesBackColor))
                        //{
                        //    borderOptions.CesControl.txtTextBox.BackColor = borderOptions.CesControl.txtTextBox.Focused ? borderOptions.CesFocusColor : borderOptions.CesBackColor;

                        //    gpBorder.CloseFigure();
                        //    g.FillPath(sb, gpBorder);
                        //}

                        using (var sb = new SolidBrush(borderOptions.CesBackColor))
                        {
                            //_ctr.BackColor = borderOptions.CesBackColor;

                            gpBorder.CloseFigure();
                            g.FillPath(sb, gpBorder);
                        }

                        g.DrawPath(pBorder, gpBorder);
                    }
                }

                // Draw Title
                if (titleOptions.CesShowTitle)
                {
                    using (var gpTitle = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        using (var pTitle = new Pen(borderOptions.CesBorderColor, borderOptions.CesBorderThickness))
                        {
                            // Define Title Path
                            if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Left)
                            {
                                // Top-Left Arc
                                gpTitle.AddArc(new Rectangle(
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesBorderRadius,
                                    borderOptions.CesBorderRadius),
                                    180, 90);

                                // Top line
                                gpTitle.AddLine(
                                    (borderOptions.CesBorderThickness / 2) + 1 + borderOptions.CesBorderRadius,
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
                                    (borderOptions.CesBorderThickness / 2) + 1);

                                // Right Line
                                gpTitle.AddLine(
                                    titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2));

                                // Bottom Line
                                gpTitle.AddLine(
                                    titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - 1,
                                    (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - 1);

                                // Bottom-Left Arc
                                gpTitle.AddArc(new Rectangle(
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesBorderRadius,
                                    borderOptions.CesBorderRadius),
                                    90, 90);
                            }

                            if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Right)
                            {
                                // Top line
                                gpTitle.AddLine(
                                    borderOptions.CesControl.Width - (titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth),
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesControl.Width - borderOptions.CesBorderRadius,
                                    (borderOptions.CesBorderThickness / 2) + 1);

                                // Top-Right Arc
                                gpTitle.AddArc(new Rectangle(
                                    borderOptions.CesControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesBorderRadius,
                                    borderOptions.CesBorderRadius),
                                    270, 90);

                                // Bottom-Right Arc
                                gpTitle.AddArc(new Rectangle(
                                    borderOptions.CesControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesBorderRadius,
                                    borderOptions.CesBorderRadius),
                                    0, 90);

                                // Bottom line
                                gpTitle.AddLine(
                                    borderOptions.CesControl.Width - borderOptions.CesBorderRadius,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesControl.Width - (titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth),
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - 1);
                            }

                            if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Top)
                            {
                                // Top-Left Arc
                                gpTitle.AddArc(new Rectangle(
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesBorderRadius,
                                    borderOptions.CesBorderRadius),
                                    180, 90);

                                // Top-Right Arc
                                gpTitle.AddArc(new Rectangle(
                                    borderOptions.CesControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesBorderRadius,
                                    borderOptions.CesBorderRadius),
                                    270, 90);

                                // Right Line
                                gpTitle.AddLine(
                                    borderOptions.CesControl.Width - (borderOptions.CesBorderThickness / 2) - 1,
                                    (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius,
                                    borderOptions.CesControl.Width - (borderOptions.CesBorderThickness / 2) - 1,
                                    (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? borderOptions._titleTextSize.Height : titleOptions.CesTitleHeight));

                                // Bottom Line
                                gpTitle.AddLine(
                                    borderOptions.CesControl.Width - borderOptions.CesBorderRadius,
                                    (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? borderOptions._titleTextSize.Height : titleOptions.CesTitleHeight),
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? borderOptions._titleTextSize.Height : titleOptions.CesTitleHeight));
                            }

                            if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Bottom)
                            {
                                // Top Line
                                gpTitle.AddLine(
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius - (titleOptions.CesTitleAutoHeight ? borderOptions._titleTextSize.Height : titleOptions.CesTitleHeight),
                                    borderOptions.CesControl.Width - (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius - (titleOptions.CesTitleAutoHeight ? borderOptions._titleTextSize.Height : titleOptions.CesTitleHeight));

                                // Right Line
                                gpTitle.AddLine(
                                    borderOptions.CesControl.Width - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius - (titleOptions.CesTitleAutoHeight ? borderOptions._titleTextSize.Height : titleOptions.CesTitleHeight),
                                    borderOptions.CesControl.Width - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius);

                                // Bottom-Right Arc
                                gpTitle.AddArc(new Rectangle(
                                    borderOptions.CesControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesBorderRadius,
                                    borderOptions.CesBorderRadius),
                                    0, 90);

                                // Bottom-Left Arc
                                gpTitle.AddArc(new Rectangle(
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesBorderRadius,
                                    borderOptions.CesBorderRadius),
                                    90, 90);
                            }

                            // Draw Title And  Fill Path
                            using (var sbTitle = new SolidBrush(borderOptions.CesHasNotification ? borderOptions.CesNotificationColor : borderOptions.CesBorderColor))
                            {
                                gpTitle.CloseFigure();

                                if (titleOptions.CesTitleBackground)
                                {
                                    g.FillPath(sbTitle, gpTitle);
                                }
                                else
                                {
                                    g.DrawPath(pTitle, gpTitle);
                                }
                            }
                        }

                        // Draw Icon
                        if (titleOptions.CesShowIcon)
                        {
                            RectangleF iconDestinationRect = new RectangleF();

                            if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Left)
                            {
                                iconDestinationRect = new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesControl.Margin.Left :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? ((titleOptions.CesTitleAutoWidth ? titleOptions.CesIcon.Width : titleOptions.CesTitleWidth) / 2) - (titleOptions.CesIcon.Width / 2) :
                                    (titleOptions.CesTitleAutoWidth ? titleOptions.CesIcon.Width : titleOptions.CesTitleWidth) - titleOptions.CesIcon.Width - (borderOptions.CesBorderThickness * 2),
                                    (borderOptions.CesControl.Height / 2) - (titleOptions.CesIcon.Height / 2),
                                    titleOptions.CesIcon.Width,
                                    titleOptions.CesIcon.Height);
                            }

                            if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Right)
                            {
                                iconDestinationRect = new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? borderOptions.CesControl.Width - (titleOptions.CesTitleAutoWidth ? titleOptions.CesIcon.Width : titleOptions.CesTitleWidth) + (borderOptions.CesBorderThickness * 2) :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? borderOptions.CesControl.Width - ((titleOptions.CesTitleAutoWidth ? titleOptions.CesIcon.Width : titleOptions.CesTitleWidth) / 2) - (titleOptions.CesIcon.Width / 2) :
                                    borderOptions.CesControl.Width - titleOptions.CesIcon.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesControl.Margin.Right,
                                    (borderOptions.CesControl.Height / 2) - (titleOptions.CesIcon.Height / 2),
                                    titleOptions.CesIcon.Width,
                                    titleOptions.CesIcon.Height);
                            }

                            if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Top)
                            {
                                iconDestinationRect = new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesControl.Margin.Left :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesControl.Width / 2) - (titleOptions.CesIcon.Width / 2) :
                                    borderOptions.CesControl.Width - titleOptions.CesIcon.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesControl.Margin.Right,
                                    ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions.CesIcon.Height : titleOptions.CesTitleHeight)) / 2) - (titleOptions.CesIcon.Height / 2),
                                    titleOptions.CesIcon.Width,
                                    titleOptions.CesIcon.Height);
                            }

                            if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Bottom)
                            {
                                iconDestinationRect = new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesControl.Margin.Left :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesControl.Width / 2) - (titleOptions.CesIcon.Width / 2) :
                                    borderOptions.CesControl.Width - titleOptions.CesIcon.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesControl.Margin.Right,
                                    borderOptions.CesControl.Height - ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions.CesIcon.Height : titleOptions.CesTitleHeight)) / 2) - (titleOptions.CesIcon.Height / 2),
                                    titleOptions.CesIcon.Width,
                                    titleOptions.CesIcon.Height);
                            }

                            g.DrawImage(
                                titleOptions.CesIcon,
                                iconDestinationRect,
                                new RectangleF(0, 0, titleOptions.CesIcon.Width, titleOptions.CesIcon.Height),
                                GraphicsUnit.Pixel);

                            return g; // Not need to draw string after icon
                        }

                        // Draw Title Text
                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Left)
                        {
                            g.DrawString(
                                titleOptions.CesTitleText,
                                titleOptions.CesTitleFont,
                                new SolidBrush(titleOptions.CesTitleTextColor),
                                new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesControl.Margin.Left :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? ((titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth) / 2) - (borderOptions._titleTextSize.Width / 2) :
                                    (titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth) - borderOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2),
                                    (borderOptions.CesControl.Height / 2) - (borderOptions._titleTextSize.Height / 2),
                                    borderOptions._titleTextSize.Width,
                                    borderOptions._titleTextSize.Height));
                        }

                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Right)
                        {
                            g.DrawString(
                                titleOptions.CesTitleText,
                                titleOptions.CesTitleFont,
                                new SolidBrush(titleOptions.CesTitleTextColor),
                                new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? borderOptions.CesControl.Width - (titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth) + (borderOptions.CesBorderThickness * 2) :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? borderOptions.CesControl.Width - ((titleOptions.CesTitleAutoWidth ? borderOptions._titleTextSize.Width : titleOptions.CesTitleWidth) / 2) - (borderOptions._titleTextSize.Width / 2) :
                                    borderOptions.CesControl.Width - borderOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesControl.Margin.Right,
                                    (borderOptions.CesControl.Height / 2) - (borderOptions._titleTextSize.Height / 2),
                                    borderOptions._titleTextSize.Width,
                                    borderOptions._titleTextSize.Height));
                        }

                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Top)
                        {
                            g.DrawString(
                                titleOptions.CesTitleText,
                                titleOptions.CesTitleFont,
                                new SolidBrush(titleOptions.CesTitleTextColor),
                                new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesControl.Margin.Left :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesControl.Width / 2) - (borderOptions._titleTextSize.Width / 2) :
                                    borderOptions.CesControl.Width - borderOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesControl.Margin.Right,
                                    ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? borderOptions._titleTextSize.Height : titleOptions.CesTitleHeight)) / 2) - (borderOptions._titleTextSize.Height / 2),
                                    borderOptions._titleTextSize.Width,
                                    borderOptions._titleTextSize.Height));
                        }

                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Bottom)
                        {
                            g.DrawString(
                                titleOptions.CesTitleText,
                                titleOptions.CesTitleFont,
                                new SolidBrush(titleOptions.CesTitleTextColor),
                                new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesControl.Margin.Left :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesControl.Width / 2) - (borderOptions._titleTextSize.Width / 2) :
                                    borderOptions.CesControl.Width - borderOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesControl.Margin.Right,
                                    borderOptions.CesControl.Height - ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? borderOptions._titleTextSize.Height : titleOptions.CesTitleHeight)) / 2) - (borderOptions._titleTextSize.Height / 2),
                                    borderOptions._titleTextSize.Width,
                                    borderOptions._titleTextSize.Height));
                        }
                    }
                }

                return g;
            }
        }
    }
}
