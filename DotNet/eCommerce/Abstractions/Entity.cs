namespace eCommerce.Abstractions;

public class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedDate { get; set; }
}
