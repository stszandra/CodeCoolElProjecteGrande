using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public class OrderRepository : IOrderRepository
{
    private readonly List<string> _orders = new();
    
    public Task<Order> GetById(int id)
    {
        return null;
    }

    public Task<IEnumerable<Order>> GetAll()
    {
        return null;
    }

    public async Task<bool> Add(Order entity)
    {
        return true;
    }

    public Task<Order?> Remove(int id)
    {
        return null;
    }
}