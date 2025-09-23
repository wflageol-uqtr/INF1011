using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    public class Discount
    {
        private int nbBooks;
        private double priceRatio;

        public Discount(int nb, double priceRatio)
        {
            nbBooks = nb;
            this.priceRatio = priceRatio;
        }

        public bool CanBeApplied(Basket b) => b.HowManyDifferent() >= nbBooks;

        public double Apply(double basePrice) => nbBooks * basePrice * priceRatio;

        public Basket RemovePaidBooks(Basket b) => b.RemoveDifferent(nbBooks);
    }
}
