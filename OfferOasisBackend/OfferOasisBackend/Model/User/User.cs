using System.Text.RegularExpressions;

namespace OfferOasisBackend.Model;

public abstract class User
{
    private int Id { get; }
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
    
    
    // private static bool IsValidEmail(string email)
    // {
    //     string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
		  //
    //     if (string.IsNullOrEmpty(email))
    //         return false;
		  //
    //     Regex regex = new Regex(emailPattern);
    //     return regex.IsMatch(email);
    // }
    
    // ... common methods?
}