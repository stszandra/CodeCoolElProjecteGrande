using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public interface IGenericRepository<T> where T : class
{
     Task<T> GetById(int id);
     Task<List<T>> GetAll();
    void Add(T entity);
    void Remove(int id);
}