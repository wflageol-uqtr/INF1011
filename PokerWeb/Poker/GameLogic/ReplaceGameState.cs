using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.GameLogic
{
    public class ReplaceGameState : GameState
    {
        private PlayerState initialPlayer;

        public ReplaceGameState(PlayerState player)
        {
            initialPlayer = player;
        }

        public override void ReplaceCards(IDeck deck, IEnumerable<Card> replaceCards)
        {
            if (UpdatedPlayer != null)
                throw new GameException("Vous avez déjà remplacé votre main.");

            List<Card> cards = new(initialPlayer.Hand);

            foreach (var card in replaceCards)
            {
                cards.Remove(card);
                cards.Add(deck.Draw());
            }

            UpdatedPlayer = initialPlayer with { Hand = new Hand(cards) };
        }

        public override IGameState CreateNextGameState()
        {
            if (UpdatedPlayer == null)
                throw new ArgumentException("Opération invalide.");

            return new BetGameState(UpdatedPlayer, true);
        }
    }
}
