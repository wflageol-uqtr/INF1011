using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.GameLogic
{
    public record PlayerState(Hand Hand, int Bet, bool Folded);
}
