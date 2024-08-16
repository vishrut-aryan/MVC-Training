using ChatAppTest.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatAppTest.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("receiveMessage", message);
    }
}
