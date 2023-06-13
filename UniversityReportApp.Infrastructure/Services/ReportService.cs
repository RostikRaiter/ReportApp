using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityReportApp.Domain.Entities;
using UniversityReportApp.Infrastructure.Data;
using UniversityReportApp.Infrastructure.Interfaces;

namespace UniversityReportApp.Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Report> GetReportAsync(int id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public IQueryable<Report> GetReports()
        {
            return _context.Reports;
        }

        public async Task AddReportAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(Report report)
        {
            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReportAsync(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
        }
    }
}
