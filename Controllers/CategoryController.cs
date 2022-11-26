using Microsoft.AspNetCore.Mvc;
using Capstone.LabManagement.Models;
using Capstone.LabManagement.Repository;

namespace Capstone.LabManagement.Controllers;

[ApiController]
[Route("category")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly CategoryRepository _categoryRepo;

    public CategoryController(ILogger<CategoryController> logger, CategoryRepository categoryRepo)
    {
        _logger = logger;
        _categoryRepo = categoryRepo;
    }

    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("createCategory")]
    public IActionResult CreateCategory(Category category)
    {
        Category? result = _categoryRepo.Create(category);

        if(result == null)
        {
            _logger.LogError("Error while creating Category!");
            return BadRequest("Error while creating Category!");
        }
        else
        {
            _logger.LogInformation("Category is created!");
            return Created("Category is created! ", result);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("updateCategory")]
    public IActionResult UpdateCategory(Category category, int id)
    {
        var result = _categoryRepo.Update(category,id);
        if(result == null)
            return NotFound($"No Category found for Id: {id}. Please try with a valid id !");
        
        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("deleteCategory")]
    public IActionResult DeleteCategory(int id)
    {
        if(_categoryRepo.Delete(id))
            return Ok($"Category with {id} is successfully Deleted !");
        else
            return NotFound($"No Category found for Id: {id}. Please try with a valid id !");
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Category>))]
    [HttpGet("getCategories")]
    public IActionResult GetCategories()
    {
        return Ok(_categoryRepo.SearchAll());
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("getCategory")]
    public IActionResult GetCategory(int id)
    {
        var result = _categoryRepo.Search(id);
        if(result == null)
            return NotFound($"No Category found for Id: {id}. Please try with a valid id !");
        
        return Ok(result);
    }
}