using Ces.WinForm.UI.CesListBox.Events;
using System.ComponentModel;
using System.Data;

namespace Ces.WinForm.UI.CesListBox
{
    [DefaultEvent(nameof(CesSelectedItemChanged))]
    public partial class CesListBox : UserControl
    {
        public CesListBox()
        {
            InitializeComponent();
            flp.MouseWheel += new MouseEventHandler(this.ScrollItems);
        }

        public event EventHandler<Events.CesSelectionChangeEvent> CesSelectedItemChanged;

        private IEnumerable<object> MainData = new List<object>();
        private IEnumerable<object> TempData = new List<object>();
        private IEnumerable<CesListBoxItemProperty> FinalData = new List<CesListBoxItemProperty>();


        private int TotalItemForScroll { get; set; }
        private bool _isPrimitive { get; set; } = false;
        private bool _loadingData { get; set; }


        [Browsable(false)]
        public object? CesSelectedItem { get; set; }
        [Browsable(false)]
        public IList<object>? CesSelectedItems { get; set; } = new List<object>();

        #region Properties

        private bool cesMultiSelect { get; set; }
        [System.ComponentModel.Category("Ces ListBox")]
        public bool CesMultiSelect
        {
            get { return cesMultiSelect; }
            set
            {
                cesMultiSelect = value;
                ClearSelection();
            }
        }

        private Color cesIndicatorColor { get; set; } = Color.DodgerBlue;
        [System.ComponentModel.Category("Ces ListBox")]
        public Color CesIndicatorColor
        {
            get { return cesIndicatorColor; }
            set
            {
                cesIndicatorColor = value;

                foreach (CesListBoxItem item in flp.Controls)
                    item.CesIndicatorColor = value;
            }
        }

        private Color cesHighlightColor { get; set; } = Color.Khaki;
        [System.ComponentModel.Category("Ces ListBox")]
        public Color CesHighlightColor
        {
            get { return cesHighlightColor; }
            set
            {
                cesHighlightColor = value;

                foreach (CesListBoxItem item in flp.Controls)
                    item.CesHighlightColor = value;
            }
        }

        private Color cesSelectionColor { get; set; } = Color.Gold;
        [System.ComponentModel.Category("Ces ListBox")]
        public Color CesSelectionColor
        {
            get { return cesSelectionColor; }
            set
            {
                cesSelectionColor = value;

                foreach (CesListBoxItem item in flp.Controls)
                    item.CesSelectionColor = value;

                ResetSelectionColor();
            }
        }

        private Color cesSelectionForeColor { get; set; } = Color.Black;
        [System.ComponentModel.Category("Ces ListBox")]
        public Color CesSelectionForeColor
        {
            get { return cesSelectionForeColor; }
            set
            {
                cesSelectionForeColor = value;

                foreach (CesListBoxItem item in flp.Controls)
                    item.CesSelectionForeColor = value;

                ResetSelectionColor();
            }
        }

        private string cesValueMember { get; set; } = string.Empty;
        [System.ComponentModel.Category("Ces ListBox")]
        public string CesValueMember
        {
            get { return cesValueMember; }
            set
            {
                cesValueMember = value;
            }
        }

        private string cesDisplayMember { get; set; } = string.Empty;
        [System.ComponentModel.Category("Ces ListBox")]
        public string CesDisplayMember
        {
            get { return cesDisplayMember; }
            set
            {
                cesDisplayMember = value;
            }
        }

        private string cesImageMember { get; set; } = string.Empty;
        [System.ComponentModel.Category("Ces ListBox")]
        public string CesImageMember
        {
            get { return cesImageMember; }
            set
            {
                cesImageMember = value;
            }
        }

        private bool cesShowIndicator { get; set; }
        [System.ComponentModel.Category("Ces ListBox")]
        public bool CesShowIndicator
        {
            get { return cesShowIndicator; }
            set
            {
                cesShowIndicator = value;

                foreach (CesListBoxItem item in flp.Controls)
                    item.CesShowIndicator = value;
            }
        }

