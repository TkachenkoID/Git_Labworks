namespace BiblioControl
{
    public interface IBook
    {
        // Property for the title of the book
        string Title { get; set; }

        // Property for the author of the book
        string Author { get; set; }

        // Property for the publication year of the book
        int PublicationYear { get; set; }

        // Property to check if the book is available
        bool IsAvailable { get; set; }
    }
}
