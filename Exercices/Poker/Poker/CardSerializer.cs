using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class CardSerializer
    {
        private Dictionary<char, CardValue> Values = new()
        {
            { 'A', CardValue.Ace },
            { '2', CardValue.Two },
            { '3', CardValue.Three },
            { '4', CardValue.Four },
            { '5', CardValue.Five },
            { '6', CardValue.Six },
            { '7', CardValue.Seven },
            { '8', CardValue.Eight },
            { '9', CardValue.Nine },
            { 'T', CardValue.Ten },
            { 'J', CardValue.Jack },
            { 'Q', CardValue.Queen },
            { 'K', CardValue.King },
        };

        private Dictionary<char, CardSuit> Suits = new()
        {
            { 'H', CardSuit.Heart },
            { 'S', CardSuit.Spade },
            { 'D', CardSuit.Diamond },
            { 'C', CardSuit.Club },
        };

        private CardValue ValueFromChar(char c) => Values[c];
        private CardSuit SuitFromChar(char c) => Suits[c];

        public Card Deserialize(string serializedCard)
        {
            if (serializedCard.Length != 2)
                throw new ArgumentException("String séralisée de mauvaise longueur.");

            if (serializedCard == "JK")
                return new Card(CardSuit.Joker, CardValue.Joker);

            if (!Values.ContainsKey(serializedCard[0]))
                throw new ArgumentException("Valeur non reconnue.");
            if (!Suits.ContainsKey(serializedCard[1]))
                throw new ArgumentException("Couleur non reconnue.");

            return new Card(
                SuitFromChar(serializedCard[1]),
                ValueFromChar(serializedCard[0])
            );
        }
    }
}
