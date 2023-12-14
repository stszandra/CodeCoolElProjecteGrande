namespace OfferOasisBackend.Service.Authentication;

public record AuthResult(
    bool Success,
    string Email,
    string UserName,
    string Id,
    string Token)
{
    //Error code - error message
    public readonly Dictionary<string, string> ErrorMessages = new();
}
