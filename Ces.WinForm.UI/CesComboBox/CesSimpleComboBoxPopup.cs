namespace Ces.WinForm.UI.CesComboBox
{
    public partial class CesSimpleComboBoxPopup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesSimpleComboBoxPopup()
        {
            InitializeComponent();
        }

        public object? SelectedItem { get; set; }

        private void CesSimpleComboBoxPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void CesSimpleComboBoxPopup_Deactivate(object sender, EventArgs e)
        {
            //this.Close();
            //Dispose();
        }

        private void GetSelectedItem(object sender, object? item)
        {
            SelectedItem = item;
            this.Close();
        }

        private void lb_CesListBoxItemChanged(object sernder, object item)
        {
            SelectedItem = item;
            this.Close();
        }
    }
}
