using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public interface IDieFace
    {
        int Power { get; }
        IEnumerable<Direction> Directions { get; }
    }
}
