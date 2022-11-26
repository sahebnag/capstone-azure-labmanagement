using Capstone.LabManagement.Entities;
using Capstone.LabManagement.Models;

namespace Capstone.LabManagement.Repository;

public class LabRepository
{
    private LabManagementContext _labManagementContext;
    private readonly ILogger<LabRepository> _logger;

    public LabRepository(LabManagementContext labManagementContext, ILogger<LabRepository> logger)
    {
        _labManagementContext = labManagementContext;
        _logger = logger;
    }

    public Lab? Create(Lab lab)
    {
        try
        {
            var authorId = lab.Author.Id;
            var categoryId = lab.Category.Id;

            LabDto labDto = new(){Name = lab.Name, CategoryId = categoryId, AuthorId = authorId};
            _labManagementContext.Labs.Add(labDto);
            _labManagementContext.SaveChanges();
            lab.Id = labDto.Id;
            return lab;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);   
            return null;
        }
        
    }

    public Lab? Update(Lab lab, int searchId)
    {
        LabDto? labDto = _labManagementContext.Labs.Where(x => x.Id == searchId).FirstOrDefault();

        if(labDto != null)
        {
            labDto.Name = lab.Name;
            labDto.CategoryId = lab.Category.Id;
            labDto.AuthorId = lab.Author.Id;
            _labManagementContext.Labs.Update(labDto);
            _labManagementContext.SaveChanges();
            lab.Id = labDto.Id;

            return lab;
        }
        else
        {
            return null;
        }
    }

    public bool Delete(int deleteId)
    {
        LabDto? labDto = _labManagementContext.Labs.Where(x => x.Id == deleteId).FirstOrDefault();

        if(labDto != null)
        {
            _labManagementContext.Labs.Remove(labDto);
            _labManagementContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public Lab? Search(int searchId)
    {
        LabDto? labDto = _labManagementContext.Labs.Where(x => x.Id == searchId).FirstOrDefault();

        if(labDto != null)
        {
            return new(){Id = labDto.Id, Name = labDto.Name, Category = new(){ Id = labDto.CategoryId }, Author = new(){ Id = labDto.AuthorId } };
        }
        else
        {
            return null;
        }
    }

    public List<Lab> SearchAll()
    {
        List<Lab> labs = new();
        var labDtos =_labManagementContext.Labs.ToList();
        labDtos.ForEach(l => labs.Add(
            new(){Id = l.Id, Name = l.Name, Category = new(){ Id = l.CategoryId }, Author = new(){ Id = l.AuthorId } }
        ));
        return labs;
    }

    public bool ValidateCategory(int categoryId)
    {
        CategoryDto? categoryDto = _labManagementContext.Categories.Where(x => x.Id == categoryId).FirstOrDefault();
        
        if(categoryDto == null)
            return false;
        else
            return true;

    }

    public bool ValidateAuthor(int authorId)
    {
        AuthorDto? authorDto = _labManagementContext.Authors.Where(x => x.Id == authorId).FirstOrDefault();

        if(authorDto == null)
            return false;
        else
            return true;

    }
}