using Labb_2.Data;
using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb_2.Services;

public class BookAuthorService : IBookAuthorService
{
    private readonly LibraryDbContext _context;

    public BookAuthorService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookAuthor>> GetAllBookAuthors()
    {
        return await _context.BookAuthors.ToListAsync();
    }

    public async Task<BookAuthor?> GetSingleBookAuthor(int bookId, int authorId)
    {
        return await _context.BookAuthors.FindAsync(bookId, authorId);
    }

    public async Task<List<BookAuthor>> AddBookAuthor(BookAuthor bookAuthor)
    {
        _context.BookAuthors.Add(bookAuthor);
        await _context.SaveChangesAsync();
        return await _context.BookAuthors.ToListAsync();
    }

    public async Task<List<BookAuthor>> DeleteBookAuthor(int bookId, int authorId)
    {
        var bookAuthor = await _context.BookAuthors.FindAsync(bookId, authorId);
        if (bookAuthor != null)
        {
            _context.BookAuthors.Remove(bookAuthor);
            await _context.SaveChangesAsync();
        }
        return await _context.BookAuthors.ToListAsync();
    }
}


