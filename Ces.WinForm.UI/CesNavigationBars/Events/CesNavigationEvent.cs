namespace Ces.WinForm.UI.CesNavigationBars.Events
{
    public class CesNavigationEvent : EventArgs
    {
        public int TotalRows { get; set; }
        public int CurrentRowNumber { get; set; }
        public bool IsFirst { get; set; }
        public bool IsLast { get; set; }
    }
}
