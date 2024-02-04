using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Releational.Models;

public sealed class AdditionalProduct
{
    [Key]
    public Guid ProductId { get; set; }
    //[DeleteBehavior(DeleteBehavior.NoAction)]
    //public Product? Product { get; set; }
    [Column(TypeName = "varchar(150)")]
    public string? Description { get; set; }
    [Column(TypeName = "money")]
    [Required]
    public decimal Price { get; set; }
}
