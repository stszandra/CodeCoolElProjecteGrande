using Microsoft.AspNetCore.Identity;

namespace OfferOasisBackend.Service.Authentication;

public interface ITokenService
{
    public string CreateToken(IdentityUser user, string role);
}