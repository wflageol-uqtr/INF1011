using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    interface ILoanStrategy
    {
        void AddLoanToLibrary(Library library, Loan loan);
        void RemoveLoanFromLibrary(Library library, Loan loan);
        void SetLoanToBook(Book book, Loan loan);
        void UnsetLoanFromBook(Book book, Loan loan);
        void AddLoanToUser(User user, Loan loan);
        void RemoveLoanFromUser(User user, Loan loan);
    }

    class Loan : ILoan
    {
        private ILoanStrategy strategy;

        public Library Library { get; private set; }
        public Book LoanedBook { get; private set; }
        public User Loaner { get; private set; }

        public Loan(Library library, Book loanedBook, User loaner, ILoanStrategy strategy)
        {
            Library = library;
            LoanedBook = loanedBook;
            Loaner = loaner;

            strategy.AddLoanToLibrary(Library, this);
            strategy.SetLoanToBook(LoanedBook, this);
            strategy.AddLoanToUser(Loaner, this);
        }

        public void Return()
        {
            strategy.RemoveLoanFromLibrary(Library, this);
            strategy.UnsetLoanFromBook(LoanedBook, this);
            strategy.RemoveLoanFromUser(Loaner, this);
        }
    }

    class UserLoanStrategy : ILoanStrategy
    {
        public void AddLoanToLibrary(Library library, Loan loan)
        {
            library.AddLoan(loan);
        }

        public void AddLoanToUser(User user, Loan loan)
        {
            user.AddLoan(loan);
        }

        public void RemoveLoanFromLibrary(Library library, Loan loan)
        {
            library.RemoveLoan(loan);
        }

        public void RemoveLoanFromUser(User user, Loan loan)
        {
            user.RemoveLoan(loan);
        }

        public void SetLoanToBook(Book book, Loan loan)
        {
            book.CurrentLoan = loan;
        }

        public void UnsetLoanFromBook(Book book, Loan loan)
        {
            book.CurrentLoan = null;
        }
    }

    class NoUserLoanStrategy : ILoanStrategy
    {
        public void AddLoanToLibrary(Library library, Loan loan)
        {
            library.AddLoan(loan);
        }

        public void AddLoanToUser(User user, Loan loan) { }

        public void RemoveLoanFromLibrary(Library library, Loan loan)
        {
            library.RemoveLoan(loan);
        }

        public void RemoveLoanFromUser(User user, Loan loan) { }

        public void SetLoanToBook(Book book, Loan loan)
        {
            book.CurrentLoan = loan;
        }

        public void UnsetLoanFromBook(Book book, Loan loan)
        {
            book.CurrentLoan = null;
        }
    }

    interface ILoaner
    {
        ILoan Loan(Book book);
    }

    interface ILoan
    {
        void Return();
    }

    class UserLoaner : ILoaner
    {
        private Library library;
        private User user;

        public UserLoaner(Library library, User user)
        {
            this.library = library;
            this.user = user;
        }

        public ILoan Loan(Book book)
        {
            return new Loan(library, book, user, new UserLoanStrategy());
        }
    }

    class NoUserLoaner : ILoaner
    {
        private Library library;

        public NoUserLoaner(Library library)
        {
            this.library = library;
        }

        public ILoan Loan(Book book)
        {
            return new Loan(library, book, null, new NoUserLoanStrategy());
        }
    }

    class Library
    {
        public static Library Instance { get; } = new();
        private Library() { }

        private List<Book> books = new();
        private List<User> users = new();
        private List<Loan> loans = new();

        public IEnumerable<Book> Books => books;
        public IEnumerable<User> Users => users;
        public IEnumerable<Loan> Loans => loans;

        public void AddUser(User user) => users.Add(user);
        public void AddBook(Book book) => books.Add(book);

        public void AddLoan(Loan loan) => loans.Add(loan);
        public void RemoveLoan(Loan loan) => loans.Remove(loan);
    }

    class Book
    {
        public string Isbn { get; private set; }
        public string Name { get; private set; }

        public Loan CurrentLoan { get; set; }

        public Book(string isbn, string name)
        {
            Isbn = isbn;
            Name = name;
        }
    }

    class User
    {
        private List<Loan> loans = new();

        public string Name { get; private set; }
        public IEnumerable<Loan> CurrentLoans => loans;

        public User(string name)
        {
            Name = name;
        }

        public void AddLoan(Loan loan) => loans.Add(loan);
        public void RemoveLoan(Loan loan) => loans.Remove(loan);
    }


    class StrategyDemo
    {
        public void Demo()
        {
            // Préparation.
            Book book = new("9780131969452", "Design Patterns: Elements of Reusable Object-Oriented Software");
            User user = new("John Smith");

            // Utilisation du patron.
            ILoaner loaner1 = new UserLoaner(Library.Instance, user);
            ILoaner loaner2 = new NoUserLoaner(Library.Instance);

            // Emprunt d'un livre.
            ILoan loan1 = loaner1.Loan(book);
            ILoan loan2 = loaner2.Loan(book);

            // Retour d'un livre.
            loan1.Return();
            loan2.Return();
        }
    }
}
