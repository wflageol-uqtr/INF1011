using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public enum Direction
    {
        North, South, East, West
    }

    public class DirectionFace : IDieFace
    {
        public int Power => throw new NotImplementedException();

        public IEnumerable<Direction> Directions => throw new NotImplementedException();
    }
}
