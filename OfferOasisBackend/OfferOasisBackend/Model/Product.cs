using System.Text.Json.Serialization;

namespace OfferOasisBackend.Models;

public class Product
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string ProductType { get; set; }
    public int Price { get; set; } 
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }

    public Product(int id,string name,string productType, int price,int quantity,string imageUrl)
    {
        Id = id;
        Name = name;
        ProductType = productType;
        Price = price;
        Quantity = quantity;
        ImageUrl = imageUrl;
    }
}
