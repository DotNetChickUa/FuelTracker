using FuelTracker.Application.Identity.Auth;
using Microsoft.AspNetCore.Components;

namespace FuelTracker.Components.Pages;

public partial class Login(NavigationManager navigationManager, IAuthService authService) : ComponentBase
{
    private string? _email;
    private string? _password;
    private string? _error;
    private bool _busy;
    
    [Parameter] 
    [SupplyParameterFromQuery]
    public string? ReturnUrl { get; set; }

    private async Task SignIn()
    {
        _error = null;
        _busy = true;
        try
        {
            var result = await authService.SignInAsync(_email ?? string.Empty, _password ?? string.Empty);
            if (result.Success)
            {
                var target = string.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl;
                navigationManager.NavigateTo(target, replace: true);
            }
            else
            {
                _error = result.ErrorMessage ?? "Sign in failed";
            }
        }
        finally
        {
            _busy = false;
        }
    }
}