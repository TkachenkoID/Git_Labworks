using System;
using System.Collections.Generic;
using System.Linq;

namespace BiblioControl
{
    public class LibrarySystem : ILibrarySystem
    {
        public List<IBook> Books { get; set; }
        public List<IReader> Readers { get; set; }

        public LibrarySystem()
        {
            Books = new List<IBook>();
            Readers = new List<IReader>();
        }

        // Method for adding a new book to the library collection
        public bool AddBook(IBook book)
        {
            if (Books.Any(b => b.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase) && b.Author.Equals(book.Author, StringComparison.OrdinalIgnoreCase)))
            {
                return false; 
            }

            Books.Add(book);
            return true;
        }

        // Method for registering a new reader
        public bool RegisterReader(IReader reader)
        {
            if (Readers.Any(r => r.PhoneNumber.Equals(reader.PhoneNumber)))
            {
                return false;
            }

            Readers.Add(reader);
            return true;
        }

        public bool ReturnBook(IBook book, IReader reader)
        {
            if (book != null && reader != null && reader.BorrowedBooks.Contains(book))
            {
                return reader.ReturnBook(book);
            }

            return false;  
        }

        public bool IssueBook(IBook book, IReader reader)
        {
            if (book != null && reader != null && Books.Contains(book) && book.IsAvailable)
            {
                return reader.BorrowBook(book);
            }

            return false; 
        }

        public IBook SearchBookByTitle(string title)
        {
            return Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public IBook SearchBookByAuthor(string author)
        {
            return Books.FirstOrDefault(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }

        public IBook SearchBookByYear(int year)
        {
            return Books.FirstOrDefault(b => b.PublicationYear == year);
        }
    }
}
