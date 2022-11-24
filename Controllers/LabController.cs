using Microsoft.AspNetCore.Mvc;
using Capstone.LabManagement.Models;

namespace Capstone.LabManagement.Controllers;

[ApiController]
[Route("lab")]
public class LabController : ControllerBase
{
    private readonly ILogger<LabController> _logger;

    public LabController(ILogger<LabController> logger)
    {
        _logger = logger;
    }

    [HttpPost("createLab")]
    public void CreateLab(Lab lab)
    {

    }

    [HttpPut("updateLab")]
    public void UpdateLab(Lab Lab, int id)
    {
        
    }

    [HttpDelete("deleteLab")]
    public void DeleteLab(int idToDelete)
    {
        
    }

    [HttpGet("getLabs")]
    public void GetLabs()
    {

    }

    [HttpGet("getLab")]
    public void GetLab(int LabId)
    {

    }

    // private Lab buildLab(LabDto labDto) {
    //     Optional<Category> category = categoryRepository.findById(labDto.getCategoryId());
    //     Optional<Author> author = authorRepository.findById(labDto.getAuthorId());
    //     return new Lab(labDto.getId(), labDto.getName(), labDto.getDescription(),
    //             category.isPresent() ? category.get() : null, author.isPresent() ? author.get() : null);
    // }
}