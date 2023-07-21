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
        #region CesTextBox Constructors

        public CesTextBox()
        {
            InitializeComponent();
            initialControlHeight = this.Height;
            CesTitleFont = this.Font;
            ArrangeControls();
        }

        #endregion CesTextBox Constructors

        #region CesTextBox Fields

        public int initialControlHeight { get; set; }
        private SizeF _titleTextSize { get; set; }

        #endregion CesTextBox Fields

        #region CesTextBox Property

        private bool cesHasNotification { get; set; }
        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesHasNotification
        {
            get { return cesHasNotification; }
            set
            {
                cesHasNotification = value;
                Redraw();
            }
        }

        private Color cesNotificationColor { get; set; } = Color.Red;
        [System.ComponentModel.Category("CesTextBox Title")]
        public Color CesNotificationColor
        {
            get { return cesNotificationColor; }
            set
            {
                cesNotificationColor = value;
                Redraw();
            }
        }


        private bool cesAutoHeight { get; set; } = true;
        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesAutoHeight
        {
            get { return cesAutoHeight; }
            set
            {
                cesAutoHeight = value;

                if (!value)
                    this.Height = initialControlHeight;

                ArrangeControls();
            }
        }


        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.EditorBrowsable]
        [System.ComponentModel.Category("CesTextBox Title")]
        public TextBox CesTextBoxControl { get { return txtTextBox; } }


        private Color cesBackColor { get; set; } = Color.White;
        [System.ComponentModel.Category("CesTextBox")]
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
        [System.ComponentModel.Category("CesTextBox")]
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
        [System.ComponentModel.Category("CesTextBox")]
        public int CesBorderThickness
        {
            get { return cesBorderThickness; }
            set
            {
                cesBorderThickness = value;
                ArrangeControls();
            }
        }


        private int cesBorderRadius { get; set; } = 15;
        [System.ComponentModel.Category("CesTextBox")]
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
        [System.ComponentModel.Category("CesTextBox")]
        public Color CesFocusColor
        {
            get { return cesFocusColor; }
            set
            {
                cesFocusColor = value;
                Redraw();
            }
        }

        #endregion CesTextBox Property

        #region CesTextBox Title Property

        private bool cesShowTitle { get; set; }
        [System.ComponentModel.Category("CesTextBox Title")]
        public bool CesShowTitle
        {
            get { return cesShowTitle; }
            set
            {
                cesShowTitle = value;
                ArrangeControls();
            }
        }


        private Font cesTitleFont { get; set; }
        public Font CesTitleFont
        {
            get { return cesTitleFont; }
            set
            {
                cesTitleFont = value;
                Redraw();
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
                Redraw();
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
                ArrangeControls();
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
                ArrangeControls();
            }
        }


        private CesTitleTextAlignmentEnum cesTitleTextAlignment { get; set; }
            = CesTitleTextAlignmentEnum.Center;
        [System.ComponentModel.Category("CesTextBox Title")]
        public CesTitleTextAlignmentEnum CesTitleTextAlignment
        {
            get
            {
                return cesTitleTextAlignment;
            }
            set
            {
                cesTitleTextAlignment = value;
                Redraw();
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
                ArrangeControls();
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
                ArrangeControls();
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
                ArrangeControls();
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
                ArrangeControls();
            }
        }

        #endregion CesTextBox Title Property

        #region CesTextBox Methods
        private void CesTextBox_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        private void ArrangeControls()
        {
            using (var g = this.CreateGraphics())
                _titleTextSize = g.MeasureString(cesTitleText, cesTitleFont);

            // Auto Height TextBox Control
            if (cesShowTitle && cesAutoHeight &&
                (cesTitlePosition == CesTitlePositionEnum.Top ||
                cesTitlePosition == CesTitlePositionEnum.Bottom))
                this.Height =
                    txtTextBox.Height +
                    this.Margin.Top +
                    this.Margin.Bottom +
                    (cesBorderThickness * 4) +
                    (int)(cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight) + cesBorderRadius;

            // Set txtTextBox Control Inside UserControl
            this.txtTextBox.Width =
                this.Width -
                this.Padding.Left -
                this.Padding.Right -
                (cesBorderThickness * 4) -
                ((cesShowTitle && (cesTitlePosition == CesTitlePositionEnum.Left || cesTitlePosition == CesTitlePositionEnum.Right)) ?
                (cesTitleAutoWidth ? (int)_titleTextSize.Width : cesTitleWidth) : 0);

            // Normal Top Position
            this.txtTextBox.Top =
                (this.Height / 2) -
                (this.txtTextBox.Height / 2);

            // Set Top Postion According to Title Position = Top
            if (cesShowTitle && cesTitlePosition == CesTitlePositionEnum.Top)
                this.txtTextBox.Top =
                    (this.Height / 2) -
                    (this.txtTextBox.Height / 2) +
                    (int)(cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight);

            // Set Top Postion According to Title Position = Bottom
            if (cesShowTitle && cesTitlePosition == CesTitlePositionEnum.Bottom)
                this.txtTextBox.Top =
                    (this.Height / 2) -
                    (this.txtTextBox.Height / 2) -
                    (int)(cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight);

            // Normal Left Position
            this.txtTextBox.Left =
                (this.Width / 2) -
                (this.txtTextBox.Width / 2);

            // Set txtTextBox Left Position According to Title Position = Left
            if (cesShowTitle && cesTitlePosition == CesTitlePositionEnum.Left)
                this.txtTextBox.Left =
                    (int)(cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth) +
                    (cesBorderThickness * 4);

            // Set txtTextBox Left Position According to Title Position = Right
            if (cesShowTitle && cesTitlePosition == CesTitlePositionEnum.Right)
                this.txtTextBox.Left =
                    (cesBorderThickness * 4);

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

                // Draw Border
                using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    using (var p = new Pen(cesHasNotification ? cesNotificationColor : cesBorderColor, cesBorderThickness))
                    {
                        // Top-Left Arc
                        gp.AddArc(new Rectangle(
                            (cesBorderThickness / 2) + 1,
                            (cesBorderThickness / 2) + 1,
                            cesBorderRadius,
                            cesBorderRadius),
                            180, 90);

                        // Top-Right Arc
                        gp.AddArc(new Rectangle(
                            this.Width - cesBorderRadius - (cesBorderThickness / 2) - 1,
                            (cesBorderThickness / 2) + 1,
                            cesBorderRadius,
                            cesBorderRadius),
                            270, 90);

                        // Bottom-Right Arc
                        gp.AddArc(new Rectangle(
                            this.Width - CesBorderRadius - (cesBorderThickness / 2) - 1,
                            this.Height - CesBorderRadius - (cesBorderThickness / 2) - 1,
                            cesBorderRadius,
                            cesBorderRadius),
                            0, 90);

                        // Bottom-Left Arc
                        gp.AddArc(new Rectangle(
                            (cesBorderThickness / 2) + 1,
                            this.Height - cesBorderRadius - (cesBorderThickness / 2) - 1,
                            cesBorderRadius,
                            cesBorderRadius),
                            90, 90);

                        using (var sb = new SolidBrush(this.txtTextBox.Focused ? cesFocusColor : cesBackColor))
                        {
                            this.txtTextBox.BackColor = this.txtTextBox.Focused ? cesFocusColor : cesBackColor;

                            gp.CloseFigure();
                            g.FillPath(sb, gp);
                        }

                        g.DrawPath(p, gp);
                    }
                }

                // Draw Title Area
                if (cesShowTitle)
                {
                    using (var gpTitleArea = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        using (var pTitleArea = new Pen(cesBorderColor, cesBorderThickness))
                        {
                            if (cesTitlePosition == CesTitlePositionEnum.Left)
                            {
                                // Top-Left Arc
                                gpTitleArea.AddArc(new Rectangle(
                                    (cesBorderThickness / 2) + 1,
                                    (cesBorderThickness / 2) + 1,
                                    cesBorderRadius,
                                    cesBorderRadius),
                                    180, 90);

                                // Top line
                                gpTitleArea.AddLine(
                                    (cesBorderThickness / 2) + 1 + cesBorderRadius,
                                    (cesBorderThickness / 2) + 1,
                                    cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth,
                                    (cesBorderThickness / 2) + 1);

                                // Right Line
                                gpTitleArea.AddLine(
                                    cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth,
                                    (cesBorderThickness / 2) + 1,
                                    cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth,
                                    this.Height - (cesBorderThickness / 2));

                                // Bottom Line
                                gpTitleArea.AddLine(
                                    cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth,
                                    this.Height - (cesBorderThickness / 2) - 1,
                                    (cesBorderThickness / 2) + CesBorderRadius,
                                    this.Height - (cesBorderThickness / 2) - 1);

                                // Bottom-Left Arc
                                gpTitleArea.AddArc(new Rectangle(
                                    (cesBorderThickness / 2) + 1,
                                    this.Height - cesBorderRadius - (cesBorderThickness / 2) - 1,
                                    cesBorderRadius,
                                    cesBorderRadius),
                                    90, 90);
                            }

                            if (cesTitlePosition == CesTitlePositionEnum.Right)
                            {
                                // Top line
                                gpTitleArea.AddLine(
                                    this.Width - (cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth),
                                    (cesBorderThickness / 2) + 1,
                                    this.Width - cesBorderRadius,
                                    (cesBorderThickness / 2) + 1);

                                // Top-Right Arc
                                gpTitleArea.AddArc(new Rectangle(
                                    this.Width - cesBorderRadius - (cesBorderThickness / 2) - 1,
                                    (cesBorderThickness / 2) + 1,
                                    cesBorderRadius,
                                    cesBorderRadius),
                                    270, 90);

                                // Bottom-Right Arc
                                gpTitleArea.AddArc(new Rectangle(
                                    this.Width - CesBorderRadius - (cesBorderThickness / 2) - 1,
                                    this.Height - CesBorderRadius - (cesBorderThickness / 2) - 1,
                                    cesBorderRadius,
                                    cesBorderRadius),
                                    0, 90);

                                // Bottom line
                                gpTitleArea.AddLine(
                                    this.Width - cesBorderRadius,
                                    this.Height - (cesBorderThickness / 2) - 1,
                                    this.Width - (cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth),
                                    this.Height - (cesBorderThickness / 2) - 1);
                            }

                            if (cesTitlePosition == CesTitlePositionEnum.Top)
                            {
                                // Top-Left Arc
                                gpTitleArea.AddArc(new Rectangle(
                                    (cesBorderThickness / 2) + 1,
                                    (cesBorderThickness / 2) + 1,
                                    cesBorderRadius,
                                    cesBorderRadius),
                                    180, 90);

                                // Top-Right Arc
                                gpTitleArea.AddArc(new Rectangle(
                                    this.Width - cesBorderRadius - (cesBorderThickness / 2) - 1,
                                    (cesBorderThickness / 2) + 1,
                                    cesBorderRadius,
                                    cesBorderRadius),
                                    270, 90);

                                // Right Line
                                gpTitleArea.AddLine(
                                    this.Width - (cesBorderThickness / 2) - 1,
                                    (cesBorderThickness / 2) + CesBorderRadius,
                                    this.Width - (cesBorderThickness / 2) - 1,
                                    (cesBorderThickness / 2) + CesBorderRadius + (cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight));

                                // Bottom Line
                                gpTitleArea.AddLine(
                                    this.Width - CesBorderRadius,
                                    (cesBorderThickness / 2) + CesBorderRadius + (cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight),
                                    (cesBorderThickness / 2) + 1,
                                    (cesBorderThickness / 2) + CesBorderRadius + (cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight));
                            }

                            if (cesTitlePosition == CesTitlePositionEnum.Bottom)
                            {
                                // Top Line
                                gpTitleArea.AddLine(
                                    (cesBorderThickness / 2) + 1,
                                    this.Height - (cesBorderThickness / 2) - CesBorderRadius - (cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight),
                                    this.Width - (cesBorderThickness / 2) + 1,
                                    this.Height - (cesBorderThickness / 2) - CesBorderRadius - (cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight));

                                // Right Line
                                gpTitleArea.AddLine(
                                    this.Width - (cesBorderThickness / 2) - 1,
                                    this.Height - (cesBorderThickness / 2) - CesBorderRadius - (cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight),
                                    this.Width - (cesBorderThickness / 2) - 1,
                                    this.Height - (cesBorderThickness / 2) - CesBorderRadius);

                                // Bottom-Right Arc
                                gpTitleArea.AddArc(new Rectangle(
                                    this.Width - CesBorderRadius - (cesBorderThickness / 2) - 1,
                                    this.Height - CesBorderRadius - (cesBorderThickness / 2) - 1,
                                    cesBorderRadius,
                                    cesBorderRadius),
                                    0, 90);

                                // Bottom-Left Arc
                                gpTitleArea.AddArc(new Rectangle(
                                    (cesBorderThickness / 2) + 1,
                                    this.Height - cesBorderRadius - (cesBorderThickness / 2) - 1,
                                    cesBorderRadius,
                                    cesBorderRadius),
                                    90, 90);
                            }

                            // Draw Title Text
                            using (var sbTitleArea = new SolidBrush(cesHasNotification ? cesNotificationColor : cesBorderColor))
                            {
                                gpTitleArea.CloseFigure();
                                g.FillPath(sbTitleArea, gpTitleArea);

                                if (cesTitlePosition == CesTitlePositionEnum.Left)
                                    g.DrawString(
                                        cesTitleText,
                                        cesTitleFont,
                                        new SolidBrush(cesTitleTextColor),
                                        new RectangleF(
                                            cesTitleTextAlignment == CesTitleTextAlignmentEnum.Left ? (cesBorderThickness * 2) + this.Margin.Left :
                                            cesTitleTextAlignment == CesTitleTextAlignmentEnum.Center ? ((cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth) / 2) - (_titleTextSize.Width / 2) :
                                            (cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth) - _titleTextSize.Width - (cesBorderThickness * 2),
                                            (this.Height / 2) - (_titleTextSize.Height / 2),
                                            _titleTextSize.Width,
                                            _titleTextSize.Height));

                                if (cesTitlePosition == CesTitlePositionEnum.Right)
                                    g.DrawString(
                                        cesTitleText,
                                        cesTitleFont,
                                        new SolidBrush(cesTitleTextColor),
                                        new RectangleF(
                                            cesTitleTextAlignment == CesTitleTextAlignmentEnum.Left ? this.Width - (cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth) + (cesBorderThickness * 2) :
                                            cesTitleTextAlignment == CesTitleTextAlignmentEnum.Center ? this.Width - ((cesTitleAutoWidth ? _titleTextSize.Width : cesTitleWidth) / 2) - (_titleTextSize.Width / 2) :
                                            this.Width - _titleTextSize.Width - (cesBorderThickness * 2) - this.Margin.Right,
                                            (this.Height / 2) - (_titleTextSize.Height / 2),
                                            _titleTextSize.Width,
                                            _titleTextSize.Height));

                                if (cesTitlePosition == CesTitlePositionEnum.Top)
                                    g.DrawString(
                                        cesTitleText,
                                        cesTitleFont,
                                        new SolidBrush(cesTitleTextColor),
                                        new RectangleF(
                                            cesTitleTextAlignment == CesTitleTextAlignmentEnum.Left ? (cesBorderThickness * 2) + this.Margin.Left :
                                            cesTitleTextAlignment == CesTitleTextAlignmentEnum.Center ? (this.Width / 2) - (_titleTextSize.Width / 2) :
                                            this.Width - _titleTextSize.Width - (cesBorderThickness * 2) - this.Margin.Right,
                                            ((cesBorderRadius + (cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight)) / 2) - (_titleTextSize.Height / 2),
                                            _titleTextSize.Width,
                                            _titleTextSize.Height));

                                if (cesTitlePosition == CesTitlePositionEnum.Bottom)
                                    g.DrawString(
                                        cesTitleText,
                                        cesTitleFont,
                                        new SolidBrush(cesTitleTextColor),
                                        new RectangleF(
                                            cesTitleTextAlignment == CesTitleTextAlignmentEnum.Left ? (cesBorderThickness * 2) + this.Margin.Left :
                                            cesTitleTextAlignment == CesTitleTextAlignmentEnum.Center ? (this.Width / 2) - (_titleTextSize.Width / 2) :
                                            this.Width - _titleTextSize.Width - (cesBorderThickness * 2) - this.Margin.Right,
                                            this.Height - ((cesBorderRadius + (cesTitleAutoHeight ? _titleTextSize.Height : cesTitleHeight)) / 2) - (_titleTextSize.Height / 2),
                                            _titleTextSize.Width,
                                            _titleTextSize.Height));
                            }
                        }
                    }
                }
            }
        }

        private void CesTextBox_Resize(object sender, EventArgs e)
        {
            ArrangeControls();
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
            ArrangeControls();
        }

        private void CesTextBox_Load(object sender, EventArgs e)
        {

        }
        #endregion CesTextBox Methods

        private void CesTextBox_SizeChanged(object sender, EventArgs e)
        {
            initialControlHeight = this.Height;
        }
    }

    public enum CesTitlePositionEnum
    {
        Top,
        Right,
        Bottom,
        Left,
    }

    public enum CesTitleTextAlignmentEnum
    {
        Left,
        Center,
        Right,
    }
}
