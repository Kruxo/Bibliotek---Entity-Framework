using Labb_2.Models;

namespace Labb_2.Services.Interfaces;

public interface IBorrowerService
{
    Task<List<Borrower>> GetAllBorrowers();
    Task<Borrower?> GetSingleBorrower(int id);
    Task<List<Borrower>> AddBorrower(Borrower borrower);
    Task<List<Borrower>?> DeleteBorrower(int id);
}
