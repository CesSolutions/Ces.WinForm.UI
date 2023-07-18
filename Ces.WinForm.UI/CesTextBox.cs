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
            _initialControlHeight = this.Height;
            ArrangeControls();
        }

        private int _initialControlHeight { get; set; }
        private SizeF _titleTextSize { get; set; }


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
                ArrangeControls();
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
            CesTextBoxAlignmentEnum.CenterToEdge;
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

                if (!value)
                    this.Height = _initialControlHeight;

                ArrangeControls();
            }
        }


        private bool cesTitleAreaAutoLength { get; set; }
        public bool CesTitleAreaAutoLength
        {
            get { return cesTitleAreaAutoLength; }
            set
            {
                cesTitleAreaAutoLength = value;
                ArrangeControls();
            }
        }


        private CesTextBoxTitleTypeEnum cesTitleType { get; set; } = CesTextBoxTitleTypeEnum.OnTop;
        public CesTextBoxTitleTypeEnum CesTitleType
        {
            get { return cesTitleType; }
            set
            {
                cesTitleType = value;
                ArrangeControls();
            }
        }


        private int cesTitleAreaLength { get; set; } = 80;
        public int CesTitleAreaLength
        {
            get { return cesTitleAreaLength; }
            set
            {
                cesTitleAreaLength = value;
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

                // Draw Border
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
                            this.lblTitle.BackColor = this.txtTextBox.Focused ? cesFocusColor : cesBackColor;

                            gp.CloseFigure();
                            g.FillPath(sb, gp);
                        }

                        g.DrawPath(p, gp);
                    }
                }

                // Draw Title Area
                if (cesShowTitle && cesTitleType == CesTextBoxTitleTypeEnum.Inside)
                {
                    using (var gpTitleArea = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        using (var pTitleArea = new Pen(cesBorderColor, cesBorderThickness))
                        {
                            _titleTextSize = g.MeasureString(cesTitleText, lblTitle.Font);

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
                                cesTitleAreaAutoLength ? _titleTextSize.Width : cesTitleAreaLength,
                                (cesBorderThickness / 2) + 1);

                            // Right Line
                            gpTitleArea.AddLine(
                                cesTitleAreaAutoLength ? _titleTextSize.Width : cesTitleAreaLength,
                                (cesBorderThickness / 2) + 1,
                                cesTitleAreaAutoLength ? _titleTextSize.Width : cesTitleAreaLength,
                                this.Height - (cesBorderThickness / 2));

                            // Bottom Line
                            gpTitleArea.AddLine(
                                cesTitleAreaAutoLength ? _titleTextSize.Width : cesTitleAreaLength,
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

                            using (var sbTitleArea = new SolidBrush(cesBorderColor))
                            {
                                gpTitleArea.CloseFigure();
                                g.FillPath(sbTitleArea, gpTitleArea);

                                g.DrawString(
                                    cesTitleText,
                                    lblTitle.Font,
                                    new SolidBrush(Color.White),
                                    new RectangleF(cesBorderThickness * 2,
                                    (this.Height / 2) - (_titleTextSize.Height / 2),
                                    (cesTitleAreaAutoLength ? _titleTextSize.Width + (cesBorderThickness * 2) : cesTitleAreaLength) - (cesBorderThickness * 2),
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

        private void ArrangeControls()
        {
            using(var g = this.CreateGraphics())
            {
                _titleTextSize = g.MeasureString(cesTitleText, lblTitle.Font);
            }

            // Set lblTitle visibility
            if (cesShowTitle & cesTitleType == CesTextBoxTitleTypeEnum.OnTop)
            {
                lblTitle.Visible = true;
            }
            else
            {
                lblTitle.Visible = false;
            }


            // Auto Height
            if (cesAutoHeight)
                this.Height =
                    (cesShowTitle && cesTitleType == CesTextBoxTitleTypeEnum.OnTop) ?
                    lblTitle.Height + txtTextBox.Height + this.Margin.Top + this.Margin.Bottom + (cesBorderThickness * 4) :
                    txtTextBox.Height + this.Margin.Top + this.Margin.Bottom + (cesBorderThickness * 4);


            // Show Title
            if (cesShowTitle & cesTitleType == CesTextBoxTitleTypeEnum.OnTop)
            {
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


            // Show TextBox
            this.txtTextBox.Width =
                this.Width -
                (cesBorderThickness * 4) -
                this.Padding.Left -
                this.Padding.Right -
                ((cesShowTitle && cesTitleType == CesTextBoxTitleTypeEnum.Inside) ? (cesTitleAreaAutoLength ? (int)_titleTextSize.Width : cesTitleAreaLength) : 0);

            if (cesTextBoxAlignment == CesTextBoxAlignmentEnum.CenterToEdge)
            {
                this.txtTextBox.Location = new Point(
                    ((this.Width -
                    ((cesShowTitle && cesTitleType == CesTextBoxTitleTypeEnum.Inside) ? (cesTitleAreaAutoLength ? (int)_titleTextSize.Width : cesTitleAreaLength) : 0)) / 2) -
                    (this.txtTextBox.Width / 2) +
                    ((cesShowTitle && cesTitleType == CesTextBoxTitleTypeEnum.Inside) ? (cesTitleAreaAutoLength ? (int)_titleTextSize.Width : cesTitleAreaLength) : 0),
                    (cesShowTitle && cesTitleType == CesTextBoxTitleTypeEnum.OnTop) ?
                    (this.Height / 2) + cesBorderThickness :
                    (this.Height / 2) - (this.txtTextBox.Height / 2));
            }

            if (cesTextBoxAlignment == CesTextBoxAlignmentEnum.EdgeToCenter)
            {
                this.txtTextBox.Location = new Point(
                    ((this.Width - ((cesShowTitle && cesTitleType == CesTextBoxTitleTypeEnum.Inside) ? (cesTitleAreaAutoLength ? (int)_titleTextSize.Width : cesTitleAreaLength) : 0)) / 2) -
                    (this.txtTextBox.Width / 2) +
                    ((cesShowTitle && cesTitleType == CesTextBoxTitleTypeEnum.Inside) ? (cesTitleAreaAutoLength ? (int)_titleTextSize.Width : cesTitleAreaLength) : 0),
                    (cesShowTitle && cesTitleType == CesTextBoxTitleTypeEnum.OnTop) ?
                    this.Height - txtTextBox.Height - (cesBorderThickness * 2) :
                    (this.Height / 2) - (this.txtTextBox.Height / 2));
            }

            Redraw();
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

    public enum CesTextBoxTitleTypeEnum
    {
        OnTop,
        Inside,
    }
}
