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

    public BorrowerController(IBorrowerService borrowerService)
    {
        _borrowerService = borrowerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Borrower>>> GetAllBorrowers()
    {
        return await _borrowerService.GetAllBorrowers();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Borrower>> GetSingleBorrower(int id)
    {
        var result = await _borrowerService.GetSingleBorrower(id);
        if (result == null)
        {
            return NotFound("This borrower doesn't exist");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Borrower>>> AddBorrower(Borrower borrower)
    {
        var result = await _borrowerService.AddBorrower(borrower);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Borrower>>> DeleteBorrower(int id)
    {
        var result = await _borrowerService.DeleteBorrower(id);
        if (result == null)
        {
            return NotFound("This borrower doesn't exist");
        }
        return Ok(result);
    }
}
