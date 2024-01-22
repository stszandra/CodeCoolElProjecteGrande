using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Contract;
using OfferOasisBackend.Model;
using OfferOasisBackend.Service;

namespace OfferOasisBackend.Controllers;

// TODO:[Authorize]
[ApiController, Route("/cart")]
public class CartController : ControllerBase
{
    private readonly ILogger<CartController> _logger;
    private ICartRepository _cartRepository;


    public CartController(ILogger<CartController> logger, ICartRepository cart)
    {
        _logger = logger;
        _cartRepository = cart;
    }

    [HttpGet()]
    public async Task<ActionResult<List<CartDetail>>> GetCart([Required] string userId)
    {
        return Ok(await _cartRepository.GetCartOfUser(userId));
    }
    
    [HttpPost()]
    public async Task<IActionResult> AddCart([FromBody] CartRequest cartRequest)
    {
        // Clearing cart for user
        var userId = cartRequest.ListOfCartDetails.First().UserId;
        var cartOfUser = await _cartRepository.GetCartOfUser(userId);
        foreach (var cartDetail in cartOfUser)
        {
            await _cartRepository.Remove(cartDetail.Id); //TODO: error handling
        }
        
        // Creating new cart for user
        foreach (var cartDetail in cartRequest.ListOfCartDetails)
        {
            var success = await _cartRepository.Add(cartDetail);
            if (!success)
            {
                _logger.LogError($"Could not add cartDetail with id: {cartDetail.Id}.");
                return NotFound($"Could not add cartDetail with id: {cartDetail.Id}.");
            }
        }
        _logger.LogInformation($"Created cart for user: {userId}");
       
        return Ok($"Created cart for user: {cartRequest.ListOfCartDetails.First().UserId}");
    }

    [HttpDelete()]
    public async Task<IActionResult> RemoveCart(string userId)
    {
        var cartOfUser = await _cartRepository.GetCartOfUser(userId);
        foreach (var cartDetail in cartOfUser)
        {
            await _cartRepository.Remove(cartDetail.Id); //TODO: error handling
        }

        return Ok($"Cart removed");
    }
}