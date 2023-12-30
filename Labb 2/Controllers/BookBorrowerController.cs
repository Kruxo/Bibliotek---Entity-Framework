using Labb_2.Models;
using Labb_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookBorrowerController : ControllerBase
{
    private readonly IBookBorrowerService _bookBorrowerService;

    public BookBorrowerController(IBookBorrowerService bookBorrowerService)
    {
        _bookBorrowerService = bookBorrowerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookBorrower>>> GetAllBookBorrowers()
    {
        return await _bookBorrowerService.GetAllBookBorrowers();
    }

    [HttpGet("{bookId}/{borrowerId}")]
    public async Task<ActionResult<BookBorrower>> GetSingleBookBorrower(int bookId, int borrowerId)
    {
        var result = await _bookBorrowerService.GetSingleBookBorrower(bookId, borrowerId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<BookBorrower>>> AddBookBorrower(BookBorrower bookBorrower)
    {
        var result = await _bookBorrowerService.AddBookBorrower(bookBorrower);
        return Ok(result);
    }

    [HttpDelete("{bookId}/{borrowerId}")]
    public async Task<ActionResult<List<BookBorrower>>> DeleteBookBorrower(int bookId, int borrowerId)
    {
        var result = await _bookBorrowerService.DeleteBookBorrower(bookId, borrowerId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("borrow/{bookId}/{borrowerId}")]
    public async Task<ActionResult<List<BookBorrower>>> BorrowBook(int bookId, int borrowerId)
    {
        var result = await _bookBorrowerService.BorrowBook(bookId, borrowerId);
        if (result == null)
        {
            return NotFound("Error! Failed to borrow. Check if the book and borrower exist or if the book is already borrowed.");
        }
        return Ok(result);
    }

    [HttpPost("return/{bookId}/{borrowerId}")]
    public async Task<ActionResult<List<BookBorrower>>> ReturnBook(int bookId, int borrowerId)
    {
        var result = await _bookBorrowerService.ReturnBook(bookId, borrowerId);
        if (result == null)
        {
            return NotFound("Error! Failed to return.");
        }
        return Ok(result);
    }
}

