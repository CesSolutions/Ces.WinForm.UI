namespace Ces.WinForm.UI.CesNavigationBars
{
    public partial class frmFullScreen : Form
    {
        public Control? Parent;
        public Control? GridView;

        public frmFullScreen()
        {
            InitializeComponent();
        }

        private void frmFullScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parent?.Controls.Add(GridView);
            Dispose();
        }

        private void frmFullScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
