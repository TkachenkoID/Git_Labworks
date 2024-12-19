using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioControl
{
    public interface IReader
    {
        // Property for the reader's name
        string Name { get; set; }

        // Property for the reader's address
        string Address { get; set; }

        // Property for the reader's contact information
        string PhoneNumber { get; set; }

        // Property for the list of books borrowed by the reader
        List<IBook> BorrowedBooks { get; set; }

        bool BorrowBook(IBook book);
        bool ReturnBook(IBook book);
    }
}
