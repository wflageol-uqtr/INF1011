using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public class Die
    {
        private IRandomNumberGenerator rng;

        public IEnumerable<IDieFace> Faces { get; set; }

        public Die(IRandomNumberGenerator rng)
        {
            this.rng = rng;
        }

        public IDieFace Roll()
        {
            throw new NotImplementedException();
        }

        public void ChangeFace(IDieFace oldFace, IDieFace newFace)
        {

        }
    }
}
