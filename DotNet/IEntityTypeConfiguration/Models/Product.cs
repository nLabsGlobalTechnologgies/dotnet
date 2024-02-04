using System.ComponentModel.DataAnnotations.Schema;

namespace IEntityTypeConfiguration.Models;

public sealed class Product
{
    public string Id { get; set; } = Ulid.NewUlid().ToString();
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }


    [ForeignKey("Category")]
    public string CategoryId { get; set; } = Ulid.NewUlid().ToString();
    public Category? Category { get; set; }
}
