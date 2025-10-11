using System.ComponentModel.DataAnnotations;
using FuelTracker.Application.Identity;
using FuelTracker.Application.Identity.Auth;
using FuelTracker.Infrastructure.Database;
using FuelTracker.Infrastructure.Database.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Components.Pages;

public partial class Register(
    NavigationManager navigationManager,
    FuelTrackerDbContext dbContext,
    IAuthService authService) : ComponentBase
{
    private string? _email;
    private string? _password;
    private string? _confirmPassword;
    private string? _error;
    private string? _success;
    private bool _busy;

    [Parameter] [SupplyParameterFromQuery] public string? ReturnUrl { get; set; }

    private async Task RegisterUser()
    {
        _error = null;
        _success = null;

        if (string.IsNullOrWhiteSpace(_email) || !new EmailAddressAttribute().IsValid(_email))
        {
            _error = "Please enter a valid email.";
            return;
        }

        if (string.IsNullOrWhiteSpace(_password) || string.IsNullOrWhiteSpace(_confirmPassword))
        {
            _error = "Please enter and confirm your password.";
            return;
        }

        if (!string.Equals(_password, _confirmPassword, StringComparison.Ordinal))
        {
            _error = "Passwords do not match.";
            return;
        }

        _busy = true;
        try
        {
            var exists = await dbContext.Users.AnyAsync(u => u.Email == _email);
            if (exists)
            {
                _error = "An account with this email already exists.";
                return;
            }

            // Hash password and create user
            PasswordHasher.CreatePasswordHash(_password!, out var passwordHash, out var passwordSalt);

            var user = new User
            {
                Email = _email!,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            _success = "Account created. Please sign in.";
            navigationManager.NavigateTo($"/login?returnUrl={Uri.EscapeDataString(ReturnUrl ?? "/")}", replace: true);
        }
        catch (Exception)
        {
            _error = "Registration failed. Please try again.";
        }
        finally
        {
            _busy = false;
        }
    }
}