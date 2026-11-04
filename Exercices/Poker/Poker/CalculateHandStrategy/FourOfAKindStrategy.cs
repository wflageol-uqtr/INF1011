using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class FourOfAKindStrategy : ICalculateHandStrategy
    {
        public Hand Hand => Hand.FourOfAKind;

        public bool CalculateHand(PokerHand hand)
        {
            return hand.IdenticalCards() == 4;
        }
    }
}
