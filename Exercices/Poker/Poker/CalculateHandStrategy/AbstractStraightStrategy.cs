using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class AbstractStraightStrategy
    {
        protected bool IsStraight(PokerHand hand)
        {
            var values = hand.Cards.Select(c => c.ValueInt).Order();
            var first = values.First();
            foreach (var value in values.Skip(1))
            {
                first++;
                if (value != first)
                    return false;
            }

            return true;
        }
    }
}
