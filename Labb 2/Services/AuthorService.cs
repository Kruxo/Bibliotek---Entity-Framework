using Labb_2.Data;
using Labb_2.DTO;
using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_2.Services;

public class AuthorService : IAuthorService
{
    private readonly LibraryDbContext _context;

    public AuthorService(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<List<AuthoredBooks>> GetAllAuthors()
    {
        var authors = await _context.Authors.Include(a => a.Books).ToListAsync();

        return authors.Select(author => new AuthoredBooks
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            BookIds = author.Books.Select(bookAuthor => bookAuthor.BookId).ToList()
        }).ToList();
    }

    public async Task<AuthoredBooks?> GetSingleAuthor(int id)
    {
        var author = await _context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (author is null)
        {
            return null;
        }

        return new AuthoredBooks
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            BookIds = author.Books.Select(bookAuthor => bookAuthor.BookId).ToList()
        };
    }

    public async Task<Author> AddAuthor(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return author;
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

