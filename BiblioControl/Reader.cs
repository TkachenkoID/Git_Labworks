using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BiblioControl
{
    public class Reader
    {
        // Fields for the reader's properties
        private string _name;
        private string _address;
        private string _phoneNumber;
        private List<IBook> _borrowedBooks;

        // Property for the reader's name
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        // Property for the reader's address
        public string Address
        {
            get => _address;
            set => _address = value;
        }

        // Property for the reader's phone number with validation
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                // Regular expression for validating the phone number format
                string pattern = @"^\+380\d{9}$";
                if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentException("Phone number must be in the format +380999865183.");
                }
                _phoneNumber = value;
            }
        }

        public List<IBook> BorrowedBooks
        {
            get
            {
                if (_borrowedBooks == null)
                {
                    _borrowedBooks = new List<IBook>();  // Create a new list if it's null
                }
                return _borrowedBooks;
            }
        }

        // Constructor to initialize a new reader
        public Reader(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            _borrowedBooks = new List<IBook>();
        }

        // Method to borrow a book
        public bool BorrowBook(IBook book)
        {
            if (book != null && book.IsAvailable)
            {
                BorrowedBooks.Add(book);
                book.IsAvailable = false; 
                return true;
            }
            
            return false;
        }

        // Method to return a book
        public bool ReturnBook(IBook book)
        {
            if (book != null && BorrowedBooks.Contains(book))
            {
                BorrowedBooks.Remove(book); 
                book.IsAvailable = true;    
                return true;
            }
            return false;  
        }
    }
}
