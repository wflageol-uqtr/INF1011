using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandAnalyzer
    {
        public Hand AnalyzeHand(string[] hand)
        {
            CardSerializer serializer = new();
            var deck = BuildDeck();
            var cards = hand.Select(serializer.Deserialize)
                .Where(c => c != null);

            IPokerHand pokerHand;
            if (cards.Count() == 5)
                pokerHand = new PokerHand(cards);
            else 
                pokerHand = new JokerHand(cards, deck);

                return pokerHand.CalculateHand();
        }

        private IEnumerable<Card> BuildDeck()
        {
            var cards = new List<Card>();
            foreach(var suit in Enum.GetValues<CardSuit>())
            {
                foreach (var value in Enum.GetValues<CardValue>())
                    cards.Add(new Card(suit, value));
            }

            return cards;
        }
    }
}