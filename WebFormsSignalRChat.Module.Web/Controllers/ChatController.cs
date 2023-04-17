using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Templates;
using WebFormsSignalRChat.Module.BusinessObjects;
namespace WebFormsSignalRChat.Module.Web.Controllers
{
    public class ChatController : ViewController<DetailView>, IXafCallbackHandler
    {

        public ChatController()
        {
            TargetObjectType = typeof(ChatContainer);
            var sendMessage = new SimpleAction(this, "acSendMessage", "View");
            sendMessage.Caption = "Send";
            sendMessage.Execute += SendMessage_Execute;

        }

        private void SendMessage_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var currentObj = e.CurrentObject as ChatContainer;
            var title = currentObj.Title;
            var message = currentObj.Message;
            WebWindow.CurrentRequestWindow.RegisterClientScript("SendBroadcastAlert", $"sendMessage('{title}','{message}');");
            //MessageOptions ms = new MessageOptions();
            //ms.Duration = 3000;
            //ms.Message = message;
            //ms.Type = InformationType.Warning;
            //Application.ShowViewStrategy.ShowMessage(ms);
            //((WebWindow)this.Frame).RegisterStartupScript("ExecuteScriptFromAction", $"RaiseXafCallback(globalCallbackControl, 'MyScript', '{message}', '', false);");

        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            //XafCallbackManager.RegisterHandler("MyScript", this);
            ////WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("jquery", "http://localhost:2064/Scripts/jquery-1.6.4.min.js");
            //WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("signalr", "http://localhost:2064/Scripts/jquery.signalR-2.4.3.min.js");
            //WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("hub", "http://localhost:2064/signalr/hubs");
            //WebWindow.CurrentRequestWindow.RegisterClientScriptInclude("messenger", "http://localhost:2064/Scripts/Chat.js");
            //WebWindow.CurrentRequestWindow.RegisterClientScript("StartListening", $"sendMessage('','');");

        }

        protected XafCallbackManager XafCallbackManager
        {
            get
            {
                return WebWindow.CurrentRequestPage != null ? ((ICallbackManagerHolder)WebWindow.CurrentRequestPage).CallbackManager : null;
            }
        }
        public void ProcessAction(string parameter)
        {
            var currentObj = View.CurrentObject as ChatContainer;
            var title = currentObj.Title;
            XafCallbackManager.NeedEndResponse = false;
            string Script = $"sendMessage('{title}','{parameter}');";
            ((WebWindow)this.Frame).RegisterStartupScript("CallBack", Script, true);
        }
    }
}