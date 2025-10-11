using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace FuelTracker.Application.Identity.Auth;

public sealed class IdentityRevalidatingAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
    : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = httpContextAccessor.HttpContext?.User ?? new ClaimsPrincipal(new ClaimsIdentity());
        return Task.FromResult(new AuthenticationState(principal));
    }
}