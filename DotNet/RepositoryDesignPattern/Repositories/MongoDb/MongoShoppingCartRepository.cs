using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Repositories.MongoDb;

public class MongoShoppingCartRepository
{
    public int Add(ShoppingCart entity)
    {
        //MongoDbKayıt Kodları
        return entity.Id;
    }

    public Task<int> AddAsync(ShoppingCart entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        //MongoDbRemove Kodları
    }

    public List<ShoppingCart> GetAll(CancellationToken cancellationToken = default)
    {
        //MongoDbList Kodları
        return new List<ShoppingCart>();
    }

    public Task<List<ShoppingCart>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public int SaveChanges(CancellationToken cancellationToken = default)
    {
        return 0;
    }

    public void Update(ShoppingCart entity)
    {
        //MongoDbUpdate Kodları
    }
}
