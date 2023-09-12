namespace OfferOasisBackend.Model;

public abstract class User
{
    // - id
    // - email
    // - password
    // - firstname
    // - lastname
    // - address
    
    // - shoppingCart (user)
    // - previousOrders (user)
    // - ratings List<Rating> (user)
    
    private Guid Id { get; }
    private string FirstName { get; }
    private string LastName { get; }
    private string Address { get; }
    private string Password { get; }
    
    // TODO: email with validation

    protected User(Guid id, string firstName, string lastName, string address, string password)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Password = password;
    }
    
    // ... common methods?
}