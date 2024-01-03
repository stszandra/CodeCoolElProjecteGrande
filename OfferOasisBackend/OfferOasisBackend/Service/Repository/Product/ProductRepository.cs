using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Data;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public class ProductRepository : IProductRepository
{
    private readonly OasisContext _oasisContext;

    public ProductRepository(OasisContext oasisContext)
    {
        _oasisContext = oasisContext;
    }

    public async Task<Product?> GetById(int id)
    {
        return await _oasisContext.Products.FindAsync(id);
    }
    
    public async Task<IEnumerable<Product?>> GetAll()
    {
     
        return await _oasisContext.Products.ToListAsync();
    }
    
    public async Task<bool> Add(Product product)
    {
        bool success = true;
        try
        {
            await _oasisContext.AddAsync(product);
            await _oasisContext.SaveChangesAsync();
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
     
        var productToRemove = await GetById(id);

        if (productToRemove == null) return productToRemove;
        _oasisContext.Remove(productToRemove);
        await _oasisContext.SaveChangesAsync();

        return productToRemove;
    }
    
    // public async Task<Product> UpdateProductAsync(Product updatedProduct)
    // {
    //     var existingProduct = await GetById(updatedProduct.Id);
    //
    //     if (existingProduct == null) return existingProduct;
    //
    //     existingProduct.Name = updatedProduct.Name;
    //     existingProduct.Price = updatedProduct.Price;
    //     existingProduct.ProductType = updatedProduct.ProductType;
    //     existingProduct.ProductTypeString = Enum.GetName(typeof(ProductType), updatedProduct.ProductType);
    //     existingProduct.QuantityInStock = updatedProduct.QuantityInStock;
    //     existingProduct.ImageUrl = updatedProduct.ImageUrl;
    //     
    //     await _oasisContext.SaveChangesAsync();
    //
    //     return existingProduct;
    // }
    
    public async Task<Product> UpdateQuantityInStockAsync(int productId, int toSubtract)
    {
        var existingProduct = await GetById(productId);

        if (existingProduct == null) return existingProduct;
        
        existingProduct.QuantityInStock -= toSubtract;
        
        await _oasisContext.SaveChangesAsync();

        return existingProduct;
    }
}