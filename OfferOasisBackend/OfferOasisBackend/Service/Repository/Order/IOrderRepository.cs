using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public interface IOrderRepository : IGenericRepository<Order>
{
    public string Test()
    {
        return "Here come some order infos.";
    }
}