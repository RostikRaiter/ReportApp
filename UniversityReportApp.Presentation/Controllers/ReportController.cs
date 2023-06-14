using Microsoft.AspNetCore.Mvc;
using UniversityReportApp.Domain.Entities;
using UniversityReportApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UniversityReportApp.Presentation.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetReports().ToListAsync());
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var report = await _service.GetReportAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,ProfessorId,DepartmentId,Date")] Report report)
        {
            if (ModelState.IsValid)
            {
                await _service.AddReportAsync(report);
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var report = await _service.GetReportAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,ProfessorId,DepartmentId,Date")] Report report)
        {
            if (id != report.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.UpdateReportAsync(report);
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _service.GetReportAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteReportAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
