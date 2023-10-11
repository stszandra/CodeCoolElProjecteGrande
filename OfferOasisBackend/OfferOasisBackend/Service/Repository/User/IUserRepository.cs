using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public interface IUserRepository : IGenericRepository<User>
{
    public string GetAllUsersTest();
    // ... type-specific methods
}