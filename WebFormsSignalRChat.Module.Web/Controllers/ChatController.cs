using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Templates;
using Microsoft.AspNet.SignalR.Client;
using System;
using WebFormsSignalRChat.Module.BusinessObjects;
namespace WebFormsSignalRChat.Module.Web.Controllers
{
    public class ChatController : ViewController<DetailView>, IXafCallbackHandler
    {
        IHubProxy myHub;
        HubConnection connection;
        public ChatController()
        {
            TargetObjectType = typeof(ChatContainer);
            var sendMessage = new SimpleAction(this, "acSendMessage", "View");
            sendMessage.Caption = "Send";
            sendMessage.Execute += SendMessage_Execute;

        }

        private  void SendMessage_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            connection = new HubConnection("http://localhost:52838/");
            //Make proxy to hub based on hub name on server
            myHub = connection.CreateHubProxy("CustomHub");
            //Start connection

             connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                    myHub.Invoke<string>("Send", "HELLO World ").ContinueWith(task2 =>
                    {
                        if (task2.IsFaulted)
                        {
                            Console.WriteLine("There was an error calling send: {0}",
                                              task.Exception.GetBaseException());
                        }
                        else
                        {
                            Console.WriteLine(task2.Result);
                        }
                    });

                    myHub.On<string>("addMessage", param =>
                    {
                        Console.WriteLine(param);
                    });
                }

            }).Wait();
            
            //var currentObj = e.CurrentObject as ChatContainer;
            //var title = currentObj.Title;
            //var message = currentObj.Message;
            //WebWindow.CurrentRequestWindow.RegisterClientScript("SendBroadcastAlert", $"sendMessage('{title}','{message}');");
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
        //public async void SendMessage()
        //{
        //    var url = "Hub URL goes here";

        //    var connection = new HubConnectionBuilder()
        //        .WithUrl($"{url}")
        //        .WithAutomaticReconnect() //I don't think this is totally required, but can't hurt either
        //        .Build();

        //    //Start the connection
        //    var t = connection.StartAsync();

        //    //Wait for the connection to complete
        //    t.Wait();

        //    //Make your call - but in this case don't wait for a response 
        //    //if your goal is to set it and forget it
        //    await connection.InvokeAsync("SendMessage", "User-Server", "Message from the server");
        //}
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