using Linq.Context;
using Microsoft.EntityFrameworkCore;

namespace Linq.Repositories;

public class Repository<T> where T : class
{
    private readonly AppDbContext _context;

    public DbSet<T> Entity;

    public Repository(DbSet<T> entity, AppDbContext context)
    {
        Entity = entity;
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken);
        return entity;
    }

    public void Update(T entity)
    {
        Entity.Update(entity);
    }

    public void DeleteById(Guid id)
    {
        var entity = _context.Set<T>().Find(id);


        if (entity is not null)
        {
            _context.Remove(entity);
        }
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Entity.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Entity.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public IQueryable<T> GetAllReturnIQueryable()
    {
        return Entity.AsQueryable();
    }
}
