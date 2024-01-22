
namespace OfferOasisBackend.Model;

public class CartDetail
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; }
    public int Quantity { get; set; }
    public decimal ProductPrice { get; set; }

    public CartDetail(int id, int productId, string userId, int quantity, decimal productPrice)
    {
        Id = id;
        ProductId = productId;
        UserId = userId;
        Quantity = quantity;
        ProductPrice = productPrice;
    }
}