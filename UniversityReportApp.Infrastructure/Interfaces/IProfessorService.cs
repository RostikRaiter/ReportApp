using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityReportApp.Domain.Entities;

namespace UniversityReportApp.Infrastructure.Interfaces
{
    public interface IProfessorService
    {
        Task<Professor> GetProfessorAsync(int id);
        IQueryable<Professor> GetProfessors();
        Task AddProfessorAsync(Professor professor);
        Task UpdateProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(int id);
    }
}
