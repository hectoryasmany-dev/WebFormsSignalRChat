using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Web;
using WebFormsSignalRChat.Module.BusinessObjects;
namespace WebFormsSignalRChat.Module.Web.Controllers
{
    public class ChatController : ObjectViewController<DetailView, ChatContainer>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            ((WebWindow)this.Frame).RegisterStartupScript("test", "alert('test')");

        }
        public ChatController()
        {
            var sendMessage = new SimpleAction(this, "acSendMessage", "View");
            sendMessage.Caption = "Send";
            sendMessage.Execute += SendMessage_Execute;
            
        }

        private void SendMessage_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            
            //var currentObj = e.CurrentObject as ChatContainer;
            //var hub = new ChatHub();
            //hub.Send(currentObj.SenderName, currentObj.Message);
        }
       
    }
}