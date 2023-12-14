using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Model;
using OfferOasisBackend.Models;
using OfferOasisBackend.Service;

namespace OfferOasisBackend.Controllers;

// TODO:[Authorize]
[ApiController, Route("/orders")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private IOrderRepository _orderRepository;
    private IProductRepository _productRepository;
    private IOrderDetailsRepository _orderDetailsRepository;


    public OrderController(ILogger<OrderController> logger, IOrderRepository orders, IOrderDetailsRepository orderDetailsRepository, IProductRepository productRepository)
    {
        _logger = logger;
        _orderRepository = orders;
        _orderDetailsRepository = orderDetailsRepository;
        _productRepository = productRepository;
    }

    [HttpGet()]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        return Ok(_orderRepository.Test());
    }
    
    [HttpPost()]
    public async Task<IActionResult> AddOrder(List<OrderDetails> listOfOrderDetails, ShippingType shippingType, string userId, string shippingAddress, string billingAddress)
    {
        // totalPrice -- list of order details-ből
        var totalPrice = 0m;
        foreach (var orderDetail in listOfOrderDetails)
        {
            totalPrice += orderDetail.ProductPrice * orderDetail.Quantity;
        }
        
        // order létrehozása
        var addedOrder = new Order(0, userId, billingAddress, shippingAddress, shippingType, totalPrice);
        var success = await _orderRepository.Add(addedOrder);
        
        
        if (!success)
        {
            _logger.LogError($"Could not add order");
            return NotFound($"Could not add order");
            
        }
        
        // var createdOrder = CreatedAtAction(nameof(AddOrder), new { id = addedOrder.Id }, addedOrder); // TODO: SQL által adott ID?
        _logger.LogInformation($"Created order: {addedOrder.Id}");
        
        
        // List-ből egyesével recordok (SQL által adott orderID-val ellátva)
        foreach (var orderDetail in listOfOrderDetails)
        {
            orderDetail.OrderId = addedOrder.Id;
            var successfullyAddedDetail = await _orderDetailsRepository.Add(orderDetail);
            if (!successfullyAddedDetail)
            {
                _logger.LogError($"Could not add order detail");
                return NotFound($"Could not add order detail");
            }
        }
        // TODO: productRepóban quantity kivonása
        
        return Ok($"Order with ID {addedOrder.Id} added to DB with details.");


       

    }
 
}