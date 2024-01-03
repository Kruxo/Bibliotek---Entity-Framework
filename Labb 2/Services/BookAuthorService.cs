using Labb_2.Data;
using Labb_2.DTO;
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

    public async Task<List<BookAuthorDTO>> GetAllBookAuthors()
    {
        var bookAuthors = await _context.BookAuthors.ToListAsync();
        var bookAuthorDTOs = bookAuthors.Select(ba => new BookAuthorDTO
        {
            BookId = ba.BookId,
            AuthorId = ba.AuthorId
        }).ToList();

        return bookAuthorDTOs;
    }

    public async Task<BookAuthorDTO?> GetSingleBookAuthor(int bookId, int authorId)
    {
        var bookAuthor = await _context.BookAuthors.FindAsync(bookId, authorId);

        if (bookAuthor is null)
        {
            return null;
        }

        return new BookAuthorDTO
        {
            BookId = bookAuthor.BookId,
            AuthorId = bookAuthor.AuthorId
        };

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
        if (bookAuthor is null)
        {
            return null;
        }

        _context.BookAuthors.Remove(bookAuthor);
            await _context.SaveChangesAsync();

        return await _context.BookAuthors.ToListAsync();
    }

}


