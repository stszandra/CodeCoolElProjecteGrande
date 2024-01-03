
namespace OfferOasisBackend.Model;

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
  
    public decimal ProductPrice { get; set; }

    public OrderDetail(int orderDetailId, int productId, int orderId, int quantity, decimal productPrice)
    {
        OrderDetailId = orderDetailId;
        ProductId = productId;
        OrderId = orderId;
        Quantity = quantity;
        ProductPrice = productPrice;
    }
}