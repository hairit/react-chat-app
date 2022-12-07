using chatapp_server.Models;
using Microsoft.AspNetCore.SignalR;
namespace chatapp_server
{
    public class Message : Hub
    {
        private readonly string _botUser;

        public Message()
        {
            _botUser = "Welcome to my chat";
        }

        public async Task JoinRoom(ChatUser user,string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.All.SendAsync("ReceiveMessage", _botUser , $"{user.Name} has joined");
        }
    }
}
