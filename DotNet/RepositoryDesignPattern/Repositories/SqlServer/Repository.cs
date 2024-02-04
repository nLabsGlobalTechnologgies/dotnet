using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Abstractions;
using RepositoryDesignPattern.Context;
using RepositoryDesignPattern.Interfaces;

namespace RepositoryDesignPattern.Repositories.SqlServer;

public class Repository<T> : IRepository<T>
    where T : Entity, new()
{
    private readonly AppDbContext _context;

    public DbSet<T> Entity;

    public Repository(AppDbContext context)
    {
        _context = context;
        Entity = context.Set<T>();
    }

    public int Add(T entity)
    {
        Entity.Add(entity);
        return entity.Id;
    }

    public async Task<int> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken);
        return entity.Id;
    }

    public void Update(T entity)
    {
        Entity.Update(entity);
        //efCore Tracking mekanizması var oldugu için _context.SaveChanges update ve delete için gereksizdir.
    }

    public void DeleteById(int id)
    {
        T entity = new()
        {
            Id = id
        };
        if (entity is not null)
        {
            _context.Remove(entity);
            //efCore Tracking mekanizması var oldugu için _context.SaveChanges update ve delete için gereksizdir.
        }
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Entity.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await Entity.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public IQueryable<T> GetAllReturnIQueryable()
    {
        return Entity.AsQueryable();
    }
}
