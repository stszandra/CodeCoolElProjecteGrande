using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Models;
using OfferOasisBackend.Service;

namespace OfferOasisBackend.Controllers;

[Authorize]
[ApiController, Route("/products")]
public class ProductController : ControllerBase
{
    private IProductRepository ProductRepository { get; init; }

    public ProductController(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }
    
    [HttpGet,Authorize(Roles = "User")]
    public IActionResult GetAllProducts()
    {
        return Ok(ProductRepository.TestGetAllProducts());
    }
    
}