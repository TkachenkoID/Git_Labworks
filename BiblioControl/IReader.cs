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
        string Name { get; }

        // Property for the reader's address
        string Address { get; }

        // Property for the reader's contact information
        string PhoneNumber { get; }

        // Property for the list of books borrowed by the reader
        List<IBook> BorrowedBooks { get; }
    }
}
