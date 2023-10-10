
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class Order
{
    public int Id { get; init; }
    public int CustomerId { get; set; }
    private string BillingAddress { get; init; }
    private string ShippingAddress { get; init; }
    //[JsonConverter(typeof(JsonStringEnumConverter))]
    public ShippingType Shipping { get; init; }
    public string ShippingString{ get; set; }
    //private decimal ShippingCost { get; init; }
    //public decimal TotalPrice { get; set; }
    private DateTime OrderDate { get; init; }
    public decimal Price { get; set; }
     public Order(int id, int userId, string billingAddress, string shippingAddress, ShippingType shipping,decimal price)
     {
       Id = id;
       //validate customerId
       CustomerId = userId;
       BillingAddress = billingAddress;
       ShippingAddress = shippingAddress;
       Shipping = shipping;
       ShippingString = Enum.GetName(typeof(ShippingType), shipping);
       OrderDate = DateTime.Now;
       Price = price;

     }

     public Order()
     {
         
     }
        
     public decimal ShowTotalPrice()
     {
         throw new NotImplementedException();
     }
}