        private bool cesShowImage { get; set; }
        [System.ComponentModel.Category("Ces ListBox")]
        public bool CesShowImage
        {
            get { return cesShowImage; }
            set
            {
                cesShowImage = value;

                foreach (CesListBoxItem item in flp.Controls)
                    item.CesShowImage = value;
            }
        }

        private int cesImageWidth { get; set; } = 24;
        [System.ComponentModel.Category("Ces ListBox")]
        public int CesImageWidth
        {
            get { return cesImageWidth; }
            set
            {
                cesImageWidth = value;

                foreach (CesListBoxItem item in flp.Controls)
                    item.CesImageWidth = value;
            }
        }

        private int cesItemHeight { get; set; } = 30;
        [System.ComponentModel.Category("Ces ListBox")]
        public int CesItemHeight
        {
            get { return cesItemHeight; }
            set
            {
                cesItemHeight = value;

                foreach (CesListBoxItem item in flp.Controls)
                    item.CesItemHeight = value;
            }
        }

        private bool cesShowSearchBox { get; set; } = true;
        [System.ComponentModel.Category("Ces ListBox")]
        public bool CesShowSearchBox
        {
            get { return cesShowSearchBox; }
            set
            {
                cesShowSearchBox = value;
                pnlSeachBox.Visible = value;
            }
        }

        private bool cesShowStatusBar { get; set; } = true;
        [System.ComponentModel.Category("Ces ListBox")]
        public bool CesShowStatusBar
        {
            get { return cesShowStatusBar; }
            set
            {
                cesShowStatusBar = value;
                lblStatusBar.Visible = value;
            }
        }

        private Infrastructure.ThemeEnum cesTheme { get; set; }
            = Infrastructure.ThemeEnum.White;
        [System.ComponentModel.Category("Ces ListBox")]
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

        private void SetTheme()
        {
            if (this.CesTheme == Infrastructure.ThemeEnum.None)
                ThemeNone();
            else if (this.CesTheme == Infrastructure.ThemeEnum.White)
                ThemeWhite();
            else if (this.CesTheme == Infrastructure.ThemeEnum.Dark)
                ThemeDark();

            foreach (CesListBoxItem item in flp.Controls)
                item.CesTheme = CesTheme;
        }

        private void ThemeNone()
        {

        }

        private void ThemeWhite()
        {
            this.BackColor = Color.Silver;
            flp.BackColor = Color.White;
            pnlSeachBox.BackColor = Color.White;
            txtSearchBox.BackColor = Color.White;
            txtSearchBox.ForeColor = Color.Black;
            pbSearch.BackColor = Color.White;
            topLine.BackColor = Color.White;
            topLine.CesLineColor = Color.FromArgb(224, 224, 224);
            lblStatusBar.BackColor = Color.WhiteSmoke;
            lblStatusBar.ForeColor = Color.DimGray;
        }

        private void ThemeDark()
        {
            this.BackColor = Color.Silver;
            flp.BackColor = Color.FromArgb(64, 64, 64);
            pnlSeachBox.BackColor = Color.FromArgb(64, 64, 64);
            txtSearchBox.BackColor = Color.FromArgb(64, 64, 64);
            txtSearchBox.ForeColor = Color.Silver;
            pbSearch.BackColor = Color.FromArgb(64, 64, 64);
            topLine.BackColor = Color.FromArgb(64, 64, 64);
            topLine.CesLineColor = Color.FromArgb(90, 90, 90);
            lblStatusBar.BackColor = Color.FromArgb(50, 50, 50);
            lblStatusBar.ForeColor = Color.Silver;
        }

        public void CesDataSource(IEnumerable<object> dataSource)
        {
            _loadingData = true;
            ClearSelection();

            //ابتدا اگر آیتمی وجود داشته باشد باید حذف شوند
            foreach (Ces.WinForm.UI.CesListBox.CesListBoxItem item in flp.Controls)
                flp.Controls.Clear();

            CesSelectedItem = null;
            MainData = dataSource;
            TempData = dataSource;

            IsPrimitiveType(MainData);
            GenerateFinalData();
            _loadingData = false;
        }

