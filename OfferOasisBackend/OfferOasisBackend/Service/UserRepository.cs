using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public class UserRepository : IUserRepository
{
    public string GetAllUsersTest()
    {
        return "A list of all the users.";
    }
    
    public User? GetById(int id)
    {
        return null;
    }

    public HashSet<User> GetAll()
    {
        return null;
    }

    public void Add(User entity)
    {
        return;
    }

    public void Remove(int id)
    {
        return;
    }
}