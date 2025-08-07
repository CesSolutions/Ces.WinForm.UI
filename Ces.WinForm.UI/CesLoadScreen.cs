namespace Ces.WinForm.UI
{
    public partial class CesLoadScreen : Form
    {
        public CesLoadScreen()
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
            bool coverParentForm = false,
            string title = "Loading...",
            double opacity = 0.5)
        {

            var frm = new CesLoadScreen();
            frm._title = title;
            frm.Opacity = opacity;

            if (!IsVisible(control))
                return frm;

            SetLoadingScreenSize(frm, coverParentContainer, coverParentForm, control);

            //باید برای رویداد تغییر سایز، متد زیر را تعرف کرد تا فرم
            //لودینگ با توجه به تغییرات اندازه‌ی کنترل، تغییر اندازه جدید بدهد
            control.Resize += (s, e) => SetLoadingScreenSize(frm, coverParentContainer, coverParentForm, control);

            frm.Show(control.FindForm());
            Application.DoEvents();

            return frm;
        }

        /// <summary>
        /// فرم زمانی نمایش داده خواهد شد که کنترل والد در مانیتور
        /// قابل رویت باشد. در غیر اینصورت از نمایش فرم جلوگیری
        /// خواهد شد چون غیر ضروری است
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool IsVisible(Control control)
        {
            Rectangle screenBounds = Screen.FromControl(control).Bounds;
            Rectangle controlBounds = control.RectangleToScreen(control.ClientRectangle);

            bool isOnScreen = screenBounds.IntersectsWith(controlBounds);

            if (!control.IsHandleCreated || !isOnScreen)
                return false;

            if (!control.Visible)
                return false;

            return true;
        }

        //جهت دسترسی چندباره کدهای تنظیم صفحه،
        //این متد داخلی تعریف شده تا در دو نقطه در دسترس باشد
        private static void SetLoadingScreenSize(Form frm, bool coverParentContainer, bool coverParentForm, Control control)
        {
            //با توجه به اینکه فرم لودینگ باید ناحیه والد را
            //پوشش دهد یا خیر، باید مشخصات ناحیه را بدست آورد
            var controlClientRectangle =
                coverParentForm && control.FindForm() != null ?
                control.FindForm().ClientRectangle :
                (
                    coverParentContainer && control.Parent != null ?
                    control.Parent.ClientRectangle:
                    control.ClientRectangle
                );

            //حالا باید موقعیت کنترل در صفحه مانیتور مشخص شود
            //چون فرم لودینگ جهت نمایش نیاز به موقعیت مطلق دارد
            var controlRectangleToScreen =
                coverParentForm && control.FindForm() != null ?
                control.FindForm().RectangleToScreen(controlClientRectangle) :
                (
                    coverParentContainer && control.Parent != null ?
                    control.Parent.RectangleToScreen(controlClientRectangle) :
                    control.RectangleToScreen(controlClientRectangle)
                );

            frm.Location = new Point
            {
                X = controlRectangleToScreen.X,
                Y = controlRectangleToScreen.Y
            };

            frm.Size = controlClientRectangle.Size;
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
