using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace OfferOasisBackend.Model;

public class User: IdentityUser
{
   // public int Id { get;  }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    //private string Password { get; }
    //private string Email { get; }
}