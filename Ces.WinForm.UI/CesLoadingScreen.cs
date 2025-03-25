namespace Ces.WinForm.UI
{
    public partial class CesLoadingScreen : Form
    {
        public CesLoadingScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        ///از این متد می‌توان جهت ایجاد یک صفحه لودینگ استفاده کرد و یک 
        ///فرم را به عنوان خروجی بر می‌گرداند که در زمان مناسب می‌توان این 
        ///فرم  را از حافظه پاک کرد
        /// </summary>
        /// <param name="control"></param>
        /// <param name="coverParentContainer"></param>
        /// <returns></returns>
        public static Form Create(Control control, bool coverParentContainer = true)
        {
            var frm = new CesLoadingScreen();
            frm.Opacity = 0.5;

            SetLoadingForSize();

            control.Resize += (s, e) =>
            {
                SetLoadingForSize();
            };

            frm.Show(control);

            //متد داخلی تا در دو نقطه در دسترس باشد
            void SetLoadingForSize()
            {
                var cesGridViewClientRectangle =
                    coverParentContainer || control.Parent == null ?
                    control.ClientRectangle :
                    control.Parent.ClientRectangle;

                frm.Location = new Point
                {
                    X = coverParentContainer || control.Parent == null ?
                        control.RectangleToScreen(cesGridViewClientRectangle).X :
                        control.Parent.RectangleToScreen(cesGridViewClientRectangle).X,

                    Y = coverParentContainer || control.Parent == null ?
                        control.RectangleToScreen(cesGridViewClientRectangle).Y :
                        control.Parent.RectangleToScreen(cesGridViewClientRectangle).Y
                };
                frm.Size = cesGridViewClientRectangle.Size;
            }

            return frm;
        }

        private void frmLoading_Shown(object sender, EventArgs e)
        {
            SetLabelPosition();
        }

        private void frmLoading_Resize(object sender, EventArgs e)
        {
            SetLabelPosition();
        }

        private void SetLabelPosition()
        {
            lblLoading.Left = this.Width / 2 - lblLoading.Width / 2;
            lblLoading.Top = this.Height / 2 - lblLoading.Height / 2;
        }
    }
}
