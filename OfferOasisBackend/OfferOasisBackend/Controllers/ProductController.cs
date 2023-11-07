using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Models;
using OfferOasisBackend.Service;

namespace OfferOasisBackend.Controllers;

// [Authorize]
[ApiController, Route("/products")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    
    [HttpGet]
     //[Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        return Ok(await _productRepository.GetAll());
    }
    
    [HttpGet("/GetProduct/{id}")]
     [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _productRepository.GetById(id);
        if (product == null)
        {
            _logger.LogError($"No product found in database with id: {id}");
            return NotFound($"No product found in database with id: {id}");
        }
        _logger.LogInformation($"The current product on id: {id} was shown.");
        return Ok(product);
    }
    
    [HttpPost("/AddProduct")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        var success = await _productRepository.Add(product);
        if (success)
        {
            _logger.LogInformation($"Created product: {product.Name}");
            return CreatedAtAction(nameof(AddProduct), new { id = product.Id }, product);
        }
        _logger.LogError($"Could not create product {product.Name}");
        return NotFound($"Could not create product {product.Name}"); // Todo: ?How to include more info?
    }
    
    // [HttpPost("/UpdateProduct/{id}")]
    // [Authorize(Roles = "Admin")]
    // public IActionResult UpdateProduct(int id, [FromBody] Product request)
    // {
    //     try
    //     {
    //         _productRepository.Update(id, request);
    //         return Ok($"The current city on id: {id} is successfully updated to {request}.");
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw new Exception($"{e}");        }
    //     
    // }
    //
    [HttpDelete("/DeleteProductById/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            var removedProduct = await _productRepository.Remove(id);
            if (removedProduct == null)
            {
                _logger.LogError($"No product found in database with id: {id}");
                return NotFound($"No product found in database with id: {id}");
            }
            _logger.LogInformation($"The current product on id: {id} is successfully deleted.");
            return Ok($"The current product on id: {id} is successfully deleted.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"{e}");
        }
    }
}