using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public class TestRepository : ITestRepository
{
    public string TestGetAllProducts()
    {
        return "All products!";
    }
    
    public Test? GetById(int id)
    {
        using var dbContext = new OasisContext();
        return dbContext.Test.FirstOrDefault(test => test.Id == id);
    }
    
    public HashSet<Test> GetAll()
    {
        using var dbContext = new OasisContext();
        return dbContext.Test.ToHashSet();
    }
    
    public void Add(Test test)
    {
        using var dbContext = new OasisContext();
        dbContext.Add(test);
        dbContext.SaveChanges();   
    }
    
    public void Remove(int id)
    {
        using var dbContext = new OasisContext();
        var testToRemove = GetById(id);
        dbContext.Remove(testToRemove);
        dbContext.SaveChanges();
    }
}