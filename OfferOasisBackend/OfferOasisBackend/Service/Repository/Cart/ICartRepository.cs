using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public interface ICartRepository : IGenericRepository<CartDetail>
{
    public Task<IEnumerable<CartDetail?>> GetCartOfUser(string userId);
}