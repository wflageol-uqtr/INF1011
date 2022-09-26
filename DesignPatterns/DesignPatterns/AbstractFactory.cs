using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
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
            return new Loan(library, book, user);
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
            return new NoUserLoan(library, book);
        }
    }


    class Loan : ILoan
    {
        public Library Library { get; private set; }
        public Book LoanedBook { get; private set; }

        public User Loaner { get; private set; }

        public Loan(Library library, Book loanedBook, User loaner)
        {
            Library = library;
            LoanedBook = loanedBook;
            Loaner = loaner;

            AddLoanToLibrary();
            SetLoanToBook();
            AddLoanToUser();
        }

        public void Return()
        {
            RemoveLoanFromLibrary();
            UnsetLoanFromBook();
            RemoveLoanFromUser();
        }

        public virtual void AddLoanToLibrary()
        {
            Library.AddLoan(this);
        }
        public virtual void RemoveLoanFromLibrary()
        {
            Library.RemoveLoan(this);
        }

        public virtual void SetLoanToBook()
        {
            LoanedBook.CurrentLoan = this;
        }

        public virtual void UnsetLoanFromBook()
        {
            LoanedBook.CurrentLoan = null;
        }

        public virtual void AddLoanToUser()
        {
            Loaner.AddLoan(this);
        }

        public virtual void RemoveLoanFromUser()
        {
            Loaner.RemoveLoan(this);
        }
    }

    class NoUserLoan : Loan
    {
        public NoUserLoan(Library library, Book book) : base(library, book, null) { }

        public override void AddLoanToUser() { }
        public override void RemoveLoanFromUser() { }
    }


    class Library
    {
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


    class AbstractFactoryDemo
    {
        public void Demo()
        {
            // Préparation.
            Library library = new();
            Book book = new("9780131969452", "Design Patterns: Elements of Reusable Object-Oriented Software");
            User user = new("John Smith");

            // Utilisation du patron.
            ILoaner loaner1 = new UserLoaner(library, user);
            ILoaner loaner2 = new NoUserLoaner(library);

            // Emprunt d'un livre.
            ILoan loan1 = loaner1.Loan(book);
            ILoan loan2 = loaner2.Loan(book);

            // Retour d'un livre.
            loan1.Return();
            loan2.Return();
        }
    }
}
