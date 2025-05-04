namespace Ces.WinForm.UI.CesGridView
{
    /// <summary>
    /// DeepSeek
    /// برای آنکه بتوان مرتب سازی یک لیست از رشته را بر مبنای نوع داده
    /// انجام دهیم باید مقایسه را برمبنای تایپ یک داده انجام بدهیم
    /// </summary>
    public class DataComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            // Handle null cases
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Try to parse as different types in order of priority
            if (TryParse(x, y, out int xInt, out int yInt, int.TryParse))
                return xInt.CompareTo(yInt);

            if (TryParse(x, y, out double xDouble, out double yDouble, double.TryParse))
                return xDouble.CompareTo(yDouble);

            if (TryParse(x, y, out DateTime xDate, out DateTime yDate, DateTime.TryParse))
                return xDate.CompareTo(yDate);

            if (TryParse(x, y, out TimeSpan xTime, out TimeSpan yTime, TimeSpan.TryParse))
                return xTime.CompareTo(yTime);

            // Fall back to string comparison
            return string.Compare(x, y, StringComparison.Ordinal);
        }

        private bool TryParse<T>(string x, string y, out T xVal, out T yVal, TryParseHandler<T> tryParse)
        {
            xVal = default;
            yVal = default;

            bool xParsed = tryParse(x, out xVal);
            bool yParsed = tryParse(y, out yVal);

            // Only use this type if both parse successfully
            return xParsed && yParsed;
        }

        private delegate bool TryParseHandler<T>(string s, out T result);
    }
}

