using Labb_2.Services;

namespace Labb_2.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public DateOnly Published { get; set; }
    public int? Rating { get; set; }

    public List<BookAuthor> Authors { get; set; }
    public List<BookBorrower> Borrowers { get; set; }
}
