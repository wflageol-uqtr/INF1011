using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.TemplateMethod
{
    class Loan
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


    class TemplateMethodDemo
    {
        public void Demo()
        {
            // Préparation.
            Library library = new();
            Book book = new("9780131969452", "Design Patterns: Elements of Reusable Object-Oriented Software");
            User user = new("John Smith");

            // Utilisation du patron.

            // Emprunt d'un livre.
            NoUserLoan loan = new(library, book);

            // Retour d'un livre.
            loan.Return();
        }
    }
}
