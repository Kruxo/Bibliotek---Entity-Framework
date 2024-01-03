using Labb_2.DTO;
using Labb_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2.Services.Interfaces;

public interface IAuthorService
{
    Task<List<AuthoredBooks>> GetAllAuthors();
    Task<AuthoredBooks?> GetSingleAuthor(int id);
    Task<Author> AddAuthor(Author author);
    Task<List<Author>?> DeleteAuthor(int id);
}

