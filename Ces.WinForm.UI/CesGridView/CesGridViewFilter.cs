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

        #region Control Methods

        private void CesGridViewFilter_Load(object sender, EventArgs e)
        {
            txtCriteriaA.Clear();
            txtCriteriaB.Clear();

            q = new();
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
            txtCriteriaA.Focus();
        }

        private void CesGridViewFilter_Deactivate(object sender, EventArgs e)
        {
            //this.Hide(); // Dispose();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (q.Filter == FilterType.Between)
            {
                if (ColumnDataType == typeof(DateTime))
                {
                    q.CriteriaA = dpA.CesStartDate.Value.Date;
                    q.CriteriaB = dpB.CesStartDate.Value.Date;
                }
                else if (ColumnDataType == typeof(bool))
                {
                    q.CriteriaA = rbTrue.Checked ? true : false;
                }
                else
                {
                    q.CriteriaA = txtCriteriaA.CesText;
                    q.CriteriaB = txtCriteriaA.CesText;
                }
            }
            else
            {
                if (ColumnDataType == typeof(string))
                    q.CriteriaA = txtCriteriaA.CesText;

                if (ColumnDataType == typeof(decimal) || ColumnDataType == typeof(int))
                    q.CriteriaA = txtCriteriaA.CesText;

                if (ColumnDataType == typeof(DateTime))
                    q.CriteriaA = dpA.CesStartDate.Value.Date;

                if (ColumnDataType == typeof(bool))
                    q.CriteriaA = rbTrue.Checked ? true : false;
            }

            if (lbSelectionBox != null && lbSelectionBox?.CesSelectedItems?.Count > 0)
            {

                q.SelectedItems = lbSelectionBox.GetSelectedItems();
            }

            this.Hide();
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
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

        private void CesGridViewFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Dispose();
        }

        private void comFilterType_CesSelectedItemChanged(object sender, object? item)
        {
            q.Filter = comFilterType.GetValue<string>().Value;

            pnlTextBox.Visible = false;
            pnlRadioButton.Visible = false;
            pnlDatePicker.Visible = false;

            txtCriteriaA.Visible = false;
            txtCriteriaA.Visible = false;
            dpA.Visible = false;
            dpB.Visible = false;
            rbTrue.Visible = false;
            rbFalse.Visible = false;

            if (q.Filter == FilterType.None)
            {
                sc.Panel1Collapsed = true;
                return;
            }
            else if (q.Filter == FilterType.Between)
            {
                if (ColumnDataType == typeof(DateTime))
                {
                    pnlDatePicker.Visible = true;
                    dpA.Visible = true;
                    dpB.Visible = true;
                }
                else if (ColumnDataType == typeof(bool))
                {
                    pnlRadioButton.Visible = true;
                    rbTrue.Visible = true;
                    rbFalse.Visible = true;
                }
                else
                {
                    pnlTextBox.Visible = true;
                    txtCriteriaA.Visible = true;
                    txtCriteriaA.Visible = true;
                    txtCriteriaA.ChildContainer.Focus();
                }
            }
            else
            {
                if (ColumnDataType == typeof(DateTime))
                {
                    pnlDatePicker.Visible = true;
                    dpA.Visible = true;
                }
                else if (ColumnDataType == typeof(bool))
                {
                    pnlRadioButton.Visible = true;
                    rbTrue.Visible = true;
                    rbFalse.Visible = true;
                }
                else
                {
                    pnlTextBox.Visible = true;
                    txtCriteriaA.Visible = true;
                    txtCriteriaA.ChildContainer.Focus();
                }
            }

            sc.Panel1Collapsed = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion Control Methods
    }
}
