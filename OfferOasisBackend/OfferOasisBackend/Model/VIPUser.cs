namespace OfferOasisBackend.Model;

public class VIPUser : User
{
    // - shoppingCart (user)
    // - previousOrders (user)
    // - ratings List<Rating> (user)
    private ShoppingCart _selectedProducts;
    private List<Order> _previousOrders;
    private List<Rating> _ratings;

    public VIPUser(Guid id, string firstName, string lastName, string address, string password) : base(id, firstName, lastName, address, password)
    {
    }
    
    // ... subclass-specific methods
}