using JeuDeDes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDesTests
{
    class RandomNumberMock : IRandomNumberGenerator
    {
        public int Value { get; set; }

        public int Roll(int max)
        {
            return Value;
        }
    }
}
