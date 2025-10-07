using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class PokerHandAnalyzerTests
    {
        PokerHandAnalyzer analyzer;

        [TestInitialize]
        public void SetUp() => analyzer = new PokerHandAnalyzer();

        void TestHand(HandValue expected, string hand) 
            => Assert.AreEqual(expected, analyzer.AnalyzeHand(hand.Split(" ")));

        [TestMethod]
        public void HighCard() => TestHand(HandValue.HighCard, "AS 7D 9S JH KC");

        [TestMethod]
        public void Pair() => TestHand(HandValue.Pair, "3S 6C JH JS QD");

        [TestMethod]
        public void TwoPair() => TestHand(HandValue.TwoPair, "QS 8D 8H QC JS");

        [TestMethod]
        public void ThreeOfAKind() => TestHand(HandValue.ThreeOfAKind, "7S 7D 7H QC JS");

        [TestMethod]
        public void Straight() => TestHand(HandValue.Straight, "AS 3D 2S 5H 4C");

        [TestMethod]
        public void Flush() => TestHand(HandValue.Flush, "3D JD 9D QD KD");

        [TestMethod]
        public void FullHouse() => TestHand(HandValue.FullHouse, "AS TH TC AH TS");

        [TestMethod]
        public void FourOfAKind() => TestHand(HandValue.FourOfAKind, "QH QS 2H QC QD");

        [TestMethod]
        public void StraightFlush() => TestHand(HandValue.StraightFlush, "2S 4S 3S 5S 6S");

        [TestMethod]
        public void RoyalFlush() => TestHand(HandValue.RoyalFlush, "AC KC QC JC TC");

        [TestMethod]
        public void JokerPair() => TestHand(HandValue.Pair, "3S 6C 7S KH JK");

        [TestMethod]
        public void JokerThreeOfAKind() => TestHand(HandValue.ThreeOfAKind, "4H 2S AH JK AD");

        [TestMethod]
        public void JokerThreeOfAKind2() => TestHand(HandValue.ThreeOfAKind, "6H 2S AH JK JK");

        [TestMethod]
        public void JokerStraight() => TestHand(HandValue.Straight, "3S 4D JK 6H 7C");

        [TestMethod]
        public void JokerStraight2() => TestHand(HandValue.Straight, "4H 2S AH JK JK");

        [TestMethod]
        public void JokerFlush() => TestHand(HandValue.Flush, "3D 6D 9D JK KD");

        [TestMethod]
        public void JokerFlush2() => TestHand(HandValue.Flush, "JK 6D 9D JK KD");

        [TestMethod]
        public void JokerFullHouse() => TestHand(HandValue.FullHouse, "2S 2H JK QH QS");

        [TestMethod]
        public void JokerFourOfAKind() => TestHand(HandValue.FourOfAKind, "2H JS JH JC JK");

        [TestMethod]
        public void JokerFourOfAKind2() => TestHand(HandValue.FourOfAKind, "2H JK JH JC JK");

        [TestMethod]
        public void JokerStraightFlush() => TestHand(HandValue.StraightFlush, "3S 4S JK 6S 7S");

        [TestMethod]
        public void JokerStraightFlush2() => TestHand(HandValue.StraightFlush, "JK 4S JK 6S 7S");

        [TestMethod]
        public void JokerRoyalFlush() => TestHand(HandValue.RoyalFlush, "AS JK QS JS TS");

        [TestMethod]
        public void JokerRoyalFlush2() => TestHand(HandValue.RoyalFlush, "AS JK JK JS TS");
    }
}
