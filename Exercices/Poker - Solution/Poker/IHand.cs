using System.Collections;
using System.Collections.Generic;

namespace Poker
{
    public interface IHand : IEnumerable<Card>
    {
        HandValue CalculateValue();
    }
}