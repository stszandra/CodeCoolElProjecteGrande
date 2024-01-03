using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Contract;
using OfferOasisBackend.Model;
using OfferOasisBackend.Service;

namespace OfferOasisBackend.Controllers;

// TODO:[Authorize]
[ApiController, Route("/orders")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private IOrderRepository _orderRepository;
    private IProductRepository _productRepository;
    private IOrderDetailRepository _orderDetailRepository;


    public OrderController(ILogger<OrderController> logger, IOrderRepository orders, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
    {
        _logger = logger;
        _orderRepository = orders;
        _orderDetailRepository = orderDetailRepository;
        _productRepository = productRepository;
    }

    [HttpGet()]
    public async Task<ActionResult<List<Order>>> GetAllOrders()
    {
        return Ok(await _orderRepository.GetAll());
    }
    
    [HttpPost()]
    public async Task<IActionResult> AddOrder([FromBody] OrderRequest orderRequest)
    {
        var totalPrice = 0m;
        foreach (var orderDetail in orderRequest.ListOfOrderDetails)
        {
            var product = _productRepository.GetById(orderDetail.ProductId).Result;
            if (orderDetail.Quantity > product.QuantityInStock)
            {
                _logger.LogError($"Not enough {product.Name} in stock (ordered: {orderDetail.Quantity}, in stock: {product.QuantityInStock})");
                return BadRequest($"Not enough {product.Name} in stock (ordered: {orderDetail.Quantity}, in stock: {product.QuantityInStock})");
            }
            totalPrice += orderDetail.ProductPrice * orderDetail.Quantity;
            await _productRepository.UpdateQuantityInStockAsync(orderDetail.ProductId, orderDetail.Quantity);
        }
        
        // create order
        var addedOrder = new Order(0, orderRequest.UserId, orderRequest.BillingAddress, orderRequest.ShippingAddress, orderRequest.ShippingType, totalPrice);
        var success = await _orderRepository.Add(addedOrder);
        
        
        if (!success)
        {
            _logger.LogError($"Could not add order");
            return NotFound($"Could not add order");
        }
        
        _logger.LogInformation($"Created order: {addedOrder.Id}");
        
        // Applying newly created orderId to the orderDetails
        foreach (var orderDetail in orderRequest.ListOfOrderDetails)
        {
            orderDetail.OrderId = addedOrder.Id;
            var successfullyAddedDetail = await _orderDetailRepository.Add(orderDetail);
            if (!successfullyAddedDetail)
            {
                _logger.LogError($"Could not add order detail {orderDetail.OrderDetailId}");
                return NotFound($"Could not add order detail {orderDetail.OrderDetailId}");
            }
        }
        
        return Ok($"Order with ID {addedOrder.Id} added to DB with details.");
    }
}