namespace FuelTracker.Application.Identity.Register;

public record RegisterRequest(string Email, string Password, string[] Roles);