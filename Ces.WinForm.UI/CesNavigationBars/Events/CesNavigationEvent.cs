namespace Ces.WinForm.UI.CesNavigationBars.Events
{
    public class CesNavigationEvent : EventArgs
    {
        public int CountRows { get; set; }
        /// <summary>
        /// Return current row index
        /// </summary>
        public int RowIndex { get; set; }
        public bool IsFirst { get; set; }
        public bool IsLast { get; set; }
    }
}
