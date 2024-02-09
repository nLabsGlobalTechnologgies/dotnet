namespace NewRepositoryDesignPattern.Models;

public class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set;}
    public DateTime? DeletedDate { get; set; }
}
