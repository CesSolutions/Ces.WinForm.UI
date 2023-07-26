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
    public partial class CesFormBase : Form
    {
        public CesFormBase()
        {
            InitializeComponent();
            DrawBorder();
        }


        private bool cesBorderVisible { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesBorderVisible
        {
            get
            {
                return cesBorderVisible;
            }
            set
            {
                cesBorderVisible = value;
                DrawBorder();
            }
        }


        private Color cesBorderColor { get; set; } = Color.Orange;
        [System.ComponentModel.Category("CesForm")]
        public Color CesBorderColor
        {
            get
            {
                return cesBorderColor;
            }
            set
            {
                cesBorderColor = value;
                DrawBorder();
            }
        }


        private float cesBorderThickness { get; set; } = 2;
        [System.ComponentModel.Category("CesForm")]
        public float CesBorderThickness
        {
            get
            {
                return cesBorderThickness;
            }
            set
            {
                cesBorderThickness = value;
                DrawBorder();
            }
        }


        private System.Drawing.Drawing2D.DashStyle cesLineType { get; set; } =
            System.Drawing.Drawing2D.DashStyle.Solid;
        [System.ComponentModel.Category("CesForm")]
        public System.Drawing.Drawing2D.DashStyle CesLineType
        {
            get
            {
                return cesLineType;
            }
            set
            {
                cesLineType = value;
                DrawBorder();
            }
        }


        private bool cesVisibleTopBorder { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesVisibleTopBorder
        {
            get
            {
                return cesVisibleTopBorder;
            }
            set
            {
                cesVisibleTopBorder = value;
                DrawBorder();
            }
        }


        private bool cesVisibleRightBorder { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesVisibleRightBorder
        {
            get
            {
                return cesVisibleRightBorder;
            }
            set
            {
                cesVisibleRightBorder = value;
                DrawBorder();
            }
        }


        private bool cesVisibleBottomBorder { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesVisibleBottomBorder
        {
            get
            {
                return cesVisibleBottomBorder;
            }
            set
            {
                cesVisibleBottomBorder = value;
                DrawBorder();
            }
        }


        private bool cesVisibleLeftBorder { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesVisibleLeftBorder
        {
            get
            {
                return cesVisibleLeftBorder;
            }
            set
            {
                cesVisibleLeftBorder = value;
                DrawBorder();
            }
        }


        // Methods

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == Infrastructure.Win32Helpers.WM_NCPAINT)
            {
                WmNCPaint(ref m);
            }
            else if (m.Msg == Infrastructure.Win32Helpers.WM_NCCALCSIZE)
            {
                WmNCCalcSize(ref m);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            DrawBorder();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
        }

        private void DrawBorder()
        {
            RecalculateClientSize();

            Infrastructure.Win32Helpers.RedrawWindow(
               Handle, IntPtr.Zero, IntPtr.Zero,
               Infrastructure.Win32Helpers.RDW_FRAME |
               Infrastructure.Win32Helpers.RDW_INVALIDATE |
               Infrastructure.Win32Helpers.RDW_UPDATENOW);

            this.Refresh();
        }

        private void RecalculateClientSize()
        {
            Infrastructure.Win32Helpers.SetWindowPos(
                this.Handle, IntPtr.Zero, 0, 0, 0, 0,
                Infrastructure.Win32Helpers.SWP_NOSIZE |
                Infrastructure.Win32Helpers.SWP_NOMOVE |
                Infrastructure.Win32Helpers.SWP_FRAMECHANGED |
                Infrastructure.Win32Helpers.SWP_NOZOORDER);
        }

        private void WmNCCalcSize(ref Message m)
        {
            if (m.WParam != IntPtr.Zero)
            {
                var nccsp =
                    (Infrastructure.Win32Helpers.NCCALCSIZE_PARAMS)System.Runtime.InteropServices.Marshal.PtrToStructure(
                    m.LParam, typeof(Infrastructure.Win32Helpers.NCCALCSIZE_PARAMS));

                nccsp.rgrc[0].top += (int)cesBorderThickness;
                nccsp.rgrc[0].bottom -= (int)cesBorderThickness;
                nccsp.rgrc[0].left += (int)cesBorderThickness;
                nccsp.rgrc[0].right -= (int)cesBorderThickness;

                System.Runtime.InteropServices.Marshal.StructureToPtr(nccsp, m.LParam, true);
                Infrastructure.Win32Helpers.InvalidateRect(this.Handle, nccsp.rgrc[0], true);
                m.Result = IntPtr.Zero;
            }
        }

        private void WmNCPaint(ref Message m)
        {
            var dc = Infrastructure.Win32Helpers.GetWindowDC(Handle);

            using (var g = Graphics.FromHdc(dc))
            {
                using (var b = new Pen(cesBorderColor, cesBorderThickness * 2))
                {
                    g.Clear(this.BackColor);

                    if (!cesBorderVisible)
                        return;

                    b.DashStyle = cesLineType;

                    if (cesVisibleTopBorder)
                        g.DrawLine(b, 0, 0, this.Width, 0);

                    if (cesVisibleRightBorder)
                        g.DrawLine(b, this.Width, 0, this.Width, this.Height);

                    if (cesVisibleBottomBorder)
                        g.DrawLine(b, 0, this.Height, this.Width, this.Height);

                    if (cesVisibleLeftBorder)
                        g.DrawLine(b, 0, 0, 0, this.Height);


                    //var textSize = g.MeasureString(cesFormTitle, cesFormTitleFont);
                    //var textLocation = new PointF((this.Width / 2) - (textSize.Width / 2), (this.Height / 2) - (textSize.Height / 2));

                    //g.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), new RectangleF(cesBorderThickness, cesBorderThickness, this.Width - (cesBorderThickness * 2), 30));
                    //g.DrawString(cesFormTitle, cesFormTitleFont, new SolidBrush(Color.Silver), textLocation);
                }
            }

            Infrastructure.Win32Helpers.ReleaseDC(Handle, dc);
            m.Result = IntPtr.Zero;
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var size = base.GetPreferredSize(proposedSize);
            this.Size = new Size(
                this.Size.Width + (int)cesBorderThickness,
                this.Size.Height + (int)cesBorderThickness);
            return size;
        }
    }
}
