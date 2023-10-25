using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Data;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public class ProductRepository : IProductRepository
{
    public async Task<Product?> GetById(int id)
    {
        await using var dbContext = new OasisContext();
        return await dbContext.Products.FindAsync(id);
    }
    
    public async Task<IEnumerable<Product>> GetAll()
    {
        await using var dbContext = new OasisContext();
        return await dbContext.Products.ToListAsync();
    }
    
    public async Task<bool> Add(Product product)
    {
        bool success = true;
        await using var dbContext = new OasisContext();
        try
        {
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            success = false;
        }

        return success;
    }
    
    public async Task<Product?> Remove(int id)
    {
        await using var dbContext = new OasisContext();
        var productToRemove = await GetById(id);

        if (productToRemove == null) return productToRemove;
        dbContext.Remove(productToRemove);
        await dbContext.SaveChangesAsync();

        return productToRemove;
    }
}