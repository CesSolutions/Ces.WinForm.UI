﻿using System.Data;

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
        public string ColumnText { get; set; }
        public Type ColumnDataType { get; set; }
        public CesGridFilterAndSort q { get; set; }
        public bool ClearFilter { get; set; }
        public CesGridFilterOperation? CurrentFilter { get; set; }
        public CesGridSortTypeEnum CurrentSort { get; set; }

        #endregion Properties

        #region Control Methods

        private void CesGridViewFilter_Load(object sender, EventArgs e)
        {
            q = new();

            q.ColumnName = this.ColumnName;

            var comboSource = new List<Ces.WinForm.UI.CesListBox.CesListBoxItemProperty>();

            comboSource = System.Enum
                .GetNames(typeof(CesGridFilterTypeEnum))
                .OrderBy(x => x)
                .Select(s => new CesListBox.CesListBoxItemProperty
                {
                    Value = s,
                    Text = s,
                })
                .ToList();

            comFilterType.CesValueMember = "Value";
            comFilterType.CesDisplayMember = "Text";
            comFilterType.CesDataSource = comboSource;
            //comFilterType.CesDataSourceXX<Ces.WinForm.UI.CesListBox.CesListBoxItemProperty>(comboSource);

            //comFilterType.CesSelectedItem = new CesComboBox.CesSimpleComboBoxItem(text: "None");

            lblColumnName.Text = $"Name : {ColumnText}";
            lblColumnType.Text = $"Type : {ColumnDataType.ToString().Replace("System.", String.Empty)}";

            if (CurrentFilter != null)
                lblCurrentFilter.Text =
                    $"Filter : {CurrentFilter.FilterType.ToString()} = " +
                    $"{(CurrentFilter.CriteriaA != null ? CurrentFilter.CriteriaA.ToString() : string.Empty)}" +
                    $"{(CurrentFilter.CriteriaB != null ? (" ~ " + CurrentFilter.CriteriaB.ToString()) : string.Empty)}";
            else
                lblCurrentFilter.Text = "Filter : Not Set";

            this.Location = MouseLocation;
        }

        private void CesGridViewFilter_Deactivate(object sender, EventArgs e)
        {
            //this.Hide(); // Dispose();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (q.FilterType == CesGridFilterTypeEnum.Between)
            {
                if (ColumnDataType == typeof(DateTime))
                {
                    q.CriteriaA = dpA.Value.Date;
                    q.CriteriaB = dpB.Value.Date;
                }
                else if (ColumnDataType == typeof(bool))
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

                if (ColumnDataType == typeof(decimal) || ColumnDataType == typeof(int))
                    q.CriteriaA = txtCriteriaA.CesText;

                if (ColumnDataType == typeof(DateTime))
                    q.CriteriaA = dpA.Value.Date;

                if (ColumnDataType == typeof(bool))
                    q.CriteriaA = rbTrue.Checked ? true : false;
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

        //private void comFilterType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    q.FilterType = (CesGridFilterTypeEnum)System.Enum.Parse(typeof(CesGridFilterTypeEnum), comFilterType.CesSelectedItem.Text);

        //    pnlTextBox.Visible = false;
        //    pnlRadioButton.Visible = false;
        //    pnlDatePicker.Visible = false;

        //    lblCriteriaA.Visible = false;
        //    lblCriteriaB.Visible = false;

        //    txtCriteriaA.Visible = false;
        //    txtCriteriaB.Visible = false;
        //    dpA.Visible = false;
        //    dpB.Visible = false;
        //    rbTrue.Visible = false;
        //    rbFalse.Visible = false;

        //    if (q.FilterType == CesGridFilterTypeEnum.None)
        //        return;

        //    if (q.FilterType == CesGridFilterTypeEnum.Between)
        //    {
        //        if (ColumnDataType == typeof(DateTime))
        //        {
        //            pnlDatePicker.Visible = true;
        //            lblCriteriaA.Visible = true;
        //            lblCriteriaB.Visible = true;
        //            dpA.Visible = true;
        //            dpB.Visible = true;
        //        }
        //        else
        //        {
        //            pnlTextBox.Visible = true;
        //            //lblCriteriaA.Visible = true;
        //            //lblCriteriaB.Visible = true;
        //            txtCriteriaA.Visible = true;
        //            txtCriteriaB.Visible = true;

        //            txtCriteriaA.Focus();
        //        }
        //    }
        //    else
        //    {
        //        if (ColumnDataType == typeof(DateTime))
        //        {
        //            pnlDatePicker.Visible = true;
        //            lblCriteriaA.Visible = true;
        //            dpA.Visible = true;
        //        }
        //        else if (ColumnDataType == typeof(bool))
        //        {
        //            pnlRadioButton.Visible = true;
        //            //lblCriteriaA.Visible = true;
        //            rbTrue.Visible = true;
        //            rbFalse.Visible = true;
        //        }
        //        else
        //        {
        //            pnlTextBox.Visible = true;
        //            //lblCriteriaA.Visible = true;
        //            txtCriteriaA.Visible = true;

        //            txtCriteriaA.Focus();
        //        }
        //    }
        //}

        private void CesGridViewFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Dispose();
        }

        private void comFilterType_CesSelectedItemChanged(object sender, object? item)
        {
            q.FilterType =
                (CesGridFilterTypeEnum)System.Enum.Parse(
                    typeof(CesGridFilterTypeEnum),
                    ((Ces.WinForm.UI.CesListBox.CesListBoxItemProperty)item)?.Text);

            pnlTextBox.Visible = false;
            pnlRadioButton.Visible = false;
            pnlDatePicker.Visible = false;

            lblCriteriaA.Visible = false;
            lblCriteriaB.Visible = false;

            txtCriteriaA.Visible = false;
            txtCriteriaB.Visible = false;
            dpA.Visible = false;
            dpB.Visible = false;
            rbTrue.Visible = false;
            rbFalse.Visible = false;

            if (q.FilterType == CesGridFilterTypeEnum.None)
                return;

            if (q.FilterType == CesGridFilterTypeEnum.Between)
            {
                if (ColumnDataType == typeof(DateTime))
                {
                    pnlDatePicker.Visible = true;
                    lblCriteriaA.Visible = true;
                    lblCriteriaB.Visible = true;
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
                    txtCriteriaB.Visible = true;
                    txtCriteriaA.ChildContainer.Focus();
                }
            }
            else
            {
                if (ColumnDataType == typeof(DateTime))
                {
                    pnlDatePicker.Visible = true;
                    lblCriteriaA.Visible = true;
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
        }

        #endregion Control Methods
    }
}
