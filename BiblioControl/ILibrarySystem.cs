using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioControl
{
    public interface ILibrarySystem
    {
        // Property for adding a new book to the library collection
        void AddBook(IBook book);

        // Property for registering a new reader
        void RegisterReader(IReader reader);

        // Property for issuing a book to a reader
        void IssueBook(IBook book, IReader reader);

        // Property for returning a book from a reader
        void ReturnBook(IBook book, IReader reader);

        // Property for searching for a book by its title
        IBook SearchBookByTitle(string title);

        // Property for searching for a book by its author
        IBook SearchBookByAuthor(string author);

        // Property for searching for a book by its publication year
        IBook SearchBookByYear(int year);
    }
}
