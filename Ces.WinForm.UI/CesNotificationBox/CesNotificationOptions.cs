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
                IssueDateTime = DateTime.Now;
                Duration = 15;
                Icon = CesNotificationIconEnum.None;
                Position = CesNotificationPositionEnum.BottomRight;
                BackColor = Color.BlueViolet;
                ShowTitleBar = true;
                ShowExitButton = true;
                ShowStatusBar = false;
                ShowIssueDateTime = true;
                ShowRemained = true;
                ShowIcon = true;
                Size = new Size(400, 110);
            }
        }

        public DateTime IssueDateTime { get; set; }
        public int Duration { get; set; } // in second
        public string? Title { get; set; }
        public string? Message { get; set; }
        public CesNotificationIconEnum Icon { get; set; }
        public CesNotificationPositionEnum Position { get; set; }
        public Color BackColor { get; set; }
        public bool ShowTitleBar { get; set; }
        public bool ShowExitButton { get; set; }
        public bool ShowStatusBar { get; set; }
        public bool ShowIssueDateTime { get; set; }
        public bool ShowRemained { get; set; }
        public bool ShowIcon { get; set; }
        public Size Size { get; set; }


        public delegate void CesNotificationOnExitDelegate();
        public CesNotificationOnExitDelegate CesNotificationOnExitHandler;
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

    public enum CesNotificationIconEnum
    {
        None,
        NotificationCheck,
        NotificationEmail,
        NotificationInformation,
        NotificationQuestion,
        NotificationSecurity,
        NotificationSettings,
        NotificationUser,
        NotificationWarning,
        NotificationWeb,
    }
}
