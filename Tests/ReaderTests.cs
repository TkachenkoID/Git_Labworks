using BiblioControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            string name = "John Doe";
            string address = "123 Main St";
            string phoneNumber = "+380999123456";

            // Act
            var reader = new Reader(name, address, phoneNumber);

            // Assert
            Assert.AreEqual(name, reader.Name, "Name was not initialized correctly.");
            Assert.AreEqual(address, reader.Address, "Address was not initialized correctly.");
            Assert.AreEqual(phoneNumber, reader.PhoneNumber, "PhoneNumber was not initialized correctly.");
            Assert.IsNotNull(reader.BorrowedBooks, "BorrowedBooks should be initialized.");
            Assert.AreEqual(0, reader.BorrowedBooks.Count, "BorrowedBooks should be empty.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PhoneNumber_SetInvalidFormat_ShouldThrowException()
        {
            // Arrange
            var reader = new Reader("John Doe", "123 Main St", "+380999123456");

            // Act
            reader.PhoneNumber = "InvalidPhoneNumber";
        }

        [TestMethod]
        public void BorrowBook_ShouldAddBookToBorrowedBooks()
        {
            // Arrange
            var reader = new Reader("John Doe", "123 Main St", "+380999123456");
            var book = new Book("Test Book", "Test Author", 2020, true);

            // Act
            bool result = reader.BorrowBook(book);

            // Assert
            Assert.IsTrue(result, "BorrowBook should return true for available books.");
            Assert.AreEqual(1, reader.BorrowedBooks.Count, "BorrowedBooks should contain one book.");
            Assert.AreSame(book, reader.BorrowedBooks[0], "Borrowed book should match the input book.");
            Assert.IsFalse(book.IsAvailable, "Book should be marked as unavailable.");
        }

        [TestMethod]
        public void BorrowBook_ShouldFailForUnavailableBook()
        {
            // Arrange
            var reader = new Reader("John Doe", "123 Main St", "+380999123456");
            var book = new Book("Test Book", "Test Author", 2020, false);

            // Act
            bool result = reader.BorrowBook(book);

            // Assert
            Assert.IsFalse(result, "BorrowBook should return false for unavailable books.");
            Assert.AreEqual(0, reader.BorrowedBooks.Count, "BorrowedBooks should remain empty.");
        }

        [TestMethod]
        public void ReturnBook_ShouldRemoveBookFromBorrowedBooks()
        {
            // Arrange
            var reader = new Reader("John Doe", "123 Main St", "+380999123456");
            var book = new Book("Test Book", "Test Author", 2020, true);
            reader.BorrowBook(book);

            // Act
            bool result = reader.ReturnBook(book);

            // Assert
            Assert.IsTrue(result, "ReturnBook should return true for books in BorrowedBooks.");
            Assert.AreEqual(0, reader.BorrowedBooks.Count, "BorrowedBooks should be empty after returning a book.");
            Assert.IsTrue(book.IsAvailable, "Book should be marked as available.");
        }

        [TestMethod]
        public void ReturnBook_ShouldFailForNonBorrowedBook()
        {
            // Arrange
            var reader = new Reader("John Doe", "123 Main St", "+380999123456");
            var book = new Book("Test Book", "Test Author", 2020, true);

            // Act
            bool result = reader.ReturnBook(book);

            // Assert
            Assert.IsFalse(result, "ReturnBook should return false for books not in BorrowedBooks.");
            Assert.AreEqual(0, reader.BorrowedBooks.Count, "BorrowedBooks should remain empty.");
        }
    }
}
