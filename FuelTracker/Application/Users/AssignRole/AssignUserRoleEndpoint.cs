namespace FuelTracker.Application.Users.AssignRole;

public static class AssignUserRoleEndpoint
{
    public static void MapAssignUserRole(this RouteGroupBuilder group)
    {
        group.MapPost("/{userId:guid}/roles", Handler)
            .RequireAuthorization(policy => policy.RequireRole(Infrastructure.Roles.Admin));;
    }

    private static async Task<IResult> Handler(
        Guid userId,
        AssignUserRoleRequest request,
        AssignUserRoleHandler handler)
    {
        var result = await handler.Handle(userId, request.Roles);
        if (result)
        {
            return Results.Ok();
        }
        
        return Results.BadRequest();
    }
}

public record AssignUserRoleRequest(string[] Roles);
