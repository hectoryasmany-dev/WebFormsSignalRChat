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
                window.RegisterClientScriptInclude("signalr", "https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/5.0.4/signalr.min.js");
                window.RegisterClientScriptInclude("hub", "http://localhost:2064/signalr/hubs");
                window.RegisterClientScriptInclude("messenger", "http://localhost:2064/Scripts/Chat.js");
            }

        }

        //needs change this to window controller
        //protected override void OnViewControlsCreated()
        //{
        //    base.OnViewControlsCreated();
        //    //its messing with dx javascripts
        //    //WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("jquery", "http://localhost:2064/Scripts/jquery-1.6.4.min.js");
        //    WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("signalr", "https://localhost:7206/js/signalr/dist/browser/signalr.js");
        //    //WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("hub", "https://localhost:7206/signalr/hubs");
        //    WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("messenger", "https://localhost:7206/js/chat.js");
        //    //WebWindow.CurrentRequestWindow.RegisterClientScript("StartListening", $"sendMessage('','');");
        //WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("jquery", "http://localhost:2064/Scripts/jquery-1.6.4.min.js");
       // WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("signalr", "http://localhost:2064/Scripts/jquery.signalR-2.4.3.min.js");
         //   WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("hub", "http://localhost:2064/signalr/hubs");
           // WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("messenger", "http://localhost:2064/Scripts/Chat.js");
            //WebWindow.CurrentRequestWindow.RegisterClientScript("StartListening", $"sendMessage('','');");
        //}
        protected override void OnActivated()
        {
            base.OnActivated();
           
        }
    }
}
