using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesGridView
{
    public partial class CesGridViewFilter : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesGridViewFilter()
        {
            InitializeComponent();
        }

        public Point MouseLocation { get; set; }
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public string ColumnText { get; set; }
        public Type ColumnDataType { get; set; }
        public CesGridFilterAndSort q { get; set; } = new CesGridFilterAndSort();
        public bool ClearFilter { get; set; }
        public CesGridFilterOperation? CurrentFilter { get; set; }
        public CesGridSortTypeEnum CurrentSort { get; set; }


        private void CesGridViewFilter_Load(object sender, EventArgs e)
        {
            q.ColumnName = this.ColumnName;

            comFilterType.DataSource = System.Enum.GetNames(typeof(CesGridFilterTypeEnum)).OrderBy(x => x).ToList();
            comFilterType.SelectedItem = "None";

            lblColumnName.Text = $"Column : {ColumnText} , Type : [{ColumnDataType.ToString()}]";

            if (CurrentFilter != null)
                lblCurrentFilter.Text =
                    $"Current Filter : {CurrentFilter.FilterType.ToString()} = " +
                    $"{(CurrentFilter.CriteriaA != null ? CurrentFilter.CriteriaA.ToString() : string.Empty)}" +
                    $"{(CurrentFilter.CriteriaB != null ? (" ~ " + CurrentFilter.CriteriaB.ToString()) : string.Empty)}";
            else
                lblCurrentFilter.Text = "Current Filter : Not Defined";

            this.Location = MouseLocation;
        }

        private void CesGridViewFilter_Deactivate(object sender, EventArgs e)
        {
            Dispose();
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
                else
                {
                    q.CriteriaA = txtCriteriaA.Text;
                    q.CriteriaB = txtCriteriaB.Text;
                }
            }
            else
            {
                if (ColumnDataType == typeof(string))
                    q.CriteriaA = txtCriteriaA.Text;

                if (ColumnDataType == typeof(decimal) || ColumnDataType == typeof(int))
                    q.CriteriaA = txtCriteriaA.Text;

                if (ColumnDataType == typeof(DateTime))
                    q.CriteriaA = dpA.Value.Date;

                if (ColumnDataType == typeof(bool))
                    q.CriteriaA = rbTrue.Checked ? true : false;
            }

            this.Close();
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            q.ColumnName = this.ColumnName;
            q.ClearColumnFilter = true;
            this.Close();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            q.ClearAllFilter = true;
            this.Close();
        }

        private void btnSortAsc_Click(object sender, EventArgs e)
        {
            q.ColumnName = this.ColumnName;
            q.SortType = CesGridSortTypeEnum.ASC;
            this.Close();
        }

        private void btnSortDesc_Click(object sender, EventArgs e)
        {
            q.ColumnName = this.ColumnName;
            q.SortType = CesGridSortTypeEnum.DESC;
            this.Close();
        }

        private void btnSortClear_Click(object sender, EventArgs e)
        {
            q.ClearAllSort = true;
            this.Close();
        }

        private void comFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            q.FilterType = (CesGridFilterTypeEnum)System.Enum.Parse(typeof(CesGridFilterTypeEnum), comFilterType.SelectedItem.ToString());

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
                else
                {
                    pnlTextBox.Visible = true;
                    lblCriteriaA.Visible = true;
                    lblCriteriaB.Visible = true;
                    txtCriteriaA.Visible = true;
                    txtCriteriaB.Visible = true;

                    txtCriteriaA.Focus();
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
                    lblCriteriaA.Visible = true;
                    rbTrue.Visible = true;
                    rbFalse.Visible = true;
                }
                else
                {
                    pnlTextBox.Visible = true;
                    lblCriteriaA.Visible = true;
                    txtCriteriaA.Visible = true;

                    txtCriteriaA.Focus();
                }
            }
        }
    }
}
