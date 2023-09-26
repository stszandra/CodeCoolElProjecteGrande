using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public class ProductRepository : IProductRepository
{
    public string TestGetAllProducts()
    {
        return "All products!";
    }
    
    public Product? GetById(int id)
    {
        using var dbContext = new OasisContext();
        return dbContext.Products.FirstOrDefault(product => product.Id == id);
    }

    public HashSet<Product> GetAll()
    {
        using var dbContext = new OasisContext();
        return dbContext.Products.ToHashSet();
    }

    public void Add(Product product)
    {
        using var dbContext = new OasisContext();
        dbContext.Add(product);
        dbContext.SaveChanges();   
    }

    public void Remove(int id)
    {
        using var dbContext = new OasisContext();
        var productToRemove = GetById(id);
        dbContext.Remove(productToRemove);
        dbContext.SaveChanges();
    }
}