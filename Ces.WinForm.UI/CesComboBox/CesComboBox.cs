using Microsoft.DotNet.DesignTools.Protocol.Values;
using System.ComponentModel;
using System.Xml.Linq;

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
            SetOptionButtonVisibility();
            InitializePopup();
        }

        public delegate void CesSelectedItemChangedEventHandler(object sender, object? item);
        public event CesSelectedItemChangedEventHandler CesSelectedItemChanged;

        public event EventHandler<Events.CesReloadDataEvent> CesReloadDataClicked;
        public event EventHandler<Events.CesAddItemEvent> CesAddItemClicked;
        public event EventHandler<Events.CesEditItemEvent> CesEditItemClicked;

        #region Properties

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

        private object? cesSelectedValue;
        [Browsable(false)]
        public object? CesSelectedValue
        {
            get { return cesSelectedValue; }
            set { cesSelectedValue = value; }
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

                CesSelectedValue =
                     value == null ?
                     null :
                     value?.GetType().GetProperty(CesValueMember)?.GetValue(value);

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
                SetOptionButtonVisibility();
            }
        }

        private bool cesShowAddItemButton = false;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowAddItemButton
        {
            get { return cesShowAddItemButton; }
            set
            {
                cesShowAddItemButton = value;
                SetOptionButtonVisibility();
            }
        }

        private bool cesShowEditItemButton = false;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowEditItemButton
        {
            get { return cesShowEditItemButton; }
            set
            {
                cesShowEditItemButton = value;
                SetOptionButtonVisibility();
            }
        }

        private bool cesShowLoadButton = false;
        [System.ComponentModel.Category("Ces Simple ComboBox")]
        public bool CesShowLoadButton
        {
            get { return cesShowLoadButton; }
            set
            {
                cesShowLoadButton = value;
                SetOptionButtonVisibility();
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

        #endregion Properties

        #region Custom Methods

        private void SetOptionButtonVisibility()
        {
            this.btnClear.Visible = CesShowClearButton;
            this.btnAddItem.Visible = CesShowAddItemButton;
            this.btnEditItem.Visible = CesShowEditItemButton;
            this.btnReloadData.Visible = CesShowLoadButton;

            SetTextBoxWidth();
        }

        private void InitializePopup()
        {
            frmPopup = new CesComboBoxPopup();
            frmPopup.Deactivate += new EventHandler(frmDeactivated);
            frmPopup.CesSelectedItemChanged += new Ces.WinForm.UI.CesComboBox.CesComboBoxPopup.CesSelectedItemChangedEventHandler(SelectedItemChanged);
            frmPopup.CesBorderColor = CesBorderColor;
            frmPopup.TopMost = true;
        }

        private void ReadyPopup()
        {
            if (CesDataSource == null)
            {
                frmPopup.lb.CesDataSource(CesDataSource);
                CesSelectedItem = null;
                return;
            }

            SetPopupLocation();

            frmPopup.lb.CesDisplayMember = CesDisplayMember;
            frmPopup.lb.CesValueMember = CesValueMember;
            frmPopup.lb.CesShowStatusBar = CesShowStatusBar;
            frmPopup.lb.CesShowSearchBox = CesShowSearchBox;
            frmPopup.lb.CesMultiSelect = false;
            frmPopup.lb.BorderStyle = BorderStyle.None;
            frmPopup.lb.CesDataSource(CesDataSource);
        }

        private void SelectedItemChanged(object sender, object? item)
        {
            CesSelectedItem = item;
        }

        private void SetPopupLocation()
        {
            frmPopup.Size = CesAdjustPopupToParentWidth ? new Size(this.Width, CesPopupSize.Height) : CesPopupSize;

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

        private void SetTextBoxWidth()
        {
            int visibleButton = 0;

            if (CesShowClearButton)
                visibleButton += 1;

            if (CesShowAddItemButton)
                visibleButton += 1;

            if (CesShowEditItemButton)
                visibleButton += 1;

            if (CesShowLoadButton)
                visibleButton += 1;

            // btnOpen is always visible and its space must be set 20
            pnlButtonContainer.Width = 20 + (visibleButton * 20);

            txtSelectedItem.Left = 5;
            txtSelectedItem.Width = pnlContainer.Width - 5 - pnlButtonContainer.Width - 5;
            txtSelectedItem.Top = (pnlContainer.Height / 2) - (txtSelectedItem.Height / 2);

            lblEnable.Left = 5;
            lblEnable.Width = pnlContainer.Width - 5 - pnlButtonContainer.Width - 5;
            lblEnable.Top = (pnlContainer.Height / 2) - (lblEnable.Height / 2);
        }

        #endregion Custom Methods

        #region Control Methods

        private void CesSimpleComboBox_Paint(object sender, PaintEventArgs e)
        {
            this.lblEnable.BackColor = CesBackColor;
            this.txtSelectedItem.BackColor = CesBackColor;
            this.GenerateBorder(this);
        }

        private void frmDeactivated(object? sender, EventArgs e)
        {
            // frmPopup.Hide();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (CesDataSource == null)
                return;

            ReadyPopup();
            frmPopup.ShowDialog(this);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CesSelectedItem = null;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            CesAddItemClicked?.Invoke(this, new UI.CesComboBox.Events.CesAddItemEvent());
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            CesReloadDataClicked?.Invoke(this, new UI.CesComboBox.Events.CesReloadDataEvent());
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            CesEditItemClicked?.Invoke(this, new UI.CesComboBox.Events.CesEditItemEvent());
        }

        #endregion Control Methods

        #region Override Methods

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.txtSelectedItem.Focus();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
            {
                lblEnable.Text = string.Empty;
                lblEnable.Visible = !this.Enabled;

                txtSelectedItem.Visible = this.Enabled;

                CesBorderColor = currentBorderColor;
            }
            else
            {
                txtSelectedItem.Visible = this.Enabled;

                lblEnable.Left = txtSelectedItem.Left;
                lblEnable.Top = txtSelectedItem.Top;
                lblEnable.Width = txtSelectedItem.Width;
                lblEnable.Text = txtSelectedItem.Text;
                lblEnable.ForeColor = Color.DarkGray;
                lblEnable.Visible = !this.Enabled;

                currentBorderColor = CesBorderColor;
                CesBorderColor = Color.Silver;
            }
        }

        #endregion Override Methods

        #region Public Methods

        /// <summary>
        /// Return field value from CesSelectedItem. Default field name is CesValueMember
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public SelectedValue<T?> GetValue<T>(string propertyName = "")
        {
            string exceptionMessage = "Property name is not valid";

            if (string.IsNullOrWhiteSpace(propertyName)
                && string.IsNullOrWhiteSpace(CesValueMember))
                throw new Exception(exceptionMessage);

            if (string.IsNullOrWhiteSpace(propertyName)
                && !string.IsNullOrWhiteSpace(CesValueMember))
                propertyName = CesValueMember;

            var propertyInfo =
                CesSelectedItem == null ?
                null :
                CesSelectedItem?.GetType().GetProperty(propertyName);

            if (propertyInfo is null)
                throw new Exception(exceptionMessage);

            var value = propertyInfo.GetValue(CesSelectedItem);

            var result = (T?)value;

            return result;
        }

        #endregion Public Methods
    }
}
