using Microsoft.AspNetCore.SignalR;
using Poker;
using Poker.GameLogic;
using System.Diagnostics.Eventing.Reader;

namespace PokerWeb.Hubs
{
    public class PokerHub : Hub
    {
        public const string Url = "/pokerhub";

        private GameController pokerController = new();

        private PokerHandAnalyzer analyzer = new();

        private bool IsEvaluationRequest(string message)
            => message.StartsWith("[Evaluate]");

        private string EvaluateHand(string message)
        {
            var hand = message.Substring(11);

            try
            {
                return analyzer.AnalyzeHand(hand.Split(" ")).ToString();
            } catch(ArgumentException ex)
            {
                return $"Main invalide: {ex.Message}";
            } catch(Exception)
            {
                return "Main invalide.";
            }
        }

        public async Task Broadcast(string username, string message)
        {
            if (IsEvaluationRequest(message))
            {
                var response = EvaluateHand(message);
                // Envoyer seulement au client qui a fait la requête.
                await Clients.Client(Context.ConnectionId).SendAsync("Broadcast", username, $"[Evaluation] {response}");
            }
            else
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
