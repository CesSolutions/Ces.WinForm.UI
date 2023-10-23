using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesForm
{
    public partial class CesForm : Form
    {
        public CesForm()
        {
            InitializeComponent();
            this.Padding = new System.Windows.Forms.Padding(all: (int)CesBorderThickness);
        }

        private bool IsMouseDown { get; set; }
        private Point CurrentMousePosition { get; set; }


        [System.ComponentModel.Category("CesForm")]
        public PictureBox CesFormIcon { get { return pbFormIcon; } }


        private bool cesFormIconVisible { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesFormIconVisible

        {
            get { return cesFormIconVisible; }
            set
            {
                cesFormIconVisible = value;
                scFormTop.Panel1Collapsed = !value;
            }
        }


        private bool cesFormTitleVisible { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesFormTitleVisible
        {
            get { return cesFormTitleVisible; }
            set
            {
                cesFormTitleVisible = value;
                lblFormTitle.Visible = value;
            }
        }


        private Font cesFormTitleFont { get; set; }
        [System.ComponentModel.Category("CesForm")]
        public Font CesFormTitleFont
        {
            get { return cesFormTitleFont; }
            set
            {
                cesFormTitleFont = value;
            }
        }


        private string cesFormTitle { get; set; }
        [System.ComponentModel.Category("CesForm")]
        public string CesFormTitle
        {
            get { return cesFormTitle; }
            set
            {
                cesFormTitle = value;
                lblFormTitle.Text = value;
            }
        }


        private bool cesControlBoxVisible { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesControlBoxVisible
        {
            get { return cesControlBoxVisible; }
            set
            {
                cesControlBoxVisible = value;
                pnlControlBox.Visible = value;
            }
        }


        private bool cesExitButtonVisible { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesExitButtonVisible
        {
            get { return cesExitButtonVisible; }
            set
            {
                cesExitButtonVisible = value;
                btnExit.Visible = value;
            }
        }


        private bool cesMaximizeButtonVisible { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesMaximizeButtonVisible
        {
            get { return cesMaximizeButtonVisible; }
            set
            {
                cesMaximizeButtonVisible = value;
                btnMaximize.Visible = value;
            }
        }


        private bool cesMinimizeButtonVisible { get; set; } = true;
        [System.ComponentModel.Category("CesForm")]
        public bool CesMinimizeButtonVisible
        {
            get { return cesMinimizeButtonVisible; }
            set
            {
                cesMinimizeButtonVisible = value;
                btnMinimize.Visible = value;
            }
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
                this.Invalidate();
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
                this.Invalidate();
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
                this.Padding = new Padding(all: (int)value);
                this.Invalidate();
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
                this.Invalidate();
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
                this.Invalidate();
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
                this.Invalidate();
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
                this.Invalidate();
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
                this.Invalidate();
            }
        }







        private CesFormTypeEnum cesFormType { get; set; } = CesFormTypeEnum.Normal;
        public CesFormTypeEnum CesFormType
        {
            get { return cesFormType; }
            set
            {
                cesFormType = value;
            }
        }

        private void FormConfiguration()
        {
            if (cesFormType == CesFormTypeEnum.Normal)
                NormalFormConfiguration();

            if (cesFormType == CesFormTypeEnum.Dialog)
                DialogFormConfiguration();

            if (cesFormType == CesFormTypeEnum.None)
                NoneFormConfiguration();
        }

        private void NoneFormConfiguration()
        {
            throw new NotImplementedException();
        }

        private void DialogFormConfiguration()
        {
            throw new NotImplementedException();
        }

        private void NormalFormConfiguration()
        {
            throw new NotImplementedException();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblFormTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            IsMouseDown = true;
            CurrentMousePosition = new Point(e.Location.X, e.Location.Y);
        }

        private void CesForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void lblFormTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown)
                return;

            this.Left = this.Left + (e.X - CurrentMousePosition.X);
            this.Top = this.Top + (e.Y - CurrentMousePosition.Y);
        }

        private void lblFormTitle_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void CesForm_Paint(object sender, PaintEventArgs e)
        {
            using (var g = this.CreateGraphics())
            {
                g.Clear(this.BackColor);
                g.DrawRectangle(
                    new Pen(CesBorderColor, CesBorderThickness * 2),                     
                    0, 
                    0, 
                    this.Width,
                    this.Height);
            }
        }
    }

    public enum CesFormTypeEnum
    {
        Normal,
        Dialog,
        None,
    }
}