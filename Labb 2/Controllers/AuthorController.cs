using AutoMapper;
using Labb_2.DTO;
using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
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
    public async Task<ActionResult<Author>> AddAuthor(AuthorDTO authorDto)
    {
        var addedAuthor = await _authorService.AddAuthor(_mapper.Map<Author>(authorDto)); //Maps AuthorDTO to an Author when an author gets added to the service
        var addedAuthorDto = _mapper.Map<AuthorDTO>(addedAuthor); //This maps back from Author to AuthorDTO which gives us the result

       return CreatedAtAction(nameof(GetSingleAuthor), new { id = addedAuthorDto.Id }, addedAuthorDto);
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


