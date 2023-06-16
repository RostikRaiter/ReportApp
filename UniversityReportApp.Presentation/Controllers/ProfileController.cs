using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityReportApp.Domain.Entities;

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
        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }
}
