using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    public class Basket
    {
        private IEnumerable<Book> books;

        public Basket(IEnumerable<Book> books)
        {
            this.books = books;
        }

        public int HowMany(Book book)
        {
            //int n = 0;
            //foreach(Book b in books)
            //{
            //    if (b.Equals(book))
            //        n++;
            //}

            //return n;

            return books.Count(b => b.Equals(book));
        }

        public int Count() => books.Count();

        private IEnumerable<Book> UniqueBooks() 
        {
            return new HashSet<Book>(books);

            // return books.Distinct();
        }
        public int HowManyDifferent() => UniqueBooks().Count();

        public bool IsEmpty() => !books.Any();

        public Basket RemoveDifferent(int nbToRemove)
        {
            IEnumerable<Book> toRemove = 
                UniqueBooks()
                .OrderByDescending(HowMany)
                .Take(nbToRemove);
            List<Book> newBooks = books.ToList();

            foreach (Book b in toRemove)
                newBooks.Remove(b);

            return new Basket(newBooks);
        }
    }
}
