namespace OfferOasisBackend.Service.Authentication;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(string email, string username, string password, string role);
    Task<AuthResult> LoginAsync(string username, string password);
    Task<AuthResult> ManageUserRoleAsync(string requestEmail, string requestRoleName, bool b);
}