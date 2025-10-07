using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Deck : IEnumerable<Card>
    {
        private List<Card> cards = new();

        public static Deck CreateFullDeck()
        {
            var deck = new Deck();

            foreach (var suit in Enum.GetValues<CardSuit>())
            {
                foreach (var value in Enum.GetValues<CardValue>())
                    deck.cards.Add(new Card(suit, value));
            }

            return deck;
        }


        public IEnumerator<Card> GetEnumerator() => cards.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => cards.GetEnumerator();
    }
}
