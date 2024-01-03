using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Data;
using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public class OrderRepository : IOrderRepository
{
    private readonly OasisContext _oasisContext;

    public OrderRepository(OasisContext oasisContext)
    {
        _oasisContext = oasisContext;
    }

    public async Task<Order?> GetById(int id)
    {
        return await _oasisContext.Orders.FindAsync(id);
    }
    
    public async Task<IEnumerable<Order?>> GetAll()
    {
     
        return await _oasisContext.Orders.ToListAsync();
    }
    
    public async Task<bool> Add(Order order)
    {
        bool success = true;
        try
        {
            await _oasisContext.AddAsync(order);
            await _oasisContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            success = false;
        }

        return success;
    }
    
    public async Task<Order?> Remove(int id)
    {
     
        var orderToRemove = await GetById(id);

        if (orderToRemove == null) return orderToRemove;
        _oasisContext.Remove(orderToRemove);
        await _oasisContext.SaveChangesAsync();

        return orderToRemove;
    }
}