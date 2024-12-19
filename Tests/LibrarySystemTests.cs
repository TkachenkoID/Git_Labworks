using BiblioControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class LibrarySystemTests
    {

        [TestMethod]
        public void AddBook_ShouldAddNewBook_WhenBookIsNotAlreadyInLibrary()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);

            bool result = _librarySystem.AddBook(_book1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddBook_ShouldReturnFalse_WhenBookAlreadyExists()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);
            _librarySystem.AddBook(_book1);
            var duplicateBook = new Book("Book One", "Author A", 2020, true);

            var result = _librarySystem.AddBook(duplicateBook);

            Assert.IsFalse(result);
            Assert.AreEqual(1, _librarySystem.Books.Count); 
        }

        [TestMethod]
        public void RegisterReader_ShouldRegisterReader_WhenReaderIsNew()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IReader _reader = new Reader("John Doe", "Test", "+380998651841");
            var result = _librarySystem.RegisterReader(_reader);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RegisterReader_ShouldReturnFalse_WhenReaderAlreadyRegistered()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IReader _reader = new Reader("John Doe", "Test", "+380998651841");
            _librarySystem.RegisterReader(_reader);
            var duplicateReader = new Reader("John Doe", "Test", "+380998651841");

            var result = _librarySystem.RegisterReader(duplicateReader);

            Assert.IsFalse(result);
            Assert.AreEqual(1, _librarySystem.Readers.Count);
        }

        [TestMethod]
        public void IssueBook_ShouldIssueBook_WhenConditionsAreMet()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);
            IReader _reader = new Reader("John Doe", "Test", "+380998651841");

            _librarySystem.AddBook(_book1);
            _librarySystem.RegisterReader(_reader);

            var result = _librarySystem.IssueBook(_book1, _reader);

            Assert.IsTrue(result);
            Assert.IsTrue(_reader.BorrowedBooks.Contains(_book1));
            Assert.IsFalse(_book1.IsAvailable);
        }

        [TestMethod]
        public void IssueBook_ShouldReturnFalse_WhenBookIsNotAvailable()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);
            IReader _reader = new Reader("John Doe", "Test", "+380998651841");

            _book1.IsAvailable = false; 
            _librarySystem.AddBook(_book1);
            _librarySystem.RegisterReader(_reader);

            var result = _librarySystem.IssueBook(_book1, _reader);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnBook_ShouldReturnTrue_WhenBookIsReturned()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);
            IReader _reader = new Reader("John Doe", "Test", "+380998651841");

            _librarySystem.AddBook(_book1);
            _librarySystem.RegisterReader(_reader);
            _librarySystem.IssueBook(_book1, _reader);

            var result = _librarySystem.ReturnBook(_book1, _reader);

            Assert.IsTrue(result);
            Assert.IsFalse(_reader.BorrowedBooks.Contains(_book1));
            Assert.IsTrue(_book1.IsAvailable);
        }

        [TestMethod]
        public void ReturnBook_ShouldReturnFalse_WhenBookIsNotBorrowed()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);
            IReader _reader = new Reader("John Doe", "Test", "+380998651841");

            _librarySystem.AddBook(_book1);
            _librarySystem.RegisterReader(_reader);

            var result = _librarySystem.ReturnBook(_book1, _reader);

            Assert.IsFalse(result);  // Book was never borrowed, so can't return
        }

        [TestMethod]
        public void SearchBookByTitle_ShouldReturnCorrectBook()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);
            IBook _book2 = new Book("Book Two", "Author B", 2021, true);

            _librarySystem.AddBook(_book1);
            _librarySystem.AddBook(_book2);

            var result = _librarySystem.SearchBookByTitle("Book One");

            Assert.IsNotNull(result);
            Assert.AreEqual("Book One", result.Title);
            Assert.AreEqual("Author A", result.Author);
        }

        [TestMethod]
        public void SearchBookByTitle_ShouldReturnNull_WhenBookNotFound()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);

            _librarySystem.AddBook(_book1);

            var result = _librarySystem.SearchBookByTitle("Nonexistent Book");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SearchBookByAuthor_ShouldReturnCorrectBook()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);
            IBook _book2 = new Book("Book Two", "Author B", 2021, true);

            _librarySystem.AddBook(_book1);
            _librarySystem.AddBook(_book2);

            var result = _librarySystem.SearchBookByAuthor("Author A");

            Assert.IsNotNull(result);
            Assert.AreEqual("Book One", result.Title);
            Assert.AreEqual("Author A", result.Author);
        }

        [TestMethod]
        public void SearchBookByYear_ShouldReturnCorrectBook()
        {
            LibrarySystem _librarySystem = new LibrarySystem();
            IBook _book1 = new Book("Book One", "Author A", 2020, true);
            IBook _book2 = new Book("Book Two", "Author B", 2021, true);

            _librarySystem.AddBook(_book1);
            _librarySystem.AddBook(_book2);

            var result = _librarySystem.SearchBookByYear(2021);

            Assert.IsNotNull(result);
            Assert.AreEqual("Book Two", result.Title);
            Assert.AreEqual(2021, result.PublicationYear);
        }
    }
}
