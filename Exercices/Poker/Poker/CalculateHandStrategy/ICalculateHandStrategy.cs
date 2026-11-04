using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CalculateHandStrategy
{
    public interface ICalculateHandStrategy
    {
        bool CalculateHand(PokerHand hand);
        Hand Hand { get; }
    }
}
