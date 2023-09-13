using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Models;
using OfferOasisBackend.Service;

namespace OfferOasisBackend.Controllers;

[ApiController, Route("/products")]
public class ProductController : ControllerBase
{
    private IProductRepository ProductRepository { get; init; }

    public ProductController(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(ProductRepository.TestGetAllProducts());
    }
    
}