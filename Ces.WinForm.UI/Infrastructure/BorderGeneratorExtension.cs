using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.Infrastructure
{
    //public enum CesTitlePositionEnum
    //{
    //    Top,
    //    Right,
    //    Bottom,
    //    Left,
    //}


    ///// <summary>
    ///// Title content can be text or image
    ///// </summary>
    //public enum CesTitleContentAlignmentEnum
    //{
    //    Left,
    //    Center,
    //    Right,
    //}

    //[System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    //[System.ComponentModel.Category("Ces Border Options")]
    //public class BorderOptions
    //{
    //    public BorderOptions(UserControl userControl)
    //    {
    //        this.CesUserControl = userControl;
    //        this._initialControlHeight = userControl.Height;
    //    }


    //    [System.ComponentModel.Browsable(false)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    public int _initialControlHeight { get; set; }


    //    [System.ComponentModel.Browsable(false)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    public UserControl CesUserControl { get; set; }


    //    private System.Windows.Forms.Padding cesPadding = new Padding(3);
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public System.Windows.Forms.Padding CesPadding
    //    {
    //        get { return cesPadding; }
    //        set
    //        {
    //            cesPadding = value;
    //            CesUserControl.Invalidate();
    //        }
    //    }

    //    private bool cesHasNotification = false;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public bool CesHasNotification
    //    {
    //        get { return cesHasNotification; }
    //        set
    //        {
    //            cesHasNotification = value;
    //            CesUserControl.Invalidate();
    //        }
    //    }

    //    private Color cesNotificationColor = Color.Red;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public Color CesNotificationColor
    //    {
    //        get { return cesNotificationColor; }
    //        set
    //        {
    //            cesNotificationColor = value;
    //            CesUserControl.Invalidate();
    //        }
    //    }

    //    private bool cesAutoHeight = true;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public bool CesAutoHeight
    //    {
    //        get { return cesAutoHeight; }
    //        set
    //        {
    //            cesAutoHeight = value;
    //            CesUserControl.Invalidate();
    //        }
    //    }

    //    private Color cesBackColor = Color.White;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public Color CesBackColor
    //    {
    //        get { return cesBackColor; }
    //        set
    //        {
    //            cesBackColor = value;
    //            CesUserControl.Invalidate();
    //        }
    //    }

    //    private Color cesBorderColor = Color.DeepSkyBlue;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public Color CesBorderColor
    //    {
    //        get { return cesBorderColor; }
    //        set
    //        {
    //            cesBorderColor = value;
    //            CesUserControl.Invalidate();
    //        }
    //    }

    //    private int cesBorderThickness = 1;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public int CesBorderThickness
    //    {
    //        get { return cesBorderThickness; }
    //        set
    //        {
    //            cesBorderThickness = value;
    //            CesUserControl.Invalidate();
    //        }
    //    }

    //    private int cesBorderRadius = 15;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Border Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public int CesBorderRadius
    //    {
    //        get { return cesBorderRadius; }
    //        set
    //        {
    //            cesBorderRadius = value;
    //            CesUserControl.Invalidate();
    //        }
    //    }
    //}



    //[System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    //[System.ComponentModel.Category("Ces Title Options")]
    //public class TitleOptions
    //{
    //    public TitleOptions(UserControl userControl)
    //    {
    //        this.CesUserControl = userControl;
    //        this.CesTitleFont = userControl.Font;
    //    }


    //    [System.ComponentModel.Browsable(false)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    public SizeF _titleTextSize { get; set; }


    //    [System.ComponentModel.Browsable(false)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    public UserControl CesUserControl { get; set; }


    //    private bool cesShowIcon = false;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public bool CesShowIcon
    //    {
    //        get { return cesShowIcon; }
    //        set
    //        {
    //            cesShowIcon = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private Image? cesIcon = null;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public Image? CesIcon
    //    {
    //        get { return cesIcon; }
    //        set
    //        {
    //            cesIcon = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }

    //    private bool cesShowTitle = false;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public bool CesShowTitle
    //    {
    //        get { return cesShowTitle; }
    //        set
    //        {
    //            cesShowTitle = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }

    //    private bool cesTitleBackground = true;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public bool CesTitleBackground
    //    {
    //        get
    //        {
    //            return cesTitleBackground;
    //        }
    //        set
    //        {
    //            cesTitleBackground = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private Font cesTitleFont;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public Font CesTitleFont
    //    {
    //        get { return cesTitleFont; }
    //        set
    //        {
    //            cesTitleFont = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private Color cesTitleTextColor = Color.White;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public Color CesTitleTextColor
    //    {
    //        get { return cesTitleTextColor; }
    //        set
    //        {
    //            cesTitleTextColor = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private string cesTitleText = "Enter Value";
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public string CesTitleText
    //    {
    //        get { return cesTitleText; }
    //        set
    //        {
    //            cesTitleText = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private CesTitlePositionEnum cesTitlePosition = CesTitlePositionEnum.Left;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public CesTitlePositionEnum CesTitlePosition
    //    {
    //        get { return cesTitlePosition; }
    //        set
    //        {
    //            cesTitlePosition = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private CesTitleContentAlignmentEnum cesTitleTextAlignment = CesTitleContentAlignmentEnum.Center;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public CesTitleContentAlignmentEnum CesTitleTextAlignment
    //    {
    //        get
    //        {
    //            return cesTitleTextAlignment;
    //        }
    //        set
    //        {
    //            cesTitleTextAlignment = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private bool cesTitleAutoWidth;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public bool CesTitleAutoWidth
    //    {
    //        get { return cesTitleAutoWidth; }
    //        set
    //        {
    //            cesTitleAutoWidth = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private int cesTitleWidth = 80;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public int CesTitleWidth
    //    {
    //        get { return cesTitleWidth; }
    //        set
    //        {
    //            cesTitleWidth = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private bool cesTitleAutoHeight;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public bool CesTitleAutoHeight
    //    {
    //        get { return cesTitleAutoHeight; }
    //        set
    //        {
    //            cesTitleAutoHeight = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }


    //    private int cesTitleHeight = 10;
    //    [System.ComponentModel.Browsable(true)]
    //    [System.ComponentModel.NotifyParentProperty(true)]
    //    [System.ComponentModel.Category("Ces Title Options")]
    //    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always)]
    //    public int CesTitleHeight
    //    {
    //        get { return cesTitleHeight; }
    //        set
    //        {
    //            cesTitleHeight = value;
    //            this.CesUserControl.Invalidate();
    //        }
    //    }
    //}


    //public static class BorderGeneratorExtension
    //{
    //    public static void GenerateBorder(
    //        this Control userControl,
    //        BorderOptions borderOptions,
    //        TitleOptions titleOptions)
    //    {
    //        if (borderOptions is null)
    //            return;

    //        borderOptions.CesUserControl.ArrangeControls(borderOptions, titleOptions);

    //        //Control? childControl = borderOptions.CesUserControl.Controls[0];
    //        //if (childControl is not null)
    //        //    childControl.BackColor = borderOptions.CesBackColor;

    //        using (var g = userControl.CreateGraphics())
    //        {
    //            g.Clear(borderOptions.CesUserControl.BackColor);
    //            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
    //            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
    //            //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
    //            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

    //            // Draw Border
    //            using (var gpBorder = new System.Drawing.Drawing2D.GraphicsPath())
    //            {
    //                using (var pBorder =
    //                    new Pen(borderOptions.CesHasNotification ?
    //                    borderOptions.CesNotificationColor :
    //                    borderOptions.CesBorderColor,
    //                    borderOptions.CesBorderThickness))
    //                {
    //                    // Top-Left Arc
    //                    gpBorder.AddArc(new Rectangle(
    //                        (borderOptions.CesBorderThickness / 2) + 1,
    //                        (borderOptions.CesBorderThickness / 2) + 1,
    //                        borderOptions.CesBorderRadius,
    //                        borderOptions.CesBorderRadius),
    //                        180, 90);

    //                    // Top-Right Arc
    //                    gpBorder.AddArc(new Rectangle(
    //                        borderOptions.CesUserControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                        (borderOptions.CesBorderThickness / 2) + 1,
    //                        borderOptions.CesBorderRadius,
    //                        borderOptions.CesBorderRadius),
    //                        270, 90);

    //                    // Bottom-Right Arc
    //                    gpBorder.AddArc(new Rectangle(
    //                        borderOptions.CesUserControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                        borderOptions.CesUserControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                        borderOptions.CesBorderRadius,
    //                        borderOptions.CesBorderRadius),
    //                        0, 90);

    //                    // Bottom-Left Arc
    //                    gpBorder.AddArc(new Rectangle(
    //                        (borderOptions.CesBorderThickness / 2) + 1,
    //                        borderOptions.CesUserControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                        borderOptions.CesBorderRadius,
    //                        borderOptions.CesBorderRadius),
    //                        90, 90);

    //                    using (var sb = new SolidBrush(borderOptions.CesBackColor))
    //                    {
    //                        gpBorder.CloseFigure();
    //                        g.FillPath(sb, gpBorder);
    //                    }

    //                    g.DrawPath(pBorder, gpBorder);
    //                }
    //            }

    //            // Draw Title
    //            if (titleOptions is not null && titleOptions.CesShowTitle)
    //            {
    //                titleOptions._titleTextSize = g.MeasureString(titleOptions.CesTitleText, titleOptions.CesTitleFont);

    //                using (var gpTitle = new System.Drawing.Drawing2D.GraphicsPath())
    //                {
    //                    // Draw title area
    //                    using (var pTitle = new Pen(borderOptions.CesBorderColor, borderOptions.CesBorderThickness))
    //                    {
    //                        // Define Title Path
    //                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Left)
    //                        {
    //                            // Top-Left Arc
    //                            gpTitle.AddArc(new Rectangle(
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                borderOptions.CesBorderRadius,
    //                                borderOptions.CesBorderRadius),
    //                                180, 90);

    //                            // Top line
    //                            gpTitle.AddLine(
    //                                (borderOptions.CesBorderThickness / 2) + 1 + borderOptions.CesBorderRadius,
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
    //                                (borderOptions.CesBorderThickness / 2) + 1);

    //                            // Right Line
    //                            gpTitle.AddLine(
    //                                titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
    //                                borderOptions.CesUserControl.Height - (borderOptions.CesBorderThickness / 2));

    //                            // Bottom Line
    //                            gpTitle.AddLine(
    //                                titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth,
    //                                borderOptions.CesUserControl.Height - (borderOptions.CesBorderThickness / 2) - 1,
    //                                (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius,
    //                                borderOptions.CesUserControl.Height - (borderOptions.CesBorderThickness / 2) - 1);

    //                            // Bottom-Left Arc
    //                            gpTitle.AddArc(new Rectangle(
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                borderOptions.CesUserControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                                borderOptions.CesBorderRadius,
    //                                borderOptions.CesBorderRadius),
    //                                90, 90);
    //                        }

    //                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Right)
    //                        {
    //                            // Top line
    //                            gpTitle.AddLine(
    //                                borderOptions.CesUserControl.Width - (titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth),
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                borderOptions.CesUserControl.Width - borderOptions.CesBorderRadius,
    //                                (borderOptions.CesBorderThickness / 2) + 1);

    //                            // Top-Right Arc
    //                            gpTitle.AddArc(new Rectangle(
    //                                borderOptions.CesUserControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                borderOptions.CesBorderRadius,
    //                                borderOptions.CesBorderRadius),
    //                                270, 90);

    //                            // Bottom-Right Arc
    //                            gpTitle.AddArc(new Rectangle(
    //                                borderOptions.CesUserControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                                borderOptions.CesUserControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                                borderOptions.CesBorderRadius,
    //                                borderOptions.CesBorderRadius),
    //                                0, 90);

    //                            // Bottom line
    //                            gpTitle.AddLine(
    //                                borderOptions.CesUserControl.Width - borderOptions.CesBorderRadius,
    //                                borderOptions.CesUserControl.Height - (borderOptions.CesBorderThickness / 2) - 1,
    //                                borderOptions.CesUserControl.Width - (titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth),
    //                                borderOptions.CesUserControl.Height - (borderOptions.CesBorderThickness / 2) - 1);
    //                        }

    //                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Top)
    //                        {
    //                            // Top-Left Arc
    //                            gpTitle.AddArc(new Rectangle(
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                borderOptions.CesBorderRadius,
    //                                borderOptions.CesBorderRadius),
    //                                180, 90);

    //                            // Top-Right Arc
    //                            gpTitle.AddArc(new Rectangle(
    //                                borderOptions.CesUserControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                borderOptions.CesBorderRadius,
    //                                borderOptions.CesBorderRadius),
    //                                270, 90);

    //                            // Right Line
    //                            gpTitle.AddLine(
    //                                borderOptions.CesUserControl.Width - (borderOptions.CesBorderThickness / 2) - 1,
    //                                (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius,
    //                                borderOptions.CesUserControl.Width - (borderOptions.CesBorderThickness / 2) - 1,
    //                                (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight));

    //                            // Bottom Line
    //                            gpTitle.AddLine(
    //                                borderOptions.CesUserControl.Width - borderOptions.CesBorderRadius,
    //                                (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight),
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                (borderOptions.CesBorderThickness / 2) + borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight));
    //                        }

    //                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Bottom)
    //                        {
    //                            // Top Line
    //                            gpTitle.AddLine(
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                borderOptions.CesUserControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius - (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight),
    //                                borderOptions.CesUserControl.Width - (borderOptions.CesBorderThickness / 2) + 1,
    //                                borderOptions.CesUserControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius - (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight));

    //                            // Right Line
    //                            gpTitle.AddLine(
    //                                borderOptions.CesUserControl.Width - (borderOptions.CesBorderThickness / 2) - 1,
    //                                borderOptions.CesUserControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius - (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight),
    //                                borderOptions.CesUserControl.Width - (borderOptions.CesBorderThickness / 2) - 1,
    //                                borderOptions.CesUserControl.Height - (borderOptions.CesBorderThickness / 2) - borderOptions.CesBorderRadius);

    //                            // Bottom-Right Arc
    //                            gpTitle.AddArc(new Rectangle(
    //                                borderOptions.CesUserControl.Width - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                                borderOptions.CesUserControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                                borderOptions.CesBorderRadius,
    //                                borderOptions.CesBorderRadius),
    //                                0, 90);

    //                            // Bottom-Left Arc
    //                            gpTitle.AddArc(new Rectangle(
    //                                (borderOptions.CesBorderThickness / 2) + 1,
    //                                borderOptions.CesUserControl.Height - borderOptions.CesBorderRadius - (borderOptions.CesBorderThickness / 2) - 1,
    //                                borderOptions.CesBorderRadius,
    //                                borderOptions.CesBorderRadius),
    //                                90, 90);
    //                        }

    //                        // Draw Title And Fill Path
    //                        using (var sbTitle = new SolidBrush(borderOptions.CesHasNotification ? borderOptions.CesNotificationColor : borderOptions.CesBorderColor))
    //                        {
    //                            gpTitle.CloseFigure();

    //                            if (titleOptions.CesTitleBackground)
    //                            {
    //                                g.FillPath(sbTitle, gpTitle);
    //                            }
    //                            else
    //                            {
    //                                g.DrawPath(pTitle, gpTitle);
    //                            }
    //                        }
    //                    }

    //                    // Draw Icon
    //                    if (titleOptions.CesShowIcon && titleOptions.CesIcon is not null)
    //                    {
    //                        RectangleF iconDestinationRect = new RectangleF();

    //                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Left)
    //                        {
    //                            iconDestinationRect = new RectangleF(
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesUserControl.Margin.Left :
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? ((titleOptions.CesTitleAutoWidth ? titleOptions.CesIcon.Width : titleOptions.CesTitleWidth) / 2) - (titleOptions.CesIcon.Width / 2) :
    //                                (titleOptions.CesTitleAutoWidth ? titleOptions.CesIcon.Width : titleOptions.CesTitleWidth) - titleOptions.CesIcon.Width - (borderOptions.CesBorderThickness * 2),
    //                                (borderOptions.CesUserControl.Height / 2) - (titleOptions.CesIcon.Height / 2),
    //                                titleOptions.CesIcon.Width,
    //                                titleOptions.CesIcon.Height);
    //                        }

    //                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Right)
    //                        {
    //                            iconDestinationRect = new RectangleF(
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? borderOptions.CesUserControl.Width - (titleOptions.CesTitleAutoWidth ? titleOptions.CesIcon.Width : titleOptions.CesTitleWidth) + (borderOptions.CesBorderThickness * 2) :
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? borderOptions.CesUserControl.Width - ((titleOptions.CesTitleAutoWidth ? titleOptions.CesIcon.Width : titleOptions.CesTitleWidth) / 2) - (titleOptions.CesIcon.Width / 2) :
    //                                borderOptions.CesUserControl.Width - titleOptions.CesIcon.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesUserControl.Margin.Right,
    //                                (borderOptions.CesUserControl.Height / 2) - (titleOptions.CesIcon.Height / 2),
    //                                titleOptions.CesIcon.Width,
    //                                titleOptions.CesIcon.Height);
    //                        }

    //                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Top)
    //                        {
    //                            iconDestinationRect = new RectangleF(
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesUserControl.Margin.Left :
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesUserControl.Width / 2) - (titleOptions.CesIcon.Width / 2) :
    //                                borderOptions.CesUserControl.Width - titleOptions.CesIcon.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesUserControl.Margin.Right,
    //                                ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions.CesIcon.Height : titleOptions.CesTitleHeight)) / 2) - (titleOptions.CesIcon.Height / 2),
    //                                titleOptions.CesIcon.Width,
    //                                titleOptions.CesIcon.Height);
    //                        }

    //                        if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Bottom)
    //                        {
    //                            iconDestinationRect = new RectangleF(
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesUserControl.Margin.Left :
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesUserControl.Width / 2) - (titleOptions.CesIcon.Width / 2) :
    //                                borderOptions.CesUserControl.Width - titleOptions.CesIcon.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesUserControl.Margin.Right,
    //                                borderOptions.CesUserControl.Height - ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions.CesIcon.Height : titleOptions.CesTitleHeight)) / 2) - (titleOptions.CesIcon.Height / 2),
    //                                titleOptions.CesIcon.Width,
    //                                titleOptions.CesIcon.Height);
    //                        }

    //                        g.DrawImage(
    //                            titleOptions.CesIcon,
    //                            iconDestinationRect,
    //                            new RectangleF(0, 0, titleOptions.CesIcon.Width, titleOptions.CesIcon.Height),
    //                            GraphicsUnit.Pixel);

    //                        return; // Not need to draw string if ShowIcon = true
    //                    }

    //                    // Draw Title Text
    //                    var titleRect = new RectangleF();

    //                    if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Left)
    //                    {
    //                        titleRect = new RectangleF(
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesUserControl.Margin.Left :
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? ((titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) / 2) - (titleOptions._titleTextSize.Width / 2) :
    //                                (titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) - titleOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2),
    //                                (borderOptions.CesUserControl.Height / 2) - (titleOptions._titleTextSize.Height / 2),
    //                                titleOptions._titleTextSize.Width,
    //                                titleOptions._titleTextSize.Height);
    //                    }

    //                    if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Right)
    //                    {
    //                        titleRect = new RectangleF(
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? borderOptions.CesUserControl.Width - (titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) + (borderOptions.CesBorderThickness * 2) :
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? borderOptions.CesUserControl.Width - ((titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) / 2) - (titleOptions._titleTextSize.Width / 2) :
    //                                borderOptions.CesUserControl.Width - titleOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesUserControl.Margin.Right,
    //                                (borderOptions.CesUserControl.Height / 2) - (titleOptions._titleTextSize.Height / 2),
    //                                titleOptions._titleTextSize.Width,
    //                                titleOptions._titleTextSize.Height);
    //                    }

    //                    if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Top)
    //                    {
    //                        titleRect = new RectangleF(
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesUserControl.Margin.Left :
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesUserControl.Width / 2) - (titleOptions._titleTextSize.Width / 2) :
    //                                borderOptions.CesUserControl.Width - titleOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesUserControl.Margin.Right,
    //                                ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight)) / 2) - (titleOptions._titleTextSize.Height / 2),
    //                                titleOptions._titleTextSize.Width,
    //                                titleOptions._titleTextSize.Height);
    //                    }

    //                    if (titleOptions.CesTitlePosition == CesTitlePositionEnum.Bottom)
    //                    {
    //                        titleRect = new RectangleF(
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Left ? (borderOptions.CesBorderThickness * 2) + borderOptions.CesUserControl.Margin.Left :
    //                                titleOptions.CesTitleTextAlignment == CesTitleContentAlignmentEnum.Center ? (borderOptions.CesUserControl.Width / 2) - (titleOptions._titleTextSize.Width / 2) :
    //                                borderOptions.CesUserControl.Width - titleOptions._titleTextSize.Width - (borderOptions.CesBorderThickness * 2) - borderOptions.CesUserControl.Margin.Right,
    //                                borderOptions.CesUserControl.Height - ((borderOptions.CesBorderRadius + (titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight)) / 2) - (titleOptions._titleTextSize.Height / 2),
    //                                titleOptions._titleTextSize.Width,
    //                                titleOptions._titleTextSize.Height);
    //                    }

    //                    g.DrawString(
    //                        titleOptions.CesTitleText,
    //                        titleOptions.CesTitleFont,
    //                        new SolidBrush(titleOptions.CesTitleTextColor),
    //                        titleRect);
    //                }
    //            }

    //            return;
    //        }
    //    }


    //    public static void ArrangeControls(
    //        this Control userControl,
    //        BorderOptions borderOptions,
    //        TitleOptions titleOptions)
    //    {
    //        if (borderOptions is null || titleOptions is null)
    //            return;

    //        using System.Drawing.Graphics g = userControl.CreateGraphics();
    //        titleOptions._titleTextSize = g.MeasureString(titleOptions.CesTitleText, titleOptions.CesTitleFont);

    //        // Auto Height TextBox Control
    //        if (titleOptions.CesShowTitle && borderOptions.CesAutoHeight &&
    //            (titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top ||
    //            titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Bottom))
    //            userControl.Height =
    //                    userControl.Controls[0].Height +
    //                    (borderOptions.CesBorderThickness * 2) +
    //                    (int)(titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight) + borderOptions.CesBorderRadius;

    //        //Set txtTextBox Control Inside UserControl
    //        int childControlWidth =
    //            userControl.Width -
    //            borderOptions.CesPadding.Left -
    //            borderOptions.CesPadding.Right -
    //            (borderOptions.CesBorderThickness * 2);

    //        if (titleOptions.CesShowTitle &&
    //            (titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left ||
    //            titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right))
    //        {
    //            if (titleOptions.CesTitleAutoWidth)
    //            {
    //                childControlWidth -= (int)titleOptions._titleTextSize.Width;
    //            }
    //            else
    //            {
    //                childControlWidth -= titleOptions.CesTitleWidth;
    //            }
    //        }

    //        userControl.Controls[0].Width = childControlWidth;


    //        // Normal Top Position
    //        userControl.Controls[0].Top =
    //            (userControl.Height / 2) -
    //            (userControl.Controls[0].Height / 2);

    //        // Set Top Postion According to Title Position = Top
    //        if (titleOptions.CesShowTitle && titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Top)
    //            userControl.Controls[0].Top =
    //                (userControl.Height / 2) -
    //                (userControl.Controls[0].Height / 2) +
    //                (int)(titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight);

    //        // Set Top Postion According to Title Position = Bottom
    //        if (titleOptions.CesShowTitle && titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Bottom)
    //            userControl.Controls[0].Top =
    //                (userControl.Height / 2) -
    //                (userControl.Controls[0].Height / 2) -
    //                (int)(titleOptions.CesTitleAutoHeight ? titleOptions._titleTextSize.Height : titleOptions.CesTitleHeight);

    //        // Normal Left Position
    //        userControl.Controls[0].Left =
    //            (userControl.Width / 2) -
    //            (userControl.Controls[0].Width / 2);

    //        // Set txtTextBox Left Position According to Title Position = Left
    //        if (titleOptions.CesShowTitle && titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Left)
    //            userControl.Controls[0].Left =
    //                (int)(titleOptions.CesTitleAutoWidth ? titleOptions._titleTextSize.Width : titleOptions.CesTitleWidth) +
    //                borderOptions.CesPadding.Left +
    //                (borderOptions.CesBorderThickness / 2);

    //        // Set txtTextBox Left Position According to Title Position = Right
    //        if (titleOptions.CesShowTitle && titleOptions.CesTitlePosition == Ces.WinForm.UI.Infrastructure.CesTitlePositionEnum.Right)
    //            userControl.Controls[0].Left =
    //                 borderOptions.CesPadding.Left +
    //                 (borderOptions.CesBorderThickness / 2);
    //    }
    //}
}
