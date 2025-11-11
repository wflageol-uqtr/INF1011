using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronsBibliotheque.Strategy_Factory
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
        public ILoan? CurrentLoan { get; set; }

        public Book(string isbn, string name)
        {
            Isbn = isbn;
            Name = name;
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

    interface ILoanStrategy
    {
        ILoan LoanBook(Book book);
    }

    class NoUserLoanStrategy : ILoanStrategy
    {
        private Library library;

        public NoUserLoanStrategy(Library library)
        {
            this.library = library;
        }

        public ILoan LoanBook(Book book)
        {
            if (book.CurrentLoan != null)
                throw new ArgumentException("Le livre est déjà emprunté.");

            NoUserLoan loan = new(book);
            book.CurrentLoan = loan;

            library.AddLoan(loan);

            return loan;
        }
    }

    class LoanStrategy : ILoanStrategy
    {
        private Library library;
        private User loanee;

        public LoanStrategy(Library library, User loanee)
        {
            this.library = library;
            this.loanee = loanee;
        }

        public ILoan LoanBook(Book book)
        {
            if (book.CurrentLoan != null)
                throw new ArgumentException("Le livre est déjà emprunté.");

            Loan loan = new(book, loanee);
            book.CurrentLoan = loan;

            library.AddLoan(loan);

            return loan;
        }
    }

    class Demo
    {
        public static void Run()
        {
            Library library = new();
            Book book = new("12345", "Lord of the Rings");
            User user = new User("John Smith");

            library.AddBook(book);
            library.AddUser(user);

            ILoanStrategy loanStrategy = new LoanStrategy(library, user);

            var loan = loanStrategy.LoanBook(book);

            ILoanStrategy noUserStrategy = new NoUserLoanStrategy(library);

            noUserStrategy.LoanBook(book);
        }
    }
}
