using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal enum CardSuit
    {
        Heart = 'H',
        Spade = 'S',
        Clubs = 'C',
        Diamond = 'D'
    }

    internal enum CardValue
    {
        Ace = 'A',
        Two = '2',
        Three = '3',
        Four = '4',
        Five = '5',
        Six = '6',
        Seven = '7',
        Eight = '8',
        Nine = '9',
        Ten = 'T',
        Jack = 'J',
        Queen = 'Q',
        King = 'K'
    }

    internal class Card
    {
        public CardSuit Suit { get; }
        public CardValue Value { get; }

        public int ValueInt
        {
            get
            {
                switch(Value)
                {
                    case CardValue.Ace: return 1;
                    case CardValue.Ten: return 10;
                    case CardValue.Jack: return 11;
                    case CardValue.Queen: return 12;
                    case CardValue.King: return 13;
                    default: return int.Parse(((char)Value).ToString());
                }
            }
        }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
 