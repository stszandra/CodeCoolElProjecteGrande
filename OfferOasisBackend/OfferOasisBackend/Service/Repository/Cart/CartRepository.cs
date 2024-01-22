using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Data;
using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public class CartRepository : ICartRepository
{
    private readonly OasisContext _oasisContext;

    public CartRepository(OasisContext oasisContext)
    {
        _oasisContext = oasisContext;
    }

    public async Task<CartDetail?> GetById(int id)
    {
        return await _oasisContext.CartDetails.FindAsync(id);
    }
    
    public async Task<IEnumerable<CartDetail?>> GetAll()
    {
        return await _oasisContext.CartDetails.ToListAsync();
    }
    
    public async Task<bool> Add(CartDetail cartDetail)
    {
        bool success = true;
        try
        {
            await _oasisContext.AddAsync(cartDetail);
            await _oasisContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            success = false;
        }

        return success;
    }
    
    public async Task<CartDetail?> Remove(int id)
    {
     
        var cartDetailToRemove = await GetById(id);

        if (cartDetailToRemove == null) return cartDetailToRemove;
        _oasisContext.Remove(cartDetailToRemove);
        await _oasisContext.SaveChangesAsync();

        return cartDetailToRemove;
    }

    public async Task<IEnumerable<CartDetail?>> GetCartOfUser(string userId)
    {
        return await _oasisContext.CartDetails.Where(c => c.UserId == userId).ToListAsync();
    }
}