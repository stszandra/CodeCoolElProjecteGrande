using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly List<string> _orders = new();
    
    public Task<OrderDetails> GetById(int id)
    {
        return null;
    }

    public Task<IEnumerable<Product>> GetAll()
    {
        return null;
    }

    public async Task<bool> Add(OrderDetails entity)
    {
        return true;
    }

    public Task<OrderDetails?> Remove(int id)
    {
        return null;
    }
}