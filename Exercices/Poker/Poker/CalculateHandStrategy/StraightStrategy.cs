using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class StraightStrategy : AbstractStraightStrategy, ICalculateHandStrategy
    {
        public Hand Hand => Hand.Straight;

        public bool CalculateHand(PokerHand hand)
        {
            return IsStraight(hand);
        }
    }
}
