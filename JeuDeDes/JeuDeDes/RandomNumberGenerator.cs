using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDes
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random rand = new Random();

        public int Roll(int max)
        {
            return rand.Next(max);
        }
    }
}
