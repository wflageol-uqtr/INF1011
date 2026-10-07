using Minesweeper.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperTests
{
    internal class OneMineFactory : ITileFactory
    {
        private int minePosition;

        public OneMineFactory(int minePosition)
        {
            this.minePosition = minePosition;
        }

        public ITile[] CreateRandomTiles(int nbTiles)
        {
            var tiles = new List<ITile>();
            for (int i = 0; i < nbTiles; i++)
            {
                if (i == minePosition)
                    tiles.Add(new MineTile());
                else
                    tiles.Add(new ValueTile(TileValue.None));
            }

            return tiles.ToArray();
        }
    }
}
