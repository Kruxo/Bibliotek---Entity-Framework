using Labb_2.Data;
using Labb_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_2.Services;

public class BookBorrowerService : IBookBorrowerService
{
    private readonly LibraryDbContext _context;

    public BookBorrowerService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookBorrower>> GetAllBookBorrowers()
    {
        return await _context.BookBorrowers.ToListAsync();
    }

    public async Task<BookBorrower?> GetSingleBookBorrower(int bookId, int borrowerId)
    {
        return await _context.BookBorrowers.FindAsync(bookId, borrowerId);
    }

    public async Task<List<BookBorrower>> AddBookBorrower(BookBorrower bookBorrower)
    {
        _context.BookBorrowers.Add(bookBorrower);
        await _context.SaveChangesAsync();
        return await _context.BookBorrowers.ToListAsync();
    }

    public async Task<List<BookBorrower>> DeleteBookBorrower(int bookId, int borrowerId)
    {
        var bookBorrower = await _context.BookBorrowers.FindAsync(bookId, borrowerId);
        if (bookBorrower != null)
        {
            _context.BookBorrowers.Remove(bookBorrower);
            await _context.SaveChangesAsync();
        }
        return await _context.BookBorrowers.ToListAsync();
    }
}

