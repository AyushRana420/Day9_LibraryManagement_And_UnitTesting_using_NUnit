using NUnit.Framework;
using Demo_LibraryManagement_And_Testing;

namespace LibraryManagement_Testing
{
    public class LibraryTests
    {
        //Creating a Library object to test the methods
        private Library library;
        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        //Testing Adding a Book:
        public void TestAddBook()
        {
            // Arrange
            var book = new Book("Kafka on the Shore", "Haruki Murakami", "1234567890");
            // Act
            library.AddBook(book);
            // Assert
            Assert.That(library.ViewBooks().Count, Is.EqualTo(1));
            Assert.That(library.Books[0].Title, Is.EqualTo("Kafka on the Shore"));
        }
        [Test]
        //Testing Registering a Borrower:
        public void TestRegisterBorrower()
        {
            // Arrange
            var borrower = new Borrower("Ayush", "12345");
            // Act
            library.RegisterBorrower(borrower);
            //Assert
            Assert.Contains(borrower, library.ViewBorrowers());
        }

        [Test]
        //Testing Borrowing a Book:
        public void TestBorrowBook()
        {
            // Arrange
            var book = new Book("Paper Towns", "Jhon Green", "1234567890");
            library.AddBook(book);
            var borrower = new Borrower("Test Borrower", "12345");
            library.RegisterBorrower(borrower);
            // Act
            borrower.BorrowBook(book);
            // Assert
            Assert.IsTrue(book.IsBorrowed);
            Assert.Contains(book, borrower.BorrowedBooks);
        }

        [Test]
        //Testing Returning a Book:
        public void TestReturnBook()
        {
            // Arrange
            var book = new Book("IKIGAI", "Hector Garcia", "1234567890");
            library.AddBook(book);
            var borrower = new Borrower("Ayush", "12345");
            library.RegisterBorrower(borrower);
            borrower.BorrowBook(book);
            // Act
            borrower.ReturnBook(book);
            // Assert
            Assert.IsFalse(book.IsBorrowed);
            Assert.IsFalse(borrower.BorrowedBooks.Contains(book));
        }
        [Test]
        //Viewing Books:
        public void TestViewBooks()
        {
            library.AddBook(new Book("Kafka on the Shore", "Haruki Murakami", "1234567890"));
            library.AddBook(new Book("1984", "George Orwell", "0987654321"));
            var books = library.ViewBooks();
            Assert.That(books.Count, Is.EqualTo(2));
            Assert.That(books[0].Title, Is.EqualTo("Kafka on the Shore"));
            Assert.That(books[1].Title, Is.EqualTo("1984"));
        }

        [Test]
        //Viewing Books and Borrowers:
        public void TestViewBorrower()
        {
            library.RegisterBorrower(new Borrower("Ayush", "12345"));
            library.RegisterBorrower(new Borrower("Nandani", "67890"));
            var borrowers = library.ViewBorrowers();
            Assert.That(borrowers.Count, Is.EqualTo(2));
        }
    }
}