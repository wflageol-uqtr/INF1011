using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void TestBuild()
        {
            // Arrange

            // Act
            var deck = Deck.CreateFullDeck();

            // Assert
            Assert.AreEqual(52, deck.Count());
        }
    }
}
