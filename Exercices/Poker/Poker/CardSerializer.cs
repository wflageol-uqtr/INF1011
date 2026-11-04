using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class CardSerializer
    {
        public Card? Deserialize(string cardString)
        {
            if (cardString == "JK")
                return null;

            var value = (CardValue)cardString[0];
            var suit = (CardSuit)cardString[1];

            return new Card(suit, value);
        }
    }
}
