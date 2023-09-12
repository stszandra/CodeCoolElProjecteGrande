namespace OfferOasisBackend.Models;

public class Product
{
    public int Id { get; init; }
    public ProductType ProductType { get; init; }
    public DateTime PostDate { get; init; }
    public decimal Price { get; private set; }
    public bool IsSold { get; private set; }
    public List<Rating> UserRatings { get; init; }

    public Product(int id, ProductType productType, DateTime postDate, decimal price)
    {
        Id = id;
        ProductType = productType;
        PostDate = postDate;
        Price = price;
        IsSold = false;
        UserRatings = new List<Rating>();
    }
}