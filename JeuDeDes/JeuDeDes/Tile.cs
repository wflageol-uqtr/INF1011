using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public enum TileType
    {
        Normal, Merchant, Bonus, GameEnd
    }

    public class Tile
    {
        public TileType TileType { get; set; }
    }
}
