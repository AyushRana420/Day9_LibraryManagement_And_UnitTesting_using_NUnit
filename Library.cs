using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LibraryManagement_And_Testing
{
    public class Library
    {
        //Properties: Books (a list of books), Borrowers (a list of borrowers)
        public List<Book> Books { get; private set; } = new List<Book>();
        public List<Borrower> Borrowers { get; private set; } = new List<Borrower>();
        //Method to add a book to the library
        public void AddBook(Book book)
        {
           Books.Add(book);
        }

        //Method to register a borrower
        public void RegisterBorrower(Borrower borrower)
        {
            Borrowers.Add(borrower);
        }

        //Method to borrow a book using isbn and library card number
        public void BorrowBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                throw new InvalidOperationException("Book not found.");
            }
            if (book.IsBorrowed)
            {
                throw new InvalidOperationException("This book is already borrowed.");
            }
            book.Borrow();
        }

        //Method to return a book
        public void ReturnBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                throw new InvalidOperationException("Book not found.");
            }
            if (!book.IsBorrowed)
            {
                throw new InvalidOperationException("This book was not borrowed.");
            }
            book.Return();
        }

        //Method to ViewBooks
        public List<Book> ViewBooks()
        {
            return Books;
        }

        //Method to ViewBorrowers
        public List<Borrower> ViewBorrowers()
        {
            return Borrowers;
        }
    }
}
