using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class StraightFlushStrategy : AbstractStraightStrategy, ICalculateHandStrategy
    {
        public Hand Hand => Hand.StraightFlush;

        public bool CalculateHand(PokerHand hand)
        {
            return IsStraight(hand) && hand.SuitsCount() == 1;
        }
    }
}
