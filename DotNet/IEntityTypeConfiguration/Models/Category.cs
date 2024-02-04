namespace IEntityTypeConfiguration.Models;

public sealed class Category
{
    public string Id { get; set; } = Ulid.NewUlid().ToString();
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public ICollection<Product>? Products { get; set; }
}
