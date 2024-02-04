using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Releational.Models;

[Index("Name", IsUnique = true)]
public sealed class Product
{
    public Guid Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    [Required]
    public string Name { get; set; } = string.Empty;
    public AdditionalProduct? AdditionalProduct { get; set; }
    [ForeignKey("Category")]
    public Guid CategoryId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Category? Category { get; set; }
}
