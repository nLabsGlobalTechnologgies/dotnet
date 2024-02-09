﻿using Microsoft.EntityFrameworkCore;

namespace NewRepositoryDesignPattern.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
