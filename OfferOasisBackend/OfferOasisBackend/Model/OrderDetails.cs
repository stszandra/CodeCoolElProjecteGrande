using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class OrderDetails
{
    public int OrderDetailsId { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
  
    public decimal ProductPrice { get; set; }

    public OrderDetails(int orderDetailsId,int productId,int orderId,int quantity)
    {
        OrderDetailsId = orderDetailsId;
        ProductId = productId;
        OrderId = orderId;
        Quantity = quantity;
    }

    public OrderDetails()
    {
        
    }
}