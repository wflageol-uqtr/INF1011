using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronsBibliotheque.Single_Observer_Decorator
{
    class Library
    {
        public static Library Singleton { get; } = new();

        private Library() { }

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

        public ILoan LoanBook(ILoanStrategy strategy, IBook book)
        {
            ILoan loan = strategy.LoanBook(book);
            loans.Add(loan);
            return loan;
        }
    }

    interface IBook : IComparable<IBook>
    {
        string Isbn { get; }
        string Name { get; }
        ILoan? CurrentLoan { get; set; }
    }

    class Book : IBook
    {
        public string Isbn { get; }
        public string Name { get; }
        public ILoan? CurrentLoan { get; set; }

        public Book(string isbn, string name)
        {
            Isbn = isbn;
            Name = name;
        }

        public int CompareTo(IBook? other)
            => Isbn.CompareTo(other?.Isbn);
    }

    class ObservableBookDecorator : IBook
    {
        private IBook book;
        private List<Action<IBook>> bookObservers = new();

        public ObservableBookDecorator(IBook book)
        {
            this.book = book;
        }

        public string Isbn => book.Isbn;

        public string Name => book.Name;

        public ILoan? CurrentLoan 
        {
            get => book.CurrentLoan; 
            set 
            {
                book.CurrentLoan = value;
                NotifyOnLoan();
            }
        }

        public void AddObserver(Action<IBook> observer)
            => bookObservers.Add(observer);

        public int CompareTo(IBook? other) => book.CompareTo(other);

        private void NotifyOnLoan()
        {
            foreach (var observer in bookObservers)
                observer(this);
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
        private IBook LoanedBook { get; }
        private User Loanee { get; }

        public Loan(IBook loanedBook, User loanee)
        {
            LoanedBook = loanedBook;
            Loanee = loanee;
        }
    }

    class NoUserLoan : ILoan
    {
        private IBook LoanedBook { get; }

        public NoUserLoan(IBook loanedBook)
        {
            LoanedBook = loanedBook;
        }
    }

    interface ILoanStrategy
    {
        ILoan LoanBook(IBook book);
    }

    abstract class LoanStrategy : ILoanStrategy
    {
        public ILoan LoanBook(IBook book)
        {
            if (book.CurrentLoan != null)
                throw new ArgumentException("Le livre est déjà emprunté.");

            ILoan loan = CreateLoan(book);
            book.CurrentLoan = loan;

            return loan;
        }

        public abstract ILoan CreateLoan(IBook book);
    }

    class NoUserLoanStrategy : LoanStrategy
    {
        public override ILoan CreateLoan(IBook book) 
            => new NoUserLoan(book);
    }

    class UserLoanStrategy : LoanStrategy
    {
        private User loanee;

        public UserLoanStrategy(User loanee)
        {
            this.loanee = loanee;
        }

        public override ILoan CreateLoan(IBook book)
            => new Loan(book, loanee);
    }

    class Demo
    {
        public static void Run()
        {
            var library = Library.Singleton;
            Book book = library.CreateBook("12345", "Lord of the Rings");
            User user = library.CreateUser("John Smith");

            var observableBook = new ObservableBookDecorator(book);
            observableBook.AddObserver(book => Console.WriteLine($"{book.Name} emprunté!"));

            library.LoanBook(new UserLoanStrategy(user), observableBook);
            //library.LoanBook(new NoUserLoanStrategy(), book);
        }
    }
}
