using Labb_2.Models;

namespace Labb_2.Services.Interfaces;

public interface IBookAuthorService
{
    Task<List<BookAuthor>> GetAllBookAuthors();
    Task<BookAuthor?> GetSingleBookAuthor(int bookId, int authorId);
    Task<List<BookAuthor>> AddBookAuthor(BookAuthor bookAuthor);
    Task<List<BookAuthor>> DeleteBookAuthor(int bookId, int authorId);
}