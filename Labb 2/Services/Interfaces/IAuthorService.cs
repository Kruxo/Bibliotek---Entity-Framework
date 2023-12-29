using Labb_2.Models;

namespace Labb_2.Services.Interfaces;

public interface IAuthorService
{
    Task<List<Author>> GetAllAuthors();
    Task<Author?> GetSingleAuthor(int id);
    Task<List<Author>> AddAuthor(Author author);
    Task<List<Author>?> DeleteAuthor(int id);
}