        /// <summary>
        /// این متد بررسی می‌کند که آیا آیتم‌های سورس ارسال شده
        /// از نوع مقادیر پایه در دات نت است یا یک نوع سفارشی
        /// که برنامه با توجه به این بررسی در نمایش داده ها
        /// اقدام خواهد کرد
        /// </summary>
        /// <param name="list"></param>
        private void IsPrimitiveType(IEnumerable<object> list)
        {
            if (list == null)
                return;

            _isPrimitive = list.All(x
                => x.GetType().IsPrimitive
                || x.GetType().IsEnum
                || x.GetType() == typeof(string)
                || x.GetType() == typeof(decimal)
                || x.GetType() == typeof(int)
                || x.GetType() == typeof(long)
                || x.GetType() == typeof(DateTime)
                || x.GetType() == typeof(DateTimeOffset)
                || x.GetType() == typeof(TimeSpan)
                || x.GetType() == typeof(Guid));
        }

        private void GenerateFinalData()
        {
            if (MainData == null)            
                return;            

            if (_isPrimitive)
            {
                FinalData = MainData.Select(x => new CesListBoxItemProperty
                {
                    Value = x,
                    Text = x.ToString(),
                    Image = null,

                }).ToList();
            }
            else
            {
                FinalData = MainData.Select(x => new CesListBoxItemProperty
                {
                    Value = string.IsNullOrEmpty(CesValueMember) ? null : x.GetType().GetProperty(CesValueMember)?.GetValue(x),
                    Text = string.IsNullOrEmpty(CesDisplayMember) ? null : x.GetType().GetProperty(CesDisplayMember)?.GetValue(x)?.ToString(),
                    Image = string.IsNullOrEmpty(CesImageMember) ? null : (Image)(x.GetType()?.GetProperty(CesImageMember)?.GetValue(x))

                }).ToList();
            }

            GenerateBlankItems();
        }

        private void GenerateBlankItems()
        {
            SetTotalItem();
            ClearItems();

            for (int i = 0; i < TotalItemForScroll; i++)
            {
                if (i >= flp.Controls.Count)
                    break;

                ((CesListBoxItem)flp.Controls[i]).CesTheme = CesTheme;

                if (i < TotalItemForScroll)
                    flp.Controls[i].Visible = true;
                else
                    flp.Controls[i].Visible = false;
            }
            
            PopulateData();
        }

        private void SetTotalItem()
        {
            //تعداد آیتم های مورد نیاز با توجه به ارتفاع جدید کنترل اصلی
            TotalItemForScroll = (int)Math.Ceiling((double)(flp.Height / CesItemHeight));
            
            //بدست آوردن تعداد کنترل های موجود در کنترل اصلی
            int totalExistingItems = flp.Controls.Count;

            //اگر تعداد آیتم های مورد نیاز از تعداد آیتم های موجود بیشتر باشد
            //باید آیتم های جدید را اضافه کنیم.
            if (TotalItemForScroll > totalExistingItems)
                for (int i = 0; i < TotalItemForScroll - totalExistingItems; i++)
                {
                    var newItem = new Ces.WinForm.UI.CesListBox.CesListBoxItem();
                    newItem.CesItemClick += new EventHandler<Events.CesItemClickEvent>(ClickItemHandler);
                    newItem.Width = flp.Width;
                    newItem.Height = CesItemHeight;
                    newItem.CesShowImage = CesShowImage;

                    flp.Controls.Add(newItem);
                }

            if (FinalData.Count() > TotalItemForScroll)
                vs.Visible = true;
            else
                vs.Visible = false;

            //تنظیم مقدار حرکت اسکرول بار عمودی
            //با توجه به ارتفاع کمبو که توسط کاربر قابل تنظیم 
            //است ممکن است تعداد آیتم های قابل رویت بیش از تعداد
            //آیتم های موجود در منبع داده باشد و بنابراین مقدار اولیه
            //مقدار حداکثر نباید عددی منفی باشد در غیر اینصورت به
            //اندازه تعداد آیتم های خارج از محدوده نمایش در لیست تنظیم
            //خواهد شد تا میزان اسکرول تعیین شود
            vs.CesMaxValue = (FinalData.Count() - TotalItemForScroll) < 0 ? 0 : FinalData.Count() - TotalItemForScroll;
        }

