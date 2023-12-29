namespace Labb_2.Models;

public class BookBorrower
{
    public int BookId { get; set; }
    public int BorrowerId { get; set; }
    public DateOnly BorrowDate { get; set; }
    public DateOnly? ReturnDate { get; set; }

    public Book Book { get; set; }
    public Borrower Borrower { get; set; }

}