namespace OfferOasisBackend.Model;

public class adminUser : User
{
    public adminUser(Guid id, string firstName, string lastName, string address, string password, string email) : base(id, firstName, lastName, address, password, email)
    {
    }
    
    // ... subclass-specific methods
}