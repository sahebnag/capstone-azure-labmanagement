using Capstone.LabManagement.Configuration;
using Capstone.LabManagement.Entities;
using Microsoft.EntityFrameworkCore;


namespace Capstone.LabManagement.Repository;

public class LabManagementContext : DbContext
{
    private readonly LabManagementDbConnection _lab;

    public LabManagementContext(DbContextOptions<LabManagementContext> options, IServiceProvider provider) : base(options)
    {
        _lab = ActivatorUtilities.CreateInstance<LabManagementDbConnection>(provider);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_lab.ConnectionString);
    }

    public DbSet<CategoryDto> Categories { get; set; }

    public DbSet<AuthorDto> Authors { get; set; }

    public DbSet<LabDto> Labs { get; set; }

}