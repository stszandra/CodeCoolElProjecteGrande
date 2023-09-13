using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Model;
using OfferOasisBackend.Service;

namespace OfferOasisBackend.Controllers;

[ApiController, Route("/orders")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private IOrderRepository _orders;

    public OrderController(ILogger<OrderController> logger, IOrderRepository orders)
    {
        _logger = logger;
        _orders = orders;
    }

    [HttpGet()]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        return Ok(_orders.Test());
    }
}