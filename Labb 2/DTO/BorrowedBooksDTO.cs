namespace Labb_2.DTO;

public class BorrowedBooksDTO
{
    public int BookId { get; set; }
    public DateOnly BorrowDate { get; set; }
    public DateOnly? ReturnDate { get; set; }
}
