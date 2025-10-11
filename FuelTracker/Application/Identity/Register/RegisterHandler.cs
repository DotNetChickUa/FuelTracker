using FuelTracker.Infrastructure.Database;
using FuelTracker.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Application.Identity.Register;

public class RegisterHandler(FuelTrackerDbContext dbContext)
{
    public async Task Handle(RegisterRequest request)
    {
        if (await dbContext.Users.AnyAsync(u => u.Email == request.Email))
            throw new InvalidOperationException("User exists");

        PasswordHasher.CreatePasswordHash(request.Password, out var hash, out var salt);

        var user = new User
        {
            Email = request.Email,
            PasswordHash = hash,
            PasswordSalt = salt
        };

        var roles = await dbContext.Roles.Where(x => request.Roles.Contains(x.Name)).ToListAsync();

        foreach (var role in roles)
        {
            user.UserRoles.Add(new UserRole { Role = role, User = user });
        }

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
    }
}