namespace OfferOasisBackend.Model;

public class Message
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string  Email { get; set; }
    public string Content { get; set; }
    
    public Message(int id,string userName, string email, string content)
    {
        Id = id;
        UserName = userName;
        Email = email;
        Content = content;
    }
}