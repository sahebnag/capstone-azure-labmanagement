
using Capstone.LabManagement.Entities;
using Capstone.LabManagement.Models;

namespace Capstone.LabManagement.Repository;

public class AuthorRepository
{
    private LabManagementContext _labManagementContext;
    private readonly ILogger<AuthorRepository> _logger;

    public AuthorRepository(LabManagementContext labManagementContext, ILogger<AuthorRepository> logger)
    {
        _labManagementContext = labManagementContext;
        _logger = logger;
    }

    public Author? Create(Author author)
    {
        try
        {
            AuthorDto authorDto = new(){FirstName = author.FirstName, LastName = author.LastName};
            _labManagementContext.Authors.Add(authorDto);
            _labManagementContext.SaveChanges();
            author.Id = authorDto.Id;
            return author;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);   
            return null;
        }
        
    }

    public Author? Update(Author author, int searchId)
    {
        AuthorDto? authorDto = _labManagementContext.Authors.Where(x => x.Id == searchId).FirstOrDefault();

        if(authorDto != null)
        {
            authorDto.FirstName = author.FirstName;
            authorDto.LastName = author.LastName;
            _labManagementContext.Authors.Update(authorDto);
            _labManagementContext.SaveChanges();
            author.Id = authorDto.Id;

            return author;
        }
        else
        {
            return null;
        }
    }

    public bool Delete(int deleteId)
    {
        AuthorDto? authorDto = _labManagementContext.Authors.Where(x => x.Id == deleteId).FirstOrDefault();

        if(authorDto != null)
        {
            _labManagementContext.Authors.Remove(authorDto);
            _labManagementContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public Author? Search(int searchId)
    {
        AuthorDto? authorDto = _labManagementContext.Authors.Where(x => x.Id == searchId).FirstOrDefault();

        if(authorDto != null)
        {
            return new(){Id = authorDto.Id, FirstName = authorDto.FirstName, LastName = authorDto.LastName};
        }
        else
        {
            return null;
        }
    }

    public List<Author> SearchAll()
    {
        List<Author> authors = new();
        var authorDtos =_labManagementContext.Authors.ToList();
        authorDtos.ForEach(l => authors.Add(new Author() {Id =l.Id, FirstName =l.FirstName, LastName =l.LastName }));
        return authors;
    }
}