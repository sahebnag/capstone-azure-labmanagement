using Microsoft.AspNetCore.Mvc;
using Capstone.LabManagement.Models;
using Capstone.LabManagement.Repository;

namespace Capstone.LabManagement.Controllers;

[ApiController]
[Route("lab")]
public class LabController : ControllerBase
{
    private readonly ILogger<LabController> _logger;
    private readonly LabRepository _labRepo;

    public LabController(ILogger<LabController> logger, LabRepository labRepo)
    {
        _logger = logger;
        _labRepo = labRepo;
    }

    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Lab))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("createLab")]
    public IActionResult CreateLab(Lab lab)
    {
        if(!_labRepo.ValidateAuthor(lab.Author.Id))
            return BadRequest($"Author Id: {lab.Author.Id} does not exist. Please try with valid Author Id !");

        if(!_labRepo.ValidateCategory(lab.Category.Id))
            return BadRequest($"Category Id: {lab.Category.Id} does not exist. Please try with valid Category Id !");

        Lab? result = _labRepo.Create(lab);

        if(result == null)
        {
            _logger.LogError("Error while creating Lab!");
            return BadRequest("Error while creating Lab ! ");
        }
        else
        {
            _logger.LogInformation("Lab is created!");
            return Created("Lab is created! ", result);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lab))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("updateLab")]
    public IActionResult UpdateLab(Lab lab, int id)
    {
        if(!_labRepo.ValidateAuthor(lab.Author.Id))
            return BadRequest($"Author Id: {lab.Author.Id} does not exist. Please try with valid Author Id !");

        if(!_labRepo.ValidateCategory(lab.Category.Id))
            return BadRequest($"Category Id: {lab.Category.Id} does not exist. Please try with valid Category Id !");

        var result = _labRepo.Update(lab,id);

        if(result == null)
            return NotFound($"No Lab found for Id: {id}. Please try with a valid id !");
        
        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lab))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("deleteLab")]
    public IActionResult DeleteLab(int id)
    {
        if(_labRepo.Delete(id))
            return Ok($"Lab with {id} is successfully Deleted !");
        else
            return NotFound($"No Lab found for Id: {id}. Please try with a valid id !");
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Lab>))]
    [HttpGet("getLabs")]
    public IActionResult GetLabs()
    {
        return Ok(_labRepo.SearchAll());
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lab))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("getLab")]
    public IActionResult Getlab(int id)
    {
        var result = _labRepo.Search(id);
        if(result == null)
            return NotFound($"No Lab found for Id: {id}. Please try with a valid id !");
        
        return Ok(result);
    }
}