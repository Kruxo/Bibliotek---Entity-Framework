using Labb_2.DTO;
using Labb_2.Models;

namespace Labb_2.Extensions;

public static class BookExtensions
{
    public static BookDTO ToBookDTO(this Book book)
    {
        var bookDTO = new BookDTO
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            Published = book.Published,
            Rating = book.Rating,
            AuthorInfo = new AuthorDTO
            {
                AuthorIds = book.Authors.Select(author => author.AuthorId).ToList()
            },
            BorrowerInfo = new BorrowDTO
            {
                BorrowerId = book.Borrowers.FirstOrDefault()?.BorrowerId,
                BorrowDate = book.Borrowers.FirstOrDefault()?.BorrowDate,
                ReturnDate = book.Borrowers.FirstOrDefault()?.ReturnDate
            }
        };

        return bookDTO;
    }
}



