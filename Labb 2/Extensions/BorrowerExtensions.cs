using Labb_2.DTO;
using Labb_2.Models;

namespace Labb_2.Extensions;

public static class BorrowerExtensions
{
    public static BorrowerDTO ToBorrowDTO(this Borrower borrower)
    {
        var borrowedBooks = borrower.BorrowedBooks.Select(bb => new BorrowedBooksDTO
        {
            BookId = bb.BookId,
            BorrowDate = bb.BorrowDate,
            ReturnDate = bb.ReturnDate
        }).ToList();

        return new BorrowerDTO
        {
            Id = borrower.Id,
            FirstName = borrower.FirstName,
            LastName = borrower.LastName,
            LibraryCard = borrower.LibraryCard,
            BorrowedBooks = borrowedBooks
        };
    }
}

