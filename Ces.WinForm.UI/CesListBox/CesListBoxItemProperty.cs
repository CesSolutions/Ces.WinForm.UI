namespace Ces.WinForm.UI.CesListBox
{
    public class CesListBoxItemProperty
    {
        // تعیین مقدار متن جهت نمایش الزامی می باشد
        public CesListBoxItemProperty(string? text = null, object? value = null, Image? image = null)
        {
            this.Value = value;
            this.Text = text;
            this.Image = image;
        }

        public string? Text { get; set; }
        public object? Value { get; set; }
        public Image? Image { get; set; }
    }
}