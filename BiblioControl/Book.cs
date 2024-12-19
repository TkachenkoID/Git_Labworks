using System;

namespace BiblioControl
{
    public class Book : IBook
    {
        private int _publicationYear;
        private string _title;
        private string _author;
        private bool _isAvailable;

        // Property for Title
        public string Title
        {
            get => _title;
            set => _title = value;
        }

        // Property for Author
        public string Author
        {
            get => _author;
            set => _author = value;
        }

        // Property for PublicationYear with validation
        public int PublicationYear
        {
            get => _publicationYear;
            set
            {
                if (value.ToString().Length < 1 || value.ToString().Length > 4)
                {
                    throw new ArgumentException("Publication year must be between 1 and 4 digits.");
                }
                _publicationYear = value;
            }
        }

        // Property for IsAvailable
        public bool IsAvailable
        {
            get => _isAvailable;
            set => _isAvailable = value;
        }

        // Constructor to initialize a new book
        public Book(string title, string author, int publicationYear, bool available)
        {
            Title = title;
            Author = author;
            IsAvailable = available;
            PublicationYear = publicationYear;
        }
    }

}
