using Ces.WinForm.UI.CesListBox;
using System.Data;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridViewFilter : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesGridViewFilter()
        {
            InitializeComponent();
        }

        #region Properties

        public Point MouseLocation { get; set; }
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public Type ColumnDataType { get; set; }
        public CesGridFilterAndSort q { get; set; }
        public CesGridFilterOperation? CurrentFilter { get; set; }
        public List<string>? UniqeItems { get; set; } = new List<string>();

        #endregion Properties

        #region Control Methods

        private void CesGridViewFilter_Load(object sender, EventArgs e)
        {
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
