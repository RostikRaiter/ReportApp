using UniversityReportApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityReportApp.Infrastructure.Data;
using UniversityReportApp.Infrastructure.Services;
using UniversityReportApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using UniversityReportApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Build Configuration
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Identity services to the DI container.
builder.Services.AddIdentity<Professor, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add Services to the DI container.
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IReportService, ReportService>();

// Add DbContext to the DI container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Add this line
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
