using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class HighCardStrategy : ICalculateHandStrategy
    {
        public Hand Hand => Hand.HighCard;

        public bool CalculateHand(PokerHand hand)
        {
            return true;
        }
    }
}
