namespace Ces.WinForm.UI
{
    public partial class CesInputBox : Form
    {
        public CesInputBox()
        {
            InitializeComponent();
        }


        private bool IsMouseDown { get; set; }
        private Point CurrentMousePosition { get; set; }


        public string CesValue { get; set; }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.CesValue = this.txtValue.ChildContainer.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CesInputBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Orange, 2), new Rectangle(1, 1, this.Width - 2, this.Height - 2));
        }

        private void CesInputBox_Load(object sender, EventArgs e)
        {
            this.txtValue.ChildContainer.Text = this.CesValue;
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            IsMouseDown = true;
            CurrentMousePosition = new Point(e.Location.X, e.Location.Y);
        }

        private void pnlTitle_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void pnlTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown)
                return;

            this.Left = this.Left + (e.X - CurrentMousePosition.X);
            this.Top = this.Top + (e.Y - CurrentMousePosition.Y);
        }
    }
}
