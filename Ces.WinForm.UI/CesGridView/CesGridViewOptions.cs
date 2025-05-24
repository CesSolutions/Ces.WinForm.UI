using Ces.WinForm.UI.CesListBox;

namespace Ces.WinForm.UI.CesGridView
{
    /// <summary>
    /// کلاس زیر اطلاعات کادر فیلترینگ را جمع آوری و به گرید تحویل خواهد داد
    /// </summary>
    public class CesGridFilterAndSort
    {
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; } = string.Empty;
        public Type? ColumnDataType { get; set; }
        public string Filter { get; set; } = FilterType.None;
        public CesGridSortTypeEnum SortType { get; set; } = CesGridSortTypeEnum.None;
        public object? CriteriaA { get; set; }
        public object? CriteriaB { get; set; }
        public bool ClearColumnFilter { get; set; }
        public bool ClearAllFilter { get; set; }
        public bool ClearAllSort { get; set; }
        public List<CesListBoxItemProperty>? SelectedItems { get; set; }
    }

    /// <summary>
    /// این کلاس اطلاعات فیلتریگ و مرتب سازی یک ستون را نگهداری میکند
    /// وهر ستون میتواند چندین اطلاعات درخصوص فیلترینگ داشته باشد
    /// </summary>
    public class CesGridFilterOperation
    {
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; } = string.Empty;
        public Type? ColumnDataType { get; set; }
        public string Filter { get; set; } = FilterType.None;
        public object? CriteriaA { get; set; }
        public object? CriteriaB { get; set; }
        public List<CesListBoxItemProperty> SelectedItems { get; set; } = new List<CesListBoxItemProperty>();
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
        public static string NotEqual = "Not Equal";
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
            NotEqual,
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

    public enum CesGridViewRowSizeModeEnum : int
    {
        Compact = 20,
        Normal = 30,
        Comfortable = 38,
    }

    public enum CesGridLineStyleEnum
    {
        None,
        Vertical,
        Horizontal,
        Both,
        Custom
    }
}