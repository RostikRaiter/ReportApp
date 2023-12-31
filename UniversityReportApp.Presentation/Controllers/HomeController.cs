﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityReportApp.Presentation.Models;

namespace UniversityReportApp.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RedirectToProfessors()
        {
            return RedirectToAction("Index", "Professors");
        }

        public IActionResult RedirectToDepartments()
        {
            return RedirectToAction("Index", "Departments");
        }

        public IActionResult RedirectToFaculties()
        {
            return RedirectToAction("Index", "Faculties");
        }

        public IActionResult RedirectToReports()
        {
            return RedirectToAction("Index", "Reports");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
