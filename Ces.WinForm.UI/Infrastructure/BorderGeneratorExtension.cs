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


    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    [System.ComponentModel.Category("CesBorderOptions")]
    public class BorderOptions
    {
        public BorderOptions(Control control)
        {
            this.CesControl = control;
            this._initialControlHeight = control.Height;
        }


        [System.ComponentModel.Browsable(false)]
        public int _initialControlHeight { get; set; }


        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("CesBorderOptions")]
        public Control CesControl { get; set; }


        private bool cesHasNotification = false;
        [System.ComponentModel.Category("CesBorderOptions")]
        public bool CesHasNotification
        {
            get { return cesHasNotification; }
            set
            {
                cesHasNotification = value;
                CesControl.Invalidate();
            }
        }

        private Color cesNotificationColor = Color.Red;
        [System.ComponentModel.Category("CesBorderOptions")]
        public Color CesNotificationColor
        {
            get { return cesNotificationColor; }
            set
            {
                cesNotificationColor = value;
                CesControl.Invalidate();
            }
        }

        private bool cesAutoHeight = true;
        [System.ComponentModel.Category("CesBorderOptions")]
        public bool CesAutoHeight
        {
            get { return cesAutoHeight; }
            set
            {
                cesAutoHeight = value;
                CesControl.Invalidate();
            }
        }

        private Color cesBackColor = Color.White;
        [System.ComponentModel.Category("CesBorderOptions")]
        public Color CesBackColor
        {
            get { return cesBackColor; }
            set
            {
                cesBackColor = value;
                CesControl.Invalidate();
            }
        }

        private Color cesBorderColor = Color.DeepSkyBlue;
        [System.ComponentModel.Category("CesBorderOptions")]
        public Color CesBorderColor
        {
            get { return cesBorderColor; }
            set
            {
                cesBorderColor = value;
                CesControl.Invalidate();
            }
        }

        private int cesBorderThickness = 1;
        [System.ComponentModel.Category("CesBorderOptions")]
        public int CesBorderThickness
        {
            get { return cesBorderThickness; }
            set
            {
                cesBorderThickness = value;
                CesControl.Invalidate();
            }
        }

        private int cesBorderRadius = 15;
        [System.ComponentModel.Category("CesBorderOptions")]
        public int CesBorderRadius
        {
            get { return cesBorderRadius; }
            set
            {
                cesBorderRadius = value;
                CesControl.Invalidate();
            }
        }
    }



    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    [System.ComponentModel.Category("CesTitleOptions")]
    public class TitleOptions
    {

        public TitleOptions(Control control, Font font)
        {
            this.CesControl = control;
            this.CesTitleFont = font;
        }


        [System.ComponentModel.Browsable(false)]
        public SizeF _titleTextSize { get; set; }


        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("CesTextBox Icon")]
        public Control CesControl { get; set; }


        private bool cesShowIcon = false;
        [System.ComponentModel.Category("CesTextBox Icon")]
        public bool CesShowIcon
        {
            get { return cesShowIcon; }
            set
            {
                cesShowIcon = value;
                this.CesControl.Invalidate();
            }
        }


        private Image? cesIcon = null;
        [System.ComponentModel.Category("CesTextBox Icon")]
        public Image? CesIcon
        {
            get { return cesIcon; }
            set
            {
                cesIcon = value;
                this.CesControl.Invalidate();
            }
        }

        private bool cesShowTitle = false;
        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesShowTitle
        {
            get { return cesShowTitle; }
            set
            {
                cesShowTitle = value;
                this.CesControl.Invalidate();
            }
        }

        private bool cesTitleBackground = true;
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
                this.CesControl.Invalidate();
            }
        }


        private Font cesTitleFont;
        public Font CesTitleFont
        {
            get { return cesTitleFont; }
            set
            {
                cesTitleFont = value;
                this.CesControl.Invalidate();
            }
        }


        private Color cesTitleTextColor = Color.White;
        [System.ComponentModel.Category("CesTextBox Title")]
        public Color CesTitleTextColor
        {
            get { return cesTitleTextColor; }
            set
            {
                cesTitleTextColor = value;
                this.CesControl.Invalidate();
            }
        }


        private string cesTitleText = "Enter Value";
        [System.ComponentModel.Category("CesTextBox Title")]
        public string CesTitleText
        {
            get { return cesTitleText; }
            set
            {
                cesTitleText = value;
                this.CesControl.Invalidate();
            }
        }


        private CesTitlePositionEnum cesTitlePosition = CesTitlePositionEnum.Left;
        [System.ComponentModel.Category("CesTextBox Title")]
        public CesTitlePositionEnum CesTitlePosition
        {
            get { return cesTitlePosition; }
            set
            {
                cesTitlePosition = value;
                this.CesControl.Invalidate();
            }
        }


        private CesTitleContentAlignmentEnum cesTitleTextAlignment = CesTitleContentAlignmentEnum.Center;
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
                this.CesControl.Invalidate();
            }
        }


        private bool cesTitleAutoWidth;
        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesTitleAutoWidth
        {
            get { return cesTitleAutoWidth; }
            set
            {
                cesTitleAutoWidth = value;
                this.CesControl.Invalidate();
            }
        }


        private int cesTitleWidth = 80;
        [System.ComponentModel.Category("CesTextBox Title")]
        public int CesTitleWidth
        {
            get { return cesTitleWidth; }
            set
            {
                cesTitleWidth = value;
                this.CesControl.Invalidate();
            }
        }


        private bool cesTitleAutoHeight;
        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesTitleAutoHeight
        {
            get { return cesTitleAutoHeight; }
            set
            {
                cesTitleAutoHeight = value;
                this.CesControl.Invalidate();
            }
        }


        private int cesTitleHeight = 10;
        [System.ComponentModel.Category("CesTextBox Title")]
        public int CesTitleHeight
        {
            get { return cesTitleHeight; }
            set
            {
                cesTitleHeight = value;
                this.CesControl.Invalidate();
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

                titleOptions._titleTextSize = g.MeasureString(titleOptions.CesTitleText, titleOptions.CesTitleFont);

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
                        // Draw title area
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
                                    titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
                                    (borderOptions.CesBorderThickness / 2) + 1);

                                // Right Line
                                gpTitle.AddLine(
                                    titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2));

                                // Bottom Line
                                gpTitle.AddLine(
                                    titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
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
                                    borderOptions.CesControl.Width - (titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth),
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
                                    borderOptions.CesControl.Width - (titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth),
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
                                    (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight));

                                // Bottom Line
                                gpTitle.AddLine(
                                    borderOptions.CesControl.Width - borderOptions.CesBorderRadius,
                                    (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight),
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight));
                            }

                            if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Bottom)
                            {
                                // Top Line
                                gpTitle.AddLine(
                                    (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius - (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight),
                                    borderOptions.CesControl.Width - (borderOptions.CesBorderThickness / 2) + 1,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius - (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight));

                                // Right Line
                                gpTitle.AddLine(
                                    borderOptions.CesControl.Width - (borderOptions.CesBorderThickness / 2) - 1,
                                    borderOptions.CesControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius - (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight),
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

                            // Draw Title And Fill Path
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

                            return g; // Not need to draw string if ShowIcon = true
                        }

                        // Draw Title Text
                        var titleRect = new RectangleF();

                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Left)
                        {
                            titleRect = new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesControl.Margin.Left :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? ((titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) / 2) - (titleOptions._titleTextSize.Width / 2) :
                                    (titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) - titleOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2),
                                    (borderOptions.CesControl.Height / 2) - (titleOptions._titleTextSize.Height / 2),
                                    titleOptions._titleTextSize.Width,
                                    titleOptions._titleTextSize.Height);
                        }

                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Right)
                        {
                            titleRect = new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? borderOptions.CesControl.Width - (titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) + (borderOptions.CesBorderThickness * 2) :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? borderOptions.CesControl.Width - ((titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) / 2) - (titleOptions._titleTextSize.Width / 2) :
                                    borderOptions.CesControl.Width - titleOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesControl.Margin.Right,
                                    (borderOptions.CesControl.Height / 2) - (titleOptions._titleTextSize.Height / 2),
                                    titleOptions._titleTextSize.Width,
                                    titleOptions._titleTextSize.Height);
                        }

                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Top)
                        {
                            titleRect = new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesControl.Margin.Left :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesControl.Width / 2) - (titleOptions._titleTextSize.Width / 2) :
                                    borderOptions.CesControl.Width - titleOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesControl.Margin.Right,
                                    ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight)) / 2) - (titleOptions._titleTextSize.Height / 2),
                                    titleOptions._titleTextSize.Width,
                                    titleOptions._titleTextSize.Height);
                        }

                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Bottom)
                        {
                            titleRect = new RectangleF(
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesControl.Margin.Left :
                                    titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesControl.Width / 2) - (titleOptions._titleTextSize.Width / 2) :
                                    borderOptions.CesControl.Width - titleOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesControl.Margin.Right,
                                    borderOptions.CesControl.Height - ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight)) / 2) - (titleOptions._titleTextSize.Height / 2),
                                    titleOptions._titleTextSize.Width,
                                    titleOptions._titleTextSize.Height);
                        }

                        g.DrawString(
                            titleOptions.CesTitleText,
                            titleOptions.CesTitleFont,
                            new SolidBrush(titleOptions.CesTitleTextColor),
                            titleRect);
                    }
                }

                return g;
            }
        }


        public static void ArrangeControls(
            this UserControl userControl,
            BorderOptions borderOptions,
            TitleOptions titleOptions)
        {
            // Auto Height TextBox Control
            if (titleOptions.CesShowTitle && borderOptions.CesAutoHeight &&
                (titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top ||
                titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Bottom))
                borderOptions.CesControl.Height =
                        borderOptions.CesControl.Controls[0].Height +
                        borderOptions.CesControl.Margin.Top +
                        borderOptions.CesControl.Margin.Bottom +
                        (borderOptions.CesBorderThickness * 4) +
                        (int)(titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight) + borderOptions.CesBorderRadius;

            // Set txtTextBox Control Inside UserControl
            borderOptions.CesControl.Controls[0].Width =
                    borderOptions.CesControl.Width -
                    borderOptions.CesControl.Padding.Left -
                    borderOptions.CesControl.Padding.Right -
                    (borderOptions.CesBorderThickness * 4) -
                    ((titleOptions.CesShowTitle && (titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left || titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right)) ?
                    (titleOptions.CesTitleAutoWidth ? (int)titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) : 0);

            // Normal Top Position
            borderOptions.CesControl.Controls[0].Top =
                (borderOptions.CesControl.Height / 2) -
                (borderOptions.CesControl.Controls[0].Height / 2);

            // Set Top Postion According to Title Position = Top
            if (titleOptions.CesShowTitle && titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top)
                borderOptions.CesControl.Controls[0].Top =
                    (borderOptions.CesControl.Height / 2) -
                    (borderOptions.CesControl.Controls[0].Height / 2) +
                    (int)(titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight);

            // Set Top Postion According to Title Position = Bottom
            if (titleOptions.CesShowTitle && titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Bottom)
                borderOptions.CesControl.Controls[0].Top =
                    (borderOptions.CesControl.Height / 2) -
                    (borderOptions.CesControl.Controls[0].Height / 2) -
                    (int)(titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight);

            // Normal Left Position
            borderOptions.CesControl.Controls[0].Left =
                (borderOptions.CesControl.Width / 2) -
                (borderOptions.CesControl.Controls[0].Width / 2);

            // Set txtTextBox Left Position According to Title Position = Left
            if (titleOptions.CesShowTitle && titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left)
                borderOptions.CesControl.Controls[0].Left =
                    (int)(titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) +
                    (borderOptions.CesBorderThickness * 4);

            // Set txtTextBox Left Position According to Title Position = Right
            if (titleOptions.CesShowTitle && titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right)
                borderOptions.CesControl.Controls[0].Left =
                    (borderOptions.CesBorderThickness * 4);
        }
    }
}
