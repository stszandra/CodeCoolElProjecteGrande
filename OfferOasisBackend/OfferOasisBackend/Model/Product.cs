using System.Text.Json.Serialization;

namespace OfferOasisBackend.Models;

public class Product
{
    public int Id { get; init; }
    public string Name { get; set; }
    public ProductType ProductType { get; set; }
    public string? ProductTypeString { get; set; }
    public int Price { get; set; } 
    public int QuantityInStock { get; set; }
    public string ImageUrl { get; set; }

    public Product(int id, string name, ProductType productType, int price, int quantityInStock, string imageUrl)
    {
        Id = id;
        Name = name;
        ProductType = productType;
        ProductTypeString = Enum.GetName(typeof(ProductType), productType);
        Price = price;
        QuantityInStock = quantityInStock;
        ImageUrl = imageUrl;
    }
}
