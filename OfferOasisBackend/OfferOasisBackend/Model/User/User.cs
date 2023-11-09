using System.Text.RegularExpressions;

namespace OfferOasisBackend.Model;

public abstract class User
{
    public int Id { get;  }
    private string FirstName { get; }
    private string LastName { get; }
    private string Address { get; }
    private string Password { get; }
    private string Email { get; }
    protected User(int id, string firstName, string lastName, string address, string password, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Password = password;
        Email = email;
    }
}