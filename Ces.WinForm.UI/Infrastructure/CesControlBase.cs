﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.Infrastructure
{
    [ToolboxItem(false)]
    public partial class CesControlBase : UserControl
    {
        public CesControlBase()
        {
            CesTitleFont = this.Font;
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private Graphics g;

        private int OffsetFromEdge = 1;

        [System.ComponentModel.Browsable(false)]
        public Control ChildContainer { get; set; } // value shall be set in constructor of inherited class

        [System.ComponentModel.Browsable(false)]
        public int _initialControlHeight { get; set; } = 0;


        #region "Ces Focus Options"

        public bool cesHasFocus = false;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Focus Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool CesHasFocus
        {
            get { return cesHasFocus; }
            set
            {
                cesHasFocus = value;
                ApplyPropertyValue();
            }
        }

        private Color cesFocusColor { get; set; } = Color.Beige;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Focus Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public Color CesFocusColor
        {
            get { return cesFocusColor; }
            set
            {
                cesFocusColor = value;
                ApplyPropertyValue();
            }
        }

        #endregion "Ces Focus Options"

        #region "Ces Border Options"

        private System.Windows.Forms.Padding cesPadding = new Padding(5);
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
            }
        }

        private Color cesBackColor = Color.White;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.NotifyParentProperty(true)]
        [System.ComponentModel.Category("Ces Border Options")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public virtual Color CesBackColor
        {
            get { return cesBackColor; }
            set
            {
                cesBackColor = value;
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                cesBorderRadius = value < 0 ? 0 : value;
                ApplyPropertyValue();
            }
        }

        #endregion"Ces Border Options"

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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
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
                ApplyPropertyValue();
            }
        }


        private int cesTitleHeight = 25;
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
                ApplyPropertyValue();
            }
        }

        #endregion "Ces Title Options"

        #region "Custom Methods"

        public void SetPadding()
        {
            //using var g = this.CreateGraphics();

            _titleTextSize = g.MeasureString(CesTitleText, CesTitleFont);

            if (CesTitlePosition == CesTitlePositionEnum.Top)
                CesPadding = new Padding(
                    CesBorderThickness,
                    (CesShowTitle ? CesTitleHeight : CesBorderThickness) + CesBorderRadius,
                    CesBorderThickness,
                    CesBorderThickness);

            if (CesTitlePosition == CesTitlePositionEnum.Right)
                CesPadding = new Padding(
                    CesBorderThickness,
                    CesBorderThickness,
                    (int)((CesShowTitle ? _titleTextSize.Width : CesBorderThickness) + CesBorderThickness),
                    CesBorderThickness);

            if (CesTitlePosition == CesTitlePositionEnum.Bottom)
                CesPadding = new Padding(
                    CesBorderThickness,
                    CesBorderThickness,
                    CesBorderThickness,
                    (CesShowTitle ? CesTitleHeight : CesBorderThickness) + CesBorderRadius);

            if (CesTitlePosition == CesTitlePositionEnum.Left)
                CesPadding = new Padding(
                    (int)((CesShowTitle ? _titleTextSize.Width : CesBorderThickness) + CesBorderThickness),
                    CesBorderThickness,
                    CesBorderThickness,
                    CesBorderThickness);
        }

        public void ApplyPropertyValue()
        {
            this.Invalidate();
            ArrangeControls();
        }

        public void ArrangeControls()
        {
            if (ChildContainer == null)
                return;

            SetChildContainerWidth();
            SetChildContainerHeight();
            LocateChildContainer();
        }

        private void SetChildContainerWidth()
        {
            if (!CesShowTitle)
            {
                ChildContainer.Width = this.Width - CesPadding.Left - CesPadding.Right - (CesBorderThickness * 2);
                return;
            }

            // Set Width  Postion According to [Title Position = Top/Bottom]
            if (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top
                || CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Bottom)
                ChildContainer.Width =
                    this.Width -
                    CesPadding.Left -
                    CesPadding.Right -
                    (CesBorderThickness * 2);

            // Set Width Postion According to [Title Position = Left/Right]
            if (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left
                || CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right)
                ChildContainer.Width =
                    this.Width -
                    CesPadding.Left -
                    CesPadding.Right -
                    (CesBorderThickness * 2) -
                    CesTitleWidth;
        }

        private void SetChildContainerHeight()
        {
            if (!CesShowTitle)
            {
                ChildContainer.Height = this.Height - CesPadding.Top - CesPadding.Bottom - (CesBorderThickness * 2);
                return;
            }

            // Set Height Postion According to [Title Position = Top/Bottom]
            if (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top
                || CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Bottom)
                ChildContainer.Height =
                    this.Height -
                    CesPadding.Top -
                    CesPadding.Bottom -
                    (CesBorderThickness * 2) -
                    (CesTitleHeight * 2);

            // Set Height Postion According to [Title Position = Left/Right]
            if (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left
                || CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right)
                ChildContainer.Height =
                    this.Height -
                    CesPadding.Top -
                    CesPadding.Bottom -
                    (CesBorderThickness * 2);
        }

        private void LocateChildContainer()
        {
            if (!CesShowTitle)
            {
                ChildContainer.Top = (this.Height / 2) - (this.Controls[0].Height / 2);
                ChildContainer.Left = (this.Width / 2) - (this.Controls[0].Width / 2);
                return;
            }

            // Set Left & Top Postion According to Title Position = Top
            if (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top)
            {
                ChildContainer.Left =
                    CesPadding.Left +
                    CesBorderThickness;

                ChildContainer.Top =
                    CesPadding.Top +
                    (CesBorderThickness * 2) +
                    (CesTitleHeight * 2);

                return;
            }

            // Set Left & Top Postion According to Title Position = Bottom
            if (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Bottom)
            {
                ChildContainer.Left =
                    CesPadding.Left +
                    CesBorderThickness;

                ChildContainer.Top =
                    CesPadding.Top +
                    (CesBorderThickness * 2);
            }

            // Set Left & TopPostion According to Title Position = Right
            if (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right)
            {
                ChildContainer.Left =
                    CesPadding.Left +
                    CesBorderThickness;

                ChildContainer.Top =
                    CesPadding.Top +
                    (CesBorderThickness * 2);
            }

            // Set Left & TopPostion According to Title Position = Left
            if (CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left)
            {
                ChildContainer.Left =
                    CesPadding.Left +
                    CesBorderThickness +
                    CesTitleWidth;

                ChildContainer.Top =
                    CesPadding.Top +
                    (CesBorderThickness * 2);
            }
        }

        public void GenerateBorder(Control control)
        {
            if (ChildContainer != null)
                ChildContainer.BackColor = CesHasFocus ? CesFocusColor : CesBackColor;

            SetGraphicOptions();
            DrawBorder();
            DrawTitle();
        }

        private void SetGraphicOptions()
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void DrawBorder()
        {
            if (CesBorderRadius == 0)
                DrawRectangularBorder();
            else
                DrawRoundedBorder();
        }

        private void DrawRectangularBorder()
        {
            g.FillRectangle(new SolidBrush(CesBackColor), this.ClientRectangle);

            using var pBorder =
                new Pen(CesHasNotification ?
                CesNotificationColor :
                CesBorderColor,
                CesBorderThickness);

            var rectagle = new Rectangle
            (
                CesBorderThickness / 2,
                CesBorderThickness / 2,
                this.Width - CesBorderThickness,
                this.Height - CesBorderThickness
            );

            g.DrawRectangle(pBorder, rectagle);
        }

        private void DrawRoundedBorder()
        {
            using var gpBorder = new System.Drawing.Drawing2D.GraphicsPath();

            using var pBorder =
                new Pen(CesHasNotification ?
                CesNotificationColor :
                CesBorderColor,
                CesBorderThickness);

            // Top-Left Arc
            gpBorder.AddArc(new Rectangle(
                CesBorderThickness / 2,
                CesBorderThickness / 2,
                CesBorderRadius,
                CesBorderRadius),
                180, 90);

            // Top-Right Arc
            gpBorder.AddArc(new Rectangle(
                this.Width - CesBorderRadius - (CesBorderThickness / 2) - OffsetFromEdge,
                CesBorderThickness / 2,
                CesBorderRadius,
                CesBorderRadius),
                270, 90);

            // Bottom-Right Arc
            gpBorder.AddArc(new Rectangle(
                this.Width - CesBorderRadius - (CesBorderThickness / 2) - OffsetFromEdge,
                this.Height - CesBorderRadius - (CesBorderThickness / 2) - OffsetFromEdge,
                CesBorderRadius,
                CesBorderRadius),
                0, 90);

            // Bottom-Left Arc
            gpBorder.AddArc(new Rectangle(
                CesBorderThickness / 2,
                this.Height - CesBorderRadius - (CesBorderThickness / 2) - OffsetFromEdge,
                CesBorderRadius,
                CesBorderRadius),
                90, 90);

            using (var sb = new SolidBrush(CesHasFocus ? CesFocusColor : CesBackColor))
            {
                gpBorder.CloseFigure();
                g.FillPath(sb, gpBorder);
            }

            g.DrawPath(pBorder, gpBorder);
        }

        private void DrawTitle()
        {
            if (!CesShowTitle)
                return;

            DrawTitleArea();
            DrawTitleIcon();
            DrawTitleText();
        }

        private void DrawTitleArea()
        {
            if (CesBorderRadius == 0)
                DrawRectangularTitleArea();
            else
                DrawRoundedTitleArea();
        }

        private void DrawRectangularTitleArea()
        {
            using var sbBorder = new SolidBrush(CesBorderColor);

            if (CesTitlePosition == CesTitlePositionEnum.Left)
                g.FillRectangle(sbBorder, new Rectangle(CesBorderThickness - OffsetFromEdge, CesBorderThickness - OffsetFromEdge, CesTitleWidth, this.Height - (CesBorderThickness * 2) + (OffsetFromEdge * 2)));

            if (CesTitlePosition == CesTitlePositionEnum.Right)
                g.FillRectangle(sbBorder, new Rectangle(this.Width - CesBorderThickness - CesTitleWidth + OffsetFromEdge, CesBorderThickness - OffsetFromEdge, CesTitleWidth, this.Height - (CesBorderThickness * 2) + (OffsetFromEdge * 2)));

            if (CesTitlePosition == CesTitlePositionEnum.Top)
                g.FillRectangle(sbBorder, new Rectangle(CesBorderThickness - OffsetFromEdge, CesBorderThickness - OffsetFromEdge, this.Width - (CesBorderThickness * 2) + (OffsetFromEdge * 2), CesTitleHeight));

            if (CesTitlePosition == CesTitlePositionEnum.Bottom)
                g.FillRectangle(sbBorder, new Rectangle(CesBorderThickness - OffsetFromEdge, this.Height - CesBorderThickness - CesTitleHeight + OffsetFromEdge, this.Width - (CesBorderThickness * 2) + (OffsetFromEdge * 2), CesTitleHeight));
        }

        private void DrawRoundedTitleArea()
        {
            _titleTextSize = g.MeasureString(CesTitleText, CesTitleFont);

            using var gpTitle = new System.Drawing.Drawing2D.GraphicsPath();

            // Draw title area
            //using var pTitle = new Pen(CesBorderColor, CesBorderThickness);
            using var pTitle = new Pen(Color.Green, CesBorderThickness);

            // Define Title Path
            if (CesTitlePosition == CesTitlePositionEnum.Left)
            {
                // Top-Left Arc
                gpTitle.AddArc(new Rectangle(
                    0,
                    0,
                    CesBorderRadius,
                    CesBorderRadius),
                    180, 90);

                // Top line
                gpTitle.AddLine(
                    0 + CesBorderRadius,
                    0,
                    CesTitleWidth + CesBorderThickness,
                    0);

                // Right Line
                gpTitle.AddLine(
                    CesBorderThickness + CesTitleWidth,
                    0,
                    CesBorderThickness + CesTitleWidth,
                    this.Height);

                // Bottom Line
                gpTitle.AddLine(
                    CesBorderThickness + CesTitleWidth,
                    this.Height,
                    0 + CesBorderRadius,
                    this.Height);

                // Bottom-Left Arc
                gpTitle.AddArc(new Rectangle(
                    0,
                    this.Height - CesBorderRadius,
                    CesBorderRadius,
                    CesBorderRadius),
                    90, 90);
            }

            if (CesTitlePosition == CesTitlePositionEnum.Right)
            {
                // Top line
                gpTitle.AddLine(
                    this.Width - CesTitleWidth - CesBorderThickness,
                    0,
                    this.Width - CesBorderRadius - CesBorderThickness,
                    0);

                // Top-Right Arc
                gpTitle.AddArc(new Rectangle(
                    this.Width - CesBorderRadius,
                    0,
                    CesBorderRadius,
                    CesBorderRadius),
                    270, 90);

                // Bottom-Right Arc
                gpTitle.AddArc(new Rectangle(
                    this.Width - CesBorderRadius,
                    this.Height - CesBorderRadius,
                    CesBorderRadius,
                    CesBorderRadius),
                    0, 90);

                // Bottom line
                gpTitle.AddLine(
                    this.Width - CesBorderRadius,
                    this.Height,
                    this.Width - CesTitleWidth - CesBorderThickness,
                    this.Height);
            }

            if (CesTitlePosition == CesTitlePositionEnum.Top)
            {
                // Top-Left Arc
                gpTitle.AddArc(new Rectangle(
                    0,
                    0,
                    CesBorderRadius,
                    CesBorderRadius),
                    180, 90);

                // Top-Right Arc
                gpTitle.AddArc(new Rectangle(
                    this.Width - CesBorderRadius,
                    0,
                    CesBorderRadius,
                    CesBorderRadius),
                    270, 90);

                // Right Line
                gpTitle.AddLine(
                    this.Width,
                    CesBorderRadius,
                    this.Width,
                    CesTitleHeight);

                // Bottom Line
                gpTitle.AddLine(
                    this.Width,
                    CesTitleHeight,
                    0,
                    CesTitleHeight);
            }

            if (CesTitlePosition == CesTitlePositionEnum.Bottom)
            {
                // Top Line
                gpTitle.AddLine(
                    0,
                    this.Height - CesTitleHeight,
                    this.Width,
                    this.Height - CesTitleHeight);

                // Right Line
                gpTitle.AddLine(
                    this.Width,
                    this.Height - CesTitleHeight,
                    this.Width,
                    this.Height );

                // Bottom-Right Arc
                gpTitle.AddArc(new Rectangle(
                    this.Width - CesBorderRadius,
                    this.Height - CesBorderRadius,
                    CesBorderRadius,
                    CesBorderRadius),
                    0, 90);

                // Bottom-Left Arc
                gpTitle.AddArc(new Rectangle(
                    0,
                    this.Height - CesBorderRadius,
                    CesBorderRadius,
                    CesBorderRadius),
                    90, 90);
            }

            // Draw Title And Fill Path
            using (var sbTitle = new SolidBrush(CesHasNotification ? CesNotificationColor : CesBorderColor))
            {
                gpTitle.CloseFigure();

                if (CesTitleBackground)
                    g.FillPath(sbTitle, gpTitle);
                else
                    g.DrawPath(pTitle, gpTitle);
            }
        }

        private void DrawTitleIcon()
        {
            if (!CesShowIcon || CesIcon is null)
                return;

            RectangleF iconDestinationRect = new RectangleF();

            if (CesTitlePosition == CesTitlePositionEnum.Left)
                iconDestinationRect = new RectangleF(
                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (CesBorderThickness * 2) + this.Margin.Left :
                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? ((CesTitleAutoWidth ? CesIcon.Width : CesTitleWidth) / 2) - (CesIcon.Width / 2) :
                    (CesTitleAutoWidth ? CesIcon.Width : CesTitleWidth) - CesIcon.Width - (CesBorderThickness * 2),
                    (this.Height / 2) - (CesIcon.Height / 2),
                    CesIcon.Width,
                    CesIcon.Height);


            if (CesTitlePosition == CesTitlePositionEnum.Right)
                iconDestinationRect = new RectangleF(
                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? this.Width - (CesTitleAutoWidth ? CesIcon.Width : CesTitleWidth) + (CesBorderThickness * 2) :
                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? this.Width - ((CesTitleAutoWidth ? CesIcon.Width : CesTitleWidth) / 2) - (CesIcon.Width / 2) :
                    this.Width - CesIcon.Width - (CesBorderThickness * 2) - this.Margin.Right,
                    (this.Height / 2) - (CesIcon.Height / 2),
                    CesIcon.Width,
                    CesIcon.Height);


            if (CesTitlePosition == CesTitlePositionEnum.Top)
                iconDestinationRect = new RectangleF(
                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (CesBorderThickness * 2) + this.Margin.Left :
                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (this.Width / 2) - (CesIcon.Width / 2) :
                    this.Width - CesIcon.Width - (CesBorderThickness * 2) - this.Margin.Right,
                    ((CesBorderRadius + (CesTitleAutoHeight ? CesIcon.Height : CesTitleHeight)) / 2) - (CesIcon.Height / 2),
                    CesIcon.Width,
                    CesIcon.Height);


            if (CesTitlePosition == CesTitlePositionEnum.Bottom)
                iconDestinationRect = new RectangleF(
                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (CesBorderThickness * 2) + this.Margin.Left :
                    CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (this.Width / 2) - (CesIcon.Width / 2) :
                    this.Width - CesIcon.Width - (CesBorderThickness * 2) - this.Margin.Right,
                    this.Height - ((CesBorderRadius + (CesTitleAutoHeight ? CesIcon.Height : CesTitleHeight)) / 2) - (CesIcon.Height / 2),
                    CesIcon.Width,
                    CesIcon.Height);


            g.DrawImage(
                CesIcon,
                iconDestinationRect,
                new RectangleF(0, 0, CesIcon.Width, CesIcon.Height),
                GraphicsUnit.Pixel);
        }

        private void DrawTitleText()
        {
            // No need to draw string if [ShowIcon = true]
            if (CesShowIcon)
                return;

            var titleRect = new RectangleF();
            var titleTextMargin = 2;

            if (CesTitlePosition == CesTitlePositionEnum.Left)
            {
                titleRect = new RectangleF(
                        CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? CesBorderThickness + titleTextMargin :
                        CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? CesBorderThickness + (CesTitleWidth / 2) - (_titleTextSize.Width / 2) :
                        CesBorderThickness + CesTitleWidth - _titleTextSize.Width - titleTextMargin,
                        (this.Height / 2) - (_titleTextSize.Height / 2),
                        _titleTextSize.Width,
                        _titleTextSize.Height);
            }

            if (CesTitlePosition == CesTitlePositionEnum.Right)
            {
                titleRect = new RectangleF(
                        CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? this.Width - CesTitleWidth - CesBorderThickness + titleTextMargin :
                        CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? this.Width - CesTitleWidth - CesBorderThickness + ((CesTitleWidth / 2) - (_titleTextSize.Width / 2)) :
                        this.Width - CesBorderThickness - _titleTextSize.Width - titleTextMargin,
                        (this.Height / 2) - (_titleTextSize.Height / 2),
                        _titleTextSize.Width,
                        _titleTextSize.Height);
            }

            if (CesTitlePosition == CesTitlePositionEnum.Top)
            {
                titleRect = new RectangleF(
                        CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? CesBorderThickness + titleTextMargin :
                        CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (this.Width / 2) - (_titleTextSize.Width / 2) :
                        this.Width - CesBorderThickness - _titleTextSize.Width + titleTextMargin,
                        CesBorderThickness + (CesTitleHeight / 2) - (_titleTextSize.Height / 2),
                        _titleTextSize.Width,
                        _titleTextSize.Height);
            }

            if (CesTitlePosition == CesTitlePositionEnum.Bottom)
            {
                titleRect = new RectangleF(
                        CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? CesBorderThickness + titleTextMargin :
                        CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (this.Width / 2) - (_titleTextSize.Width / 2) :
                        this.Width - CesBorderThickness - _titleTextSize.Width + titleTextMargin,
                        this.Height - CesBorderThickness - (CesTitleHeight / 2) - (_titleTextSize.Height / 2),
                        _titleTextSize.Width,
                        _titleTextSize.Height);
            }

            g.DrawString(
                CesTitleText,
                CesTitleFont,
                new SolidBrush(CesTitleTextColor),
                titleRect);
        }

        #endregion "Methods"

        #region Override Methods

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ArrangeControls();
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            ArrangeControls();
        }

        #endregion Override Region
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
