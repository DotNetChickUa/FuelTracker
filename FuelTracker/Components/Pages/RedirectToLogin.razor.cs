using System.Net;
using Microsoft.AspNetCore.Components;

namespace FuelTracker.Components.Pages;

public partial class RedirectToLogin(NavigationManager navigationManager) : ComponentBase
{
    protected override void OnInitialized()
    {
        var returnUrl = WebUtility.UrlEncode(navigationManager.ToBaseRelativePath(navigationManager.Uri));
        navigationManager.NavigateTo($"/login?returnUrl={returnUrl}", forceLoad: false);
    }
}