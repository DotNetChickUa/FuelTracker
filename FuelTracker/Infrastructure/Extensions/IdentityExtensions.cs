using FuelTracker.Application.Identity;
using FuelTracker.Application.Identity.Login;
using FuelTracker.Application.Identity.Register;

namespace FuelTracker.Infrastructure.Extensions;

public static class IdentityExtensions
{
    public static void AddIdentity(this IHostApplicationBuilder builder)
    {
        builder.AddLogin();
        builder.AddRegister();
    }

    private static void AddLogin(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<LoginHandler>();
    }

    private static void AddRegister(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<RegisterHandler>();
    }
}