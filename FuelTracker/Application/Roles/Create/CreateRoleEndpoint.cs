namespace FuelTracker.Application.Roles.Create;

public static class CreateRoleEndpoint
{
    public static void MapCreateRole(this RouteGroupBuilder group)
    {
        group.MapPost("/", Handler);
    }

    private static async Task<IResult> Handler(CreateRoleRequest request, CreateRoleHandler handler)
    {
        var result = await handler.Handle(request);
        return result.Result;
    }
}
