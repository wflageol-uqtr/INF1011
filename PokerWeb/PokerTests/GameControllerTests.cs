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
    public class GameControllerTests
    {
        private GameController controller;

        [TestInitialize]
        public void Setup()
        {
            controller = new(new MockDeck(), ["John", "Jane"]);
        }

        [TestMethod]
        public void FullGameTest()
        {
            controller.DrawCard("John");
            controller.DrawCard("Jane");

            controller.ProgressGame();

            controller.Bet("John", 10);
            controller.Bet("Jane", 0);

            controller.ProgressGame();

            controller.ReplaceCards("John", "KS");
            controller.ReplaceCards("Jane", "8S 7S 4S");

            controller.ProgressGame();

            controller.Bet("John", 10);
            controller.Bet("Jane", 0);

            controller.ProgressGame();
        }
    }
}
