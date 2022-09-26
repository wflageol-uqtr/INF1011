using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
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

    // La façade.
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

            Library.AddLoan(this);
            LoanedBook.CurrentLoan = this;
            Loaner.AddLoan(this);
        }

        public void Return()
        {
            Library.RemoveLoan(this);
            LoanedBook.CurrentLoan = null;
            Loaner.RemoveLoan(this);
        }
    }

    public class FacadeDemo
    {
        public void Demo()
        {
            // Préparation.
            Library library = new();
            Book book = new("9780131969452", "Design Patterns: Elements of Reusable Object-Oriented Software");
            User user = new("John Smith");

            // Utilisation du patron.

            // Emprunt d'un livre.
            Loan loan = new(library, book, user);

            // Retour d'un livre.
            loan.Return();
        }
    }
}
