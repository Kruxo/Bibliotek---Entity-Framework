using Labb_2.Models;

namespace Labb_2.DTO;

public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public DateOnly Published { get; set; }
    public int Rating { get; set; }
    public AuthorDTO AuthorInfo { get; set; } 
    public BorrowDTO BorrowerInfo { get; set; }
}

public class AuthorDTO
{
    public List<int> AuthorIds { get; set; }

}

public class BorrowDTO
{
    public int? BorrowerId { get; set; }
    public DateOnly? BorrowDate { get; set; }
    public DateOnly? ReturnDate { get; set; }

}





