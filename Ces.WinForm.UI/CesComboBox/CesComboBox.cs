using System.ComponentModel;

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

        public event EventHandler<Events.CesReloadDataEvent> CesLoadClicked;
        public event EventHandler<Events.CesAddItemEvent> CesAddItemClicked;
        public event EventHandler<Events.CesEditItemEvent> CesEditItemClicked;

        #region Properties

        private Ces.WinForm.UI.CesComboBox.CesComboBoxPopup frmPopup;
        private Color currentBorderColor;

        private int cesItemHeight = 30;
        [System.ComponentModel.Category("CesComboBox")]
        public int CesItemHeight
        {
            get { return cesItemHeight; }
            set { cesItemHeight = value; }
        }

        private int cesImageWidth = 24;
        [System.ComponentModel.Category("CesComboBox")]
        public int CesImageWidth
        {
            get { return cesImageWidth; }
            set { cesImageWidth = value; }
        }

        private bool cesShowIndicator = false;
        [System.ComponentModel.Category("CesComboBox")]
        public bool CesShowIndicator
        {
            get { return cesShowIndicator; }
            set { cesShowIndicator = value; }
        }

        private bool cesShowImage = true;
        [System.ComponentModel.Category("CesComboBox")]
        public bool CesShowImage
        {
            get { return cesShowImage; }
            set { cesShowImage = value; }
        }

        private bool cesAlignToRight = false;
        [System.ComponentModel.Category("CesComboBox")]
        public bool CesAlignToRight
        {
            get { return cesAlignToRight; }
            set { cesAlignToRight = value; }
        }

        private Size cesPopupSize = new Size(350, 400);
        [System.ComponentModel.Category("CesComboBox")]
        public Size CesPopupSize
        {
            get { return cesPopupSize; }
            set { cesPopupSize = value; }
        }

        private bool cesShowSearchBox { get; set; } = true;
        [System.ComponentModel.Category("CesComboBox")]
        public bool CesShowSearchBox
        {
            get { return cesShowSearchBox; }
            set
            {
                cesShowSearchBox = value;
            }
        }

        private bool cesShowStatusBar { get; set; } = true;
        [System.ComponentModel.Category("CesComboBox")]
        public bool CesShowStatusBar
        {
            get { return cesShowStatusBar; }
            set
            {
                cesShowStatusBar = value;
            }
        }

        private object? cesSelectedValue;
        /// <summary>
        /// This property Get/Set type of selected item
        /// </summary>
        [Browsable(false)]
        public object? CesSelectedValue
        {
            get { return cesSelectedValue; }
            set { cesSelectedValue = value; }
        }

        private object? cesSelectedItem { get; set; }
        /// <summary>
        /// یک نوع را از لیست داده ها انتخاب و یا بر میگرداند
        /// </summary>
        [System.ComponentModel.Category("CesComboBox")]
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

                //باید مقدار جاری در متغیر ذخیره شود تا اگر 
                //دیتا مجدد بارگذاری شد برنامه با توجه به تنظیم
                //CesKeepPreviousSelection
                //بتواند آیتم قبلی را در حالت انتخاب نگهدارد
                //تا کاربر مجبور به انتخا آیتم قبلی خود نباشد
                _previousValueMember = CesSelectedValue;

                txtSelectedItem.Text =
                    value == null ?
                    string.Empty :
                    value?.GetType().GetProperty(CesDisplayMember)?.GetValue(value)?.ToString();

                if (CesSelectedItemChanged != null)
                    CesSelectedItemChanged(this, value);
            }
        }

        private object? _previousValueMember;
        /// <summary>
        /// After loading data,automatically select previous item
        /// </summary>
        private bool cesKeepPreviousSelection = true;
        [System.ComponentModel.Category("Ces TextBox")]
        [System.ComponentModel.Description("After loading data, automatically select previous item")]
        public bool CesKeepPreviousSelection
        {
            get
            {
                return cesKeepPreviousSelection;
            }
            set
            {
                cesKeepPreviousSelection = value;

                if (value)
                    cesSelectFirstItem = false;
            }
        }

        private bool cesSelectFirstItemIfPreviousWasNull = true;
        [System.ComponentModel.Category("Ces TextBox")]
        [System.ComponentModel.Description("After loading data, automatically select first item if previous value was null")]
        public bool CesSelectFirstItemIfPreviousWasNull
        {
            get
            {
                return cesSelectFirstItemIfPreviousWasNull;
            }
            set
            {
                cesSelectFirstItemIfPreviousWasNull = value;

                if (value)
                    cesSelectFirstItem = false;
            }
        }

        private bool cesSelectFirstItem = false;
        [System.ComponentModel.Category("Ces TextBox")]
        [System.ComponentModel.Description("After loading data, automatically select first item")]
        public bool CesSelectFirstItem
        {
            get
            {
                return cesSelectFirstItem;
            }
            set
            {
                cesSelectFirstItem = value;

                if (value)
                {
                    cesKeepPreviousSelection = false;
                    cesSelectFirstItemIfPreviousWasNull = false;
                }
            }
        }

        private bool cesAdjustPopupToParentWidth = true;
        [System.ComponentModel.Category("CesComboBox")]
        public bool CesAdjustPopupToParentWidth
        {
            get { return cesAdjustPopupToParentWidth; }
            set { cesAdjustPopupToParentWidth = value; }
        }

        private bool cesShowClearButton = false;
        [System.ComponentModel.Category("CesComboBox")]
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
        [System.ComponentModel.Category("CesComboBox")]
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
        [System.ComponentModel.Category("CesComboBox")]
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
        [System.ComponentModel.Category("CesComboBox")]
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
        /// <summary>
        /// برای آیتم‌هایی که به عنوان داده به کنترل تخصیص داده شده اند 
        /// می‌بایست ستونی که شناسه و یا کلید اصلی است را معرفی کرد
        /// </summary>
        [System.ComponentModel.Category("CesComboBox")]
        public string CesValueMember
        {
            get { return cesValueMember; }
            set
            {
                cesValueMember = value;
            }
        }

        private string cesDisplayMember { get; set; }
        /// <summary>
        /// این ویژگی نام ستونی که باید مقدار آن در کمبو باکس
        /// نمایش داده شود را مشخص می‌کند
        /// </summary>
        [System.ComponentModel.Category("CesComboBox")]
        public string CesDisplayMember
        {
            get { return cesDisplayMember; }
            set
            {
                cesDisplayMember = value;
            }
        }

        private IEnumerable<object>? cesDataSource;
        [Browsable(false)]
        [System.ComponentModel.Category("CesComboBox")]
        public IEnumerable<object>? CesDataSource
        {
            get { return cesDataSource; }
            set
            {
                cesDataSource = value;
                ReadyPopup();

                //اگر انتخاب آخرین آیتم فعال باشد، برنامه آیتم قبلی را مجدد انتخاب خواهد کرد
                if (CesKeepPreviousSelection && _previousValueMember != null)
                    GoToValueMember(_previousValueMember);

                //اگر انتخاب اولین آیتم فعال باشد یا آنکه انتخاب قبلی فعال باشد و شرطی دومش
                //اینکه مقدار قبلی هنوز در اولین بارگذاری تعیین نشده است باید اولین آیتم
                //را در حالت انتخا قرار دهد.
                if ((CesSelectFirstItem && value != null)
                    || (CesSelectFirstItemIfPreviousWasNull && _previousValueMember == null && value != null))
                    CesSelectedItem = ((IEnumerable<object>)value).FirstOrDefault();
            }
        }

        private bool cesLoadingMode;
        /// <summary>
        /// اگر مقدار این ویژگی برابر 1 باشد دکمه های تعبیه شده در کنترل
        /// تا پایان عملیات غیرفعال می شوند و کاربر عبارت Loading... را خواهد دید
        /// </summary>
        [System.ComponentModel.Category("CesComboBox")]
        public bool CesLoadingMode
        {
            get
            {
                return cesLoadingMode;
            }
            set
            {
                cesLoadingMode = value;
                SetLoadingMode();
            }
        }

        private bool cesDropDownOnFocus;
        public bool CesDropDownOnFocus
        {
            get
            {
                return cesDropDownOnFocus;
            }
            set
            {
                cesDropDownOnFocus = value;
            }
        }

        private Infrastructure.ThemeEnum cesTheme { get; set; }
            = Infrastructure.ThemeEnum.White;
        [Category("CesTextBox")]
        public Infrastructure.ThemeEnum CesTheme
        {
            get { return cesTheme; }
            set
            {
                cesTheme = value;
                SetTheme();
            }
        }

        #endregion Properties

        #region Custom Methods

        private void SetTheme()
        {
            if (this.CesTheme == Infrastructure.ThemeEnum.None)
                ThemeNone();
            else if (this.CesTheme == Infrastructure.ThemeEnum.White)
                ThemeWhite();
            else if (this.CesTheme == Infrastructure.ThemeEnum.Dark)
                ThemeDark();
        }

        private void ThemeNone()
        {
            btnOpen.Image = Properties.Resources.CesComboBoxDropDown;
            btnAddItem.Image = Properties.Resources.CesComboBoxAddItem;
            btnEditItem.Image = Properties.Resources.CesComboBoxEditItem;
            btnReloadData.Image = Properties.Resources.CesComboBoxReloadData;
            btnClear.Image = Properties.Resources.CesComboBoxClear;
        }

        private void ThemeWhite()
        {
            this.BackColor = Color.White;
            this.CesBackColor = Color.White;
            this.CesBorderColor = Color.DeepSkyBlue;
            this.txtSelectedItem.BackColor = Color.White;
            this.txtSelectedItem.ForeColor = Color.Black;
            this.lblEnable.BackColor = Color.White;
            this.lblEnable.ForeColor = Color.Black;
            this.lblLoading.BackColor = Color.White;
            this.lblLoading.ForeColor = Color.Black;
            this.pnlContainer.BackColor = Color.White;
            this.CesTitleTextColor = Color.White;
            this.CesFocusColor = Color.White;

            btnOpen.Image = Properties.Resources.CesComboBoxDropDown;
            btnAddItem.Image = Properties.Resources.CesComboBoxAddItem;
            btnEditItem.Image = Properties.Resources.CesComboBoxEditItem;
            btnReloadData.Image = Properties.Resources.CesComboBoxReloadData;
            btnClear.Image = Properties.Resources.CesComboBoxClear;
        }

        private void ThemeDark()
        {
            this.BackColor = Color.FromArgb(64, 64, 64);
            this.CesBackColor = Color.FromArgb(64, 64, 64);
            this.CesBorderColor = Color.FromArgb(90, 90, 90);
            this.txtSelectedItem.BackColor = Color.FromArgb(64, 64, 64);
            this.txtSelectedItem.ForeColor = Color.Silver;
            this.lblEnable.BackColor = Color.FromArgb(64, 64, 64);
            this.lblEnable.ForeColor = Color.Silver;
            this.lblLoading.BackColor = Color.FromArgb(64, 64, 64);
            this.lblLoading.ForeColor = Color.Silver;
            this.pnlContainer.BackColor = Color.FromArgb(90, 90, 90);
            this.CesTitleTextColor = Color.Silver;
            this.CesFocusColor = Color.FromArgb(64, 64, 64);

            btnOpen.Image = Properties.Resources.CesComboBoxDropDownDark;
            btnAddItem.Image = Properties.Resources.CesComboBoxAddItemDark;
            btnEditItem.Image = Properties.Resources.CesComboBoxEditItemDark;
            btnReloadData.Image = Properties.Resources.CesComboBoxReloadDataDark;
            btnClear.Image = Properties.Resources.CesComboBoxClearDark;
        }

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
            frmPopup.CesSelectedItemChanged +=
                new Ces.WinForm.UI.CesComboBox.CesComboBoxPopup.CesSelectedItemChangedEventHandler(SelectedItemChanged);
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

            frmPopup.CesBorderColor = CesBorderColor;
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
            var popupTopLocation = comboLocation.Y - frmPopup.Height;
            var topSpace = comboLocation.Y;
            var bottomSpace = screenSize.Height - comboLocation.Y - this.Height;

            // Top Location
            if (popupBottomLocation < screenSize.Height)
            {
                frmPopup.Top = comboLocation.Y + this.Height;
            }
            else
            {
                if (bottomSpace > topSpace)
                {
                    //قبل از اینکه فرم در بالا باز شود بررسی میکنیم که اگز فضای
                    //پایین بزرگتر از فضای بالا باشد، ابتدا ارتفاع فرم را تغییر میدهیم
                    //بعد فرم را موقعیت دهی میکنیم
                    frmPopup.Height = bottomSpace;
                    frmPopup.Top = comboLocation.Y + this.Height;
                }
                else
                {
                    if (frmPopup.Height > topSpace)
                        frmPopup.Height = topSpace;

                    frmPopup.Top = comboLocation.Y - frmPopup.Height;
                }
            }

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

        private void SetLoadingMode()
        {
            //جهت فعال کردن حالت بارگذاری، کنترل باید فعال باشد
            if (!this.Enabled)
                return;

            pnlButtonContainer.Enabled = !CesLoadingMode;
            txtSelectedItem.Visible = !CesLoadingMode;
            lblLoading.Visible = CesLoadingMode;
            Application.DoEvents();
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

            lblLoading.Left = 5;
            lblLoading.Width = pnlContainer.Width - 5 - pnlButtonContainer.Width - 5;
            lblLoading.Top = (pnlContainer.Height / 2) - (lblLoading.Height / 2);
        }

        #endregion Custom Methods

        #region Control Methods

        private void CesSimpleComboBox_Paint(object sender, PaintEventArgs e)
        {
            this.lblEnable.BackColor = CesBackColor;
            this.txtSelectedItem.BackColor = CesBackColor;
            this.lblLoading.BackColor = CesBackColor;
            this.GenerateBorder(this);
        }

        private void frmDeactivated(object? sender, EventArgs e)
        {
            // frmPopup.Hide();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DropDown();
        }

        private void DropDown()
        {
            if (CesDataSource == null)
                return;

            ReadyPopup();
            frmPopup.CesTheme = this.cesTheme;
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
            CesLoadClicked?.Invoke(this, new UI.CesComboBox.Events.CesReloadDataEvent());
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            CesEditItemClicked?.Invoke(this, new UI.CesComboBox.Events.CesEditItemEvent());
        }

        private void CesComboBox_Enter(object sender, EventArgs e)
        {
            txtSelectedItem.Focus();
            DropDown();
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

            //برای آنکه تنظیمات به منظور نمایشکنترل هایصحیح دچار مشکل نشود
            //در زمان فعال و یا غیر فعال کردن کنترل باید حالت بارگذاری کنترل
            //فالس باشد
            cesLoadingMode = false;

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

        private void pnlContainer_Resize(object sender, EventArgs e)
        {
            SetTextBoxWidth();
        }

        #endregion Override Methods

        #region Public Methods

        /// <summary>
        /// بصورت پیشفرض مقدار CesValueMember را بر میگرداند اما می‌توان نام پروپرتی‌های دیگری را نیز
        /// با معرفی نام پروپرتی به عنوان پارامتر ورودی متد بدست آورد
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public SelectedValue<T?> GetValue<T>(string propertyName = "")
        {
            if (CesSelectedItem == null)
                return new SelectedValue<T?> { Value = default };

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

        public void GoToValueMember<T>(T searchValue)
        {
            if (searchValue == null)
            {
                CesSelectedItem = null;
                return;
            }

            // Ensure CesDataSource is not null
            if (CesDataSource is not IEnumerable<object> source)
            {
                CesSelectedItem = null;
                return;
            }

            foreach (var item in source)
            {
                if (item == null)
                    continue;

                var propertyInfo = item.GetType().GetProperty(CesValueMember);

                if (propertyInfo == null)
                    continue;

                var propertyValue = propertyInfo.GetValue(item);

                if (Equals(propertyValue, searchValue))
                {
                    CesSelectedItem = item;
                    return;
                }
            }

            //اگر در جستجو چیزی پیدا نشود مقدار انتخاب شده برابر نول خواهد شد
            CesSelectedItem = null;
        }

        public void GoToDisplayMember<T>(T searchValue)
        {
            if (searchValue == null)
            {
                CesSelectedItem = null;
                return;
            }

            // Ensure CesDataSource is not null
            if (CesDataSource is not IEnumerable<object> source)
            {
                CesSelectedItem = null;
                return;
            }

            foreach (var item in source)
            {
                if (item == null)
                    continue;

                var propertyInfo = item.GetType().GetProperty(CesDisplayMember);
                if (propertyInfo == null)
                    continue;

                var propertyValue = propertyInfo.GetValue(item);

                if (Equals(propertyValue, searchValue))
                {
                    CesSelectedItem = item;
                    return;
                }
            }

            //اگر در جستجو چیزی پیدا نشود مقدار انتخاب شده برابر نول خواهد شد
            CesSelectedItem = null;
        }

        public void ClearPreviousSelection()
        {
            _previousValueMember = null;
        }

        /// <summary>
        /// Return bool to find that, previous selection is not null
        /// </summary>
        /// <returns></returns>
        public bool HasPreviousSelection()
        {
            return _previousValueMember == null;
        }

        /// <summary>
        /// دریافت عبارت نمایش داده شده در کمبوباکس
        /// </summary>
        /// <returns></returns>
        public string? GetDisplayMember()
        {
            if (CesSelectedItem == null)
                return null;

            return txtSelectedItem.Text;
        }

        #endregion Public Methods
    }
}
