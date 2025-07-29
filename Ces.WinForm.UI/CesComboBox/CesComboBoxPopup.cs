namespace Ces.WinForm.UI.CesComboBox
{
    public partial class CesComboBoxPopup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesComboBoxPopup()
        {
            InitializeComponent();
        }

        public event EventHandler<CesListBox.Events.CesSelectedItemChangedEvent> CesSelectedItemChanged;

        private void CesSimpleComboBoxPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            this.Hide();
        }

        private void CesSimpleComboBoxPopup_Deactivate(object sender, EventArgs e)
        {
            lb.ClearSeachBox();
            this.Hide();
        }

        private void lb_CesSelectedItemChanged(object sender, Ces.WinForm.UI.CesListBox.Events.CesSelectedItemChangedEvent e)
        {
            lb.ClearSelection();
            this.Hide();

            CesSelectedItemChanged?.Invoke(this, new CesListBox.Events.CesSelectedItemChangedEvent { Item = e.Item });
        }
    }
}
