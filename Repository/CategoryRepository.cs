using Capstone.LabManagement.Entities;
using Capstone.LabManagement.Models;

namespace Capstone.LabManagement.Repository;

public class CategoryRepository
{
    private LabManagementContext _labManagementContext;
    private readonly ILogger<CategoryRepository> _logger;

    public CategoryRepository(LabManagementContext labManagementContext, ILogger<CategoryRepository> logger)
    {
        _labManagementContext = labManagementContext;
        _logger = logger;
    }

    public Category? Create(Category category)
    {
        try
        {
            CategoryDto categoryDto = new(){Name = category.Name};
            _labManagementContext.Categories.Add(categoryDto);
            _labManagementContext.SaveChanges();
            category.Id = categoryDto.Id;
            return category;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);   
            return null;
        }
        
    }

    public Category? Update(Category category, int searchId)
    {
        CategoryDto? categoryDto = _labManagementContext.Categories.Where(x => x.Id == searchId).FirstOrDefault();

        if(categoryDto != null)
        {
            categoryDto.Name = category.Name;
            _labManagementContext.Categories.Update(categoryDto);
            _labManagementContext.SaveChanges();
            category.Id = categoryDto.Id;

            return category;
        }
        else
        {
            return null;
        }
    }

    public bool Delete(int deleteId)
    {
        CategoryDto? categoryDto = _labManagementContext.Categories.Where(x => x.Id == deleteId).FirstOrDefault();

        if(categoryDto != null)
        {
            _labManagementContext.Categories.Remove(categoryDto);
            _labManagementContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public Category? Search(int searchId)
    {
        CategoryDto? categoryDto = _labManagementContext.Categories.Where(x => x.Id == searchId).FirstOrDefault();

        if(categoryDto != null)
        {
            return new(){Id = categoryDto.Id, Name = categoryDto.Name};
        }
        else
        {
            return null;
        }
    }

    public List<Category> SearchAll()
    {
        List<Category> categories = new();
        var categoryDtos =_labManagementContext.Categories.ToList();
        categoryDtos.ForEach(l => categories.Add(new Category() {Id =l.Id, Name =l.Name }));
        return categories;
    }
}