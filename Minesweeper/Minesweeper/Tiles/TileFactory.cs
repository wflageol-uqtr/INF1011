using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tiles
{
    public class TileFactory : ITileFactory
    {
        private int nbMines;

        public TileFactory(int nbMines) 
        { 
            this.nbMines = nbMines;
        }

        public ITile[] CreateRandomTiles(int nbTiles)
        {
            throw new NotImplementedException();
        }
    }
}
