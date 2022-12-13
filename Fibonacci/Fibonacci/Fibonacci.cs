using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class FibonacciCalculator
    {
        public Decimal Value(int n)
        {
            if (n == 0)
                return 1;
            else if (n == 1)
                return 1;
            else if (n < 0)
                throw new ArgumentException();
            else
                return Value(n - 1) + Value(n - 2);
        }
    }
}
