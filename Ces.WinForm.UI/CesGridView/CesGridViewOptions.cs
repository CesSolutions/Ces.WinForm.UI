namespace Ces.WinForm.UI.CesGridView
{
    public class CesGridFilterAndSort
    {
        public string ColumnName { get; set; } = string.Empty;
        public Type? ColumnDataType { get; set; }
        public CesGridFilterTypeEnum FilterType { get; set; } = CesGridFilterTypeEnum.None;
        public CesGridSortTypeEnum SortType { get; set; } = CesGridSortTypeEnum.None;
        public object? CriteriaA { get; set; }
        public object? CriteriaB { get; set; }
        public bool ClearColumnFilter { get; set; }
        public bool ClearAllFilter { get; set; }
        public bool ClearAllSort { get; set; }
    }

    public class CesGridFilterOperation
    {
        public string ColumnName { get; set; } = string.Empty;
        public Type? ColumnDataType { get; set; }
        public CesGridFilterTypeEnum FilterType { get; set; } = CesGridFilterTypeEnum.None;
        public object? CriteriaA { get; set; }
        public object? CriteriaB { get; set; }
    }

    public enum CesGridSortTypeEnum
    {
        None,
        ASC,
        DESC,
    }

    public enum CesGridFilterTypeEnum
    {
        None,
        Equal,
        Contain,
        BiggerThan,
        EqualAndBiggerThan,
        SmallerThan,
        EqualAndSmallerThan,
        Between,
    }

    public enum CesGridFilterActionModeEnum
    {
        None,
        RightClick,
        LeftClick,
    }
}