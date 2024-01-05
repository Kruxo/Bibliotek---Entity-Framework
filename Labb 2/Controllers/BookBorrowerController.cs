using AutoMapper;
using Labb_2.DTO;
using Labb_2.Models;
using Labb_2.Services;
using Labb_2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookBorrowerController : ControllerBase
{
    private readonly IBookBorrowerService _bookBorrowerService;
    private readonly IMapper _mapper;

    public BookBorrowerController(IBookBorrowerService bookBorrowerService, IMapper mapper)
    {
        _bookBorrowerService = bookBorrowerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookBorrowerDTO>>> GetAllBookBorrowers()
    {
        return await _bookBorrowerService.GetAllBookBorrowers();
    }

    [HttpGet("{bookId}/{borrowerId}")]
    public async Task<ActionResult<BookBorrower>> GetSingleBookBorrower(int bookId, int borrowerId)
    {
        var result = await _bookBorrowerService.GetSingleBookBorrower(bookId, borrowerId);
        if (result == null)
        {
            return NotFound("This combination of book and borrower doesn't exist");
        }
        return Ok(result);
    }

    //If we want to manually type in the borrow and return date
    [HttpPost]
    public async Task<ActionResult<List<BookBorrowerDTO>>> AddBookBorrower(BookBorrowerDTO bookBorrowerDto)
    {
        var bookBorrower = _mapper.Map<BookBorrower>(bookBorrowerDto);
        var result = await _bookBorrowerService.AddBookBorrower(bookBorrower);

        var bookBorrowerResultDto = _mapper.Map<List<BookBorrowerDTO>>(result);

        return Ok(bookBorrowerResultDto);
    }

    [HttpDelete("{bookId}/{borrowerId}")]
    public async Task<ActionResult<List<BookBorrower>>> DeleteBookBorrower(int bookId, int borrowerId)
    {
        var result = await _bookBorrowerService.DeleteBookBorrower(bookId, borrowerId);
        if (result == null)
        {
            return NotFound("This combination of book and author doesn't exist");
        }
        return Ok($"Successfully deleted combination of BookId = {bookId} and BorrowerId = {borrowerId} from the database");
    }

    //Borrowing a book, basically adding a book but with less steps.
    //BorrowDate will be the system's date. Configured in modelbuilder in the dbcontext
    [HttpPost("Borrow Book/{bookId}/{borrowerId}")]
    public async Task<ActionResult<List<BookBorrowerDTO>>> BorrowBook(int bookId, int borrowerId)
    {
        var result = await _bookBorrowerService.BorrowBook(bookId, borrowerId);
        if (result == null)
        {
            return NotFound("Error! Failed to borrow. Check if the book and borrower exist or if the book is already borrowed.");
        }

        var bookBorrowerResultDto = _mapper.Map<List<BookBorrowerDTO>>(result);
        return Ok(bookBorrowerResultDto);
    }


    [HttpPost("Return Book/{bookId}/{borrowerId}")]
    public async Task<ActionResult<List<BookBorrowerDTO>>> ReturnBook(int bookId, int borrowerId)
    {
        var result = await _bookBorrowerService.ReturnBook(bookId, borrowerId);
        if (result == null)
        {
            return NotFound("Error! Failed to return.");
        }

        var bookBorrowerResultDto = _mapper.Map<List<BookBorrowerDTO>>(result);
        return Ok(bookBorrowerResultDto);
    }

}

