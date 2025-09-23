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

        public int HowMany(Book book) => books.Count(b => b.Equals(book));

        public int Count() => books.Count();

        private IEnumerable<Book> UniqueBooks() => books.Distinct();

        public int HowManyDifferent() => UniqueBooks().Count();

        public bool IsEmpty() => !books.Any();

        public Basket RemoveDifferent(int nbToRemove)
        {
            List<Book> newBooks = new(books);
            var toRemove = UniqueBooks()
                .OrderByDescending(HowMany)
                .Take(nbToRemove);

            foreach (var bookToRemove in toRemove)
                newBooks.Remove(bookToRemove);

            return new Basket(newBooks);
        }
    }
}
