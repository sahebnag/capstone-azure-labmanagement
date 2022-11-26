using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Capstone.LabManagement.Entities;

[Table("LAB")]
public class LabDto
{
    [Column("ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("NAME")]
    public string? Name { get; set; }

    [Column("CATEGORY_ID")]
    public int CategoryId { get; set; }

    [Column("AUTHOR_ID")]
    public int AuthorId { get; set; }
}