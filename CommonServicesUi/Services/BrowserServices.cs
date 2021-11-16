using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServicesUi.Services
{
    /// <summary>
    /// Provides common browser methods. Needs to be added to Services in the client app, i.e. builder.Services.AddScoped<BrowserServices>();
    /// </summary>
    public class BrowserServices : ComponentBase
    {
        /// <summary>
        /// Direct access to the IJSRuntime for ad hoc calls
        /// </summary>
        public IJSRuntime Js { get; set; }

        public BrowserServices(IJSRuntime js)
        {
            Js = js;
            Console = new BrowserConsole(js);
        }

        public BrowserConsole Console { get; set; }

        public void FocusElementById(string id)
        {
            Js.InvokeVoidAsync("cs.focusElementById", id);
        }

        /// <summary>
        /// All th and td with an "r" attribute get "text-right" added to class list
        /// </summary>
        public void JustifyTable()
        {
            Js.InvokeVoidAsync("cs.justifyTable");
        }

        public void ScrollToElement(string selector, int? delay = null)
        {
            Js.InvokeVoidAsync("cs.scrollToElement", selector, delay);
        }
    }

    public class BrowserConsole
    {
        IJSRuntime js_ { get; set; }

        public BrowserConsole(IJSRuntime js)
        {
            js_ = js;
        }

        public void Clear()
        {
            js_.InvokeVoidAsync("cs.clear");
        }
    }

    public class LocalStorage
    {
        IJSRuntime js_ { get; set; }
        
        public LocalStorage(IJSRuntime js)
        {
            js_ = js;
        }


    }
}
