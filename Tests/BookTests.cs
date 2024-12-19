using BiblioControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Book_Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            string title = "Test Book";
            string author = "Test Author";
            int publicationYear = 2020;
            bool isAvailable = true;

            // Act
            var book = new Book(title, author, publicationYear, isAvailable);

            // Assert
            Assert.AreEqual(title, book.Title, "Title was not initialized correctly.");
            Assert.AreEqual(author, book.Author, "Author was not initialized correctly.");
            Assert.AreEqual(publicationYear, book.PublicationYear, "PublicationYear was not initialized correctly.");
            Assert.AreEqual(isAvailable, book.IsAvailable, "IsAvailable was not initialized correctly.");
        }

        [TestMethod]
        public void PublicationYear_SetValidValue_Success()
        {
            // Arrange
            var book = new Book("Title", "Author", 2020, true);

            // Act
            book.PublicationYear = 1999;

            // Assert
            Assert.AreEqual(1999, book.PublicationYear, "PublicationYear setter did not set the correct value.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PublicationYear_SetInvalidValue_ShouldThrowArgumentException()
        {
            // Arrange
            var book = new Book("Title", "Author", 2000, true);

            // Act
            book.PublicationYear = 12345; // Invalid year
        }

        [TestMethod]
        public void Title_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            var book = new Book("Old Title", "Author", 2000, true);

            // Act
            book.Title = "New Title";

            // Assert
            Assert.AreEqual("New Title", book.Title);
        }

        [TestMethod]
        public void Author_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            var book = new Book("Title", "Old Author", 2000, true);

            // Act
            book.Author = "New Author";

            // Assert
            Assert.AreEqual("New Author", book.Author);
        }

        [TestMethod]
        public void IsAvailable_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            var book = new Book("Title", "Author", 2000, true);

            // Act
            book.IsAvailable = false;

            // Assert
            Assert.IsFalse(book.IsAvailable);
        }

    }
}
