using Minesweeper;
using Minesweeper.Tiles;

namespace MinesweeperTests
{
    [TestClass]
    public sealed class BoardTests
    {
        [TestMethod]
        public void TestConstructorMinesOnly()
        {
            // Arrange
            int height = 3;
            int width = 4;
            ITileFactory tileFactory = new MineFactory();

            // Act
            Board board = new Board(height, width, tileFactory);

            // Assert
            for (int y = 0; y < width; y++)
                for (int x = 0; x < height; x++)
                    Assert.IsInstanceOfType<MineTile>(board.Tiles[x, y]);
        }

        [TestMethod]
        public void TestConstructorOneMine1()
        {
            // Arrange
            int height = 3;
            int width = 4;
            ITileFactory tileFactory = new OneMineFactory(1);

            // Act
            Board board = new Board(height, width, tileFactory);

            // Assert
            Assert.IsInstanceOfType<MineTile>(board.Tiles[0, 1]);
        }

        [TestMethod]
        public void TestConstructorOneMine2()
        {
            // Arrange
            int height = 3;
            int width = 4;
            ITileFactory tileFactory = new OneMineFactory(7);

            // Act
            Board board = new Board(height, width, tileFactory);

            // Assert
            Assert.IsInstanceOfType<MineTile>(board.Tiles[1, 3]);
        }
    }
}
