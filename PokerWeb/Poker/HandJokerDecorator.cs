using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class HandJokerDecorator : IHand
    {
        private IHand hand;
        private IDeck deck;

        public HandJokerDecorator(IHand hand, IDeck deck)
        {
            this.hand = hand;
            this.deck = deck;
        }

        private bool IsJoker() => hand.Any(c => c.Value == CardValue.Joker);

        private IEnumerable<IHand> GenerateHands()
        {
            var noJokerCards = hand.Where(c => !c.IsJoker);

            IEnumerable<IEnumerable<Card>> hands = [noJokerCards];

            while (hands.Any() && hands.First().Count() < 5)
            {
                List<IEnumerable<Card>> newHands = new();

                foreach (var hand in hands)
                    foreach (var card in deck)
                        newHands.Add(hand.Append(card));

                hands = newHands;
            }

            return hands.Select(cs => new Hand(cs));
        }

        public HandValue CalculateValue()
        {
            if(IsJoker())
                return GenerateHands().Select(h => h.CalculateValue()).Max();
            else 
                return hand.CalculateValue();
        }

        public IEnumerator<Card> GetEnumerator() => hand.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => hand.GetEnumerator();
    }
}
