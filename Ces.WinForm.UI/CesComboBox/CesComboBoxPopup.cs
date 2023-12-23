namespace Ces.WinForm.UI.CesComboBox
{
    public partial class CesComboBoxPopup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesComboBoxPopup()
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

        private void lb_CesListBoxItemChanged(object sernder, object item)
        {
            SelectedItem = item;
            lb.ClearSelection();
            this.Close();
        }
    }
}
