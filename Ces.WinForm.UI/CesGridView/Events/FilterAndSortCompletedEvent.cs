namespace Ces.WinForm.UI.CesGridView.Events
{
    public class FilterAndSortCompletedEvent : EventArgs
    {
        public int ColumnIndex { get; set; }
        public CesGridSortTypeEnum SortType { get; set; } = CesGridSortTypeEnum.None;
        public bool ClearColumnFilter { get; set; }
        public bool ClearAllFilter { get; set; }
        public bool ClearAllSort { get; set; }
        public bool HasFilterignData { get; set; }
    }
}
