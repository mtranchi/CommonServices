using CommonServicesUi.Forms.Bases;

namespace CommonServicesUi.Services
{
    public class Notice
    {
        public BootstrapClass BootstrapClass { get; set; }

        public string BootstrapCss { get; private set; }

        public string IconCss { get; set; }

        public string Message { get; set; }

        public NotificationPosition NotificationPosition { get; set; }

        public DateTime RemoveAt { get; set; }

        public Notice(BootstrapClass bootstrapClass, string message, NotificationPosition notificationPosition, int seconds)
        {
            BootstrapClass = bootstrapClass;
            Message = message;
            NotificationPosition = notificationPosition;
            RemoveAt = DateTime.Now.AddSeconds(seconds);

            setCss();
        }

        void setCss()
        {
            switch (BootstrapClass)
            {
                case BootstrapClass.Info:
                    BootstrapCss = IconCss = "info";
                    break;
                case BootstrapClass.Danger:
                    BootstrapCss = "danger";
                    IconCss = "warning";
                    break;
                case BootstrapClass.Primary:
                    BootstrapCss = "primary";
                    IconCss = "info";
                    break;
                case BootstrapClass.Success:
                    BootstrapCss = "success";
                    IconCss = "check";
                    break;
                case BootstrapClass.Warning:
                    BootstrapCss = IconCss = "warning";
                    break;
                default:
                    BootstrapCss = IconCss = "info";
                    break;
            }
        }
    }
}
