namespace OfferOasisBackend.Service;

public interface IGenericRepository<T> where T : class
{
    T? GetById(int id);
    HashSet<T> GetAll();
    void Add(T entity);
    void Remove(int id);
}