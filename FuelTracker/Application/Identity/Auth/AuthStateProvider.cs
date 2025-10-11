using Microsoft.AspNetCore.Components.Authorization;

namespace FuelTracker.Application.Identity.Auth;

public sealed class IdentityRevalidatingAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
{
    private readonly IAuthService _authService;

    public IdentityRevalidatingAuthenticationStateProvider(IAuthService authService)
    {
        _authService = authService;
        _authService.AuthStateChanged += OnAuthenticationStateChanged; 
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = await _authService.GetClaimsPrincipalAsync();
        return new AuthenticationState(principal);
    }

    public void Dispose()
    {
        _authService.AuthStateChanged -= OnAuthenticationStateChanged; 
    }

    private void OnAuthenticationStateChanged(object? sender, EventArgs e)
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}