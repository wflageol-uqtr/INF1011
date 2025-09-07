using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    public class Basket
    {
        public Basket(IEnumerable<Book> books)
        {

        }

        public int HowMany(Book b)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int HowManyDifferent()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty() 
        {
            throw new NotImplementedException();
        }

        public Basket RemoveDifferent(int nbToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
