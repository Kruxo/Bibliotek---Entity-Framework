using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Author>>> GetAllAuthors()
    {
        return await _authorService.GetAllAuthors();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetSingleAuthor(int id)
    {
        var result = await _authorService.GetSingleAuthor(id);
        if (result == null)
        {
            return NotFound("This author doesn't exist");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Author>>> AddAuthor(Author author)
    {
        var result = await _authorService.AddAuthor(author);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Author>>> DeleteAuthor(int id)
    {
        var result = await _authorService.DeleteAuthor(id);
        if (result == null)
        {
            return NotFound("This author doesn't exist");
        }
        return Ok(result);
    }
}


