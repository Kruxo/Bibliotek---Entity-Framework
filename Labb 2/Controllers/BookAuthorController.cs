using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookAuthorController : ControllerBase
{
    private readonly IBookAuthorService _bookAuthorService;

    public BookAuthorController(IBookAuthorService bookAuthorService)
    {
        _bookAuthorService = bookAuthorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookAuthor>>> GetAllBookAuthors()
    {
        return await _bookAuthorService.GetAllBookAuthors();
    }

    [HttpGet("{bookId}/{authorId}")]
    public async Task<ActionResult<BookAuthor>> GetSingleBookAuthor(int bookId, int authorId)
    {
        var result = await _bookAuthorService.GetSingleBookAuthor(bookId, authorId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<BookAuthor>>> AddBookAuthor(BookAuthor bookAuthor)
    {
        var result = await _bookAuthorService.AddBookAuthor(bookAuthor);
        return Ok(result);
    }

    [HttpDelete("{bookId}/{authorId}")]
    public async Task<ActionResult<List<BookAuthor>>> DeleteBookAuthor(int bookId, int authorId)
    {
        var result = await _bookAuthorService.DeleteBookAuthor(bookId, authorId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}

