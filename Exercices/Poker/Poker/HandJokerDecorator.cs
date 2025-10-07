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

        public HandJokerDecorator(IHand hand)
        {
            this.hand = hand;
        }

        private bool IsJoker() => hand.Any(c => c.Value == CardValue.Joker);

        private IEnumerable<Hand> GenerateHands()
        {
            throw new NotImplementedException();
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
