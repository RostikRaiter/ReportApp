using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniversityReportApp.Domain.Entities;
using UniversityReportApp.Infrastructure.Interfaces;

namespace UniversityReportApp.Presentation.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _service;

        public FacultyController(IFacultyService service)
        {
            _service = service;
        }

        // GET: Faculties
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetFaculties().ToListAsync());
        }

        // GET: Faculties/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var faculty = await _service.GetFacultyAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UniversityId")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                await _service.AddFacultyAsync(faculty);
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var faculty = await _service.GetFacultyAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UniversityId")] Faculty faculty)
        {
            if (id != faculty.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateFacultyAsync(faculty);
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var faculty = await _service.GetFacultyAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteFacultyAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
