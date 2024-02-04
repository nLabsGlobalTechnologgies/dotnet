using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Releational.Models;

public sealed class UserRole
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; } //Id
    public User? User { get; set; }

    [ForeignKey("Role")]
    public Guid RoleId { get; set; } //Id
    public Role? Role { get; set; }
}
