namespace Ces.WinForm.UI.Infrastructure
{
    public static class Location
    {
        /// <summary>
        /// متد زیر موقعیت یک فرم باز شوند مانند کمبوباکس را تعیین می‌کند
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Form PopupLocation(
            this Form frm,
            Control control,
            bool adjustToControlWidth,
            Size popupSize,
            bool alignToRight)
        {
            //ابتدا اندازه منوی باز شونده طبق تنظیمات کاربر تغییر خواهد کرد
            frm.Size =
                adjustToControlWidth ?
                new Size(control.Width, popupSize.Height) :
                popupSize;

            var screenSize = Screen.PrimaryScreen.WorkingArea;
            var popupRightLocation = 0;
            var popupLeftLocation = 0;
            var comboLocation = control.PointToScreen(Point.Empty); //موقعیت کنترل در مانیتور
            var popupBottomLocation = comboLocation.Y + frm.Height; //موقعیت پایین منوی باز شونده
            var popupTopLocation = comboLocation.Y - frm.Height; //موقعیت بالای منوی بازشونده
            var topSpace = comboLocation.Y; //فاصله لبه بالایی کنترل تا لبه بالایی مانیتور
            var bottomSpace = screenSize.Height - comboLocation.Y - control.Height;

            //اگر لبه پایینی منوی باز شونده از لبه پایینی مانیتور
            //بیرون نزد، منو در زیر کنترل نمایش داده خواهد شد
            //و بنابراین موقعیت بالای منوی باز شونده زیر کنترل خواهد بود
            if (popupBottomLocation < screenSize.Height)
            {
                //بدست آوردن موقعیت بالا برای منوی باز شونده که در واقع
                //موقعیت کنترل به اضافه ارتفاع کنترل می‌باشد چون منوی
                //باز شونده قرار است زیر کنترل باز شود
                frm.Top = comboLocation.Y + control.Height;
            }
            //اما اگر موقعیت پایینی منوی باز شونده از لبه پایینی مانیتور بیرون بزند
            //باید بررسی‌های بیشتری انجام داد و در صورت لزوم منوی باز شونده در موقعیت 
            //بالای کنترل نمایش داده شود
            else
            {
                //اگر قرار باشد منو در بالای کنترل باز شود باید دقت کرد که اندازه‌ای
                //که کاربر تعیین کرده در فضای بالای کنترل موجود است. در غیر اینصورت
                //اگر در بالا باز شود بخش بالایی منوی باز شونده در لبه بالایی مانیتور
                //خارج خواهد شد. بنابراین باید فضای خالی بالا و پایین کنترل را بررسی
                //کنیم. اگر فضای پایین کنترل بیشتر از فضای بالا بود الزاما باید ارتفاع
                //منوی باز شونده را به حداکثر فاصله زیر کنترل تغییر دهیم در واقع اندازه
                //تعیین شده کاربر را باید اصلاح کنیم
                if (bottomSpace > topSpace)
                {
                    //قبل از اینکه فرم در بالا باز شود بررسی میکنیم که اگز فضای
                    //پایین بزرگتر از فضای بالا باشد، ابتدا ارتفاع فرم را تغییر میدهیم
                    //بعد فرم را موقعیت دهی میکنیم
                    frm.Height = bottomSpace;
                    frm.Top = comboLocation.Y + control.Height;
                }
                    //در غیر اینصورت اگر فضای بالا بیشتر بود باید منوی باز شونده در بالای
                    //کنترل نمایش داده شود و همچنین باید بررسی شود که اگر منوی باز شونده
                    //از لبه بالایی مانیتور خارج می شود باید ارتفاع منو را تغییر دهیم و در 
                    //واقع اندازه تعیین شده توسط کاربر را باید اصلاح کنیم
                else
                {
                    if (frm.Height > topSpace)
                        frm.Height = topSpace;

                    frm.Top = comboLocation.Y - frm.Height;
                }
            }

            //تعیین موقعیت سمت چپ منوی باز شونده با توجه به تنظیمات کاربر
            //منو می‌تواند از لبه سمت راست و یا لبه سمت چپ تراز شود
            if (alignToRight)
                popupLeftLocation = comboLocation.X - (frm.Width - control.Width);
            else
                popupRightLocation = comboLocation.X + frm.Width;

            //تراز کردن منوی باز شونده از لبه راست و یا چپ دارای ملاحظاتی نیز است
            //اگر لبه راست و یا چپ از لبه مانیتور خارج شود، برنامه موقعیت منوی
            //باز شونده را به همان اندازه جابجا خواهد کرد
            if (alignToRight)
            {
                if (popupLeftLocation < 0)
                    frm.Left = 0;
                else
                    frm.Left = comboLocation.X - (frm.Width - control.Width);
            }
            else
            {
                if (popupRightLocation > screenSize.Width)
                    frm.Left = screenSize.Width - frm.Width;
                else
                    frm.Left = comboLocation.X < 0 ? 0 : comboLocation.X;
            }

            //برگشت فرم جهت نمایش
            return frm;
        }
    }
}
