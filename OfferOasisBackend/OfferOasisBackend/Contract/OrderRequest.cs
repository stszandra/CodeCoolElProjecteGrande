using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Contract;

public record OrderRequest(List<OrderDetail> ListOfOrderDetails, ShippingType ShippingType, string UserId, string ShippingAddress, string BillingAddress);