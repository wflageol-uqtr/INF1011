using Minesweeper.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Board
    {
        public ITile[,] Tiles { get; }

        public Board(int height, int width, ITileFactory tileFactory)
        {
            var randomTiles = tileFactory.CreateRandomTiles(height * width);
            Tiles = new ITile[height, width];
            for (int y = 0; y < width; y++)
                for (int x = 0; x < height; x++)
                {
                    Tiles[x, y] = randomTiles[y + x * width];
                }
        }
    }
}
