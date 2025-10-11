using System.Text;
using FuelTracker.Application.Identity;
using FuelTracker.Application.Identity.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FuelTracker.Infrastructure.Extensions;

public static class AuthExtensions
{
    public static void AddAuth(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAuthentication()
            .AddCookie();
        builder.Services.AddAuthorization();

        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IdentityRevalidatingAuthenticationStateProvider>();
        builder.Services.AddMemoryCache();
    }
}