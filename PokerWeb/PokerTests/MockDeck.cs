using Poker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTests
{
    internal class MockDeck : IDeck
    {
        private Stack<Card> cards;

        public MockDeck()
        {
            cards = new();

            foreach (var suit in Enum.GetValues<CardSuit>())
            {
                foreach (var value in Enum.GetValues<CardValue>())
                {
                    if (suit != CardSuit.Joker && value != CardValue.Joker)
                        cards.Push(new Card(suit, value));
                }
            }
        }

        public Card Draw() => cards.Pop();

        public IEnumerator<Card> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
