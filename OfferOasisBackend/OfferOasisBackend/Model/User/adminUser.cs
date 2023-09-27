namespace OfferOasisBackend.Model;

public class adminUser : User
{
    // Todo: kép link
    public adminUser(int id, string firstName, string lastName, string address, string password, string email) : base(id, firstName, lastName, address, password, email)
    {
    }
    
    // ... subclass-specific methods
}