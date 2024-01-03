using Labb_2.DTO;
using Labb_2.Models;

namespace Labb_2.Services;

public interface IBookBorrowerService
{
    Task<List<BookBorrowerDTO>> GetAllBookBorrowers();
    Task<BookBorrowerDTO?> GetSingleBookBorrower(int bookId, int borrowerId);
    Task<List<BookBorrower>> AddBookBorrower(BookBorrower bookBorrower);
    Task<List<BookBorrower>> DeleteBookBorrower(int bookId, int borrowerId);
    Task<List<BookBorrower>> BorrowBook(int bookId, int borrowerId);
    Task<List<BookBorrower>> ReturnBook(int bookId, int borrowerId);
}

