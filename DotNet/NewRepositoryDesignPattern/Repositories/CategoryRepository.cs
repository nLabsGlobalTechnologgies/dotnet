using NewRepositoryDesignPattern.Context;
using NewRepositoryDesignPattern.Models;

namespace NewRepositoryDesignPattern.Repositories;

public class CategoryRepository : Repository<Category>
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
