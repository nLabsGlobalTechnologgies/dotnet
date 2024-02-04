using Microsoft.EntityFrameworkCore;

namespace Auth.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
