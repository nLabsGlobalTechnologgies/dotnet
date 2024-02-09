namespace NTierArchitecture.Entities.Abstractions;
public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsDeleted { get; set; } = false;
}
