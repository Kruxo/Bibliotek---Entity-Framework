namespace Labb_2.Models;

public class BookBorrower
{
    public Book BookId { get; set; }
    public Borrower BorrowerId { get; set; }
    public DateOnly BorrowDate { get; set; }
    public DateOnly? ReturnDate { get; set; }

    public Book Book { get; set; }
    public Borrower Borrower { get; set; }

}