        private void ClearItems()
        {
            //خالی کردن اطلاعات تمام آیتم ها
            foreach (Ces.WinForm.UI.CesListBox.CesListBoxItem current in flp.Controls)
            {
                current.CesItem = null;
                current.Width = flp.Width;
            }
        }

        private void PopulateData()
        {
            if (flp.Controls.Count == 0)
                return;

            if (vs.CesValue < 0)
                return;

            //واکشی اطلاعات متناسب با محدوده
            var items = FinalData.Take(
                new Range(
                    vs.CesValue,
                    vs.CesValue + TotalItemForScroll))
                .ToList();

            if (items == null || items.Count == 0)
                return;

            for (int i = 0; i < TotalItemForScroll; i++)
            {
                var currentItem = (Ces.WinForm.UI.CesListBox.CesListBoxItem)flp.Controls[i];

                //اگر آخرین گزینه نمایش داده شود دیگر نیازی به 
                //نمایش ردیف‌های خالی در انتها نیست و بهتر است
                //آخرین آیتم در لیست در انتها نمایش داده شود و
                //زیر آخرین آیتم دیگر فضای خالی وجود نداشته باشد
                //
                //اگر به هر دلیلی عملیات اسکرول بیش از آیتم های موود انجام شود
                //برنامه مقدار نول را جایگزین مقدار در آیتم اضافه خواهد کرد که
                //این کار باعث میشود آیتم خالی نمایش داده شود
                if (i >= items.Count)
                    currentItem.CesItem = null;
                else
                {
                    var data = (Ces.WinForm.UI.CesListBox.CesListBoxItemProperty?)items[i];
                    currentItem.CesItem = data;
                }
            }
        }

        private void ScrollItems(object? sender, MouseEventArgs e)
        {
            if (!vs.Visible)
                return;

            if (e.Delta < 0)
                vs.CesValue += vs.CesMovingStep;
            else
                vs.CesValue -= vs.CesMovingStep;
        }

        private void ClickItemHandler(object sender, CesItemClickEvent e)
        {
            if (!CesMultiSelect)
                ClearSelection();

            if (_isPrimitive)
            {
                CesSelectedItem = MainData.FirstOrDefault();
            }
            else
            {
                CesSelectedItem =
                    MainData.FirstOrDefault(x =>
                    x.GetType().GetProperty(CesValueMember)?.GetValue(x).ToString() ==
                    e.Item?.Value.ToString());
            }

            var current = CesSelectedItems?.FirstOrDefault(x
                => x.GetType().GetProperty("Value")?.GetValue(x)?.ToString()
                == e.Item?.GetType()?.GetProperty("Value")?.GetValue(e.Item)?.ToString());

            if (CesSelectedItems == null)
                CesSelectedItems = new List<object>();

            if (current == null && e.Item != null)
                CesSelectedItems?.Add(CesSelectedItem);
            else if (current != null)
                CesSelectedItems?.Remove(current);

            if (!CesMultiSelect)
                foreach (CesListBoxItem item in flp.Controls)
                    if (item?.CesItem?.Value == e.Item?.Value)
                        item.CesSelected = !item.CesSelected;

            CountSelectedItems();
            CesSelectedItemChanged?.Invoke(this, new UI.CesListBox.Events.CesSelectionChangeEvent { Item = CesSelectedItem });
        }

