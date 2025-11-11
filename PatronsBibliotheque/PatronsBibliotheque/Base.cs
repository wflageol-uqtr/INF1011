using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronsBibliotheque
{
    class Library
    {
        private List<Book> books = new();
        private List<User> users = new();
        private List<ILoan> loans = new();

        public void AddBook(Book book) => books.Add(book);
        public void AddUser(User user) => users.Add(user);
        public void AddLoan(ILoan loan) => loans.Add(loan);
    }

    class Book
    {
        public string Isbn { get; }
        public string Name { get; }
        public Loan? CurrentLoan { get; private set; }

        public Book(string isbn, string name)
        {
            Isbn = isbn;
            Name = name;
        }

        public Loan Loan(User user)
        {
            if (CurrentLoan != null)
                throw new ArgumentException("Le livre est déjà emprunté.");

            Loan loan = new(this, user);
            CurrentLoan = loan;
            return loan;
        }
    }

    class User
    {
        public string Name { get; }
        
        public User(string name)
        {
            Name = name;
        }
    }

    interface ILoan
    {

    }

    class Loan : ILoan
    {
        private Book LoanedBook { get; }
        private User Loanee { get; }

        public Loan(Book loanedBook, User loanee)
        {
            LoanedBook = loanedBook;
            Loanee = loanee;
        }
    }

    class NoUserLoan : ILoan
    {
        private Book LoanedBook { get; }

        public NoUserLoan(Book loanedBook)
        {
            LoanedBook = loanedBook;
        }
    }

    class Demo
    {
        public void Run()
        {
            Library library = new();
            Book book = new("12345", "Lord of the Rings");
            User user = new User("John Smith");

            var loan = book.Loan(user);

            library.AddBook(book);
            library.AddUser(user);
            library.AddLoan(loan);
        }
    }
}
