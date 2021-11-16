using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServicesUi.Forms.Bases
{
    public abstract class BaseSelectable<T> : BaseInput<T>
    {

        /// <summary>
        /// If true, all text/full number etc is selected when input gains focus
        /// </summary>
        [Parameter] public bool SelectAll { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && SelectAll)
            {
#pragma warning disable CS8604
                await Js.InvokeVoidAsync("cs.setSelectAll", ElementId);
#pragma warning restore CS8604
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
