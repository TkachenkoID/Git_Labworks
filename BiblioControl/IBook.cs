using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioControl
{
    public interface IBook
    {
        // Property for the title of the book
        string Title { get; }

        // Property for the author of the book
        string Author { get; }

        // Property for the publication year of the book
        int PublicationYear { get; }

        // Property to check if the book is available
        bool IsAvailable { get; }
    }
}
