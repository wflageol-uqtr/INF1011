using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tiles
{
    public class ValueTile : Tile
    {
        public TileValue Value { get; }

        public ValueTile(TileValue value)
        {
            Value = value;
        }

    }
}
