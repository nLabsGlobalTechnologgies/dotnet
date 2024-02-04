using RepositoryDesignPattern.Context;
using RepositoryDesignPattern.Interfaces;
using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Repositories.SqlServer;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}
