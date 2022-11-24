using Microsoft.AspNetCore.Mvc;
using Capstone.LabManagement.Models;
using Capstone.LabManagement.Repository;

namespace Capstone.LabManagement.Controllers;

[ApiController]
[Route("author")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly AuthorRepository _authorRepo;

    public AuthorController(ILogger<AuthorController> logger, AuthorRepository authorRepo)
    {
        _logger = logger;
        _authorRepo = authorRepo;
    }

    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Author))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("createAuthor")]
    public IActionResult CreateAuthor(Author author)
    {
        Author? result = _authorRepo.Create(author);

        if(result == null)
        {
            _logger.LogError("Error while creating Author!");
            return BadRequest("Error while creating Author!");
        }
        else
        {
            _logger.LogInformation("Author is created!");
            return Created("Author is created! ", result);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Author))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("updateAuthor")]
    public IActionResult UpdateAuthor(Author author, int id)
    {
        var result = _authorRepo.Update(author,id);
        if(result == null)
            return NotFound($"No Author found for Id: {id}. Please try with a valid id !");
        
        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Author))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("deleteAuthor")]
    public IActionResult DeleteAuthor(int id)
    {
        if(_authorRepo.Delete(id))
            return Ok($"Author with {id} is successfully Deleted !");
        else
            return NotFound($"No Author found for Id: {id}. Please try with a valid id !");
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Author>))]
    [HttpGet("getAuthors")]
    public IActionResult GetAuthors()
    {
        return Ok(_authorRepo.SearchAll());
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Author))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("getAuthor")]
    public IActionResult GetAuthor(int id)
    {
        var result = _authorRepo.Search(id);
        if(result == null)
            return NotFound($"No Author found for Id: {id}. Please try with a valid id !");
        
        return Ok(result);
    }
}