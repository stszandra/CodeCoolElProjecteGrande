using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public class OrderRepository : IOrderRepository
{
    private readonly List<string> _orders = new();
    
    public Order? GetById(int id)
    {
        return null;
    }

    public HashSet<Order> GetAll()
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