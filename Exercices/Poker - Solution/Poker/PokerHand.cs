using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class PokerHand : IPokerHand
    {
        private Card[] cards;

        public PokerHand(IEnumerable<Card> cards)
        {
            if (cards.Count() != 5)
                throw new ArgumentException("Nombre invalide de cartes.");

            this.cards = cards.ToArray();
        }

        public Hand CalculateHand()
        {
            // TODO: Rendre ça mieux orienté objet.

            var identicalCount = IdenticalCards();

            if (IsRoyalFlush())
                return Hand.RoyalFlush;
            if (IsStraight() && SuitsCount() == 1)
                return Hand.StraightFlush;
            if (identicalCount == 4)
                return Hand.FourOfAKind;
            if (IsStraight())
                return Hand.Straight;
            if (IsFullHouse())
                return Hand.FullHouse;
            if (SuitsCount() == 1)
                return Hand.Flush;
            if (identicalCount == 3)
                return Hand.ThreeOfAKind;
            if (IsTwoPairs())
                return Hand.TwoPair;
            if (identicalCount == 2)
                return Hand.Pair;

            return Hand.HighCard;
        }

        private int IdenticalCards()
        {
            int identicalCount = 0;

            foreach(Card card in cards)
            {
                int count = cards.Where(c => c.Value == card.Value).Count();
                if(count > identicalCount)
                {
                    identicalCount = count;
                }
            }

            return identicalCount;
        }

        private int SuitsCount()
        {
            return cards.DistinctBy(c => c.Suit).Count();
        }

        private bool IsFullHouse()
        {
            var groups = cards.GroupBy(c => c.Value)
                .OrderBy(g => g.Count());
            return groups.ElementAt(0).Count() == 2
                && groups.ElementAt(1).Count() == 3;
        }

        private bool IsTwoPairs()
        {
            var groups = cards.GroupBy(c => c.Value)
                .OrderByDescending(g => g.Count());
            return groups.ElementAt(0).Count() == 2
                && groups.ElementAt(1).Count() == 2;
        }

        private bool IsStraight()
        {
            var values = cards.Select(c => c.ValueInt).Order();
            var first = values.First();
            foreach(var value in values.Skip(1))
            {
                first++;
                if (value != first)
                    return false;
            }

            return true;
        }

        private bool IsRoyalFlush()
        {
            if (SuitsCount() > 1)
                return false;

            var values = cards.Select(c => c.ValueInt).Order();

            return values.ElementAt(0) == 1
                && values.ElementAt(1) == 10
                && values.ElementAt(2) == 11
                && values.ElementAt(3) == 12
                && values.ElementAt(4) == 13;
        }
    }
}
