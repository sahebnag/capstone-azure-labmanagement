using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Capstone.LabManagement.Entities;

[Table("CATEGORY")]
public class CategoryDto
{
    [Column("ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("NAME")]
    public string? Name { get; set; }
}