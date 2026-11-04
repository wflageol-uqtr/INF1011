using Poker.CalculateHandStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class PokerHand : IPokerHand
    {
        private Card[] cards;

        public IEnumerable<Card> Cards => cards;

        public PokerHand(IEnumerable<Card> cards)
        {
            if (cards.Count() != 5)
                throw new ArgumentException("Nombre invalide de cartes.");

            this.cards = cards.ToArray();
        }

        public Hand CalculateHand()
        {
            List<ICalculateHandStrategy> strategies =
                [
                new RoyalFlushStrategy(),
                new StraightFlushStrategy(),
                new FourOfAKindStrategy(),
                new StraightStrategy(),
                new FullHouseStrategy(),
                new FlushStrategy(),
                new ThreeOfAKindStrategy(),
                new TwoPairStrategy(),
                new PairStrategy(),
                new HighCardStrategy(),
            ];

            foreach (var strategy in strategies)
            {
                if (strategy.CalculateHand(this))
                    return strategy.Hand;
            }

            throw new InvalidOperationException();
        }

        public int IdenticalCards()
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

        public int SuitsCount()
        {
            return cards.DistinctBy(c => c.Suit).Count();
        }

    }
}
