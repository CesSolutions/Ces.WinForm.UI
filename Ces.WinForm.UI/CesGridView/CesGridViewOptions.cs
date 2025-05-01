namespace Ces.WinForm.UI.CesGridView
{
    public class CesGridFilterAndSort
    {
        public string ColumnName { get; set; } = string.Empty;
        public Type? ColumnDataType { get; set; }
        public string Filter { get; set; } = FilterType.None;
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
        public string Filter { get; set; } = FilterType.None;
        public object? CriteriaA { get; set; }
        public object? CriteriaB { get; set; }
        public List<object> SelectedItems { get; set; } = new List<object>();
    }

    public enum CesGridSortTypeEnum
    {
        None,
        ASC,
        DESC,
    }

    public class FilterType
    {
        public static string None = "None";
        public static string Equal = "Equal";
        public static string Contain = "Contain";
        public static string BiggerThan = "Bigger Than";
        public static string EqualAndBiggerThan = "Equal And Bigger Than";
        public static string SmallerThan = "Smaller Than";
        public static string EqualAndSmallerThan = "Equal And Smaller Than";
        public static string Between = "Between";
        public static string StartWith = "Start With";
        public static string EndWith = "End With";

        public static List<string> FilterTypes = new List<string>
        {
            None,
            Equal,
            Contain,
            BiggerThan,
            EqualAndBiggerThan,
            SmallerThan,
            EqualAndSmallerThan,
            Between,
            StartWith,
            EndWith
        };
    }

    public enum CesGridFilterActionModeEnum
    {
        None,
        RightClick,
        LeftClick,
    }
}