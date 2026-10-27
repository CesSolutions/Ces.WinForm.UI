namespace Ces.WinForm.UI.CesComboBox
{
    public partial class CesComboBoxMultiColumnPopup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesComboBoxMultiColumnPopup()
        {
            InitializeComponent();
        }

        public event EventHandler<Ces.WinForm.UI.CesComboBox.Events.CesSelectionChangeEvent> CesSelectedItemChanged;

        private void CesComboBoxMultiColumnPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            this.Hide();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lb.ClearSelection();
            this.Hide();

            CesSelectedItemChanged?.Invoke(this, new Ces.WinForm.UI.CesComboBox.Events.CesSelectionChangeEvent { Item = dgv.CurrentRow });
        }

        private void CesComboBoxMultiColumnPopup_Deactivate(object sender, EventArgs e)
        {
            //lb.ClearSeachBox();
            this.Hide();
        }
    }
}
