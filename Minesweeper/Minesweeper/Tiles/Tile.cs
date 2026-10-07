using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tiles
{
    public abstract class Tile : ITile
    {
        private bool isRevealed;
        private bool isFlagged;
    }
}
