using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class JokerHand : IPokerHand
    {
        private IEnumerable<Card> cards;
        private IEnumerable<Card> cardDeck;

        public JokerHand(IEnumerable<Card> cards, IEnumerable<Card> deck)
        {
            if (cards.Count() >= 5)
                throw new ArgumentException("Impossible de créer un JokerHand à 5 cartes.");
            if (cards.Count() < 4)
                throw new ArgumentException("Impossible d'avoir plus de 2 jokers.");

            this.cards = cards;
            this.cardDeck = deck;
        }

        public Hand CalculateHand()
        {
            Hand best = Hand.HighCard;

            foreach(var card in cardDeck)
            {
                var newHand = new PokerHand(cards.Append(card));
                var handValue = newHand.CalculateHand();

                if (handValue > best)
                    best = handValue;
            }

            return best;
        }
    }
}
