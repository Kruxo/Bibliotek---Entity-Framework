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
        //Checking if book and borrower exist by their ID
        var book = await _context.Books.FindAsync(bookId);
        var borrower = await _context.Borrowers.FindAsync(borrowerId);

        if (book == null || borrower == null)
        {
            return null; 
        }

        //Checking if book is borrowed
        if (await _context.BookBorrowers.AnyAsync(bb => bb.BookId == bookId && bb.ReturnDate == null))
        {
            return null; 
        }

        //Creating new record of borrowed book
        var bookBorrower = new BookBorrower
        {
            BookId = bookId,
            BorrowerId = borrowerId,
            BorrowDate = DateOnly.FromDateTime(DateTime.Now)
        };

        _context.BookBorrowers.Add(bookBorrower);
        await _context.SaveChangesAsync();

        return await _context.BookBorrowers.ToListAsync();
    }

    public async Task<List<BookBorrower>> ReturnBook(int bookId, int borrowerId)
    {
        //Finding existing record of borrowed book by borrower 
        var bookBorrower = await _context.BookBorrowers
            .SingleOrDefaultAsync(bb => bb.BookId == bookId && bb.BorrowerId == borrowerId && bb.ReturnDate == null);

        if (bookBorrower == null)
        {
            return null; 
        }

        //Set return date to current system date
        bookBorrower.ReturnDate = DateOnly.FromDateTime(DateTime.Now);

        await _context.SaveChangesAsync();

        return await _context.BookBorrowers.ToListAsync();
    }
}

