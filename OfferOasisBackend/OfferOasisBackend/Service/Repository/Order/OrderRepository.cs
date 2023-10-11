using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public class OrderRepository : IOrderRepository
{
    private readonly List<string> _orders = new();
    
    public Task<Order> GetById(int id)
    {
        return null;
    }

    public Task<List<Order>> GetAll()
    {
        return null;
    }

    public void Add(Order entity)
    {
        
    }

    public void Remove(int id)
    {
       
    }
}