using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Data;
using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly OasisContext _oasisContext;

    public OrderDetailRepository(OasisContext oasisContext)
    {
        _oasisContext = oasisContext;
    }

    public async Task<OrderDetail?> GetById(int id)
    {
        return await _oasisContext.OrderDetails.FindAsync(id);
    }
    
    public async Task<IEnumerable<OrderDetail?>> GetAll()
    {
     
        return await _oasisContext.OrderDetails.ToListAsync();
    }
    
    public async Task<bool> Add(OrderDetail orderDetail)
    {
        bool success = true;
        try
        {
            await _oasisContext.AddAsync(orderDetail);
            await _oasisContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            success = false;
        }

        return success;
    }
    
    public async Task<OrderDetail?> Remove(int id)
    {
     
        var orderDetailToRemove = await GetById(id);

        if (orderDetailToRemove == null) return orderDetailToRemove;
        _oasisContext.Remove(orderDetailToRemove);
        await _oasisContext.SaveChangesAsync();

        return orderDetailToRemove;
    }
}