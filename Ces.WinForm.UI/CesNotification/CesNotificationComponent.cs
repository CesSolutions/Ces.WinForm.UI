using System.ComponentModel;

namespace Ces.WinForm.UI.CesNotification
{
    public partial class CesNotificationComponent : Component
    {
        public CesNotificationComponent()
        {
            InitializeComponent();
        }

        public CesNotificationComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Browsable(false)]
        public System.Guid Id { get; set; }
        [Category("Ces Notification")]
        public DateTime IssueDateTime { get; set; } = DateTime.Now;
        [Category("Ces Notification")]
        public int Duration { get; set; } = 5;// in second
        [Category("Ces Notification")]
        public string? Title { get; set; }
        [Category("Ces Notification")]
        public string? Message { get; set; }
        [Category("Ces Notification")]
        public CesNotificationIconEnum Icon { get; set; } = CesNotificationIconEnum.None;
        [Category("Ces Notification")]
        public CesNotificationPositionEnum Position { get; set; } = CesNotificationPositionEnum.BottomRight;
        [Category("Ces Notification")]
        public Color BackColor { get; set; } = Color.BlueViolet;
        [Category("Ces Notification")]
        public bool ShowTitleBar { get; set; } = true;
        [Category("Ces Notification")]
        public bool ShowExitButton { get; set; } = true;
        [Category("Ces Notification")]
        public bool ShowStatusBar { get; set; } = false;
        [Category("Ces Notification")]
        public bool ShowIssueDateTime { get; set; } = true;
        [Category("Ces Notification")]
        public bool ShowRemained { get; set; } = true;
        [Category("Ces Notification")]
        public bool ShowIcon { get; set; } = true;
        [Category("Ces Notification")]
        public CesNotificationTypeEnum Type { get; set; } = CesNotificationTypeEnum.NotificationBox;
        [Category("Ces Notification")]
        public bool ShowStripBottom { get; set; } = true;
        [Category("Ces Notification")]
        public double Opacity { get; set; } = 1;

        public void Show()
        {
            var option = new Ces.WinForm.UI.CesNotification.CesNotificationOptions
            {
                IssueDateTime = this.IssueDateTime,
                Duration = 5,
                Title = this.Title,
                Message = this.Message,
                Icon = this.Icon,
                Position = this.Position,
                BackColor = this.BackColor,
                ShowTitleBar = this.ShowTitleBar,
                ShowExitButton = this.ShowExitButton,
                ShowStatusBar = this.ShowStatusBar,
                ShowIssueDateTime = this.ShowIssueDateTime,
                ShowRemained = this.ShowRemained,
                ShowIcon = this.ShowIcon,
                Type = this.Type,
                ShowStripBottom = this.ShowStripBottom,
                Opacity = this.Opacity,
            };

            Ces.WinForm.UI.CesNotification.CesNotification.Show(option);
        }
    }
}
