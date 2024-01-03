using Labb_2.DTO;
using Labb_2.Models;

namespace Labb_2.Extensions;

public static class AuthorExtensions
{
    public static AuthoredBooks ToAuthorDTO(this Author author)
    {
        return new AuthoredBooks
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            BookIds = author.Books.Select(bookAuthor => bookAuthor.BookId).ToList()
        };
    }
}

