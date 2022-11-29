using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class Article
    {
        public double? Price { get; set; }
        public IDiscount Discount { get; set; }
        public ILogger Logger { get; set; } = new NoLogger();

        public double CalculatePrice()
        {
            if (Price == null)
            {
                Logger.WriteLine("Price was null!");
                throw new InvalidOperationException();
            }

            return Price.Value * (Discount?.Ratio ?? 1);
        }
    }
}
