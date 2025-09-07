using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    public class Discount
    {
        public Discount(int nb, double price)
        {

        }

        public bool CanBeApplied(Basket b)
        {
            throw new NotImplementedException();
        }

        public double Apply(double basePrice)
        {
            throw new NotImplementedException();
        }

        public Basket RemovePaidBooks(Basket b)
        {
            throw new NotImplementedException();
        }
    }
}
