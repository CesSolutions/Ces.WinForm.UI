namespace Ces.WinForm.UI.CesComboBox
{
    public class SelectedValue<T>
    {
        private T? _value;

        public T? Value
        {
            get
            {
                // insert desired logic here
                return _value;
            }
            set
            {
                // insert desired logic here
                _value = value;
            }
        }

        public static implicit operator T(SelectedValue<T> value)
        {
            return value.Value;
        }

        public static implicit operator SelectedValue<T>(T value)
        {
            return new SelectedValue<T> { Value = value };
        }
    }
}
