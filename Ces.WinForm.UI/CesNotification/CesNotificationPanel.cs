namespace Ces.WinForm.UI.CesNotification
{
    [Obsolete("This control not implemented")]
    public partial class CesNotificationPanel : Form
    {
        public CesNotificationPanel(CesNotificationOptions? cesNotificationOptions = null)
        {
            if (cesNotificationOptions is null)
            {
                options = new CesNotificationOptions();
            }
            else
            {
                options = cesNotificationOptions;
            }

            InitializeComponent();            
        }
        
        private CesNotificationOptions options;

        private void CesNotificationPanel_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width -this.Width, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
