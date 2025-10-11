namespace FuelTracker.Application.Roles.Delete;

public static class DeleteRoleEndpoint
{
    public static void MapDeleteRole(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}", Handler);
    }

    private static async Task<IResult> Handler(Guid id, DeleteRoleHandler handler)
    {
        var result = await handler.Handle(id);
        return result.Result;
    }
}
