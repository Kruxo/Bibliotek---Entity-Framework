namespace Labb_2.Models;

public class Borrower
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string LibraryCard { get; set; }

    public List<BookBorrower> BorrowedBooks { get; set; }
}
