using System.Security.Claims;

namespace FuelTracker.Application.Identity.Auth;

public interface IAuthService
{
    Task<bool> IsAuthenticatedAsync();
    Task<AuthResult> SignInAsync(string email, string password);
    Task SignOutAsync();
        
    Task<ClaimsPrincipal> GetClaimsPrincipalAsync();
    event EventHandler? AuthStateChanged;
}

public record AuthResult(bool Success, string? ErrorMessage);