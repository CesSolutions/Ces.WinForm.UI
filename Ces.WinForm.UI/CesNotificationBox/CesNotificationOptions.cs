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
            if (options is not null && options.Type == CesNotificationTypeEnum.NotificationBox)
            {
                var frmBox = new CesNotificationBox(options);
                frmBox.Show();
            }

            if (options is not null && options.Type == CesNotificationTypeEnum.NotificationSrtip)
            {
                var frmStrip = new CesNotificationStrip(options);
                frmStrip.Show();
            }
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
                Type = CesNotificationTypeEnum.NotificationBox;
                ShowStripBottom = true;
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
        public Size? Size { get; set; }
        public CesNotificationTypeEnum Type { get; set; }
        public bool ShowStripBottom { get; set; }

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

    public enum CesNotificationTypeEnum
    {
        NotificationBox,
        NotificationSrtip,
    }
}
