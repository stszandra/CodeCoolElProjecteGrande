using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Data;
using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public class UserRepository : IUserRepository
{
    private readonly OasisContext _oasisContext;

    public UserRepository(OasisContext oasisContext)
    {
        _oasisContext = oasisContext;
    }

    public async Task<User?> GetById(int id)
    {
        return await _oasisContext.Users.FindAsync(id);
    }
    
    public async Task<IEnumerable<User?>> GetAll()
    {
     
        return await _oasisContext.Users.ToListAsync();
    }
    
    public async Task<bool> Add(User user)
    {
        bool success = true;
        try
        {
            await _oasisContext.AddAsync(user);
            await _oasisContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            success = false;
        }

        return success;
    }
    
    public async Task<User?> Remove(int id)
    {
     
        var userToRemove = await GetById(id);

        if (userToRemove == null) return userToRemove;
        _oasisContext.Remove(userToRemove);
        await _oasisContext.SaveChangesAsync();

        return userToRemove;
    }
}