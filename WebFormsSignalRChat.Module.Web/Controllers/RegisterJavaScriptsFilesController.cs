using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFormsSignalRChat.Module.Web.Controllers
{
    public class RegisterJavaScriptsFilesController : WindowController
    {
        public RegisterJavaScriptsFilesController()
        {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnWindowControllersActivated()
        {
            base.OnWindowControllersActivated();
            var window = (WebWindow)Frame;
            if (window != null)
            {
                //window.RegisterClientScriptInclude("signalr", "https://localhost:7206/js/signalr/dist/browser/signalr.js");
                //window.RegisterClientScriptInclude("messenger", "https://localhost:7206/js/chat.js");
                //WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("signalr", "http://localhost:2064/Scripts/jquery.signalR-2.4.3.min.js");
                //WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("hub", "http://localhost:2064/signalr/hubs");
                //WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("messenger", "http://localhost:2064/Scripts/Chat.js");
                window.RegisterClientScriptInclude("signalr", "http://localhost:2064/Scripts/jquery.signalR-2.4.3.min.js");
                window.RegisterClientScriptInclude("hub", "http://localhost:50511/signalr/hubs");
                window.RegisterClientScriptInclude("messenger", "http://localhost:50511/Scripts/Chat.js");
            }

        }
    }
}
