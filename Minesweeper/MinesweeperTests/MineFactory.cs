using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tiles
{
    public class MineFactory : ITileFactory
    {
        public ITile[] CreateRandomTiles(int nbTiles)
        {
            var tiles = new List<ITile>();
            for (int i = 0; i < nbTiles; i++)
            {
                tiles.Add(new MineTile());
            }

            return tiles.ToArray();
        }
    }
}
