using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServicesUi.Forms.Bases
{
    public abstract class BaseButton : ComponentBase
    {
        /// <summary>
        /// Additional attributes to put on the button element
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>
        /// Sets "btn-sm" class on button. Default is false
        /// </summary>
        [Parameter] public bool BtnSmall { get; set; }

        /// <summary>
        /// The method to call on click
        /// </summary>
        [Parameter] public EventCallback Callback { get; set; }

        /// <summary>
        /// Whether or not the button is disabled. Default is false
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// The title attribute on the button element
        /// </summary>
        [Parameter] public string? Title { get; set; }

        protected string btnSmallClass = "btn-sm";

        /// <summary>
        /// Disable the button
        /// </summary>
        public void Disable()
        {
            Disabled = true;
        }

        /// <summary>
        /// Enable the button
        /// </summary>
        public void Enable()
        {
            Disabled = false;
        }
    }
}
