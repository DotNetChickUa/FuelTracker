namespace FuelTracker.Application.Roles;

public record RoleResponse(Guid Id, string Name);
public record CreateRoleRequest(string Name);
public record UpdateRoleRequest(string Name);

public record RoleResponseResult(IResult Result)
{
    public static RoleResponseResult Created(string location, RoleResponse value) => new(Results.Created(location, value));
    public static RoleResponseResult NoContent() => new(Results.NoContent());
    public static RoleResponseResult NotFound() => new(Results.NotFound());
    public static RoleResponseResult Conflict(string message) => new(Results.Conflict(new { error = message }));
    public static RoleResponseResult BadRequest(string message) => new(Results.BadRequest(new { error = message }));
}
