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

namespace Ces.WinForm.UI.CesForm
{


    public partial class CesForm : Form
    {
        public CesForm()
        {
            InitializeComponent();
            //this.Padding = new System.Windows.Forms.Padding(all: (int)CesBorderThickness);
            this.Padding = new System.Windows.Forms.Padding(all: 0);
        }


        [Browsable(true)]
        [Category("Ces Form")]
        [Description("Invoked when user clicks on Option button")]
        public event EventHandler OptionClick;


        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (OptionClick != null)
                OptionClick(sender, e);
        }


        private bool IsMouseDown { get; set; }
        private Point CurrentMousePosition { get; set; }

        [System.ComponentModel.Category("Ces Form")]
        public Button CesOptionButton { get { return btnOptions; } }

        private bool cesOptionButtonVisible { get; set; } = true;
        [System.ComponentModel.Category("Ces Form")]
        public bool CesOptionButtonVisible

        {
            get { return cesOptionButtonVisible; }
            set
            {
                cesOptionButtonVisible = value;
                scFormTop.Panel1Collapsed = !value;
            }
        }

        private bool cesTitleVisible { get; set; } = true;
        [System.ComponentModel.Category("Ces Form")]
        public bool CesTitleVisible
        {
            get { return cesTitleVisible; }
            set
            {
                cesTitleVisible = value;
                lblFormTitle.Visible = value;
            }
        }

        private Font cesTitleFont { get; set; } =
            new Font(new FontFamily("Verdana"), 10, FontStyle.Bold);
        [System.ComponentModel.Category("Ces Form")]
        public Font CesTitleFont
        {
            get { return cesTitleFont; }
            set
            {
                cesTitleFont = value;
                lblFormTitle.Font = value;
            }
        }

        [System.ComponentModel.Category("Ces Form")]
        private Color cesTitleColor { get; set; } = Color.Silver;
        public Color CesTitleColor
        {
            get { return cesTitleColor; }
            set
            {
                cesTitleColor = value;
                lblFormTitle.ForeColor = value;
            }
        }

        private string cesTitle { get; set; }
        [System.ComponentModel.Category("Ces Form")]
        public string CesTitle
        {
            get { return cesTitle; }
            set
            {
                cesTitle = value;
                lblFormTitle.Text = value;
            }
        }

        private bool cesControlBoxVisible { get; set; } = true;
        [System.ComponentModel.Category("Ces Form")]
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
        [System.ComponentModel.Category("Ces Form")]
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
        [System.ComponentModel.Category("Ces Form")]
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
        [System.ComponentModel.Category("Ces Form")]
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
        [System.ComponentModel.Category("Ces Form")]
        public bool CesBorderVisible
        {
            get
            {
                return cesBorderVisible;
            }
            set
            {
                cesBorderVisible = value;

                this.clBorderLeft.Visible = value;
                this.clBorderRight.Visible = value;
                this.clBorderTop.Visible = value;
                this.clBorderBottom.Visible = value;
            }
        }

        private Color cesBorderColor { get; set; } = Color.Orange;
        [System.ComponentModel.Category("Ces Form")]
        public Color CesBorderColor
        {
            get
            {
                return cesBorderColor;
            }
            set
            {
                cesBorderColor = value;
                this.clBorderLeft.BackColor = value;
                this.clBorderRight.BackColor = value;
                this.clBorderTop.BackColor = value;
                this.clBorderBottom.BackColor = value;

                this.clBorderLeft.CesLineColor = value;
                this.clBorderRight.CesLineColor = value;
                this.clBorderTop.CesLineColor = value;
                this.clBorderBottom.CesLineColor = value;
            }
        }

        private int cesBorderThickness { get; set; } = 2;
        [System.ComponentModel.Category("Ces Form")]
        public int CesBorderThickness
        {
            get
            {
                return cesBorderThickness;
            }
            set
            {
                cesBorderThickness = value;

                this.clBorderLeft.Width = value;
                this.clBorderRight.Width = value;
                this.clBorderTop.Height = value;
                this.clBorderBottom.Height = value;

                this.clBorderLeft.CesLineWidth = value;
                this.clBorderRight.CesLineWidth = value;
                this.clBorderTop.CesLineWidth = value;
                this.clBorderBottom.CesLineWidth = value;
            }
        }

        private CesFormTypeEnum cesFormType { get; set; } = CesFormTypeEnum.Normal;
        [System.ComponentModel.Category("Ces Form")]
        public CesFormTypeEnum CesFormType
        {
            get { return cesFormType; }
            set
            {
                cesFormType = value;
                FormConfiguration();
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
            scFormTop.Visible = false;
        }

        private void DialogFormConfiguration()
        {
            CesOptionButtonVisible = false;
            CesTitleVisible = true;
            CesControlBoxVisible = true;
            CesMinimizeButtonVisible = false;
            CesMaximizeButtonVisible = false;
            CesExitButtonVisible = true;
            CesBorderVisible = true;

            scFormTop.Height = 30;
            scFormTop.Visible = true;
        }

        private void NormalFormConfiguration()
        {
            CesOptionButtonVisible = true;
            CesTitleVisible = true;
            CesControlBoxVisible = true;
            CesMinimizeButtonVisible = true;
            CesMaximizeButtonVisible = true;
            CesExitButtonVisible = true;
            CesBorderVisible = true;

            scFormTop.Height = 60;
            scFormTop.Visible = true;
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

        private void CesForm_Layout(object sender, LayoutEventArgs e)
        {
            scFormTop.SendToBack();
            clBorderLeft.SendToBack();
            clBorderRight.SendToBack();
            clBorderTop.SendToBack();
            clBorderBottom.SendToBack();
        }
    }

    public enum CesFormTypeEnum
    {
        Normal,
        Dialog,
        None,
    }
}