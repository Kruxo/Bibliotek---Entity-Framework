using Labb_2.Data;
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

    public async Task<List<Borrower>> GetAllBorrowers()
    {
        var allBorrowers = await _context.Borrowers.ToListAsync();
        return allBorrowers;
    }

    public async Task<Borrower?> GetSingleBorrower(int id)
    {
        var borrower = await _context.Borrowers.FindAsync(id);
        if (borrower is null)
        {
            return null;
        }

        return borrower;
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
