namespace Labb_2.DTO;

public class BookBorrowerDTO
{
    public int BookId { get; set; }
    public int BorrowerId { get; set; }
    public DateOnly? BorrowDate { get; set; }
    public DateOnly? ReturnDate { get; set; }

}
