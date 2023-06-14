using Microsoft.AspNetCore.Mvc;
using UniversityReportApp.Domain.Entities;
using UniversityReportApp.Infrastructure.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UniversityReportApp.Presentation.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _service;

        public ProfessorController(IProfessorService service)
        {
            _service = service;
        }

        // GET: Professors
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProfessors().ToListAsync());
        }

        // GET: Professors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _service.GetProfessorAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }


        // GET: Professors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,MiddleName,Email,DepartmentId")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                await _service.AddProfessorAsync(professor);
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var professor = await _service.GetProfessorAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,MiddleName,Email,DepartmentId")] Professor professor)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateProfessorAsync(professor);
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var professor = await _service.GetProfessorAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteProfessorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
