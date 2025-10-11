using System.Security.Claims;
using FuelTracker.Infrastructure.Database;
using FuelTracker.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace FuelTracker.Application.Identity.Auth;

internal class AuthService(FuelTrackerDbContext dbContext, IHttpContextAccessor httpContextAccessor) : IAuthService
{
    public event EventHandler? AuthStateChanged;

    public Task<bool> IsAuthenticatedAsync()
    {
        var principal = httpContextAccessor.HttpContext?.User;
        return Task.FromResult(principal?.Identity?.IsAuthenticated == true);
    }

    public async Task<AuthResult> SignInAsync(string email, string password)
    {
        
        AuthStateChanged?.Invoke(this, EventArgs.Empty);
        return new(true, null);
    }

    public async Task SignOutAsync()
    {
        

        AuthStateChanged?.Invoke(this, EventArgs.Empty);
    }

    public Task<ClaimsPrincipal> GetClaimsPrincipalAsync()
    {
        var principal = httpContextAccessor.HttpContext?.User ?? new ClaimsPrincipal(new ClaimsIdentity());
        return Task.FromResult(principal);
    }
}