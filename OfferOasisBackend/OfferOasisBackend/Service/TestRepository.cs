using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public class TestRepository : ITestRepository
{
    public string TestGetAllProducts()
    {
        return "All products!";
    }
    
    public async Task<Test> GetById(int id)
    {
        await using var dbContext = new OasisContext();
        return await dbContext.Test.FirstOrDefaultAsync(test => test.Id == id) ?? throw new InvalidOperationException();
    }
    
    public async Task<List<Test>> GetAll()
    {
       await using var dbContext = new OasisContext();
       return await dbContext.Test.ToListAsync();
    }
    
    public async void Add(Test test)
    {
        using var dbContext = new OasisContext();
        dbContext.Add(test);
        await dbContext.SaveChangesAsync();   
    }
    
    public  void Remove(int id)
    {
        using var dbContext = new OasisContext();
        var testToRemove = GetById(id);
        dbContext.Remove(testToRemove);
        dbContext.SaveChanges();
    }
}