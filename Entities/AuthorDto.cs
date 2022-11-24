using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Capstone.LabManagement.Entities;

[Table("AUTHOR")]
public class AuthorDto
{
    [Column("ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("FIRST_NAME")]
    public string? FirstName { get; set; }

    [Column("LAST_NAME")]
    public string? LastName { get; set; }
}