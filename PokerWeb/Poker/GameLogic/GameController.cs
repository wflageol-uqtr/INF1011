using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.GameLogic
{
    public class GameController
    {
        private IDeck deck;
        private Dictionary<string, IGameState> playerGameStates = new();
        private int betAmount = 0;

        public GameController(IDeck deck, IEnumerable<string> players)
        {
            this.deck = deck;
            foreach (var player in players)
                playerGameStates[player] = new DrawGameState();
        }

        private void ValidatePlayer(string playerName)
        {
            if (!playerGameStates.ContainsKey(playerName))
                throw new GameException("Joueur invalide.");
        }

        public void DrawCard(string playerName)
        {
            ValidatePlayer(playerName);

            playerGameStates[playerName].DrawCards(deck);
        }

        public void Bet(string playerName, int amount)
        {
            ValidatePlayer(playerName);

            if (amount > 0)
            {
                foreach (var kvp in playerGameStates)
                    playerGameStates[kvp.Key].ResetBet();
            }

            playerGameStates[playerName].Bet(betAmount + amount);
        }

        public void Fold(string playerName)
        {
            ValidatePlayer(playerName);

            playerGameStates[playerName].Fold();
        }

        public void ReplaceCards(string playerName, string serializedCardsToReplace)
        {
            ValidatePlayer(playerName);

            CardSerializer serializer = new();

            var cardsToReplace = serializedCardsToReplace
                .Split(" ")
                .Select(serializer.Deserialize);

            playerGameStates[playerName].ReplaceCards(deck, cardsToReplace);
        }

        public bool ProgressGame()
        {
            foreach(var kvp in playerGameStates)
            {
                if (!kvp.Value.IsComplete)
                    return false;
            }

            foreach (var kvp in playerGameStates)
            {
                var newState = kvp.Value.CreateNextGameState();

                if (newState == null)
                    playerGameStates.Remove(kvp.Key);
                else 
                    playerGameStates[kvp.Key] = newState;
            }

            return true;
        }
    }
}