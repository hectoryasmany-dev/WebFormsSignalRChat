using Microsoft.AspNetCore.SignalR;
//added by me
namespace SignalRChatHubContainer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
