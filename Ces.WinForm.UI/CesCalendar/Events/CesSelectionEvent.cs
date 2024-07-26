namespace Ces.WinForm.UI.CesCalendar.Events
{
    public class CesSelectionEvent : EventArgs
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
