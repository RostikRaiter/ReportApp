using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UniversityReportApp.Domain.Entities;
using UniversityReportApp.Infrastructure.Data;

public class DbInitializer
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<Professor>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>(); // Get RoleManager here

        context.Database.EnsureCreated();

        // Look for any users.
        if (context.Users.Any())
        {
            return;   // DB has been seeded
        }

        var adminRole = new IdentityRole<int> { Name = "Admin" };
        await roleManager.CreateAsync(adminRole);

        var adminUser = new Professor
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            IsApproved = true
        };

        await userManager.CreateAsync(adminUser, "Admin123!");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}
