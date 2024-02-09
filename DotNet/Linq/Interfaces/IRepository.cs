using Linq.Models;

namespace Linq.Interfaces;

public interface IRepository<T> where T : Entity
{
    IQueryable<T> GetAllReturnIQueryable();
    Task<int> AddAsync(T entity, CancellationToken cancellationToken = default);
    int Add(T entity);
    void Update(T entity);
    void DeleteById(int id);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
}
