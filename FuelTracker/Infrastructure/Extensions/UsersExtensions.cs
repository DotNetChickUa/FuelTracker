using FuelTracker.Application.Users.GetUser;

namespace FuelTracker.Infrastructure.Extensions;

public static class UsersExtensions
{
    public static void AddUsers(this IHostApplicationBuilder builder)
    {
        builder.AddGetUser();
    }

    private static void AddGetUser(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<GetUserHandler>();
    }
}