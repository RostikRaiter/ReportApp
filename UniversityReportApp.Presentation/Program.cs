using UniversityReportApp.Infrastructure;  // ���� ��� ApplicationDbContext ��������� ���
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityReportApp.Infrastructure.Data;
using UniversityReportApp.Infrastructure.Services; // ���� ���� ������ �������� ��� // ���� ���� ���������� �������� ���
using UniversityReportApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using UniversityReportApp.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Build Configuration
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Identity
builder.Services.AddIdentity<Professor, IdentityRole<int>>()
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitializer.Initialize(services).Wait();
}

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
