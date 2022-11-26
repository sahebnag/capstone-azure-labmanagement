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
            var authorId = lab.Author?.Id;
            var categoryId = lab.Category?.Id;

            CategoryDto? categoryDto = _labManagementContext.Categories.Where(x => x.Id == categoryId).FirstOrDefault();
            AuthorDto? authorDto = _labManagementContext.Authors.Where(x => x.Id == authorId).FirstOrDefault();

            if(categoryDto == null || authorDto == null)
                return null;

            LabDto labDto = new(){Name = lab.Name, CategoryId = categoryId ?? default(int), AuthorId = authorId ?? default(int)};
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
            var authorId = lab.Author?.Id;
            var categoryId = lab.Category?.Id;

            labDto.Name = lab.Name;
            labDto.CategoryId = categoryId ?? default(int);
            labDto.AuthorId = authorId ?? default(int);
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
            return new(){Id = labDto.Id, Name = labDto.Name, Category = new Category(){ Id = labDto.CategoryId }, Author = new Author(){ Id = labDto.AuthorId } };
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
            new(){Id = l.Id, Name = l.Name, Category = new Category(){ Id = l.CategoryId }, Author = new Author(){ Id = l.AuthorId } }
        ));
        return labs;
    }
}