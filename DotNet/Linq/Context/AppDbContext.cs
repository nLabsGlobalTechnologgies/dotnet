using Linq.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Linq.Context;

public sealed class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    internal object Entry<T>()
    {
        throw new NotImplementedException();
    }
}
