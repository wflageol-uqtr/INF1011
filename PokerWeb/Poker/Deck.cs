using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Deck : IDeck
    {
        private Random random = new();

        public static Deck Instance { get; } = CreateFullDeck();

        private List<Card> cards = new();

        private Deck() { }
        private static Deck CreateFullDeck()
        {
            var deck = new Deck();

            foreach (var suit in Enum.GetValues<CardSuit>())
            {
                foreach (var value in Enum.GetValues<CardValue>())
                {
                    if (suit != CardSuit.Joker && value != CardValue.Joker)
                        deck.cards.Add(new Card(suit, value));
                }
            }

            return deck;
        }

        public Card Draw()
        {
            int index = random.Next(cards.Count);
            Card card = cards[index];
            cards.Remove(card);

            return card;
        }


        public IEnumerator<Card> GetEnumerator() => cards.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => cards.GetEnumerator();
    }
}
