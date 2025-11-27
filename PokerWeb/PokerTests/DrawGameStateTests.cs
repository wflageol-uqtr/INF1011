using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using Poker.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTests
{
    [TestClass]
    public class DrawGameStateTests
    {
        private DrawGameState state;

        private void AssertException<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T) { }
        }

        [TestInitialize]
        public void Setup()
        {
            state = new DrawGameState();
        }

        [TestMethod]
        public void TestBet()
        {
            AssertException<GameException>(() => state.Bet(0));
        }

        [TestMethod]
        public void TestReplaceCards()
        {
            AssertException<GameException>(() => state.ReplaceCards(Deck.Instance, []));
        }
    }
}
