using System.Security.Claims;
using FuelTracker.Infrastructure.Database;
using FuelTracker.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FuelTracker.Application.Identity.Auth;

internal class AuthService(FuelTrackerDbContext dbContext, IMemoryCache tokenStore) : IAuthService
{
    public event EventHandler? AuthStateChanged;

    public async Task<bool> IsAuthenticatedAsync()
    {
        var loginResponse = tokenStore.Get<User>("currentUser");
        return loginResponse != null;
    }

    public async Task<AuthResult> SignInAsync(string email, string password)
    {
        var user = await dbContext.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            throw new UnauthorizedAccessException("Invalid credentials");

        tokenStore.Set("currentUser", user, DateTimeOffset.MaxValue);
        AuthStateChanged?.Invoke(this, EventArgs.Empty);

        return new(true, null);
    }

    public async Task SignOutAsync()
    {
        try
        {
            tokenStore.Remove("currentUser");
        }
        catch
        {
            // Ignore
        }
        finally
        {
            AuthStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public async Task<ClaimsPrincipal> GetClaimsPrincipalAsync()
    {
        var isAuth = await IsAuthenticatedAsync();
        if (!isAuth)
        {
            return new ClaimsPrincipal(new ClaimsIdentity());
        }

        var currentUserResponse = tokenStore.Get<User>("currentUser");
        if (currentUserResponse is null)
        {
            return new ClaimsPrincipal(new ClaimsIdentity());
        }

        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, currentUserResponse.Email),
        };
        foreach (var role in currentUserResponse.UserRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
        }

        var identity = new ClaimsIdentity(claims, authenticationType: "app");
        return new ClaimsPrincipal(identity);
    }
}