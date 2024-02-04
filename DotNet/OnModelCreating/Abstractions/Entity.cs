using System.ComponentModel.DataAnnotations;

namespace OnModelCreating.Abstractions;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
}
