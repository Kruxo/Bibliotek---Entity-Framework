using Labb_2.Data;
using Labb_2.DTO;
using Labb_2.Extensions;
using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb_2.Services;

public class BookService : IBookService
{
    private readonly LibraryDbContext _context;

    public BookService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookDTO>> GetAllBooks()
    {
        var allBooks = await _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Borrowers)
            .ToListAsync();

        var bookDTOs = allBooks.Select(book => book.ToBookDTO()).ToList();

        return bookDTOs;
    }


    public async Task<BookDTO?> GetSingleBook(int id)
    {
        var book = await _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Borrowers)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book is null)
        {
            return null;
        }

        return book.ToBookDTO();
    }


    public async Task<Book> AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<List<Book>?> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
        {
            return null;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return await _context.Books.ToListAsync();
    }
}
