using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.Infrastructure
{
    public partial class CesControlBase : UserControl
    {
        public CesControlBase()
        {
            CesTitleFont = this.Font;
            InitializeComponent();
        }

        #region "Ces Border Options"
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("Ces Border Options")]
        public int _initialControlHeight { get; set; } = 0;


        private System.Windows.Forms.Padding cesPadding = new Padding(3);
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Border Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public System.Windows.Forms.Padding CesPadding
        {
            get { return cesPadding; }
            set
            {
                cesPadding = value;
                this.Invalidate();
            }
        }

        private bool cesHasNotification = false;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Border Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool CesHasNotification
        {
            get { return cesHasNotification; }
            set
            {
                cesHasNotification = value;
                this.Invalidate();
            }
        }

        private Color cesNotificationColor = Color.Red;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Border Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public Color CesNotificationColor
        {
            get { return cesNotificationColor; }
            set
            {
                cesNotificationColor = value;
                this.Invalidate();
            }
        }

        private bool cesAutoHeight = true;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Border Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool CesAutoHeight
        {
            get { return cesAutoHeight; }
            set
            {
                cesAutoHeight = value;
                this.Invalidate();
            }
        }

        private Color cesBackColor = Color.White;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Border Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public Color CesBackColor
        {
            get { return cesBackColor; }
            set
            {
                cesBackColor = value;
                this.Invalidate();
            }
        }

        private Color cesBorderColor = Color.DeepSkyBlue;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Border Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public Color CesBorderColor
        {
            get { return cesBorderColor; }
            set
            {
                cesBorderColor = value;
                this.Invalidate();
            }
        }

        private int cesBorderThickness = 1;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Border Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public int CesBorderThickness
        {
            get { return cesBorderThickness; }
            set
            {
                cesBorderThickness = value;
                this.Invalidate();
            }
        }

        private int cesBorderRadius = 15;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Border Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public int CesBorderRadius
        {
            get { return cesBorderRadius; }
            set
            {
                cesBorderRadius = value;
                this.Invalidate();
            }
        }
        #endregion

        #region "Ces Title Options"
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Category("Ces Title Options")]
        public SizeF _titleTextSize { get; set; }


        private bool cesShowIcon = false;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool CesShowIcon
        {
            get { return cesShowIcon; }
            set
            {
                cesShowIcon = value;
                this.Invalidate();
            }
        }


        private Image? cesIcon = null;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public Image? CesIcon
        {
            get { return cesIcon; }
            set
            {
                cesIcon = value;
                this.Invalidate();
            }
        }

        private bool cesShowTitle = false;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool CesShowTitle
        {
            get { return cesShowTitle; }
            set
            {
                cesShowTitle = value;
                this.Invalidate();
            }
        }

        private bool cesTitleBackground = true;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool CesTitleBackground
        {
            get
            {
                return cesTitleBackground;
            }
            set
            {
                cesTitleBackground = value;
                this.Invalidate();
            }
        }


        private Font cesTitleFont; //initial value set in constructor
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public Font CesTitleFont
        {
            get { return cesTitleFont; }
            set
            {
                cesTitleFont = value;
                this.Invalidate();
            }
        }


        private Color cesTitleTextColor = Color.White;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public Color CesTitleTextColor
        {
            get { return cesTitleTextColor; }
            set
            {
                cesTitleTextColor = value;
                this.Invalidate();
            }
        }


        private string cesTitleText = "Enter Value";
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public string CesTitleText
        {
            get { return cesTitleText; }
            set
            {
                cesTitleText = value;
                this.Invalidate();
            }
        }


        private CesTitlePositionEnum cesTitlePosition = CesTitlePositionEnum.Left;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public CesTitlePositionEnum CesTitlePosition
        {
            get { return cesTitlePosition; }
            set
            {
                cesTitlePosition = value;
                this.Invalidate();
            }
        }


        private CesTitleContentAlignmentEnum cesTitleTextAlignment = CesTitleContentAlignmentEnum.Center;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public CesTitleContentAlignmentEnum CesTitleTextAlignment
        {
            get
            {
                return cesTitleTextAlignment;
            }
            set
            {
                cesTitleTextAlignment = value;
                this.Invalidate();
            }
        }


        private bool cesTitleAutoWidth = false;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool CesTitleAutoWidth
        {
            get { return cesTitleAutoWidth; }
            set
            {
                cesTitleAutoWidth = value;
                this.Invalidate();
            }
        }


        private int cesTitleWidth = 80;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public int CesTitleWidth
        {
            get { return cesTitleWidth; }
            set
            {
                cesTitleWidth = value;
                this.Invalidate();
            }
        }


        private bool cesTitleAutoHeight = false;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool CesTitleAutoHeight
        {
            get { return cesTitleAutoHeight; }
            set
            {
                cesTitleAutoHeight = value;
                this.Invalidate();
            }
        }


        private int cesTitleHeight = 10;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Title Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public int CesTitleHeight
        {
            get { return cesTitleHeight; }
            set
            {
                cesTitleHeight = value;
                this.Invalidate();
            }
        }
        #endregion

        public void ArrangeControls(Control control)
        {
            if (control.Controls.Count == 0)
                return;

            Control? childControl = control.Controls[0];

            using System.Drawing.Graphics g = control.CreateGraphics();
            _titleTextSize = g.MeasureString(CesTitleText, CesTitleFont);

            // Auto Height TextBox Control
            if (CesShowTitle && CesAutoHeight &&
                (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top ||
                CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Bottom))
                this.Height =
                        childControl.Height +
                        (CesBorderThickness * 2) +
                        (int)(CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight) + CesBorderRadius;

            //Set Child Control Inside UserControl
            int childControlWidth =
                control.Width -
                CesPadding.Left -
                CesPadding.Right -
                (CesBorderThickness * 2);

            if (CesShowTitle &&
                (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left ||
                CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right))
            {
                if (CesTitleAutoWidth)
                {
                    childControlWidth -= (int)_titleTextSize.Width;
                }
                else
                {
                    childControlWidth -= CesTitleWidth;
                }
            }


            childControl.Width = childControlWidth;


            // Normal Top Position
            childControl.Top =
                (this.Height / 2) -
                (this.Controls[0].Height / 2);

            // Set Top Postion According to Title Position = Top
            if (CesShowTitle && CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top)
                childControl.Top =
                    (this.Height / 2) -
                    (this.Controls[0].Height / 2) +
                    (int)(CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight);

            // Set Top Postion According to Title Position = Bottom
            if (CesShowTitle && CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Bottom)
                childControl.Top =
                    (this.Height / 2) -
                    (this.Controls[0].Height / 2) -
                    (int)(CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight);

            // Normal Left Position
            childControl.Left =
                (this.Width / 2) -
                (this.Controls[0].Width / 2);

            // Set txtTextBox Left Position According to Title Position = Left
            if (CesShowTitle && CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left)
                childControl.Left =
                    (int)(CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth) +
                    CesPadding.Left +
                    (CesBorderThickness / 2);

            // Set txtTextBox Left Position According to Title Position = Right
            if (CesShowTitle && CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right)
                childControl.Left =
                     CesPadding.Left +
                     (CesBorderThickness / 2);
        }

        public void GenerateBorder(Control control)
        {
            if (control.Controls.Count > 0)
            {
                Control? childControl = control.Controls[0];

                if (childControl is not null)
                    childControl.BackColor = CesBackColor;
            }

            using (var g = this.CreateGraphics())
            {
                g.Clear(this.BackColor);
                //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw Border
                using (var gpBorder = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    using (var pBorder =
                        new Pen(CesHasNotification ?
                        CesNotificationColor :
                        CesBorderColor,
                        CesBorderThickness))
                    {
                        // Top-Left Arc
                        gpBorder.AddArc(new Rectangle(
                            (CesBorderThickness / 2) + 1,
                            (CesBorderThickness / 2) + 1,
                            CesBorderRadius,
                            CesBorderRadius),
                            180, 90);

                        // Top-Right Arc
                        gpBorder.AddArc(new Rectangle(
                            this.Width - CesBorderRadius - (CesBorderThickness / 2) - 1,
                            (CesBorderThickness / 2) + 1,
                            CesBorderRadius,
                            CesBorderRadius),
                            270, 90);

                        // Bottom-Right Arc
                        gpBorder.AddArc(new Rectangle(
                            this.Width - CesBorderRadius - (CesBorderThickness / 2) - 1,
                            this.Height - CesBorderRadius - (CesBorderThickness / 2) - 1,
                            CesBorderRadius,
                            CesBorderRadius),
                            0, 90);

                        // Bottom-Left Arc
                        gpBorder.AddArc(new Rectangle(
                            (CesBorderThickness / 2) + 1,
                            this.Height - CesBorderRadius - (CesBorderThickness / 2) - 1,
                            CesBorderRadius,
                            CesBorderRadius),
                            90, 90);

                        using (var sb = new SolidBrush(CesBackColor))
                        {
                            gpBorder.CloseFigure();
                            g.FillPath(sb, gpBorder);
                        }

                        g.DrawPath(pBorder, gpBorder);
                    }
                }

                // Draw Title
                if (CesShowTitle)
                {
                    _titleTextSize = g.MeasureString(CesTitleText, CesTitleFont);

                    using (var gpTitle = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        // Draw title area
                        using (var pTitle = new Pen(CesBorderColor, CesBorderThickness))
                        {
                            // Define Title Path
                            if (CesTitlePosition == CesTitlePositionEnum.Left)
                            {
                                // Top-Left Arc
                                gpTitle.AddArc(new Rectangle(
                                    (CesBorderThickness / 2) + 1,
                                    (CesBorderThickness / 2) + 1,
                                    CesBorderRadius,
                                    CesBorderRadius),
                                    180, 90);

                                // Top line
                                gpTitle.AddLine(
                                    (CesBorderThickness / 2) + 1 + CesBorderRadius,
                                    (CesBorderThickness / 2) + 1,
                                    CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth,
                                    (CesBorderThickness / 2) + 1);

                                // Right Line
                                gpTitle.AddLine(
                                    CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth,
                                    (CesBorderThickness / 2) + 1,
                                    CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth,
                                    this.Height - (CesBorderThickness / 2));

                                // Bottom Line
                                gpTitle.AddLine(
                                    CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth,
                                    this.Height - (CesBorderThickness / 2) - 1,
                                    (CesBorderThickness / 2) + CesBorderRadius,
                                    this.Height - (CesBorderThickness / 2) - 1);

                                // Bottom-Left Arc
                                gpTitle.AddArc(new Rectangle(
                                    (CesBorderThickness / 2) + 1,
                                    this.Height - CesBorderRadius - (CesBorderThickness / 2) - 1,
                                    CesBorderRadius,
                                    CesBorderRadius),
                                    90, 90);
                            }

                            if (CesTitlePosition == CesTitlePositionEnum.Right)
                            {
                                // Top line
                                gpTitle.AddLine(
                                    this.Width - (CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth),
                                    (CesBorderThickness / 2) + 1,
                                    this.Width - CesBorderRadius,
                                    (CesBorderThickness / 2) + 1);

                                // Top-Right Arc
                                gpTitle.AddArc(new Rectangle(
                                    this.Width - CesBorderRadius - (CesBorderThickness / 2) - 1,
                                    (CesBorderThickness / 2) + 1,
                                    CesBorderRadius,
                                    CesBorderRadius),
                                    270, 90);

                                // Bottom-Right Arc
                                gpTitle.AddArc(new Rectangle(
                                    this.Width - CesBorderRadius - (CesBorderThickness / 2) - 1,
                                    this.Height - CesBorderRadius - (CesBorderThickness / 2) - 1,
                                    CesBorderRadius,
                                    CesBorderRadius),
                                    0, 90);

                                // Bottom line
                                gpTitle.AddLine(
                                    this.Width - CesBorderRadius,
                                    this.Height - (CesBorderThickness / 2) - 1,
                                    this.Width - (CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth),
                                    this.Height - (CesBorderThickness / 2) - 1);
                            }

                            if (CesTitlePosition == CesTitlePositionEnum.Top)
                            {
                                // Top-Left Arc
                                gpTitle.AddArc(new Rectangle(
                                    (CesBorderThickness / 2) + 1,
                                    (CesBorderThickness / 2) + 1,
                                    CesBorderRadius,
                                    CesBorderRadius),
                                    180, 90);

                                // Top-Right Arc
                                gpTitle.AddArc(new Rectangle(
                                    this.Width - CesBorderRadius - (CesBorderThickness / 2) - 1,
                                    (CesBorderThickness / 2) + 1,
                                    CesBorderRadius,
                                    CesBorderRadius),
                                    270, 90);

                                // Right Line
                                gpTitle.AddLine(
                                    this.Width - (CesBorderThickness / 2) - 1,
                                    (CesBorderThickness / 2) + CesBorderRadius,
                                    this.Width - (CesBorderThickness / 2) - 1,
                                    (CesBorderThickness / 2) + CesBorderRadius + (CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight));

                                // Bottom Line
                                gpTitle.AddLine(
                                    this.Width - CesBorderRadius,
                                    (CesBorderThickness / 2) + CesBorderRadius + (CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight),
                                    (CesBorderThickness / 2) + 1,
                                    (CesBorderThickness / 2) + CesBorderRadius + (CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight));
                            }

                            if (CesTitlePosition == CesTitlePositionEnum.Bottom)
                            {
                                // Top Line
                                gpTitle.AddLine(
                                    (CesBorderThickness / 2) + 1,
                                    this.Height - (CesBorderThickness / 2) - CesBorderRadius - (CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight),
                                    this.Width - (CesBorderThickness / 2) + 1,
                                    this.Height - (CesBorderThickness / 2) - CesBorderRadius - (CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight));

                                // Right Line
                                gpTitle.AddLine(
                                    this.Width - (CesBorderThickness / 2) - 1,
                                    this.Height - (CesBorderThickness / 2) - CesBorderRadius - (CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight),
                                    this.Width - (CesBorderThickness / 2) - 1,
                                    this.Height - (CesBorderThickness / 2) - CesBorderRadius);

                                // Bottom-Right Arc
                                gpTitle.AddArc(new Rectangle(
                                    this.Width - CesBorderRadius - (CesBorderThickness / 2) - 1,
                                    this.Height - CesBorderRadius - (CesBorderThickness / 2) - 1,
                                    CesBorderRadius,
                                    CesBorderRadius),
                                    0, 90);

                                // Bottom-Left Arc
                                gpTitle.AddArc(new Rectangle(
                                    (CesBorderThickness / 2) + 1,
                                    this.Height - CesBorderRadius - (CesBorderThickness / 2) - 1,
                                    CesBorderRadius,
                                    CesBorderRadius),
                                    90, 90);
                            }

                            // Draw Title And Fill Path
                            using (var sbTitle = new SolidBrush(CesHasNotification ? CesNotificationColor : CesBorderColor))
                            {
                                gpTitle.CloseFigure();

                                if (CesTitleBackground)
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
                        if (CesShowIcon && CesIcon is not null)
                        {
                            RectangleF iconDestinationRect = new RectangleF();

                            if (CesTitlePosition == CesTitlePositionEnum.Left)
                            {
                                iconDestinationRect = new RectangleF(
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (CesBorderThickness * 2) + this.Margin.Left :
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? ((CesTitleAutoWidth ? CesIcon.Width : CesTitleWidth) / 2) - (CesIcon.Width / 2) :
                                    (CesTitleAutoWidth ? CesIcon.Width : CesTitleWidth) - CesIcon.Width - (CesBorderThickness * 2),
                                    (this.Height / 2) - (CesIcon.Height / 2),
                                    CesIcon.Width,
                                    CesIcon.Height);
                            }

                            if (CesTitlePosition == CesTitlePositionEnum.Right)
                            {
                                iconDestinationRect = new RectangleF(
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? this.Width - (CesTitleAutoWidth ? CesIcon.Width : CesTitleWidth) + (CesBorderThickness * 2) :
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? this.Width - ((CesTitleAutoWidth ? CesIcon.Width : CesTitleWidth) / 2) - (CesIcon.Width / 2) :
                                    this.Width - CesIcon.Width - (CesBorderThickness * 2) - this.Margin.Right,
                                    (this.Height / 2) - (CesIcon.Height / 2),
                                    CesIcon.Width,
                                    CesIcon.Height);
                            }

                            if (CesTitlePosition == CesTitlePositionEnum.Top)
                            {
                                iconDestinationRect = new RectangleF(
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (CesBorderThickness * 2) + this.Margin.Left :
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (this.Width / 2) - (CesIcon.Width / 2) :
                                    this.Width - CesIcon.Width - (CesBorderThickness * 2) - this.Margin.Right,
                                    ((CesBorderRadius + (CesTitleAutoHeight ? CesIcon.Height : CesTitleHeight)) / 2) - (CesIcon.Height / 2),
                                    CesIcon.Width,
                                    CesIcon.Height);
                            }

                            if (CesTitlePosition == CesTitlePositionEnum.Bottom)
                            {
                                iconDestinationRect = new RectangleF(
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (CesBorderThickness * 2) + this.Margin.Left :
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (this.Width / 2) - (CesIcon.Width / 2) :
                                    this.Width - CesIcon.Width - (CesBorderThickness * 2) - this.Margin.Right,
                                    this.Height - ((CesBorderRadius + (CesTitleAutoHeight ? CesIcon.Height : CesTitleHeight)) / 2) - (CesIcon.Height / 2),
                                    CesIcon.Width,
                                    CesIcon.Height);
                            }

                            g.DrawImage(
                                CesIcon,
                                iconDestinationRect,
                                new RectangleF(0, 0, CesIcon.Width, CesIcon.Height),
                                GraphicsUnit.Pixel);

                            return; // Not need to draw string if ShowIcon = true
                        }

                        // Draw Title Text
                        var titleRect = new RectangleF();

                        if (CesTitlePosition == CesTitlePositionEnum.Left)
                        {
                            titleRect = new RectangleF(
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (CesBorderThickness * 2) + this.Margin.Left :
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? ((CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth) / 2) - (_titleTextSize.Width / 2) :
                                    (CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth) - _titleTextSize.Width - (CesBorderThickness * 2),
                                    (this.Height / 2) - (_titleTextSize.Height / 2),
                                    _titleTextSize.Width,
                                    _titleTextSize.Height);
                        }

                        if (CesTitlePosition == CesTitlePositionEnum.Right)
                        {
                            titleRect = new RectangleF(
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? this.Width - (CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth) + (CesBorderThickness * 2) :
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? this.Width - ((CesTitleAutoWidth ? _titleTextSize.Width : CesTitleWidth) / 2) - (_titleTextSize.Width / 2) :
                                    this.Width - _titleTextSize.Width - (CesBorderThickness * 2) - this.Margin.Right,
                                    (this.Height / 2) - (_titleTextSize.Height / 2),
                                    _titleTextSize.Width,
                                    _titleTextSize.Height);
                        }

                        if (CesTitlePosition == CesTitlePositionEnum.Top)
                        {
                            titleRect = new RectangleF(
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (CesBorderThickness * 2) + this.Margin.Left :
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (this.Width / 2) - (_titleTextSize.Width / 2) :
                                    this.Width - _titleTextSize.Width - (CesBorderThickness * 2) - this.Margin.Right,
                                    ((CesBorderRadius + (CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight)) / 2) - (_titleTextSize.Height / 2),
                                    _titleTextSize.Width,
                                    _titleTextSize.Height);
                        }

                        if (CesTitlePosition == CesTitlePositionEnum.Bottom)
                        {
                            titleRect = new RectangleF(
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (CesBorderThickness * 2) + this.Margin.Left :
                                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (this.Width / 2) - (_titleTextSize.Width / 2) :
                                    this.Width - _titleTextSize.Width - (CesBorderThickness * 2) - this.Margin.Right,
                                    this.Height - ((CesBorderRadius + (CesTitleAutoHeight ? _titleTextSize.Height : CesTitleHeight)) / 2) - (_titleTextSize.Height / 2),
                                    _titleTextSize.Width,
                                    _titleTextSize.Height);
                        }

                        g.DrawString(
                            CesTitleText,
                            CesTitleFont,
                            new SolidBrush(CesTitleTextColor),
                            titleRect);
                    }
                }

                return;
            }
        }
    }

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

    public partial class CesControlBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }
}
