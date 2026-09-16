using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    public class Book
    {
        public static double Price { get; set; }

        private readonly int bookNb;

        public Book(int nb)
        {
            bookNb = nb;
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   bookNb == book.bookNb;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(bookNb);
        }
    }
}
