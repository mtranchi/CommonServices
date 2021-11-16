using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonServicesUi.Forms.Bases
{
    public abstract class BaseInput<T> : InputBase<T>
    {

        /// <summary>
        /// If true, this element will be focused when the page loads
        /// </summary>
        [Parameter] public bool Autofocus { get; set; }

        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// Optional. Sets the id on the input element as well as the for attibute on the label element
        /// </summary>
        [Parameter] public string ElementId { get; set; }

        /// <summary>
        /// Optional. For those occassional times you need to render HTML in a span[class="form-text"]
        /// </summary>
        [Parameter] public RenderFragment HelpHtml { get; set; }

        /// <summary>
        /// Optional. If supplied, adds a span element with the class form-text
        /// </summary>
        [Parameter] public string HelpText { get; set; }

        #region Input group

        /// <summary>
        /// Appends render fragment to input group
        /// </summary>
        [Parameter] public RenderFragment AppendHtml { get; set; }

        /// <summary>
        /// Appends text to input group
        /// </summary>
        [Parameter] public string AppendText { get; set; }

        /// <summary>
        /// Prepends render fragment to input group
        /// </summary>
        [Parameter] public RenderFragment PrependHtml { get; set; }

        /// <summary>
        /// Prepends text to input group
        /// </summary>
        [Parameter] public string PrependText { get; set; }

        #endregion //input group

        /// <summary>
        /// Optional. Default is "Enter {DisplayName.ToLower()} here..."
        /// </summary>
        [Parameter] public string Placeholder { get; set; }

        /// <summary>
        /// If the field needs to be filled out
        /// </summary>
        [Parameter] public bool Required { get; set; }

        /// <summary>
        /// If false, the .visually-hidden class is added to the label
        /// </summary>
        [Parameter] public bool ShowLabel { get; set; } = true;

        /// <summary>
        /// If set, adds a ValidationMessage component underneath the input
        /// </summary>
        [Parameter] public Expression<Func<T>> ValidationFor { get; set; }

        [Inject] protected IJSRuntime Js { get; set; }

        protected bool needsInputGroup { get; set; }

        protected bool required { get; set; }

        protected string visuallyHiddedCss { get; private set; } = "";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                if (Autofocus) await Js.InvokeVoidAsync("cs.focusElementById", ElementId);
#pragma warning restore CS8604 // Possible null reference argument.
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected override void OnInitialized()
        {
            if (string.IsNullOrWhiteSpace(ElementId)) ElementId = "".GenerateRandomString_Mt(5, null, false);

            if (string.IsNullOrWhiteSpace(Placeholder)) Placeholder = $"Enter {DisplayName?.ToLower()} here...";

            if (!ShowLabel) visuallyHiddedCss = "visually-hidden";

            if(AppendHtml != null || AppendText != null || PrependHtml != null || PrependText != null) needsInputGroup = true;

            base.OnInitialized();
        }
    }
}
