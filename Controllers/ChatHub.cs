using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace whiteboard_be_dotnet.Controllers
{
    public class ChatHub : Hub
    {
        
        public async Task SendMessage(string user, Data message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message.passport);

            System.Console.WriteLine();
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Socket connected");
            return base.OnConnectedAsync();
        }
    }
}

