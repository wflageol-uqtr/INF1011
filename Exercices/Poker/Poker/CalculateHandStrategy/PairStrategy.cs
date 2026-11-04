using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class PairStrategy : ICalculateHandStrategy
    {
        public Hand Hand => Hand.Pair;

        public bool CalculateHand(PokerHand hand)
        {
            return hand.IdenticalCards() == 2;
        }
    }
}
