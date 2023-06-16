using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityReportApp.Domain.Entities;
using System;

[Authorize]
public class ProfileController : Controller
{
    private readonly UserManager<Professor> _userManager;

    public ProfileController(UserManager<Professor> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userId = Int32.Parse(_userManager.GetUserId(User));
        var user = await _userManager.Users
            .Include(u => u.Department) // Include the department
            .FirstOrDefaultAsync(u => u.Id == userId);

        return View(user);
    }
}
