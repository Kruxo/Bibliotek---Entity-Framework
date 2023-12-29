using Labb_2.Data;
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

    public async Task<List<Book>> GetAllBooks()
    {
        var allBooks = await _context.Books.ToListAsync();
        return allBooks;
    }

    public async Task<Book?> GetSingleBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
        {
            return null;
        }

        return book;
    }

    public async Task<List<Book>> AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return await _context.Books.ToListAsync();
    }

    /*public async Task<List<Book>?> UpdateBook(Book updateBook, int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
        {
            return null;
        }

        book.Title = updateBook.Title;
        book.ISBN = updateBook.ISBN;
        book.Published = updateBook.Published;
        book.Rating = updateBook.Rating;

        await _context.SaveChangesAsync();

        return await _context.Books.ToListAsync();
    }*/

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
