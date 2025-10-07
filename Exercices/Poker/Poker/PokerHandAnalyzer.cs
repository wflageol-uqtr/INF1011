using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandAnalyzer
    {
        private CardSerializer serializer = new();

        public HandValue AnalyzeHand(string[] rawHand)
        {
            IHand hand = new Hand(rawHand.Select(serializer.Deserialize));
            hand = new HandJokerDecorator(hand);

            return hand.CalculateValue();
        }
    }
}
