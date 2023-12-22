namespace Labb_2.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<BookAuthor> Books { get; set; }
}

