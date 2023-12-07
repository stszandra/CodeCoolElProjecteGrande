using System.ComponentModel.DataAnnotations;

namespace OfferOasisBackend.Contract;

public record RegistrationRequest(
    [Required]string Email, 
    [Required]string Username, 
    [Required]string Password,
    [Required]string FirstName,
    [Required]string LastName,
    [Required]string Address
    );