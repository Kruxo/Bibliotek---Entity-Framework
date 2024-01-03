using Labb_2.Data;
using Labb_2.DTO;
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

    public async Task<List<BookBorrowerDTO>> GetAllBookBorrowers()
    {
        var bookBorrowers = await _context.BookBorrowers.ToListAsync();
        var bookBorrowersDTO = bookBorrowers.Select(bb => new BookBorrowerDTO
        {
            BookId = bb.BookId,
            BorrowerId = bb.BorrowerId,
            BorrowDate = bb.BorrowDate,
            ReturnDate = bb.ReturnDate

        }).ToList();

        return bookBorrowersDTO;
    }

    public async Task<BookBorrowerDTO?> GetSingleBookBorrower(int bookId, int borrowerId)
    {
        var bookBorrower = await _context.BookBorrowers.FindAsync(bookId, borrowerId);

        if (bookBorrower == null)
        {
            return null;
        }

        return new BookBorrowerDTO
        {
            BookId = bookBorrower.BookId,
            BorrowerId = bookBorrower.BorrowerId,
            BorrowDate = bookBorrower.BorrowDate,
            ReturnDate = bookBorrower.ReturnDate
        };
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
        if (bookBorrower is null)
        {
            return null;
        }

        _context.BookBorrowers.Remove(bookBorrower);
        await _context.SaveChangesAsync();

        return await _context.BookBorrowers.ToListAsync();
    }

    public async Task<List<BookBorrower>> BorrowBook(int bookId, int borrowerId)
    {
        //Checking if book and borrower exist by their ID in the database
        var book = await _context.Books.FindAsync(bookId);
        var borrower = await _context.Borrowers.FindAsync(borrowerId);

        if (book == null || borrower == null)
        {
            return null; 
        }

        //Checking if book is borrowed, return null if not
        if (await _context.BookBorrowers.AnyAsync(bb => bb.BookId == bookId && bb.ReturnDate == null))
        {
            return null; 
        }

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
        //Looking for an existing record of borrowed book by borrower 
        var bookBorrower = await _context.BookBorrowers 
            .SingleOrDefaultAsync(bb => bb.BookId == bookId && bb.BorrowerId == borrowerId && bb.ReturnDate == null);

        if (bookBorrower == null)
        {
            return null;
        }

        //Setting return date to current system time
        bookBorrower.ReturnDate = DateOnly.FromDateTime(DateTime.Now); 

        await _context.SaveChangesAsync();

        return await _context.BookBorrowers.ToListAsync();
    }
}

