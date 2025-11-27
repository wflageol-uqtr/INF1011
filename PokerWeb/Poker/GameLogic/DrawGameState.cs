using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.GameLogic
{
    public class DrawGameState : GameState
    {
        public override void DrawCards(IDeck deck)
        {
            List<Card> cards = new();
            for (int i = 0; i < 5; i++)
                cards.Add(deck.Draw());

            UpdatedPlayer = new PlayerState(new Hand(cards), 0, false);
        }

        public override IGameState CreateNextGameState()
        {
            if (UpdatedPlayer == null)
                throw new ArgumentException("Opération invalide.");

            return new BetGameState(UpdatedPlayer, false);
        }
    }
}
