using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public class FullHouseStrategy : ICalculateHandStrategy
    {
        public Hand Hand => Hand.FullHouse;

        public bool CalculateHand(PokerHand hand)
        {
            var groups = hand.Cards.GroupBy(c => c.Value)
                .OrderBy(g => g.Count());
            return groups.ElementAt(0).Count() == 2
                && groups.ElementAt(1).Count() == 3;
        }
    }
}
