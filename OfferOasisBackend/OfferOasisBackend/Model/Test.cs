namespace OfferOasisBackend.Model;

public class Test
{
    public int Id { get; init; }
    public string Name { get; set; }
    public int Rating { get; set; }
    public string Picture { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }

    public Test(int id, string name, int rating, string picture, int price, string description)
    {
        Id = id;
        Name = name;
        Rating = rating;
        Picture = picture;
        Price = price;
        Description = description;
    }
}