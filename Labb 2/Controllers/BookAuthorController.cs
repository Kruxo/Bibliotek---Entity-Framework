using AutoMapper;
using Labb_2.DTO;
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
    private readonly IMapper _mapper;

    public BookAuthorController(IBookAuthorService bookAuthorService, IMapper mapper)
    {
        _bookAuthorService = bookAuthorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookAuthorDTO>>> GetAllBookAuthors()
    {
        return await _bookAuthorService.GetAllBookAuthors();
    }

    [HttpGet("{bookId}/{authorId}")]
    public async Task<ActionResult<BookAuthor>> GetSingleBookAuthor(int bookId, int authorId)
    {
        var result = await _bookAuthorService.GetSingleBookAuthor(bookId, authorId);
        if (result == null)
        {
            return NotFound("This combination of book and author doesn't exist");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<BookAuthorDTO>>> AddBookAuthor(BookAuthorDTO bookAuthorDto)
    {
        var bookAuthor = _mapper.Map<BookAuthor>(bookAuthorDto);
        var result = await _bookAuthorService.AddBookAuthor(bookAuthor);

        var bookAuthorResultDto = _mapper.Map<List<BookAuthorDTO>>(result);

        return Ok(bookAuthorResultDto);
    }

    [HttpDelete("{bookId}/{authorId}")]
    public async Task<ActionResult<List<BookAuthor>>> DeleteBookAuthor(int bookId, int authorId)
    {
        var result = await _bookAuthorService.DeleteBookAuthor(bookId, authorId);
        if (result == null)
        {
            return NotFound("This combination of book and author doesn't exist");
        }
        return Ok($"Successfully deleted combination of BookId = {bookId} and AuthorId = {authorId} from the database");
    }
}

