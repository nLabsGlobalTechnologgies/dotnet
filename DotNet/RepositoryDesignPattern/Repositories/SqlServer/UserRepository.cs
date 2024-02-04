using RepositoryDesignPattern.Context;
using RepositoryDesignPattern.Interfaces;
using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Repositories.SqlServer;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public int GetUserCount(AppDbContext _context)
    {
        return _context.Users.Count();
    }
}
