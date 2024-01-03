using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product> UpdateQuantityInStockAsync(int productId, int toSubtract);
}