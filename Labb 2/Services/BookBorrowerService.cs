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
    public async Task<List<BookBorrower>> BorrowBook(int bookId, int borrowerId)
    {
        // Check if the book and borrower exist
        var book = await _context.Books.FindAsync(bookId);
        var borrower = await _context.Borrowers.FindAsync(borrowerId);

        if (book == null || borrower == null)
        {
            return null; // Book or borrower not found
        }

        // Check if the book is already borrowed
        if (await _context.BookBorrowers.AnyAsync(bb => bb.BookId == bookId && bb.ReturnDate == null))
        {
            return null; // Book is already borrowed
        }

        // Create a new BookBorrower record
        var bookBorrower = new BookBorrower
        {
            BookId = bookId,
            BorrowerId = borrowerId,
            BorrowDate = DateOnly.FromDateTime(DateTime.Now) // Set the current date as the borrow date
        };

        _context.BookBorrowers.Add(bookBorrower);
        await _context.SaveChangesAsync();

        return await _context.BookBorrowers.ToListAsync();
    }

    public async Task<List<BookBorrower>> ReturnBook(int bookId, int borrowerId)
    {
        // Find the BookBorrower record for the given book and borrower
        var bookBorrower = await _context.BookBorrowers
            .SingleOrDefaultAsync(bb => bb.BookId == bookId && bb.BorrowerId == borrowerId && bb.ReturnDate == null);

        if (bookBorrower == null)
        {
            return null; // Book is not currently borrowed by the specified borrower
        }

        // Set the return date to the current date
        bookBorrower.ReturnDate = DateOnly.FromDateTime(DateTime.Now);

        await _context.SaveChangesAsync();

        return await _context.BookBorrowers.ToListAsync();
    }
}

