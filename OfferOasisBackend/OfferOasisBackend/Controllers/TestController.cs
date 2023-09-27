using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Model;
using OfferOasisBackend.Service;

namespace OfferOasisBackend.Controllers;

[ApiController, Route("/test")]
public class TestController : ControllerBase
{
    private ITestRepository TestRepository { get; init; }

    public TestController(ITestRepository productRepository)
    {
        TestRepository = productRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(TestRepository.GetAll());
    }
    
    [HttpPost]
    public IActionResult AddParams(string name, int rating, string picture, int price, string description)
    {
        TestRepository.Add(new Test(0, name, rating, picture, price, description));
        return Ok($"Test {name} has been added to DB.");
    }
}