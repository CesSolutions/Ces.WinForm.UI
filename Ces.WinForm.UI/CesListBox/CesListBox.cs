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
        }

        public IEnumerable<object> MainData = new List<object>();
        private IEnumerable<Ces.WinForm.UI.CesListBox.CesListBoxItemProperty> FinalData =
            new List<Ces.WinForm.UI.CesListBox.CesListBoxItemProperty>();

        public Ces.WinForm.UI.CesComboBox.CesListBoxOptions Options { get; set; }
        private int InitialItemNumber { get; set; } = -1;
        private int TotalItemForScroll { get; set; } = 50;
        public object? SelectedItem { get; set; }


        private string cesValueMember { get; set; }
        [System.ComponentModel.Category("Ces ListBox")]
        public string CesValueMember
        {
            get { return cesValueMember; }
            set
            {
                cesValueMember = value;
            }
        }

        private string cesDisplayMember { get; set; }
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
                Value = s?.GetType()?.GetProperty(Options.ValueMember)?.GetValue(s),
                Text = s?.GetType()?.GetProperty(Options.DisplayMember)?.GetValue(s)?.ToString()
            });

            vs.CesMaxValue = FinalData.Count() - 1;
            GenerateBlankItems();
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

            PopulateData();
        }

        private void ScrollItems(object? sender, MouseEventArgs e)
        {
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
            foreach (Ces.WinForm.UI.CesComboBox.CesListBoxItem current in flp.Controls)
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

                var a = (Ces.WinForm.UI.CesListBox.CesListBoxItem)flp.Controls[i];
                a.CesItem = (Ces.WinForm.UI.CesListBox.CesListBoxItemProperty?)items[i];
            }
        }

        private void SetTotalItem()
        {
            // تعداد آیتم های مورد نیاز با توجه به ارتفاع جدید کنترل اصلی
            TotalItemForScroll = (int)Math.Floor((double)(flp.Height / 35));

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
        }

        private void GetSelectedItem(object sender, object? item)
        {
            SelectedItem = item;
        }

        private void vs_CesScrollValueChanged(object sender, int value)
        {
            PopulateData();
        }

        private void CesListBox_Load(object sender, EventArgs e)
        {
            vs.CesValue = 0;
            GenerateFinalData();
        }
    }
}
