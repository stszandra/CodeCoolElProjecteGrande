using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class VIPUser : User
{
    private ShoppingCart _selectedProducts;
    private List<Order> _previousOrders;
    private List<Rating> _ratings;

    public VIPUser(int id, string firstName, string lastName, string address, string password, string email) : base(id, firstName, lastName, address, password, email)
    {
    }
    
    // ... subclass-specific methods
}