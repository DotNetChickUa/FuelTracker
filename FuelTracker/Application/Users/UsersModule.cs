using FuelTracker.Application.Users.GetUser;

namespace FuelTracker.Application.Users;

public static class UsersModule
{
    public static void MapUsers(this WebApplication app)
    {
        var group = app.MapGroup("/api/v1/users")
            .RequireAuthorization();
        group.MapGetUser();
        group.MapGetCurrentUser();
    }
}