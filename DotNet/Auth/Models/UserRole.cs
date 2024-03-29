﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auth.Models;

public sealed class UserRole
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("AppUser")]
    public Guid AppUserId { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public AppUser? AppUser { get; set; }

    [ForeignKey("Role")]
    public Guid RoleId { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Role? Role { get; set; }
}
