using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class RoyalFlushStrategy : ICalculateHandStrategy
    {
        public Hand Hand => Hand.RoyalFlush;

        public bool CalculateHand(PokerHand hand)
        {
            if (hand.SuitsCount() > 1)
                return false;

            var values = hand.Cards.Select(c => c.ValueInt).Order();

            return values.ElementAt(0) == 1
                && values.ElementAt(1) == 10
                && values.ElementAt(2) == 11
                && values.ElementAt(3) == 12
                && values.ElementAt(4) == 13;
        }
    }
}
