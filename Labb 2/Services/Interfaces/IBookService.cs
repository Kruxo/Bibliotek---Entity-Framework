using Labb_2.DTO;
using Labb_2.Models;

namespace Labb_2.Services.Interfaces;

public interface IBookService
{
    Task<List<BookDTO>> GetAllBooks();
    Task<BookDTO?> GetSingleBook(int id);
    Task<Book> AddBook(Book book);
    Task<List<Book>?> DeleteBook(int id);
}

