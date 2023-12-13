using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace OfferOasisBackend.Model;

public class User: IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public bool? IsVip { get; set; }
}