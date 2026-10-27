namespace Ces.WinForm.UI.CesGridView.Events
{
    public class ColumnHeaderMouseDown:EventArgs
    {
        public int ColumnIndex { get; set; }
        public int ColumnDisplayIndex { get; set; }
    }
}
