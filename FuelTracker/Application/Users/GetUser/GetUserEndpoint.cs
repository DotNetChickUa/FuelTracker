using System.Security.Claims;
using FuelTracker.Infrastructure.Database.Entities;

namespace FuelTracker.Application.Users.GetUser;

public static class GetUserEndpoint
{
    public static void MapGetUser(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", Handler)
            .RequireAuthorization(policy => policy.RequireRole("Admin"));;
    }

    private static async Task<IResult> Handler(Guid id, GetUserHandler handler)
    {
        var result = await handler.Handle(id);
        if (result is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(GetUserResponse.FromUser(result));
    }

    public static void MapGetCurrentUser(this RouteGroupBuilder group)
    {
        group.MapGet("/me", GetCurrentUserHandler);
    }

    private static async Task<IResult> GetCurrentUserHandler(HttpContext context, GetUserHandler handler)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(userId, out var id))
        {
            return Results.NotFound();
        }

        var result = await handler.Handle(id);
        if (result is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(GetUserResponse.FromUser(result));
    }
}

public record GetUserResponse(string Email, IList<string> Roles)
{
    public static GetUserResponse FromUser(User user)
    {
        return new GetUserResponse(user.Email, user.UserRoles.Select(x => x.Role.Name).ToList());
    }
}