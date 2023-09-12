namespace OfferOasisBackend.Model;

public class adminUser : User
{
    public adminUser(Guid id, string firstName, string lastName, string address, string password) : base(id, firstName, lastName, address, password)
    {
    }
    
    // ... subclass-specific methods
}