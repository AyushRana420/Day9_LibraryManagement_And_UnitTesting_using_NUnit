using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LibraryManagement_And_Testing
{
    public class Borrower
    {
        //Define Properties: Name, LibraryCardNumber, BorrowedBooks (a list of books)
        public string Name { get; set; }
        public string LibraryCardNumber { get; set; }
        public List<Book> BorrowedBooks { get; private set; }
        
        //Constructor to initialize the properties
        public Borrower(string name, string libraryCardNumber)
        {
            Name = name;
            LibraryCardNumber = libraryCardNumber;
            BorrowedBooks = new List<Book>();
        }

        //Method to borrow a book
        public void BorrowBook(Book book)
        {
            book.Borrow();
            BorrowedBooks.Add(book);
        }

        //Method to return a book
        public void ReturnBook(Book book)
        {
            book.Return();
            BorrowedBooks.Remove(book);
        }
    }
}
