using Labb_2.Data;
using Labb_2.DTO;
using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb_2.Services;

public class BorrowerService : IBorrowerService
{
    private readonly LibraryDbContext _context;

    public BorrowerService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<BorrowerDTO>> GetAllBorrowers()
    {
        var allBorrowers = await _context.Borrowers
            .Include(b => b.BorrowedBooks)
            .ToListAsync();

        var borrowerDTOs = allBorrowers.Select(b => new BorrowerDTO
        {
            Id = b.Id,
            FirstName = b.FirstName,
            LastName = b.LastName,
            LibraryCard = b.LibraryCard,
            BorrowedBooks = b.BorrowedBooks.Select(bb => new BorrowedBooksDTO
            {
                BookId = bb.BookId,
                BorrowDate = bb.BorrowDate,
                ReturnDate = bb.ReturnDate
            }).ToList()
        }).ToList();

        return borrowerDTOs;
    }

    public async Task<BorrowerDTO?> GetSingleBorrower(int id)
    {
        var borrower = await _context.Borrowers
            .Include(b => b.BorrowedBooks)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (borrower is null)
        {
            return null;
        }

        var borrowedBooks = borrower.BorrowedBooks.Select(bb => new BorrowedBooksDTO
        {
            BookId = bb.BookId,
            BorrowDate = bb.BorrowDate,
            ReturnDate = bb.ReturnDate
        }).ToList();

        return new BorrowerDTO
        {
            Id = borrower.Id,
            FirstName = borrower.FirstName,
            LastName = borrower.LastName,
            LibraryCard = borrower.LibraryCard,
            BorrowedBooks = borrowedBooks
        };
    }


    public async Task<Borrower> AddBorrower(Borrower borrower)
    {
        _context.Borrowers.Add(borrower);
        await _context.SaveChangesAsync();
        return borrower;
    }

    public async Task<List<Borrower>?> DeleteBorrower(int id)
    {
        var borrower = await _context.Borrowers.FindAsync(id);
        if (borrower is null)
        {
            return null;
        }

        _context.Borrowers.Remove(borrower);
        await _context.SaveChangesAsync();

        return await _context.Borrowers.ToListAsync();
    }
}
