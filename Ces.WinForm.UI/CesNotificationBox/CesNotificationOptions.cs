using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesNotificationBox
{
    public static class CesNotification
    {
        public static async Task Show(CesNotificationOptions? options = null)
        {
            var frm = new CesNotificationBox(options);
            frm.Show();
        }
    }


    public class CesNotificationOptions
    {
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
