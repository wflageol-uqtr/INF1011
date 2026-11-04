using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class FlushStrategy : ICalculateHandStrategy
    {
        public Hand Hand => Hand.Flush;

        public bool CalculateHand(PokerHand hand)
        {
            return hand.SuitsCount() == 1;
        }
    }
}
