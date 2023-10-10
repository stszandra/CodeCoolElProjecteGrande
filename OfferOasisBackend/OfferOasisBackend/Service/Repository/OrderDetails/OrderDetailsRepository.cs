using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly List<string> _orders = new();
    
    public Task<OrderDetails> GetById(int id)
    {
        return null;
    }

    public Task<List<OrderDetails>> GetAll()
    {
        return null;
    }

    public void Add(OrderDetails entity)
    {
        
    }

    public void Remove(int id)
    {
       
    }
}