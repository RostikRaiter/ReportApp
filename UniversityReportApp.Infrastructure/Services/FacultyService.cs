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
    public class FacultyService : IFacultyService
    {
        private readonly ApplicationDbContext _context;

        public FacultyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Faculty> GetFacultyAsync(int id)
        {
            return await _context.Faculties.FindAsync(id);
        }

        public IQueryable<Faculty> GetFaculties()
        {
            return _context.Faculties;
        }

        public async Task AddFacultyAsync(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFacultyAsync(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFacultyAsync(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
        }
    }
}
