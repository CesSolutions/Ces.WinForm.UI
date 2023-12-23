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
    public partial class CesSimpleComboBoxPopup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesSimpleComboBoxPopup()
        {

            InitializeComponent();
            flp.MouseWheel += new MouseEventHandler(this.ScrollItems);
        }

        public IEnumerable<object> MainData = new List<object>();
        private IEnumerable<Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem> FinalData =
            new List<Ces.WinForm.UI.CesComboBox.CesSimpleComboBoxItem>();
        
        public Ces.WinForm.UI.CesComboBox.CesListBoxOptions Options { get; set; }
        private int InitialItemNumber { get; set; } = -1;
        private int TotalItemForScroll { get; set; } = 50;
        public object? SelectedItem { get; set; }

        private void CesSimpleComboBoxPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
                    //Dispose();
        }

        private void CesSimpleComboBoxPopup_Deactivate(object sender, EventArgs e)
        {
            //Dispose();
        }

        private void vs_CesScrollValueChanged(object sender, int e)
        {
            PopulateData();
        }

        private void CesSimpleComboBoxPopup_Load(object sender, EventArgs e)
        {
            vs.CesValue = 0;
            GenerateFinalData();
        }

        //public void CesDataSource<T>(IList<T> dataSource) where T : class
        //{
        //    MainData = MainData.Cast<T>().ToList();
        //    MainData = (List<T>)dataSource;

        //    GenerateFinalData();
        //}

        private void GenerateFinalData()
        {
            FinalData = MainData.Select(s => new CesSimpleComboBoxItem
            {
                Value = s.GetType().GetProperty(Options.ValueMember).GetValue(s),
                Text = s.GetType().GetProperty(Options.DisplayMember).GetValue(s).ToString()
            });

            vs.CesMaxValue = FinalData.Count() - 1;
            GenerateBlankTaskItems();
        }


        private void GenerateBlankTaskItems()
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

                var a = (Ces.WinForm.UI.CesComboBox.CesListBoxItem)flp.Controls[i];
                a.CesItem = (CesSimpleComboBoxItem?)items[i];
            }
        }

        private void SetTotalItem()
        {
            // تعداد آیتم های مورد نیاز با توجه به ارتفاع جدید کنترل اصلی
            TotalItemForScroll = (int)Math.Floor((double)(flp.Height / 35));

            // بدست آوردن تعداد کنترل های موجود در کنترل اصلی
            int totalExistingItems = flp.Controls.Count;

            // اگر تعداد آیتم های مورد نیاز از تعداد آیتم های موجود بیشتر باشد
            // باید آیتم های جدید را اضافه کنیم.
            if (TotalItemForScroll > totalExistingItems)
                for (int i = 0; i < TotalItemForScroll - totalExistingItems; i++)
                {
                    var newItem = new Ces.WinForm.UI.CesComboBox.CesComboBoxItem(
                        new CesSimpleComboBoxItem(Text = string.Empty),
                        Options);

                    newItem.CesSimpleComboBoxItemClick += GetSelectedIte;
                    newItem.Width = flp.Width;

                    flp.Controls.Add(newItem);
                }

        }

        private void GetSelectedIte(object sender, object? item)
        {
            SelectedItem = item;
            this.Close();
        }


    }
}
