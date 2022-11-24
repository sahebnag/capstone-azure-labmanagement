using Capstone.LabManagement.Configuration;
using Capstone.LabManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<KeyVaultManager>();
builder.Services.AddDbContext<Capstone.LabManagement.Repository.LabManagementContext>();
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<CategoryRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
