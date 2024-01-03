using AutoMapper;
using Labb_2.Data;
using Labb_2.DTO;
using Labb_2.Models;
using Labb_2.Services;
using Labb_2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookDTO>>> GetAllBooks()
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
    public async Task<ActionResult<Book>> AddBook(AddBookDTO bookDto)
    {
        var addedBook = await _bookService.AddBook(_mapper.Map<Book>(bookDto));
        var addedBookDto = _mapper.Map<AddBookDTO>(addedBook);

        return CreatedAtAction(nameof(GetSingleBook), new { id = addedBook.Id }, addedBook);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Book>>> DeleteBook(int id)
    {
        var result = await _bookService.DeleteBook(id);
        if (result == null)
        {
            return NotFound("This book doesn't exist");
        }
        return Ok($"Book with Id = {id} is deleted from the database");
    }


}
