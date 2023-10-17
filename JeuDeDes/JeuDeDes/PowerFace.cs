using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public class PowerFace : IDieFace
    {
        private int power;

        public PowerFace(int power)
        {
            this.power = power;
        }

        public int Power => throw new NotImplementedException();

        public IEnumerable<Direction> Directions => throw new NotImplementedException();
    }
}
