using System.Text.Json.Serialization;

namespace OfferOasisBackend.Models;

public class Product
{
    public int Id { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ProductType ProductType { get; init; }
    public DateTime PostDate { get; init; }
    public int Price { get; private set; }
    public bool IsSold { get; private set; }
    // Todo: kapcsolótábla public List<Rating> UserRatings { get; init; } 

    public Product(int id, ProductType productType, DateTime postDate, int price)
    {
        Id = id;
        ProductType = productType;
        PostDate = postDate;
        Price = price;
        IsSold = false;
    }
}
