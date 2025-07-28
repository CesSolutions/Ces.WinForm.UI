using Microsoft.VisualBasic;
using System.Data;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridViewFilter : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesGridViewFilter()
        {
            InitializeComponent();
        }

        #region Public Properties

        /// <summary>
        ///زمانی که کاربر روی یک ستون کلیک میکند، گرید باید اطلاعات زیر را
        ///جهت نمایش کادر فیلترینگ مقدار دهی کرده و سپس کادر فیلترینگ را نمایش دهد
        /// </summary>
        /// 
        public Point MouseLocation { get; set; }
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public Type ColumnDataType { get; set; }
        public CesGridFilterAndSort q { get; set; }
        /// <summary>
        /// پروپرتی زیر اطلاعات جاری فیلترینگ ستون جاری را جهت
        /// هرگونه بهره‌برداری برای کادر فیلترینگ نگهداری میکند
        /// این پروپرتی نیز توسط گرید و پس از کلیک کاربر مقداردهی
        /// می شود
        /// </summary>
        public CesGridFilterOperation? CurrentFilter { get; set; }
        /// <summary>
        /// برای آنکه در کادر فیلترینگ همانند برنامه اکسل لیستی از داده‌های ستون
        /// جاری نمایش داده شود تا کاربر براحتی بتواند مقادیر را با استفاده از
        /// ماوس انتخاب کند باید لیست غیرتکراری از داده‌های سلول‌های ستون حاری
        /// را برای کادر فیلترینگ ارسال کنیم تا در لیست آیتم‌ها نمایش داده شود این
        /// لیست نیز پس کلیک کاربر روی عنوان ستون مقداردهی می‌شود
        /// </summary>
        public List<string>? UniqeItems { get; set; } = new List<string>();

        #endregion Public Properties

        private void SetTheme()
        {
            if (this.CesTheme == Infrastructure.ThemeEnum.None)
                ThemeNone();
            else if (this.CesTheme == Infrastructure.ThemeEnum.White)
                ThemeWhite();
            else if (this.CesTheme == Infrastructure.ThemeEnum.Dark)
                ThemeDark();

            lbSelectionBox.CesTheme = this.CesTheme;
        }

        private void ThemeNone()
        {

        }

        private void ThemeWhite()
        {
            this.CesBorderColor = Color.Silver;
            btnSortAsc.CesColorTemplate = CesButton.ColorTemplateEnum.White;
            btnSortDesc.CesColorTemplate = CesButton.ColorTemplateEnum.White;
            pnlTextBox.BackColor = Color.White;
            topLine.BackColor = Color.White;
            topLine.CesLineColor = Color.FromArgb(224, 224, 224);
        }

        private void ThemeDark()
        {
            this.CesBorderColor = Color.FromArgb(90, 90, 90);
            btnSortAsc.CesColorTemplate = CesButton.ColorTemplateEnum.Dark;
            btnSortDesc.CesColorTemplate = CesButton.ColorTemplateEnum.Dark;
            pnlTextBox.BackColor = Color.FromArgb(64, 64, 64);
            topLine.BackColor = Color.FromArgb(64, 64, 64);
            topLine.CesLineColor = Color.FromArgb(90, 90, 90);
        }

        #region Control Methods

        private void CesGridViewFilter_Load(object sender, EventArgs e)
        {
            SetTheme();
            txtCriteriaA.Clear();
            txtCriteriaB.Clear();

            q = new();
            q.ColumnIndex = this.ColumnIndex;
            q.ColumnName = this.ColumnName;

            var comboSource = FilterType.FilterTypes
                .Select(x => new CesListBox.CesListBoxItemProperty
                {
                    Value = x,
                    Text = x,
                })
                .ToList();

            comFilterType.CesValueMember = "Value";
            comFilterType.CesDisplayMember = "Text";
            comFilterType.CesDataSource = comboSource;
            comFilterType.GoToValueMember(FilterType.Contain);

            UniqeItems?.Sort(new DataComparer());
            lbSelectionBox.CesDataSource(UniqeItems);
            lbSelectionBox.ClearSelection();
            this.Location = MouseLocation;

            this.Width = 340;
            this.Height = 455;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (q.Filter == FilterType.Between)
            {
                if (ColumnDataType == typeof(DateTime) || ColumnDataType == typeof(DateTime?))
                {
                    q.CriteriaA = dpA.CesStartDate.Value.Date;
                    q.CriteriaB = dpB.CesStartDate.Value.Date;
                }
                else if (ColumnDataType == typeof(bool) || ColumnDataType == typeof(bool?))
                {
                    q.CriteriaA = rbTrue.Checked ? true : false;
                }
                else
                {
                    q.CriteriaA = txtCriteriaA.CesText;
                    q.CriteriaB = txtCriteriaB.CesText;
                }
            }
            else
            {
                if (ColumnDataType == typeof(string))
                    q.CriteriaA = txtCriteriaA.CesText;

                else if (ColumnDataType == typeof(int) || ColumnDataType == typeof(int?)
                    || ColumnDataType == typeof(decimal) || ColumnDataType == typeof(decimal?)
                    || ColumnDataType == typeof(double) || ColumnDataType == typeof(double?)
                    || ColumnDataType == typeof(long) || ColumnDataType == typeof(long?)
                    || ColumnDataType == typeof(float) || ColumnDataType == typeof(float?)
                    )
                    q.CriteriaA = txtCriteriaA.CesText;

                else if (ColumnDataType == typeof(DateTime) || ColumnDataType == typeof(DateTime?))
                    q.CriteriaA = dpA.CesStartDate.Value.Date;

                else if (ColumnDataType == typeof(bool) || ColumnDataType == typeof(bool?))
                    q.CriteriaA = rbTrue.Checked ? true : false;
            }

            if (lbSelectionBox != null && lbSelectionBox?.CesSelectedItems?.Count > 0)
                q.SelectedItems = lbSelectionBox.GetSelectedItems();

            q.ColumnIndex = this.ColumnIndex;

            this.Hide();
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            q.ColumnIndex = this.ColumnIndex;
            q.ColumnName = this.ColumnName;
            q.ClearColumnFilter = true;
            this.Hide();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            q.ClearAllSort = true;
            q.ClearAllFilter = true;
            this.Hide();
        }

        private void btnSortAsc_Click(object sender, EventArgs e)
        {
            q.ColumnIndex = this.ColumnIndex;
            q.ColumnName = this.ColumnName;
            q.SortType = CesGridSortTypeEnum.ASC;
            this.Hide();
        }

        private void btnSortDesc_Click(object sender, EventArgs e)
        {
            q.ColumnName = this.ColumnName;
            q.SortType = CesGridSortTypeEnum.DESC;
            this.Hide();
        }

        private void btnSortClear_Click(object sender, EventArgs e)
        {
            q.ClearAllSort = true;
            this.Hide();
        }

        private void comFilterType_CesSelectedItemChanged(object sender, object? item)
        {
            q.Filter = comFilterType.GetValue<string>().Value;
            ArrangeUI();
        }

        private void ArrangeUI()
        {
            pnlTextBox.Visible = false;
            pnlRadioButton.Visible = false;
            pnlDatePicker.Visible = false;

            if (comFilterType.GetValue<string>() == FilterType.Between)
            {
                txtCriteriaA.Width = pnlTextBox.Width - txtCriteriaB.Width - 20;
                dpA.Width = pnlDatePicker.Width - dpB.Width - 20;

                txtCriteriaB.Visible = true;
                dpB.Visible = true;
            }
            else
            {
                txtCriteriaA.Width = pnlTextBox.Width - 5;
                dpA.Width = pnlDatePicker.Width - 5;

                txtCriteriaB.Visible = false;
                dpB.Visible = false;
            }

            if (ColumnDataType == typeof(DateTime))
                pnlDatePicker.Visible = true;

            else if (ColumnDataType == typeof(bool))
                pnlRadioButton.Visible = true;

            else
            {
                pnlTextBox.Visible = true;
                txtCriteriaA.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion Control Methods
    }
}
