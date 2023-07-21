using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesNotification
{
    public class CesNotificationOptions
    {
        public static async Task Show(CesNotificationOptions? options)
        {
            var frm = new CesNotification(options);
            frm.Show();
        }


        public CesNotificationOptions(CesNotificationOptions? options = null)
        {
            if (options is null)
            {
                Duration = 15;
                Title = "Notification";
                Message = "Notification message";
                Icon = CesMessageBox.CesMessageBoxIconEnum.None;
                Position = CesNotificationPositionEnum.BottomRight;
            }
        }

        public int Duration { get; set; } // in second
        public string? Title { get; set; }
        public string? Message { get; set; }
        public CesMessageBox.CesMessageBoxIconEnum Icon { get; set; }
        public CesNotificationPositionEnum Position { get; set; }
    }

    public enum CesNotificationPositionEnum
    {
        TopLeft,
        TopCenter,
        TopRight,
        BottomLeft,
        BottomCenter,
        BottomRight,
        ScreenCenter,
    }
}
