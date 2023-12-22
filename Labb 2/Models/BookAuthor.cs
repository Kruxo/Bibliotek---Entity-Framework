namespace Labb_2.Models;

public class BookAuthor
{
    public Book BookId { get; set; }
    public List<Author> AuthorId { get; set; }

    public Book Book { get; set; }
    public Author Author { get; set; }

}
