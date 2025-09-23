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

        void TestHand(Hand expected, string hand) 
            => Assert.AreEqual(expected, analyzer.AnalyzeHand(hand.Split(" ")));

        [TestMethod]
        public void HighCard() => TestHand(Hand.HighCard, "AS 7D 9S JH KC");

        [TestMethod]
        public void Pair() => TestHand(Hand.Pair, "3S 6C JH JS QD");

        [TestMethod]
        public void TwoPair() => TestHand(Hand.TwoPair, "QS 8D 8H QC JS");

        [TestMethod]
        public void ThreeOfAKind() => TestHand(Hand.ThreeOfAKind, "7S 7D 7H QC JS");

        [TestMethod]
        public void Straight() => TestHand(Hand.Straight, "AS 3D 2S 5H 4C");

        [TestMethod]
        public void Flush() => TestHand(Hand.Flush, "3D JD 9D QD KD");

        [TestMethod]
        public void FullHouse() => TestHand(Hand.FullHouse, "AS TH TC AH TS");

        [TestMethod]
        public void FourOfAKind() => TestHand(Hand.FourOfAKind, "QH QS 2H QC QD");

        [TestMethod]
        public void StraightFlush() => TestHand(Hand.StraightFlush, "2S 4S 3S 5S 6S");

        [TestMethod]
        public void RoyalFlush() => TestHand(Hand.RoyalFlush, "AC KC QC JC TC");

        [TestMethod]
        public void JokerPair() => TestHand(Hand.Pair, "3S 6C 7S KH JK");

        [TestMethod]
        public void JokerThreeOfAKind() => TestHand(Hand.ThreeOfAKind, "4H 2S AH JK AD");

        [TestMethod]
        public void JokerThreeOfAKind2() => TestHand(Hand.ThreeOfAKind, "6H 2S AH JK JK");

        [TestMethod]
        public void JokerStraight() => TestHand(Hand.Straight, "3S 4D JK 6H 7C");

        [TestMethod]
        public void JokerStraight2() => TestHand(Hand.Straight, "4H 2S AH JK JK");

        [TestMethod]
        public void JokerFlush() => TestHand(Hand.Flush, "3D 6D 9D JK KD");

        [TestMethod]
        public void JokerFlush2() => TestHand(Hand.Flush, "JK 6D 9D JK KD");

        [TestMethod]
        public void JokerFullHouse() => TestHand(Hand.FullHouse, "2S 2H JK QH QS");

        [TestMethod]
        public void JokerFourOfAKind() => TestHand(Hand.FourOfAKind, "2H JS JH JC JK");

        [TestMethod]
        public void JokerFourOfAKind2() => TestHand(Hand.FourOfAKind, "2H JK JH JC JK");

        [TestMethod]
        public void JokerStraightFlush() => TestHand(Hand.StraightFlush, "3S 4S JK 6S 7S");

        [TestMethod]
        public void JokerStraightFlush2() => TestHand(Hand.StraightFlush, "JK 4S JK 6S 7S");

        [TestMethod]
        public void JokerRoyalFlush() => TestHand(Hand.RoyalFlush, "AS JK QS JS TS");

        [TestMethod]
        public void JokerRoyalFlush2() => TestHand(Hand.RoyalFlush, "AS JK JK JS TS");
    }
}
