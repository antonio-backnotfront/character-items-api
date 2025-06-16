// using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using pazio_test2.API.DTO;
using pazio_test2.API.Exceptions;
using pazio_test2.API.Services;

namespace pazio_test2.API.Controllers;

[ApiController]
[Route("/api/characters")]
public class CharactersController : ControllerBase
{
    ICharactersService _service;
    private ILogger<CharactersController> _logger;

    public CharactersController(ICharactersService service, ILogger<CharactersController> logger)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacterById(int id, CancellationToken cancellationToken)
    {
        try
        {
            GetCharacterDto? character = await _service.GetCharacterByIdAsync(id, cancellationToken);
            return character != null ? Ok(character) : NotFound($"Character with id {id} not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Problem();
        }
    }
    
    [HttpPost("{id}/backpacks")]
    public async Task<IActionResult> AddItems(int id, [FromBody] int[] items, CancellationToken cancellationToken)
    {
        try
        {
            int[]? dto = await _service.AddItemToCharacterAsync(id, items, cancellationToken);
            return Created($"api/{id}", dto);
        }
        catch (ExceedingLimitException e)
        {
            return BadRequest(e.Message);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Problem();
        }
    }
    
    
    
}