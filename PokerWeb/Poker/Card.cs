using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum CardSuit
    {
        Spade,
        Heart,
        Diamond,
        Club,
        Joker,
    }

    public enum CardValue
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Joker,
    }

    public class Card : IComparable<Card>
    {
        public CardSuit Suit { get; }
        public CardValue Value { get; }

        public bool IsJoker => Suit == CardSuit.Joker;

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public int CompareTo(Card other)
        {
            if (Value > other.Value)
                return 1;
            else if (Value < other.Value)
                return -1;
            else
                return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Card)
                return CompareTo(obj as Card) == 0;
            else
                return false;
        }

        public static bool operator ==(Card left, Card right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }

        public static bool operator <(Card left, Card right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Card left, Card right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Card left, Card right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Card left, Card right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
