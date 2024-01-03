using Labb_2.DTO;
using Labb_2.Models;

namespace Labb_2.Services.Interfaces;

public interface IBookAuthorService
{
    Task<List<BookAuthorDTO>> GetAllBookAuthors();
    Task<BookAuthorDTO?> GetSingleBookAuthor(int bookId, int authorId);
    Task<List<BookAuthor>> AddBookAuthor(BookAuthor bookAuthor);
    Task<List<BookAuthor>> DeleteBookAuthor(int bookId, int authorId);
}