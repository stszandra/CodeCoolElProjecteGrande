using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class Order
{
    public Guid Id { get; init; }
    private List<Product> _products;
    private string BillingAddress { get; init; }
    private string ShippingAddress { get; init; }
    private string ShippingType { get; init; } // Todo: lehetne enum
    private decimal ShippingCost { get; init; }
    private DateTime OrderDate { get; init; }
    private User _user;
}