        private void CountSelectedItems()
        {
            lblStatusBar.Text = "Selected Item(s) : " + CesSelectedItems?.Count.ToString();
        }

        public void ClearSelection()
        {
            foreach (CesListBoxItem item in flp.Controls)
                item.CesSelected = false;

            CesSelectedItems?.Clear();
            CesSelectedItems = null;
            CesSelectedItem = null;

            CountSelectedItems();
        }

        private void vs_CesScrollValueChanged(object sender, int value)
        {
            if (_loadingData)
                return;

            PopulateData();
            ShowSelectedItems();
        }

        private void CesListBox_SizeChanged(object sender, EventArgs e)
        {
            ShowSelectedItems();
        }

        private void Search()
        {
            if (_isPrimitive)
            {
                MainData = TempData
                    .Where(x => x
                        .ToString()
                        .ToLower()
                        .Contains(this.txtSearchBox.Text.ToLower()))
                    .ToList();
            }
            else
            {
                MainData = TempData
                    .Where(x => x
                        .GetType()
                        .GetProperty(CesDisplayMember)
                        .GetValue(x)
                        .ToString()
                        .ToLower()
                        .Contains(this.txtSearchBox.Text.ToLower()))
                    .ToList();
            }

            GenerateFinalData();
            ShowSelectedItems();
        }

        /// <summary>
        /// زمانی که در کادر جستجو مقداری وارد شود آیتم‌های لیست تغییر
        /// خواهند کرد و برای آنکه کاربر متوجه شود که کدام آیتم از قبل
        /// انتخاب شده است باید آیتم‌های انتخاب شده هایلایت شوند
        /// </summary>
        public void ShowSelectedItems()
        {
            if (CesSelectedItems == null || CesSelectedItems.Count == 0)
                return;

            foreach (CesListBoxItem item in flp.Controls)
            {
                if (item.CesItem == null)
                    continue;

                if (_isPrimitive)
                {
                    if (CesSelectedItems.Any(x => x.GetType()?.GetProperty("Value")?.GetValue(x)?.ToString() == item?.CesItem?.Value?.ToString()))
                        item.CesSelected = true;
                    else
                        item.CesSelected = false;
                }
                else
                {
                    var a = CesSelectedItems.FirstOrDefault(x => x.GetType()?.GetProperty(CesValueMember)?.GetValue(x)?.ToString() == item?.CesItem?.Value?.ToString());

                    if (CesSelectedItems.Any(x => x.GetType()?.GetProperty(CesValueMember)?.GetValue(x)?.ToString() == item?.CesItem?.Value?.ToString()))
                        item.CesSelected = true;
                    else
                        item.CesSelected = false;
                }
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void ResetSelectionColor()
        {
            foreach (Ces.WinForm.UI.CesListBox.CesListBoxItem current in flp.Controls)
                if (current.CesSelected)
                {
                    current.BackColor = CesSelectionColor;
                    current.lblItemText.ForeColor = CesSelectionForeColor;
                }
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            ClearSeachBox();
        }

        public void ClearSeachBox()
        {
            txtSearchBox.Clear();
            txtSearchBox.Focus();
        }

        /// <summary>
        /// متد زیر آیتم‌های انتخاب شده را بصورت لیستی از 
        /// CesListBoxItemProperty
        /// بر می‌گرداند نه از نوع 
        /// object
        /// </summary>
        /// <returns></returns>
        public List<CesListBoxItemProperty>? GetSelectedItems()
        {
            if (CesSelectedItems == null)
                return null;

            return CesSelectedItems.Select(x => new CesListBoxItemProperty
            {
                Value = ((CesListBoxItemProperty)x).Value,
                Text = ((CesListBoxItemProperty)x).Text

            }).ToList();
        }

        private void flp_SizeChanged(object sender, EventArgs e)
        {
            if (_loadingData || MainData == null || MainData.Count() == 0)
                return;

            GenerateBlankItems();
        }
    }
}
