using Labb_2.Data;
using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb_2.Services;

public class AuthorService : IAuthorService
{
    private readonly LibraryDbContext _context;

    public AuthorService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAllAuthors()
    {
        var allAuthors = await _context.Authors.ToListAsync();
        return allAuthors;
    }

    public async Task<Author?> GetSingleAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author is null)
        {
            return null;
        }

        return author;
    }

    public async Task<List<Author>> AddAuthor(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return await _context.Authors.ToListAsync();
    }

    public async Task<List<Author>?> DeleteAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author is null)
        {
            return null;
        }

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();

        return await _context.Authors.ToListAsync();
    }
}

