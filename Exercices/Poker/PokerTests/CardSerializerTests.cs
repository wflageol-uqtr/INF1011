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
    public class CardSerializerTests
    {
        private CardSerializer cardSerializer;

        [TestInitialize]
        public void Setup()
        {
            cardSerializer = new();
        }

        [TestMethod]
        public void TestDeserializeBase()
        {
            // Arrange
            var scard = "5H";

            // Act
            var card = cardSerializer.Deserialize(scard);

            // Assert
            Assert.AreEqual(new Card(CardSuit.Heart, CardValue.Five), card);
        }
    }
}
