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
            if (cards.Count() < 3)
                throw new ArgumentException("Impossible d'avoir plus de 2 jokers.");

            this.cards = cards;
            this.cardDeck = deck;
        }

        public Hand CalculateHand()
        {
            int count = cards.Count();

            List<IEnumerable<Card>> hands = [cards];

            while (count < 5)
            {
                List<IEnumerable<Card>> newHands = [];
                foreach (var cards in hands) {
                    foreach (var card in cardDeck)
                    {
                        var newCards = cards.Append(card);
                        newHands.Add(newCards);
                    }
                }

                hands = newHands;
                count++;
            }

            var best = hands.Select(cards => new PokerHand(cards))
                .Select(hand => hand.CalculateHand())
                .Max();

            return best;
        }
    }
}
