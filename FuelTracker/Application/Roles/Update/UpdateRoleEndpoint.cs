namespace FuelTracker.Application.Roles.Update;

public static class UpdateRoleEndpoint
{
    public static void MapUpdateRole(this RouteGroupBuilder group)
    {
        group.MapPut("/{id:guid}", Handler);
    }

    private static async Task<IResult> Handler(Guid id, UpdateRoleRequest request, UpdateRoleHandler handler)
    {
        var result = await handler.Handle(id, request);
        return result.Result;
    }
}
