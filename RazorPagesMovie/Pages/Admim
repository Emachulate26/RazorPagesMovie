using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace YourAppNamespace.Data
{
    public static class SeedData
    {
        public static async Task EnsureAdminCreatedAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Get email and password from config
            string adminEmail = configuration["AdminSettings:Email"];
            string adminPassword = configuration["AdminSettings:Password"];

            if (string.IsNullOrWhiteSpace(adminEmail) || string.IsNullOrWhiteSpace(adminPassword))
            {
                throw new Exception("Admin credentials are not set in configuration!");
            }

            // Create Admin role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var roleResult = await roleManager.CreateAsync(new IdentityRole("Admin"));
                if (!roleResult.Succeeded)
                    throw new Exception("Failed to create Admin role: " + string.Join(", ", roleResult.Errors));
            }

            // Create Admin user if it doesn't exist
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var userResult = await userManager.CreateAsync(adminUser, adminPassword);
                if (!userResult.Succeeded)
                    throw new Exception("Failed to create Admin user: " + string.Join(", ", userResult.Errors));
            }

            // Assign Admin user to Admin role
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                var addToRoleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
                if (!addToRoleResult.Succeeded)
                    throw new Exception("Failed to assign Admin role: " + string.Join(", ", addToRoleResult.Errors));
            }
        }
    }
}
