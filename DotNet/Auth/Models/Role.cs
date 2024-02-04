using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auth.Models;

[Index("Name", IsUnique = true)]
public sealed class Role
{
    [Key]
    public Guid Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    [Required]
    public string Name { get; set; } = string.Empty;
}
