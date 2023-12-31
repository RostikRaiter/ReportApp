﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityReportApp.Domain.Entities;
using UniversityReportApp.Presentation.Controllers;
using UniversityReportApp.Presentation.Models;

namespace UniversityReportApp.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<Professor> _userManager;
        private readonly SignInManager<Professor> _signInManager;

        public RegisterController(UserManager<Professor> userManager, SignInManager<Professor> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Professor
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName, // Add this line
                    LastName = model.LastName, // Add this line
                    MiddleName = model.MiddleName, // Add this line
                    DepartmentId = model.DepartmentId, // Add this line
                    IsApproved = false
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }

}
