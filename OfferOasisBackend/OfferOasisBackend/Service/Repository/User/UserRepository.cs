using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public class UserRepository : IUserRepository
{
    public string GetAllUsersTest()
    {
        return "A list of all the users.";
    }
    
    public async Task<User> GetById(int id)
    {
        return null;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return null;
    }

    public async Task<bool> Add(User entity)
    {
        return true;
    }

    public Task<User?> Remove(int id)
    {
        return null;
    }
}