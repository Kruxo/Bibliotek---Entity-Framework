using AutoMapper;
using Labb_2.DTO;
using Labb_2.Models;
using Labb_2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowerController : ControllerBase
{
    private readonly IBorrowerService _borrowerService;
    private readonly IMapper _mapper;
    public BorrowerController(IBorrowerService borrowerService, IMapper mapper)
    {
        _borrowerService = borrowerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<BorrowerDTO>>> GetAllBorrowers()
    {
        return await _borrowerService.GetAllBorrowers();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BorrowerDTO>> GetSingleBorrower(int id)
    {
        var result = await _borrowerService.GetSingleBorrower(id);
        if (result == null)
        {
            return NotFound("This borrower doesn't exist");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<AddBorrowerDTO>> AddBorrower(AddBorrowerDTO borrowerDto)
    {
        var addedBorrower = await _borrowerService.AddBorrower(_mapper.Map<Borrower>(borrowerDto));
        var addedBorrowerDto = _mapper.Map<AddBorrowerDTO>(addedBorrower);

        return CreatedAtAction(nameof(GetSingleBorrower), new { id = addedBorrower.Id }, addedBorrower);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Borrower>>> DeleteBorrower(int id)
    {
        var result = await _borrowerService.DeleteBorrower(id);
        if (result == null)
        {
            return NotFound("This borrower doesn't exist");
        }
        return Ok($"Borrower with Id = {id} is deleted from the database");
    }
}
