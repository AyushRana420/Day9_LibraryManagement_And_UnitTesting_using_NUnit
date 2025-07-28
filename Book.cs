using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LibraryManagement_And_Testing
{
    public class Book
    {
        //Properties: Title, Author, ISBN, IsBorrowed
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; private set; }

        //Constructor to initialize the properties
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false; // Initially, the book is not borrowed
        }

        //Craeting method Borrow to borrow a book and throw exception if the book is already borrowed
        public void Borrow()
        {
            if (IsBorrowed)
            {
                throw new InvalidOperationException("This book is already borrowed.");
            }
            IsBorrowed = true;
        }

        //Creating method Return to return a book and throw exception if the book is not borrowed
        public void Return()
        {
            if (!IsBorrowed)
            {
                throw new InvalidOperationException("This book was not borrowed.");
            }
            IsBorrowed = false;
        }

    }
}
