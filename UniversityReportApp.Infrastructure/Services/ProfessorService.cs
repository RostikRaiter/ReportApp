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
    public class ProfessorService : IProfessorService
    {
        private readonly ApplicationDbContext _context;

        public ProfessorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Professor> GetProfessorAsync(int id)
        {
            return await _context.Professors.FindAsync(id);
        }

        public IQueryable<Professor> GetProfessors()
        {
            return _context.Professors;
        }

        public async Task AddProfessorAsync(Professor professor)
        {
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfessorAsync(Professor professor)
        {
            _context.Professors.Update(professor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfessorAsync(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();
        }
    }
}
