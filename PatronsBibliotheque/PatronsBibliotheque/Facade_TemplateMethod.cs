using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronsBibliotheque.Facade_TemplateMethod
{
    class Library
    {
        private List<Book> books = new();
        private List<User> users = new();
        private List<ILoan> loans = new();

        public Book CreateBook(string isbn, string name)
        {
            Book book = new(isbn, name);
            books.Add(book);
            return book;
        }

        public User CreateUser(string name)
        {
            User user = new(name);
            users.Add(user);
            return user;
        }

        public ILoan LoanBook(ILoanStrategy strategy, Book book)
        {
            ILoan loan = strategy.LoanBook(book);
            loans.Add(loan);
            return loan;
        }
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

    abstract class LoanStrategy : ILoanStrategy
    {
        public ILoan LoanBook(Book book)
        {
            if (book.CurrentLoan != null)
                throw new ArgumentException("Le livre est déjà emprunté.");

            ILoan loan = CreateLoan(book);
            book.CurrentLoan = loan;

            return loan;
        }

        public abstract ILoan CreateLoan(Book book);
    }

    class NoUserLoanStrategy : LoanStrategy
    {
        public override ILoan CreateLoan(Book book) 
            => new NoUserLoan(book);
    }

    class UserLoanStrategy : LoanStrategy
    {
        private User loanee;

        public UserLoanStrategy(User loanee)
        {
            this.loanee = loanee;
        }

        public override ILoan CreateLoan(Book book)
            => new Loan(book, loanee);
    }

    class Demo
    {
        public static void Run()
        {
            Library library = new();
            Book book = library.CreateBook("12345", "Lord of the Rings");
            User user = library.CreateUser("John Smith");

            library.LoanBook(new UserLoanStrategy(user), book);
            library.LoanBook(new NoUserLoanStrategy(), book);
        }
    }
}
