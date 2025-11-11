using Microsoft.AspNetCore.SignalR;

namespace PokerWeb.Hubs
{
    public class PokerHub : Hub
    {
        public const string Url = "/pokerhub";

        public async Task Broadcast(string username, string message)
        {
            await Clients.All.SendAsync("Broadcast", username, message);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connecté.");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? e)
        {
            Console.WriteLine($"Déconnection: {e?.Message} {Context.ConnectionId}");
            return base.OnDisconnectedAsync(e);
        }
    }
}
