using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class basicUser : User
{
    private ShoppingCart _selectedProducts;
    private List<Order> _previousOrders;
    private List<Rating> _ratings;
    
    public basicUser(int id, string firstName, string lastName, string address, string password, string email) : base(id, firstName, lastName, address, password, email)
    {
    }
    
    // ... subclass-specific methods
}