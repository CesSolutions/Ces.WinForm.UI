using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesListBox
{
    public partial class CesListBox : UserControl
    {
        public CesListBox()
        {
            InitializeComponent();
            flp.MouseWheel += new MouseEventHandler(this.ScrollItems);
        }

        public IEnumerable<object> MainData = new List<object>();
        private IEnumerable<Ces.WinForm.UI.CesListBox.CesListBoxItemProperty> FinalData =
            new List<Ces.WinForm.UI.CesListBox.CesListBoxItemProperty>();

        public Ces.WinForm.UI.CesListBox.CesListBoxOptions Options { get; set; }
        private int InitialItemNumber { get; set; } = -1;
        private int TotalItemForScroll { get; set; } = 50;
        private bool _formLoadingCompleted { get; set; }

        [Browsable(false)]
        public object? CesSelectedItem { get; set; }
        [Browsable(false)]
        public IList<object>? CesSelectedItems { get; set; } = new List<object>();

        private bool cesMultiSelect { get; set; }
        public bool CesMultiSelect
        {
            get { return cesMultiSelect; }
            set { cesMultiSelect = value; }
        }

        private Color cesSelectionColor { get; set; } = Color.Black;
        [System.ComponentModel.Category("Ces ListBox")]
        public Color CesSelectionColor
        {
            get { return cesSelectionColor; }
            set { cesSelectionColor = value; }
        }

        private Color cesSelectionForeColor { get; set; } = Color.White;
        [System.ComponentModel.Category("Ces ListBox")]
        public Color CesSelectionForeColor
        {
            get { return cesSelectionForeColor; }
            set { cesSelectionForeColor = value; }
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

        private bool cesShowIndicator { get; set; }
        [System.ComponentModel.Category("Ces ListBox")]
        public bool CesShowIndicator
        {
            get { return cesShowIndicator; }
            set { cesShowIndicator = value; }
        }

        private bool cesShowImage { get; set; }
        [System.ComponentModel.Category("Ces ListBox")]
        public bool CesShowImage
        {
            get { return cesShowImage; }
            set { cesShowImage = value; }
        }

        private int cesMargin { get; set; } = 0;
        [System.ComponentModel.Category("Ces ListBox")]
        public int CesMargin
        {
            get { return cesMargin; }
            set { cesMargin = value; }
        }

        private int cesImageWidth { get; set; } = 24;
        [System.ComponentModel.Category("Ces ListBox")]
        public int CesImageWidth
        {
            get { return cesImageWidth; }
            set { cesImageWidth = value; }
        }

        private int cesItemHeight { get; set; } = 35;
        [System.ComponentModel.Category("Ces ListBox")]
        public int CesItemHeight
        {
            get { return cesItemHeight; }
            set { cesItemHeight = value; }
        }

        private int cesItemWidth { get; set; } = 35;
        [System.ComponentModel.Category("Ces ListBox")]
        public int CesItemWidth
        {
            get { return cesItemWidth; }
            set { cesItemWidth = value; }
        }


        private bool cesShowSearchBox { get; set; }
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

        private bool cesShowStatusBar { get; set; }
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

        public void CesDataSource<T>(IList<T> dataSource) where T : class
        {
            MainData = MainData.Cast<T>().ToList();
            MainData = (List<T>)dataSource;

            GenerateFinalData();
        }

        private void GenerateFinalData()
        {
            FinalData = MainData.Select(s => new CesListBoxItemProperty
            {
                Value = string.IsNullOrEmpty(CesValueMember) ? null : s.GetType().GetProperty(CesValueMember)?.GetValue(s),
                Text = string.IsNullOrEmpty(CesDisplayMember) ? null : s.GetType().GetProperty(CesDisplayMember)?.GetValue(s)?.ToString()
            });

            GenerateBlankItems();
            vs.CesMaxValue = FinalData.Count() - 1;
        }

        private void GenerateBlankItems()
        {
            SetTotalItem();

            for (int i = 0; i < TotalItemForScroll; i++)
            {
                if (i >= flp.Controls.Count)
                    break;

                if (i < TotalItemForScroll)
                    flp.Controls[i].Visible = true;
                else
                    flp.Controls[i].Visible = false;
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

        private void PopulateData()
        {
            if (flp.Controls.Count == 0)
                return;

            if (vs.CesValue < 0)
                return;

            // خالی کردن اطلاعات تمام آیتم ها
            foreach (Ces.WinForm.UI.CesListBox.CesListBoxItem current in flp.Controls)
                current.CesItem = null;

            // واکشی اطلاعات متناسب با محدوده
            var items = FinalData.Take(
                new Range(
                    vs.CesValue,
                    vs.CesValue + TotalItemForScroll)
                ).ToList();

            InitialItemNumber += TotalItemForScroll;

            if (items == null || items.Count == 0)
                return;

            int totalNewItems = items.Count;

            for (int i = 0; i < TotalItemForScroll; i++)
            {
                if (i >= totalNewItems)
                    break;

                var currentItem = (Ces.WinForm.UI.CesListBox.CesListBoxItem)flp.Controls[i];
                currentItem.CesItem = (Ces.WinForm.UI.CesListBox.CesListBoxItemProperty?)items[i];
            }
        }

        private void SetTotalItem()
        {
            // تعداد آیتم های مورد نیاز با توجه به ارتفاع جدید کنترل اصلی
            TotalItemForScroll = (int)Math.Ceiling((double)(flp.Height / 30));

            // بدست آوردن تعداد کنترل های موجود در کنترل اصلی
            int totalExistingItems = flp.Controls.Count;

            var option = new Ces.WinForm.UI.CesListBox.CesListBoxOptions
            {
                ValueMember = CesValueMember,
                DisplayMember = CesDisplayMember,
                ShowIndicator = CesShowIndicator,
                ShowImage = CesShowImage,
                Margin = CesMargin,
                ImageWidth = CesImageWidth,
                ItemHeight = CesItemHeight,
                ItemWidth = CesItemWidth,
            };

            // اگر تعداد آیتم های مورد نیاز از تعداد آیتم های موجود بیشتر باشد
            // باید آیتم های جدید را اضافه کنیم.
            if (TotalItemForScroll > totalExistingItems)
                for (int i = 0; i < TotalItemForScroll - totalExistingItems; i++)
                {
                    var newItem = new Ces.WinForm.UI.CesListBox.CesListBoxItem();

                    newItem.CesListBoxItemClick += GetSelectedItem;
                    newItem.Width = flp.Width;

                    flp.Controls.Add(newItem);
                }

            if (FinalData.Count() > TotalItemForScroll)
                vs.Visible = true;
            else
                vs.Visible = false;
        }

        private void GetSelectedItem(object sender, object? item)
        {
            CesSelectedItem = item;

            var current = CesSelectedItems?.FirstOrDefault(x => x.Equals(item));

            if (current == null && item != null)
                CesSelectedItems?.Add(item);
            else if (current != null)
                CesSelectedItems?.Remove(current);

            CountSelectedItems();
        }

        private void CountSelectedItems()
        {
            lblStatusBar.Text = "Selected Item(s) : " + CesSelectedItems?.Count.ToString();
        }

        public void ClearSelection()
        {
            if (CesSelectedItems == null || CesSelectedItems.Count() == 0)
                return;

            foreach (Ces.WinForm.UI.CesListBox.CesListBoxItem item in flp.Controls)
                item.CesSelected = false;

            CesSelectedItem = null;
            CesSelectedItems.Clear();

            CountSelectedItems();
        }

        private void vs_CesScrollValueChanged(object sender, int value)
        {
            PopulateData();
        }

        private void CesListBox_Load(object sender, EventArgs e)
        {
            _formLoadingCompleted = true;
        }

        private void CesListBox_Resize(object sender, EventArgs e)
        {
            if (!_formLoadingCompleted)
                return;

            SetTotalItem();
            PopulateData();
        }
    }
}
