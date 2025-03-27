namespace Ces.WinForm.UI
{
    public partial class CesLoadingScreen : Form
    {
        public CesLoadingScreen()
        {
            InitializeComponent();
        }

        private string _title { get; set; } = default!;

        /// <summary>
        ///از این متد می‌توان جهت ایجاد یک صفحه لودینگ استفاده کرد و یک 
        ///فرم را به عنوان خروجی بر می‌گرداند که در زمان مناسب می‌توان این 
        ///فرم  را از حافظه پاک کرد
        /// </summary>
        /// <param name="control"></param>
        /// <param name="coverParentContainer"></param>
        /// <returns></returns>
        public static Form Create(
            Control control,
            bool coverParentContainer = true,
            string title = "Loading...",
            double opacity = 0.5)
        {
            var frm = new CesLoadingScreen();
            frm._title = title;
            frm.Opacity = opacity;

            SetLoadingScreenSize();

            //باید برای رویداد تغییر سایز، متد زیر را تعرف کرد تا فرم
            //لودینگ با توجه به تغییرات اندازه‌ی کنترل، تغییر اندازه جدید بدهد
            control.Resize += (s, e) =>
            {
                SetLoadingScreenSize();
            };

            frm.Show(control);

            //جهت دسترسی چندباره کدهای تنظیم صفحه،
            //این متد داخلی تعریف شده تا در دو نقطه در دسترس باشد
            void SetLoadingScreenSize()
            {
                //با توجه به اینکه فرم لودینگ باید ناحیه والد را
                //پوشش دهد یا خیر، باید مشخصات ناحیه را بدست آورد
                var controlClientRectangle =
                    coverParentContainer && control.Parent != null ?
                    control.Parent.ClientRectangle :
                    control.ClientRectangle;

                //حالا باید موقعیت کنترل در صفحه مانیتور مشخصشود
                //چون فرم لودینگ جهت نمایش نیاز به موقعیت مطلق دارد
                var controlRectangleToScreen =
                    coverParentContainer && control.Parent != null ?
                    control.Parent.RectangleToScreen(controlClientRectangle) :
                    control.RectangleToScreen(controlClientRectangle);

                frm.Location = new Point
                {
                    X = controlRectangleToScreen.X,
                    Y = controlRectangleToScreen.Y
                };
                frm.Size = controlClientRectangle.Size;
            }

            return frm;
        }

        private void CesLoadingScreen_Load(object sender, EventArgs e)
        {
            lblLoading.Text = _title;
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
