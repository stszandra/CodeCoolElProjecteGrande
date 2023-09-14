using System.Text.Json.Serialization;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class Order
{
    public int Id { get; init; }
    private List<Product> Products { get; init; }
    private string BillingAddress { get; init; }
    private string ShippingAddress { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    private ShippingType Shipping { get; init; }
    private decimal ShippingCost { get; init; }
    private DateTime OrderDate { get; init; }
    private User User { get; init; }

    public Order(int id, List<Product> products, string billingAddress, string shippingAddress, ShippingType shipping, User user)
    {
        Id = id;
        Products = products;
        BillingAddress = billingAddress;
        ShippingAddress = shippingAddress;
        Shipping = shipping;
        ShippingCost = 0; // computed property to be implemented
        OrderDate = DateTime.Now;
        User = user;
    }
}