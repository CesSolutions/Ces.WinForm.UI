﻿namespace Ces.WinForm.UI.CesComboBox
{
    public partial class CesComboBoxPopup : Ces.WinForm.UI.CesForm.CesForm
    {
        public CesComboBoxPopup()
        {
            InitializeComponent();
        }

        public delegate void CesSelectedItemChangedEventHandler(object sender, object? item);
        public event CesSelectedItemChangedEventHandler CesSelectedItemChanged;

        private void CesSimpleComboBoxPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void CesSimpleComboBoxPopup_Deactivate(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }

        private void lb_CesListBoxItemChanged(object sernder, object item)
        {
            lb.ClearSelection(null);
            this.Close();

            CesSelectedItemChanged?.Invoke(this, item);
        }
    }
}
