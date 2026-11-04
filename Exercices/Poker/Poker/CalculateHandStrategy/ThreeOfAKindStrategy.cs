using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class ThreeOfAKindStrategy : ICalculateHandStrategy
    {
        public Hand Hand => Hand.ThreeOfAKind;

        public bool CalculateHand(PokerHand hand)
        {
            return hand.IdenticalCards() == 3;
        }
    }
}
