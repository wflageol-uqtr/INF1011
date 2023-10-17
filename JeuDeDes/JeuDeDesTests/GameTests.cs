using JeuDeDes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace JeuDeDesTests
{
    [TestClass]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Setup()
        {
            game = new Game();
        }

        [TestMethod]
        public void InitializeTilesCountTest()
        {
            // Arrange
            // Act
            game.Initialize();

            // Assert
            Assert.AreEqual(2500, game.Board.Tiles.Count());
            Assert.AreEqual(15, game.Board.Tiles.Where(t => t.TileType == TileType.Merchant));
            Assert.AreEqual(15, game.Board.Tiles.Where(t => t.TileType == TileType.Bonus));
            Assert.AreEqual(1, game.Board.Tiles.Where(t => t.TileType == TileType.GameEnd));
        }

        [TestMethod]
        public void InitializeBoardRandomTest()
        {
            // Arrange & Act
            game.Initialize();
            var board1 = game.Board;
            game.Initialize();
            var board2 = game.Board;

            // Assert
            CollectionAssert.AreEquivalent(board1.Tiles.ToList(), board2.Tiles.ToList());
        }

        [TestMethod]
        public void TestCreateDie()
        {
            // Arrange & Act
            var die = game.CreateDie(4);

            // Assert
            Assert.AreEqual(4, die.Faces.Count());
            foreach(var face in die.Faces)
            {
                Assert.AreEqual(1, face.Power);
                Assert.IsTrue(!face.Directions.Any());
            }
        }
    }
}
