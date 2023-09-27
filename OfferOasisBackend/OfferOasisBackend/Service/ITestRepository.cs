using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public interface ITestRepository : IGenericRepository<Test>
{
    public string TestGetAllProducts();
}