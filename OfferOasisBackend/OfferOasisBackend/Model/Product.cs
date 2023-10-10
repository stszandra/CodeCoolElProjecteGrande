using System.Text.Json.Serialization;

namespace OfferOasisBackend.Models;

public class Product
{
    public int Id { get; init; }
    public string Name { get; set; }
   //[JsonConverter(typeof(JsonStringEnumConverter))]
    public ProductType ProductType { get; init; }
    public string ProductTypeString { get; set; }
    public int Price { get; private set; } 
    public int Quantity { get; private set; }
    public int id2 { get; set; }

    public Product(int id,string name,ProductType productType, int price,int quantity)
    {
        Id = id;
        Name = name;
        ProductType = productType;
        ProductTypeString = Enum.GetName(typeof(ProductType), productType);
        Price = price;
        Quantity = quantity;
    }
}
