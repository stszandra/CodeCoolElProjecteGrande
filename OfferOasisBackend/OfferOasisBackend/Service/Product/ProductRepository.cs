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
        return null;
    }

    public HashSet<Product> GetAll()
    {
        return null;
    }

    public void Add(Product entity)
    {
        
    }

    public void Remove(int id)
    {
        
    }
}