using Labb_2.Models;

namespace Labb_2.Services.Interfaces;

public interface IBookService
{
    Task<List<Book>> GetAllBooks();
    Task<Book?> GetSingleBook(int id);
    Task<List<Book>> AddBook(Book book);
    Task<List<Book>?> DeleteBook(int id);
}

