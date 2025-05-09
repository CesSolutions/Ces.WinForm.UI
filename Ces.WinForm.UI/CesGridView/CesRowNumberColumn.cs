namespace Ces.WinForm.UI.CesGridView
{
    public class CesRowNumberColumn : DataGridViewColumn
    {
        public CesRowNumberColumn(string headerText = "#")
        {
            this.CellTemplate = new CesRowNumberCell();
            this.ReadOnly = true;
            this.DisplayIndex = 0;
            this.Width = 60;
            this.HeaderText = headerText;
        }

        public int CesTrailingZero { get; set; }
        public int CesRowNumberStartNumber { get; set; } = 1;
        public int CesRowNumberIncrementStep { get; set; } = 1;
    }

    public class CesRowNumberCell : DataGridViewTextBoxCell
    {
        public CesRowNumberCell()
        {
        }

        protected override bool SetValue(int rowIndex, object value)
        {
            CesRowNumberColumn parent = (CesRowNumberColumn)this.OwningColumn;

            if (parent is null)
                return false;

            if (value == null)
                return false;

            if (!int.TryParse(value.ToString(), out int number))
                return false;

            return base.SetValue(rowIndex, number.ToString().PadLeft(parent.CesTrailingZero, '0'));
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            // ابتدا باید مطمئن شوینم که ستون شماره ردیف به گرید اضاقه شده است
            Ces.WinForm.UI.CesGridView.CesRowNumberColumn? cesRowNumberColumn = null;

            foreach (var col in this.DataGridView.Columns)
            {
                if (col.GetType() == typeof(Ces.WinForm.UI.CesGridView.CesRowNumberColumn))
                {
                    cesRowNumberColumn = (CesRowNumberColumn)col;
                }
            }

            // اگر ستون شماره ردیف وجود داشت باید با استفاده از حلقه
            // شماره ایندکس هر ردیف در سلول درج شود
            if (cesRowNumberColumn != null)
            {
                int rowNumber = 0;

                foreach (DataGridViewRow r in this.DataGridView.Rows)
                {
                    rowNumber =
                        (r.Index +
                        cesRowNumberColumn.CesRowNumberStartNumber) *
                        cesRowNumberColumn.CesRowNumberIncrementStep;

                    r.Cells[cesRowNumberColumn.Index].Value = rowNumber;
                }
            }

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }
    }
}
