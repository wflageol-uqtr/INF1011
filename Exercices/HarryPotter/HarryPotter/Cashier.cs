using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    public class Cashier
    {
        private readonly IEnumerable<Discount> discounts;

        public Cashier(int basePrice, IEnumerable<Discount> discounts)
        {
            Book.Price = basePrice;
            this.discounts = discounts;
        }

        public double Compute(Basket b) 
        {
            if(b.IsEmpty()) { return 0; }

            var availables = AvailableDiscount(b);

            if (availables.Any())
                return availables.Select(d => Compute(b, d)).Min();
            else
                return Book.Price * b.Count();
        }

        public double Compute(Basket b, Discount d)
        {
            var discountedPrice = d.Apply(Book.Price);
            var remaining = d.RemovePaidBooks(b);
            return discountedPrice + Compute(remaining);
        }

        public IEnumerable<Discount> AvailableDiscount(Basket b)
            => discounts.Where(d => d.CanBeApplied(b));
    }
}
