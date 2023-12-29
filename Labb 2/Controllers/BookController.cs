using Labb_2.Data;
using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllBooks()
    {
        return await _bookService.GetAllBooks();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetSingleBook(int id)
    {
        var result = await _bookService.GetSingleBook(id);
        if (result == null)
        {
            return NotFound("This book doesn't exist");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Book>>> AddBook(Book book)
    {
        var result = await _bookService.AddBook(book);
        return Ok(result);
    }

    /*[HttpPut]
    public async Task<ActionResult<List<Book>>> UpdateBook(Book updateBook, int id)
    {
        var result = await _bookService.UpdateBook(updateBook, id);
        if (result == null)
        {
            return NotFound("This book doesn't exist");
        }
        return Ok(result);
    }*/


    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Book>>> DeleteBook(int id)
    {
        var result = await _bookService.DeleteBook(id);
        if (result == null)
        {
            return NotFound("This book doesn't exist");
        }
        return Ok(result);
    }


}
