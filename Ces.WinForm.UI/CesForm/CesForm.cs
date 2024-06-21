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

            this.Padding = new System.Windows.Forms.Padding(all: 0);

            FormConfiguration();
            LocateResizeIcon();

            _NormalSize = this.Size;
            _NormalLocation = this.Location;
        }

        private bool _Maximize;
        private Point _NormalLocation;
        private Size _NormalSize;

        [Browsable(true)]
        [Category("Ces Form")]
        [Description("Invoked when user clicks on Option button")]
        public event EventHandler OptionClick;

        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (OptionClick != null)
                OptionClick(sender, e);
        }


        #region Private Fields

        private bool IsMouseDown { get; set; }
        private Point CurrentMousePosition { get; set; }
        private Size CurrentFormSize { get; set; }

        #endregion Private Fields

        #region Properties

        [System.ComponentModel.Category("Ces Form")]
        public Button CesOptionButton { get { return btnOptions; } }

        private bool cesOptionButtonVisible { get; set; } = false;
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

                if (value)
                    pnlControlBox.Width += 45;
                else
                    pnlControlBox.Width -= 45;
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

                if (value)
                    pnlControlBox.Width += 45;
                else
                    pnlControlBox.Width -= 45;
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

                if (value)
                    pnlControlBox.Width += 45;
                else
                    pnlControlBox.Width -= 45;
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

        private bool cesShowResizeIcon { get; set; } = true;
        [System.ComponentModel.Category("Ces Form")]
        public bool CesShowResizeIcon
        {
            get { return cesShowResizeIcon; }
            set
            {
                cesShowResizeIcon = value;
                pbResizeForm.Visible = value;
            }
        }

        private CesFormTypeEnum cesFormType { get; set; } = CesFormTypeEnum.Dialog;
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

        #endregion Properties

        #region Custom Methods

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
            CesControlBoxVisible = true;
            CesMinimizeButtonVisible = false;
            CesMaximizeButtonVisible = false;
            CesExitButtonVisible = true;
            CesBorderVisible = true;

            scFormTop.Height = 30;
            pnlControlBox.Width = 45;
            btnOptions.Size = new Size(30, 30);
        }

        private void NormalFormConfiguration()
        {
            CesControlBoxVisible = true;
            CesMinimizeButtonVisible = true;
            CesMaximizeButtonVisible = true;
            CesExitButtonVisible = true;
            CesBorderVisible = true;

            scFormTop.Height = 60;
            btnOptions.Size = new Size(60, 60);
        }

        private void LocateResizeIcon()
        {
            // در زمان تعیین موقعیت بایدسایز فرم و ضخامت حاشیه مد نظر قرار گیرد
            pbResizeForm.Left = this.Width - pbResizeForm.Width - clBorderRight.Width;
            pbResizeForm.Top = this.Height - pbResizeForm.Height - clBorderBottom.Height;
        }

        #endregion Custom Methods

        #region Control Methods

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (_Maximize)
            {
                _Maximize = false;

                this.CesBorderVisible = true;
                this.Location = _NormalLocation;
                this.Size = _NormalSize;

                return;
            }
            else
            {
                _Maximize = true;

                this.CesBorderVisible = false;
                this.Location = new Point(0, 0);
                this.Size = new Size(
                    Screen.PrimaryScreen.WorkingArea.Width,
                    Screen.PrimaryScreen.WorkingArea.Height);

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
            pbResizeForm.SendToBack();
        }

        private void pbResizeForm_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            CurrentMousePosition = e.Location;
            CurrentFormSize = this.Size;
        }

        private void pbResizeForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown)
                return;

            int newX = 0;
            int newY = 0;

            newX = e.Location.X - CurrentMousePosition.X;
            newY = e.Location.Y - CurrentMousePosition.Y;
            this.Width += newX;
            this.Height += newY;
        }

        private void pbResizeForm_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void CesForm_Resize(object sender, EventArgs e)
        {
            LocateResizeIcon();
        }

        private void clBorderBottom_DoubleClick(object sender, EventArgs e)
        {
            if (!CesShowResizeIcon)
                return;

            this.Top = 0;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void clBorderTop_DoubleClick(object sender, EventArgs e)
        {
            if (!CesShowResizeIcon)
                return;

            this.Top = 0;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void clBorderRight_DoubleClick(object sender, EventArgs e)
        {
            if (!CesShowResizeIcon)
                return;

            this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
        }

        private void clBorderLeft_DoubleClick(object sender, EventArgs e)
        {
            if (!CesShowResizeIcon)
                return;

            this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
        }

        private void lblFormTitle_DoubleClick(object sender, EventArgs e)
        {
            if (!CesShowResizeIcon)
                return;

            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void CesForm_ResizeEnd(object sender, EventArgs e)
        {
            if (!_Maximize)
                _NormalSize = this.Size;
        }

        private void CesForm_Move(object sender, EventArgs e)
        {
            if (!_Maximize)
                _NormalLocation = this.Location;
        }

        #endregion Control Methods
    }

    public enum CesFormTypeEnum
    {
        Normal,
        Dialog,
        None,
    }
}