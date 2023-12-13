
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class Order
{
    public int Id { get; init; }
    public string UserId { get; set; }
    private string BillingAddress { get; init; }
    private string ShippingAddress { get; init; }
    //[JsonConverter(typeof(JsonStringEnumConverter))]
    public ShippingType Shipping { get; init; }
    public string? ShippingString{ get; set; }
    //private decimal ShippingCost { get; init; }
    private DateTime OrderDate { get; init; }
    public decimal TotalPrice { get; set; }
     public Order(int id, string userId, string billingAddress, string shippingAddress, ShippingType shipping, decimal totalPrice)
     {
       Id = id;
       UserId = userId;
       BillingAddress = billingAddress;
       ShippingAddress = shippingAddress;
       Shipping = shipping;
       ShippingString = Enum.GetName(typeof(ShippingType), shipping);
       OrderDate = DateTime.Now;
       TotalPrice = totalPrice;

     }

     public Order()
     {
         
     }
        
     public decimal ShowTotalPrice()
     {
         throw new NotImplementedException();
     }
}