using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsUnitaires;

namespace TestUnitairesTests
{
    class DiscountMock : IDiscount
    {
        public double Ratio { get; set; }
    }
}
