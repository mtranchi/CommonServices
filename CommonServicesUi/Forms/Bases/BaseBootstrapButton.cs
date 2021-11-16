using Microsoft.AspNetCore.Components;

namespace CommonServicesUi.Forms.Bases
{
    public abstract class BaseBootstrapButton : BaseButton
    {
        [Parameter] public BootstrapClass BootstrapClass { get; set; } = BootstrapClass.Primary;

        protected string bootstrapCss { get; set; } = "";

        protected override void OnInitialized()
        {
            string start = BtnSmall ? "btn btn-sm btn-outline-" : "btn btn-outline-";

            switch (BootstrapClass)
            {
                case BootstrapClass.Danger:
                    bootstrapCss = start + "danger";
                    break;
                case BootstrapClass.Info:
                    bootstrapCss = start + "info";
                    break;
                case BootstrapClass.Link:
                    bootstrapCss = "btn btn-link";
                    break;
                case BootstrapClass.Primary:
                    bootstrapCss = start + "primary";
                    break;
                case BootstrapClass.Success:
                    bootstrapCss = start + "success";
                    break;
                case BootstrapClass.Warning:
                    bootstrapCss = start + "warning";
                    break;
            }
        }

    }
}
