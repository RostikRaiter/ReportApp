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

        // Create a faculty before creating the department
        var faculty = new Faculty { Name = "Admin Faculty" }; // You may need to adjust this to match your Faculty model
        context.Faculties.Add(faculty);
        await context.SaveChangesAsync();

        // Create a department before creating the user
        var department = new Department { Name = "Admin Department", FacultyId = faculty.Id }; // Use the Id of the newly created faculty
        context.Departments.Add(department);
        await context.SaveChangesAsync();

        var adminUser = new Professor
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            FirstName = "Admin",
            LastName = "User",
            MiddleName = "AdminUser",
            DepartmentId = department.Id, // Use the Id of the newly created department
            IsApproved = true
        };

        await userManager.CreateAsync(adminUser, "Admin123!");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}
