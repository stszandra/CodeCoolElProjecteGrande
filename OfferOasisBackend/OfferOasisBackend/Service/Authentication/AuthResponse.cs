namespace OfferOasisBackend.Service.Authentication;

public record AuthResponse(string Email, string UserName, string userId, string Token);
