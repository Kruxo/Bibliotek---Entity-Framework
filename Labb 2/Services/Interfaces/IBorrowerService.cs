using Labb_2.DTO;
using Labb_2.Models;

namespace Labb_2.Services.Interfaces;

public interface IBorrowerService
{
    Task<List<BorrowerDTO>> GetAllBorrowers();
    Task<BorrowerDTO?> GetSingleBorrower(int id);
    Task<Borrower> AddBorrower(Borrower borrower);
    Task<List<Borrower>?> DeleteBorrower(int id);
}
