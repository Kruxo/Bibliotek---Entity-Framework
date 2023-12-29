using Labb_2.Models;

namespace Labb_2.Services;

public interface IBookBorrowerService
{
    Task<List<BookBorrower>> GetAllBookBorrowers();
    Task<BookBorrower?> GetSingleBookBorrower(int bookId, int borrowerId);
    Task<List<BookBorrower>> AddBookBorrower(BookBorrower bookBorrower);
    Task<List<BookBorrower>> DeleteBookBorrower(int bookId, int borrowerId);
}

