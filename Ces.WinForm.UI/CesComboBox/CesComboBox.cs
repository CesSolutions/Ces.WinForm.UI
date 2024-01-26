using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesComboBox
{
    [DefaultEvent(nameof(CesSelectedItemChanged))]
    [ToolboxItem(true)]
    public partial class CesComboBox : Infrastructure.CesControlBase
    {
        public CesComboBox()
        {
            InitializeComponent();
            ChildContainer = pnlContainer;
        }

        public delegate void CesSelectedItemChangedEventHandler(object sender, object? item);
        public event CesSelectedItemChangedEventHandler CesSelectedItemChanged;

        // This Class Property
        private Ces.WinForm.UI.CesComboBox.CesComboBoxPopup frmPopup;
        private Color currentBorderColor;

        private int cesItemHeight = 30;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public int CesItemHeight
        {
            get { return cesItemHeight; }
            set { cesItemHeight = value; }
        }

        private int cesImageWidth = 24;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public int CesImageWidth
        {
            get { return cesImageWidth; }
            set { cesImageWidth = value; }
        }

        private bool cesShowIndicator = false;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowIndicator
        {
            get { return cesShowIndicator; }
            set { cesShowIndicator = value; }
        }

        private bool cesShowImage = true;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowImage
        {
            get { return cesShowImage; }
            set { cesShowImage = value; }
        }

        private bool cesAlignToRight = false;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesAlignToRight
        {
            get { return cesAlignToRight; }
            set { cesAlignToRight = value; }
        }

        private Size cesPopupSize = new Size(350, 400);
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public Size CesPopupSize
        {
            get { return cesPopupSize; }
            set { cesPopupSize = value; }
        }

        private bool cesShowSearchBox { get; set; } = true;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowSearchBox
        {
            get { return cesShowSearchBox; }
            set
            {
                cesShowSearchBox = value;
            }
        }

        private bool cesShowStatusBar { get; set; } = true;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowStatusBar
        {
            get { return cesShowStatusBar; }
            set
            {
                cesShowStatusBar = value;
            }
        }

        private object? cesSelectedItem { get; set; }
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        [System.ComponentModel.Browsable(false)]
        public object? CesSelectedItem
        {
            get { return cesSelectedItem; }
            set
            {
                cesSelectedItem = value;

                txtSelectedItem.Text =
                    value == null ?
                    string.Empty :
                    value?.GetType().GetProperty(CesDisplayMember)?.GetValue(value)?.ToString();

                if (CesSelectedItemChanged != null)
                    CesSelectedItemChanged(this, value);
            }
        }

        private bool cesAdjustPopupToParentWidth = true;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesAdjustPopupToParentWidth
        {
            get { return cesAdjustPopupToParentWidth; }
            set { cesAdjustPopupToParentWidth = value; }
        }

        private bool cesShowClearButton = false;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowClearButton
        {
            get { return cesShowClearButton; }
            set
            {
                cesShowClearButton = value;
                this.btnClear.Visible = value;
            }
        }

        private string cesValueMember { get; set; }
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public string CesValueMember
        {
            get { return cesValueMember; }
            set
            {
                cesValueMember = value;
            }
        }

        private string cesDisplayMember { get; set; }
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public string CesDisplayMember
        {
            get { return cesDisplayMember; }
            set
            {
                cesDisplayMember = value;
            }
        }

        private object? cesDataSource;
        [Browsable(false)]
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public object? CesDataSource
        {
            get { return cesDataSource; }
            set
            {
                cesDataSource = value;
                ReadyPopup();
            }
        }

        private void ReadyPopup()
        {
            if (CesDataSource == null)
                return;

            frmPopup = new CesComboBoxPopup();
            frmPopup.Deactivate += new EventHandler(frmDeactivated);
            frmPopup.CesSelectedItemChanged += new Ces.WinForm.UI.CesComboBox.CesComboBoxPopup.CesSelectedItemChangedEventHandler(SelectedItemChanged);
            frmPopup.CesBorderColor = CesBorderColor;
            frmPopup.TopMost = true;
            frmPopup.Size = CesAdjustPopupToParentWidth ? new Size(this.Width, CesPopupSize.Height) : CesPopupSize;

            SetPopupLocation();

            frmPopup.lb.CesDisplayMember = CesDisplayMember;
            frmPopup.lb.CesValueMember = CesValueMember;
            frmPopup.lb.CesShowStatusBar = CesShowStatusBar;
            frmPopup.lb.CesShowSearchBox = CesShowSearchBox;
            frmPopup.lb.CesMultiSelect = false;
            frmPopup.lb.BorderStyle = BorderStyle.None;
            frmPopup.lb.CesDataSource(CesDataSource);
            //frmPopup.Hide();
        }

        private void SelectedItemChanged(object sender, object? item)
        {
            CesSelectedItem = item;
        }

        private void SetPopupLocation()
        {
            // Check form size to fit in location. if locate out of screen,
            // another location shall be select automatically by application

            var screenSize = Screen.PrimaryScreen.WorkingArea;
            var popupRightLocation = 0;
            var popupLeftLocation = 0;
            var comboLocation = this.PointToScreen(Point.Empty);
            var popupBottomLocation = comboLocation.Y + frmPopup.Height;

            // Top Location
            if (popupBottomLocation > screenSize.Height)
                frmPopup.Top = comboLocation.Y - frmPopup.Height;
            else
                frmPopup.Top = comboLocation.Y + this.Height;

            // Left Location
            if (CesAlignToRight)
                popupLeftLocation = comboLocation.X - (frmPopup.Width - this.Width);
            else
                popupRightLocation = comboLocation.X + frmPopup.Width;

            if (CesAlignToRight)
            {
                if (popupLeftLocation < 0)
                    frmPopup.Left = 0;
                else
                    frmPopup.Left = comboLocation.X - (frmPopup.Width - this.Width);
            }
            else
            {
                if (popupRightLocation > screenSize.Width)
                    frmPopup.Left = screenSize.Width - frmPopup.Width;
                else
                    frmPopup.Left = comboLocation.X < 0 ? 0 : comboLocation.X;
            }
        }

        private void CesSimpleComboBox_Paint(object sender, PaintEventArgs e)
        {
            this.GenerateBorder(this);
        }

        private void frmDeactivated(object? sender, EventArgs e)
        {
            frmPopup.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (CesDataSource == null)
                return;

            ReadyPopup();
            frmPopup.Show(this);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CesSelectedItem = null;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.txtSelectedItem.Focus();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
                CesBorderColor = currentBorderColor;
            else
            {
                currentBorderColor = CesBorderColor;
                CesBorderColor = Color.Silver;
            }
        }
    }
}
