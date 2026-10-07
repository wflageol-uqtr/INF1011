using Minesweeper.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperTests
{
    [TestClass]
    public class TileFactoryTests
    {
        [TestMethod]
        public void TestCreateRandomMines3()
        {
            // Arrange
            int nbMines = 3;
            TileFactory tileFactory = new(10);

            // Act
            var tiles = tileFactory.CreateRandomTiles(3);

            // Arrange
            Assert.AreEqual(3, tiles.Where(tile => tile is MineTile).Count());
        }
    }
}
