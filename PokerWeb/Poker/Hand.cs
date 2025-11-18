using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Hand : IHand
    {
        private IEnumerable<Card> cards;

        private IEnumerable<CardValue> cardValues;
        private IEnumerable<CardSuit> cardSuits;

        public Hand(IEnumerable<Card> cards)
        {
            if (cards.Count() != 5)
                throw new ArgumentException("Mauvais nombre de carte pour une main.");

            this.cards = cards;
            cardValues = cards.Select(c => c.Value);
            cardSuits = cards.Select(c => c.Suit);
        }

        public HandValue CalculateValue()
        {
            if (TestRoyalFlush())
                return HandValue.RoyalFlush;
            if (TestStraightFlush())
                return HandValue.StraightFlush;
            if (TestFourOfAKind())
                return HandValue.FourOfAKind;
            if (TestFullHouse())
                return HandValue.FullHouse;
            if (TestFlush())
                return HandValue.Flush;
            if (TestStraight())
                return HandValue.Straight;
            if (TestThreeOfAKind())
                return HandValue.ThreeOfAKind;
            if (TestTwoPair())
                return HandValue.TwoPair;
            if (TestPair())
                return HandValue.Pair;

            return HandValue.HighCard;
        }

        private bool TestPair() => cardValues.Distinct().Count() < 5;

        private bool TestGroups(int groupSize, int groupCount)
        {
            var groups = cardValues
                .GroupBy(v => v)
                .Where(g => g.Count() >= groupSize);

            return groups.Count() >= groupCount;
        }

        private bool TestTwoPair() => TestGroups(2, 2);

        private bool TestThreeOfAKind() => TestGroups(3, 1);

        private bool TestStraight()
        {
            var ordered = cardValues.Order();

            int init = (int)ordered.First();
            foreach (var next in ordered.Skip(1))
            {
                init++;
                if ((int)next != init)
                    return false;
            }

            return true;
        }

        private bool TestFlush() => cardSuits.Distinct().Count() == 1;

        private bool TestFullHouse()
        {
            var groups = cardValues.GroupBy(v => v);
            return groups.Any(g => g.Count() == 3)
                && groups.Any(g => g.Count() == 2);
        }

        private bool TestFourOfAKind() => TestGroups(4, 1);

        private bool TestStraightFlush() => TestStraight() && TestFlush();

        private bool TestRoyalFlush() =>
            TestFlush()
            && cardValues.Intersect([
                CardValue.Ten,
                CardValue.Jack,
                CardValue.Queen,
                CardValue.King,
                CardValue.Ace])
            .Count() == 5;

        public IEnumerator<Card> GetEnumerator() => cards.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => cards.GetEnumerator();
    }
}
